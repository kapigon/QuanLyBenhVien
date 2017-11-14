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

namespace QLBV_DEV
{
    public partial class frmThongTinChung : DevExpress.XtraEditors.XtraForm
    {
        ThongTinChungRepository rpo_ThongTinChung = new ThongTinChungRepository();
        ThongTinChung obj_ThongTinChung = new ThongTinChung();

        int thongtinchung_ID = 0;

        public frmThongTinChung()
        {
            InitializeComponent();
            loadData(1);
        }


        #region methods
       
        public void loadData(int ID)
        {
            try
            {
                thongtinchung_ID = ID;
                obj_ThongTinChung = rpo_ThongTinChung.GetSingle(ID);

                if (ID > 0)
                {
                    txtTenNhaThuoc.Text         = obj_ThongTinChung.Ten;
                    //imgHinhAnh
                    txtDiaChi.Text              = obj_ThongTinChung.DiaChi;
                    txtSDT.Text                 = obj_ThongTinChung.SDT;
                    txtEmail.Text               = obj_ThongTinChung.Email;
                    txtMST.Text                 = obj_ThongTinChung.MST;
                    txtWebsite.Text             = obj_ThongTinChung.Website;
                    txtTaiKhoanNganHang.Text    = obj_ThongTinChung.TaiKhoan;
                    txtNganHang.Text            = obj_ThongTinChung.NganHang;
                    txtNguoiPhuTrach.Text       = obj_ThongTinChung.NguoiPhuTrach;
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
                    if (thongtinchung_ID > 0) // Cập nhật
                    {

                        obj_ThongTinChung.Ten               = txtTenNhaThuoc.Text;
                        //imgHinhAnh
                        obj_ThongTinChung.DiaChi            = txtDiaChi.Text;
                        obj_ThongTinChung.SDT               = txtSDT.Text;
                        obj_ThongTinChung.Email             = txtEmail.Text;
                        obj_ThongTinChung.MST               = txtMST.Text;
                        obj_ThongTinChung.Website           = txtWebsite.Text;
                        obj_ThongTinChung.TaiKhoan          = txtTaiKhoanNganHang.Text;
                        obj_ThongTinChung.NganHang          = txtNganHang.Text;
                        obj_ThongTinChung.NguoiPhuTrach     = txtNguoiPhuTrach.Text;
                        
                        rpo_ThongTinChung.Save(obj_ThongTinChung);
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
        #endregion
    }
}