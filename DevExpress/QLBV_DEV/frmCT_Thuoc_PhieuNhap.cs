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
    public partial class frmCT_Thuoc_PhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        public frmCT_Thuoc_PhieuNhap()
        {
            InitializeComponent();
        }

        private void cbbTenThuoc_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void cbbTenThuoc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind.ToString()=="Plus")
            {
                MessageBox.Show("Hey");
            }
        }

        internal void loadData()
        {
            throw new NotImplementedException();
        }
    }
}