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
            var qCT_Xuat_TuNgay_DenNgay = from ct_xuat in db.CT_Thuoc_PhieuXuat
                                          where ct_xuat.SoLuong > 0 && (ct_xuat.NgayBan >= tuNgay && ct_xuat.NgayBan <= denNgay)
                                          group ct_xuat by ct_xuat.CT_Thuoc_PhieuNhap_ID into gr_CT_Xuat
                                          select new
                                          {
                                              gr_CT_Xuat.FirstOrDefault().CT_Thuoc_PhieuNhap_ID,
                                              SoLuong = gr_CT_Xuat.Sum(p => p.SoLuong),
                                              GiaBan = gr_CT_Xuat.Sum(p => p.GiaBan),
                                          };

            var qCT_Xuat_DenNgay_HienTai = from ct_xuat in db.CT_Thuoc_PhieuXuat
                                           where ct_xuat.SoLuong > 0 && (ct_xuat.NgayBan > denNgay)
                                           group ct_xuat by ct_xuat.CT_Thuoc_PhieuNhap_ID into gr_CT_Xuat
                                           select new
                                           {
                                               CT_Thuoc_PhieuNhap_ID = gr_CT_Xuat.FirstOrDefault().CT_Thuoc_PhieuNhap_ID,
                                               SoLuongNgoai = gr_CT_Xuat.Sum(p => p.SoLuong),
                                               GiaBan = gr_CT_Xuat.Sum(p => p.GiaBan),
                                           };

            //var qCT_PhieuNhapNgoaiKhoangT = from ct_nhap in db.CT_Thuoc_PhieuNhap
            //                                where (ct_nhap.NgayNhap >= tuNgay && ct_nhap.NgayNhap <= DateTime.Now)
            //                                group ct_nhap by ct_nhap.Thuoc_ID into gr_CT_Nhap
            //                                select new
            //                                {
            //                                    Thuoc_ID = gr_CT_Nhap.FirstOrDefault().Thuoc_ID,
            //                                    ID = gr_CT_Nhap.FirstOrDefault().ID,
            //                                    SoLuongNhap = gr_CT_Nhap.Sum(p => p.SoLuong)
            //                                };

            //from ct_nhap in db.CT_Thuoc_PhieuNhap
            var query = from ct_xuat in qCT_Xuat_TuNgay_DenNgay
                        from ct_nhap in db.CT_Thuoc_PhieuNhap.Where(ct_nhap => ct_nhap.ID == ct_xuat.CT_Thuoc_PhieuNhap_ID).DefaultIfEmpty()
                        from ct_xuatNgoai in qCT_Xuat_DenNgay_HienTai.Where(ct_xuatNgoai => ct_xuatNgoai.CT_Thuoc_PhieuNhap_ID == ct_nhap.ID).DefaultIfEmpty()
                        //from ct_xuat in db.CT_Thuoc_PhieuXuat.Where(ct_xuat => ct_xuat.CT_Thuoc_PhieuNhap_ID == ct_nhap.ID)//.DefaultIfEmpty()
                        join thuoc in db.Thuoc on ct_nhap.Thuoc_ID equals thuoc.ID
                        //where (ct_nhap.NgayNhap >= tuNgay && ct_nhap.NgayNhap <= denNgay)
                        select new
                        {
                            Thuoc_ID = thuoc.ID,
                            MaThuoc = thuoc.MaThuoc,
                            TenThuoc = thuoc.TenThuoc,
                            TonDauKy = ct_nhap.TonKho + (ct_xuat.SoLuong != null ? ct_xuat.SoLuong : 0) + (ct_xuatNgoai.SoLuongNgoai != null ? ct_xuatNgoai.SoLuongNgoai : 0) - ct_nhap.SoLuong,
                            NhapTrongKy = ct_nhap.SoLuong,
                            XuatTrongky = ct_xuat.SoLuong,
                            GiaXuatTrongKy = ct_xuat.GiaBan,
                            TonCuoiKy = ct_nhap.TonKho + (ct_xuatNgoai.SoLuongNgoai != null ? ct_xuatNgoai.SoLuongNgoai : 0)
                        };

            grdDS_BanHang.DataSource = query.ToList();
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
    }
}