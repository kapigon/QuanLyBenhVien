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
    public partial class frmThemThuoc : DevExpress.XtraEditors.XtraForm
    {
        #region params
        Thuoc       obj_Thuoc   = new Thuoc();

        ThuocRepository         rpo_Thuoc       = new ThuocRepository();
        NhomThuocRepository     rpo_NhomThuoc   = new NhomThuocRepository();
        DVTRepository           rpo_DVT         = new DVTRepository();
        CT_DonViTinhRepository  rpo_CT_DVT      = new CT_DonViTinhRepository();
        HoatChatRepository      rpo_HoatChat    = new HoatChatRepository();
        HangSanXuatRepository   rpo_HangSX      = new HangSanXuatRepository();
        NuocSanXuatRepository   rpo_NuocSX      = new NuocSanXuatRepository();
        List<CT_DonViTinh>      lstCT_DVT       = new List<CT_DonViTinh>();
        bool isUpdate = false;
        long thuoc_ID;


        #endregion

        public frmThemThuoc()
        {
            InitializeComponent();
        }
        #region methods
        private void LoadAllCombobox()
        {
            try
            {
                /// Nhóm Thuốc
                cbbNhomThuoc.Properties.DataSource = rpo_NhomThuoc.GetAll().ToList();
                cbbNhomThuoc.Properties.DisplayMember = "TenNhom";
                cbbNhomThuoc.Properties.ValueMember = "ID";

                /// Đơn Vị Tính Nguyên - Lẻ
                //cbbDonViNguyen.Properties.DataSource = rpo_DVT.GetAll().ToList();
                //cbbDonViNguyen.Properties.DisplayMember = "TenDVT";
                //cbbDonViNguyen.Properties.ValueMember = "ID";

                //cbbDonViLe.Properties.DataSource = rpo_DVT.GetAll().ToList();
                //cbbDonViLe.Properties.DisplayMember = "TenDVT";
                //cbbDonViLe.Properties.ValueMember = "ID";

                cbbDonViQuyChuan.Properties.DisplayMember = "TenDVT";
                cbbDonViQuyChuan.Properties.ValueMember = "ID";

                /// Hãng Sản Xuất
                cbbHangSanXuat.Properties.DataSource = rpo_HangSX.GetAll().ToList();
                cbbHangSanXuat.Properties.DisplayMember = "TenHangSX";
                cbbHangSanXuat.Properties.ValueMember = "ID";
                ///Nước sản xuất
                cbbNuocSanXuat.Properties.DataSource = rpo_NuocSX.GetAll().ToList();
                cbbNuocSanXuat.Properties.DisplayMember = "TenNuoc";
                cbbNuocSanXuat.Properties.ValueMember = "ID";

                /// Hoạt Chất
                cbbHoatChat.Properties.DataSource = rpo_HoatChat.GetAll().ToList();
                cbbHoatChat.Properties.DisplayMember = "TenHoatChat";
                cbbHoatChat.Properties.ValueMember = "ID";
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }

        }

        public void loadData(long id){
            try
            {
                obj_Thuoc = rpo_Thuoc.GetSingle(id);

                txtTenThuoc.Text            = obj_Thuoc.TenThuoc;
                txtMaThuoc.Text             = obj_Thuoc.MaThuoc;
                cbbNhomThuoc.EditValue      = obj_Thuoc.NhomThuoc_ID;
                //cbbDonViNguyen.EditValue    = obj_Thuoc.DVT_Nguyen_ID;
                cbbDonViQuyChuan.EditValue        = obj_Thuoc.DVT_Le_ID;
                cbbHangSanXuat.EditValue    = obj_Thuoc.HangSanXuat_ID;
                cbbNuocSanXuat.EditValue    = obj_Thuoc.NuocSanXuat_ID;
                cbbHoatChat.EditValue       = obj_Thuoc.HoatChat_ID;
                //txtQuyCach.Text             = obj_Thuoc.QuyCach.ToString();
                txtTonKho.Text              = obj_Thuoc.TonKho.ToString();        
                txtTonKhoToiThieu.Text      = obj_Thuoc.TonKhoToiThieu.ToString();
                txtCanhBaoHetHan.Text       = obj_Thuoc.ThoiGianCanhBaoHetHan.ToString();
                txtGiaBanLe.Text            = obj_Thuoc.GiaBanLe.ToString();
                txtGiaBanBuon.Text          = obj_Thuoc.GiaBanBuon.ToString();
                chkKichHoat.EditValue       = obj_Thuoc.KichHoat;

                thuoc_ID = id;
                btnLuu.Text = "Cập nhật";
                isUpdate = true;

                List<dynamic> lstDVT = rpo_CT_DVT.GetAllByThuocID(id).ToList();
                cbbDonViQuyChuan.Properties.DataSource = lstDVT.Where(p=>p.KichHoat == true);
                cbbDonViQuyChuan.Properties.DisplayMember = "TenDVT";
                cbbDonViQuyChuan.Properties.ValueMember = "DVT_ID";

                lstCT_DVT = new List<CT_DonViTinh>();
                for (int i = 0; i < lstDVT.Count; i++)
                {
                    CT_DonViTinh _obj = new CT_DonViTinh();
                    _obj.ID         = lstDVT[i].ID;
                    _obj.Thuoc_ID   = lstDVT[i].Thuoc_ID;
                    _obj.DVT_ID     = lstDVT[i].DVT_ID;
                    _obj.QuyDoi     = lstDVT[i].QuyDoi;
                    _obj.TenDVT     = lstDVT[i].TenDVT;
                    _obj.KichHoat   = lstDVT[i].KichHoat;

                    lstCT_DVT.Add(_obj);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }

        public void setValueLookUpEdit(List<CT_DonViTinh> _lstCT_DVT)
        {
            cbbDonViQuyChuan.Properties.DataSource = _lstCT_DVT.Where(p => p.KichHoat == true);
            lstCT_DVT = _lstCT_DVT;
        }

        #endregion

        #region events
        private void frmThemThuoc_Load(object sender, EventArgs e)
        {
            /// Load hết dữ liệu đổ vào tất cả combobox
            LoadAllCombobox();
            txtTonKho.Text = obj_Thuoc.TonKho.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
           
            if (dxValidate.Validate())
            {
                
                obj_Thuoc.TenThuoc              = txtTenThuoc.Text.Trim();
                obj_Thuoc.MaThuoc               = txtMaThuoc.Text.Trim();
                obj_Thuoc.NhomThuoc_ID          = Convert.ToInt32(cbbNhomThuoc.EditValue);
                //obj_Thuoc.DVT_Nguyen_ID         = Convert.ToInt32(cbbDonViNguyen.EditValue);
                obj_Thuoc.DVT_Le_ID             = Convert.ToInt32(cbbDonViQuyChuan.EditValue);
                obj_Thuoc.HangSanXuat_ID        = Convert.ToInt32(cbbHangSanXuat.EditValue);
                obj_Thuoc.NuocSanXuat_ID        = Convert.ToInt32(cbbNuocSanXuat.EditValue);
                obj_Thuoc.HoatChat_ID           = Convert.ToInt32(cbbHoatChat.EditValue);
                //obj_Thuoc.QuyCach               = Convert.ToInt32(txtQuyCach.Text.Trim());
                //obj_Thuoc.TonKho                = Convert.ToInt32(txtTonKho.Text.Trim());
                obj_Thuoc.TonKhoToiThieu        = txtTonKhoToiThieu.Text != "" ? Convert.ToInt32(txtTonKhoToiThieu.EditValue) : 0;
                obj_Thuoc.ThoiGianCanhBaoHetHan = txtCanhBaoHetHan.Text != ""? Convert.ToInt32(txtCanhBaoHetHan.Text) : 0;
                obj_Thuoc.GiaBanLe              = txtGiaBanLe.Text != "" ? Convert.ToDouble(txtGiaBanLe.Text) : 0;
                obj_Thuoc.GiaBanBuon            = txtGiaBanBuon.Text != "" ? Convert.ToDouble(txtGiaBanBuon.Text) : 0;
                obj_Thuoc.KichHoat              = Convert.ToBoolean(chkKichHoat.EditValue);

                try
                {
                    if (!isUpdate)
                    {
                        rpo_Thuoc.Create(obj_Thuoc);
                        //db.Thuoc.Create(obj_Thuoc);
                    }
                    else
                    {
                        rpo_Thuoc.Save(obj_Thuoc);
                    }

                    if (lstCT_DVT.Count > 0)
                    {
                        for (int i = 0; i < lstCT_DVT.Count; i++)
                        {
                            if (lstCT_DVT[i].ID != null && lstCT_DVT[i].ID > 0)
                            {
                                CT_DonViTinh obj = rpo_CT_DVT.GetSingle(lstCT_DVT[i].ID);
                                obj.Thuoc_ID    = lstCT_DVT[i].Thuoc_ID;
                                obj.DVT_ID      = lstCT_DVT[i].DVT_ID;
                                obj.QuyDoi      = lstCT_DVT[i].QuyDoi;
                                obj.TenDVT      = lstCT_DVT[i].TenDVT;
                                obj.KichHoat    = lstCT_DVT[i].KichHoat;

                                rpo_CT_DVT.Save(obj);
                            }
                            else
                            {
                                lstCT_DVT[i].Thuoc_ID = obj_Thuoc.ID;
                                rpo_CT_DVT.Create(lstCT_DVT[i]);
                            }
                        }
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
        
        private void cbbNhomThuoc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind.ToString() == "Plus")
            {
                frmNhomThuoc frmNhomThuoc = new frmNhomThuoc();
                frmNhomThuoc.ShowInTaskbar = false;
                frmNhomThuoc.ShowDialog();
            }
        }

        private void cbbHangSanXuat_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind.ToString() == "Plus")
            {
                frmHangSanXuat frmHangSanXuat = new frmHangSanXuat();
                frmHangSanXuat.ShowInTaskbar = false;
                frmHangSanXuat.ShowDialog();
            }
        }

        private void txtTenThuoc_Leave(object sender, EventArgs e)
        {
            if (txtTenThuoc.Text != "" && txtTenThuoc.Text.Length >= 3)
            {
                txtMaThuoc.Text = "";
                string maThuoc = Helpers.StringClearFormat.ClearNumberSpecial(txtTenThuoc.Text).Substring(0, 3).ToUpper();

                if (maThuoc != "")
                {
                    try
                    {
                        int soTT = rpo_Thuoc.getCountByMaThuoc(maThuoc);

                        maThuoc = maThuoc + (soTT + 1).ToString("000");

                        txtMaThuoc.Text = maThuoc;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
                    }
                }
            }
        }

        private void cbbNuocSanXuat_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind.ToString() == "Plus")
            {
                frmNuocSanXuat frmNuocSanXuat = new frmNuocSanXuat();
                frmNuocSanXuat.ShowInTaskbar = false;
                frmNuocSanXuat.ShowDialog();
            }
        }

        private void cbbHoatChat_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind.ToString() == "Plus")
            {
                frmHoatChat frmHoatChat = new frmHoatChat();
                frmHoatChat.ShowInTaskbar = false;
                frmHoatChat.ShowDialog();
            }
        }

        private void cbbDonViQuyChuan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind.ToString() == "Plus")
            {
                frmDonViTinh_QuyDoi frmDonViTinh_QuyDoi = new frmDonViTinh_QuyDoi(this);
                frmDonViTinh_QuyDoi.LoadData(lstCT_DVT);
                frmDonViTinh_QuyDoi.ShowInTaskbar = false;
                frmDonViTinh_QuyDoi.ShowDialog();
            }
        }
        #endregion     
    }
}