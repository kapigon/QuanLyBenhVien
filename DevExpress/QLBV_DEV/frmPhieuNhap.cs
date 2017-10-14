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

namespace QLBV_DEV
{
    public partial class frmPhieuNhapThuoc : DevExpress.XtraEditors.XtraForm
    {
        HospitalEntities db = new HospitalEntities();
        PhieuNhapThuocRepository repository_PhieuNhap = new PhieuNhapThuocRepository();
        CT_Thuoc_PhieuNhapRepository repository_CT_Thuoc = new CT_Thuoc_PhieuNhapRepository();

        public frmPhieuNhapThuoc()
        {
            InitializeComponent();
            LoadNCC();
            LoadDVT();
            LoadThuoc();
        }

        #region methods
        private void LoadNCC()
        {
            var result = from ncc in db.NCC_KH
                         where ncc.KichHoat == true && (ncc.LoaiNCC_KH_ID == 1 || ncc.LoaiNCC_KH_ID == 3)
                         select new
                        {
                            ID = ncc.ID,
                            TenNCC = ncc.TenNCC_KH,
                            DiaChi = ncc.DiaChi
                        };
            cbbNCC.Properties.DataSource = result.ToList();
            //cbbNCC.DataSource = result.ToList();
            cbbNCC.Properties.DisplayMember = "TenNCC";
            cbbNCC.Properties.ValueMember = "ID";
        }

        private void LoadDVT()
        {
            var result = from dvt in db.DonViTinh
                         select new
                         {
                             ID = dvt.ID,
                             TenDVT = dvt.TenDVT
                         };
            cbbDVT.DataSource = result.ToList();
            //cbbNCC.DataSource = result.ToList();
            cbbDVT.DisplayMember = "TenDVT";
            cbbDVT.ValueMember = "ID";
        }

        private void LoadThuoc()
        {
            var result = from thuoc in db.Thuoc
                         select new
                         {
                             ID = thuoc.ID,
                             MaThuoc = thuoc.MaThuoc,
                             TenThuoc = thuoc.TenThuoc
                         };
            gridColThuoc_ID.DataSource = result.ToList();
            //cbbNCC.DataSource = result.ToList();
            gridColThuoc_ID.DisplayMember = "TenThuoc";
            gridColThuoc_ID.ValueMember = "ID";
        }
        #endregion

        #region events
        private void frmPhieuNhapThuoc_Load(object sender, EventArgs e)
        {
            //Defaul value
            dateNgayNhap.EditValue = DateTime.Now;
            dateNgayVietHD.EditValue = DateTime.Now;

            grdDSThuoc.DataSource = new BindingList<CT_Thuoc_PhieuNhap>(db.CT_Thuoc_PhieuNhap.Where(p=>p.ID == 0).ToList());
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            dxValidate.Validate();

            int nccID = Convert.ToInt32(cbbNCC.EditValue);
            String soPhieu = txtSoPhieu.Text;
            String ghiChu = txtGhiChu.Text;
            DateTime ngayNhap = dateNgayNhap.DateTime;
            //MessageBox.Show(ngayNhap.ToString("dd/MM/yyyy"));
            String soSeri = txtSeri.Text;
            int thueSuat = Convert.ToInt32(cbbThueSuat.EditValue);
            String soHD = txtSoHoaDon.Text;
            DateTime ngayVietHD = dateNgayVietHD.DateTime;

            PhieuNhapThuoc _object = new PhieuNhapThuoc();
            _object.NCC_KH_ID = nccID;
            _object.SoPhieu = soPhieu;
            _object.GhiChu = ghiChu;
            _object.NgayNhap = ngayNhap;
            _object.ThueSuat = thueSuat;
            _object.SoSeri = soSeri;
            _object.SoHoaDon = soHD;
            _object.NgayHoaDon = ngayVietHD;
            _object.TongTienTruocThue = 0;
            _object.ChietKhau = 0;
            _object.TongTienTra = 0;

        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void grdDSThuoc_DoubleClick(object sender, EventArgs e)
        {
            //if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID") == null)
            //    return;
            if (gridView1 == null || gridView1.SelectedRowsCount == 0) return;

            DataRow[] rows = new DataRow[gridView1.SelectedRowsCount];
            //int indexRow = gridView1.GetSelectedRows;
            long thuocID = 0;
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thuoc_ID_1") != null)
                thuocID = Convert.ToInt64(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Thuoc_ID_1").ToString());
            DataRow dr = null;
            //dr = gridView1.GetFocusedDataRow();
            
            frmCT_Thuoc_PhieuNhap frmCT_Thuoc = new frmCT_Thuoc_PhieuNhap();
            frmCT_Thuoc.ShowDialog();
            frmCT_Thuoc.loadData(thuocID, dr);
            //MessageBox.Show(thuocID.ToString());
        }
    }
}