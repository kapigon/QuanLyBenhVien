using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBenhVien
{
    public partial class frmMsgOK : Form
    {
        public frmMsgOK()
        {
            InitializeComponent();
        }

        #region method
        public void HienThi(string loinhan, string tieude)
        {
            lblloiNhac.Text = loinhan;
            this.Text = tieude + "12345";
        }
        #endregion
    }
}
