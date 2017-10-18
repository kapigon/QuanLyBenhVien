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
    public partial class frmKho : DevExpress.XtraEditors.XtraForm
    {
        #region params
        int Kho_Id = 0;
        KhoRepository repository = new KhoRepository();
        HospitalEntities db = new HospitalEntities();
        bool isUpdate = false;
        #endregion

        public frmKho()
        {
            InitializeComponent();
            LoadDS_Kho();
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            //frmThemNuocSanXuat frmThemNuocSanXuat = new frmThemNuocSanXuat();
            //frmThemNuocSanXuat.ShowInTaskbar = false;
            //frmThemNuocSanXuat.FormClosed += new FormClosedEventHandler(close_form);
            //frmThemNuocSanXuat.ShowDialog();
        }
        private void LoadDS_Kho()
        {
            QLBV_DEV.HospitalEntities dbContext = new QLBV_DEV.HospitalEntities();
            // Call the Load method to get the data for the given DbSet from the database.
            dbContext.Kho.Load();
            // This line of code is generated by Data Source Configuration Wizard
            gridcontrolKho.DataSource = dbContext.Kho.Local.ToBindingList();
        }
        private void close_form(object sender, FormClosedEventArgs e)
        {
            LoadDS_Kho();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (Kho_Id > 0)
            {
                String ten = grvKho.GetRowCellValue(grvKho.FocusedRowHandle, "TenKho").ToString();
                DialogResult dialogResult = MessageBox.Show(ten, "Xác nhận xóa?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    repository.Delete(Kho_Id);


                    // Tải lại danh sách nước sản xuất
                    LoadDS_Kho();
                    txtTenKho.Text = "";
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }                               
            }
        }

        private void Xoatrang()
        {
            txtTenKho.Text = "";
            txtMaKho.Text = "";
            txtDienThoai.Text = "";
            txtDiaChi.Text = "";
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

            Kho obj_Kho;
            try
            {
                if (isUpdate && Kho_Id > 0)
                {
                    obj_Kho = db.Kho.Where(p => p.ID == Kho_Id).SingleOrDefault();
                }
                else
                {
                    obj_Kho = new Kho();
                }
                obj_Kho.TenKho = txtTenKho.Text.Trim();
                obj_Kho.MaKho = txtMaKho.Text.Trim();
                obj_Kho.DiaChi = txtDiaChi.Text.Trim();
                obj_Kho.DienThoai = txtDienThoai.Text.Trim();
                

                if (isUpdate && Kho_Id > 0) // Cập nhật
                {
                    //respository.Save(objNuocSanXuat);
                    db.SaveChanges();

                }
                else // Thêm mới
                {
                    repository.Create(obj_Kho);
                    //db.NCC_KH.Add(_object);
                    //db.SaveChanges(); 
                    Xoatrang();
                }
                LoadDS_Kho();
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

        private void gridcontrolHoatChat_Click(object sender, EventArgs e)
        {
            // dừng xử lý nếu không kích vào dòng có dữ liệu
            if (grvKho.GetRowCellValue(grvKho.FocusedRowHandle, "ID") == null)
                return;

            string id = grvKho.GetRowCellValue(grvKho.FocusedRowHandle, "ID").ToString();
            Kho_Id = Convert.ToInt32(id);
            isUpdate = true;
            //MessageBox.Show(id); 
            txtTenKho.Text = grvKho.GetRowCellValue(grvKho.FocusedRowHandle, "TenKho").ToString();
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



        private void btnSua_Click(object sender, EventArgs e)
        {
            if (Kho_Id > 0)
            {
                layoutControlGroup2.Expanded = true;
                txtTenKho.Focus();

            }
            else
            {
                MessageBox.Show("Hãy lựa chọn dòng cần sửa.");
            }
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            layoutControlGroup2.Expanded = true;
            txtTenKho.Focus();
            Xoatrang();
            isUpdate = false;
        }

        private void gridcontrolViTri_Click(object sender, EventArgs e)
        {
            // dừng xử lý nếu không kích vào dòng có dữ liệu
            if (grvKho.GetRowCellValue(grvKho.FocusedRowHandle, "ID") == null)
                return;

            string id = grvKho.GetRowCellValue(grvKho.FocusedRowHandle, "ID").ToString();
            Kho_Id = Convert.ToInt32(id);
            isUpdate = true;
            //MessageBox.Show(id); 
            txtTenKho.Text = grvKho.GetRowCellValue(grvKho.FocusedRowHandle, "TenKho").ToString();
            txtMaKho.Text = grvKho.GetRowCellValue(grvKho.FocusedRowHandle, "MaKho").ToString();
            txtDiaChi.Text = grvKho.GetRowCellValue(grvKho.FocusedRowHandle, "DiaChi").ToString();
            txtDienThoai.Text = grvKho.GetRowCellValue(grvKho.FocusedRowHandle, "DienThoai").ToString();

        }
    }
}