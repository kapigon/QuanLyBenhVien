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
    public partial class frmBangKeChiTietNhap_Xuat_Ton : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities            db              = new HospitalEntities();
        PhieuNhapThuocRepository    rpo_PhieuNhap   = new PhieuNhapThuocRepository();
        CT_DonViTinhRepository      rpo_CT_DVT      = new CT_DonViTinhRepository();
        int phieuNhapID = 0;

        int iRow;
        #endregion

        public frmBangKeChiTietNhap_Xuat_Ton()
        {
            InitializeComponent();

            gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;

            dateTuNgay.EditValue = DateTime.Now;
            dateDenNgay.EditValue = DateTime.Now;

            LoadBangKeCT_Xuat_Nhap_Ton_Thuoc();
        }

        #region methods
        private void LoadBangKeCT_Xuat_Nhap_Ton_Thuoc()
        {
            DateTime tuNgay     = Convert.ToDateTime(dateTuNgay.EditValue);
            DateTime denNgay    = Convert.ToDateTime(dateDenNgay.EditValue);

            tuNgay  = Convert.ToDateTime(tuNgay.ToShortDateString());
            denNgay = Convert.ToDateTime(denNgay.ToShortDateString());

            // Group nhom theo CT_Thuoc_PhieuNhap_ID
            try
            {
                //var lst_CT_PhieuXuat = (from ct_xuat in db.CT_Thuoc_PhieuXuat
                //                        join ct_nhap in db.CT_Thuoc_PhieuNhap on ct_xuat.CT_Thuoc_PhieuNhap_ID equals ct_nhap.ID
                //                        where ct_xuat.SoLuong > 0 && (ct_xuat.NgayBan >= tuNgay && ct_xuat.NgayBan <= denNgay)
                //                        select new
                //                        {
                //                            CT_Thuoc_PhieuNhap_ID = ct_xuat.CT_Thuoc_PhieuNhap_ID,
                //                            SoLuong = ct_xuat.SoLuong.Value * rpo_CT_DVT.GetHeSoTheoQuyChuan(Convert.ToInt64(ct_nhap.Thuoc_ID), Convert.ToInt32(ct_nhap.DVT_Theo_DVT_Thuoc_ID), 'T'),
                //                            GiaBan = ct_xuat.GiaBan
                //                        });
                //foreach (var item in lst_CT_PhieuXuat.ToList())
                //{
                //    CT_Thuoc_PhieuNhapRepository rpo_CT_PhieuNhap = new CT_Thuoc_PhieuNhapRepository();
                //    CT_Thuoc_PhieuNhap obj_CT_PhieuNhap = rpo_CT_PhieuNhap.GetSingle(Convert.ToInt64(item.CT_Thuoc_PhieuNhap_ID));
                //    //item.SoLuong *= 3 + rpo_CT_DVT.GetHeSoTheoQuyChuan(Convert.ToInt64(obj_CT_PhieuNhap.Thuoc_ID), Convert.ToInt32(obj_CT_PhieuNhap.DVT_Theo_DVT_Thuoc_ID), 'T');
                //    item.SoLuong = 0;
                //}
                //lst_CT_PhieuXuat.GroupBy(p => p.CT_Thuoc_PhieuNhap_ID).Sum(p => p.FirstOrDefault().SoLuong);

                //var qCT_Xuat_TuNgay_DenNgay = lst_CT_PhieuXuat;
                var qCT_Xuat_TuNgay_DenNgay = from ct_xuat in db.CT_Thuoc_PhieuXuat
                                              where ct_xuat.SoLuong > 0 && (ct_xuat.NgayBan >= tuNgay && ct_xuat.NgayBan <= denNgay)
                                              group ct_xuat by ct_xuat.CT_Thuoc_PhieuNhap_ID into gr_CT_Xuat
                                              select new
                                              {
                                                  gr_CT_Xuat.FirstOrDefault().CT_Thuoc_PhieuNhap_ID,
                                                  SoLuong = gr_CT_Xuat.Sum(p => p.SoLuong),
                                                  GiaBan = gr_CT_Xuat.Sum(p => p.GiaBan),
                                              };

                var qCT_PhieuNhap = from ct_nhap in db.CT_Thuoc_PhieuNhap
                                    where (ct_nhap.NgayNhap >= tuNgay && ct_nhap.NgayNhap <= denNgay)
                                    select new
                                    {
                                        ID = ct_nhap.ID,
                                        Thuoc_ID = ct_nhap.Thuoc_ID,
                                        SoLuongNhap = ct_nhap.SoLuong,
                                        TonKho = ct_nhap.TonKho,
                                    };


                //////////////////////////////
                var nhap_truoc = from ct_nhap in db.CT_Thuoc_PhieuNhap
                                 where (ct_nhap.NgayNhap < tuNgay)
                                 select new { ct_nhap.ID, ct_nhap.SoLuong };

                var nhap_sau = from ct_nhap in db.CT_Thuoc_PhieuNhap
                               where (ct_nhap.NgayNhap <= denNgay)
                               select new { ct_nhap.ID, ct_nhap.SoLuong };

                var xuat_truoc = from ct_xuat in db.CT_Thuoc_PhieuXuat
                                 where ct_xuat.SoLuong > 0 && ct_xuat.NgayBan < tuNgay
                                 group ct_xuat by ct_xuat.CT_Thuoc_PhieuNhap_ID into gr_CT_Xuat
                                 select new
                                 {
                                     gr_CT_Xuat.FirstOrDefault().CT_Thuoc_PhieuNhap_ID,
                                     SoLuong = gr_CT_Xuat.Sum(p => p.SoLuong),
                                     GiaBan = gr_CT_Xuat.Sum(p => p.GiaBan),
                                 };

                var xuat_sau = from ct_xuat in db.CT_Thuoc_PhieuXuat
                               where ct_xuat.SoLuong > 0 && ct_xuat.NgayBan <= denNgay
                               group ct_xuat by ct_xuat.CT_Thuoc_PhieuNhap_ID into gr_CT_Xuat
                               select new
                               {
                                   gr_CT_Xuat.FirstOrDefault().CT_Thuoc_PhieuNhap_ID,
                                   SoLuong = gr_CT_Xuat.Sum(p => p.SoLuong),
                                   GiaBan = gr_CT_Xuat.Sum(p => p.GiaBan),
                               };


                var query = from ct_nhap        in db.CT_Thuoc_PhieuNhap
                            from _nhap_truoc    in nhap_truoc.Where(_nhap_truoc => _nhap_truoc.ID == ct_nhap.ID).DefaultIfEmpty()
                            from _nhap_sau      in nhap_sau.Where(_nhap_sau => _nhap_sau.ID == ct_nhap.ID).DefaultIfEmpty()
                            from _xuat_truoc    in xuat_truoc.Where(_xuat_truoc => _xuat_truoc.CT_Thuoc_PhieuNhap_ID == ct_nhap.ID).DefaultIfEmpty()
                            from _xuat_sau      in xuat_sau.Where(_xuat_sau => _xuat_sau.CT_Thuoc_PhieuNhap_ID == ct_nhap.ID).DefaultIfEmpty()
                            from ct_xuat        in qCT_Xuat_TuNgay_DenNgay.Where(ct_xuat => ct_xuat.CT_Thuoc_PhieuNhap_ID == ct_nhap.ID).DefaultIfEmpty()
                            from _qCT_PhieuNhap in qCT_PhieuNhap.Where(_qCT_PhieuNhap => _qCT_PhieuNhap.ID == ct_nhap.ID).DefaultIfEmpty()
                            join thuoc          in db.Thuoc on ct_nhap.Thuoc_ID equals thuoc.ID
                            join dvt            in db.DonViTinh on ct_nhap.DVT_Theo_DVT_Thuoc_ID equals dvt.ID
                            select new
                            {
                                Thuoc_ID        = thuoc.ID,
                                MaThuoc         = thuoc.MaThuoc,
                                TenThuoc        = thuoc.TenThuoc,
                                TenDVT          = dvt.TenDVT,
                                TonDauKy        = (_nhap_truoc.SoLuong != null ? _nhap_truoc.SoLuong : 0) - (_xuat_truoc.SoLuong != null ? _xuat_truoc.SoLuong : 0),
                                NhapTrongKy     = _qCT_PhieuNhap.SoLuongNhap,
                                XuatTrongky     = ct_xuat.SoLuong,
                                GiaXuatTrongKy  = ct_xuat.GiaBan,
                                TonCuoiKy       = (_nhap_sau.SoLuong != null ? _nhap_sau.SoLuong : 0) - (_xuat_sau.SoLuong != null ? _xuat_sau.SoLuong : 0),
                               // NgayNhap = ct_nhap.NgayNhap
                            };
                grdDS_Nhap_Xuat_Ton.DataSource = query.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }

       
        #endregion

        #region events
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //int ncc_kh_ID       = Convert.ToInt32(cbbNCC_KH.EditValue); 
            //String soPhieu      = txtSoPhieu.Text.Trim();
            //DateTime tuNgay     = Convert.ToDateTime(dateTuNgay.EditValue);
            //DateTime denNgay    = Convert.ToDateTime(dateDenNgay.EditValue);
            //String soHoaDon     = txtSoHoaDon.Text.Trim();

            //var query = rpo_PhieuNhap.search(ncc_kh_ID, soPhieu, tuNgay, denNgay, soHoaDon);
            //grdDS_BanHang.DataSource = new BindingList<PhieuNhapThuoc>(query.ToList());
            LoadBangKeCT_Xuat_Nhap_Ton_Thuoc();
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