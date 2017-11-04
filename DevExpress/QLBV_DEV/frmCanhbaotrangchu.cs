using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBV_DEV.Repository;
using System.Data.Entity;

namespace QLBV_DEV
{
    public partial class frmCanhbaotrangchu : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities db = new HospitalEntities();
        ThuocRepository rpo_Thuoc = new ThuocRepository();
        #endregion

        public frmCanhbaotrangchu()
        {
            InitializeComponent();
            LoadDS_ThuocCanDate();
            LoadDS_TonKhoToiThieu();
            LoadDS_PhieuXuat();
            LoadDS_PhieuNhap();
        }

        private void LoadDS_ThuocCanDate()
        {
            var query = from thuoc_phieunhap in db.CT_Thuoc_PhieuNhap
                        join thuoc in db.Thuoc on thuoc_phieunhap.Thuoc_ID equals thuoc.ID
                        where DateTime.Now >= DbFunctions.AddDays(thuoc_phieunhap.HSD, -thuoc.ThoiGianCanhBaoHetHan)
                        select new
                        {
                            Id = thuoc_phieunhap.Thuoc_ID,
                            TenThuoc = thuoc.TenThuoc,
                            Mathuoc = thuoc.MaThuoc,
                            SoLo = thuoc_phieunhap.SoLo,
                            HSD = thuoc_phieunhap.HSD
                        };
            gridControl1.DataSource = query.ToList();
        }


        private void LoadDS_TonKhoToiThieu()
        {
            var query = from thuoc in db.Thuoc
                        join nhomthuoc in db.NhomThuoc on thuoc.NhomThuoc_ID equals nhomthuoc.ID
                        // join hangsanxuat in db.HangSanXuat on thuoc.HangSanXuat_ID equals hangsanxuat.ID                      
                        where thuoc.TonKho < thuoc.TonKhoToiThieu

                        select new
                        {
                            Id = thuoc.ID,
                            MaThuoc = thuoc.MaThuoc,
                            TenThuoc = thuoc.TenThuoc,

                            TonKho = thuoc.TonKho,
                            //TonKhoToiThieu = thuoc.TonKhoToiThieu,
                            // HangSanXuat = hangsanxuat.TenHangSX,
                            //NhomThuoc = nhomthuoc.TenNhom
                        };
            gridControl2.DataSource = query.ToList();
        }

        private void LoadDS_PhieuXuat()
        {
            //var result = from nv in db.PhieuNhapThuoc
            //             where nv.Xoa == false
            //             select nv;
            //var result = rpo_PhieuNhap.GetAllNotDelete();
            var result = from phieuxuat in db.PhieuXuatThuoc
                         //join ncc_kh in db.NCC_KH on phieuxuat.NCC_KH_ID equals ncc_kh.ID
                         from kh in db.NCC_KH.Where(kh => kh.ID == phieuxuat.NCC_KH_ID).DefaultIfEmpty()
                         where phieuxuat.Xoa != true
                         orderby phieuxuat.ID ascending
                         select new
                         {
                             ID = phieuxuat.ID,
                             SoPhieu = phieuxuat.SoPhieu,
                             //SoHoaDon = phieuxuat.SoHoaDon,
                             NgayTao = phieuxuat.NgayTao,
                             //NCC_KH_ID = kh.TenNCC_KH,
                             //ThueSuat = phieuxuat.ThueSuat + "%",
                             //ChietKhau = phieuxuat.ChietKhau,
                             TongTienKHTra = phieuxuat.TongTienKHTra
                         };
            gridControl4.DataSource = result.ToList();
        }

        private void LoadDS_PhieuNhap()
        {
            var result = from phieunhap in db.PhieuNhapThuoc
                         join ncc_kh in db.NCC_KH on phieunhap.NCC_KH_ID equals ncc_kh.ID
                         where phieunhap.Xoa != true
                         orderby phieunhap.ID ascending
                         select new
                         {
                             ID = phieunhap.ID,
                             SoPhieu = phieunhap.SoPhieu,
                             //SoHoaDon = phieunhap.SoHoaDon,
                             NgayTao = phieunhap.NgayNhap,
                             //NCC_KH_ID = ncc_kh.TenNCC_KH,
                             //ThueSuat = phieunhap.ThueSuat + "%",
                             //ChietKhau = phieunhap.ChietKhau,
                             TongTien = phieunhap.TongTienTra
                         };
            gridControl3.DataSource = result.ToList();
        }
    }
}