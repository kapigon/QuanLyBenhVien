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
    public partial class frmDSPhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities db = new HospitalEntities();
        PhieuNhapThuocRepository rpo_PhieuNhap = new PhieuNhapThuocRepository();

        int phieuNhapID = 0;

        int iRow;
        #endregion

        public frmDSPhieuNhap()
        {
            InitializeComponent();
            LoadNCC();
            LoadDS_PhieuNhap();
            gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
        }

        #region methods
        private void LoadDS_PhieuNhap()
        {
            //var result = from nv in db.PhieuNhapThuoc
            //             where nv.Xoa == false
            //             select nv;
            //var result = rpo_PhieuNhap.GetAllNotDelete();
            var result = from phieunhap in db.PhieuNhapThuoc
                        //join ncc_kh in db.NCC_KH on phieunhap.NCC_KH_ID equals ncc_kh.ID
                         from ncc_kh in db.NCC_KH.Where(ncc => ncc.ID == phieunhap.NCC_KH_ID).DefaultIfEmpty()
                        where phieunhap.Xoa != true
                        orderby phieunhap.ID ascending
                        select new
                        {
                            ID          = phieunhap.ID,
                            SoPhieu     = phieunhap.SoPhieu,
                            SoHoaDon    = phieunhap.SoHoaDon,
                            NgayNhap    = phieunhap.NgayNhap,
                            NCC_KH_ID   = ncc_kh.TenNCC_KH,
                            ThueSuat    = phieunhap.ThueSuat + "%",
                            ChietKhau   = phieunhap.ChietKhau,
                            TongTienTra = phieunhap.TongTienTra
                        };
            grdDS_PhieuNhap.DataSource = result.ToList();
        }

        private void LoadNCC()
        {
            NCC_KHRepository rpo_NCC_KH = new NCC_KHRepository();
            // lấy ra NCC và vừa là NCC vừa là KH
            cbbNCC_KH.Properties.DataSource = new BindingList<NCC_KH>(rpo_NCC_KH.GetAllByType(1, 2).ToList());
            //cbbNCC.DataSource = result.ToList();
            cbbNCC_KH.Properties.DisplayMember = "TenNCC_KH";
            cbbNCC_KH.Properties.ValueMember = "ID";

            cbbCol_NCC_KH.DataSource = new BindingList<NCC_KH>(rpo_NCC_KH.GetAllByType(1, 2).ToList());
            cbbCol_NCC_KH.DisplayMember = "TenNCC_KH";
            cbbCol_NCC_KH.ValueMember = "ID";
        }

        #endregion

        #region events
        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            frmPhieuNhapThuoc frmPhieuNhapThuoc = new frmPhieuNhapThuoc();
            frmPhieuNhapThuoc.ShowInTaskbar = false;
            frmPhieuNhapThuoc.ShowDialog();

            /*frmMain frmMain = new frmMain();
            frmMain.showPhieuNhap();
            Form frm = frmMain.kiemtraform(typeof(frmPhieuNhapThuoc));
            if (frm == null)
            {
                //frmPhieuNhapThuoc forms = new frmPhieuNhapThuoc();
                frmPhieuNhapThuoc.MdiParent = frmMain;
                frmPhieuNhapThuoc.Show();
            }
            else
            {
                frm.Activate();
            }*/
        }
        
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            iRow = gridView1.FocusedRowHandle;
        }
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (iRow >= 0)
            {
                String soPhieu = gridView1.GetRowCellValue(iRow, "SoPhieu").ToString();
                DialogResult dialogResult = MessageBox.Show(soPhieu, "Xác nhận xóa?", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    long id = Convert.ToInt64(gridView1.GetRowCellValue(iRow, "ID"));
                    //int userID = 100000;

                    PhieuNhapThuoc obj_PhieuNhap = rpo_PhieuNhap.GetSingle(id);
                    obj_PhieuNhap.Xoa = true;
                    obj_PhieuNhap.NgayXoa = DateTime.Now;

                    rpo_PhieuNhap.Save(obj_PhieuNhap);


                    // Tải lại danh sách nhà cung cấp
                    LoadDS_PhieuNhap();
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (iRow >= 0)
            {
                long id = Convert.ToInt64(gridView1.GetRowCellValue(iRow, "ID"));

                frmPhieuNhapThuoc frmPhieuNhap = new frmPhieuNhapThuoc();
                frmPhieuNhap.FormClosed += new FormClosedEventHandler(frmDS_PhieuNhapClosed);

                frmPhieuNhap.loadData(id);
                frmPhieuNhap.ShowInTaskbar = false;
                frmPhieuNhap.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hãy lựa chọn dòng cần sửa.");
            }
        }

        private void frmDS_PhieuNhapClosed(object sender, FormClosedEventArgs e)
        {
            LoadDS_PhieuNhap();
        }

        private void frmDSPhieuNhap_Load(object sender, EventArgs e)
        {
            
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int ncc_kh_ID       = Convert.ToInt32(cbbNCC_KH.EditValue); 
            String soPhieu      = txtSoPhieu.Text.Trim();
            DateTime tuNgay     = Convert.ToDateTime(dateTuNgay.EditValue);
            DateTime denNgay    = Convert.ToDateTime(dateDenNgay.EditValue);
            String soHoaDon     = txtSoHoaDon.Text.Trim();

            var query = rpo_PhieuNhap.search(ncc_kh_ID, soPhieu, tuNgay, denNgay, soHoaDon);
            grdDS_PhieuNhap.DataSource = new BindingList<PhieuNhapThuoc>(query.ToList());
        }
        #endregion

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            //sfdDSPhieuNhap.Filter = "Excel Worksheets|*.xls";
            sfdDSPhieuNhap.Filter = "Excel files (*.xls or .xlsx)|.xls;*.xlsx";
            if (sfdDSPhieuNhap.ShowDialog() == DialogResult.OK)
            {
                grdDS_PhieuNhap.ExportToXls(sfdDSPhieuNhap.FileName);
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