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
    public partial class Login : Form
    {
        HospitalEntities db = new HospitalEntities();

        public Login()
        {
            InitializeComponent();
        }
        
        #region METHODS
        private bool checkLogin()
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;
            //NhanVien nv = new NhanVien();
            //nv =  db.NhanViens.Where("TaiKhoan = " + user + " and MatKhau=" + user).SingleOrDefault();
            var result = from nv in db.NhanViens
                         where nv.TaiKhoan == user && nv.MatKhau == pass
                         select nv;
            if(result.Count() == 1)
                return true;
            return false;
        }
        #endregion

        #region EVENTS
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (checkLogin())
            {
                MessageBox.Show("Đăng nhập thành công!");
                ToolManage frmToolMangage = new ToolManage();

                // Đóng form ToolManage sẽ ở lại form đăng nhập
                frmToolMangage.FormClosed += new FormClosedEventHandler(frmToolMangageClosed);
                frmToolMangage.Show();
                this.Hide();
               
            }
            else
            {
                MessageBox.Show("Tài Khoản hoặc Mật Khẩu không hợp lệ!");
            }
        }

        private void frmToolMangageClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
