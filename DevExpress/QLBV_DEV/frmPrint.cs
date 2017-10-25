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

namespace QLBV_DEV
{
    public partial class frmPrint : DevExpress.XtraEditors.XtraForm
    {
        public frmPrint()
        {
            InitializeComponent();
            rptPhieuXuat report = new rptPhieuXuat();

            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }

        public void loadData(){
            rptPhieuXuat report = new rptPhieuXuat();

            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }

    }
}