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
    public partial class frmDSPhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities db = new HospitalEntities();
        int nccID = 0;
        DataGridViewRow dgvRow = new DataGridViewRow();
        #endregion

        public frmDSPhieuNhap()
        {
            InitializeComponent();
            LoadDS_NCC();
        }

        #region methods
        private void LoadDS_NCC()
        {
            var result = from nv in db.PhieuNhapThuoc
                         select nv;
            grdDSNCC.DataSource = result.ToList();
            /*var query = from phieunhapthuoc in db.PhieuNhapThuocs
                        select new
                        {
                            ID = phieunhapthuoc.ID,
                            gridColumn1 = phieunhapthuoc.SoPhieu,
                            SoHoaDon = phieunhapthuoc.SoHoaDon,
                            NgayNhap = phieunhapthuoc.NgayNhap,
                            NCC = phieunhapthuoc.NCC_KH_ID,
                            ChietKhau = phieunhapthuoc.ChietKhau,
                            TongTien = phieunhapthuoc.TongTienTra
                        };

            if (query.ToList().Count() > 0)
            {
                
                grdDSNCC.DataSource = query.ToList();
                //dgvRow = grdDSNCC.Rows[0];
                nccID = Convert.ToInt32(dgvRow.Cells[0].Value);
                //grdDSNCC.ReadOnly = true;

            }
            else
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }*/
        }

        #endregion

        #region events
        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            frmPhieuNhapThuoc f_PhieuNhapThuoc = new frmPhieuNhapThuoc();
            f_PhieuNhapThuoc.Show();
        }
        #endregion

    }
}