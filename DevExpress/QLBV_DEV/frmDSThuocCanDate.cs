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
    public partial class frmDSThuocCanDate : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities db = new HospitalEntities();
        ThuocRepository rpo_Thuoc = new ThuocRepository();        
        #endregion

        public frmDSThuocCanDate()
        {
            InitializeComponent();
            lblKhoangNgay.Text = "";
            LoadDS_ThuocCanDate();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            //int ngay = Convert.ToInt32((DateTime.Now.Date-txtNgayKetThuc.DateTime.Date).TotalDays);
            
            //txtNgay.Text = ngay.ToString();
            LoadDS_ThuocCanDate();
        }
        private void LoadDS_ThuocCanDate()
        {            
            DateTime thoigiantoi = DateTime.Now;
            int songaydemlui = 0;
            if(txtSoNgay.Text != "" && Convert.ToInt32(txtSoNgay.Text) > 0){
                songaydemlui = Convert.ToInt32(txtSoNgay.Text);
                thoigiantoi = thoigiantoi.AddDays(songaydemlui);
            }
                
             //lấy ra thuốc trong số ngày nhập vào hết hạn
            var query = from thuoc_phieunhap in db.CT_Thuoc_PhieuNhap
                        join thuoc in db.Thuoc on thuoc_phieunhap.Thuoc_ID equals thuoc.ID
                        where DateTime.Now <= thuoc_phieunhap.HSD && thuoc_phieunhap.HSD <= thoigiantoi 
                        select new
                        {
                            Id          = thuoc_phieunhap.Thuoc_ID,
                            TenThuoc    = thuoc.TenThuoc,
                            Mathuoc     = thuoc.MaThuoc,
                            HSD         = thuoc_phieunhap.HSD
                        };


            //Lấy thuốc theo thời gian cảnh báo
                         //where Convert.ToInt32((thuoc_phieunhap.HSD.Value.Date - DateTime.Now.Date).TotalDays) > 2
            //var query = from thuoc_phieunhap in db.CT_Thuoc_PhieuNhap
            //            join thuoc in db.Thuoc on thuoc_phieunhap.Thuoc_ID equals thuoc.ID
            //            //where DateTime.Now >= Convert.ToDateTime(thuoc_phieunhap.HSD).AddDays(Convert.ToInt32(thuoc.ThoiGianCanhBaoHetHan) * -1)
            //            where DateTime.Now >= DbFunctions.AddDays(thuoc_phieunhap.HSD, -thuoc.ThoiGianCanhBaoHetHan)
            //           // where Convert.ToInt32((thuoc_phieunhap.HSD.Value.Date-DateTime.Now.Date).TotalDays) > Convert.ToInt32( thuoc.ThoiGianCanhBaoHetHan.Value.ToString())
            //            select new
            //            {
            //                Id = thuoc_phieunhap.Thuoc_ID,
            //                TenThuoc = thuoc.TenThuoc,
            //                Mathuoc = thuoc.MaThuoc,
            //                HSD = thuoc_phieunhap.HSD
            //            };
            grvHangCanDate.DataSource = query.ToList();
        }

        private void txtSoNgay_EditValueChanged(object sender, EventArgs e)
        {
            int khoangthoigian =  Convert.ToInt32(txtSoNgay.Text);
            DateTime tungay = DateTime.Now;
            DateTime denngay = tungay.AddDays(khoangthoigian);
            String str = "( Từ ngày " + tungay.ToString("dd/MM/yyyy") + " đến ngày " + denngay.ToString("dd/MM/yyyy")+ " )";
            lblKhoangNgay.Text = str;
            lblKhoangNgay.Font = new Font(lblKhoangNgay.Font, FontStyle.Italic);
        }
    }
}