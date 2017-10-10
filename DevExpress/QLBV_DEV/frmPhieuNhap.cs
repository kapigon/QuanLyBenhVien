using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QLBV_DEV
{
    public partial class frmPhieuNhapThuoc : DevExpress.XtraEditors.XtraForm
    {
        HospitalEntities db = new HospitalEntities();
        public frmPhieuNhapThuoc()
        {
            InitializeComponent();
            LoadNCC();
        }

        #region methods
        private void LoadNCC()
        {
            var result = from ncc in db.NCC_KH
                         where ncc.KichHoat == true && (ncc.LoaiNCC_KH_ID == 1 || ncc.LoaiNCC_KH_ID == 3)
                         select new
                        {
                            ID = ncc.ID,
                            TenNCC = ncc.TenNCC_KH
                        };
            cbbNCC.Properties.DataSource = result.ToList();
            //cbbNCC.DataSource = result.ToList();
            cbbNCC.Properties.DisplayMember = "TenNCC";
            cbbNCC.Properties.ValueMember = "ID";
        }
        #endregion

        #region events
        private void frmPhieuNhapThuoc_Load(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int nccID = Convert.ToInt32(cbbNCC.EditValue);
            String soPhieu = txtSoPhieu.Text;
            String ghiChu = txtGhiChu.Text;
            DateTime ngayNhap = dateNgayNhap.DateTime;
            MessageBox.Show(ngayNhap.ToString("dd/MM/yyyy"));
            String soSeri = txtSeri.Text;
            int thueSuat = Convert.ToInt32(cboThueSuat.EditValue);
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
    }
}