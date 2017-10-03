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
    public partial class frmTonKhoThuoc : Form
    {
        public frmTonKhoThuoc()
        {
            InitializeComponent();
        }

        private void txtPhanTram_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Nếu là số thì cho nhập
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);

            // Khi ấn enter bắt đầu tìm kiếm
            if (e.KeyChar == (char)13)
            {

            }
        }

        private void txtSoNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Nếu là số thì cho nhập
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);

            // Khi ấn enter bắt đầu tìm kiếm
            if (e.KeyChar == (char)13)
            {

            }
        }
    }
}
