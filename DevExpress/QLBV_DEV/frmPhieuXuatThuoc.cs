using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBV_DEV.Repository;
using System.Collections;

namespace QLBV_DEV
{
    public partial class frmPhieuXuatThuoc : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities db = new HospitalEntities();
        PhieuXuatThuocRepository rpo_PhieuXuat = new PhieuXuatThuocRepository();
        CT_Thuoc_PhieuXuatRepository rpo_CT_Thuoc = new CT_Thuoc_PhieuXuatRepository();
        
        // Chỉ số của dòng
        int index;
        bool isUpdate = false;
        long phieuxuat_ID = 0;
        #endregion

        public frmPhieuXuatThuoc()
        {
            InitializeComponent();
            grdDSThuoc.DataSource = new BindingList<CT_Thuoc_PhieuXuat>();
            LoadNCC_KH();
            LoadDVT();
            LoadThuoc();
        }

        #region methods
        private void LoadNCC_KH()
        {
            var result = from ncc in db.NCC_KH
                         where ncc.KichHoat == true && (ncc.LoaiNCC_KH_ID == 2 || ncc.LoaiNCC_KH_ID == 3)
                         select new
                        {
                            ID = ncc.ID,
                            TenNCC_KH = ncc.TenNCC_KH,
                            DiaChi = ncc.DiaChi
                        };
            cbbKH.Properties.DataSource = result.ToList();
            //cbbNCC.DataSource = result.ToList();
            cbbKH.Properties.DisplayMember = "TenNCC_KH";
            cbbKH.Properties.ValueMember = "ID";
        }

        private void LoadDVT()
        {
            var result = from dvt in db.DonViTinh
                         select new
                         {
                             ID = dvt.ID,
                             TenDVT = dvt.TenDVT
                         };
            cbbDVT.DataSource = result.ToList();
            //cbbNCC.DataSource = result.ToList();
            cbbDVT.DisplayMember = "TenDVT";
            cbbDVT.ValueMember = "ID";
        }

        private void LoadThuoc()
        {
            var result = from thuoc in db.Thuoc
                         join ct_thuoc in db.CT_Thuoc_PhieuNhap on thuoc.ID equals ct_thuoc.Thuoc_ID
                         //join dvt in db.DonViTinh on ct_thuoc.DVT_Theo_DVT_Thuoc_ID equals dvt.ID
                         select new
                         {
                             ID = ct_thuoc.ID,
                             MaThuoc = thuoc.MaThuoc,
                             TenThuoc = thuoc.TenThuoc,
                             TonKhoLo = ct_thuoc.TonKho,
                             TonKhoTong = thuoc.TonKho,
                             DVT_Theo_DVT_Thuoc_ID = ct_thuoc.DVT_Theo_DVT_Thuoc_ID,
		                     SoLuong = ct_thuoc.SoLuong,  // 1
                             SoLo = ct_thuoc.SoLo, 
                             HSD = ct_thuoc.HSD             //2
                         };
            
            rlookHSD.DataSource=
            gridColThuoc_ID.DataSource = result.ToList<dynamic>();
            //cbbNCC.DataSource = result.ToList();
            gridColThuoc_ID.DisplayMember = "TenThuoc";
            gridColThuoc_ID.ValueMember = "ID";
        }

        public void setValueGridControl(CT_Thuoc_PhieuXuat obj_CT_Thuoc, int _index)
        {
            //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.FocusedColumn, "New Value");
            //gridView1.SetRowCellValue(_index, "Thuoc_ID", obj_CT_Thuoc.Thuoc_ID);
            //gridView1.SetRowCellValue(_index, "Kho_ID", obj_CT_Thuoc.Kho_ID);
            //gridView1.SetRowCellValue(_index, "DVT_Theo_DVT_Thuoc_ID", obj_CT_Thuoc.DVT_Theo_DVT_Thuoc_ID);
            //gridView1.SetRowCellValue(_index, "ViTri_ID", obj_CT_Thuoc.ViTri_ID);
            //gridView1.SetRowCellValue(_index, "Barcode_1", obj_CT_Thuoc.Barcode);
            //gridView1.SetRowCellValue(_index, "HSD", obj_CT_Thuoc.HSD);
            //gridView1.SetRowCellValue(_index, "GiaNhap", obj_CT_Thuoc.GiaNhap);
            //gridView1.SetRowCellValue(_index, "SoLuong", obj_CT_Thuoc.SoLuong);
            //gridView1.SetRowCellValue(_index, "SoLo", obj_CT_Thuoc.SoLo);
        }
        #endregion

