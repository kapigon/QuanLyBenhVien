using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBV_DEV.Repository;
using System.Security.Cryptography;
using System.IO;

namespace QLBV_DEV
{
    public partial class frmThongTinNguoiDung : DevExpress.XtraEditors.XtraForm
    {
        NhanVienRepository rpo_NhanVien = new NhanVienRepository();
        NhanVien obj_NhanVien = new NhanVien();

        int nhanvien_ID = 0;

        public frmThongTinNguoiDung()
        {
            InitializeComponent();
        }


        #region methods
       
        public void loadData(int ID)
        {
            try
            {
                nhanvien_ID = ID;
                obj_NhanVien = rpo_NhanVien.GetSingle(ID);
                if (ID > 0)
                {
                    txtTaiKhoan.Text        = obj_NhanVien.TaiKhoan;
                    txtHoVaTen.Text         = obj_NhanVien.HoVaTen;
                    txtDiaChi.Text          = obj_NhanVien.DiaChi;
                    txtSDT.Text             = obj_NhanVien.SDT;
                    txtCMT.Text             = obj_NhanVien.CMT;
                    if (Convert.ToBoolean(obj_NhanVien.GioiTinh))
                        chkGioiTinh.EditValue = 1;
                    else
                        chkGioiTinh.EditValue = 0;
                    dateNgaySinh.EditValue  = obj_NhanVien.NgaySinh;
                    txtSDT.Text             = obj_NhanVien.SDT;
                    //txtMatKhauCu.Text     = obj_NhanVien.MatKhau;
                    txtEmail.Text           = obj_NhanVien.Email;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }
        #endregion

        #region events
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(dxValidate.Validate())
            {
                try
                {
                    if (nhanvien_ID > 0) // Cập nhật
                    {

                        obj_NhanVien.HoVaTen    = txtHoVaTen.Text;
                        obj_NhanVien.Email      = txtEmail.Text;
                        obj_NhanVien.DiaChi     = txtDiaChi.Text;
                        obj_NhanVien.SDT        = txtSDT.Text;
                        obj_NhanVien.CMT        = txtCMT.Text;
                        obj_NhanVien.GioiTinh   = Convert.ToBoolean(chkGioiTinh.EditValue);
                        obj_NhanVien.NgaySinh   = Convert.ToDateTime(dateNgaySinh.EditValue);
                        obj_NhanVien.SDT        = txtSDT.Text;
                        obj_NhanVien.HinhAnh    = picHinhAnh.Image.ToString();
                        if (txtMatKhauMoi.Text.Trim() != "")
                        {
                            if( txtMatKhauMoi.Text.Trim().Length < 6)
                            {
                                MessageBox.Show("Mật khẩu mới phải có số ký tự >= 6");
                                txtMatKhauMoi.Focus();
                            }
                            else
                            {
                                MD5 md5Hash = MD5.Create();
                                string matKhau_moi = Helpers.StringClearFormat.GetMd5Hash(md5Hash, txtMatKhauMoi.Text);
                                string matKhau_cu = Helpers.StringClearFormat.GetMd5Hash(md5Hash, txtMatKhauCu.Text);

                                if (txtMatKhauCu.Text.Length > 0 && !matKhau_cu.Equals(obj_NhanVien.MatKhau))
                                {
                                    MessageBox.Show("Mật khẩu cũ không đúng");
                                    txtMatKhauCu.Focus();
                                }
                                else
                                {
                                    obj_NhanVien.MatKhau = matKhau_moi;
                                }
                            }
                        }


                        rpo_NhanVien.Save(obj_NhanVien);
                        MessageBox.Show("Cập nhật thành công");

                        this.Close();
                    }
                    
                }
                catch (Exception)
                {
                    MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
                }
               
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpAnh_Click(object sender, EventArgs e)
        {
            ofdHinhAnh.Title = "Chọn ảnh";
            //ofdHinhAnh.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            ofdHinhAnh.Filter = "Images files (*.png or .jpg)|.png;*.jpg";

            string appPath = Environment.CurrentDirectory + @"\Images\Avatars\";                // <---
            if (Directory.Exists(appPath) == false)                                              // <---
            {                                                                                    // <---
                Directory.CreateDirectory(appPath);                                              // <---
            }                                                                                    // <---

            if (ofdHinhAnh.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string iName = ofdHinhAnh.SafeFileName;   // <---
                    string filepath = ofdHinhAnh.FileName;    // <---
                    File.Copy(filepath, appPath + iName); // <---
                    picHinhAnh.Image = new Bitmap(ofdHinhAnh.OpenFile());
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Unable to open file " + exp.Message);
                }
            }
            else
            {
                ofdHinhAnh.Dispose();
            }
        }

        #endregion
    }
}