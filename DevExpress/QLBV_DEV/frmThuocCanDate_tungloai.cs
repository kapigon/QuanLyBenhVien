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
using DevExpress.XtraGrid.Views.Grid;

namespace QLBV_DEV
{
    public partial class frmThuocCanDate_tungloai : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities db = new HospitalEntities();
        ThuocRepository                 rpo_Thuoc           = new ThuocRepository();
        CT_Thuoc_PhieuNhapRepository    rpo_CT_PhieuNhap    = new CT_Thuoc_PhieuNhapRepository();
        #endregion

        public frmThuocCanDate_tungloai()
        {
            InitializeComponent();
            LoadDS_ThuocCanDate();
            gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
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


            try
            {
                //Lấy thuốc theo thời gian cảnh báo
                var query = rpo_CT_PhieuNhap.ThuocCanDate();
                grvThuocCanDate_tungloai.DataSource = query.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }

        #region Sothutu
        //Tạo số thứ tự tăng tự động cho 1 gridView. Dùng cho cả trường hợp group.
        //Thêm dòng sau vào dưới InitializeComponent():
        //gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator; 
        //Sử dụng thư viện:
        //using DevExpress.XtraGrid.Views.Grid;

        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!gridView1.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
            {
                if (e.Info.IsRowIndicator) //Nếu là dòng Indicator
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1; //Không hiển thị hình
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); //Số thứ tự tăng dần
                    }
                    SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước của vùng hiển thị Text
                    Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); }));
            }

        }
        #endregion
    }

}