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
using System.Data.Entity;

namespace QLBV_DEV
{
    public partial class frmBangKeChiTietNhap : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities db = new HospitalEntities();
        PhieuNhapThuocRepository rpo_PhieuNhap = new PhieuNhapThuocRepository();

        int phieuNhapID = 0;

        int iRow;
        #endregion

        public frmBangKeChiTietNhap()
        {
            InitializeComponent();
            dateTuNgay.EditValue = DateTime.Now;
            dateDenNgay.EditValue = DateTime.Now;

            LoadBangKeCT_Nhap_Thuoc();
        }

        #region methods
        private void LoadBangKeCT_Nhap_Thuoc()
        {
            DateTime tuNgay = Convert.ToDateTime(dateTuNgay.EditValue);
            DateTime denNgay = Convert.ToDateTime(dateDenNgay.EditValue);

            var qct_nhap = from ct_nhap in db.CT_Thuoc_PhieuNhap
                           where
                           ((ct_nhap.NgayNhap.Value.Year >= tuNgay.Year && ct_nhap.NgayNhap.Value.Month >= tuNgay.Month && ct_nhap.NgayNhap.Value.Day >= tuNgay.Day)
                           && (ct_nhap.NgayNhap.Value.Year <= denNgay.Year&& ct_nhap.NgayNhap.Value.Month <= denNgay.Month&& ct_nhap.NgayNhap.Value.Day <= denNgay.Day))
                          //group ct_xuat by ct_xuat.CT_Thuoc_PhieuNhap_ID into gr_CT_Xuat
                          select new
                          {
                              Thuoc_ID = ct_nhap.Thuoc_ID,
                              DVT = ct_nhap.DVT_Theo_DVT_Thuoc_ID,
                              SoLuong = ct_nhap.SoLuong,
                              GiaNhap = ct_nhap.GiaNhap,
                              PhieuNhap_ID = ct_nhap.PhieuNhapHang_ID
                              //Thuoc_ID = gr_CT_Xuat.FirstOrDefault().ThuocID,
                              //DVT = gr_CT_Xuat.FirstOrDefault().DVT_Theo_DVT_Thuoc_ID,
                              //SoLuong = gr_CT_Xuat.Sum(p => p.SoLuong),
                              //GiaBan = gr_CT_Xuat.Sum(p => p.GiaBan),
                          };


            var query = from ct_xuat    in qct_nhap
                        join phieunhap  in db.PhieuNhapThuoc on ct_xuat.PhieuNhap_ID equals phieunhap.ID
                        join thuoc      in db.Thuoc on ct_xuat.Thuoc_ID equals thuoc.ID
                        join dvt        in db.DonViTinh on ct_xuat.DVT equals dvt.ID
                       
                        select new
                        {
                            SoPhieu = phieunhap.SoPhieu,
                            Thuoc_ID = thuoc.ID,
                            MaThuoc = thuoc.MaThuoc,
                            TenThuoc = thuoc.TenThuoc,
                            TenDVT = dvt.TenDVT,
                            SoLuong = ct_xuat.SoLuong,
                            GiaNhap = ct_xuat.GiaNhap
                        };

            grdDS_Nhap_Xuat_Ton.DataSource = query.ToList();
        }

       
        #endregion

        #region events


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frmDSPhieuNhap_Load(object sender, EventArgs e)
        {

        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadBangKeCT_Nhap_Thuoc();
        }
        

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            //sfdDSPhieuNhap.Filter = "Excel Worksheets|*.xls";
            sfdDSNhap_Xuat_Ton.Filter = "Excel files (*.xls or .xlsx)|.xls;*.xlsx";
            if (sfdDSNhap_Xuat_Ton.ShowDialog() == DialogResult.OK)
            {
                grdDS_Nhap_Xuat_Ton.ExportToXls(sfdDSNhap_Xuat_Ton.FileName);
            }
        }
        #endregion
    }
}