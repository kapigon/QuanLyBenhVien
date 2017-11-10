using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using QLBV_DEV.Repository;

namespace QLBV_DEV
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        NhanVienRepository  rpo_NhanVien = new NhanVienRepository();
        NhanVien            obj_NhanVien = new NhanVien();

        int sodon_trongngay         = 0;
        int sodon_chohuy_trongngay  = 0;
        int sodon_dahuy_trongngay   = 0;
        int thuoc_can_date          = 0;
        int thuoc_sap_het = 0;
        //frmPhieuNhapThuoc   frmPhieuNhapThuoc   = new frmPhieuNhapThuoc();
        //frmDSPhieuNhap      frmDSPhieuNhap      = new frmDSPhieuNhap();
        //frmDSPhieuXuat      frmDSPhieuXuat      = new frmDSPhieuXuat();
        //frmThemNCC_KH       frmThemNCC_KH       = new frmThemNCC_KH();
        //frmThemThuoc        frmThemThuoc        = new frmThemThuoc();
        //frmDSNCC_KH         frmDSNCC_KH         = new frmDSNCC_KH();
        //frmNuocSanXuat      frmNuocSanXuat      = new frmNuocSanXuat();
        //frmHoatChat         frmHoatChat         = new frmHoatChat();
        //frmNhomThuoc        frmNhomThuoc        = new frmNhomThuoc();
        //frmDonViTinh        frmDonViTinh        = new frmDonViTinh();
        //frmKho              frmKho              = new frmKho();
        //frmHangSanXuat      frmHangSanXuat      = new frmHangSanXuat();
        //frmViTri            frmViTri            = new frmViTri();
        //frmDS_Thuoc         frmDS_Thuoc         = new frmDS_Thuoc();
        //frmPhieuXuatThuoc   frmPhieuXuatThuoc   = new frmPhieuXuatThuoc();
        //frmDSThuocCanDate   frmDSThuocCanDate   = new frmDSThuocCanDate();
        //frmThuocCanDate_tungloai frmThuocCanDate_tungloai = new frmThuocCanDate_tungloai();
        //frmTonKhoTheoLo     frmTonKhoTheoLo     = new frmTonKhoTheoLo();
        //frmTonKhoTheoThuoc  frmTonKhoTheoThuoc  = new frmTonKhoTheoThuoc();
        //frmTonKhoToiThieu   frmTonKhoToiThieu   = new frmTonKhoToiThieu();
        //frmKiemKe           frmKiemKe           = new frmKiemKe();
        //frmCanhbaotrangchu  frmCanhbaotrangchu  = new frmCanhbaotrangchu();
        //frmDSPhieuXuatHuy   frmDSPhieuXuatHuy   = new frmDSPhieuXuatHuy();


        //private void close_form(object sender, FormClosedEventArgs e)
        //{
        //    frmPhieuNhapThuoc       = new frmPhieuNhapThuoc();
        //    frmDSPhieuNhap          = new frmDSPhieuNhap();
        //    frmDSPhieuXuat          = new frmDSPhieuXuat();
        //    frmThemNhaCungCap       = new frmThemNCC_KH();
        //    frmThemThuoc            = new frmThemThuoc();
        //    frmDSNCC_KH             = new frmDSNCC_KH();
        //    frmNuocSanXuat          = new frmNuocSanXuat();
        //    frmHoatChat             = new frmHoatChat();
        //    frmNhomThuoc            = new frmNhomThuoc();
        //    frmDonViTinh            = new frmDonViTinh();
        //    frmViTri                = new frmKho();
        //    frmHangSanXuat          = new frmHangSanXuat();
        //    frmKho                  = new frmKho();
        //    frmPhieuXuatThuoc       = new frmPhieuXuatThuoc();
        //    frmDSThuocCanDate       = new frmDSThuocCanDate();
        //    frmThuoCanDate_tungloai = new frmThuocCanDate_tungloai();
        //    frmTonKhoTheoLo         = new frmTonKhoTheoLo();
        //    frmTonKhoTheoThuoc      = new frmTonKhoTheoThuoc();
        //    frmTonKhoToiThieu       = new frmTonKhoToiThieu();
        //    frmDS_Thuoc             = new frmDS_Thuoc();
        //    frmKiemKe               = new frmKiemKe();
        //    frmCanhbaotrangchu      = new frmCanhbaotrangchu();
        //}
        private Dictionary<Type, Form> ActiveForms;

        public frmMain()
        {

            InitializeComponent();
            this.ActiveForms = new Dictionary<Type, Form>();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");
            LoadCanhBaoTrangChu();

            obj_NhanVien = QLBV_DEV.Helpers.LoginInfo.nhanVien;
            barUserName.Caption = obj_NhanVien.TaiKhoan;

            LoadBaoCao();
        }

        
        private void ShowForm<TSource>() where TSource : Form
        {
            Form form = null;

            if (this.ActiveForms.ContainsKey(typeof(TSource)))
            {
                form = this.ActiveForms[typeof(TSource)];
                form.Activate();
            }
            else
            {
                form = Activator.CreateInstance<TSource>();
                form.MdiParent = this;
                //form.FormClosed += form_FormClosed;
                form.FormClosed += (sender1, eventArgs) =>
                {
                    this.ActiveForms.Remove(form.GetType());
                    form = Activator.CreateInstance<TSource>();
                };
                form.Show();

                this.ActiveForms.Add(typeof(TSource), form);
            }
        }

        private void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            this.ActiveForms.Remove(sender.GetType());
        }
        /// Reload Form 
        public frmMain(int type)
        {
            //if (type == 1)
            //    frmPhieuNhapThuoc = new frmPhieuNhapThuoc();
            //else if (type == 2)
            //    frmDSPhieuNhap = new frmDSPhieuNhap();
            //else if (type == 3)
            //    frmDSPhieuXuat = new frmDSPhieuXuat();
            //else
            //{
            //    frmThemNCC_KH = new frmThemNCC_KH();
            //    frmThemThuoc = new frmThemThuoc();
            //    frmDSNCC_KH = new frmDSNCC_KH();
            //    frmNuocSanXuat = new frmNuocSanXuat();
            //    frmHoatChat = new frmHoatChat();
            //    frmNhomThuoc = new frmNhomThuoc();
            //    frmDonViTinh = new frmDonViTinh();
            //    frmViTri = new frmViTri();
            //    frmHangSanXuat = new frmHangSanXuat();
            //    frmKho = new frmKho();
            //    frmPhieuXuatThuoc = new frmPhieuXuatThuoc();
            //    frmDSThuocCanDate = new frmDSThuocCanDate();
            //    frmThuocCanDate_tungloai = new frmThuocCanDate_tungloai();
            //    frmTonKhoTheoLo = new frmTonKhoTheoLo();
            //    frmTonKhoTheoThuoc = new frmTonKhoTheoThuoc();
            //    frmTonKhoToiThieu = new frmTonKhoToiThieu();
            //    frmDS_Thuoc = new frmDS_Thuoc();
            //    frmKiemKe = new frmKiemKe();
            //    frmCanhbaotrangchu = new frmCanhbaotrangchu();
            //}

        }

        //--------------------------------------------------------------------------------
        //Kiểm tra đã bật Tab Form chưa
        public Form kiemtraform(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == ftype)
                {
                    return f;
                }
            }
            return null;
        }
        //--------------------------------------------------------------------------------
        private void LoadCanhBaoTrangChu()
        {
            this.ShowForm<frmCanhbaotrangchu>();
        }
        //---------------------------------------------------------------------------------

        private void btnTaoPhieuNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmPhieuNhapThuoc>();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnDSPhieuNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmDSPhieuNhap>();
            //Form frm = kiemtraform(typeof(frmDSPhieuNhap));
            //if (frm == null)
            //{
            //    frmDSPhieuNhap.MdiParent = this;
            //    frmDSPhieuNhap.FormClosed += (sender1, eventArgs) => { frmDSPhieuNhap = new frmDSPhieuNhap(); };
            //    frmDSPhieuNhap.Show();
            //}
            //else
            //{
            //    frm.Activate();
            //}
        }

        private void btnThemNhaCungCap_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmThemNCC_KH>();
        }

        private void btnThemThuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmThemThuoc>();
        }

        public void btnDSNhaCungCap_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmDSNCC_KH>();
        }

        private void btnDSNuocSanXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmNuocSanXuat>();
        }

        private void btnHoatChat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmHoatChat>();
        }

        private void btnDonViTinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmKho>();
        }

        private void btnNhomThuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmNhomThuoc>();
        }

        private void btnViTri_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmViTri>();
        }

        private void btnHangSanXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmHangSanXuat>();
        }

        private void btnKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmKho>();
        }

        private void btnDSThuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmDS_Thuoc>();
        }

        private void btnTaoPhieuXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmPhieuXuatThuoc>();
        }

        private void btnCanDate1_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmDSThuocCanDate>();
        }

        private void btnThuocCanDate_tungloai_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmThuocCanDate_tungloai>();
        }

        private void btnTonKhoTheoLo_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmTonKhoTheoLo>();
        }

        private void btnTonKhoTheoThuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmTonKhoTheoThuoc>();
        }

        private void btnTonkhoToiThieu_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmTonKhoToiThieu>();
        }

        private void btnDSPhieuXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmDSPhieuXuat>();
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmKiemKe>();
        }


        private void btnDSPhieuXuatHuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmDSPhieuXuatHuy>();
        }

        private void btnBC_Nhapxuatton_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmBangKeChiTietNhap_Xuat_Ton>();
        }

        private void btnBC_Xuatthuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmBangKeChiTietXuat>();
        }

        private void btnBC_Nhapthuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmBangKeChiTietNhap>();
        }

        private void btnCanhbao_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmCanhbaotrangchu>();
            LoadBaoCao();
        }

        private void btnThuocBanTheoNgay_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmBaoCaoNgay>();
        }

        private void btnGiaBan_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmCapNhatGia>();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Bạn chắc chắn muốn thoát khỏi chương trình.?", "Xác nhận thoát chương trình", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    Application.Exit();
                else
                    e.Cancel = true;
            }
        }

        private void LoadBaoCao()
        {
            try
            {
                PhieuXuatThuocRepository rpo_PhieuXuat = new PhieuXuatThuocRepository();
                sodon_trongngay         = rpo_PhieuXuat.getTongSoDonBanHomNay();
                sodon_chohuy_trongngay  = rpo_PhieuXuat.getTongSoDonChoHuyHomNay();
                sodon_dahuy_trongngay   = rpo_PhieuXuat.getTongSoDonDaHuyHomNay();

                CT_Thuoc_PhieuNhapRepository rpo_CT_PhieuNhap = new CT_Thuoc_PhieuNhapRepository();
                thuoc_can_date          = rpo_CT_PhieuNhap.ThuocCanDate().Count();

                ThuocRepository rpo_Thuoc   = new ThuocRepository();
                thuoc_sap_het               = rpo_Thuoc.TonKhoToiThieu().Count();

                /// Tổng số đơn BÁN hàng trong ngày
                btnSoDonBanHomNay.Caption       = "Tổng đơn bán: (" + sodon_trongngay + ")";

                /// Tổng số đơn CHỜ HỦY hàng trong ngày
                btnSoDonChoHuyHomNay.Caption    = "Tổng đơn chờ hủy: (" + sodon_chohuy_trongngay + ")";

                /// Tổng số đơn ĐÃ HỦY hàng trong ngày
                btnSoDonDaHuyHomNay.Caption     = "Tổng đơn đã hủy: (" + sodon_dahuy_trongngay + ")";

                // Tổng số thuốc CẬN DATE
                btnSapHetHan.Caption            = "Sắp hết hạn: (" + thuoc_can_date + ")";

                // Tổng số thuốc sắp hết trong kho
                btnSapHetTrongKho.Caption       = "Sắp hết trong kho: (" + thuoc_sap_het + ")";


            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }

        private void btnUserInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (obj_NhanVien.ID > 0)
            {
                frmThongTinNguoiDung frmUserInfo = new frmThongTinNguoiDung();
                frmUserInfo.loadData(obj_NhanVien.ID);
                frmUserInfo.ShowInTaskbar = false;
                frmUserInfo.ShowDialog();
            }
            else
            {
                this.Hide();
                frmLogin frmLogin = new frmLogin();
                frmLogin.Show();
            }
        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
        }

        private void btnSoDonBanHomNay_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (sodon_trongngay > 0)
            {
                frmDSPhieuXuat frmDSPhieuXuat = new frmDSPhieuXuat();
                frmDSPhieuXuat.LoadDS_SoDon_HomNay(DateTime.Today);
                frmDSPhieuXuat.ShowInTaskbar = false;
                frmDSPhieuXuat.ShowDialog();
            }
        }

        private void btnSoDonChoHuyHomNay_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (sodon_chohuy_trongngay > 0)
            {
                frmDSPhieuXuatHuy frmDSPhieuXuatHuy = new frmDSPhieuXuatHuy();
                frmDSPhieuXuatHuy.LoadDS_SoDon_ChoHuy_HomNay(DateTime.Today);
                frmDSPhieuXuatHuy.ShowInTaskbar = false;
                frmDSPhieuXuatHuy.ShowDialog();
            }
        }

        private void btnHetHan_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (thuoc_can_date > 0)
            {
                frmThuocCanDate_tungloai frm = new frmThuocCanDate_tungloai();
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
        }

        private void btnHetTrongKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (thuoc_sap_het > 0)
            {
                frmTonKhoToiThieu frm = new frmTonKhoToiThieu();
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
        } 
    }
}