using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Repository
{
    public partial class CT_Thuoc_PhieuXuatRepository
    {
        QLBV_DEV.Helpers.ErrorHandle myError = new QLBV_DEV.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<CT_Thuoc_PhieuXuat> GetAll()
        {
            return from _object in db.CT_Thuoc_PhieuXuat orderby _object.ID ascending select _object;
        }

        public IQueryable<CT_Thuoc_PhieuXuat> GetAllByPhieuXuatThuoc_ID(long ID)
        {
            return from _object in db.CT_Thuoc_PhieuXuat where _object.PhieuXuatHang_ID == ID orderby _object.PhieuXuatHang_ID ascending select _object;
        }

        public CT_Thuoc_PhieuXuat GetSingle(long id)
        {
            return (from _object in db.CT_Thuoc_PhieuXuat where _object.ID == id select _object).FirstOrDefault();
        }
               
        public List<CT_Thuoc_PhieuXuat> GetAll(int take, int pageSize, ref int count)
        {
            try
            {
                var contents = (from c in db.CT_Thuoc_PhieuXuat
                                orderby c.ID descending
                                select c)
                                .ToList()
                                .Skip(pageSize)
                                .Take(take);
                count = contents.Count();
                return contents.ToList();

            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
                return null;
            }
        }

        public IQueryable<dynamic> search(int ncc_kh_ID, String soPhieu, DateTime tuNgay, DateTime denNgay, String soHoaDon)
        {
            var query = from ct_phieuxuat       in db.CT_Thuoc_PhieuXuat
                        join phieuxuat          in db.PhieuXuatThuoc        on ct_phieuxuat.PhieuXuatHang_ID        equals phieuxuat.ID
                        join ct_phieunhap       in db.CT_Thuoc_PhieuNhap    on ct_phieuxuat.CT_Thuoc_PhieuNhap_ID   equals ct_phieunhap.ID
                        join thuoc              in db.Thuoc                 on ct_phieunhap.Thuoc_ID                equals thuoc.ID
                        join dvt                in db.DonViTinh             on ct_phieuxuat.DVT_Theo_DVT_Thuoc_ID   equals dvt.ID
                        //from ncc_kh             in db.NCC_KH.Where(p=>p.ID == phieuxuat.NCC_KH_ID).DefaultIfEmpty()
                        //orderby phieunhap.ID ascending
                        select new
                        {
                           // ID = thuoc.ID,
                            MaThuoc = thuoc.MaThuoc,
                            TenThuoc = thuoc.TenThuoc,
                            SoLuong = ct_phieuxuat.SoLuong,
                            GiaBan = ct_phieuxuat.GiaBan,
                            DVT = dvt.TenDVT,
                            NgayBan = phieuxuat.NgayTao,
                            TongTien = ct_phieuxuat.TongTien,
                            ///NCC_KH_ID = ncc_kh.ID,
                            SoPhieu = phieuxuat.SoPhieu,
                            NgayTao = phieuxuat.NgayTao,
                            SoHoaDon = phieuxuat.SoHoaDon
                            //SoPhieu     = phieux.SoPhieu,
                            //SoHoaDon    = phieunhap.SoHoaDon,
                            //NgayNhap    = phieunhap.NgayNhap,
                            //NCC_KH_ID   = ncc_kh.TenNCC_KH,
                            //ThueSuat    = phieunhap.ThueSuat + "%",
                            //ChietKhau   = phieunhap.ChietKhau,
                            //TongTienTra = phieunhap.TongTienTra
                        };

            //if (ncc_kh_ID > 0)
            //    query = query.Where(p => p.NCC_KH_ID == ncc_kh_ID);

            if (soPhieu != "")
                query = query.Where(p => p.SoPhieu == soPhieu);

            if (tuNgay != null)
                query = query.Where(p => p.NgayTao >= tuNgay);

            if (denNgay != null)
                query = query.Where(p => p.NgayTao <= denNgay);

            if (soHoaDon != "")
                query = query.Where(p => p.SoHoaDon == soHoaDon);

            return query;
        }

        public IQueryable<dynamic> BangKeCT_Xuat_Thuoc(DateTime tuNgay, DateTime denNgay)
        {
            return (from ct_xuat    in db.CT_Thuoc_PhieuXuat
                    join phieuxuat  in db.PhieuXuatThuoc        on ct_xuat.PhieuXuatHang_ID         equals phieuxuat.ID
                    join ct_nhap    in db.CT_Thuoc_PhieuNhap    on ct_xuat.CT_Thuoc_PhieuNhap_ID    equals ct_nhap.ID
                    join thuoc      in db.Thuoc                 on ct_nhap.Thuoc_ID                 equals thuoc.ID
                    join dvt        in db.DonViTinh             on ct_xuat.DVT_Theo_DVT_Thuoc_ID    equals dvt.ID
                    where (ct_xuat.NgayBan >= tuNgay && ct_xuat.NgayBan <= denNgay) && ct_xuat.SoLuong > 0
                    select new
                    {
                        SoPhieu     = phieuxuat.SoPhieu,
                        Thuoc_ID    = thuoc.ID,
                        MaThuoc     = thuoc.MaThuoc,
                        TenThuoc    = thuoc.TenThuoc,
                        TenDVT      = dvt.TenDVT,
                        SoLuong     = ct_xuat.SoLuong,
                        GiaBan      = ct_xuat.GiaBan
                    });
        }

        public void Create(CT_Thuoc_PhieuXuat _object)
        {
            try
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        _object.NgayBan = System.DateTime.Now;
                        db.CT_Thuoc_PhieuXuat.Add(_object);
                        db.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var _object = (from _list in db.CT_Thuoc_PhieuXuat where _list.ID == id select _list).First();
                        db.CT_Thuoc_PhieuXuat.Remove(_object);
                        db.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

        public void Save(CT_Thuoc_PhieuXuat _object)
        {
            try
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

    }
}
