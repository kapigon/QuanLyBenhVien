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
    public partial class frmDSPhieuDieuChinh : DevExpress.XtraEditors.XtraForm
    {
        #region params
        PhieuDieuChinhRepository rpo_PhieuDieuChinh = new PhieuDieuChinhRepository();

        int phieuXuatID = 0;

        int iRow;
        #endregion

        public frmDSPhieuDieuChinh()
        {
            InitializeComponent();
            Load_NhanVien();
            LoadDS_PhieuDieuChinh();
            gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
        }

        #region methods
        private void LoadDS_PhieuDieuChinh()
        {
            try
            {
                var result = rpo_PhieuDieuChinh.search("", "", Convert.ToDateTime("01/01/0001"), Convert.ToDateTime("01/01/0001"));
                grdDS_PhieuDieuChinh.DataSource = result.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }

       
        private void Load_NhanVien()
        {
            try
            {
                NhanVienRepository rpo_NhanVien = new NhanVienRepository();

                cbbCol_NhanVien.DataSource = new BindingList<NhanVien>(rpo_NhanVien.GetAll(true).ToList());
                cbbCol_NhanVien.DisplayMember = "TaiKhoan";
                cbbCol_NhanVien.ValueMember = "ID";
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            iRow = gridView1.FocusedRowHandle;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                if (iRow >= 0)
                {
                    long id = Convert.ToInt64(gridView1.GetRowCellValue(iRow, "ID"));

                    frmCT_PhieuDieuChinh frmCT_PhieuDieuChinh = new frmCT_PhieuDieuChinh();

                    frmCT_PhieuDieuChinh.loadData(id);
                    frmCT_PhieuDieuChinh.ShowInTaskbar = false;
                    frmCT_PhieuDieuChinh.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Hãy lựa chọn dòng cần sửa.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }
        
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                String maPhieu = txtMaPhieu.Text.Trim();
                DateTime tuNgay = Convert.ToDateTime(dateTuNgay.EditValue);
                DateTime denNgay = Convert.ToDateTime(dateDenNgay.EditValue);
                String tenPhieu = txtTenPhieu.Text.Trim();

                tuNgay = Convert.ToDateTime(tuNgay.ToShortDateString());
                denNgay = Convert.ToDateTime(denNgay.ToShortDateString());

                var query = rpo_PhieuDieuChinh.search(maPhieu, tenPhieu, tuNgay, denNgay);
                grdDS_PhieuDieuChinh.DataSource = new BindingList<PhieuDieuChinh>(query.ToList());
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
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
            try
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
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }
        #endregion
    }
}