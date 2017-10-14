using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Repository
{    
    public partial class HoatChatRepository
    {
        QLBV_DEV.Helpers.ErrorHandle myError = new QLBV_DEV.Helpers.ErrorHandle();
        HospitalEntities db = new HospitalEntities();

        public IQueryable<HoatChat> GetAll()
        {
            return from _object in db.HoatChat orderby _object.ID ascending select _object;
        }

        public IQueryable<HoatChat> GetAll(bool kichhoat)
        {
            return from _object in db.HoatChat orderby _object.ID ascending select _object;
        }

        public HoatChat GetSingle(int id)
        {
            return (from _object in db.HoatChat where _object.ID == id select _object).FirstOrDefault();
        }

        public HoatChat GetSingle(string TenHoatChat)
        {
            return (from c in db.HoatChat.AsEnumerable() where Helpers.StringClearFormat.ClearCharacterSpecial(c.TenHoatChat) == TenHoatChat select c).FirstOrDefault();
        }
        public List<HoatChat> GetAll(int take, int pageSize, ref int count)
        {
            try
            {
                var contents = (from c in db.HoatChat
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

        public void Create(HoatChat _object)
        {
            try
            {
                db.HoatChat.Add(_object);
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
                var _object = (from _list in db.HoatChat where _list.ID == id select _list).First();
                db.HoatChat.Remove(_object);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                myError.AddError(ex.Message);
            }
        }

        public void Save(HoatChat _object)
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
