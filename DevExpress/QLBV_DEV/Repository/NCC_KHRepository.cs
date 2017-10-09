using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Repository
{    
    public partial class NCC_KHRepository
    {
        QLBV_DEV.Helpers.ErrorHandle myError = new QLBV_DEV.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<NCC_KH> GetAll()
        {
            return from _object in db.NCC_KH orderby _object.ID ascending select _object;
        }

        public IQueryable<NCC_KH> GetAll(bool kichhoat)
        {
            return from _object in db.NCC_KH where (_object.KichHoat == kichhoat) orderby _object.ID ascending select _object;
        }

        public NCC_KH GetSingle(int id)
        {
            return (from _object in db.NCC_KH where _object.ID == id select _object).FirstOrDefault();
        }

        public NCC_KH GetSingle(string tenNCC_KH)
        {
            return (from c in db.NCC_KH.AsEnumerable() where Helpers.StringClearFormat.ClearCharacterSpecial(c.TenNCC_KH) == tenNCC_KH select c).FirstOrDefault();
        }
        public List<NCC_KH> GetAll(int take, int pageSize, ref int count)
        {
            try
            {
                var contents = (from c in db.NCC_KH
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

        public void Create(NCC_KH _object)
        {
            try
            {
                _object.NgayTao = System.DateTime.Now;
                db.NCC_KH.Add(_object);
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
                var _object = (from _list in db.NCC_KH where _list.ID == id select _list).First();
                db.NCC_KH.Remove(_object);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

        public void Save(NCC_KH _object)
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

    }
}
