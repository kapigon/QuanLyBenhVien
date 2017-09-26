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
    public partial class frmNhaCungCap : Form
    {
        HospitalEntities db = new HospitalEntities();
        public frmNhaCungCap()
        {
            InitializeComponent();
            LoadTinhTP();
        }

        #region method
        // Load Danh sách Tỉnh Thành Phố
        private void LoadTinhTP()
        {
            var result = from tinhTP in db.TinhTPs
                         select tinhTP;
            cboTinhTP.DataSource = result.ToList();
            cboTinhTP.DisplayMember = "TenTinhTP";
            cboTinhTP.ValueMember = "ID";
        }
        #endregion

        #region event
        private void btnThemTinhTP_Click(object sender, EventArgs e)
        {
            frmTinhTP tinhTP = new frmTinhTP();
            // CallBack khi đóng form TinhTP
            tinhTP.FormClosed += new FormClosedEventHandler(frmTinhTPClosed);
            tinhTP.ShowDialog();
        }

        private void frmTinhTPClosed(object sender, FormClosedEventArgs e)
        {
            LoadTinhTP();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }
    }
}
