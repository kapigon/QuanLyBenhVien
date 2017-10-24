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
        CT_Thuoc_PhieuNhapRepository rpo_CT_Thuoc = new CT_Thuoc_PhieuNhapRepository();

        #endregion

        public frmPhieuDieuChinh()
        {
            InitializeComponent();
            LoadDVT();
            dateNgayTao.EditValue = DateTime.Now;
            grvPhieuDieuChinh.DataSource = new BindingList<PhieuDieuChinh>();

        }
        
        #region methods
        public void loadData(GridView gridView)
        {
            grvDSThuoc.DataSource = gridView.DataSource;

            List<PhieuDieuChinh> lstPhieuDieuChinh = new List<PhieuDieuChinh>();
            PhieuDieuChinh obj_PhieuDieuChinh;
            for(int i = 0; i < gridView.RowCount; i++){
                obj_PhieuDieuChinh = new PhieuDieuChinh();
                obj_PhieuDieuChinh.SoLuongKiemKe = Convert.ToInt32(gridView.GetRowCellValue(i, "TonKho"));
                lstPhieuDieuChinh.Add(obj_PhieuDieuChinh);
            }
            grvPhieuDieuChinh.DataSource = lstPhieuDieuChinh.ToList();
        }
        private void LoadDS_Thuoc()
        {
            var query = from ct_thuoc_nhap in db.CT_Thuoc_PhieuNhap
                        join thuoc in db.Thuoc on ct_thuoc_nhap.Thuoc_ID equals thuoc.ID
                        from pdc in db.PhieuDieuChinh.Where(pdc => pdc.CT_Thuoc_PhieuNhap_ID == ct_thuoc_nhap.ID).DefaultIfEmpty()
                        select new
                        {
                            ID          = ct_thuoc_nhap.ID,
                            MaThuoc     = thuoc.MaThuoc,
                            TenThuoc    = thuoc.TenThuoc,
                            DVT         = thuoc.DVT_Le_ID,
                            HSD         = ct_thuoc_nhap.HSD,
                            SoLo        = ct_thuoc_nhap.SoLo,
                            TonKho      = ct_thuoc_nhap.TonKho,
                            TonSoSach   = ct_thuoc_nhap.TonKho,
                            KichHoat    = thuoc.KichHoat
                            //TenNhom = nhomthuoc.TenNhom,
                            //HoatChat = hoatchat.TenHoatChat,
                            //ThoiGianCanhBaoHetHan = thuoc.ThoiGianCanhBaoHetHan,
                            //TonKhoToiThieu = thuoc.TonKhoToiThieu,
                        };
            if (query.ToList().Count() > 0)
            {
                grvPhieuDieuChinh.DataSource = query.ToList();
                //grvDSThuoc.DataSource = new BindingList<Thuoc>(db.Thuoc.Where(p=>p.KichHoat == true || p.KichHoat == null).ToList());

            }
            else
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
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
        }

        private void frmDSThuoc_Closed(object sender, FormClosedEventArgs e)
        {
            LoadDS_Thuoc();
        }
        
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (thuoc_ID > 0)
            {
                frmThemThuoc frmThemThuoc = new frmThemThuoc();
                frmThemThuoc.FormClosed += new FormClosedEventHandler(frmDSThuoc_Closed);
                frmThemThuoc.loadData(thuoc_ID);
                frmThemThuoc.ShowDialog();
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
                    CT_Thuoc_PhieuNhap obj_CT_Thuoc = rpo_CT_Thuoc.GetSingle(thuoc_ID);
                    obj_CT_Thuoc.Xoa = true;
                    rpo_CT_Thuoc.Save(obj_CT_Thuoc);
                    //rpo_Thuoc.Delete(thuoc_ID);

                    // Tải lại danh sách nhà cung cấp
                    LoadDS_Thuoc();
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
        
        private void grvDSThuoc_Click(object sender, EventArgs e)
        {
            // dừng xử lý nếu không kích vào dòng có dữ liệu
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID") == null)
                return;

            string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString();
            thuoc_ID = Convert.ToInt32(id);
            //MessageBox.Show(id);
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
        #endregion
    }
}