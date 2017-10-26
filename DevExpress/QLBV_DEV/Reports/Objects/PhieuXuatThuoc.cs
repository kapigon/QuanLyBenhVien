using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Reports.Objects
{
    public partial class oPhieuXuatThuoc
    {
        public string Barcode { get; set; }
        public string MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public string DVT { get; set; }
        public Nullable<double> GiaBan { get; set; }
        public Nullable<double> GiaBanLe { get; set; }
        public Nullable<double> GiaBanBuon { get; set; }
        public Nullable<double> ThanhTien { get; set; }
        public Nullable<double> QuyCach { get; set; }
        public Nullable<int> TonKho { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<int> TonKhoToiThieu { get; set; }
        public Nullable<System.DateTime> HSD { get; set; }
    }
}
