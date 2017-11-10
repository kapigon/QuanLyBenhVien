using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Repository
{    
    public partial class NCC_KHRepository
    {
        QLBV_DEV.Helpers.ErrorHandle myError = new QLBV_DEV.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<NCC_KH> GetAll()
        {
            return from _object in db.NCC_KH orderby _object.ID ascending select _object;
        }

        public IQueryable<NCC_KH> GetAll(bool kichhoat)
        {
            return from _object in db.NCC_KH where (_object.KichHoat == kichhoat) orderby _object.ID ascending select _object;
        }

        // type: 1-lấy ra 1 kiểu; 2 lấy ra 2 kiểu
        public IQueryable<NCC_KH> GetAllByType(int loai_ID, int type)
        {
            if (type == 1)
                return from _object in db.NCC_KH where (_object.KichHoat == true && _object.LoaiNCC_KH_ID == loai_ID) orderby _object.ID ascending select _object;
            else
                return from _object in db.NCC_KH where (_object.KichHoat == true && (_object.LoaiNCC_KH_ID == loai_ID || _object.LoaiNCC_KH_ID == 3)) orderby _object.ID ascending select _object;
        }

        public IQueryable<dynamic> GetLoaiNCC_KH()
        {
            return (from ncc in db.LoaiNCC_KH
                    select new
                    {
                        ID = ncc.ID,
                        LoaiNCC_KH = ncc.TenLoaiNCC_KH
                    });
        }
        public IQueryable<NCC_KH> search(String maNCC_KH, int loai_CCC_KH, String tenNCC_KH)
        {
            var query = from _object in db.NCC_KH select _object;

            if (maNCC_KH != "")
                query = query.Where(p => p.MaNCC_KH.StartsWith(maNCC_KH));

            if (loai_CCC_KH > 0)
                query = query.Where(p => p.LoaiNCC_KH_ID == loai_CCC_KH);

            if (tenNCC_KH != "")
                query = query.Where(p => p.TenNCC_KH.Contains(tenNCC_KH));

            return query;
        }

        public IQueryable<dynamic> DS_NCC_KH()
        {
            return (from ncc_kh in db.NCC_KH
                    join loaiNCC_KH in db.LoaiNCC_KH on ncc_kh.LoaiNCC_KH_ID equals loaiNCC_KH.ID
                    orderby ncc_kh.ID descending
                    select new
                    {
                        ID = ncc_kh.ID,
                        MaNCC_KH = ncc_kh.MaNCC_KH,
                        TenNCC_KH = ncc_kh.TenNCC_KH,
                        LoaiNCC_KH_ID = loaiNCC_KH.TenLoaiNCC_KH,
                        DiaChi = ncc_kh.DiaChi,
                        SDT = ncc_kh.DienThoai,
                        MST = ncc_kh.MST,
                        KichHoat = ncc_kh.KichHoat
                    });
        }
        public NCC_KH GetSingle(int id)
        {
            return (from _object in db.NCC_KH where _object.ID == id select _object).FirstOrDefault();
        }

        public NCC_KH GetSingle(string tenNCC_KH)
        {
            return (from c in db.NCC_KH.AsEnumerable() where Helpers.StringClearFormat.ClearCharacterSpecial(c.TenNCC_KH) == tenNCC_KH select c).FirstOrDefault();
        }
        public List<NCC_KH> GetAll(int take, int pageSize, ref int count)
        {
            try
            {
                var contents = (from c in db.NCC_KH
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

        public void Create(NCC_KH _object)
        {
            try
            {
                _object.NgayTao = System.DateTime.Now;
                db.NCC_KH.Add(_object);
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
                var _object = (from _list in db.NCC_KH where _list.ID == id select _list).First();
                db.NCC_KH.Remove(_object);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

        public void Save(NCC_KH _object)
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

    }
}
