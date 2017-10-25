using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBV_DEV.Reports;
using QLBV_DEV.Repository;

namespace QLBV_DEV
{
    public partial class frmPrint : DevExpress.XtraEditors.XtraForm
    {
        public frmPrint()
        {
            InitializeComponent();
        }

        public void printDSThuoc(List<Thuoc> lstThuoc)
        {
            ThuocRepository rpo_thuoc = new ThuocRepository();

            rptPhieuXuatThuoc report = new rptPhieuXuatThuoc();

            report.DataSource = rpo_thuoc.GetAllS(10).ToList();

            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }
    }
}