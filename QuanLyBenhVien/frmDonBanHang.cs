﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBenhVien
{
    public partial class frmDonBanHang : Form
    {
        public frmDonBanHang()
        {
            InitializeComponent();
        }
        #region methods
        private void fomatNumberCurrent(String textBoxName, KeyPressEventArgs e)
        {
            // Nếu là số thì cho nhập
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);

            // Format dạng tiền
            if (e.KeyChar == (char)13)
            {
                TextBox tv = this.Controls.Find(textBoxName, false).First() as TextBox;
                tv.Text = string.Format("{0:n0}", double.Parse(tv.Text));
            }
        }

        private void resetField()
        {
            txtKhachHang
        }
        #endregion

        #region events
        private void frmDonBanHang_Load(object sender, EventArgs e)
        {
            var checkedButton = grbGioiTinh.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            //MessageBox.Show(checkedButton.Text);
        }

        private void txtTongCong_KeyPress(object sender, KeyPressEventArgs e)
        {
            fomatNumberCurrent("txtTongCong", e);
        }
                
        private void txtTienThuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            fomatNumberCurrent("txtTienThuoc", e);
        }

        private void txtKHTra_KeyPress(object sender, KeyPressEventArgs e)
        {
            fomatNumberCurrent("txtKHTra", e);
        }

        private void txtPhuPhi_KeyPress(object sender, KeyPressEventArgs e)
        {
            fomatNumberCurrent("txtPhuPhi", e);
        }

        private void txtSoTienTraLai_KeyPress(object sender, KeyPressEventArgs e)
        {
            fomatNumberCurrent("txtSoTienTraLai", e);
        }

        private void txtTienThuocVaPhuPhi_KeyPress(object sender, KeyPressEventArgs e)
        {
            fomatNumberCurrent("txtTienThuocVaPhuPhi", e);
        }
        private void txtTuoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Nếu là số thì cho nhập
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Nếu là số thì cho nhập
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn lưu trước khi thêm mới không ?", "Bạn có muốn lưu trước khi thêm mới không ?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        #endregion

        
       
    }
}
