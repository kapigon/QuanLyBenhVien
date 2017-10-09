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
    public partial class frmDanhSachKH : Form
    {
        HospitalEntities db = new HospitalEntities();
        int khID = 0;
        DataGridViewRow dgvRow = new DataGridViewRow();

        public frmDanhSachKH()
        {
            InitializeComponent();
            LoadKhachHang();
        }

        #region methods
        private void LoadKhachHang()
        {
            var query = from ncc in db.NCC_KH
                        select new
                        {
                            ID = ncc.ID,
                            MaKH = ncc.MaNCC_KH,
                            TenKH = ncc.TenNCC_KH,
                            DiaChi = ncc.DiaChi,
                            Email = ncc.Email,
                            DienThoai = ncc.DienThoai,
                            KichHoat = ncc.KichHoat
                        };

            if (query.ToList().Count() > 0)
            {
                dgvKhachHang.DataSource = query.ToList();
                dgvRow = dgvKhachHang.Rows[0];
                khID = Convert.ToInt32(dgvRow.Cells[0].Value);
                dgvKhachHang.ReadOnly = true;
            }
        }

        #endregion

        #region events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmKhachHang khachHang = new frmKhachHang();
            khachHang.FormClosed += new FormClosedEventHandler(frmKHClosed);
            khachHang.ShowDialog();
        }
        private void frmNhaCCClosed(object sender, FormClosedEventArgs e)
        {
            LoadKhachHang();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (khID > 0)
            {
                DialogResult dialogResult = MessageBox.Show(dgvRow.Cells[2].Value.ToString(), "Xác nhận xóa 'Nhà Cung Cấp' ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                    NCC_KH objNCC = db.NCC_KH.Where(p => p.ID == khID).SingleOrDefault();
                    db.NCC_KH.Remove(objNCC);
                    db.SaveChanges();

                    // Tải lại danh sách nhà cung cấp
                    LoadKhachHang();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (khID > 0)
            {
                frmKhachHang frmKH = new frmKhachHang();
                frmKH.FormClosed += new FormClosedEventHandler(frmKHClosed);
                frmKH.loadData(khID);
                frmKH.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hãy lựa chọn dòng cần sửa.");
            }
        }

        private void frmKHClosed(object sender, FormClosedEventArgs e)
        {
            LoadKhachHang();
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            dgvRow = dgvKhachHang.Rows[index];
            khID = Convert.ToInt32(dgvRow.Cells[0].Value);
            MessageBox.Show(index.ToString());
        }
        #endregion
    }
}
