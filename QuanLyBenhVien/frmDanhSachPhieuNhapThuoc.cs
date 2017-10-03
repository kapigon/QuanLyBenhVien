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
    public partial class frmDanhSachPhieuNhapThuoc : Form
    {
        HospitalEntities db = new HospitalEntities();

        public frmDanhSachPhieuNhapThuoc()
        {
            InitializeComponent();
            Load_DS_PhieuNhapThuoc();
        }

        private void Load_DS_PhieuNhapThuoc()
        {
            DataTable dt = new DataTable();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
