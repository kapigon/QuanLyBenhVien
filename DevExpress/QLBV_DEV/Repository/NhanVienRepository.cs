﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Repository
{    
    public partial class NhanVienRepository
    {
        QLBV_DEV.Helpers.ErrorHandle myError = new QLBV_DEV.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<NhanVien> GetAll()
        {
            return from _object in db.NhanVien orderby _object.ID ascending select _object;
        }

        public IQueryable<NhanVien> GetAll(bool kichhoat)
        {
            return from _object in db.NhanVien where (_object.KichHoat == kichhoat) orderby _object.ID ascending select _object;
        }

        public NhanVien GetSingle(int id)
        {
            return (from _object in db.NhanVien where _object.ID == id select _object).FirstOrDefault();
        }

        public NhanVien GetSingle(string HoVaTen)
        {
            return (from c in db.NhanVien.AsEnumerable() where Helpers.StringClearFormat.ClearCharacterSpecial(c.HoVaTen) == HoVaTen select c).FirstOrDefault();
        }
        public List<NhanVien> GetAll(int take, int pageSize, ref int count)
        {
            try
            {
                var contents = (from c in db.NhanVien
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

        public void Create(NhanVien _object)
        {
            try
            {
                _object.NgayTao = System.DateTime.Now;
                db.NhanVien.Add(_object);
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
                var _object = (from _list in db.NhanVien where _list.ID == id select _list).First();
                db.NhanVien.Remove(_object);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

        public void Save(NhanVien _object)
        {
            try
            {
                //_object.EntityKey = (from NhanVien ac in db.NhanVien where ac.ID == _object.ID select ac).FirstOrDefault().EntityKey;
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