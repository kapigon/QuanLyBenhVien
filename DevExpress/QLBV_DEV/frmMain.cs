using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace QLBV_DEV
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
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

        public frmMain()
        {

            InitializeComponent();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");
            LoadCanhBaoTrangChu();

        }
        //--------------------------------------------------------------------------------
        //Kiểm tra đã bật Tab Form chưa
        private Form kiemtraform(Type ftype)
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
            frmCanhbaotrangchu frmCanhbaotrangchu = new frmCanhbaotrangchu();
            Form frm = kiemtraform(typeof(frmCanhbaotrangchu));
            if (frm == null)
            {
                frmCanhbaotrangchu.MdiParent = this;
                frmCanhbaotrangchu.FormClosed += (sender1, eventArgs) => { frmCanhbaotrangchu = new frmCanhbaotrangchu(); };
                frmCanhbaotrangchu.Show();
            }
            else
            {
                frm.Activate();
            }
        }
        //---------------------------------------------------------------------------------

        private void btnTaoPhieuNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frmPhieuNhapThuoc));
            if (frm == null)
            {
                //frmPhieuNhapThuoc forms = new frmPhieuNhapThuoc();
                frmPhieuNhapThuoc.MdiParent = this;
                frmPhieuNhapThuoc.FormClosed += (sender1, eventArgs) => { frmPhieuNhapThuoc = new frmPhieuNhapThuoc(); };
                frmPhieuNhapThuoc.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnDSPhieuNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frmDSPhieuNhap));
            if (frm == null)
            {
                frmDSPhieuNhap.MdiParent = this;
                frmDSPhieuNhap.FormClosed += (sender1, eventArgs) => { frmDSPhieuNhap = new frmDSPhieuNhap(); };
                frmDSPhieuNhap.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnThemNhaCungCap_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frmThemNCC_KH));
            if (frm == null)
            {
                frmThemNCC_KH.MdiParent = this;
                frmThemNCC_KH.FormClosed += (sender1, eventArgs) => { frmThemNCC_KH = new frmThemNCC_KH(); };
                frmThemNCC_KH.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnThemThuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frmThemThuoc));
            if (frm == null)
            {
                frmThemThuoc.MdiParent = this;
                frmThemThuoc.FormClosed += (sender1, eventArgs) => { frmThemThuoc = new frmThemThuoc(); };
                frmThemThuoc.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnDSNhaCungCap_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frmDSNCC_KH));
            if (frm == null)
            {
                frmDSNCC_KH.MdiParent = this;
                frmDSNCC_KH.FormClosed += (sender1, eventArgs) => { frmDSNCC_KH = new frmDSNCC_KH(); };
                frmDSNCC_KH.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnDSNuocSanXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frmNuocSanXuat));
            if (frm == null)
            {
                frmNuocSanXuat.MdiParent = this;
                frmNuocSanXuat.FormClosed += (sender1, eventArgs) => { frmNuocSanXuat = new frmNuocSanXuat(); };
                frmNuocSanXuat.Show();
                
            }
            else
            {
                frm.Activate();
            }
        }



        private void btnHoatChat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frmHoatChat));
            if (frm == null)
            {
                frmHoatChat.MdiParent = this;
                frmHoatChat.FormClosed += (sender1, eventArgs) => { frmHoatChat = new frmHoatChat(); };
                frmHoatChat.Show();

            }
            else
            {
                frm.Activate();
            }
        }

        private void btnDonViTinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frmKho));
            if (frm == null)
            {
                frmDonViTinh.MdiParent = this;
                frmDonViTinh.FormClosed += (sender1, eventArgs) => { frmDonViTinh = new frmDonViTinh(); };
                frmDonViTinh.Show();

            }
            else
            {
                frm.Activate();
            }
        }

        private void btnNhomThuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frmNhomThuoc));
            if (frm == null)
            {
                frmNhomThuoc.MdiParent = this;
                frmNhomThuoc.FormClosed += (sender1, eventArgs) => { frmNhomThuoc = new frmNhomThuoc(); };
                frmNhomThuoc.Show();

            }
            else
            {
                frm.Activate();
            }
        }

        private void btnViTri_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frmKho));
            if (frm == null)
            {
                frmViTri.MdiParent = this;
                frmViTri.FormClosed += (sender1, eventArgs) => { frmViTri = new frmViTri(); };
                frmViTri.Show();

            }
            else
            {
                frm.Activate();
            }
        }

        private void btnHangSanXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frmHangSanXuat));
            if (frm == null)
            {
                frmHangSanXuat.MdiParent = this;
                frmHangSanXuat.FormClosed += (sender1, eventArgs) => { frmHangSanXuat = new frmHangSanXuat(); };
                frmHangSanXuat.Show();

            }
            else
            {
                frm.Activate();
            }
        }

        private void btnKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frmKho));
            if (frm == null)
            {
                frmKho.MdiParent = this;
                frmKho.FormClosed += (sender1, eventArgs) => { frmKho = new frmKho(); };
                frmKho.Show();

            }
            else
            {
                frm.Activate();
            }
        }

        private void btnDSThuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frmDS_Thuoc));
            if (frm == null)
            {
                frmDS_Thuoc.MdiParent = this;
                frmDS_Thuoc.FormClosed += (sender1, eventArgs) => { frmDS_Thuoc = new frmDS_Thuoc(); }; ;
                frmDS_Thuoc.Show();

            }
            else
            {
                frm.Activate();
            }
        }

        private void btnTaoPhieuXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frmPhieuXuatThuoc));
            if (frm == null)
            {
                frmPhieuXuatThuoc.MdiParent = this;
                frmPhieuXuatThuoc.FormClosed += (sender1, eventArgs) => { frmPhieuXuatThuoc = new frmPhieuXuatThuoc(); };
                frmPhieuXuatThuoc.Show();

            }
            else
            {
                frm.Activate();
            }
        }

        private void btnCanDate1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frmDSThuocCanDate));
            if (frm == null)
            {
                frmDSThuocCanDate.MdiParent = this;
                frmDSThuocCanDate.FormClosed += (sender1, eventArgs) => { frmDSThuocCanDate = new frmDSThuocCanDate(); };
                frmDSThuocCanDate.Show();

            }
            else
            {
                frm.Activate();
            }
        }

        private void btnThuocCanDate_tungloai_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frmThuocCanDate_tungloai));
            if (frm == null)
            {
                frmThuocCanDate_tungloai.MdiParent = this;
                frmThuocCanDate_tungloai.FormClosed += (sender1, eventArgs) => { frmThuocCanDate_tungloai = new frmThuocCanDate_tungloai(); };
                frmThuocCanDate_tungloai.Show();

            }
            else
            {
                frm.Activate();
            }
        }

        private void btnTonKhoTheoLo_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frmTonKhoTheoLo));
            if (frm == null)
            {
                frmTonKhoTheoLo.MdiParent = this;
                frmTonKhoTheoLo.FormClosed += (sender1, eventArgs) => { frmTonKhoTheoLo = new frmTonKhoTheoLo(); };
                frmTonKhoTheoLo.Show();

            }
            else
            {
                frm.Activate();
            }
        }

        private void btnTonKhoTheoThuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frmTonKhoTheoThuoc));
            if (frm == null)
            {
                frmTonKhoTheoThuoc.MdiParent = this;
                frmTonKhoTheoThuoc.FormClosed += (sender1, eventArgs) => { frmTonKhoTheoThuoc = new frmTonKhoTheoThuoc(); };
                frmTonKhoTheoThuoc.Show();

            }
            else
            {
                frm.Activate();
            }
        }

        private void btnTonkhoToiThieu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frmTonKhoToiThieu));
            if (frm == null)
            {
                frmTonKhoToiThieu.MdiParent = this;
                frmTonKhoToiThieu.FormClosed += (sender1, eventArgs) => { frmTonKhoToiThieu = new frmTonKhoToiThieu(); };
                frmTonKhoToiThieu.Show();

            }
            else
            {
                frm.Activate();
            }
        }

        private void btnDSPhieuXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frmDSPhieuXuat));
            if (frm == null)
            {
                frmDSPhieuXuat.MdiParent = this;
                frmDSPhieuXuat.FormClosed += (sender1, eventArgs) => { frmDSPhieuXuat = new frmDSPhieuXuat(); };
                frmDSPhieuXuat.Show();

            }
            else
            {
                frm.Activate();
            }
        }

        private void ribbon_Click(object sender, EventArgs e)
        {
            
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frmKiemKe));
            if (frm == null)
            {
                frmKiemKe.MdiParent = this;
                frmKiemKe.FormClosed += (sender1, eventArgs) => { frmKiemKe = new frmKiemKe(); };
                frmKiemKe.Show();

            }
            else
            {
                frm.Activate();
            }
        }

        private void ribbon_Click_1(object sender, EventArgs e)
        {

        }
    }
}