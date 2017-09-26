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
    public partial class PhieuNhapThuoc : Form
    {
        HospitalEntities db = new HospitalEntities();
        public PhieuNhapThuoc()
        {
            InitializeComponent();
            LoadNhaCungCap();
        }

        #region method
        private void LoadNhaCungCap()
        {
            var result = from nv in db.NhaCungCaps
                         where nv.KichHoat == true
                         select nv;
            cboNhaCungCap.DataSource = result.ToList();
            cboNhaCungCap.DisplayMember = "Name";
            cboNhaCungCap.ValueMember = "ID";
           // ddlNhaCungCap.DataBind();
        }
       
        #endregion

        #region event
        private void btnThemNhaCC_Click(object sender, EventArgs e)
        {
            
            frmNhaCungCap nhaCC = new frmNhaCungCap();
            nhaCC.FormClosed += new FormClosedEventHandler(frmNhaCCClosed);
            nhaCC.ShowDialog();
        }
               
        private void frmNhaCCClosed(object sender, FormClosedEventArgs e)
        {
            LoadNhaCungCap();
        }
        #endregion
    }
}