        #region events
        private void frmPhieuXuatThuoc_Load(object sender, EventArgs e)
        {
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cbbKH.EditValue            = null;
            txtSoPhieu.Text             = "";
            txtGhiChu.Text              = "";
            txtSeri.Text                = "";
            cbbThueSuat.EditValue       = "";
            txtSoHoaDon.Text            = "";
            dateNgayVietHD.EditValue    = DateTime.Now;
            dateNgayBan.EditValue      = DateTime.Now;
            grdDSThuoc.DataSource = new BindingList<CT_Thuoc_PhieuXuat>();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dxValidate.Validate())
            {
                //MessageBox.Show(ngayNhap.ToString("dd/MM/yyyy"));

                int khID            = Convert.ToInt32(cbbKH.EditValue);
                String soPhieu      = txtSoPhieu.Text.Trim();
                String ghiChu       = txtGhiChu.Text.Trim();
                DateTime ngayBan    = dateNgayBan.DateTime;
                String soSeri       = txtSeri.Text.Trim();
                int thueSuat        = Convert.ToInt32(cbbThueSuat.EditValue.ToString().Replace("%",""));
                String soHD         = txtSoHoaDon.Text.Trim();
                DateTime ngayVietHD = dateNgayVietHD.DateTime;
                int userID          = 100000;
                double tongtien = Convert.ToDouble(gridView1.Columns["ThanhTien"].SummaryItem.SummaryValue);

                PhieuXuatThuoc obj_PhieuXuat;

                if (!isUpdate)
                    obj_PhieuXuat = new PhieuXuatThuoc();
                else
                    obj_PhieuXuat = rpo_PhieuXuat.GetSingle(phieuxuat_ID);

                obj_PhieuXuat.NCC_KH_ID         = khID;
                obj_PhieuXuat.SoPhieu           = soPhieu;
                obj_PhieuXuat.GhiChu            = ghiChu;
                obj_PhieuXuat.NgayTao           = ngayBan;
                obj_PhieuXuat.ThueSuat          = thueSuat;
                obj_PhieuXuat.SoSeri            = soSeri;
                obj_PhieuXuat.SoHoaDon          = soHD;
                obj_PhieuXuat.NgayHoaDon        = ngayVietHD;
                obj_PhieuXuat.TongTienTruocThue = tongtien;            /// *
                obj_PhieuXuat.ChietKhau         = 0;            /// *
                obj_PhieuXuat.TongTienKHTra     = tongtien + tongtien * thueSuat;            /// *
                obj_PhieuXuat.UserTao           = userID;       /// *

                /// Tạo Phiếu nhập
                if (!isUpdate)
                    rpo_PhieuXuat.Create(obj_PhieuXuat);
                /// Lưu lại phiếu nhập
                else 
                    rpo_PhieuXuat.Save(obj_PhieuXuat);

                if (gridView1.DataRowCount > 0)
                {
                    using (var dbContextTransaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            /// Khi tao 1 phiếu nhập thành công -> tạo các Chi tiết Thuốc theo phiếu nhập đó
                            if (obj_PhieuXuat.ID != null)
                            {
                                for (int i = 0; i < gridView1.DataRowCount; i++)
                                {
                                    CT_Thuoc_PhieuXuat obj_CT_Thuoc;
                                    int ct_thuoc_ID = 0;
                                    bool isUpdateRow = false;

                                    /// Kiểm tra xem ID đã tồn tại trong 'row' chưa
                                    if (gridView1.GetRowCellValue(i, "ID") != "" && Convert.ToInt32(gridView1.GetRowCellValue(i, "ID")) > 0)
                                    {
                                        ct_thuoc_ID = Convert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                                        obj_CT_Thuoc = rpo_CT_Thuoc.GetSingle(ct_thuoc_ID);
                                        isUpdateRow = true;
                                    }
                                    else
                                    {
                                        obj_CT_Thuoc = new CT_Thuoc_PhieuXuat();
                                    }

                                    //obj_CT_Thuoc.PhieuXuatHang_ID       = obj_PhieuXuat.ID;
                                    //obj_CT_Thuoc.Thuoc_ID               = Convert.ToInt64(gridView1.GetRowCellValue(i, "Thuoc_ID"));
                                    //obj_CT_Thuoc.Kho_ID                 = Convert.ToInt32(gridView1.GetRowCellValue(i, "Kho_ID"));
                                    //obj_CT_Thuoc.DVT_Theo_DVT_Thuoc_ID  = Convert.ToInt32(gridView1.GetRowCellValue(i, "DVT_Theo_DVT_Thuoc_ID"));
                                    //obj_CT_Thuoc.ViTri_ID               = Convert.ToInt32(gridView1.GetRowCellValue(i, "ViTri_ID"));
                                    //obj_CT_Thuoc.Barcode                = gridView1.GetRowCellValue(i, "Barcode_1").ToString();
                                    //obj_CT_Thuoc.HSD                    = Convert.ToDateTime(gridView1.GetRowCellValue(i, "HSD"));
                                    //obj_CT_Thuoc.GiaNhap                = Convert.ToDouble(gridView1.GetRowCellValue(i, "GiaNhap"));
                                    //obj_CT_Thuoc.SoLuong                = Convert.ToInt32(gridView1.GetRowCellValue(i, "SoLuong"));
                                    //obj_CT_Thuoc.SoLo                   = gridView1.GetRowCellValue(i, "SoLo") != null ? gridView1.GetRowCellValue(i, "SoLo").ToString() : "";
                                    obj_PhieuXuat.UserTao               = userID;

                                    /// Nếu 'row' chưa có 1 Chi tiết Thuốc thì tạo mới
                                    if (!isUpdateRow)
                                        rpo_CT_Thuoc.Create(obj_CT_Thuoc);
                                    /// Lưu lại 1 Chi tiết Thuốc
                                    else
                                        rpo_CT_Thuoc.Save(obj_CT_Thuoc);
                                }
                            }
                            this.Close();
                        }
                        catch (Exception)
                        {
                            dbContextTransaction.Rollback();
                        }
                    }
                } 
                MessageBox.Show("Lưu thành công");
                btnLuu.Enabled = false;
            }
            else
            {
                MessageBox.Show("Bạn phải nhập nhưng trường có dấu * màu đỏ");

            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void grdDSThuoc_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1 == null || gridView1.SelectedRowsCount == 0) return;

            int row = index;

            CT_Thuoc_PhieuXuat obj_CT_Thuoc = new CT_Thuoc_PhieuXuat();

            long thuocID = 0;
            thuocID                             = Convert.ToInt64(gridView1.GetRowCellValue(index, "Thuoc_ID"));
            //obj_CT_Thuoc.Thuoc_ID               = Convert.ToInt64(gridView1.GetRowCellValue(index, "Thuoc_ID"));
            //obj_CT_Thuoc.Kho_ID                 = Convert.ToInt32(gridView1.GetRowCellValue(index, "Kho_ID"));
            //obj_CT_Thuoc.DVT_Theo_DVT_Thuoc_ID  = Convert.ToInt32(gridView1.GetRowCellValue(index, "DVT_Theo_DVT_Thuoc_ID"));
            //obj_CT_Thuoc.ViTri_ID               = Convert.ToInt32(gridView1.GetRowCellValue(index, "ViTri_ID"));
            //obj_CT_Thuoc.Barcode                = gridView1.GetRowCellValue(index, "Barcode_1").ToString();
            //obj_CT_Thuoc.HSD                    = Convert.ToDateTime(gridView1.GetRowCellValue(index, "HSD"));
            //obj_CT_Thuoc.GiaNhap                = Convert.ToDouble(gridView1.GetRowCellValue(index, "GiaNhap"));
            //obj_CT_Thuoc.SoLuong                = Convert.ToInt32(gridView1.GetRowCellValue(index, "SoLuong"));
            //obj_CT_Thuoc.SoLo                   = gridView1.GetRowCellValue(index, "SoLo") != null ? gridView1.GetRowCellValue(index, "SoLo").ToString() : "";

            frmCT_Thuoc_PhieuXuat frmCT_Thuoc = new frmCT_Thuoc_PhieuXuat(this);
           // frmCT_Thuoc.loadData(thuocID, ref obj_CT_Thuoc, row);
            frmCT_Thuoc.ShowInTaskbar = false;
            frmCT_Thuoc.ShowDialog();
            
            /// Get all row selected
            /*int[] selectedRows = gridView1.GetSelectedRows();
            foreach (int rowHandle in selectedRows)
            {
                long thuocID = 0;
                if (rowHandle >= 0)
                {
                    thuocID = Convert.ToInt64(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thuoc_ID_1"));
                }
                     
            }*/

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            index = gridView1.FocusedRowHandle;
        }
        #endregion


        // Load dữ liệu theo ID đổ vào các trường trong Form
        public void loadData(long id)
        {
            phieuxuat_ID    = id;
            isUpdate        = true;

            PhieuXuatThuoc obj_PhieuXuat    = new PhieuXuatThuoc();
            obj_PhieuXuat                   = rpo_PhieuXuat.GetSingle(id);

            cbbKH.EditValue             = obj_PhieuXuat.NCC_KH_ID;
            txtSoPhieu.Text             = obj_PhieuXuat.SoPhieu;
            txtGhiChu.Text              = obj_PhieuXuat.GhiChu;
            txtSeri.Text                = obj_PhieuXuat.SoSeri;
            cbbThueSuat.EditValue       = obj_PhieuXuat.ThueSuat + "%";
            txtSoHoaDon.Text            = obj_PhieuXuat.SoHoaDon;
            dateNgayVietHD.EditValue    = Convert.ToDateTime(obj_PhieuXuat.NgayHoaDon);
            dateNgayBan.EditValue       = Convert.ToDateTime(obj_PhieuXuat.NgayTao);

            grdDSThuoc.DataSource = new BindingList<CT_Thuoc_PhieuXuat>(db.CT_Thuoc_PhieuXuat.Where(p => p.PhieuXuatHang_ID == id).ToList());
        }


        private void gridColThuoc_ID_EditValueChanged(object sender, EventArgs e)
        {
            //CT_Thuoc_PhieuXuat

            var search = sender as SearchLookUpEdit;
            if (search == null) return;

            var id = (search.EditValue == null || search.EditValue == DBNull.Value) ? 0 : Convert.ToInt32(search.EditValue);

           //search.Properties.DataSource
            var listThuoc = search.Properties.DataSource as List<dynamic>;
            if (listThuoc == null) return;

            var x = listThuoc.FirstOrDefault(t => t.ID == id);

            var ctXuat = gridView1.GetFocusedRow() as CT_Thuoc_PhieuXuat;
            if (ctXuat == null) return;
            ctXuat.SoLuong = x.SoLuong;
            ctXuat.DVT_Theo_DVT_Thuoc_ID = x.DVT_Theo_DVT_Thuoc_ID;

            gridView1.PostEditor();
        }
    }
}