using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace QLBV_DEV.Repository
{    
    public partial class ThongTinChungRepository
    {
        QLBV_DEV.Helpers.ErrorHandle myError = new QLBV_DEV.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<ThongTinChung> GetAll()
        {
            return from _object in db.ThongTinChung orderby _object.ID ascending select _object;
        }

        public IQueryable<ThongTinChung> GetAll(bool kichhoat)
        {
            return from _object in db.ThongTinChung where (_object.KichHoat == kichhoat) orderby _object.ID ascending select _object;
        }

        public ThongTinChung GetSingle(int id)
        {
            return (from _object in db.ThongTinChung where _object.ID == id select _object).FirstOrDefault();
        }
        
        public void Create(ThongTinChung _object)
        {
            try
            {
                db.ThongTinChung.Add(_object);
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
                var _object = (from _list in db.ThongTinChung where _list.ID == id select _list).First();
                db.ThongTinChung.Remove(_object);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

        public void Save(ThongTinChung _object)
        {
            try{
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

    }
}
