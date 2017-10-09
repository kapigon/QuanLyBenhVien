using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBenhVien.Reports
{
    public partial class frmBaoCao : Form
    {
        HospitalEntities db = new HospitalEntities();
        public frmBaoCao()
        {
            InitializeComponent();
        }
        public void PreviewReport(string strSQL,  int numberReport){
            switch (numberReport)
            {
                case 1:
                    Console.WriteLine("Case 1");
                    //var result = from nv in db.NhanViens
                    //             select nv;
                    rptNhanVien rpt_NV = new rptNhanVien();
                    //rpt_NV.
                    /*List<NhanVien> lstNhanVien = new List<NhanVien>();
                    lstNhanVien = db.NhanViens.Select(p => p).ToList();
                    lstNhanVien = from nv in db.NhanViens
                                         select new NhanVien
                                         {
                                             ID = nv.ID,
                                             TaiKhoan = nv.TaiKhoan,
                                             HoVaTen = nv.HoVaTen,
                                             DiaChi = nv.DiaChi,
                                             CMT = nv.CMT
                                         };
                    */
                    //lstNhanVien = lst.ToList();
                   /* List<Khoa> lstKhoa = new List<Khoa>();
                    lstKhoa = db.Khoas.Select(p => p).ToList();

                    
                    rptNhanVien.SetDataSource(db.Khoas.Select(p => new { 
                        ID = p.ID,
                        TenKhoa = p.TenKhoa
                    }).ToList());*/
                    rptNhanVien.SetDataSource(db.NhanViens.Select(p => new
                    {
                        ID = p.ID,
                        HoVaTen = p.HoVaTen,
                        TaiKhoan = p.TaiKhoan,
                        DiaChi = p.DiaChi
                    }).ToList());
                    rptNhanVien.SetParameterValue("pUserName", "Admin");
                    rptNhanVien.SetParameterValue("pFullName", "Le Phuc Hoa");
                    rptNhanVien.SetParameterValue("pAddress", "Ha Noi");
                    rptNhanVien.SetParameterValue("pSex", "Nam");
                    rptNhanVien.SetParameterValue("pBirthday", "29/08/1988");
                    rptNhanVien.SetParameterValue("pCMT", "123456789");
                    crvBaoCao.ReportSource = rptNhanVien;
                    crvBaoCao.Refresh();
                     /*Dim rpt As New rptPhieuNhapKho
                Dim rpt1 As CrystalDecisions.CrystalReports.Engine.ReportDocument = rpt.Subreports(0)
                rpt1.SetDataSource(ds.Tables(1))
                rpt.SetDataSource(ds.Tables(0))
                rpt.Refresh()
                Me.CrystalReportViewer1.ReportSource = rpt*/
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }
    }
}
