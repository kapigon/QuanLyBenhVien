using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Repository
{
    public partial class CT_Thuoc_PhieuNhapRepository
    {
        QLBV_DEV.Helpers.ErrorHandle myError = new QLBV_DEV.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<CT_Thuoc_PhieuNhap> GetAll()
        {
            return from _object in db.CT_Thuoc_PhieuNhap orderby _object.ID ascending select _object;
        }

        public IQueryable<CT_Thuoc_PhieuNhap> GetAllByPhieuNhapThuoc_ID(long ID)
        {
            return from _object in db.CT_Thuoc_PhieuNhap where _object.PhieuNhapHang_ID == ID orderby _object.PhieuNhapHang_ID ascending select _object;
        }

        public CT_Thuoc_PhieuNhap GetSingle(long id)
        {
            return (from _object in db.CT_Thuoc_PhieuNhap where _object.ID == id select _object).FirstOrDefault();
        }
               
        public List<CT_Thuoc_PhieuNhap> GetAll(int take, int pageSize, ref int count)
        {
            try
            {
                var contents = (from c in db.CT_Thuoc_PhieuNhap
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

        public void Create(CT_Thuoc_PhieuNhap _object)
        {
            try
            {
                _object.NgayNhap = System.DateTime.Now;
                db.CT_Thuoc_PhieuNhap.Add(_object);
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
                var _object = (from _list in db.CT_Thuoc_PhieuNhap where _list.ID == id select _list).First();
                db.CT_Thuoc_PhieuNhap.Remove(_object);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

        public void Save(CT_Thuoc_PhieuNhap _object)
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


        public IQueryable<dynamic> search(long thuoc_Id, int nhomthuoc_Id, int hangsanxuat_Id, int khohang_Id,
                                           string solo, int hoatchat_Id, int nuocsanxuat_Id, int vitri_Id)
        {
            var query = from _object in db.CT_Thuoc_PhieuNhap
                        //join nt in db.NhomThuoc on _object.NhomThuoc_ID equals nt.ID
                        //join hc in db.HoatChat on _object.HoatChat_ID equals hc.ID
                        //join hsx in db.HangSanXuat on _object.HangSanXuat_ID equals hsx.ID
                        from thuoc in db.Thuoc.Where(t => t.ID == _object.Thuoc_ID).DefaultIfEmpty()
                        from nhomthuoc in db.NhomThuoc.Where(nt => nt.ID == thuoc.NhomThuoc_ID).DefaultIfEmpty()
                        from hangsanxuat in db.HangSanXuat.Where(hsx => hsx.ID == thuoc.HangSanXuat_ID).DefaultIfEmpty()
                        from khohang in db.Kho.Where(kh => kh.ID == _object.Kho_ID).DefaultIfEmpty()
                        from vitri in db.ViTri.Where(vt => vt.ID == _object.ViTri_ID).DefaultIfEmpty()
                        from hoatchat in db.HoatChat.Where(hc => hc.ID == thuoc.HoatChat_ID).DefaultIfEmpty()
                        from nuocsanxuat in db.NuocSanXuat.Where(nsx => nsx.ID == thuoc.NuocSanXuat_ID).DefaultIfEmpty()


                        select new
                        {
                            ID = _object.ID,
                            ThuocID = thuoc.ID,
                            MaThuoc = thuoc.MaThuoc,
                            TenThuoc = thuoc.TenThuoc,

                            SoLo = _object.SoLo,
                            DVT = thuoc.DVT_Le_ID,
                            HSD = _object.HSD,
                            TonKho = _object.TonKho,

                            TenNhom = nhomthuoc.TenNhom,
                            NhomThuoc_ID = nhomthuoc.ID,

                            TenHangSX = hangsanxuat.TenHangSX,
                            HangSX_Id = hangsanxuat.ID,

                            //TenNuocSX = nuocsanxuat.TenNuoc,
                            //NuocSX_Id = nuocsanxuat.ID,

                            TenHoatChat = hoatchat.TenHoatChat,
                            hoatchat_Id = hoatchat.ID,

                            KhoHang_Id = khohang.ID,
                            KhoHang = khohang.TenKho,

                            ViTri_Id = _object.ViTri_ID,
                            ViTri = vitri.TenViTri

                        };

            //if (thuoc_Id > 0)
            //    query = query.Where(p => p.ThuocID == thuoc_Id);

            //if (nhomthuoc_Id > 0)
            //    query = query.Where(p => p.NhomThuoc_ID == nhomthuoc_Id);

            //if (hangsanxuat_Id > 0)
            //    query = query.Where(p => p.HangSX_Id == hangsanxuat_Id);

            //if (khohang_Id > 0)
            //    query = query.Where(p => p.KhoHang_Id == khohang_Id);

            //if (solo != "")
            //    query = query.Where(p => p.SoLo.Contains(solo));

            //if (hoatchat_Id > 0)
            //    query = query.Where(p => p.hoatchat_Id == hoatchat_Id);

            //if (nuocsanxuat_Id > 0)
            //    query = query.Where(p => p.NuocSX_Id == nuocsanxuat_Id);

            //if (vitri_Id > 0)
            //    query = query.Where(p => p.ViTri_Id == vitri_Id);

            return query;

        }


    }
}
