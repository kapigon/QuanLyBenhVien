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
        frmThemNCC_KH       frmThemNhaCungCap   = new frmThemNCC_KH();
        frmThemThuoc        frmThemThuoc        = new frmThemThuoc();
        frmDSNCC_KH         frmDSNCC_KH         = new frmDSNCC_KH();
        frmNuocSanXuat      frmNuocSanXuat      = new frmNuocSanXuat();
        frmHoatChat         frmHoatChat         = new frmHoatChat();
        frmDonViTinh        frmDonViTinh        = new frmDonViTinh();
        frmNhomThuoc        frmNhomThuoc        = new frmNhomThuoc();
        frmKho              frmViTri            = new frmKho();
        frmHangSanXuat      frmHangSanXuat      = new frmHangSanXuat();
        frmKho              frmKho              = new frmKho();
        frmDS_Thuoc         frmDS_Thuoc         = new frmDS_Thuoc();
        frmPhieuXuatThuoc   frmPhieuXuatThuoc   = new frmPhieuXuatThuoc();
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

        private void comboBoxEdit1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("Hey");
        }

        private void btnTaoPhieuNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = kiemtraform(typeof(frmPhieuNhapThuoc));
            if (frm == null)
            {
                //frmPhieuNhapThuoc forms = new frmPhieuNhapThuoc();
                frmPhieuNhapThuoc.MdiParent = this;
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

        private void close_form(object sender, FormClosedEventArgs e)
        {
            frmPhieuNhapThuoc   = new frmPhieuNhapThuoc();
            frmDSPhieuNhap      = new frmDSPhieuNhap();
            frmThemNhaCungCap   = new frmThemNCC_KH();
            frmThemThuoc        = new frmThemThuoc();
            frmDSNCC_KH         = new frmDSNCC_KH();
            frmNuocSanXuat      = new frmNuocSanXuat();
            frmHoatChat         = new frmHoatChat();
            frmNhomThuoc        = new frmNhomThuoc();
            frmDonViTinh        = new frmDonViTinh();
            frmViTri            = new frmKho();
            frmHangSanXuat      = new frmHangSanXuat();
            frmKho              = new frmKho();
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
    }
}