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
using DevExpress.XtraGrid.Views.Grid;

namespace QLBV_DEV
{
    public partial class frmTonKhoToiThieu : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities db = new HospitalEntities();
        ThuocRepository rpo_Thuoc = new ThuocRepository();
        #endregion
        public frmTonKhoToiThieu()
        {
            InitializeComponent();
            LoadDS_TonKhoToiThieu();
            gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator; 
        }

        private void LoadDS_TonKhoToiThieu()
        {
            try
            {
                var query = from thuoc in db.Thuoc
                            join nhomthuoc in db.NhomThuoc on thuoc.NhomThuoc_ID equals nhomthuoc.ID
                            // join hangsanxuat in db.HangSanXuat on thuoc.HangSanXuat_ID equals hangsanxuat.ID                      
                            where thuoc.TonKho < thuoc.TonKhoToiThieu

                            select new
                            {
                                Id = thuoc.ID,
                                MaThuoc = thuoc.MaThuoc,
                                TenThuoc = thuoc.TenThuoc,

                                TonKho = thuoc.TonKho,
                                TonKhoToiThieu = thuoc.TonKhoToiThieu,
                                // HangSanXuat = hangsanxuat.TenHangSX,
                                NhomThuoc = nhomthuoc.TenNhom
                            };
                grvTonKhoToiThieu.DataSource = query.ToList();
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