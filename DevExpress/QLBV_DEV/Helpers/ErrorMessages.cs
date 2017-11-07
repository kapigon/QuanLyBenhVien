using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLBV_DEV.Helpers
{
    public partial class ErrorMessages
    {
        public static int type;

        public static string show(int type)
        {
            switch (type)
            {
                case 1:
                    return "Lỗi kết nối mạng, Vui lòng kiểm tra lại...";
                case 2:
                    return "Danh sách trống, Vui lòng nhập dữ liệu...";
                default:
                    return "Hệ thống đang bị lỗi";
            }
        }
    }
}
