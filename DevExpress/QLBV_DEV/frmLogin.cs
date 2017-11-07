using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Entity;
using QLBV_DEV.Repository;
using System.Data.Entity.Validation;
using System.Diagnostics;



namespace QLBV_DEV
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        #region params
        NhanVienRepository rpo_NhanVien = new NhanVienRepository();
        NhanVien obj_NhanVien = new NhanVien();
        #endregion

        public frmLogin()
        {
            InitializeComponent();
        }
        
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string user = txtTenDangNhap.Text.Trim();
                string pass = txtMatKhau.Text.Trim();

                obj_NhanVien = rpo_NhanVien.GetSingle(user, pass);
                if (obj_NhanVien != null)
                {
                    this.Hide();

                    QLBV_DEV.Helpers.LoginInfo.nhanVien = obj_NhanVien;
                    frmMain frmMain = new frmMain();
                    frmMain.Show();
                }
                else
                    MessageBox.Show("Tên đăng nhập và mật khẩu không đúng");
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}