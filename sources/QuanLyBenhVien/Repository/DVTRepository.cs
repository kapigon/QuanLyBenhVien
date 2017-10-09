using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyBenhVien.Repository
{    
    public partial class DVTRepository
    {
        QuanLyBenhVien.Helpers.ErrorHandle myError = new QuanLyBenhVien.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<DonViTinh> GetAll()
        {
            return from _object in db.DonViTinhs orderby _object.ID ascending select _object;
        }
        
        public DonViTinh GetSingle(int id)
        {
            return (from _object in db.DonViTinhs where _object.ID == id select _object).FirstOrDefault();
        }

        public DonViTinh GetSingle(string TenDVT)
        {
            return (from c in db.DonViTinhs.AsEnumerable() where Helpers.StringClearFormat.ClearCharacterSpecial(c.TenDVT) == TenDVT select c).FirstOrDefault();
        }
        public List<DonViTinh> GetAll(int take, int pageSize, ref int count)
        {
            try
            {
                var contents = (from c in db.DonViTinhs
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

        public void Create(DonViTinh _object)
        {
            try
            {
                db.DonViTinhs.Add(_object);
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
                var _object = (from _list in db.DonViTinhs where _list.ID == id select _list).First();
                db.DonViTinhs.Remove(_object);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

        public void Save(DonViTinh _object)
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
