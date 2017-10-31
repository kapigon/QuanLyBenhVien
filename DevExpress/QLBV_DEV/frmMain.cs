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
        NhanVienRepository rpo_NhanVien = new NhanVienRepository();
        NhanVien obj_NhanVien = new NhanVien();
                
        frmPhieuNhapThuoc   frmPhieuNhapThuoc   = new frmPhieuNhapThuoc();
        frmDSPhieuNhap      frmDSPhieuNhap      = new frmDSPhieuNhap();
        frmDSPhieuXuat      frmDSPhieuXuat      = new frmDSPhieuXuat();
        frmThemNCC_KH       frmThemNCC_KH       = new frmThemNCC_KH();
        frmThemThuoc        frmThemThuoc        = new frmThemThuoc();
        frmDSNCC_KH         frmDSNCC_KH         = new frmDSNCC_KH();
        frmNuocSanXuat      frmNuocSanXuat      = new frmNuocSanXuat();
        frmHoatChat         frmHoatChat         = new frmHoatChat();
        frmNhomThuoc        frmNhomThuoc        = new frmNhomThuoc();
        frmDonViTinh        frmDonViTinh        = new frmDonViTinh();
        frmKho              frmKho              = new frmKho();
        frmHangSanXuat      frmHangSanXuat      = new frmHangSanXuat();
        frmViTri            frmViTri            = new frmViTri();
        frmDS_Thuoc         frmDS_Thuoc         = new frmDS_Thuoc();
        frmPhieuXuatThuoc   frmPhieuXuatThuoc   = new frmPhieuXuatThuoc();
        frmDSThuocCanDate   frmDSThuocCanDate   = new frmDSThuocCanDate();
        frmThuocCanDate_tungloai frmThuocCanDate_tungloai = new frmThuocCanDate_tungloai();
        frmTonKhoTheoLo     frmTonKhoTheoLo     = new frmTonKhoTheoLo();
        frmTonKhoTheoThuoc  frmTonKhoTheoThuoc  = new frmTonKhoTheoThuoc();
        frmTonKhoToiThieu   frmTonKhoToiThieu   = new frmTonKhoToiThieu();
        frmKiemKe           frmKiemKe           = new frmKiemKe();
        frmCanhbaotrangchu  frmCanhbaotrangchu  = new frmCanhbaotrangchu();
        frmDSPhieuXuatHuy   frmDSPhieuXuatHuy   = new frmDSPhieuXuatHuy();


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
                form.FormClosed += (sender1, eventArgs) => {
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
            if (type == 1)
                frmPhieuNhapThuoc = new frmPhieuNhapThuoc();
            else if (type == 2)
                frmDSPhieuNhap = new frmDSPhieuNhap();
            else if (type == 3)
                frmDSPhieuXuat = new frmDSPhieuXuat();
            else
            {
                frmThemNCC_KH = new frmThemNCC_KH();
                frmThemThuoc = new frmThemThuoc();
                frmDSNCC_KH = new frmDSNCC_KH();
                frmNuocSanXuat = new frmNuocSanXuat();
                frmHoatChat = new frmHoatChat();
                frmNhomThuoc = new frmNhomThuoc();
                frmDonViTinh = new frmDonViTinh();
                frmViTri = new frmViTri();
                frmHangSanXuat = new frmHangSanXuat();
                frmKho = new frmKho();
                frmPhieuXuatThuoc = new frmPhieuXuatThuoc();
                frmDSThuocCanDate = new frmDSThuocCanDate();
                frmThuocCanDate_tungloai = new frmThuocCanDate_tungloai();
                frmTonKhoTheoLo = new frmTonKhoTheoLo();
                frmTonKhoTheoThuoc = new frmTonKhoTheoThuoc();
                frmTonKhoToiThieu = new frmTonKhoToiThieu();
                frmDS_Thuoc = new frmDS_Thuoc();
                frmKiemKe = new frmKiemKe();
                frmCanhbaotrangchu = new frmCanhbaotrangchu();
            }

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
            this.ShowForm<frmKho>();
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

        private void ribbon_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDSPhieuXuatHuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm<frmDSPhieuXuatHuy>();
        }
    }
}