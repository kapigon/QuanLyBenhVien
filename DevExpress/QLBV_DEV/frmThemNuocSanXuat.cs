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
    public partial class frmThemNuocSanXuat : DevExpress.XtraEditors.XtraForm
    {
        HospitalEntities db = new HospitalEntities();
        NuocSanXuatRepository respository = new NuocSanXuatRepository();
        bool isUpdate = false;
        int nuocsanxuat_Id = 0;

        public frmThemNuocSanXuat()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
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
                    this.Close();
                }
                else
                {
                    respository.Create(_object);
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
}