using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBV_DEV.Repository;

namespace QLBV_DEV
{
    public partial class frmThemNhaCungCap : DevExpress.XtraEditors.XtraForm
    {
        HospitalEntities db = new HospitalEntities();
        NCC_KHRepository respository = new NCC_KHRepository();
        bool isUpdate = false;
        int ncc_kh_ID = 0;
        public frmThemNhaCungCap()
        {
            InitializeComponent();
        }

        #region methods
        private void LoadLoaiNCC_KH()
        {
            var result = from ncc in db.LoaiNCC_KH
                         select new
                         {
                             ID = ncc.ID,
                             LoaiNCC_KH = ncc.TenLoaiNCC_KH
                         };
            cbbLoaiNCC_KH.Properties.DataSource = result.ToList();
            cbbLoaiNCC_KH.Properties.DisplayMember = "LoaiNCC_KH";
            cbbLoaiNCC_KH.Properties.ValueMember = "ID";
            cbbLoaiNCC_KH.EditValue = 1;
        }

        public void loadData(int ID)
        {
            var result = from ncc_kh in db.NCC_KH
                         where ncc_kh.ID == ID
                         select ncc_kh;

            if (result.Count() > 0)
            {
                NCC_KH _object = result.SingleOrDefault();
                txtMa.Text = _object.MaNCC_KH;
                txtTen.Text = _object.TenNCC_KH;
                txtDiaChi.Text = _object.DiaChi;
                txtChiNhanh.Text = _object.ChiNhanh;
                txtMST.Text = _object.MST;
                txtSoTK.Text = _object.SoTaiKhoan;
                txtNganHang.Text = _object.NganHang;
                txtDienThoai.Text = _object.DienThoai;
                txtFax.Text = _object.Fax;
                txtEmail.Text = _object.Email;
                txtWebsite.Text = _object.Website;
                txtMota.Text = _object.MoTa;
            }
            btnLuu.Text = "&Cập nhật";
            isUpdate = true;
            ncc_kh_ID = ID;
        }
        #endregion

        #region events
        private void frmThemNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadLoaiNCC_KH();
        }

        
        #endregion

        private void btnLuu_Click(object sender, EventArgs e)
        {
            NCC_KH _object = new NCC_KH()
            {
                MaNCC_KH = txtMa.Text.Trim(),
                TenNCC_KH = txtTen.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                MST = txtMST.Text.Trim(),
                SoTaiKhoan = txtSoTK.Text.Trim(),
                NganHang = txtNganHang.Text.Trim(),
                DienThoai = txtDienThoai.Text.Trim(),
                Fax = txtFax.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Website = txtWebsite.Text.Trim(),
                MoTa = txtMota.Text.Trim(),
                LoaiNCC_KH_ID = Convert.ToInt32(cbbLoaiNCC_KH.EditValue)
            };

            try
            {
                if (isUpdate && ncc_kh_ID > 0)
                {
                    NCC_KH objNCC = db.NCC_KH.Where(p => p.ID == ncc_kh_ID).SingleOrDefault();
                    objNCC.MaNCC_KH = txtMa.Text.Trim();
                    objNCC.TenNCC_KH = txtTen.Text.Trim();
                    objNCC.DiaChi = txtDiaChi.Text.Trim();
                    objNCC.MST = txtMST.Text.Trim();
                    objNCC.SoTaiKhoan = txtSoTK.Text.Trim();
                    objNCC.NganHang = txtNganHang.Text.Trim();
                    objNCC.ChiNhanh = txtChiNhanh.Text.Trim();
                    objNCC.DienThoai = txtDienThoai.Text.Trim();
                    objNCC.Fax = txtFax.Text.Trim();
                    objNCC.Email = txtEmail.Text.Trim();
                    objNCC.Website = txtWebsite.Text.Trim();
                    objNCC.MoTa = txtMota.Text.Trim();
                    objNCC.LoaiNCC_KH_ID = Convert.ToInt32(cbbLoaiNCC_KH.EditValue);

                    //respository.Save(objNCC);
                    db.SaveChanges();

                    this.Close();
                }
                else
                {
                    respository.Create(_object);
                    //db.NCC_KH.Add(_object);
                    //db.SaveChanges();

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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}