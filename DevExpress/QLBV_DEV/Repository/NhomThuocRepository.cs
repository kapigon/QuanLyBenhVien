using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Repository
{    
    public partial class NhomThuocRepository
    {
        QLBV_DEV.Helpers.ErrorHandle myError = new QLBV_DEV.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<NhomThuoc> GetAll()
        {
            return from _object in db.NhomThuoc orderby _object.ID ascending select _object;
        }

        public IQueryable<NhomThuoc> GetAll(bool kichhoat)
        {
            return from _object in db.NhomThuoc orderby _object.ID ascending select _object;
        }

        public NhomThuoc GetSingle(int id)
        {
            return (from _object in db.NhomThuoc where _object.ID == id select _object).FirstOrDefault();
        }

        public NhomThuoc GetSingle(string TenNhom)
        {
            return (from c in db.NhomThuoc.AsEnumerable() where Helpers.StringClearFormat.ClearCharacterSpecial(c.TenNhom) == TenNhom select c).FirstOrDefault();
        }
        public List<NhomThuoc> GetAll(int take, int pageSize, ref int count)
        {
            try
            {
                var contents = (from c in db.NhomThuoc
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

        public void Create(NhomThuoc _object)
        {
            try
            {
                db.NhomThuoc.Add(_object);
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
                var _object = (from _list in db.NhomThuoc where _list.ID == id select _list).First();
                db.NhomThuoc.Remove(_object);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

        public void Save(NhomThuoc _object)
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
