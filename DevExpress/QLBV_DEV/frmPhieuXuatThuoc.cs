 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;
using QLBV_DEV.Repository;
using QLBV_DEV.Reports.Objects;
using QLBV_DEV.Helpers;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace QLBV_DEV
{
    public partial class frmPhieuXuatThuoc : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities                db                  = new HospitalEntities();
        PhieuXuatThuocRepository        rpo_PhieuXuat       = new PhieuXuatThuocRepository();
        CT_Thuoc_PhieuXuatRepository    rpo_CT_Thuoc        = new CT_Thuoc_PhieuXuatRepository();
        NhanVien                        obj_NhanVien        = new NhanVien();

        // Chỉ số của dòng
        int index;
        bool isUpdate = false;
        long phieuxuat_ID = 0;
        #endregion

        public frmPhieuXuatThuoc()
        {
            InitializeComponent();
            grdDSThuoc.DataSource = new BindingList<CT_Thuoc_PhieuXuat>();
            dateNgayBan.EditValue = DateTime.Now;
            dateNgayVietHD.EditValue = DateTime.Now;
            chkDeNghiHuy.ReadOnly = true;

            try
            {
                LoadNCC_KH();
                LoadDVT();
                LoadThuoc();
                LoadLoaiHinhBan();
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }

            CreateSoPhieu();


           // frmMain main = new frmMain();
           // MessageBox.Show(main.obj_NhanVien.HoVaTen);
            if (LoginInfo.nhanVien != null)
            {
                obj_NhanVien = LoginInfo.nhanVien;
            }

            gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;  
        }

        #region methods
        // Create tự động số phiếu xuất
        public void CreateSoPhieu()
        {
            try
            {
                string today = DateTime.Now.ToString("yyMMdd");
                //MessageBox.Show(today);

                int soTT = rpo_PhieuXuat.getCountByDay("PX" + today);

                string soPhieu = "PX" + today + "-" + (soTT + 1).ToString("000");

                txtSoPhieu.EditValue = soPhieu;
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }
        // Load dữ liệu theo ID đổ vào các trường trong Form
        public void loadData(long id)
        {
            try
            {
                if (id > 0)
                {
                    phieuxuat_ID = id;
                    isUpdate = true;

                    PhieuXuatThuoc obj_PhieuXuat = new PhieuXuatThuoc();
                    obj_PhieuXuat = rpo_PhieuXuat.GetSingle(id);
                    if (obj_PhieuXuat != null)
                    {
                        cbbKH.EditValue             = obj_PhieuXuat.NCC_KH_ID;
                        txtSoPhieu.Text             = obj_PhieuXuat.SoPhieu;
                        txtGhiChu.Text              = obj_PhieuXuat.GhiChu;
                        txtSeri.Text                = obj_PhieuXuat.SoSeri;
                        cbbThueSuat.EditValue       = obj_PhieuXuat.ThueSuat + "%";
                        txtSoHoaDon.Text            = obj_PhieuXuat.SoHoaDon;
                        dateNgayVietHD.EditValue    = Convert.ToDateTime(obj_PhieuXuat.NgayHoaDon);
                        dateNgayBan.EditValue       = Convert.ToDateTime(obj_PhieuXuat.NgayTao);
                        txtChietKhau.Text           = obj_PhieuXuat.ChietKhau.ToString();

                        grdDSThuoc.DataSource = new BindingList<CT_Thuoc_PhieuXuat>(db.CT_Thuoc_PhieuXuat.Where(p => p.PhieuXuatHang_ID == id).ToList());

                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            long thuoc_PhieuNhap_ID = Convert.ToInt64(gridView1.GetRowCellValue(i, "CT_Thuoc_PhieuNhap_ID"));

                            //search.Properties.DataSource
                            var listThuoc = gridColThuoc_ID.DataSource as List<dynamic>;
                            if (listThuoc == null) return;

                            var x = listThuoc.FirstOrDefault(t => t.ID == thuoc_PhieuNhap_ID);

                            var ctXuat = gridView1.GetFocusedRow() as CT_Thuoc_PhieuXuat;
                            if (ctXuat == null) return;

                            gridView1.SetRowCellValue(i, "TonKho", x.TonKhoLo);
                            gridView1.SetRowCellValue(i, "Barcode", x.Barcode);
                            gridView1.SetRowCellValue(i, "HSD", x.HSD);
                            gridView1.SetRowCellValue(i, "GiaBanLe", x.GiaBanLe);
                            gridView1.SetRowCellValue(i, "GiaBanBuon", x.GiaBanBuon);
                            gridView1.SetRowCellValue(i, "ThuocID", x.ThuocID);
                            gridView1.SetRowCellValue(i, "TenThuoc", x.TenThuoc);

                            //ctXuat.SoLuong = x.TonKhoLo;
                            //ctXuat.DVT_Theo_DVT_Thuoc_ID = x.DVT_Theo_DVT_Thuoc_ID;
                        }

                        gridView1.PostEditor();

                        chkDeNghiHuy.ReadOnly = false;

                        if (obj_PhieuXuat.TrangThaiPhieu_ID == 2)
                        {
                            chkDeNghiHuy.EditValue = true;
                            btnLuu.Enabled = false;
                            btnXoa.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }

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
                             ID     = dvt.ID,
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
                         where ct_thuoc.TonKho > 0
                         //join dvt in db.DonViTinh on ct_thuoc.DVT_Theo_DVT_Thuoc_ID equals dvt.ID
                         select new
                         {
                             ID                     = ct_thuoc.ID,
                             ThuocID                = thuoc.ID,
                             MaThuoc                = thuoc.MaThuoc,
                             Barcode                = ct_thuoc.Barcode,
                             TenThuoc               = thuoc.TenThuoc,
                             TonKhoLo               = ct_thuoc.TonKho,
                             TonKhoTong             = thuoc.TonKho,
                             DVT_Theo_DVT_Thuoc_ID  = ct_thuoc.DVT_Theo_DVT_Thuoc_ID,
                             GiaBanLe               = thuoc.GiaBanLe,
                             GiaBanBuon             = thuoc.GiaBanBuon,
		                     SoLuong                = ct_thuoc.SoLuong,  
                             SoLo                   = ct_thuoc.SoLo, 
                             HSD                    = ct_thuoc.HSD
                         };
            
            //rlookHSD.DataSource= : thay bằng xử lý thêm trường trong class
            gridColThuoc_ID.DataSource = result.ToList<dynamic>();
            //cbbNCC.DataSource = result.ToList();
            gridColThuoc_ID.DisplayMember = "TenThuoc";
            gridColThuoc_ID.ValueMember = "ID";
        }

        private void LoadLoaiHinhBan()
        {
            var result = from loai in db.LoaiHinhBan
                         select new
                         {
                             ID = loai.ID,
                             TenLoaiHinhBan = loai.TenLoaiHinhBan
                         };
            cbbLoaiHinhBan.Properties.DataSource = result.ToList();
            //cbbNCC.DataSource = result.ToList();
            cbbLoaiHinhBan.Properties.DisplayMember = "TenLoaiHinhBan";
            cbbLoaiHinhBan.Properties.ValueMember = "ID";

            cbbLoaiHinhBan.EditValue = 1;
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

        // Cập nhật tổng cộng tiền
        private void CapNhatTongCong()
        {
            double tongtien     = Convert.ToDouble(gridView1.Columns["ThanhTien"].SummaryItem.SummaryValue);
            double thuesuat     = Convert.ToDouble(txtThueSuat.Text.Trim().Replace("VNĐ", ""));
            double chietkhau    = Convert.ToDouble(txtChietKhau.Text.Trim().Replace("VNĐ", ""));
            double thanhtien    = 0;

            if (gridView1.RowCount > 0)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    int soluong     = Convert.ToInt32(gridView1.GetRowCellValue(i,"SoLuong"));
                    double giaban   = Convert.ToDouble(gridView1.GetRowCellValue(i, "GiaBan"));

                    thanhtien      += soluong * giaban;
                }
            }

            tongtien = thanhtien;

            txtTongCong.Text = (tongtien + thuesuat - chietkhau).ToString();
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
            cbbKH.EditValue             = null;
            txtSoPhieu.Text             = "";
            txtGhiChu.Text              = "";
            txtSeri.Text                = "";
            cbbThueSuat.EditValue       = "0%";
            txtSoHoaDon.Text            = "";
            dateNgayVietHD.EditValue    = DateTime.Now;
            dateNgayBan.EditValue       = DateTime.Now;
            grdDSThuoc.DataSource       = new BindingList<CT_Thuoc_PhieuXuat>();
            CreateSoPhieu();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dxValidate.Validate())
            {
                try
                {
                    int khID                = Convert.ToInt32(cbbKH.EditValue);
                    String soPhieu          = txtSoPhieu.Text.Trim();
                    String ghiChu           = txtGhiChu.Text.Trim();
                    DateTime ngayBan        = dateNgayBan.DateTime;
                    String soSeri           = txtSeri.Text.Trim();
                    int thueSuat            = Convert.ToInt32(cbbThueSuat.EditValue.ToString().Replace("%",""));
                    String soHD             = txtSoHoaDon.Text.Trim();
                    DateTime ngayVietHD     = dateNgayVietHD.DateTime;
                    int userID              = Convert.ToInt32(obj_NhanVien.ID);       // 10000
                    double tongtien         = Convert.ToDouble(gridView1.Columns["ThanhTien"].SummaryItem.SummaryValue);
                    double chietkhau        = Convert.ToDouble(txtChietKhau.Text);

                    PhieuXuatThuoc obj_PhieuXuat;

                    if (!isUpdate)
                        obj_PhieuXuat = new PhieuXuatThuoc();
                    else
                        obj_PhieuXuat = rpo_PhieuXuat.GetSingle(phieuxuat_ID);

                    obj_PhieuXuat.NCC_KH_ID         = khID;
                    //obj_PhieuXuat.TrangThaiPhieu_ID = 1;            // Nháp
                    obj_PhieuXuat.LoaiHinhBan_ID    = Convert.ToInt32(cbbLoaiHinhBan.EditValue);
                    obj_PhieuXuat.SoPhieu           = soPhieu;
                    obj_PhieuXuat.GhiChu            = ghiChu;
                    obj_PhieuXuat.NgayTao           = ngayBan;
                    obj_PhieuXuat.ThueSuat          = thueSuat;
                    obj_PhieuXuat.SoSeri            = soSeri;
                    obj_PhieuXuat.SoHoaDon          = soHD;
                    obj_PhieuXuat.NgayHoaDon        = ngayVietHD;
                    obj_PhieuXuat.TongTienTruocThue = tongtien;             /// *
                    obj_PhieuXuat.ChietKhau         = chietkhau;                    /// *
                    obj_PhieuXuat.TongTienKHTra     = tongtien + (tongtien * thueSuat / 100) - chietkhau;            /// *
                    obj_PhieuXuat.UserTao           = userID;               /// *
                    if(chkDeNghiHuy.Checked)
                        obj_PhieuXuat.TrangThaiPhieu_ID = 2;
                    else
                        obj_PhieuXuat.TrangThaiPhieu_ID = 1;

                    if (gridView1.DataRowCount > 0)
                    {
                        using (var dbContextTransaction = db.Database.BeginTransaction())
                        {
                            try
                            {
                                /// Tạo Phiếu xuất
                                if (!isUpdate)
                                    rpo_PhieuXuat.Create(obj_PhieuXuat);
                                /// Lưu lại phiếu xuất
                                else
                                    rpo_PhieuXuat.Save(obj_PhieuXuat);

                                /// Khi tao 1 phiếu xuất thành công -> tạo các Chi tiết Thuốc theo phiếu xuất đó
                                if (obj_PhieuXuat.ID != null)
                                {
                                    for (int i = 0; i < gridView1.DataRowCount; i++)
                                    {
                                        CT_Thuoc_PhieuXuat obj_CT_Thuoc;
                                        int ct_thuoc_ID = 0;
                                        bool isUpdateRow = false;
                                        long ct_phieunhap_ID = 0;
                                        long thuoc_ID = 0;
                                        int soluong = 0;
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

                                        ct_phieunhap_ID                     = Convert.ToInt64(gridView1.GetRowCellValue(i, "CT_Thuoc_PhieuNhap_ID"));
                                        soluong                             = Convert.ToInt32(gridView1.GetRowCellValue(i, "SoLuong"));
                                        thuoc_ID                            = Convert.ToInt64(gridView1.GetRowCellValue(i, "ThuocID"));

                                        obj_CT_Thuoc.PhieuXuatHang_ID       = obj_PhieuXuat.ID;
                                        obj_CT_Thuoc.CT_Thuoc_PhieuNhap_ID  = Convert.ToInt64(gridView1.GetRowCellValue(i, "CT_Thuoc_PhieuNhap_ID"));
                                        obj_CT_Thuoc.DVT_Theo_DVT_Thuoc_ID  = Convert.ToInt32(gridView1.GetRowCellValue(i, "DVT_Theo_DVT_Thuoc_ID"));
                                        obj_CT_Thuoc.LoaiHinhBan_ID         = obj_PhieuXuat.LoaiHinhBan_ID;
                                        obj_CT_Thuoc.GiaBan                 = Convert.ToDouble(gridView1.GetRowCellValue(i, "GiaBan"));
                                        obj_CT_Thuoc.SoLuong                = Convert.ToInt32(gridView1.GetRowCellValue(i, "SoLuong"));
                                        obj_CT_Thuoc.TongTien               = Convert.ToDouble(gridView1.GetRowCellValue(i, "ThanhTien"));
                                        obj_CT_Thuoc.GhiChu                 = gridView1.GetRowCellValue(i, "GhiChu") != null ? gridView1.GetRowCellValue(i, "GhiChu").ToString() : "";
                                        obj_PhieuXuat.UserTao               = userID;


                                        /// Nếu 'row' chưa có 1 Chi tiết Thuốc thì tạo mới
                                        if (!isUpdateRow)
                                            rpo_CT_Thuoc.Create(obj_CT_Thuoc);
                                        /// Lưu lại 1 Chi tiết Thuốc
                                        else
                                            rpo_CT_Thuoc.Save(obj_CT_Thuoc);

                                        /// Cập nhật lại số lượng thuốc theo CT_Thuoc_PhieuNhap
                                        CT_Thuoc_PhieuNhapRepository rpo_CT_PhieuNhap = new CT_Thuoc_PhieuNhapRepository();
                                        CT_Thuoc_PhieuNhap obj_CT_PhieuNhap = rpo_CT_PhieuNhap.GetSingle(ct_phieunhap_ID);
                                        obj_CT_PhieuNhap.TonKho -= soluong;
                                        rpo_CT_PhieuNhap.Save(obj_CT_PhieuNhap);


                                        /// Cập số lượng tồn kho Thuốc
                                        ThuocRepository rpo_Thuoc = new ThuocRepository();
                                        Thuoc obj_Thuoc = rpo_Thuoc.GetSingle(thuoc_ID);

                                        obj_Thuoc.TonKho = rpo_Thuoc.GetCountTonKho(thuoc_ID);

                                        rpo_Thuoc.Save(obj_Thuoc); 

                                    }
                                }
                                //this.Close();
                                MessageBox.Show("Lưu thành công");
                                btnLuu.Enabled = false;
                                chkDeNghiHuy.ReadOnly = false;

                                //frmMain frmMain = new frmMain(3);
                            }
                            catch (Exception)
                            {
                                dbContextTransaction.Rollback();
                                MessageBox.Show("Quá trình xử lý không thành công");
                            }
                        }
                    }
                    else // Danh sách grid trống, chưa có dữ liệu
                    {
                        MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(2));
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
                }
            }
            else
            {
                MessageBox.Show("Bạn phải nhập nhưng trường có dấu * màu đỏ");

            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                List<oPhieuXuatThuoc> lstPhieuXuatThuoc = new List<oPhieuXuatThuoc>();
                oPhieuXuatThuoc o_PhieuXuatThuoc;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    o_PhieuXuatThuoc            = new oPhieuXuatThuoc();
                    o_PhieuXuatThuoc.TenThuoc   = gridView1.GetRowCellValue(i, "TenThuoc").ToString();
                    o_PhieuXuatThuoc.DVT        = gridView1.GetRowCellDisplayText(i, "DVT_Theo_DVT_Thuoc_ID").ToString();
                    o_PhieuXuatThuoc.SoLuong    = Convert.ToInt32(gridView1.GetRowCellValue(i, "SoLuong"));
                    o_PhieuXuatThuoc.GiaBan     = Convert.ToDouble(gridView1.GetRowCellValue(i, "GiaBan"));
                    o_PhieuXuatThuoc.ThanhTien  = Convert.ToDouble(gridView1.GetRowCellValue(i, "ThanhTien"));

                    lstPhieuXuatThuoc.Add(o_PhieuXuatThuoc);
                }

                frmPrint print = new frmPrint();
                print.printDSThuoc(lstPhieuXuatThuoc);
                print.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        // Bắt sự kiện select dòng -> lấy ra Index
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            index = gridView1.FocusedRowHandle;
            CapNhatTongCong();
        } 

        // Bắt sự kiện thay đổi khi chọn Tên thuốc -> tự động đưa ra dữ liệu vào các cột trong gridcontrol tương ứng
        private void gridColThuoc_ID_EditValueChanged(object sender, EventArgs e)
        {
            //CT_Thuoc_PhieuXuat

            //MessageBox.Show(gridView1.FocusedRowHandle.ToString());
            int _index = gridView1.FocusedRowHandle;
            
            var search = sender as SearchLookUpEdit;
            if (search == null) return;

            var id = (search.EditValue == null || search.EditValue == DBNull.Value) ? 0 : Convert.ToInt32(search.EditValue);

           //search.Properties.DataSource
            var listThuoc = search.Properties.DataSource as List<dynamic>;
            if (listThuoc == null) return;

            var x = listThuoc.FirstOrDefault(t => t.ID == id);

            var ctXuat = gridView1.GetFocusedRow() as CT_Thuoc_PhieuXuat;
            if (ctXuat == null) return;
            ctXuat.SoLuong                  = 0;
            ctXuat.DVT_Theo_DVT_Thuoc_ID    = x.DVT_Theo_DVT_Thuoc_ID;
            ctXuat.TenThuoc                 = x.TenThuoc;
            ctXuat.Barcode                  = x.Barcode;
            ctXuat.GiaBan                   = x.GiaBanLe;
            ctXuat.TonKho                   = x.TonKhoLo;
            ctXuat.HSD                      = x.HSD;
            ctXuat.GiaBanLe                 = x.GiaBanLe;
            ctXuat.GiaBanBuon               = x.GiaBanBuon;
            ctXuat.ThuocID                  = x.ThuocID;

            gridView1.PostEditor();


            // Nhảy vào ô số lượng sau khi chọn tên thuốc
            gridView1.FocusedRowHandle = _index;
            gridView1.FocusedColumn = gridView1.Columns["SoLuong"];
            gridView1.ShowEditor();
            //-------------------------------------------

            CapNhatTongCong();
        }

        private void txtColGiaBan_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.PostEditor();
            CapNhatTongCong();
        }

        private void txtColSoLuong_EditValueChanged(object sender, EventArgs e)
        {
            index = gridView1.FocusedRowHandle;
            gridView1.PostEditor();
            int soluong = Convert.ToInt32(gridView1.GetRowCellValue(index, "SoLuong"));
            int tonkho = Convert.ToInt32(gridView1.GetRowCellValue(index, "TonKho"));
            if (soluong > tonkho)
            {
                MessageBox.Show("Số lượng nhập vượt quá số lượng trong kho");
                gridView1.SetRowCellValue(index, "SoLuong", tonkho);
            }
            CapNhatTongCong();
        }

        private void txtColThanhTien_EditValueChanged(object sender, EventArgs e)
        {
            CapNhatTongCong();
        }


        // Mở form thêm khách hàng khi kích vào dấu + trong cbb khách hàng
        private void cbbKH_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind.ToString() == "Plus")
            {
                try
                {
                    frmThemNCC_KH frmThemNCC_KH = new frmThemNCC_KH(); // 2 : KH
                    frmThemNCC_KH.ChonNCC_KH(2);
                    frmThemNCC_KH.FormClosed += new FormClosedEventHandler(frmThemNCC_KHClosed);
                    frmThemNCC_KH.ShowDialog();
                }
                catch (Exception)
                {
                    MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
                }
            }
        }

        // Sự kiện thay đổi loại bán Lẻ - Buôn -> thay đổi giá tương ứng
        private void cbbLoaiHinhBan_EditValueChanged(object sender, EventArgs e)
        {
            int loaihinhban_ID = Convert.ToInt32(cbbLoaiHinhBan.EditValue);

            if(gridView1.DataRowCount > 0 && gridView1 != null){
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    if(loaihinhban_ID == 2){
                        gridView1.SetRowCellValue(i, "GiaBan", gridView1.GetRowCellValue(i, "GiaBanBuon"));
                    }else{
                        gridView1.SetRowCellValue(i, "GiaBan", gridView1.GetRowCellValue(i, "GiaBanLe"));
                    }
                }
            }
        }

        private void frmThemNCC_KHClosed(object sender, FormClosedEventArgs e)
        {
            LoadNCC_KH();
        }

        private void txtKhachDua_EditValueChanged(object sender, EventArgs e)
        {
            double tongcong = Convert.ToDouble(txtTongCong.Text.Trim().Replace("VNĐ", ""));
            double khachtra = Convert.ToDouble(txtKhachDua.Text.Trim().Replace("VNĐ", ""));

            txtConLai.Text = (khachtra - tongcong).ToString();
        }

        private void cbbThueSuat_SelectedIndexChanged(object sender, EventArgs e)
        {
            double tongtien     = Convert.ToDouble(gridView1.Columns["ThanhTien"].SummaryItem.SummaryValue);
            int thueSuat        = Convert.ToInt32(cbbThueSuat.EditValue.ToString().Replace("%", ""));

            txtThueSuat.Text    = (tongtien * thueSuat / 100).ToString();
        }

        private void txtChietKhau_EditValueChanged(object sender, EventArgs e)
        {
            CapNhatTongCong();
        }

        private void txtThueSuat_EditValueChanged(object sender, EventArgs e)
        {
            CapNhatTongCong();
        }
                      

        private void chkDeNghiHuy_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (phieuxuat_ID > 0)
                {
                    PhieuXuatThuoc obj_PhieuXuat;
                    obj_PhieuXuat = rpo_PhieuXuat.GetSingle(phieuxuat_ID);
                    if(Convert.ToBoolean(chkDeNghiHuy.EditValue)){
                        obj_PhieuXuat.TrangThaiPhieu_ID = 2;
                        rpo_PhieuXuat.Save(obj_PhieuXuat);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (phieuxuat_ID > 0)
                {
                    DialogResult dialogResult = MessageBox.Show(txtSoPhieu.Text, "Xác nhận xóa?", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        if (gridView1.DataRowCount > 0)
                        {
                            using (var dbContextTransaction = db.Database.BeginTransaction())
                            {
                                try
                                {
                                    PhieuXuatThuoc obj_PhieuXuat = rpo_PhieuXuat.GetSingle(phieuxuat_ID);
                                    if(obj_PhieuXuat != null){
                                        /// Cập nhật lại cho 
                                        obj_PhieuXuat.Xoa       = true;
                                        obj_PhieuXuat.UserXoa   = obj_NhanVien.ID;
                                        obj_PhieuXuat.TrangThaiPhieu_ID = 4;        // Trạng thái: đã xóa/hủy
                                        rpo_PhieuXuat.Save(obj_PhieuXuat);

                                        /// Khi tao 1 phiếu xuất thành công -> tạo các Chi tiết Thuốc theo phiếu xuất đó
                                        if (obj_PhieuXuat.ID != null)
                                        {
                                            for (int i = 0; i < gridView1.DataRowCount; i++)
                                            {
                                                CT_Thuoc_PhieuXuat obj_CT_Thuoc;
                                                int ct_thuoc_ID = 0;
                                                long ct_phieunhap_ID = 0;
                                                long thuoc_ID = 0;
                                                int soluong = 0;

                                                /// Kiểm tra xem ID đã tồn tại trong 'row' chưa
                                                if (gridView1.GetRowCellValue(i, "ID") != "" && Convert.ToInt32(gridView1.GetRowCellValue(i, "ID")) > 0)
                                                {
                                                    ct_thuoc_ID = Convert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                                                    obj_CT_Thuoc = rpo_CT_Thuoc.GetSingle(ct_thuoc_ID);
                                                    if (obj_CT_Thuoc != null)
                                                    {
                                                        obj_CT_Thuoc.GiaBan     = 0;
                                                        obj_CT_Thuoc.TongTien   = 0;
                                                        obj_CT_Thuoc.SoLuong    = 0;

                                                        /// Lưu lại 1 Chi tiết Thuốc
                                                        rpo_CT_Thuoc.Save(obj_CT_Thuoc);
                                                    }
                                                }

                                                ct_phieunhap_ID = Convert.ToInt64(gridView1.GetRowCellValue(i, "CT_Thuoc_PhieuNhap_ID"));
                                                soluong = Convert.ToInt32(gridView1.GetRowCellValue(i, "SoLuong"));
                                                thuoc_ID = Convert.ToInt64(gridView1.GetRowCellValue(i, "ThuocID"));                                  

                                                /// Trả lại thuốc theo CT_Thuoc_PhieuNhap
                                                CT_Thuoc_PhieuNhapRepository rpo_CT_PhieuNhap = new CT_Thuoc_PhieuNhapRepository();
                                                CT_Thuoc_PhieuNhap obj_CT_PhieuNhap = rpo_CT_PhieuNhap.GetSingle(ct_phieunhap_ID);
                                                if (obj_CT_PhieuNhap != null)
                                                {
                                                    if (obj_CT_PhieuNhap.TonKho >= 0)
                                                        obj_CT_PhieuNhap.TonKho += soluong;
                                                    else
                                                        obj_CT_PhieuNhap.TonKho = soluong;

                                                    rpo_CT_PhieuNhap.Save(obj_CT_PhieuNhap);
                                                }

                                                /// Cập số lượng tồn kho Thuốc
                                                ThuocRepository rpo_Thuoc = new ThuocRepository();
                                                Thuoc obj_Thuoc = rpo_Thuoc.GetSingle(thuoc_ID);

                                                if (obj_Thuoc != null)
                                                {
                                                    obj_Thuoc.TonKho = rpo_Thuoc.GetCountTonKho(thuoc_ID);

                                                    rpo_Thuoc.Save(obj_Thuoc);
                                                }

                                            }
                                        }
                                        //this.Close();
                                        MessageBox.Show("Xóa thành công");
                                        this.Close();
                                    }
                                }
                                catch (Exception)
                                {
                                    dbContextTransaction.Rollback();
                                    MessageBox.Show("Quá trình xử lý không thành công");
                                }
                            }
                        } 
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }

    

        #region Sothutu
        //Tạo số thứ tự tăng tự động cho 1 gridView. Dùng cho cả trường hợp group.
        //Thêm dòng sau vào dưới InitializeComponent():
        //gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator; 
        //Sử dụng thư viện:
        //using DevExpress.XtraGrid.Views.Grid;

        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!gridView1.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
            {
                if (e.Info.IsRowIndicator) //Nếu là dòng Indicator
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1; //Không hiển thị hình
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); //Số thứ tự tăng dần
                    }
                    SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước của vùng hiển thị Text
                    Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); }));
            }

        }
        #endregion

        //Xóa dòng khi ấn nút Delete
        private void grdDSThuoc_ProcessGridKey(object sender, KeyEventArgs e)
        {
            var grid = sender as GridControl;
            var view = grid.FocusedView as GridView;
            if (e.KeyData == Keys.Delete)
            {
                view.DeleteSelectedRows();
                e.Handled = true;
            }
        }

    #endregion
    }
}