using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Repository
{    
    public partial class ViTriRepository
    {
        QLBV_DEV.Helpers.ErrorHandle myError = new QLBV_DEV.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<ViTri> GetAll()
        {
            return from _object in db.ViTri orderby _object.ID ascending select _object;
        }

        public IQueryable<ViTri> GetAll(bool kichhoat)
        {
            return from _object in db.ViTri orderby _object.ID ascending select _object;
        }

        public ViTri GetSingle(int id)
        {
            return (from _object in db.ViTri where _object.ID == id select _object).FirstOrDefault();
        }

        public ViTri GetSingle(string TenViTri)
        {
            return (from c in db.ViTri.AsEnumerable() where Helpers.StringClearFormat.ClearCharacterSpecial(c.TenViTri) == TenViTri select c).FirstOrDefault();
        }
        public List<ViTri> GetAll(int take, int pageSize, ref int count)
        {
            try
            {
                var contents = (from c in db.ViTri
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

        public void Create(ViTri _object)
        {
            try
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try{
                        db.ViTri.Add(_object);
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
                        var _object = (from _list in db.ViTri where _list.ID == id select _list).First();
                        db.ViTri.Remove(_object);
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

        public void Save(ViTri _object)
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
