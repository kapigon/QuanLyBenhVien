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
                        frmPhieuNhapThuoc forms = new frmPhieuNhapThuoc();
                        forms.MdiParent = this;
                        forms.Show();
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
                        frmDSPhieuNhap forms = new frmDSPhieuNhap();
                        forms.MdiParent = this;
                        forms.Show();
                    }
                    else
                    {
                        frm.Activate();
                    }
                }

                private void btnThemNhaCungCap_ItemClick(object sender, ItemClickEventArgs e)
                {
                    Form frm = kiemtraform(typeof(frmThemNhaCungCap));
                    if (frm == null)
                    {
                        frmThemNhaCungCap forms = new frmThemNhaCungCap();
                        forms.MdiParent = this;
                        forms.Show();
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
                        frmThemThuoc forms = new frmThemThuoc();
                        forms.MdiParent = this;
                        forms.Show();
                    }
                    else
                    {
                        frm.Activate();
                    }
                }
    }
}