using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Repository
{    
    public partial class ThuocRepository
    {
        QLBV_DEV.Helpers.ErrorHandle myError = new QLBV_DEV.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<Thuoc> GetAll()
        {
            return from _object in db.Thuoc orderby _object.ID ascending select _object;
        }

        public IQueryable<Thuoc> GetAllS(int top)
        {
            return (from _object in db.Thuoc orderby _object.ID ascending select _object).Take(top);
        }

        public List<Thuoc> GetAll(int top)
        {
            return (from _object in db.Thuoc orderby _object.ID ascending select _object).Take(top).ToList();
        }

        public IQueryable<Thuoc> GetAll(bool kichhoat)
        {
            return from _object in db.Thuoc where (_object.KichHoat == kichhoat) orderby _object.ID ascending select _object;
        }

        public int getCountByMaThuoc(string search)
        {
            var query = from _object in db.Thuoc
                        where _object.MaThuoc.StartsWith(search)
                        orderby _object.ID ascending
                        select _object;

            return query.Count();
        }

        public Thuoc GetSingle(long id)
        {
            return (from _object in db.Thuoc where _object.ID == id select _object).FirstOrDefault();
        }

        public int GetCountTonKho(long id){

            var query = from _object in db.CT_Thuoc_PhieuNhap where _object.Thuoc_ID == id select _object;

            return query.Sum(x => x.TonKho).Value;
        }

        public Thuoc GetSingleByTenThuoc(string tenThuoc)
        {
            return (from c in db.Thuoc.AsEnumerable() where Helpers.StringClearFormat.ClearCharacterSpecial(c.TenThuoc) == tenThuoc select c).FirstOrDefault();
        }

        public Thuoc GetSingleByMaThuoc(string maThuoc)
        {
            return (from c in db.Thuoc.AsEnumerable() where Helpers.StringClearFormat.ClearCharacterSpecial(c.MaThuoc) == maThuoc select c).FirstOrDefault();
        }

        public List<Thuoc> GetAll(int take, int pageSize, ref int count)
        {
            try
            {
                var contents = (from c in db.Thuoc
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

        public void Create(Thuoc _object)
        {
            try
            {
                _object.NgayTao = System.DateTime.Now;
                db.Thuoc.Add(_object);
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
                var _object = (from _list in db.Thuoc where _list.ID == id select _list).First();
                db.Thuoc.Remove(_object);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

        public void Save(Thuoc _object)
        {
            try
            {
                //_object.EntityKey = (from Thuoc ac in db.Thuoc where ac.ID == _object.ID select ac).FirstOrDefault().EntityKey;
                //_object.NgayTao = System.DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

        public IQueryable<Thuoc> search(long thuoc_id, int nhomthuoc_ID, int hoatchat_ID, int hangsanxuat_Id, int nuocsanxuat_Id, bool kichhoat)
        {
            var query = from _object in db.Thuoc 
                        //join nt in db.NhomThuoc on _object.NhomThuoc_ID equals nt.ID
                        //join hc in db.HoatChat on _object.HoatChat_ID equals hc.ID
                        //join hsx in db.HangSanXuat on _object.HangSanXuat_ID equals hsx.ID
                        from hoatchat in db.HoatChat.Where(hc => hc.ID == _object.HoatChat_ID).DefaultIfEmpty()
                        from nhomthuoc in db.NhomThuoc.Where(nt => nt.ID == _object.NhomThuoc_ID).DefaultIfEmpty()
                        from hangsanxuat in db.HangSanXuat.Where(hsx => hsx.ID == _object.HangSanXuat_ID).DefaultIfEmpty()
                        from nuocsanxuat in db.NuocSanXuat.Where(nsx => nsx.ID == _object.HangSanXuat_ID).DefaultIfEmpty()
                        select _object;

            if (thuoc_id > 0)
                query = query.Where(p =>p.ID == thuoc_id);

            //if (tenthuoc != "")
            //    query = query.Where(p => p.TenThuoc.Equals(tenthuoc));

            if (nhomthuoc_ID > 0)
                query = query.Where(p => p.NhomThuoc_ID == nhomthuoc_ID);

            if (hoatchat_ID > 0)
                query = query.Where(p => p.HoatChat_ID == hoatchat_ID);

            if (hangsanxuat_Id > 0)
                query = query.Where(p => p.HangSanXuat_ID == hangsanxuat_Id);

            if (nuocsanxuat_Id > 0)
                query = query.Where(p => p.NuocSanXuat_ID == nuocsanxuat_Id);
                query = query.Where(p => p.KichHoat == kichhoat);

            return query;

        }

    }
}
