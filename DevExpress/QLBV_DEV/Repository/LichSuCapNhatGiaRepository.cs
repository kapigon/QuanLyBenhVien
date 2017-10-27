using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Repository
{    
    public partial class LichSuCapNhatGiaRepository
    {
        QLBV_DEV.Helpers.ErrorHandle myError = new QLBV_DEV.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<LichSuCapNhatGia> GetAll()
        {
            return from _object in db.LichSuCapNhatGia orderby _object.ID ascending select _object;
        }

        public IQueryable<LichSuCapNhatGia> GetAllByThuoID(long thuocID)
        {
            return from _object in db.LichSuCapNhatGia where _object.Thuoc_ID == thuocID orderby _object.Thuoc_ID ascending select _object;
        }
        
        public LichSuCapNhatGia GetSingle(int id)
        {
            return (from _object in db.LichSuCapNhatGia where _object.ID == id select _object).FirstOrDefault();
        }
               
        public void Create(LichSuCapNhatGia _object)
        {
            try
            {
                _object.NgayTao = DateTime.Now;
                db.LichSuCapNhatGia.Add(_object);
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
                var _object = (from _list in db.LichSuCapNhatGia where _list.ID == id select _list).First();
                db.LichSuCapNhatGia.Remove(_object);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

        public void Save(LichSuCapNhatGia _object)
        {
            try
            {
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
