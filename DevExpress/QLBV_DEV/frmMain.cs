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
        frmPhieuNhapThuoc   frmPhieuNhapThuoc           = new frmPhieuNhapThuoc();
        frmDSPhieuNhap      frmDSPhieuNhap              = new frmDSPhieuNhap();
        frmDSPhieuXuat      frmDSPhieuXuat              = new frmDSPhieuXuat();
        frmThemNCC_KH       frmThemNhaCungCap           = new frmThemNCC_KH();
        frmThemThuoc        frmThemThuoc                = new frmThemThuoc();
        frmDSNCC_KH         frmDSNCC_KH                 = new frmDSNCC_KH();
        frmNuocSanXuat      frmNuocSanXuat              = new frmNuocSanXuat();
        frmHoatChat         frmHoatChat                 = new frmHoatChat();
        frmNhomThuoc        frmNhomThuoc                = new frmNhomThuoc();
        frmDonViTinh        frmDonViTinh                = new frmDonViTinh();
        frmKho              frmViTri                    = new frmKho();
        frmHangSanXuat      frmHangSanXuat              = new frmHangSanXuat();
        frmKho              frmKho                      = new frmKho();
        frmDS_Thuoc         frmDS_Thuoc                 = new frmDS_Thuoc();
        frmPhieuXuatThuoc   frmPhieuXuatThuoc           = new frmPhieuXuatThuoc();
        frmDSThuocCanDate   frmDSThuocCanDate           = new frmDSThuocCanDate();
        frmThuoCanDate_tungloai frmThuoCanDate_tungloai = new frmThuoCanDate_tungloai();
        frmTonKhoTheoLo     frmTonKhoTheoLo             = new frmTonKhoTheoLo();
        frmTonKhoTheoThuoc  frmTonKhoTheoThuoc          = new frmTonKhoTheoThuoc();
        frmTonKhoToiThieu   frmTonKhoToiThieu           = new frmTonKhoToiThieu();
        frmKiemKe   frmPhieuDieuChinh           = new frmKiemKe();

        private void close_form(object sender, FormClosedEventArgs e)
        {
            frmPhieuNhapThuoc       = new frmPhieuNhapThuoc();
            frmDSPhieuNhap          = new frmDSPhieuNhap();
            frmDSPhieuXuat          = new frmDSPhieuXuat();
            frmThemNhaCungCap       = new frmThemNCC_KH();
            frmThemThuoc            = new frmThemThuoc();
            frmDSNCC_KH             = new frmDSNCC_KH();
            frmNuocSanXuat          = new frmNuocSanXuat();
            frmHoatChat             = new frmHoatChat();
            frmNhomThuoc            = new frmNhomThuoc();
            frmDonViTinh            = new frmDonViTinh();
            frmViTri                = new frmKho();
            frmHangSanXuat          = new frmHangSanXuat();
            frmKho                  = new frmKho();
            frmPhieuXuatThuoc       = new frmPhieuXuatThuoc();
            frmDSThuocCanDate       = new frmDSThuocCanDate();
            frmThuoCanDate_tungloai = new frmThuoCanDate_tungloai();
            frmTonKhoTheoLo         = new frmTonKhoTheoLo();
            frmTonKhoTheoThuoc      = new frmTonKhoTheoThuoc();
            frmTonKhoToiThieu       = new frmTonKhoToiThieu();
            frmPhieuDieuChinh       = new frmKiemKe();
        }

        public frmMain()
        {

            InitializeComponent();
        }
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



        private void btnTaoPhieuNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frmPhieuNhapThuoc));
            if (frm == null)
            {
                //frmPhieuNhapThuoc forms = new frmPhieuNhapThuoc();
                frmPhieuNhapThuoc.MdiParent = this;
                frmPhieuNhapThuoc.FormClosed += new FormClosedEventHandler(close_form);
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
                frmDSPhieuNhap.FormClosed += new FormClosedEventHandler(close_form);
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
                frmThemNhaCungCap.MdiParent = this;
                frmThemNhaCungCap.FormClosed += new FormClosedEventHandler(close_form);
                frmThemNhaCungCap.Show();
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
                frmThemThuoc.FormClosed += new FormClosedEventHandler(close_form);
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
                frmDSNCC_KH.FormClosed += new FormClosedEventHandler(close_form);
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
                frmNuocSanXuat.FormClosed += new FormClosedEventHandler(close_form);
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
                frmHoatChat.FormClosed += new FormClosedEventHandler(close_form);
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
                frmDonViTinh.FormClosed += new FormClosedEventHandler(close_form);
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
                frmNhomThuoc.FormClosed += new FormClosedEventHandler(close_form);
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
                frmViTri.FormClosed += new FormClosedEventHandler(close_form);
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
                frmHangSanXuat.FormClosed += new FormClosedEventHandler(close_form);
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
                frmKho.FormClosed += new FormClosedEventHandler(close_form);
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
                frmDS_Thuoc.FormClosed += new FormClosedEventHandler(close_form);
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
                frmPhieuXuatThuoc.FormClosed += new FormClosedEventHandler(close_form);
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
                frmDSThuocCanDate.FormClosed += new FormClosedEventHandler(close_form);
                frmDSThuocCanDate.Show();

            }
            else
            {
                frm.Activate();
            }
        }

        private void btnThuocCanDate_tungloai_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frmThuoCanDate_tungloai));
            if (frm == null)
            {
                frmThuoCanDate_tungloai.MdiParent = this;
                frmThuoCanDate_tungloai.FormClosed += new FormClosedEventHandler(close_form);
                frmThuoCanDate_tungloai.Show();

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
                frmTonKhoTheoLo.FormClosed += new FormClosedEventHandler(close_form);
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
                frmTonKhoTheoThuoc.FormClosed += new FormClosedEventHandler(close_form);
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
                frmTonKhoToiThieu.FormClosed += new FormClosedEventHandler(close_form);
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
                frmDSPhieuXuat.FormClosed += new FormClosedEventHandler(close_form);
                frmDSPhieuXuat.Show();

            }
            else
            {
                frm.Activate();
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frmKiemKe));
            if (frm == null)
            {
                frmPhieuDieuChinh.MdiParent = this;
                frmPhieuDieuChinh.FormClosed += new FormClosedEventHandler(close_form);
                frmPhieuDieuChinh.Show();

            }
            else
            {
                frm.Activate();
            }
        }
    }
}