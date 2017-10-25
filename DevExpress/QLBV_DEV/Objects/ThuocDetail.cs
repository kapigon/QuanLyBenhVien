using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_DEV.Objects
{
    class ThuocDetail
    {
        public string Barcode { get; set; }
        public string MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public string TenDVT { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> GiaBanLe { get; set; }
        public Nullable<double> GiaBanBuon { get; set; }
        public Nullable<double> ChietKhau { get; set; }
        public Nullable<double> TongTienTruocThue { get; set; }
        public Nullable<double> ChietKhau { get; set; }
        public Nullable<double> TongTienTra { get; set; }
        public Nullable<int> TonKho { get; set; }
        public Nullable<int> ThoiGianCanhBaoHetHan { get; set; }
        public Nullable<int> TonKhoToiThieu { get; set; }
    }
}
