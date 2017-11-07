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
    public partial class frmDSPhieuXuatHuy : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities db = new HospitalEntities();
        PhieuXuatThuocRepository rpo_PhieuXuat = new PhieuXuatThuocRepository();

        int phieuXuatID = 0;

        int iRow;
        #endregion

        public frmDSPhieuXuatHuy()
        {
            InitializeComponent();
            LoadNCC();
            LoadDS_PhieuXuat();
            gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
        }

        #region methods
        private void LoadDS_PhieuXuat()
        {
            try
            {
                //var result = from nv in db.PhieuNhapThuoc
                //             where nv.Xoa == false
                //             select nv;
                //var result = rpo_PhieuNhap.GetAllNotDelete();
                var result = from phieuxuat in db.PhieuXuatThuoc
                            //join ncc_kh in db.NCC_KH on phieuxuat.NCC_KH_ID equals ncc_kh.ID
                             from kh in db.NCC_KH.Where(kh => kh.ID == phieuxuat.NCC_KH_ID).DefaultIfEmpty()
                            where phieuxuat.TrangThaiPhieu_ID == 2          // Trạng thái Hủy
                            orderby phieuxuat.ID ascending
                            select new
                            {
                                ID              = phieuxuat.ID,
                                SoPhieu         = phieuxuat.SoPhieu,
                                SoHoaDon        = phieuxuat.SoHoaDon,
                                NgayTao         = phieuxuat.NgayTao,
                                NCC_KH_ID       = kh.TenNCC_KH,
                                ThueSuat        = phieuxuat.ThueSuat + "%",
                                ChietKhau       = phieuxuat.ChietKhau,
                                TongTienKHTra   = phieuxuat.TongTienKHTra
                            };
                grdDS_PhieuXuat.DataSource = result.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }

        private void LoadNCC()
        {
            try
            {
                NCC_KHRepository rpo_NCC_KH = new NCC_KHRepository();
                // lấy ra NCC và vừa là NCC vừa là KH
                cbbNCC_KH.Properties.DataSource = new BindingList<NCC_KH>(rpo_NCC_KH.GetAllByType(2, 2).ToList());
                //cbbNCC.DataSource = result.ToList();
                cbbNCC_KH.Properties.DisplayMember = "TenNCC_KH";
                cbbNCC_KH.Properties.ValueMember = "ID";

                cbbCol_NCC_KH.DataSource = new BindingList<NCC_KH>(rpo_NCC_KH.GetAllByType(1, 2).ToList());
                cbbCol_NCC_KH.DisplayMember = "TenNCC_KH";
                cbbCol_NCC_KH.ValueMember = "ID";
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }

        #endregion

        #region events
        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            frmPhieuXuatThuoc frmPhieuXuatThuoc = new frmPhieuXuatThuoc();
            frmPhieuXuatThuoc.ShowInTaskbar = false;
            frmPhieuXuatThuoc.ShowDialog();
        }
        
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            iRow = gridView1.FocusedRowHandle;
        }
                
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (iRow >= 0)
                {
                    long id = Convert.ToInt64(gridView1.GetRowCellValue(iRow, "ID"));

                    frmPhieuXuatThuoc frmPhieuXuatThuoc = new frmPhieuXuatThuoc();
                    frmPhieuXuatThuoc.FormClosed += new FormClosedEventHandler(frmDS_PhieuXuatClosed);

                    frmPhieuXuatThuoc.loadData(id);
                    frmPhieuXuatThuoc.ShowInTaskbar = false;
                    frmPhieuXuatThuoc.ShowDialog();
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

        private void frmDS_PhieuXuatClosed(object sender, FormClosedEventArgs e)
        {
            LoadDS_PhieuXuat();
        }

        private void frmDSPhieuNhap_Load(object sender, EventArgs e)
        {
            
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                int ncc_kh_ID       = Convert.ToInt32(cbbNCC_KH.EditValue); 
                String soPhieu      = txtSoPhieu.Text.Trim();
                DateTime tuNgay     = Convert.ToDateTime(dateTuNgay.EditValue);
                DateTime denNgay    = Convert.ToDateTime(dateDenNgay.EditValue);
                String soHoaDon     = txtSoHoaDon.Text.Trim();

                var query = rpo_PhieuXuat.search(ncc_kh_ID, soPhieu, tuNgay, denNgay, soHoaDon);
                grdDS_PhieuXuat.DataSource = new BindingList<PhieuXuatThuoc>(query.ToList());
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