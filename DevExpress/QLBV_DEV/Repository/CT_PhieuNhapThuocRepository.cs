using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Repository
{
    public partial class CT_Thuoc_PhieuNhapRepository
    {
        QLBV_DEV.Helpers.ErrorHandle myError = new QLBV_DEV.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<CT_Thuoc_PhieuNhap> GetAll()
        {
            return from _object in db.CT_Thuoc_PhieuNhap orderby _object.ID ascending select _object;
        }

        public IQueryable<CT_Thuoc_PhieuNhap> GetAllByPhieuNhapThuoc_ID(long ID)
        {
            return from _object in db.CT_Thuoc_PhieuNhap where _object.PhieuNhapHang_ID == ID orderby _object.PhieuNhapHang_ID ascending select _object;
        }

        public CT_Thuoc_PhieuNhap GetSingle(long id)
        {
            return (from _object in db.CT_Thuoc_PhieuNhap where _object.ID == id select _object).FirstOrDefault();
        }
               
        public List<CT_Thuoc_PhieuNhap> GetAll(int take, int pageSize, ref int count)
        {
            try
            {
                var contents = (from c in db.CT_Thuoc_PhieuNhap
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

        public IQueryable<dynamic> ThuocCanDate()
        {
            return (from thuoc_phieunhap in db.CT_Thuoc_PhieuNhap
                   join thuoc in db.Thuoc on thuoc_phieunhap.Thuoc_ID equals thuoc.ID
                   where DateTime.Now >= DbFunctions.AddDays(thuoc_phieunhap.HSD, -thuoc.ThoiGianCanhBaoHetHan)
                    orderby thuoc_phieunhap.HSD ascending
                   select new
                   {
                       Id                       = thuoc_phieunhap.Thuoc_ID,
                       TenThuoc                 = thuoc.TenThuoc,
                       MaThuoc                  = thuoc.MaThuoc,
                       SoLo                     = thuoc_phieunhap.SoLo,
                       HSD                      = thuoc_phieunhap.HSD,
                       ThoiGianCanhBaoHetHan    = thuoc.ThoiGianCanhBaoHetHan,
                   });
        }

        public IQueryable<dynamic> TonKhoTheoLo()
        {
            return (from thuoc_phieunhap in db.CT_Thuoc_PhieuNhap
                    join thuoc in db.Thuoc on thuoc_phieunhap.Thuoc_ID equals thuoc.ID
                    join kho in db.Kho on thuoc_phieunhap.Kho_ID equals kho.ID
                    join vitri in db.ViTri on thuoc_phieunhap.ViTri_ID equals vitri.ID
                    select new
                    {
                        Id          = thuoc_phieunhap.Thuoc_ID,
                        MaThuoc     = thuoc.MaThuoc,
                        TenThuoc    = thuoc.TenThuoc,
                        SoLo        = thuoc_phieunhap.Kho_ID,
                        TonKho      = thuoc_phieunhap.TonKho,
                        TenKho      = kho.TenKho,
                        ViTri       = vitri.TenViTri,
                        HSD         = thuoc_phieunhap.HSD
                    });
        }

        public void Create(CT_Thuoc_PhieuNhap _object)
        {
            try
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        _object.NgayNhap = System.DateTime.Now;
                        db.CT_Thuoc_PhieuNhap.Add(_object);
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
                        var _object = (from _list in db.CT_Thuoc_PhieuNhap where _list.ID == id select _list).First();
                        db.CT_Thuoc_PhieuNhap.Remove(_object);
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

        public void Save(CT_Thuoc_PhieuNhap _object)
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


        public IQueryable<dynamic> search(long thuoc_Id, int nhomthuoc_Id, int hangsanxuat_Id, int khohang_Id,
                                           string solo, int hoatchat_Id, int nuocsanxuat_Id, int vitri_Id)
        {
            var query = from _object in db.CT_Thuoc_PhieuNhap
                        //join nt in db.NhomThuoc on _object.NhomThuoc_ID equals nt.ID
                        //join hc in db.HoatChat on _object.HoatChat_ID equals hc.ID
                        //join hsx in db.HangSanXuat on _object.HangSanXuat_ID equals hsx.ID
                        from khohang        in db.Kho.Where(kh => kh.ID == _object.Kho_ID).DefaultIfEmpty()
                        from vitri          in db.ViTri.Where(vt => vt.ID == _object.ViTri_ID).DefaultIfEmpty()
                        from thuoc          in db.Thuoc.Where(t => t.ID == _object.Thuoc_ID)
                        from nhomthuoc      in db.NhomThuoc.Where(nt => nt.ID == thuoc.NhomThuoc_ID).DefaultIfEmpty()
                        from hangsanxuat    in db.HangSanXuat.Where(hsx => hsx.ID == thuoc.HangSanXuat_ID).DefaultIfEmpty()
                        from hoatchat       in db.HoatChat.Where(hc => hc.ID == thuoc.HoatChat_ID).DefaultIfEmpty()
                        from nuocsanxuat    in db.NuocSanXuat.Where(nsx => nsx.ID == thuoc.NuocSanXuat_ID).DefaultIfEmpty()


                        select new
                        {
                            ID              = _object.ID,
                            ThuocID         = _object.Thuoc_ID,
                            MaThuoc         = thuoc.MaThuoc,
                            TenThuoc        = thuoc.TenThuoc,

                            SoLo            = _object.SoLo,
                            DVT             = thuoc.DVT_Le_ID,
                            HSD             = _object.HSD,
                            TonKho          = _object.TonKho,

                            KhoHang_Id      = _object.Kho_ID,
                            KhoHang         = khohang.TenKho,

                            ViTri_Id        = _object.ViTri_ID,
                            ViTri           = vitri.TenViTri,

                            TenNhom         = nhomthuoc.TenNhom,
                            NhomThuoc_ID    = thuoc.NhomThuoc_ID,

                            TenHangSX       = hangsanxuat.TenHangSX,
                            HangSX_Id       = thuoc.HangSanXuat_ID,

                            TenNuocSX       = nuocsanxuat.TenNuoc,
                            NuocSX_Id       = thuoc.NuocSanXuat_ID,

                            TenHoatChat     = hoatchat.TenHoatChat,
                            hoatchat_Id     = thuoc.HoatChat_ID
                        };

            if (thuoc_Id > 0)
                query = query.Where(p => p.ThuocID == thuoc_Id);

            if (nhomthuoc_Id > 0)
                query = query.Where(p => p.NhomThuoc_ID == nhomthuoc_Id);

            if (hangsanxuat_Id > 0)
                query = query.Where(p => p.HangSX_Id == hangsanxuat_Id);

            if (khohang_Id > 0)
                query = query.Where(p => p.KhoHang_Id == khohang_Id);

            if (solo != "")
                query = query.Where(p => p.SoLo.Contains(solo));

            if (hoatchat_Id > 0)
                query = query.Where(p => p.hoatchat_Id == hoatchat_Id);

            if (nuocsanxuat_Id > 0)
                query = query.Where(p => p.NuocSX_Id == nuocsanxuat_Id);

            if (vitri_Id > 0)
                query = query.Where(p => p.ViTri_Id == vitri_Id);

            return query;
        }
        
        public IQueryable<dynamic> BangKeCT_Nhap_Thuoc(DateTime tuNgay, DateTime denNgay)
        {
            return (from ct_nhap in db.CT_Thuoc_PhieuNhap
                    join phieunhap in db.PhieuNhapThuoc on ct_nhap.PhieuNhapHang_ID equals phieunhap.ID
                    join thuoc in db.Thuoc on ct_nhap.Thuoc_ID equals thuoc.ID
                    join dvt in db.DonViTinh on ct_nhap.DVT_Theo_DVT_Thuoc_ID equals dvt.ID
                    where (ct_nhap.NgayNhap >= tuNgay && ct_nhap.NgayNhap <= denNgay)
                    select new
                    {
                        SoPhieu = phieunhap.SoPhieu,
                        Thuoc_ID = thuoc.ID,
                        MaThuoc = thuoc.MaThuoc,
                        TenThuoc = thuoc.TenThuoc,
                        TenDVT = dvt.TenDVT,
                        SoLuong = ct_nhap.SoLuong,
                        GiaNhap = ct_nhap.GiaNhap
                    });
        }

        public IQueryable<dynamic> DS_ThuocCanDate(DateTime thoigiantoi)
        {
            return (from thuoc_phieunhap in db.CT_Thuoc_PhieuNhap
                    join thuoc in db.Thuoc on thuoc_phieunhap.Thuoc_ID equals thuoc.ID
                    where DateTime.Now <= thuoc_phieunhap.HSD && thuoc_phieunhap.HSD <= thoigiantoi
                    select new
                    {
                        Id = thuoc_phieunhap.Thuoc_ID,
                        TenThuoc = thuoc.TenThuoc,
                        Mathuoc = thuoc.MaThuoc,
                        HSD = thuoc_phieunhap.HSD
                    });
        }
    }
}
