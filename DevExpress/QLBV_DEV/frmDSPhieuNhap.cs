using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QLBV_DEV
{
    public partial class frmDSPhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        public frmDSPhieuNhap()
        {
            InitializeComponent();
        }

        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            frmPhieuNhapThuoc f_PhieuNhapThuoc = new frmPhieuNhapThuoc();
            f_PhieuNhapThuoc.Show();
        }
    }
}