using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Repository
{
    public partial class PhieuXuatThuocRepository
    {
        QLBV_DEV.Helpers.ErrorHandle myError = new QLBV_DEV.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<PhieuXuatThuoc> GetAll()
        {
            return from _object in db.PhieuXuatThuoc orderby _object.ID ascending select _object;
        }

        public int getCountByDay(string search)
        {
            var query = from _object in db.PhieuXuatThuoc
                        where _object.SoPhieu.StartsWith(search)
                        orderby _object.ID ascending
                        select _object;

            return query.Count();
        }

        public IQueryable<PhieuXuatThuoc> GetAllNotDelete()
        {
            return from _object in db.PhieuXuatThuoc where _object.Xoa != true orderby _object.ID ascending select _object;
        }

        public int getTongSoDonBanHomNay()
        {
            return (from _object in db.PhieuXuatThuoc where _object.NgayTao == DateTime.Today select _object).Count();

        }

        public int getTongSoDonChoHuyHomNay()
        {
            return (from _object in db.PhieuXuatThuoc where _object.NgayXoa == DateTime.Today && _object.TrangThaiPhieu_ID == 2 select _object).Count();

        }

        public int getTongSoDonDaHuyHomNay()
        {
            return (from _object in db.PhieuXuatThuoc where _object.NgayXoa == DateTime.Today && _object.TrangThaiPhieu_ID == 4 select _object).Count();
        }

        public IQueryable<dynamic> search(int ncc_kh_ID, String soPhieu, DateTime tuNgay, DateTime denNgay, String soHoaDon, int trangthaiPhieu)
        {
            var query = from _object in db.PhieuXuatThuoc
                        //from kh in db.NCC_KH.Where(kh => kh.ID == phieuxuat.NCC_KH_ID).DefaultIfEmpty()
                        where _object.Xoa != true && _object.TrangThaiPhieu_ID == trangthaiPhieu
                        orderby _object.ID descending
                        select new
                        {
                            ID = _object.ID,
                            SoPhieu = _object.SoPhieu,
                            SoHoaDon = _object.SoHoaDon,
                            NgayTao = _object.NgayTao,
                            //NCC_KH_ID     = kh.TenNCC_KH,
                            NCC_KH_ID = _object.NCC_KH_ID,
                            ThueSuat = _object.ThueSuat + "%",
                            ChietKhau = _object.ChietKhau,
                            TongTienKHTra = _object.TongTienKHTra
                        };

            if (ncc_kh_ID > 0)
                query = query.Where(p => p.NCC_KH_ID == ncc_kh_ID);

            if (soPhieu != "")
                query = query.Where(p => p.SoPhieu == soPhieu);

            if (tuNgay != null && tuNgay.ToString("dd/MM/yyyy") != "01/01/0001")
                query = query.Where(p => p.NgayTao >= tuNgay);

            if (denNgay != null && denNgay.ToString("dd/MM/yyyy") != "01/01/0001")
                query = query.Where(p => p.NgayTao <= denNgay);

            if (soHoaDon != "")
                query = query.Where(p => p.SoHoaDon == soHoaDon);

            return query;
            //return from _object in db.PhieuXuatThuoc orderby _object.ID ascending select _object;
        }

        public PhieuXuatThuoc GetSingle(long id)
        {
            return (from _object in db.PhieuXuatThuoc where _object.ID == id select _object).FirstOrDefault();
        }

        public PhieuXuatThuoc GetSingle(string soPhieu)
        {
            return (from c in db.PhieuXuatThuoc.AsEnumerable() where Helpers.StringClearFormat.ClearCharacterSpecial(c.SoPhieu) == soPhieu select c).FirstOrDefault();
        }
        public List<PhieuXuatThuoc> GetAll(int take, int pageSize, ref int count)
        {
            try
            {
                var contents = (from c in db.PhieuXuatThuoc
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

        public void Create(PhieuXuatThuoc _object)
        {
            try
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        //_object.NgayNhap = System.DateTime.Now;
                        db.PhieuXuatThuoc.Add(_object);
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
                        var _object = (from _list in db.PhieuXuatThuoc where _list.ID == id select _list).First();
                        db.PhieuXuatThuoc.Remove(_object);
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

        public void Save(PhieuXuatThuoc _object)
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
