using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLBV_DEV
{
    public partial class frmTrangChu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }

        Form CheckForm(Type fType)
        {
            foreach (var f in this.MdiChildren)
            {
                if (f.GetType() == fType)
                    return f;
            }
            return null;
        }


        private void btnTaoPhieuNhap(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = CheckForm(typeof(frmPhieuNhapThuoc));
            if (frm != null)
                frm.Activate();
            else
            {
                frmPhieuNhapThuoc fr = new frmPhieuNhapThuoc();
                fr.MdiParent = this;
                fr.Show();
            }
        }
    }
}
