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
    
    public partial class CT_PhieuDieuChinh
    {
        public long ID { get; set; }
        public Nullable<long> PhieuDieuChinh_ID { get; set; }
        public Nullable<long> CT_Thuoc_PhieuNhap_ID { get; set; }
        public string GhiChu { get; set; }
        public Nullable<int> SoLuongKiemKe { get; set; }
        public Nullable<int> TonSoSach { get; set; }
        public Nullable<int> SoLuongTang { get; set; }
        public Nullable<int> SoLuongGiam { get; set; }
        public Nullable<int> LoaiDieuChinh { get; set; }
        public Nullable<bool> Huy { get; set; }
        public Nullable<int> UserHuy { get; set; }
    }
}