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
    public partial class frmPhieuNhapThuoc : Form
    {
        HospitalEntities db = new HospitalEntities();
        public frmPhieuNhapThuoc()
        {
            InitializeComponent();
            LoadNhaCungCap();
        }

        #region method
        private void LoadNhaCungCap()
        {
            var result = from nv in db.NCC_KH
                         where nv.KichHoat == true
                         select nv;
            cboNhaCungCap.DataSource = result.ToList();
            cboNhaCungCap.DisplayMember = "TenNCC";
            cboNhaCungCap.ValueMember = "ID";
           // ddlNhaCungCap.DataBind();
        }
       
        #endregion

        #region event
        private void btnThemNhaCC_Click(object sender, EventArgs e)
        {
            
            frmNCC nhaCC = new frmNCC();
            nhaCC.FormClosed += new FormClosedEventHandler(frmNhaCCClosed);
            nhaCC.ShowDialog();
        }
               
        private void frmNhaCCClosed(object sender, FormClosedEventArgs e)
        {
            LoadNhaCungCap();
        }
       

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int nccID = Convert.ToInt32(cboNhaCungCap.SelectedValue);
            string ghiChu = txtGhiChu.Text;
            string soPhieu = txtSoPhieu.Text;
            DateTime ngayNhap = dtpNgayNhap.Value;
            int thueSuat = Convert.ToInt32(txtThueSuat.Text);
            string seri = txtSoSeri.Text;
            string soHD = txtSoHD.Text;
            DateTime ngayHD = dtpNgayHD.Value;


            using (var dbContextTransaction = db.Database.BeginTransaction()) 
            { 
                try 
                { 
                    /*context.Database.ExecuteSqlCommand( 
                        @"UPDATE Blogs SET Rating = 5" + 
                            " WHERE Name LIKE '%Entity Framework%'" 
                        ); */
 
                    /*var query = db.PhieuNhapThuocs.Where(p => p.Blog.Rating >= 5); 
                    foreach (var post in query) 
                    { 
                        post.Title += "[Cool Blog]"; 
                    } */
 
                    db.SaveChanges(); 
 
                    dbContextTransaction.Commit(); 
                } 
                catch (Exception) 
                { 
                    dbContextTransaction.Rollback(); 
                } 
            } 
        } 
    }
    #endregion
    
}
