using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBenhVien
{
    public partial class frmNCC : Form
    {
        HospitalEntities db = new HospitalEntities();
        bool isUpdate = false;
        int nccID = 0;
        public frmNCC()
        {
            InitializeComponent();
            //LoadTinhTP();
        }

        #region method
        // Load Danh sách Tỉnh Thành Phố
        /*private void LoadTinhTP()
        {
            var result = from tinhTP in db.TinhTPs
                         select tinhTP;
            cboTinhTP.DataSource = result.ToList();
            cboTinhTP.DisplayMember = "TenTinhTP";
            cboTinhTP.ValueMember = "ID";
        }*/
        #endregion

        #region event
        /*private void btnThemTinhTP_Click(object sender, EventArgs e)
        {
            frmTinhTP tinhTP = new frmTinhTP();
            // CallBack khi đóng form TinhTP
            tinhTP.FormClosed += new FormClosedEventHandler(frmTinhTPClosed);
            tinhTP.ShowDialog();
        }

        private void frmTinhTPClosed(object sender, FormClosedEventArgs e)
        {
            LoadTinhTP();
        }*/

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void btnLuu_Click(object sender, EventArgs e)
        {
            NCC_KH ncc = new NCC_KH() {
                    MaNCC_KH        = txtMaNCC.Text.Trim(),
                    TenNCC_KH       = txtTenNCC.Text.Trim(),
                    DiaChi          = txtDiaChi.Text.Trim(),
                    MST             = txtMST.Text.Trim(),
                    SoTaiKhoan      = txtSoTaiKhoan.Text.Trim(),
                    NganHang        = txtMoTaiNN.Text.Trim(),
                    DienThoai       = txtSDT.Text.Trim(),
                    Fax             = txtFax.Text.Trim(),
                    Email           = txtEmail.Text.Trim(),
                    Website         = txtWebsite.Text.Trim(),
                    MoTa            = txtMoTa.Text.Trim(),
                    LoaiNCC_KH      = 1
            };

            try
            {
                if (isUpdate && nccID > 0)
                {
                    NCC_KH objNCC       = db.NCC_KH.Where(p => p.ID == nccID).SingleOrDefault();
                    objNCC.MaNCC_KH     = txtMaNCC.Text.Trim();
                    objNCC.TenNCC_KH    = txtTenNCC.Text.Trim();
                    objNCC.DiaChi       = txtDiaChi.Text.Trim();
                    objNCC.MST          = txtMST.Text.Trim();
                    objNCC.SoTaiKhoan   = txtSoTaiKhoan.Text.Trim();
                    objNCC.NganHang     = txtMoTaiNN.Text.Trim();
                    objNCC.ChiNhanh     = txtChiNhanh.Text.Trim();
                    objNCC.DienThoai    = txtSDT.Text.Trim();
                    objNCC.Fax          = txtFax.Text.Trim();
                    objNCC.Email        = txtEmail.Text.Trim();
                    objNCC.Website      = txtWebsite.Text.Trim();
                    objNCC.MoTa         = txtMoTa.Text.Trim();
                    objNCC.LoaiNCC_KH   = 1;

                    db.SaveChanges();

                    this.Close();
                }
                else
                {
                    db.NCC_KH.Add(ncc);
                    db.SaveChanges();

                    this.Close();
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation(
                              "Class: {0}, Property: {1}, Error: {2}",
                              validationErrors.Entry.Entity.GetType().FullName,
                              validationError.PropertyName,
                              validationError.ErrorMessage);
                    }
                }
            }
        }

        public void loadData(int ID)
        {
            var result = from ncc in db.NCC_KH
                         where ncc.ID == ID
                         select ncc;

            if (result.Count() > 0)
            {
                NCC_KH ncc = result.SingleOrDefault();
                txtMaNCC.Text           = ncc.MaNCC_KH;
                txtTenNCC.Text          = ncc.TenNCC_KH;
                txtDiaChi.Text          = ncc.DiaChi;
                txtChiNhanh.Text        = ncc.ChiNhanh;
                txtMST.Text             = ncc.MST;
                txtSoTaiKhoan.Text      = ncc.SoTaiKhoan;
                txtMoTaiNN.Text         = ncc.NganHang;
                txtSDT.Text             = ncc.DienThoai;
                txtFax.Text             = ncc.Fax;
                txtEmail.Text           = ncc.Email;
                txtWebsite.Text         = ncc.Website;
                txtMoTa.Text            = ncc.MoTa;
            }
            btnLuu.Text = "&Cập nhật";
            isUpdate = true;
            nccID = ID;
        }
    }
}
