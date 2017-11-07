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
    public partial class frmCanhbaotrangchu : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities db = new HospitalEntities();
        ThuocRepository rpo_Thuoc = new ThuocRepository();
        #endregion

        public frmCanhbaotrangchu()
        {
            InitializeComponent();
            gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
            gridView2.CustomDrawRowIndicator += gridView2_CustomDrawRowIndicator;
            gridView3.CustomDrawRowIndicator += gridView3_CustomDrawRowIndicator;
            gridView4.CustomDrawRowIndicator += gridView4_CustomDrawRowIndicator;

            try
            {
                LoadDS_ThuocCanDate();
                LoadDS_TonKhoToiThieu();
                LoadDS_PhieuXuat();
                LoadDS_PhieuNhap();
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }

        private void LoadDS_ThuocCanDate()
        {
            var query = from thuoc_phieunhap in db.CT_Thuoc_PhieuNhap
                        join thuoc in db.Thuoc on thuoc_phieunhap.Thuoc_ID equals thuoc.ID
                        where DateTime.Now >= DbFunctions.AddDays(thuoc_phieunhap.HSD, -thuoc.ThoiGianCanhBaoHetHan)
                        select new
                        {
                            Id = thuoc_phieunhap.Thuoc_ID,
                            TenThuoc = thuoc.TenThuoc,
                            MaThuoc = thuoc.MaThuoc,
                            SoLo = thuoc_phieunhap.SoLo,
                            HSD = thuoc_phieunhap.HSD
                        };
            gridControl1.DataSource = query.ToList();
        }


        private void LoadDS_TonKhoToiThieu()
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
                            //TonKhoToiThieu = thuoc.TonKhoToiThieu,
                            // HangSanXuat = hangsanxuat.TenHangSX,
                            //NhomThuoc = nhomthuoc.TenNhom
                        };
            gridControl2.DataSource = query.ToList();
        }

        private void LoadDS_PhieuXuat()
        {
            //var result = from nv in db.PhieuNhapThuoc
            //             where nv.Xoa == false
            //             select nv;
            //var result = rpo_PhieuNhap.GetAllNotDelete();
            var result = from phieuxuat in db.PhieuXuatThuoc
                         //join ncc_kh in db.NCC_KH on phieuxuat.NCC_KH_ID equals ncc_kh.ID
                         from kh in db.NCC_KH.Where(kh => kh.ID == phieuxuat.NCC_KH_ID).DefaultIfEmpty()
                         where phieuxuat.Xoa != true
                         orderby phieuxuat.ID ascending
                         select new
                         {
                             ID = phieuxuat.ID,
                             SoPhieu = phieuxuat.SoPhieu,
                             //SoHoaDon = phieuxuat.SoHoaDon,
                             NgayTao = phieuxuat.NgayTao,
                             //NCC_KH_ID = kh.TenNCC_KH,
                             //ThueSuat = phieuxuat.ThueSuat + "%",
                             //ChietKhau = phieuxuat.ChietKhau,
                             TongTienKHTra = phieuxuat.TongTienKHTra
                         };
            gridControl4.DataSource = result.ToList();
        }

        private void LoadDS_PhieuNhap()
        {
            var result = from phieunhap in db.PhieuNhapThuoc
                         join ncc_kh in db.NCC_KH on phieunhap.NCC_KH_ID equals ncc_kh.ID
                         where phieunhap.Xoa != true
                         orderby phieunhap.ID ascending
                         select new
                         {
                             ID = phieunhap.ID,
                             SoPhieu = phieunhap.SoPhieu,
                             //SoHoaDon = phieunhap.SoHoaDon,
                             NgayTao = phieunhap.NgayNhap,
                             //NCC_KH_ID = ncc_kh.TenNCC_KH,
                             //ThueSuat = phieunhap.ThueSuat + "%",
                             //ChietKhau = phieunhap.ChietKhau,
                             TongTien = phieunhap.TongTienTra
                         };
            gridControl3.DataSource = result.ToList();
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
        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!gridView2.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
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
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView2); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView2); }));
            }

        }
        private void gridView3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!gridView3.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
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
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView3); }));
            }

        }
        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!gridView4.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
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
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView4); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView4); }));
            }

        }
        #endregion
    }
}