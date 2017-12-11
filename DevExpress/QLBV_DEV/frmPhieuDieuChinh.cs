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
    public partial class frmPhieuDieuChinh : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities db = new HospitalEntities();
        long phieudieuchinh_ID = 0;
        int iRow;
        PhieuDieuChinhRepository rpo_PhieuDieuChinh = new PhieuDieuChinhRepository();
        CT_PhieuDieuChinhRepository rpo_CT_PDC = new CT_PhieuDieuChinhRepository();
        NhanVien obj_NhanVien;
        #endregion


        public frmPhieuDieuChinh()
        {
            InitializeComponent();
            LoadDVT();
            dateNgayTao.EditValue = DateTime.Now;
            grvCT_PhieuDieuChinh.DataSource = new BindingList<PhieuDieuChinh>();
            gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
            gridView2.CustomDrawRowIndicator += gridView2_CustomDrawRowIndicator;

            obj_NhanVien = QLBV_DEV.Helpers.LoginInfo.nhanVien;

            //if (obj_NhanVien == null)
            //{
            //    frmLogin frmLogin = new frmLogin();
            //    frmLogin.ShowDialog();
            //}


        }
        
        #region methods

        /// Đổ dữ liệu vào gridView2(grvDSThuoc)
        public void loadData(GridView gridView)
        {
            grvDSThuoc.DataSource = gridView.DataSource;

            List<CT_PhieuDieuChinh> lstCT_PDC = new List<CT_PhieuDieuChinh>();
            CT_PhieuDieuChinh obj_CT_PDC;

            for(int i = 0; i < gridView.RowCount; i++){
                obj_CT_PDC = new CT_PhieuDieuChinh();
                obj_CT_PDC.CT_Thuoc_PhieuNhap_ID = Convert.ToInt64(gridView.GetRowCellValue(i, "ID"));
                obj_CT_PDC.SoLuongKiemKe = Convert.ToDouble(gridView.GetRowCellValue(i, "TonKho"));

                lstCT_PDC.Add(obj_CT_PDC);
            }
            grvCT_PhieuDieuChinh.DataSource = lstCT_PDC.ToList();
        }

        private void LoadDVT()
        {
            var result = from dvt in db.DonViTinh
                         select new
                         {
                             ID = dvt.ID,
                             TenDVT = dvt.TenDVT,
                         };

            cbbColDVT.DataSource = result.ToList();
            cbbColDVT.DisplayMember = "TenDVT";
            cbbColDVT.ValueMember = "ID";

        }
        #endregion

        #region events
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dxValidate.Validate())
            {
                ThuocRepository rpo_Thuoc = new ThuocRepository();
                Thuoc obj_Thuoc;
                CT_Thuoc_PhieuNhapRepository rpo_CT_Thuoc_PhieuNhap = new CT_Thuoc_PhieuNhapRepository();
                CT_Thuoc_PhieuNhap obj_CT_Thuoc_PhieuNhap;

                try
                {
                    /// Xu ly lu vao bang Phieu dieu chinh
                    PhieuDieuChinh obj_PDC;
                    int userID = obj_NhanVien.ID;

                    if (gridView1.RowCount > 0 && gridView1 != null)
                    {
                        using (var dbContextTransaction = db.Database.BeginTransaction())
                        {
                            try
                            {
                                /// Tạo mã phiếu điều chỉnh
                                string today = DateTime.Now.ToString("yyMMdd");

                                int soTT = rpo_PhieuDieuChinh.getCountByDay("PDC-" + today);

                                string maPhieu = "PDC-" + today + "-" + (soTT + 1).ToString("00");
                            
                                obj_PDC = new PhieuDieuChinh();
                                obj_PDC.Ma          = maPhieu;
                                obj_PDC.Ten         = txtTenPhieu.Text.Trim();
                                obj_PDC.GhiChu      = txtGhiChu.Text.Trim();
                                obj_PDC.UserTao     = userID;
                                rpo_PhieuDieuChinh.Create(obj_PDC);

                                 /// Khi tao 1 phiếu điều chỉnh thành công -> tạo các Chi tiết điều chỉnh thuốc
                                if (obj_PDC.ID > 0)
                                {
                                    CT_PhieuDieuChinh obj_CT_PDC;
                                    for (int i = 0; i < gridView1.RowCount; i++)
                                    {
                                        long ct_thuoc_ID    = Convert.ToInt64(gridView1.GetRowCellValue(i, "CT_Thuoc_PhieuNhap_ID"));
                                        double sl_HeThong   = Convert.ToDouble(gridView1.GetRowCellValue(i, "SoLuongKiemKe"));
                                        double sl_SoSach    = Convert.ToDouble(gridView1.GetRowCellValue(i, "TonSoSach"));
                                        double sl_Tang      = Convert.ToDouble(gridView1.GetRowCellValue(i, "SoLuongTang"));
                                        double sl_Giam      = Convert.ToDouble(gridView1.GetRowCellValue(i, "SoLuongGiam"));
                                        string ghiChu       = Convert.ToString(gridView1.GetRowCellValue(i, "GhiChu"));
                                        long thuoc_ID       = Convert.ToInt64(gridView2.GetRowCellValue(i, "ThuocID"));

                                        obj_CT_PDC = new CT_PhieuDieuChinh()
                                        {
                                            PhieuDieuChinh_ID       = obj_PDC.ID,
                                            CT_Thuoc_PhieuNhap_ID   = ct_thuoc_ID,
                                            SoLuongKiemKe           = sl_HeThong,
                                            //TonSoSach             = sl_SoSach,
                                            //SoLuongTang           = sl_Tang,
                                            //SoLuongGiam           = sl_Giam,
                                            //LoaiDieuChinh         = (sl_Tang > 0 ? 1 : (sl_Giam > 0 ? 2 : 0)),
                                            GhiChu = ghiChu
                                        };
                                        if (gridView1.GetRowCellValue(i, "TonSoSach") != null)
                                        {
                                            obj_CT_PDC.TonSoSach        = sl_SoSach;
                                            obj_CT_PDC.SoLuongTang      = sl_Tang;
                                            obj_CT_PDC.SoLuongGiam      = sl_Giam;
                                            obj_CT_PDC.LoaiDieuChinh    = (sl_Tang > 0 ? 1 : (sl_Giam > 0 ? 2 : 0));
                                        }

                                        // tăng = 1  - giảm = 2 - k tăng k giam = 0
                                        rpo_CT_PDC.Create(obj_CT_PDC);

                                        if (gridView1.GetRowCellValue(i, "TonSoSach") != null)
                                        {
                                            /// Cập nhật lại số lượng cho ID
                                            obj_CT_Thuoc_PhieuNhap = rpo_CT_Thuoc_PhieuNhap.GetSingle(ct_thuoc_ID);
                                            if (obj_CT_Thuoc_PhieuNhap != null)
                                            {
                                                // Số lượng tồn kho và thực tế khác nhau sẽ cập nhật lại số tồn kho
                                                if (obj_CT_Thuoc_PhieuNhap.TonKho != sl_SoSach)
                                                {
                                                    obj_CT_Thuoc_PhieuNhap.TonKho = sl_SoSach;
                                                    rpo_CT_Thuoc_PhieuNhap.Save(obj_CT_Thuoc_PhieuNhap);

                                                    /// Đếm lại số lượng Thuốc theo obj_CT_Phieu
                                                    obj_Thuoc = rpo_Thuoc.GetSingle(thuoc_ID);
                                                    obj_Thuoc.TonKho = rpo_Thuoc.GetCountTonKho(thuoc_ID);
                                                    rpo_Thuoc.Save(obj_Thuoc);
                                                }
                                            }
                                        }
                                    
                                    }
                                }
                                this.Close();
                            }
                            catch (Exception)
                            {
                                dbContextTransaction.Rollback();
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
                }
            }
        }
      
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            iRow = gridView1.FocusedRowHandle;
        }

        // Bắt sự kiện thay đổi khi chọn Tên thuốc -> tự động đưa ra dữ liệu vào các cột trong gridcontrol tương ứng
        private void txtColTonSoSach_EditValueChanged(object sender, EventArgs e)
        {
            int index = gridView1.FocusedRowHandle;

            var search = sender as TextEdit;
            if (search == null) return;

            double tonsosach = (search.EditValue == null || search.EditValue == DBNull.Value || search.EditValue.ToString() == "") ? 0 : Convert.ToDouble(search.EditValue);
            double soluongkiemke = Convert.ToDouble(gridView1.GetRowCellValue(index, "SoLuongKiemKe"));

            //MessageBox.Show(soluongkiemke + " - " + tonsosach + "-" + id);
            if (soluongkiemke - tonsosach > 0)
            {
                gridView1.SetRowCellValue(index, "SoLuongGiam", soluongkiemke - tonsosach);
                gridView1.SetRowCellValue(index, "SoLuongTang", "");
            }
            else if (soluongkiemke - tonsosach < 0)
            {
                gridView1.SetRowCellValue(index, "SoLuongTang", tonsosach - soluongkiemke);
                gridView1.SetRowCellValue(index, "SoLuongGiam", "");
            }
            else
            {
                gridView1.SetRowCellValue(index, "SoLuongTang", "");
                gridView1.SetRowCellValue(index, "SoLuongGiam", "");
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
        #endregion
    }
}