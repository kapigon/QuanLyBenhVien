using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Repository
{    
    public partial class DVTRepository
    {
        QLBV_DEV.Helpers.ErrorHandle myError = new QLBV_DEV.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<DonViTinh> GetAll()
        {
            return from _object in db.DonViTinh orderby _object.ID ascending select _object;
        }
        
        public DonViTinh GetSingle(int id)
        {
            return (from _object in db.DonViTinh where _object.ID == id select _object).FirstOrDefault();
        }

        public DonViTinh GetSingle(string TenDVT)
        {
            return (from c in db.DonViTinh.AsEnumerable() where Helpers.StringClearFormat.ClearCharacterSpecial(c.TenDVT) == TenDVT select c).FirstOrDefault();
        }
        public List<DonViTinh> GetAll(int take, int pageSize, ref int count)
        {
            try
            {
                var contents = (from c in db.DonViTinh
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
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.DonViTinh.Add(_object);
                        db.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
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
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var _object = (from _list in db.DonViTinh where _list.ID == id select _list).First();
                        db.DonViTinh.Remove(_object);
                        db.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
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
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        //_object.NgayTao = System.DateTime.Now;
                        db.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

    }
}
