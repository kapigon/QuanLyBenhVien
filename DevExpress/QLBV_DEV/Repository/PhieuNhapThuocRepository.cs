using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Repository
{
    public partial class PhieuNhapThuocRepository
    {
        QLBV_DEV.Helpers.ErrorHandle myError = new QLBV_DEV.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<PhieuNhapThuoc> GetAll()
        {
            return from _object in db.PhieuNhapThuoc orderby _object.ID ascending select _object;
        }

        public IQueryable<PhieuNhapThuoc> GetAllNotDelete()
        {
            return from _object in db.PhieuNhapThuoc where _object.Xoa != true orderby _object.ID ascending select _object;
        }

        public PhieuNhapThuoc GetSingle(long id)
        {
            return (from _object in db.PhieuNhapThuoc where _object.ID == id select _object).FirstOrDefault();
        }

        public PhieuNhapThuoc GetSingle(string soPhieu)
        {
            return (from c in db.PhieuNhapThuoc.AsEnumerable() where Helpers.StringClearFormat.ClearCharacterSpecial(c.SoPhieu) == soPhieu select c).FirstOrDefault();
        }
        public List<PhieuNhapThuoc> GetAll(int take, int pageSize, ref int count)
        {
            try
            {
                var contents = (from c in db.PhieuNhapThuoc
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

        public void Create(PhieuNhapThuoc _object)
        {
            try
            {
                _object.NgayNhap = System.DateTime.Now;
                db.PhieuNhapThuoc.Add(_object);
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
                var _object = (from _list in db.PhieuNhapThuoc where _list.ID == id select _list).First();
                db.PhieuNhapThuoc.Remove(_object);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

        public void Save(PhieuNhapThuoc _object)
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
