﻿//------------------------------------------------------------------------------
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
    
    public partial class CT_Thuoc_PhieuXuat
    {
        public long ID { get; set; }
        public Nullable<long> PhieuXuatHang_ID { get; set; }
        public Nullable<long> CT_Thuoc_PhieuNhap_ID { get; set; }
        public Nullable<int> DVT_Theo_DVT_Thuoc_ID { get; set; }
        public Nullable<int> LoaiHinhBan_ID { get; set; }
        public Nullable<double> GiaBan { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> TongTien { get; set; }
        public string GhiChu { get; set; }
        public Nullable<int> UserTao { get; set; }
        public Nullable<System.DateTime> NgayBan {get; set; }

        /// <summary>
        ///  Thêm các trường tưởng ứng bên CT_Thuoc_PhieuNhap : để hiển thị lên GridControl
        /// </summary>
        public Nullable<System.DateTime> HSD { get; set; }
        public Nullable<int> TonKho { get; set; }
    }
}
