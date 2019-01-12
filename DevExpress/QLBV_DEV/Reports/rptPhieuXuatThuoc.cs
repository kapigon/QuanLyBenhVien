using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Linq;

namespace QLBV_DEV.Reports
{
    public partial class rptPhieuXuatThuoc : DevExpress.XtraReports.UI.XtraReport
    {
        HospitalEntities db = new HospitalEntities();
        public rptPhieuXuatThuoc()
        {
            InitializeComponent();
           
        }

        public rptPhieuXuatThuoc(NCC_KH khachhang, NhanVien nhanvien)
        {
            InitializeComponent();

            ThongTinChung obj_TTC = new ThongTinChung();
            obj_TTC = (from ttc in db.ThongTinChung 
                       where ttc.ID == 1
                       select ttc).FirstOrDefault();
            pTenNhaThuoc.Value = obj_TTC.Ten.ToUpper();
            pNgayBan.Value = DateTime.Now;
            pKhachHang.Value = khachhang.TenNCC_KH;
            pSDT.Value = khachhang.DienThoai;
            pNhanVien.Value = nhanvien.TaiKhoan;
            pTuoi.Value = null;
            pGioiTinh.Value = "";
        }

    }
}
