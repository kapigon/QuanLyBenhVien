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
        frmPhieuNhapThuoc frmPhieuNhapThuoc = new frmPhieuNhapThuoc();
        frmDSPhieuNhap frmDSPhieuNhap = new frmDSPhieuNhap();
        frmThemNCC_KH frmThemNhaCungCap = new frmThemNCC_KH();
        frmThemThuoc frmThemThuoc = new frmThemThuoc();
        frmDSNCC_KH frmDSNCC_KH = new frmDSNCC_KH();
        frmNuocSanXuat frmNuocSanXuat = new frmNuocSanXuat();
        frmHoatChat frmHoatChat = new frmHoatChat();
        frmDonViTinh frmDonViTinh = new frmDonViTinh();

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
            Form frm = kiemtraform(typeof(frmDonViTinh));
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
    }
}