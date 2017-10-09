using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Repository
{    
    public partial class LoaiDonThuocRepository
    {
        QLBV_DEV.Helpers.ErrorHandle myError = new QLBV_DEV.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<LoaiDonThuoc> GetAll()
        {
            return from _object in db.LoaiDonThuoc orderby _object.ID ascending select _object;
        }

        public IQueryable<LoaiDonThuoc> GetAll(bool kichhoat)
        {
            return from _object in db.LoaiDonThuoc orderby _object.ID ascending select _object;
        }

        public LoaiDonThuoc GetSingle(int id)
        {
            return (from _object in db.LoaiDonThuoc where _object.ID == id select _object).FirstOrDefault();
        }

        public LoaiDonThuoc GetSingle(string TenLoaiDT)
        {
            return (from c in db.LoaiDonThuoc.AsEnumerable() where Helpers.StringClearFormat.ClearCharacterSpecial(c.TenDonThuoc) == TenLoaiDT select c).FirstOrDefault();
        }
        public List<LoaiDonThuoc> GetAll(int take, int pageSize, ref int count)
        {
            try
            {
                var contents = (from c in db.LoaiDonThuoc
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

        public void Create(LoaiDonThuoc _object)
        {
            try
            {
                db.LoaiDonThuoc.Add(_object);
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
                var _object = (from _list in db.LoaiDonThuoc where _list.ID == id select _list).First();
                db.LoaiDonThuoc.Remove(_object);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

        public void Save(LoaiDonThuoc _object)
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
