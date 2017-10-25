using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Repository
{    
    public partial class HangSanXuatRepository
    {
        QLBV_DEV.Helpers.ErrorHandle myError = new QLBV_DEV.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<HangSanXuat> GetAll()
        {
            return from _object in db.HangSanXuat orderby _object.ID ascending select _object;
        }

        public IQueryable<HangSanXuat> GetAll(bool kichhoat)
        {
            return from _object in db.HangSanXuat orderby _object.ID ascending select _object;
        }

        public HangSanXuat GetSingle(int id)
        {
            return (from _object in db.HangSanXuat where _object.ID == id select _object).FirstOrDefault();
        }

        public HangSanXuat GetSingle(string TenHangSX)
        {
            return (from c in db.HangSanXuat.AsEnumerable() where Helpers.StringClearFormat.ClearCharacterSpecial(c.TenHangSX) == TenHangSX select c).FirstOrDefault();
        }
        public List<HangSanXuat> GetAll(int take, int pageSize, ref int count)
        {
            try
            {
                var contents = (from c in db.HangSanXuat
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

        public void Create(HangSanXuat _object)
        {
            try
            {
                db.HangSanXuat.Add(_object);
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
                var _object = (from _list in db.HangSanXuat where _list.ID == id select _list).First();
                db.HangSanXuat.Remove(_object);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

        public void Save(HangSanXuat _object)
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
