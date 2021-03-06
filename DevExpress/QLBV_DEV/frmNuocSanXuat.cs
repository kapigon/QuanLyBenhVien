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
    public partial class frmNuocSanXuat : DevExpress.XtraEditors.XtraForm
    {
        #region params
        int nuocsanxuat_Id = 0;
        NuocSanXuatRepository repository = new NuocSanXuatRepository();
        HospitalEntities db = new HospitalEntities();
        bool isUpdate = false;
        #endregion

        public frmNuocSanXuat()
        {
            InitializeComponent();

            // This line of code is generated by Data Source Configuration Wizard
            // Instantiate a new DBContext
            QLBV_DEV.HospitalEntities dbContext = new QLBV_DEV.HospitalEntities();
            // Call the Load method to get the data for the given DbSet from the database.
            dbContext.NuocSanXuat.Load();
            // This line of code is generated by Data Source Configuration Wizard
            gridcontrolNuocSanXuat.DataSource = dbContext.NuocSanXuat.Local.ToBindingList();
        }




        private void btnThem_Click(object sender, EventArgs e)
        {
            //frmThemNuocSanXuat frmThemNuocSanXuat = new frmThemNuocSanXuat();
            //frmThemNuocSanXuat.ShowInTaskbar = false;
            //frmThemNuocSanXuat.FormClosed += new FormClosedEventHandler(close_form);
            //frmThemNuocSanXuat.ShowDialog();
        }
        private void LoadDS_NuocSanXuat()
        {
            QLBV_DEV.HospitalEntities dbContext = new QLBV_DEV.HospitalEntities();
            // Call the Load method to get the data for the given DbSet from the database.
            dbContext.NuocSanXuat.Load();
            // This line of code is generated by Data Source Configuration Wizard
            gridcontrolNuocSanXuat.DataSource = dbContext.NuocSanXuat.Local.ToBindingList();
        }
        private void close_form(object sender, FormClosedEventArgs e)
        {
            LoadDS_NuocSanXuat();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (nuocsanxuat_Id > 0 )
            {
                String ten = grvNuocSanXuat.GetRowCellValue(grvNuocSanXuat.FocusedRowHandle, "TenNuoc").ToString();
                DialogResult dialogResult = MessageBox.Show(ten, "Xác nhận xóa?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    repository.Delete(nuocsanxuat_Id);


                    // Tải lại danh sách nước sản xuất
                    LoadDS_NuocSanXuat();
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

            NuocSanXuat obj_NuocSanXuat;
            try
            {
                if (isUpdate && nuocsanxuat_Id >0)
                {
                    obj_NuocSanXuat = db.NuocSanXuat.Where(p => p.ID == nuocsanxuat_Id).SingleOrDefault();
                }
                else
                {
                    obj_NuocSanXuat = new NuocSanXuat();
                }
                obj_NuocSanXuat.TenNuoc = txtTenNuoc.Text.Trim();

                if (isUpdate && nuocsanxuat_Id > 0) // Cập nhật
                {
                    //respository.Save(objNuocSanXuat);
                    db.SaveChanges();

                }
                else // Thêm mới
                {
                    repository.Create(obj_NuocSanXuat);
                    //db.NCC_KH.Add(_object);
                    //db.SaveChanges(); 
                    txtTenNuoc.Text = "";
                }
                LoadDS_NuocSanXuat();
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

        private void gridcontrolNuocSanXuat_Click(object sender, EventArgs e)
        {
            // dừng xử lý nếu không kích vào dòng có dữ liệu
            if (grvNuocSanXuat.GetRowCellValue(grvNuocSanXuat.FocusedRowHandle, "ID") == null)
                return;

            string id = grvNuocSanXuat.GetRowCellValue(grvNuocSanXuat.FocusedRowHandle, "ID").ToString();
            nuocsanxuat_Id = Convert.ToInt32(id);
            isUpdate = true;
            //MessageBox.Show(id); 
            txtTenNuoc.Text = grvNuocSanXuat.GetRowCellValue(grvNuocSanXuat.FocusedRowHandle, "TenNuoc").ToString();
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
            if (nuocsanxuat_Id > 0)
            {
                layoutControlGroup2.Expanded = true;
                txtTenNuoc.Focus();

            }
            else
            {
                MessageBox.Show("Hãy lựa chọn dòng cần sửa.");
            }
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            layoutControlGroup2.Expanded = true;
            txtTenNuoc.Focus();
            txtTenNuoc.Text = "";
            isUpdate = false;
        }
    }
}