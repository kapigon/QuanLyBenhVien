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
            //var result = from nv in db.PhieuNhapThuoc
            //             where nv.Xoa == false
            //             select nv;
            //var result = rpo_PhieuNhap.GetAllNotDelete();
            var result = from ct_phieuxuat in db.CT_Thuoc_PhieuXuat
                         join phieuxuat in db.PhieuXuatThuoc on ct_phieuxuat.PhieuXuatHang_ID equals phieuxuat.ID
                         join ct_phieunhap in db.CT_Thuoc_PhieuNhap on ct_phieuxuat.CT_Thuoc_PhieuNhap_ID equals ct_phieunhap.ID
                         join thuoc in db.Thuoc on ct_phieunhap.Thuoc_ID equals thuoc.ID
                         join dvt in db.DonViTinh on ct_phieuxuat.DVT_Theo_DVT_Thuoc_ID equals dvt.ID

                        //join ncc_kh in db.NCC_KH on phieunhap.NCC_KH_ID equals ncc_kh.ID
                         //from ncc_kh in db.NCC_KH.Where(ncc => ncc.ID == phieunhap.NCC_KH_ID).DefaultIfEmpty()
                         where phieuxuat.NgayTao >= dateTuNgay && phieuxuat.NgayTao <= dateDenNgay
                        //orderby phieunhap.ID ascending
                        select new
                        {
                            ID          = thuoc.ID,
                            MaThuoc     = thuoc.MaThuoc,
                            TenThuoc    = thuoc.TenThuoc,
                            SoLuong     = ct_phieuxuat.SoLuong,
                            GiaBan      = ct_phieuxuat.GiaBan,
                            DVT         = dvt.TenDVT,
                            NgayBan     = phieuxuat.NgayTao,
                            TongTien    = ct_phieuxuat.TongTien
                            //SoPhieu     = phieux.SoPhieu,
                            //SoHoaDon    = phieunhap.SoHoaDon,
                            //NgayNhap    = phieunhap.NgayNhap,
                            //NCC_KH_ID   = ncc_kh.TenNCC_KH,
                            //ThueSuat    = phieunhap.ThueSuat + "%",
                            //ChietKhau   = phieunhap.ChietKhau,
                            //TongTienTra = phieunhap.TongTienTra
                        };
            grdDS_BanHang.DataSource = result.ToList();
        }

        private void LoadNCC()
        {
            NCC_KHRepository rpo_NCC_KH = new NCC_KHRepository();
            // lấy ra NCC và vừa là NCC vừa là KH
            cbbNCC_KH.Properties.DataSource = new BindingList<NCC_KH>(rpo_NCC_KH.GetAllByType(1, 2).ToList());
            //cbbNCC.DataSource = result.ToList();
            cbbNCC_KH.Properties.DisplayMember = "TenNCC_KH";
            cbbNCC_KH.Properties.ValueMember = "ID";

            cbbCol_NCC_KH.DataSource = new BindingList<NCC_KH>(rpo_NCC_KH.GetAllByType(1, 2).ToList());
            cbbCol_NCC_KH.DisplayMember = "TenNCC_KH";
            cbbCol_NCC_KH.ValueMember = "ID";
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
        }
        #endregion
    }
}