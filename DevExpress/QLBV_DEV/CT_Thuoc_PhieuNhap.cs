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
    
    public partial class CT_Thuoc_PhieuNhap
    {
        public long ID { get; set; }
        public Nullable<long> PhieuNhapHang_ID { get; set; }
        public Nullable<int> DVT_Theo_DVT_Thuoc_ID { get; set; }
        public Nullable<long> Thuoc_ID { get; set; }
        public Nullable<int> Kho_ID { get; set; }
        public Nullable<int> ViTri_ID { get; set; }
        public string Barcode { get; set; }
        public Nullable<System.DateTime> HSD { get; set; }
        public Nullable<double> GiaNhap { get; set; }
        public Nullable<double> SoLuong { get; set; }
        public string SoLo { get; set; }
        public Nullable<double> TongTien { get; set; }
        public Nullable<System.DateTime> NgayNhap { get; set; }
        public Nullable<int> UserTao { get; set; }
        public Nullable<bool> Xoa { get; set; }
        public Nullable<System.DateTime> NgayXoa { get; set; }
        public Nullable<double> TonKho { get; set; }
        public Nullable<double> ThueSuat { get; set; }
    }
}
