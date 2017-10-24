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
        int thuoc_ID = 0;
        int iRow;
        PhieuDieuChinhRepository rpo_PhieuDieuChinh = new PhieuDieuChinhRepository();

        #endregion


        public frmPhieuDieuChinh()
        {
            InitializeComponent();
            LoadDVT();
            dateNgayTao.EditValue = DateTime.Now;
            grvPhieuDieuChinh.DataSource = new BindingList<PhieuDieuChinh>();

        }
        
        #region methods

        /// Đổ dữ liệu vào gridView2(grvDSThuoc)
        public void loadData(GridView gridView)
        {
            grvDSThuoc.DataSource = gridView.DataSource;

            List<PhieuDieuChinh> lstPhieuDieuChinh = new List<PhieuDieuChinh>();
            PhieuDieuChinh obj_PhieuDieuChinh;

            for(int i = 0; i < gridView.RowCount; i++){
                obj_PhieuDieuChinh = new PhieuDieuChinh();
                obj_PhieuDieuChinh.CT_Thuoc_PhieuNhap_ID = Convert.ToInt64(gridView.GetRowCellValue(i, "ID"));
                obj_PhieuDieuChinh.SoLuongKiemKe = Convert.ToInt32(gridView.GetRowCellValue(i, "TonKho"));

                lstPhieuDieuChinh.Add(obj_PhieuDieuChinh);
            }
            grvPhieuDieuChinh.DataSource = lstPhieuDieuChinh.ToList();
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
            /// Xu ly lu vao bang Phieu dieu chinh
            PhieuDieuChinh obj_PDC;
            int userID = 100000;

            if (gridView1.RowCount > 0 && gridView1 != null)
            {
                 using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            obj_PDC = new PhieuDieuChinh();
                            obj_PDC.MaPhieuDieuChinh        = "PDC-" + (rpo_PhieuDieuChinh.GetCount() + 1);
                            obj_PDC.TenPhieuDieuChinh       = txtTenPhieu.Text.Trim();
                            obj_PDC.CT_Thuoc_PhieuNhap_ID   = Convert.ToInt64(gridView1.GetRowCellValue(i, "CT_Thuoc_PhieuNhap_ID"));
                            obj_PDC.NoiDung                 = txtGhiChu.Text.Trim();
                            obj_PDC.SoLuongKiemKe           = Convert.ToInt32(gridView1.GetRowCellValue(i, "SoLuongKiemKe"));
                            obj_PDC.TonSoSach               = Convert.ToInt32(gridView1.GetRowCellValue(i, "TonSoSach"));
                            obj_PDC.SoLuongTang             = Convert.ToInt32(gridView1.GetRowCellValue(i, "SoLuongTang"));
                            obj_PDC.SoLuongGiam             = Convert.ToInt32(gridView1.GetRowCellValue(i, "SoLuongGiam"));
                            obj_PDC.UserTao                 = userID;
                            // tăng = 1  - giảm = 2 - k tăng k giam = 0
                            obj_PDC.LoaiDieuChinh           = (Convert.ToInt32(gridView1.GetRowCellValue(i, "SoLuongTang")) > 0 ? 1 : (Convert.ToInt32(gridView1.GetRowCellValue(i, "SoLuongGiam")) > 0 ? 2 : 0));
                            rpo_PhieuDieuChinh.Create(obj_PDC);
                        }
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }
                
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (thuoc_ID > 0)
            {
                //frmThemThuoc frmThemThuoc = new frmThemThuoc();
                //frmThemThuoc.loadData(thuoc_ID);
                //frmThemThuoc.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hãy lựa chọn dòng cần sửa.");
            }
        }
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (thuoc_ID > 0)
            {
                String ten = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TenThuoc").ToString();
                DialogResult dialogResult = MessageBox.Show(ten, "Xác nhận xóa?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                    //CT_Thuoc_PhieuNhap obj_CT_Thuoc = rpo_CT_Thuoc.GetSingle(thuoc_ID);
                    //obj_CT_Thuoc.Xoa = true;
                    //rpo_CT_Thuoc.Save(obj_CT_Thuoc);
                    //rpo_Thuoc.Delete(thuoc_ID);

                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            else
            {
                MessageBox.Show("Hãy lựa chọn dòng cần xóa.");
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

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            // Thêm số thứ tự tự động tăng GridControl
            //bool indicatorIcon = true;
            GridView view = (GridView)sender;
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
                //if (!indicatorIcon)
                // e.Info.ImageIndex = -1;
            }
        }
        // Bắt sự kiện thay đổi khi chọn Tên thuốc -> tự động đưa ra dữ liệu vào các cột trong gridcontrol tương ứng
        private void txtColTonSoSach_EditValueChanged(object sender, EventArgs e)
        {
            int index = gridView1.FocusedRowHandle;

            var search = sender as TextEdit;
            if (search == null) return;

            int tonsosach = (search.EditValue.ToString() == "" || search.EditValue == null || search.EditValue == DBNull.Value) ? 0 : Convert.ToInt32(search.EditValue);
            int soluongkiemke = Convert.ToInt32(gridView1.GetRowCellValue(index, "SoLuongKiemKe"));

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
    }
}