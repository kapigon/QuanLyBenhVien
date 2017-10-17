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
        frmDSNuocSanXuat frmDSNuocSanXuat = new frmDSNuocSanXuat();

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
            Form frm = kiemtraform(typeof(frmDSNuocSanXuat));
            if (frm == null)
            {
                frmDSNuocSanXuat.MdiParent = this;
                frmDSNuocSanXuat.FormClosed += new FormClosedEventHandler(close_form);
                frmDSNuocSanXuat.Show();
                
            }
            else
            {
                frm.Activate();
            }
        }

        private void close_form(object sender, FormClosedEventArgs e)
        {
            frmDSNuocSanXuat = new frmDSNuocSanXuat();            
        }
    }
}