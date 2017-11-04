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
    public partial class frmBangKeChiTietXuat : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities db = new HospitalEntities();
        PhieuNhapThuocRepository rpo_PhieuNhap = new PhieuNhapThuocRepository();

        int phieuNhapID = 0;

        int iRow;
        #endregion

        public frmBangKeChiTietXuat()
        {
            InitializeComponent();
            gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator; 

            dateTuNgay.EditValue = DateTime.Now;
            dateDenNgay.EditValue = DateTime.Now;

            LoadBangKeCT_Xuat_Thuoc();
        }

        #region methods
        private void LoadBangKeCT_Xuat_Thuoc()
        {
            DateTime tuNgay = Convert.ToDateTime(dateTuNgay.EditValue);
            DateTime denNgay = Convert.ToDateTime(dateDenNgay.EditValue);

            var qct_xuat = from ct_xuat in db.CT_Thuoc_PhieuXuat
                           where
                           ((ct_xuat.NgayBan.Value.Year >= tuNgay.Year && ct_xuat.NgayBan.Value.Month >= tuNgay.Month && ct_xuat.NgayBan.Value.Day >= tuNgay.Day)
                           && (ct_xuat.NgayBan.Value.Year <= denNgay.Year && ct_xuat.NgayBan.Value.Month <= denNgay.Month && ct_xuat.NgayBan.Value.Day <= denNgay.Day))
                          //group ct_xuat by ct_xuat.CT_Thuoc_PhieuNhap_ID into gr_CT_Xuat
                          select new
                          {
                              CT_Thuoc_PhieuNhap_ID = ct_xuat.CT_Thuoc_PhieuNhap_ID,
                              DVT = ct_xuat.DVT_Theo_DVT_Thuoc_ID,
                              SoLuong = ct_xuat.SoLuong,
                              GiaBan = ct_xuat.GiaBan,
                              PhieuXuat_ID = ct_xuat.PhieuXuatHang_ID
                              //Thuoc_ID = gr_CT_Xuat.FirstOrDefault().ThuocID,
                              //DVT = gr_CT_Xuat.FirstOrDefault().DVT_Theo_DVT_Thuoc_ID,
                              //SoLuong = gr_CT_Xuat.Sum(p => p.SoLuong),
                              //GiaBan = gr_CT_Xuat.Sum(p => p.GiaBan),
                          };


            var query = from ct_xuat    in qct_xuat
                        join phieuxuat  in db.PhieuXuatThuoc on ct_xuat.PhieuXuat_ID equals phieuxuat.ID
                        join ct_nhap    in db.CT_Thuoc_PhieuNhap on ct_xuat.CT_Thuoc_PhieuNhap_ID equals ct_nhap.ID
                        join thuoc      in db.Thuoc on ct_nhap.Thuoc_ID equals thuoc.ID
                        join dvt        in db.DonViTinh on ct_xuat.DVT equals dvt.ID
                       
                        select new
                        {
                            SoPhieu = phieuxuat.SoPhieu,
                            Thuoc_ID = thuoc.ID,
                            MaThuoc = thuoc.MaThuoc,
                            TenThuoc = thuoc.TenThuoc,
                            TenDVT  = dvt.TenDVT,
                            SoLuong = ct_xuat.SoLuong,
                            GiaBan = ct_xuat.GiaBan
                        };

            grdDS_Nhap_Xuat_Ton.DataSource = query.ToList();
        }

       
        #endregion

        #region events


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frmDSPhieuNhap_Load(object sender, EventArgs e)
        {

        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadBangKeCT_Xuat_Thuoc();
        }
        

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            //sfdDSPhieuNhap.Filter = "Excel Worksheets|*.xls";
            sfdDSNhap_Xuat_Ton.Filter = "Excel files (*.xls or .xlsx)|.xls;*.xlsx";
            if (sfdDSNhap_Xuat_Ton.ShowDialog() == DialogResult.OK)
            {
                grdDS_Nhap_Xuat_Ton.ExportToXls(sfdDSNhap_Xuat_Ton.FileName);
            }
        }
        #endregion

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