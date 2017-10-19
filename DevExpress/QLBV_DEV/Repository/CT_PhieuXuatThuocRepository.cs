using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Repository
{
    public partial class CT_Thuoc_PhieuXuatRepository
    {
        QLBV_DEV.Helpers.ErrorHandle myError = new QLBV_DEV.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<CT_Thuoc_PhieuXuat> GetAll()
        {
            return from _object in db.CT_Thuoc_PhieuXuat orderby _object.ID ascending select _object;
        }

        public IQueryable<CT_Thuoc_PhieuXuat> GetAllByPhieuXuatThuoc_ID(long ID)
        {
            return from _object in db.CT_Thuoc_PhieuXuat where _object.PhieuXuatHang_ID == ID orderby _object.PhieuXuatHang_ID ascending select _object;
        }

        public CT_Thuoc_PhieuXuat GetSingle(long id)
        {
            return (from _object in db.CT_Thuoc_PhieuXuat where _object.ID == id select _object).FirstOrDefault();
        }
               
        public List<CT_Thuoc_PhieuXuat> GetAll(int take, int pageSize, ref int count)
        {
            try
            {
                var contents = (from c in db.CT_Thuoc_PhieuXuat
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

        public void Create(CT_Thuoc_PhieuXuat _object)
        {
            try
            {
                _object.NgayBan = System.DateTime.Now;
                db.CT_Thuoc_PhieuXuat.Add(_object);
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
                var _object = (from _list in db.CT_Thuoc_PhieuXuat where _list.ID == id select _list).First();
                db.CT_Thuoc_PhieuXuat.Remove(_object);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

        public void Save(CT_Thuoc_PhieuXuat _object)
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
