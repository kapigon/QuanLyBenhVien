using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Repository
{    
    public partial class ThuocRepository
    {
        QLBV_DEV.Helpers.ErrorHandle myError = new QLBV_DEV.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<Thuoc> GetAll()
        {
            return from _object in db.Thuoc orderby _object.ID ascending select _object;
        }

        public IQueryable<Thuoc> GetAll(bool kichhoat)
        {
            return from _object in db.Thuoc where (_object.KichHoat == kichhoat) orderby _object.ID ascending select _object;
        }

        public Thuoc GetSingle(long id)
        {
            return (from _object in db.Thuoc where _object.ID == id select _object).FirstOrDefault();
        }

        public int GetCountTonKho(long id){

            var query = from _object in db.CT_Thuoc_PhieuNhap where _object.Thuoc_ID == id select _object;

            return query.Sum(x => x.TonKho).Value;
        }

        public Thuoc GetSingleByTenThuoc(string tenThuoc)
        {
            return (from c in db.Thuoc.AsEnumerable() where Helpers.StringClearFormat.ClearCharacterSpecial(c.TenThuoc) == tenThuoc select c).FirstOrDefault();
        }

        public Thuoc GetSingleByMaThuoc(string maThuoc)
        {
            return (from c in db.Thuoc.AsEnumerable() where Helpers.StringClearFormat.ClearCharacterSpecial(c.MaThuoc) == maThuoc select c).FirstOrDefault();
        }

        public List<Thuoc> GetAll(int take, int pageSize, ref int count)
        {
            try
            {
                var contents = (from c in db.Thuoc
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

        public void Create(Thuoc _object)
        {
            try
            {
                _object.NgayTao = System.DateTime.Now;
                db.Thuoc.Add(_object);
                db.SaveChanges();
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
                var _object = (from _list in db.Thuoc where _list.ID == id select _list).First();
                db.Thuoc.Remove(_object);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

        public void Save(Thuoc _object)
        {
            try
            {
                //_object.EntityKey = (from Thuoc ac in db.Thuoc where ac.ID == _object.ID select ac).FirstOrDefault().EntityKey;
                //_object.NgayTao = System.DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

    }
}
