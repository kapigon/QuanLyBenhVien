﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLBV_DEV
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HospitalEntities : DbContext
    {
        public HospitalEntities()
            : base("name=HospitalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ChiTietPhanQuyen> ChiTietPhanQuyen { get; set; }
        public virtual DbSet<ChucNangQuanLy> ChucNangQuanLy { get; set; }
        public virtual DbSet<DonViTinh> DonViTinh { get; set; }
        public virtual DbSet<Kho> Kho { get; set; }
        public virtual DbSet<LichSuGia> LichSuGia { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<NhomThuoc> NhomThuoc { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyen { get; set; }
        public virtual DbSet<PhieuNhapThuoc> PhieuNhapThuoc { get; set; }
        public virtual DbSet<Thuoc> Thuoc { get; set; }
        public virtual DbSet<CT_Thuoc_PhieuNhap> CT_Thuoc_PhieuNhap { get; set; }
        public virtual DbSet<CT_Thuoc_PhieuXuat> CT_Thuoc_PhieuXuat { get; set; }
        public virtual DbSet<HangSanXuat> HangSanXuat { get; set; }
        public virtual DbSet<HoatChat> HoatChat { get; set; }
        public virtual DbSet<NuocSanXuat> NuocSanXuat { get; set; }
        public virtual DbSet<TrangThaiPhieu> TrangThaiPhieu { get; set; }
        public virtual DbSet<NCC_KH> NCC_KH { get; set; }
        public virtual DbSet<LoaiNCC_KH> LoaiNCC_KH { get; set; }
        public virtual DbSet<ViTri> ViTri { get; set; }
        public virtual DbSet<LoaiHinhBan> LoaiHinhBan { get; set; }
        public virtual DbSet<PhieuXuatThuoc> PhieuXuatThuoc { get; set; }
        public virtual DbSet<CT_PhieuDieuChinh> CT_PhieuDieuChinh { get; set; }
        public virtual DbSet<PhieuDieuChinh> PhieuDieuChinh { get; set; }
        public virtual DbSet<LichSuCapNhatGia> LichSuCapNhatGia { get; set; }
        public virtual DbSet<CT_DonViTinh> CT_DonViTinh { get; set; }
        public virtual DbSet<ThongTinChung> ThongTinChung { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
    }
}
