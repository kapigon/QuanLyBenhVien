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
            LoadBangKeCT_Xuat_Nhap_Ton_Thuoc();
        }

        #region methods
        private void LoadBangKeCT_Xuat_Nhap_Ton_Thuoc()
        {
            DateTime tuNgay = Convert.ToDateTime(dateTuNgay.EditValue);
            DateTime denNgay = Convert.ToDateTime(dateDenNgay.EditValue);
            // Group nhom theo CT_Thuoc_PhieuNhap_ID
            var qCT_PhieuXuat = from ct_xuat in db.CT_Thuoc_PhieuXuat
                                where ct_xuat.SoLuong > 0 && (ct_xuat.NgayBan >= tuNgay && ct_xuat.NgayBan <= denNgay)
                                group ct_xuat by ct_xuat.CT_Thuoc_PhieuNhap_ID into gr_CT_Xuat
                                select new
                                {
                                    gr_CT_Xuat.FirstOrDefault().CT_Thuoc_PhieuNhap_ID,
                                    SoLuong = gr_CT_Xuat.Sum(p => p.SoLuong),
                                    GiaBan = gr_CT_Xuat.Sum(p => p.GiaBan),
                                };

            var query = from ct_nhap    in db.CT_Thuoc_PhieuNhap
                        from ct_xuat    in qCT_PhieuXuat.Where(ct_xuat => ct_xuat.CT_Thuoc_PhieuNhap_ID == ct_nhap.ID).DefaultIfEmpty()
                        //from ct_xuat in db.CT_Thuoc_PhieuXuat.Where(ct_xuat => ct_xuat.CT_Thuoc_PhieuNhap_ID == ct_nhap.ID)//.DefaultIfEmpty()
                        join thuoc      in db.Thuoc                 on ct_nhap.Thuoc_ID equals thuoc.ID
                        where (ct_nhap.NgayNhap >= tuNgay && ct_nhap.NgayNhap <= denNgay)
                        select new
                        {
                            Thuoc_ID        = thuoc.ID,
                            MaThuoc         = thuoc.MaThuoc,
                            TenThuoc        = thuoc.TenThuoc,
                            TonDauKy        = ct_nhap.TonKho + ct_xuat.SoLuong - ct_nhap.SoLuong,
                            NhapTrongKy     = ct_nhap.SoLuong,
                            XuatTrongky     = ct_xuat.SoLuong,
                            GiaXuatTrongKy  = ct_xuat.GiaBan,
                            TonCuoiKy       = ct_nhap.TonKho - ct_xuat.SoLuong + ct_nhap.SoLuong
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