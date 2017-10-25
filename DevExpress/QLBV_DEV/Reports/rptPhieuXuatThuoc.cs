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
            //for(int i = 0; i< 10)
           // xrTableCell5.Text = this.get
            //xrTableCell5.Text = GetCurrentColumnValue("TenThuoc").ToString();
        }

        private void TopMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrTableCell5.Text = this.GetCurrentColumnValue("TenThuoc").ToString();
            //xrTableCell5.Text = GetCurrentColumnValue("TenThuoc").ToString();
            //xrTableCell5.Text = ((DataRowView)GetCurrentRow()).Row["TenThuoc"].ToString();
            //double total = Convert.ToDouble(this.DataSource.GetCurrentColumnValue("CTPT"));
        }

    }
}
