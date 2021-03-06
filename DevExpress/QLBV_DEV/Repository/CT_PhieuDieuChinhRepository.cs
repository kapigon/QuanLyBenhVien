﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Repository
{    
    public partial class CT_PhieuDieuChinhRepository
    {
        QLBV_DEV.Helpers.ErrorHandle myError = new QLBV_DEV.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<CT_PhieuDieuChinh> GetAll()
        {
            return from _object in db.CT_PhieuDieuChinh orderby _object.ID ascending select _object;
        }

        public IQueryable<CT_PhieuDieuChinh> GetAll(long phieudieuchinh_ID)
        {
            return from _object in db.CT_PhieuDieuChinh where _object.PhieuDieuChinh_ID == phieudieuchinh_ID orderby _object.ID ascending select _object;
        }

        public long GetCount()
        {
            return (from _object in db.CT_PhieuDieuChinh select _object).Count();
        } 

        public CT_PhieuDieuChinh GetSingle(long id)
        {
            return (from _object in db.CT_PhieuDieuChinh where _object.ID == id select _object).FirstOrDefault();
        }

        public IQueryable<dynamic> GetAllByPhieuDieuChinhID(long id)
        {
            return from _object in db.CT_PhieuDieuChinh
                   join ct_phieunhap in db.CT_Thuoc_PhieuNhap on _object.CT_Thuoc_PhieuNhap_ID equals ct_phieunhap.ID
                   join thuoc in db.Thuoc on ct_phieunhap.Thuoc_ID equals thuoc.ID
                   where _object.PhieuDieuChinh_ID == id
                   orderby _object.ID ascending
                   select new { 
                       _object.SoLuongKiemKe,
                       _object.TonSoSach,
                       _object.SoLuongTang,
                       _object.SoLuongGiam,
                       _object.GhiChu,
                       thuoc.MaThuoc,
                       thuoc.TenThuoc
                   };
        }   
                   
        public List<CT_PhieuDieuChinh> GetAll(int take, int pageSize, ref int count)
        {
            try
            {
                var contents = (from c in db.CT_PhieuDieuChinh
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

        public void Create(CT_PhieuDieuChinh _object)
        {
            try
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.CT_PhieuDieuChinh.Add(_object);
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
                        var _object = (from _list in db.CT_PhieuDieuChinh where _list.ID == id select _list).First();
                        db.CT_PhieuDieuChinh.Remove(_object);
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

        public void Save(CT_PhieuDieuChinh _object)
        {
            try
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        //_object.EntityKey = (from CT_PhieuDieuChinh ac in db.CT_PhieuDieuChinh where ac.ID == _object.ID select ac).FirstOrDefault().EntityKey;
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
