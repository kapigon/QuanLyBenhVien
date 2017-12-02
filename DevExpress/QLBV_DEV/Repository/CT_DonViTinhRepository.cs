using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Repository
{    
    public partial class CT_DonViTinhRepository
    {
        QLBV_DEV.Helpers.ErrorHandle myError = new QLBV_DEV.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<CT_DonViTinh> GetAll()
        {
            return from _object in db.CT_DonViTinh orderby _object.ID ascending select _object;
        }

        public IQueryable<CT_DonViTinh> GetAll(long thuoc_ID)
        {
            return from _object in db.CT_DonViTinh where _object.Thuoc_ID == thuoc_ID orderby _object.QuyDoi ascending select _object;
        }


        public IQueryable<dynamic> GetAllByThuocID(long thuoc_ID)
        {
            return from _object in db.CT_DonViTinh
                   join dvt in db.DonViTinh on _object.DVT_ID equals dvt.ID
                   where _object.Thuoc_ID == thuoc_ID
                   orderby _object.QuyDoi ascending
                   select new
                   {
                       ID           = _object.ID,
                       Thuoc_ID     = _object.Thuoc_ID,
                       DVT_ID       = _object.DVT_ID,
                       TenDVT       = dvt.TenDVT,
                       QuyDoi       = _object.QuyDoi,
                       DVTQuyChuan  = _object.DVTQuyChuan,
                       KichHoat     = _object.KichHoat
                   };
        }

        public CT_DonViTinh GetSingle(long thuoc_ID, long ct_dvt_ID)
        {
            return (from _object in db.CT_DonViTinh where (_object.Thuoc_ID == thuoc_ID && _object.DVT_ID == ct_dvt_ID) select _object).FirstOrDefault();
        }

        public long GetCount()
        {
            return (from _object in db.CT_DonViTinh select _object).Count();
        }

        public double GetQuyChuan(long thuocID)
        {
            var quychuan = (from ct_dvt in db.CT_DonViTinh.Where(p => p.DVTQuyChuan == true && p.Thuoc_ID == thuocID).DefaultIfEmpty()
                                         select ct_dvt).FirstOrDefault().QuyDoi.Value;

            return quychuan != 0 ? quychuan : 1;
        }

        public double GetQuyDoi(long thuocID, int DVT)
        {
            var quydoi = (from ct_dvt in db.CT_DonViTinh.Where(p => p.DVT_ID == DVT && p.Thuoc_ID == thuocID).DefaultIfEmpty()
                                     select ct_dvt).FirstOrDefault().QuyDoi.Value;

            return quydoi != 0 ? quydoi : 1;
        }

        /*
         * Owner        : hoalp
         * Created      : 30/11/2017
         * thuocID      : Thuốc ID
         * DVT_Xuat     : đơn vị tính theo CT_Thuoc_PhieuXuat
         * type         : <T : Thuận - N : Ngược>
         */
        public double GetHeSoTheoQuyChuan(long thuocID, int DVT_Nhap, char type)
        {
            double quychuan = GetQuyChuan(thuocID);

            double quydoi   = GetQuyDoi(thuocID, DVT_Nhap);

            quychuan    = quychuan != 0 ? quydoi : 1;

            quydoi      = quydoi != 0 ? quydoi : 1;

            if (type == 'N')
                return quydoi / quychuan;
            else
                return quychuan / quydoi;
        } 

        public CT_DonViTinh GetSingle(long id)
        {
            return (from _object in db.CT_DonViTinh where _object.ID == id select _object).FirstOrDefault();
        }
                                
        public List<CT_DonViTinh> GetAll(int take, int pageSize, ref int count)
        {
            try
            {
                var contents = (from c in db.CT_DonViTinh
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

        public void Create(CT_DonViTinh _object)
        {
            try
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.CT_DonViTinh.Add(_object);
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
                        var _object = (from _list in db.CT_DonViTinh where _list.ID == id select _list).First();
                        db.CT_DonViTinh.Remove(_object);
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

        public void Save(CT_DonViTinh _object)
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
