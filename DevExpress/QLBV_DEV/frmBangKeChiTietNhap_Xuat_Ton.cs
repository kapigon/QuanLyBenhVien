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
    public partial class frmBangKeChiTietNhap_Xuat_Ton : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities db = new HospitalEntities();
        PhieuNhapThuocRepository rpo_PhieuNhap = new PhieuNhapThuocRepository();

        int phieuNhapID = 0;

        int iRow;
        #endregion

        public frmBangKeChiTietNhap_Xuat_Ton()
        {
            InitializeComponent();
            dateTuNgay.EditValue = DateTime.Now;
            dateDenNgay.EditValue = DateTime.Now;

            LoadBangKeCT_Xuat_Nhap_Ton_Thuoc();
        }

        #region methods
        private void LoadBangKeCT_Xuat_Nhap_Ton_Thuoc()
        {
            DateTime tuNgay = Convert.ToDateTime(dateTuNgay.EditValue);
            DateTime denNgay = Convert.ToDateTime(dateDenNgay.EditValue);
            // Group nhom theo CT_Thuoc_PhieuNhap_ID
            var qCT_Xuat_TuNgay_HienTai = from ct_xuat in db.CT_Thuoc_PhieuXuat
                                          where ct_xuat.SoLuong > 0 &&
                                          (ct_xuat.NgayBan.Value.Year >= tuNgay.Year
                                          && ct_xuat.NgayBan.Value.Month >= tuNgay.Month
                                          && ct_xuat.NgayBan.Value.Day >= tuNgay.Day
                                          )
                                          group ct_xuat by ct_xuat.CT_Thuoc_PhieuNhap_ID into gr_CT_Xuat
                                          select new
                                          {
                                              CT_Thuoc_PhieuNhap_ID = gr_CT_Xuat.FirstOrDefault().CT_Thuoc_PhieuNhap_ID,
                                              SoLuong = gr_CT_Xuat.Sum(p => p.SoLuong),
                                              GiaBan = gr_CT_Xuat.Sum(p => p.GiaBan),
                                          };

            var qCT_Xuat_TuNgay_DenNgay = from ct_xuat in db.CT_Thuoc_PhieuXuat
                                          where ct_xuat.SoLuong > 0 && //(ct_xuat.NgayBan >= tuNgay && ct_xuat.NgayBan <= denNgay)
                                          ((ct_xuat.NgayBan.Value.Year >= tuNgay.Year
                                          && ct_xuat.NgayBan.Value.Month >= tuNgay.Month
                                          && ct_xuat.NgayBan.Value.Day >= tuNgay.Day
                                          )
                                          &&
                                          (ct_xuat.NgayBan.Value.Year <= denNgay.Year
                                          && ct_xuat.NgayBan.Value.Month <= denNgay.Month
                                          && ct_xuat.NgayBan.Value.Day <= denNgay.Day
                                          ))
                                          group ct_xuat by ct_xuat.CT_Thuoc_PhieuNhap_ID into gr_CT_Xuat
                                          select new
                                          {
                                              gr_CT_Xuat.FirstOrDefault().CT_Thuoc_PhieuNhap_ID,
                                              SoLuong = gr_CT_Xuat.Sum(p => p.SoLuong),
                                              GiaBan = gr_CT_Xuat.Sum(p => p.GiaBan),
                                          };

            var qCT_PhieuNhapTaiTuNgay = from ct_nhap in db.CT_Thuoc_PhieuNhap
                                             .Where(l => l.NgayNhap.Value.Year == tuNgay.Year
                                               && l.NgayNhap.Value.Month == tuNgay.Month
                                               && l.NgayNhap.Value.Day == tuNgay.Day)
                                         select new
                                         {
                                             ID = ct_nhap.ID,
                                             Thuoc_ID = ct_nhap.Thuoc_ID,
                                             SoLuongNhap = ct_nhap.SoLuong,
                                             TonKho = ct_nhap.TonKho,
                                         };

            var qCT_PhieuNhap = from ct_nhap in db.CT_Thuoc_PhieuNhap
                                where (ct_nhap.NgayNhap.Value.Year >= tuNgay.Year && ct_nhap.NgayNhap.Value.Month >= tuNgay.Month && ct_nhap.NgayNhap.Value.Day >= tuNgay.Day)
                                        && (ct_nhap.NgayNhap.Value.Year <= denNgay.Year && ct_nhap.NgayNhap.Value.Month <= denNgay.Month && ct_nhap.NgayNhap.Value.Day <= denNgay.Day)
                                select new
                                {
                                    ID = ct_nhap.ID,
                                    Thuoc_ID = ct_nhap.Thuoc_ID,
                                    SoLuongNhap = ct_nhap.SoLuong,
                                    TonKho = ct_nhap.TonKho,
                                };


            //////////////////////////////
            var nhap_truoc = from ct_nhap in db.CT_Thuoc_PhieuNhap
                                 .Where(l => l.NgayNhap.Value.Year <= tuNgay.Year
                                        && l.NgayNhap.Value.Month <= tuNgay.Month
                                        && l.NgayNhap.Value.Day < tuNgay.Day)
                             select new { ct_nhap.ID, ct_nhap.SoLuong };

            var nhap_sau = from ct_nhap in db.CT_Thuoc_PhieuNhap
                                 .Where(l => l.NgayNhap.Value.Year <= denNgay.Year
                                        && l.NgayNhap.Value.Month <= denNgay.Month
                                        && l.NgayNhap.Value.Day <= denNgay.Day)
                             select new { ct_nhap.ID, ct_nhap.SoLuong };

            var xuat_truoc = from ct_xuat in db.CT_Thuoc_PhieuXuat
                             where ct_xuat.SoLuong > 0 && 
                             (
                             ct_xuat.NgayBan.Value.Year <= tuNgay.Year
                             && ct_xuat.NgayBan.Value.Month <= tuNgay.Month
                             && ct_xuat.NgayBan.Value.Day < tuNgay.Day
                             )
                             group ct_xuat by ct_xuat.CT_Thuoc_PhieuNhap_ID into gr_CT_Xuat
                             select new
                             {
                                 gr_CT_Xuat.FirstOrDefault().CT_Thuoc_PhieuNhap_ID,
                                 SoLuong = gr_CT_Xuat.Sum(p => p.SoLuong),
                                 GiaBan = gr_CT_Xuat.Sum(p => p.GiaBan),
                             };

            var xuat_sau = from ct_xuat in db.CT_Thuoc_PhieuXuat
                             where ct_xuat.SoLuong > 0 &&
                             (
                             ct_xuat.NgayBan.Value.Year <= denNgay.Year
                             && ct_xuat.NgayBan.Value.Month <= denNgay.Month
                             && ct_xuat.NgayBan.Value.Day <= denNgay.Day
                             )
                             group ct_xuat by ct_xuat.CT_Thuoc_PhieuNhap_ID into gr_CT_Xuat
                             select new
                             {
                                 gr_CT_Xuat.FirstOrDefault().CT_Thuoc_PhieuNhap_ID,
                                 SoLuong = gr_CT_Xuat.Sum(p => p.SoLuong),
                                 GiaBan = gr_CT_Xuat.Sum(p => p.GiaBan),
                             };


            var query = from ct_nhap        in db.CT_Thuoc_PhieuNhap
                        from _nhap_truoc    in nhap_truoc.Where(_nhap_truoc => _nhap_truoc.ID == ct_nhap.ID).DefaultIfEmpty()
                        from _nhap_sau      in nhap_sau.Where(_nhap_sau => _nhap_sau.ID == ct_nhap.ID).DefaultIfEmpty()
                        from _xuat_truoc    in xuat_truoc.Where(_xuat_truoc => _xuat_truoc.CT_Thuoc_PhieuNhap_ID == ct_nhap.ID).DefaultIfEmpty()
                        from _xuat_sau      in xuat_sau.Where(_xuat_sau => _xuat_sau.CT_Thuoc_PhieuNhap_ID == ct_nhap.ID).DefaultIfEmpty()
                        from ct_xuat        in qCT_Xuat_TuNgay_DenNgay.Where(ct_xuat => ct_xuat.CT_Thuoc_PhieuNhap_ID == ct_nhap.ID).DefaultIfEmpty()
                        from _qCT_PhieuNhap in qCT_PhieuNhap.Where(_qCT_PhieuNhap => _qCT_PhieuNhap.ID == ct_nhap.ID).DefaultIfEmpty()
                        join thuoc          in db.Thuoc on ct_nhap.Thuoc_ID equals thuoc.ID
                        join dvt in db.DonViTinh on ct_nhap.DVT_Theo_DVT_Thuoc_ID equals dvt.ID
                        //from ct_xuatTrongKy in qCT_Xuat_TuNgay_DenNgay.Where(ct_xuatTrongKy => ct_xuatTrongKy.CT_Thuoc_PhieuNhap_ID == ct_xuat.CT_Thuoc_PhieuNhap_ID).DefaultIfEmpty()
                        //from ct_nhap in qCT_PhieuNhap.Where(ct_nhap => ct_nhap.ID == ct_xuat.CT_Thuoc_PhieuNhap_ID)
                        //from ct_nhapTai in qCT_PhieuNhapTaiTuNgay.Where(ct_nhapTai => ct_nhapTai.ID == ct_xuat.CT_Thuoc_PhieuNhap_ID).DefaultIfEmpty()
                       // from thuoc in qThuoc.Where(thuoc => thuoc.ID == ct_nhapTai.Thuoc_ID).DefaultIfEmpty()
                        //join ct_xuatTrongKy in qCT_Xuat_TuNgay_DenNgay on ct_xuat.CT_Thuoc_PhieuNhap_ID equals ct_xuatTrongKy.CT_Thuoc_PhieuNhap_ID
                        //join ct_nhap in qCT_PhieuNhapTaiTuNgay on ct_xuat.CT_Thuoc_PhieuNhap_ID equals ct_nhap.ID
                        //join thuoc in qThuoc on ct_nhap.Thuoc_ID equals thuoc.ID

                        //from ct_nhap in db.CT_Thuoc_PhieuNhap.Where(ct_nhap => ct_nhap.ID == ct_xuat.CT_Thuoc_PhieuNhap_ID).DefaultIfEmpty()
                        //from ct_xuat in db.CT_Thuoc_PhieuXuat.Where(ct_xuat => ct_xuat.CT_Thuoc_PhieuNhap_ID == ct_nhap.ID)//.DefaultIfEmpty()
                        //where (ct_nhap.NgayNhap >= tuNgay && ct_nhap.NgayNhap <= denNgay)
                        select new
                        {
                            Thuoc_ID = thuoc.ID,
                            MaThuoc = thuoc.MaThuoc,
                            TenThuoc = thuoc.TenThuoc,
                            TenDVT = dvt.TenDVT,
                            TonDauKy = (_nhap_truoc.SoLuong != null ? _nhap_truoc.SoLuong : 0) - (_xuat_truoc.SoLuong != null ? _xuat_truoc.SoLuong : 0),
                            NhapTrongKy = _qCT_PhieuNhap.SoLuongNhap,
                            XuatTrongky = ct_xuat.SoLuong,
                            GiaXuatTrongKy = ct_xuat.GiaBan,
                            TonCuoiKy = (_nhap_sau.SoLuong != null ? _nhap_sau.SoLuong : 0) - (_xuat_sau.SoLuong != null ? _xuat_sau.SoLuong : 0),
                           // NgayNhap = ct_nhap.NgayNhap
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
            //int ncc_kh_ID       = Convert.ToInt32(cbbNCC_KH.EditValue); 
            //String soPhieu      = txtSoPhieu.Text.Trim();
            //DateTime tuNgay     = Convert.ToDateTime(dateTuNgay.EditValue);
            //DateTime denNgay    = Convert.ToDateTime(dateDenNgay.EditValue);
            //String soHoaDon     = txtSoHoaDon.Text.Trim();

            //var query = rpo_PhieuNhap.search(ncc_kh_ID, soPhieu, tuNgay, denNgay, soHoaDon);
            //grdDS_BanHang.DataSource = new BindingList<PhieuNhapThuoc>(query.ToList());
            LoadBangKeCT_Xuat_Nhap_Ton_Thuoc();
        }
        #endregion

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            //sfdDSPhieuNhap.Filter = "Excel Worksheets|*.xls";
            sfdDSNhap_Xuat_Ton.Filter = "Excel files (*.xls or .xlsx)|.xls;*.xlsx";
            if (sfdDSNhap_Xuat_Ton.ShowDialog() == DialogResult.OK)
            {
                grdDS_Nhap_Xuat_Ton.ExportToXls(sfdDSNhap_Xuat_Ton.FileName);
            }
        }
    }
}