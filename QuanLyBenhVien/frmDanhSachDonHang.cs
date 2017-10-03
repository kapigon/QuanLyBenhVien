using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBenhVien
{
    public partial class frmDanhSachDonHang : Form
    {
        HospitalEntities db = new HospitalEntities();
        DataGridViewRow dgvRow = new DataGridViewRow();
        int nccID = 0;

        public frmDanhSachDonHang()
        {
            InitializeComponent();
            Load_DS_DonHang();
        }

        private void Load_DS_DonHang()
        {
            var query = from donthuoc in db.DonThuocs
                        select new
                        {
                            ID = donthuoc.ID,
                            SoDH = donthuoc.SoDH,
                            NgayDH = donthuoc.NgayNhap,
                            TenKH = donthuoc.KhachHang,
                            DiaChi = donthuoc.DiaChi,
                            BacSyKeToa = donthuoc.BacSyID,
                            GhiChu = donthuoc.GhiChu,
                            TongTien = donthuoc.TongTien
                        };

            if (query.ToList().Count() > 0)
            {
                
                dgvDanhSachThuoc.DataSource = query.ToList();

            }
            else
            {
            }
        }

        #region methods

        #endregion
        #region events
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string soHD = txtSoDH.Text.Trim();
            DateTime tungay = dtpTuNgay.Value;
            DateTime denngay = dtpTuNgay.Value;
            string tenKH = txtTenKH.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string bacSy = txtBacSyKeToa.Text.Trim();
            string ghiChu = txtGhiChu.Text.Trim();
            string loaidon = cbbLoaiDon.SelectedText.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmDonBanHang donhang = new frmDonBanHang();
            donhang.FormClosed += new FormClosedEventHandler(frmDSDonHangClosed);
            donhang.ShowDialog();
        }

        private void frmDSDonHangClosed(object sender, FormClosedEventArgs e)
        {
            Load_DS_DonHang();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (nccID > 0)
            {
                frmDonBanHang donhang = new frmDonBanHang();
                donhang.FormClosed += new FormClosedEventHandler(frmDSDonHangClosed);
                donhang.loadData(nccID);
                donhang.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hãy lựa chọn dòng cần sửa.");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void dgvDanhSachThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            dgvRow = dgvDanhSachThuoc.Rows[index];
            nccID = Convert.ToInt32(dgvRow.Cells[0].Value);
            MessageBox.Show(index.ToString());
        }
    }
}
