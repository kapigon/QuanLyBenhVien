using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace QLBV_DEV.Reports
{
    public partial class rptPhieuXuatThuoc : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPhieuXuatThuoc()
        {
            InitializeComponent();
            pTenNhaThuoc.Value  = "BỆNH VIỆN THAN KHOÁNG SẢN";
            pNgayBan.Value      = DateTime.Now;
            pKhachHang.Value    = "Nguyễn Tấn Dũng";
            pSDT.Value          = "";
            pNhanVien.Value     = "Admin";
            pTuoi.Value         = 36;
            pGioiTinh.Value     = "Nam";
        }

    }
}
