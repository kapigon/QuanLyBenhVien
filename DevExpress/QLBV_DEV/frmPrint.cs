using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBV_DEV.Reports;
using QLBV_DEV.Repository;
using QLBV_DEV.Reports.Objects;
using System.Data.Entity.Validation;
using System.Diagnostics;
using QLBV_DEV.Helpers;

namespace QLBV_DEV
{
    public partial class frmPrint : DevExpress.XtraEditors.XtraForm
    {
        public frmPrint()
        {
            InitializeComponent();
        }

        public void printDSThuoc(List<oPhieuXuatThuoc> lstThuoc, NCC_KH khachhang)
        {
            try
            {

                ThuocRepository rpo_thuoc = new ThuocRepository();
                NhanVien obj_NhanVien = new NhanVien();
                if (LoginInfo.nhanVien != null)
                {
                    obj_NhanVien = LoginInfo.nhanVien;
                }
                rptPhieuXuatThuoc report = new rptPhieuXuatThuoc(khachhang, obj_NhanVien);

                report.DataSource = lstThuoc;

                documentViewer1.DocumentSource = report;
                report.CreateDocument();
            }
            catch (DbEntityValidationException dbEx)
            {
                string strError = "";
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        strError += validationError.ErrorMessage;
                        Trace.TraceInformation(
                              "Class: {0}, Property: {1}, Error: {2}",
                              validationErrors.Entry.Entity.GetType().FullName,
                              validationError.PropertyName,
                              validationError.ErrorMessage);
                    }
                }
                MessageBox.Show(strError);
            }
        }
    }
}