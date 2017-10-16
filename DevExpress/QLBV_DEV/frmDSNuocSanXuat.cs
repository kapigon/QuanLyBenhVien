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
    public partial class frmDSNuocSanXuat : DevExpress.XtraEditors.XtraForm
    {
        #region params
        int nuocsanxuat_Id = 0;
        NuocSanXuatRepository repository = new NuocSanXuatRepository();
        HospitalEntities db = new HospitalEntities();
        bool isUpdate = false;
        #endregion

        public frmDSNuocSanXuat()
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
            frmThemNuocSanXuat frmThemNuocSanXuat = new frmThemNuocSanXuat();
            frmThemNuocSanXuat.ShowInTaskbar = false;
            frmThemNuocSanXuat.FormClosed += new FormClosedEventHandler(close_form);
            frmThemNuocSanXuat.ShowDialog();
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
            if (dxValidate.Validate())
            {
                NuocSanXuat _object = new NuocSanXuat()
                {
                    TenNuoc = txtTenNuoc.Text.Trim()
                };

                try
                {
                    if (isUpdate && nuocsanxuat_Id > 0)
                    {
                        NuocSanXuat objNuocSanXuat = db.NuocSanXuat.Where(p => p.ID == nuocsanxuat_Id).SingleOrDefault();
                        objNuocSanXuat.TenNuoc = txtTenNuoc.Text.Trim();

                        db.SaveChanges();
                        // Tải lại danh sách nước sản xuất

                    }
                    else
                    {
                        repository.Create(_object);
                        LoadDS_NuocSanXuat();
                        txtTenNuoc.Text = "";
                        MessageBox.Show("Lưu thành công");
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
            else
            {
                MessageBox.Show("Lỗi");
            }
            
        }

        private void gridcontrolNuocSanXuat_Click(object sender, EventArgs e)
        {
            // dừng xử lý nếu không kích vào dòng có dữ liệu
            if (grvNuocSanXuat.GetRowCellValue(grvNuocSanXuat.FocusedRowHandle, "ID") == null)
                return;

            string id = grvNuocSanXuat.GetRowCellValue(grvNuocSanXuat.FocusedRowHandle, "ID").ToString();
            nuocsanxuat_Id = Convert.ToInt32(id);
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
    }
}