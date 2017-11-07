﻿using System;
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

using DevExpress.XtraGrid.Views.Grid;


namespace QLBV_DEV
{
    public partial class frmDonViTinh : DevExpress.XtraEditors.XtraForm
    {
        #region params
        int DVT_Id = 0;
        DVTRepository repository = new DVTRepository();
        HospitalEntities db = new HospitalEntities();
        bool isUpdate = false;
        #endregion

        public frmDonViTinh()
        {
            InitializeComponent();
            LoadDS_DonViTinh();
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            //frmThemNuocSanXuat frmThemNuocSanXuat = new frmThemNuocSanXuat();
            //frmThemNuocSanXuat.ShowInTaskbar = false;
            //frmThemNuocSanXuat.FormClosed += new FormClosedEventHandler(close_form);
            //frmThemNuocSanXuat.ShowDialog();
        }
        private void LoadDS_DonViTinh()
        {
            QLBV_DEV.HospitalEntities dbContext = new QLBV_DEV.HospitalEntities();
            // Call the Load method to get the data for the given DbSet from the database.
            dbContext.DonViTinh.Load();
            // This line of code is generated by Data Source Configuration Wizard
            gridcontrolDonViTinh.DataSource = dbContext.DonViTinh.Local.ToBindingList();
        }
        private void close_form(object sender, FormClosedEventArgs e)
        {
            LoadDS_DonViTinh();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (DVT_Id > 0)
            {
                String ten = grvDonViTinh.GetRowCellValue(grvDonViTinh.FocusedRowHandle, "TenDVT").ToString();
                DialogResult dialogResult = MessageBox.Show(ten, "Xác nhận xóa?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    repository.Delete(DVT_Id);


                    // Tải lại danh sách nước sản xuất
                    LoadDS_DonViTinh();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }                               
            }
        }

        private void frmDSNuocSanXuat_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            #region Code Save cũ
            //if (dxValidate.Validate())
            //{
            //    NuocSanXuat _object = new NuocSanXuat()
            //    {
            //        TenNuoc = txtTenNuoc.Text.Trim()
            //    };

            //    try
            //    {
            //        if (isUpdate && nuocsanxuat_Id > 0)
            //        {
            //            NuocSanXuat objNuocSanXuat = db.NuocSanXuat.Where(p => p.ID == nuocsanxuat_Id).SingleOrDefault();
            //            objNuocSanXuat.TenNuoc = txtTenNuoc.Text.Trim();

            //            db.SaveChanges();
            //            // Tải lại danh sách nước sản xuất

            //        }
            //        else
            //        {
            //            repository.Create(_object);

            //            txtTenNuoc.Text = "";
            //            MessageBox.Show("Lưu thành công");
            //        }
            //        LoadDS_NuocSanXuat();

            //    }
            //    catch (DbEntityValidationException dbEx)
            //    {
            //        foreach (var validationErrors in dbEx.EntityValidationErrors)
            //        {
            //            foreach (var validationError in validationErrors.ValidationErrors)
            //            {
            //                Trace.TraceInformation(
            //                      "Class: {0}, Property: {1}, Error: {2}",
            //                      validationErrors.Entry.Entity.GetType().FullName,
            //                      validationError.PropertyName,
            //                      validationError.ErrorMessage);
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Lỗi");
            //}
            #endregion

            DonViTinh obj_DonViTinh;
            try
            {
                if (isUpdate && DVT_Id > 0)
                {
                    obj_DonViTinh = db.DonViTinh.Where(p => p.ID == DVT_Id).SingleOrDefault();
                }
                else
                {
                    obj_DonViTinh = new DonViTinh();
                }
                obj_DonViTinh.TenDVT = txtTenDVT.Text.Trim();

                if (isUpdate && DVT_Id > 0) // Cập nhật
                {
                    //respository.Save(objNuocSanXuat);
                    db.SaveChanges();

                }
                else // Thêm mới
                {
                    repository.Create(obj_DonViTinh);
                    //db.NCC_KH.Add(_object);
                    //db.SaveChanges(); 
                    txtTenDVT.Text = "";
                }
                LoadDS_DonViTinh();
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
            //catch (DbEntityValidationException dbEx)
            //{
            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //    {
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //        {
            //            Trace.TraceInformation(
            //                  "Class: {0}, Property: {1}, Error: {2}",
            //                  validationErrors.Entry.Entity.GetType().FullName,
            //                  validationError.PropertyName,
            //                  validationError.ErrorMessage);
            //        }
            //    }
            //}
            
        }

        private void gridcontrolHoatChat_Click(object sender, EventArgs e)
        {
            // dừng xử lý nếu không kích vào dòng có dữ liệu
            if (grvDonViTinh.GetRowCellValue(grvDonViTinh.FocusedRowHandle, "ID") == null)
                return;

            string id = grvDonViTinh.GetRowCellValue(grvDonViTinh.FocusedRowHandle, "ID").ToString();
            DVT_Id = Convert.ToInt32(id);
            isUpdate = true;
            //MessageBox.Show(id); 
            txtTenDVT.Text = grvDonViTinh.GetRowCellValue(grvDonViTinh.FocusedRowHandle, "TenDVT").ToString();
        }

        // Thêm số thứ tự tự động tăng GridControl
        //bool indicatorIcon = true;
        private void grvNuocSanXuat_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
             GridView view = (GridView)sender;
            if (e.Info.IsRowIndicator && e.RowHandle >=0)
            {
                e.Info.DisplayText = (e.RowHandle+1).ToString();
                //if (!indicatorIcon)
                   // e.Info.ImageIndex = -1;
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (DVT_Id > 0)
            {
                layoutControlGroup2.Expanded = true;
                txtTenDVT.Focus();

            }
            else
            {
                MessageBox.Show("Hãy lựa chọn dòng cần sửa.");
            }
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            layoutControlGroup2.Expanded = true;
            txtTenDVT.Focus();
            txtTenDVT.Text = "";
            isUpdate = false;
        }
    }
}