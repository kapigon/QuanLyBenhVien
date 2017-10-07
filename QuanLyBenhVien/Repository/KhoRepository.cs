using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyBenhVien.Repository
{    
    public partial class KhoRepository
    {
        QuanLyBenhVien.Helpers.ErrorHandle myError = new QuanLyBenhVien.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<Kho> GetAll()
        {
            return from _object in db.Kho orderby _object.ID ascending select _object;
        }

        public IQueryable<Kho> GetAll(bool kichhoat)
        {
            return from _object in db.Kho orderby _object.ID ascending select _object;
        }

        public Kho GetSingle(int id)
        {
            return (from _object in db.Kho where _object.ID == id select _object).FirstOrDefault();
        }

        public Kho GetSingle(string TenKho)
        {
            return (from c in db.Kho.AsEnumerable() where Helpers.StringClearFormat.ClearCharacterSpecial(c.TenKho) == TenKho select c).FirstOrDefault();
        }
        public List<Kho> GetAll(int take, int pageSize, ref int count)
        {
            try
            {
                var contents = (from c in db.Kho
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

        public void Create(Kho _object)
        {
            try
            {
                db.Kho.Add(_object);
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
                var _object = (from _list in db.Kho where _list.ID == id select _list).First();
                db.Kho.Remove(_object);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

        public void Save(Kho _object)
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
