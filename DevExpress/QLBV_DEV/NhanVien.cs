//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLBV_DEV
{
    using System;
    using System.Collections.Generic;
    
    public partial class NhanVien
    {
        public long ID { get; set; }
        public Nullable<int> Khoa_ID { get; set; }
        public Nullable<int> PhanQuyen_ID { get; set; }
        public string HoVaTen { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public Nullable<bool> GioiTinh { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string CMT { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public Nullable<bool> KichHoat { get; set; }
    }
}
