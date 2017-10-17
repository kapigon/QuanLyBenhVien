﻿using System;
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
    public partial class frmPhieuNhapThuoc : DevExpress.XtraEditors.XtraForm
    {
        HospitalEntities db = new HospitalEntities();
        PhieuNhapThuocRepository rpo_PhieuNhap = new PhieuNhapThuocRepository();
        CT_Thuoc_PhieuNhapRepository rpo_CT_Thuoc = new CT_Thuoc_PhieuNhapRepository();
        
        // Chỉ số của dòng
        int index;
        bool isUpdate = false;

        public frmPhieuNhapThuoc()
        {
            InitializeComponent();
            LoadNCC();
            LoadDVT();
            LoadThuoc();
        }

        #region methods
        private void LoadNCC()
        {
            var result = from ncc in db.NCC_KH
                         where ncc.KichHoat == true && (ncc.LoaiNCC_KH_ID == 1 || ncc.LoaiNCC_KH_ID == 3)
                         select new
                        {
                            ID = ncc.ID,
                            TenNCC = ncc.TenNCC_KH,
                            DiaChi = ncc.DiaChi
                        };
            cbbNCC.Properties.DataSource = result.ToList();
            //cbbNCC.DataSource = result.ToList();
            cbbNCC.Properties.DisplayMember = "TenNCC";
            cbbNCC.Properties.ValueMember = "ID";
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
                         select new
                         {
                             ID = thuoc.ID,
                             MaThuoc = thuoc.MaThuoc,
                             TenThuoc = thuoc.TenThuoc
                         };
            gridColThuoc_ID.DataSource = result.ToList();
            //cbbNCC.DataSource = result.ToList();
            gridColThuoc_ID.DisplayMember = "TenThuoc";
            gridColThuoc_ID.ValueMember = "ID";
        }

        public void setValueGridControl(CT_Thuoc_PhieuNhap obj_CT_Thuoc, int _index)
        {
            //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.FocusedColumn, "New Value");
            gridView1.SetRowCellValue(_index, "Thuoc_ID", obj_CT_Thuoc.Thuoc_ID);
            gridView1.SetRowCellValue(_index, "Kho_ID", obj_CT_Thuoc.Kho_ID);
            gridView1.SetRowCellValue(_index, "DVT_Theo_DVT_Thuoc_ID", obj_CT_Thuoc.DVT_Theo_DVT_Thuoc_ID);
            gridView1.SetRowCellValue(_index, "ViTri_ID", obj_CT_Thuoc.ViTri_ID);
            gridView1.SetRowCellValue(_index, "Barcode_1", obj_CT_Thuoc.Barcode);
            gridView1.SetRowCellValue(_index, "HSD", obj_CT_Thuoc.HSD);
            gridView1.SetRowCellValue(_index, "GiaNhap", obj_CT_Thuoc.GiaNhap);
            gridView1.SetRowCellValue(_index, "SoLuong", obj_CT_Thuoc.SoLuong);
            gridView1.SetRowCellValue(_index, "SoLo", obj_CT_Thuoc.SoLo);
        }
        #endregion

        #region events
        private void frmPhieuNhapThuoc_Load(object sender, EventArgs e)
        {
            //Defaul value
            dateNgayNhap.EditValue      = DateTime.Now;
            dateNgayVietHD.EditValue    = DateTime.Now;

            grdDSThuoc.DataSource = new BindingList<CT_Thuoc_PhieuNhap>(db.CT_Thuoc_PhieuNhap.Where(p=>p.ID == 0).ToList());
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dxValidate.Validate())
            {
                int nccID           = Convert.ToInt32(cbbNCC.EditValue);
                String soPhieu      = txtSoPhieu.Text;
                String ghiChu       = txtGhiChu.Text;
                DateTime ngayNhap   = dateNgayNhap.DateTime;
                //MessageBox.Show(ngayNhap.ToString("dd/MM/yyyy"));
                String soSeri       = txtSeri.Text;
                int thueSuat        = Convert.ToInt32(cbbThueSuat.EditValue.ToString().Replace("%",""));
                String soHD         = txtSoHoaDon.Text;
                DateTime ngayVietHD = dateNgayVietHD.DateTime;
                int userID          = 100000;

                PhieuNhapThuoc obj_PhieuNhap = new PhieuNhapThuoc();

                obj_PhieuNhap.NCC_KH_ID         = nccID;
                obj_PhieuNhap.SoPhieu           = soPhieu;
                obj_PhieuNhap.GhiChu            = ghiChu;
                obj_PhieuNhap.NgayNhap          = ngayNhap;
                obj_PhieuNhap.ThueSuat          = thueSuat;
                obj_PhieuNhap.SoSeri            = soSeri;
                obj_PhieuNhap.SoHoaDon          = soHD;
                obj_PhieuNhap.NgayHoaDon        = ngayVietHD;
                obj_PhieuNhap.TongTienTruocThue = 0;            /// *
                obj_PhieuNhap.ChietKhau         = 0;            /// *
                obj_PhieuNhap.TongTienTra       = 0;            /// *
                obj_PhieuNhap.UserTao           = 100000;

                //rpo_PhieuNhap.Create(_object);
                if (gridView1.DataRowCount > 0)
                {
                    using (var dbContextTransaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            /// Tạo mới dữ liệu Phiếu nhập và Chi tiết Thuốc theo phiếu nhập
                            if (!isUpdate)
                            {
                                rpo_PhieuNhap.Create(obj_PhieuNhap);
                                if (obj_PhieuNhap.ID != null)
                                {
                                    for (int i = 0; i < gridView1.DataRowCount; i++)
                                    {
                                        CT_Thuoc_PhieuNhap obj_CT_Thuoc = new CT_Thuoc_PhieuNhap();

                                        obj_CT_Thuoc.PhieuNhapHang_ID       = obj_PhieuNhap.ID;
                                        obj_CT_Thuoc.Thuoc_ID               = Convert.ToInt64(gridView1.GetRowCellValue(i, "Thuoc_ID"));
                                        obj_CT_Thuoc.Kho_ID                 = Convert.ToInt32(gridView1.GetRowCellValue(i, "Kho_ID"));
                                        obj_CT_Thuoc.DVT_Theo_DVT_Thuoc_ID  = Convert.ToInt32(gridView1.GetRowCellValue(i, "DVT_Theo_DVT_Thuoc_ID"));
                                        obj_CT_Thuoc.ViTri_ID               = Convert.ToInt32(gridView1.GetRowCellValue(i, "ViTri_ID"));
                                        obj_CT_Thuoc.Barcode                = gridView1.GetRowCellValue(i, "Barcode_1").ToString();
                                        obj_CT_Thuoc.HSD                    = Convert.ToDateTime(gridView1.GetRowCellValue(i, "HSD"));
                                        obj_CT_Thuoc.GiaNhap                = Convert.ToDouble(gridView1.GetRowCellValue(i, "GiaNhap"));
                                        obj_CT_Thuoc.SoLuong                = Convert.ToInt32(gridView1.GetRowCellValue(i, "SoLuong"));
                                        obj_CT_Thuoc.SoLo                   = gridView1.GetRowCellValue(i, "SoLo") != null ? gridView1.GetRowCellValue(i, "SoLo").ToString() : "";
                                        obj_PhieuNhap.UserTao               = userID;

                                        rpo_CT_Thuoc.Create(obj_CT_Thuoc);
                                    }
                                }

                            }
                            else
                            { // Cập nhật

                            }

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

            CT_Thuoc_PhieuNhap obj_CT_Thuoc = new CT_Thuoc_PhieuNhap();

            long thuocID = 0;
            thuocID                             = Convert.ToInt64(gridView1.GetRowCellValue(index, "Thuoc_ID"));
            obj_CT_Thuoc.Thuoc_ID               = Convert.ToInt64(gridView1.GetRowCellValue(index, "Thuoc_ID"));
            obj_CT_Thuoc.Kho_ID                 = Convert.ToInt32(gridView1.GetRowCellValue(index, "Kho_ID"));
            obj_CT_Thuoc.DVT_Theo_DVT_Thuoc_ID  = Convert.ToInt32(gridView1.GetRowCellValue(index, "DVT_Theo_DVT_Thuoc_ID"));
            obj_CT_Thuoc.ViTri_ID               = Convert.ToInt32(gridView1.GetRowCellValue(index, "ViTri_ID"));
            obj_CT_Thuoc.Barcode                = gridView1.GetRowCellValue(index, "Barcode_1").ToString();
            obj_CT_Thuoc.HSD                    = Convert.ToDateTime(gridView1.GetRowCellValue(index, "HSD"));
            obj_CT_Thuoc.GiaNhap                = Convert.ToDouble(gridView1.GetRowCellValue(index, "GiaNhap"));
            obj_CT_Thuoc.SoLuong                = Convert.ToInt32(gridView1.GetRowCellValue(index, "SoLuong"));
            obj_CT_Thuoc.SoLo                   = gridView1.GetRowCellValue(index, "SoLo") != null ? gridView1.GetRowCellValue(index, "SoLo").ToString() : "";

            frmCT_Thuoc_PhieuNhap frmCT_Thuoc = new frmCT_Thuoc_PhieuNhap(this);
            frmCT_Thuoc.loadData(thuocID, ref obj_CT_Thuoc, row);
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

        public void loadData(long id)
        {
            PhieuNhapThuoc obj_PhieuNhap = new PhieuNhapThuoc();
            obj_PhieuNhap = rpo_PhieuNhap.GetSingle(id);

            cbbNCC.EditValue = obj_PhieuNhap.NCC_KH_ID;
            txtSoPhieu.Text = obj_PhieuNhap.SoPhieu;
            txtGhiChu.Text = obj_PhieuNhap.GhiChu;
            txtSeri.Text = obj_PhieuNhap.SoSeri;
            cbbThueSuat.EditValue = obj_PhieuNhap.ThueSuat + "%";
            txtSoHoaDon.Text =obj_PhieuNhap.SoHoaDon;
            dateNgayVietHD.EditValue = Convert.ToDateTime(obj_PhieuNhap.NgayHoaDon);

            grdDSThuoc.DataSource = new BindingList<CT_Thuoc_PhieuNhap>(db.CT_Thuoc_PhieuNhap.Where(p => p.PhieuNhapHang_ID == id).ToList());
            //int userID = 100000;
        }
    }
}