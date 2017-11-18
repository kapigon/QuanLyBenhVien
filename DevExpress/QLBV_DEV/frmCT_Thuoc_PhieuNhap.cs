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
    public partial class frmCT_Thuoc_PhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        ///  Repository
        /// </summary>
        ThuocRepository                 rpo_Thuoc       = new ThuocRepository();
        NhomThuocRepository             rpo_NhomThuoc   = new NhomThuocRepository();
        DVTRepository                   rpo_DVT         = new DVTRepository();
        HoatChatRepository              rpo_HoatChat    = new HoatChatRepository();
        HangSanXuatRepository           rpo_HangSX      = new HangSanXuatRepository();
        KhoRepository                   rpo_Kho         = new KhoRepository();
        ViTriRepository                 rpo_ViTri       = new ViTriRepository();
        CT_Thuoc_PhieuNhapRepository    rpo_CT_Thuoc    = new CT_Thuoc_PhieuNhapRepository();
        CT_DonViTinhRepository          rpo_CT_DVT      = new CT_DonViTinhRepository();
                
        private frmPhieuNhapThuoc frmPhieuNhapThuoc;

        //CT_Thuoc_PhieuNhap      obj_CT_Thuoc    = new CT_Thuoc_PhieuNhap();
        int index;
        public frmCT_Thuoc_PhieuNhap()
        {
            InitializeComponent();
        }

        public frmCT_Thuoc_PhieuNhap(frmPhieuNhapThuoc _frmPhieuNhapThuoc)
        {
            this.frmPhieuNhapThuoc = _frmPhieuNhapThuoc;
            InitializeComponent();
        }

        #region methods
        private void setReadOnlyField(bool value)
        {
            txtMaThuoc.ReadOnly = value;
            cbbNhomThuoc.ReadOnly = value;
            cbbDonViNguyen.ReadOnly = value;
            cbbDonViLe.ReadOnly = value;
            cbbHangSanXuat.ReadOnly = value;
            cbbHoatChat.ReadOnly = value;
            txtQuyCach.ReadOnly = value;
            txtTonKho.ReadOnly = value;
            txtTonKhoToiThieu.ReadOnly = value;
            txtGiaBanLe.ReadOnly = value;
            txtGiaBanBuon.ReadOnly = value;
            txtCanhBaoHetHan.ReadOnly = value;
            chkKichHoat.ReadOnly = value;
        }

        private void LoadAllCombobox()
        {
            try
            {
                /// Thuốc
                cbbTenThuoc.Properties.DataSource = rpo_Thuoc.GetAll().ToList();
                cbbTenThuoc.Properties.DisplayMember = "TenThuoc";
                cbbTenThuoc.Properties.ValueMember = "ID";

                /// Nhóm Thuốc
                cbbNhomThuoc.Properties.DataSource = rpo_NhomThuoc.GetAll().ToList();
                cbbNhomThuoc.Properties.DisplayMember = "TenNhom";
                cbbNhomThuoc.Properties.ValueMember = "ID";

                /// Đơn Vị Tính Nguyên - Lẻ
                cbbDonViNguyen.Properties.DataSource = rpo_DVT.GetAll().ToList();
                cbbDonViNguyen.Properties.DisplayMember = "TenDVT";
                cbbDonViNguyen.Properties.ValueMember = "ID";

                cbbDonViLe.Properties.DataSource = rpo_DVT.GetAll().ToList();
                cbbDonViLe.Properties.DisplayMember = "TenDVT";
                cbbDonViLe.Properties.ValueMember = "ID";

                /// Hãng Sản Xuất
                cbbHangSanXuat.Properties.DataSource = rpo_HangSX.GetAll().ToList();
                cbbHangSanXuat.Properties.DisplayMember = "TenHangSX";
                cbbHangSanXuat.Properties.ValueMember = "ID";

                /// Hoạt Chất
                cbbHoatChat.Properties.DataSource = rpo_HoatChat.GetAll().ToList();
                cbbHoatChat.Properties.DisplayMember = "TenHoatChat";
                cbbHoatChat.Properties.ValueMember = "ID";

                /// Kho
                cbbKho.Properties.DataSource = rpo_Kho.GetAll().ToList();
                cbbKho.Properties.DisplayMember = "TenKho";
                cbbKho.Properties.ValueMember = "ID";

                /// Vị Trí
                cbbViTri.Properties.DataSource = rpo_ViTri.GetAll().ToList();
                cbbViTri.Properties.DisplayMember = "TenViTri";
                cbbViTri.Properties.ValueMember = "ID";

                /// Đơn Vị Bán
                //cbbDonViNhap.Properties.DataSource = rpo_DVT.GetAll().ToList();
                //cbbDonViNhap.Properties.DisplayMember = "TenDVT";
                //cbbDonViNhap.Properties.ValueMember = "ID";
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }

        public void loadData(long thuocID, ref CT_Thuoc_PhieuNhap obj_CT_Thuoc, int row)
        {
            if (thuocID > 0)
            {
                try
                {
                    index = row;
                    Thuoc obj_Thuoc = rpo_Thuoc.GetSingle(thuocID);
                    if (obj_Thuoc != null)
                    {
                        cbbTenThuoc.EditValue = thuocID.ToString();
                    }

                    if (obj_CT_Thuoc != null)
                    {
                        //cbbDonViNhap.EditValue = obj_CT_Thuoc.DVT_Theo_DVT_Thuoc_ID != null ? obj_CT_Thuoc.DVT_Theo_DVT_Thuoc_ID : 0;
                        txtSoLuong.Text = obj_CT_Thuoc.SoLuong.ToString();
                        txtGiaNhap.Text = obj_CT_Thuoc.GiaNhap.ToString();
                        txtBarcode.Text = obj_CT_Thuoc.Barcode;
                        txtSoLo.Text = obj_CT_Thuoc.SoLo != null ? obj_CT_Thuoc.SoLo.ToString() : "";
                        dateHSD.EditValue = obj_CT_Thuoc.HSD != null ? obj_CT_Thuoc.HSD : DateTime.Now;
                        cbbViTri.EditValue = obj_CT_Thuoc.ViTri_ID != null ? obj_CT_Thuoc.ViTri_ID : 0;
                        cbbKho.EditValue = obj_CT_Thuoc.Kho_ID != null ? obj_CT_Thuoc.Kho_ID : 0;
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
                }
            }
        }
        #endregion

        #region events
        private void cbbTenThuoc_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void cbbTenThuoc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind.ToString()=="Plus")
            {
                //MessageBox.Show("Hey");
                frmThemThuoc frmThemThuoc = new frmThemThuoc();
                frmThemThuoc.ShowDialog();
            }
        }
            
        private void frmCT_Thuoc_PhieuNhap_Load(object sender, EventArgs e)
        {
            /// Load hết dữ liệu đổ vào tất cả combobox
            LoadAllCombobox();

            /// Set Các trường khống được sửa
            setReadOnlyField(true);
        }

        private void btnInMaVach_Click(object sender, EventArgs e)
        {

        }

        public void btnLuu_Click(object sender, EventArgs e)
        {
            if (dxValidate.Validate())
            {
                try
                {
                    CT_Thuoc_PhieuNhap obj_CT_Thuoc = new CT_Thuoc_PhieuNhap();

                    int soluong         = txtSoLuong.Text.Trim() != "" ? Convert.ToInt32(txtSoLuong.Text) : 0;
                    double gianhap      = txtGiaNhap.Text.Trim() != "" ? Convert.ToDouble(txtGiaNhap.Text) : 1;
                    double tongTien     = (soluong * gianhap);

                    obj_CT_Thuoc.PhieuNhapHang_ID       = 0;
                    obj_CT_Thuoc.DVT_Theo_DVT_Thuoc_ID  = Convert.ToInt32(cbbDonViNhap.EditValue);
                    obj_CT_Thuoc.Thuoc_ID               = Convert.ToInt64(cbbTenThuoc.EditValue);
                    obj_CT_Thuoc.Kho_ID                 = Convert.ToInt32(cbbKho.EditValue);
                    obj_CT_Thuoc.ViTri_ID               = Convert.ToInt32(cbbViTri.EditValue);
                    obj_CT_Thuoc.Barcode                = txtBarcode.Text.Trim();
                    obj_CT_Thuoc.HSD                    = dateHSD.EditValue != null ? Convert.ToDateTime(dateHSD.EditValue) : Convert.ToDateTime("01/01/0001");
                    obj_CT_Thuoc.GiaNhap                = gianhap;
                    obj_CT_Thuoc.SoLuong                = soluong;
                    obj_CT_Thuoc.TonKho                 = soluong ;
                    obj_CT_Thuoc.SoLo                   = txtSoLo.Text.Trim();
                    obj_CT_Thuoc.TongTien               = Convert.ToDouble(tongTien);
                    obj_CT_Thuoc.NgayNhap               = DateTime.Now;
                
                    this.Close();

                    frmPhieuNhapThuoc.setValueGridControl(obj_CT_Thuoc, index);
                    //rpo_CT_Thuoc.Create(obj_CT_Thuoc);
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
        

        private void txtGiaNhap_EditValueChanged(object sender, EventArgs e)
        {
            int soluong = txtSoLuong.Text.Trim() != "" ? Convert.ToInt32(txtSoLuong.Text) : 1;
            double gianhap = txtGiaNhap.Text.Trim() != "" ? Convert.ToDouble(txtGiaNhap.Text) : 1;
            txtTongTien.Text = (soluong * gianhap).ToString();
        }

        private void txtSoLuong_EditValueChanged(object sender, EventArgs e)
        {
            int soluong = txtSoLuong.Text.Trim() != "" ? Convert.ToInt32(txtSoLuong.Text) : 1;
            double gianhap = txtGiaNhap.Text.Trim() != "" ? Convert.ToDouble(txtGiaNhap.Text) : 1;
            txtTongTien.Text = (soluong * gianhap).ToString();
        }

        private void cbbTenThuoc_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                long thuocID = Convert.ToInt64(cbbTenThuoc.EditValue);
                Thuoc obj_Thuoc = new Thuoc();
                obj_Thuoc = rpo_Thuoc.GetSingle(thuocID);

                if (obj_Thuoc != null)
                {
                    txtBarcode.Text             = obj_Thuoc.Barcode;
                    txtMaThuoc.Text             = obj_Thuoc.MaThuoc;
                    cbbNhomThuoc.EditValue      = obj_Thuoc.NhomThuoc_ID;
                    cbbDonViNguyen.EditValue    = obj_Thuoc.DVT_Nguyen_ID;
                    cbbDonViLe.EditValue        = obj_Thuoc.DVT_Le_ID;
                    cbbHangSanXuat.EditValue    = obj_Thuoc.HangSanXuat_ID;
                    cbbHoatChat.EditValue       = obj_Thuoc.HoatChat_ID;
                    txtQuyCach.Text             = obj_Thuoc.QuyCach.ToString();
                    txtTonKho.Text              = obj_Thuoc.TonKho.ToString();
                    txtTonKhoToiThieu.Text      = obj_Thuoc.TonKhoToiThieu.ToString();
                    txtGiaBanLe.Text            = obj_Thuoc.GiaBanLe.ToString();
                    txtGiaBanBuon.Text          = obj_Thuoc.GiaBanBuon.ToString();
                    txtCanhBaoHetHan.Text       = obj_Thuoc.ThoiGianCanhBaoHetHan.ToString();

                    //cbbDonViNhap.EditValue      = obj_Thuoc.DVT_Le_ID;
                    if (obj_Thuoc.KichHoat != null)
                        chkKichHoat.Checked     = obj_Thuoc.KichHoat.Value;

                    // Load dữ liệu cho cbbDonViNhap
                    DonViTinh dvt = new DonViTinh();
                    dvt.ID = Convert.ToInt32(cbbDonViLe.EditValue);
                    dvt.TenDVT = rpo_DVT.GetSingle(Convert.ToInt32(cbbDonViLe.EditValue)).TenDVT;
                    List<dynamic> lstDVT = rpo_CT_DVT.GetAllByThuocID(obj_Thuoc.ID).ToList();
                    //dynamic item = new dynamic(){ID = "", TenDVT = ""};
                    lstDVT.Add(new
                    {
                        ID = Convert.ToInt32(cbbDonViLe.EditValue),
                        TenDVT = rpo_DVT.GetSingle(Convert.ToInt32(cbbDonViLe.EditValue)).TenDVT.ToString(),
                        QuyDoi = Convert.ToInt64(1)
                    });

                    /// Đơn Vị Bán
                    cbbDonViNhap.Properties.DataSource = lstDVT;
                    cbbDonViNhap.Properties.DisplayMember = "TenDVT";
                    cbbDonViNhap.Properties.ValueMember = "ID";


                }
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
            
            //chkKichHoat.Checked = ((obj_Thuoc.KichHoat != null) ? Convert.ToBoolean(obj_Thuoc.KichHoat.Value) : false);
        }
        #endregion
    }
}