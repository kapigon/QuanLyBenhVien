using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBV_DEV.Repository;
using System.Data.Entity;

namespace QLBV_DEV
{
    public partial class frmThuoCanDate_tungloai : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities db = new HospitalEntities();
        ThuocRepository rpo_Thuoc = new ThuocRepository();
        #endregion

        public frmThuoCanDate_tungloai()
        {
            InitializeComponent();
            LoadDS_ThuocCanDate();
        }

        private void LoadDS_ThuocCanDate()
        {
            //DateTime thoigiantoi = DateTime.Now;
            //int songaydemlui = 0;
            //if (txtSoNgay.Text != "" && Convert.ToInt32(txtSoNgay.Text) > 0)
            //{
            //    songaydemlui = Convert.ToInt32(txtSoNgay.Text);
            //    thoigiantoi = thoigiantoi.AddDays(songaydemlui);
            //}

            ////lấy ra thuốc trong số ngày nhập vào hết hạn
            //var query = from thuoc_phieunhap in db.CT_Thuoc_PhieuNhap
            //            join thuoc in db.Thuoc on thuoc_phieunhap.Thuoc_ID equals thuoc.ID
            //            where DateTime.Now <= thuoc_phieunhap.HSD && thuoc_phieunhap.HSD <= thoigiantoi
            //            select new
            //            {
            //                Id = thuoc_phieunhap.Thuoc_ID,
            //                TenThuoc = thuoc.TenThuoc,
            //                Mathuoc = thuoc.MaThuoc,
            //                HSD = thuoc_phieunhap.HSD
            //            };


            //Lấy thuốc theo thời gian cảnh báo
            var query = from thuoc_phieunhap in db.CT_Thuoc_PhieuNhap
                        join thuoc in db.Thuoc on thuoc_phieunhap.Thuoc_ID equals thuoc.ID
                        //where DateTime.Now >= Convert.ToDateTime(thuoc_phieunhap.HSD).AddDays(Convert.ToInt32(thuoc.ThoiGianCanhBaoHetHan) * -1)
                        //where DateTime.Now >= DbFunctions.AddDays(thuoc_phieunhap.HSD, -thuoc.ThoiGianCanhBaoHetHan)
                       // where Convert.ToInt32((thuoc_phieunhap.HSD.Value.Date-DateTime.Now.Date).TotalDays) > Convert.ToInt32( thuoc.ThoiGianCanhBaoHetHan.Value.ToString())
                        select new
                        {
                            Id = thuoc_phieunhap.Thuoc_ID,
                            TenThuoc = thuoc.TenThuoc,
                            Mathuoc = thuoc.MaThuoc,
                            canhbaohethan = thuoc.ThoiGianCanhBaoHetHan,
                            HSD = thuoc_phieunhap.HSD
                        };
            grvThuocCanDate_tungloai.DataSource = query.ToList();
        }


    }

}