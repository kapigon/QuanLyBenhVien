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
    public partial class frmDonBanHang : Form
    {
        HospitalEntities db = new HospitalEntities();

        public frmDonBanHang()
        {
            InitializeComponent();
        }
        #region methods
        private void fomatNumberCurrent(String textBoxName, KeyPressEventArgs e)
        {
            // Nếu là số thì cho nhập
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);

            // Format dạng tiền
            if (e.KeyChar == (char)13)
            {
                TextBox tv = this.Controls.Find(textBoxName, false).First() as TextBox;
                tv.Text = string.Format("{0:n0}", double.Parse(tv.Text));
            }
        }

        private void resetField()
        {
            txtKhachHang.Text = "";
            txtDiaChi.Text = "";
            txtGhiChu.Text = "";
            txtTuoi.Text = "";
            txtDienThoai.Text = "";
        }

        public void loadData(int nccID)
        {
            var result = from donthuoc in db.DonThuocs
                         where donthuoc.ID == nccID
                         select donthuoc;

            if (result.Count() > 0)
            {
                DonThuoc donthuoc = result.SingleOrDefault();
                txtKhachHang.Text = donthuoc.KhachHang;
                txtDiaChi.Text = donthuoc.DiaChi;
                txtGhiChu.Text = donthuoc.GhiChu;
                if (donthuoc.GioiTinh == true)
                {
                    radNam.Checked = true;
                }
                else
                {
                    radNu.Checked = true;
                }
                txtTuoi.Text = donthuoc.Tuoi.ToString();
                txtDienThoai.Text = donthuoc.SDT;
                txtTienThuoc.Text = donthuoc.TienThuoc.ToString();
                txtPhuPhi.Text = donthuoc.PhuPhi.ToString();
                txtKHTra.Text = donthuoc.KhachHangTra.ToString();
                txtTongCong.Text = donthuoc.TongTien.ToString();
            }
            btnLuu.Text = "&Cập nhật";
            //isUpdate = true;
            //nccID = ID;
        }
        #endregion

        #region events
        private void frmDonBanHang_Load(object sender, EventArgs e)
        {
            var checkedButton = grbGioiTinh.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            //MessageBox.Show(checkedButton.Text);
        }

        private void txtTongCong_KeyPress(object sender, KeyPressEventArgs e)
        {
            fomatNumberCurrent("txtTongCong", e);
        }
                
        private void txtTienThuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            fomatNumberCurrent("txtTienThuoc", e);
        }

        private void txtKHTra_KeyPress(object sender, KeyPressEventArgs e)
        {
            fomatNumberCurrent("txtKHTra", e);
        }

        private void txtPhuPhi_KeyPress(object sender, KeyPressEventArgs e)
        {
            fomatNumberCurrent("txtPhuPhi", e);
        }

        private void txtSoTienTraLai_KeyPress(object sender, KeyPressEventArgs e)
        {
            fomatNumberCurrent("txtSoTienTraLai", e);
        }

        private void txtTienThuocVaPhuPhi_KeyPress(object sender, KeyPressEventArgs e)
        {
            fomatNumberCurrent("txtTienThuocVaPhuPhi", e);
        }
        private void txtTuoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Nếu là số thì cho nhập
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Nếu là số thì cho nhập
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn lưu trước khi thêm mới không ?", "Bạn có muốn lưu trước khi thêm mới không ?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        #endregion
    }
}
