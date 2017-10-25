using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using QLBV_DEV.Repository;
using System.Collections.Generic;

namespace QLBV_DEV.Reports
{
    public partial class rptPhieuXuat : DevExpress.XtraReports.UI.XtraReport
    {
        ThuocRepository rpo_Thuoc = new ThuocRepository();
        Thuoc obj_Thuoc = new Thuoc();
        List<Thuoc> lstThuoc = new List<Thuoc>();
        public rptPhieuXuat()
        {
            InitializeComponent();
            LoadDSThuoc();
        }

        private void LoadDSThuoc()
        {
            pTenNhaThuoc.Value = "Bệnh viện Than khoáng sản Việt Nam";
            pKhachHang.Value = "Bùi Thanh Long";
            pSDT.Value = "0902040608";
            pTuoi.Value = 36;
            pNhanVien.Value = "Admin";
            pGioiTinh.Value = "Nam";
            pNgayTao.Value = DateTime.Now;

            /*lstThuoc = rpo_Thuoc.GetAll() as List<Thuoc>;
            for (int i = 0; i < lstThuoc.Count; i++)
            {
                xrTableCell5[i] = lstThuoc[i].TenThuoc;
            }*/

        }

    }
}
