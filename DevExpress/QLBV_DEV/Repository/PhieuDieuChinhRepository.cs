using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Repository
{    
    public partial class PhieuDieuChinhRepository
    {
        QLBV_DEV.Helpers.ErrorHandle myError = new QLBV_DEV.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<PhieuDieuChinh> GetAll()
        {
            return from _object in db.PhieuDieuChinh orderby _object.ID ascending select _object;
        }

        public long GetCount()
        {
            return (from _object in db.PhieuDieuChinh select _object).Count();
        } 

        public PhieuDieuChinh GetSingle(long id)
        {
            return (from _object in db.PhieuDieuChinh where _object.ID == id select _object).FirstOrDefault();
        }
        
        public PhieuDieuChinh GetSingleByTenPhieuDieuChinh(string tenPhieuDieuChinh)
        {
            return (from c in db.PhieuDieuChinh.AsEnumerable() where Helpers.StringClearFormat.ClearCharacterSpecial(c.Ten) == tenPhieuDieuChinh select c).FirstOrDefault();
        }

        public PhieuDieuChinh GetSingleByMaPhieuDieuChinh(string maPhieuDieuChinh)
        {
            return (from c in db.PhieuDieuChinh.AsEnumerable() where c.Ma == maPhieuDieuChinh select c).FirstOrDefault();
        }

        public int getCountByDay(string search)
        {
            var query = from _object in db.PhieuDieuChinh
                        where _object.Ma.StartsWith(search)
                        orderby _object.ID ascending
                        select _object;

            return query.Count();
        }

        public IQueryable<PhieuDieuChinh> search(String ma, String ten, DateTime tuNgay, DateTime denNgay)
        {
            var query = from _object in db.PhieuDieuChinh
                        orderby _object.ID descending
                        select _object;

            if (ma != "")
                query.Where(p => p.Ma.Contains(ma));

            if (ten != "")
                query.Where(p => p.Ten.Contains(ten));

            if (tuNgay != null && tuNgay.ToString("dd/MM/yyyy") != "01/01/0001")
                query.Where(p => p.NgayTao >= tuNgay);

            if (denNgay != null && denNgay.ToString("dd/MM/yyyy") != "01/01/0001")
                query.Where(p => p.NgayTao <= denNgay);
            
            return query;
        }

        public List<PhieuDieuChinh> GetAll(int take, int pageSize, ref int count)
        {
            try
            {
                var contents = (from c in db.PhieuDieuChinh
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

        public void Create(PhieuDieuChinh _object)
        {
            try
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        _object.NgayTao = System.DateTime.Now;
                        db.PhieuDieuChinh.Add(_object);
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
                        var _object = (from _list in db.PhieuDieuChinh where _list.ID == id select _list).First();
                        db.PhieuDieuChinh.Remove(_object);
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

        public void Save(PhieuDieuChinh _object)
        {
            try
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        //_object.EntityKey = (from PhieuDieuChinh ac in db.PhieuDieuChinh where ac.ID == _object.ID select ac).FirstOrDefault().EntityKey;
                        //_object.NgayTao = System.DateTime.Now;
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
