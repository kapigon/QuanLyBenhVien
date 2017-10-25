using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Repository
{
    public partial class CT_Thuoc_PhieuNhapRepository
    {
        QLBV_DEV.Helpers.ErrorHandle myError = new QLBV_DEV.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<CT_Thuoc_PhieuNhap> GetAll()
        {
            return from _object in db.CT_Thuoc_PhieuNhap orderby _object.ID ascending select _object;
        }

        public IQueryable<CT_Thuoc_PhieuNhap> GetAllByPhieuNhapThuoc_ID(long ID)
        {
            return from _object in db.CT_Thuoc_PhieuNhap where _object.PhieuNhapHang_ID == ID orderby _object.PhieuNhapHang_ID ascending select _object;
        }

        public CT_Thuoc_PhieuNhap GetSingle(long id)
        {
            return (from _object in db.CT_Thuoc_PhieuNhap where _object.ID == id select _object).FirstOrDefault();
        }
               
        public List<CT_Thuoc_PhieuNhap> GetAll(int take, int pageSize, ref int count)
        {
            try
            {
                var contents = (from c in db.CT_Thuoc_PhieuNhap
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

        public void Create(CT_Thuoc_PhieuNhap _object)
        {
            try
            {
                _object.NgayNhap = System.DateTime.Now;
                db.CT_Thuoc_PhieuNhap.Add(_object);
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
                var _object = (from _list in db.CT_Thuoc_PhieuNhap where _list.ID == id select _list).First();
                db.CT_Thuoc_PhieuNhap.Remove(_object);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

        public void Save(CT_Thuoc_PhieuNhap _object)
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
