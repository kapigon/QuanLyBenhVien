using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Repository
{    
    public partial class NuocSanXuatRepository
    {
        QLBV_DEV.Helpers.ErrorHandle myError = new QLBV_DEV.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<NuocSanXuat> GetAll()
        {
            return from _object in db.NuocSanXuat orderby _object.ID ascending select _object;
        }

        public IQueryable<NuocSanXuat> GetAll(bool kichhoat)
        {
            return from _object in db.NuocSanXuat orderby _object.ID ascending select _object;
        }

        public NuocSanXuat GetSingle(int id)
        {
            return (from _object in db.NuocSanXuat where _object.ID == id select _object).FirstOrDefault();
        }

        public NuocSanXuat GetSingle(string TenNuocSanXuat)
        {
            return (from c in db.NuocSanXuat.AsEnumerable() where Helpers.StringClearFormat.ClearCharacterSpecial(c.TenNuoc) == TenNuocSanXuat select c).FirstOrDefault();
        }
        public List<NuocSanXuat> GetAll(int take, int pageSize, ref int count)
        {
            try
            {
                var contents = (from c in db.NuocSanXuat
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

        public void Create(NuocSanXuat _object)
        {
            try
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.NuocSanXuat.Add(_object);
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
                        var _object = (from _list in db.NuocSanXuat where _list.ID == id select _list).First();
                        db.NuocSanXuat.Remove(_object);
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

        public void Save(NuocSanXuat _object)
        {
            try
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
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
