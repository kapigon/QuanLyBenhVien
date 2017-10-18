﻿using System;
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
    public partial class frmThemNCC_KH : DevExpress.XtraEditors.XtraForm
    {
        HospitalEntities db = new HospitalEntities();
        NCC_KHRepository rpo_NCC_KH = new NCC_KHRepository();

        bool isUpdate = false;
        int ncc_kh_ID = 0;
        public frmThemNCC_KH()
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
            NCC_KH obj_NCC_KH = rpo_NCC_KH.GetSingle(ID);
            if (obj_NCC_KH.ID > 0)
            {
                txtMa.Text = obj_NCC_KH.MaNCC_KH;
                txtTen.Text = obj_NCC_KH.TenNCC_KH;
                txtDiaChi.Text = obj_NCC_KH.DiaChi;
                txtChiNhanh.Text = obj_NCC_KH.ChiNhanh;
                txtMST.Text = obj_NCC_KH.MST;
                txtSoTK.Text = obj_NCC_KH.SoTaiKhoan;
                txtNganHang.Text = obj_NCC_KH.NganHang;
                txtDienThoai.Text = obj_NCC_KH.DienThoai;
                txtFax.Text = obj_NCC_KH.Fax;
                txtEmail.Text = obj_NCC_KH.Email;
                txtWebsite.Text = obj_NCC_KH.Website;
                txtMota.Text = obj_NCC_KH.MoTa;
                chkKichHoat.EditValue = obj_NCC_KH.KichHoat;
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
            NCC_KH obj_NCC_KH;
            if(dxValidate.Validate())
            {
                try
                {
                    if (isUpdate && ncc_kh_ID > 0)
                    {
                        obj_NCC_KH = db.NCC_KH.Where(p => p.ID == ncc_kh_ID).SingleOrDefault();
                    }
                    else
                    {
                        obj_NCC_KH = new NCC_KH();
                    }

                    obj_NCC_KH.MaNCC_KH         = txtMa.Text.Trim();
                    obj_NCC_KH.TenNCC_KH        = txtTen.Text.Trim();
                    obj_NCC_KH.DiaChi           = txtDiaChi.Text.Trim();
                    obj_NCC_KH.MST              = txtMST.Text.Trim();
                    obj_NCC_KH.SoTaiKhoan       = txtSoTK.Text.Trim();
                    obj_NCC_KH.NganHang         = txtNganHang.Text.Trim();
                    obj_NCC_KH.ChiNhanh         = txtChiNhanh.Text.Trim();
                    obj_NCC_KH.DienThoai        = txtDienThoai.Text.Trim();
                    obj_NCC_KH.Fax              = txtFax.Text.Trim();
                    obj_NCC_KH.Email            = txtEmail.Text.Trim();
                    obj_NCC_KH.Website          = txtWebsite.Text.Trim();
                    obj_NCC_KH.MoTa             = txtMota.Text.Trim();
                    obj_NCC_KH.LoaiNCC_KH_ID    = Convert.ToInt32(cbbLoaiNCC_KH.EditValue);
                    obj_NCC_KH.KichHoat         = Convert.ToBoolean(chkKichHoat.EditValue);

                    if (isUpdate && ncc_kh_ID > 0) // Cập nhật
                    {
                        //respository.Save(objNCC);
                        db.SaveChanges();

                        this.Close();
                    }
                    else // Thêm mới
                    {
                        rpo_NCC_KH.Create(obj_NCC_KH);
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
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}