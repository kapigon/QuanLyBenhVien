using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Repository
{    
    public partial class LoaiHinhBanRepository
    {
        QLBV_DEV.Helpers.ErrorHandle myError = new QLBV_DEV.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<LoaiHinhBan> GetAll()
        {
            return from _object in db.LoaiHinhBan orderby _object.ID ascending select _object;
        }

        public IQueryable<LoaiHinhBan> GetAll(bool kichhoat)
        {
            return from _object in db.LoaiHinhBan orderby _object.ID ascending select _object;
        }

        public LoaiHinhBan GetSingle(int id)
        {
            return (from _object in db.LoaiHinhBan where _object.ID == id select _object).FirstOrDefault();
        }

        public LoaiHinhBan GetSingle(string TenLoaiDT)
        {
            return (from c in db.LoaiHinhBan.AsEnumerable() where Helpers.StringClearFormat.ClearCharacterSpecial(c.TenLoaiHinhBan) == TenLoaiDT select c).FirstOrDefault();
        }
        public List<LoaiHinhBan> GetAll(int take, int pageSize, ref int count)
        {
            try
            {
                var contents = (from c in db.LoaiHinhBan
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

        public void Create(LoaiHinhBan _object)
        {
            try
            {
                db.LoaiHinhBan.Add(_object);
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
                var _object = (from _list in db.LoaiHinhBan where _list.ID == id select _list).First();
                db.LoaiHinhBan.Remove(_object);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

        public void Save(LoaiHinhBan _object)
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
