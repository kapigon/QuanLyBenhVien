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
    public partial class frmDSPhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities db = new HospitalEntities();
        PhieuNhapThuocRepository rpo_PhieuNhap = new PhieuNhapThuocRepository();

        int phieuNhapID = 0;

        int iRow;
        #endregion

        public frmDSPhieuNhap()
        {
            InitializeComponent();
        }

        #region methods
        private void LoadDS_PhieuNhap()
        {
            //var result = from nv in db.PhieuNhapThuoc
            //             where nv.Xoa == false
            //             select nv;
            var result = rpo_PhieuNhap.GetAllNotDelete();
            grdDS_PhieuNhap.DataSource = result.ToList();
        }

        private void LoadNCC()
        {
            // lấy ra NCC và vừa là NCC vừa là KH
            cbbNCC_KH.Properties.DataSource = new BindingList<NCC_KH>(db.NCC_KH.Where(p=>p.ID == 1 || p.ID == 3).ToList());
            //cbbNCC.DataSource = result.ToList();
            cbbNCC_KH.Properties.DisplayMember = "TenNCC_KH";
            cbbNCC_KH.Properties.ValueMember = "ID";

            cbbCol_NCC_KH.DataSource = new BindingList<NCC_KH>(db.NCC_KH.Where(p => p.ID == 1 || p.ID == 3).ToList());
            cbbCol_NCC_KH.DisplayMember = "TenNCC_KH";
            cbbCol_NCC_KH.ValueMember = "ID";
        }

        #endregion

        #region events
        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            frmPhieuNhapThuoc frmPhieuNhapThuoc = new frmPhieuNhapThuoc();
            frmPhieuNhapThuoc.ShowInTaskbar = false;
            frmPhieuNhapThuoc.ShowDialog();

            /*frmMain frmMain = new frmMain();
            frmMain.showPhieuNhap();
            Form frm = frmMain.kiemtraform(typeof(frmPhieuNhapThuoc));
            if (frm == null)
            {
                //frmPhieuNhapThuoc forms = new frmPhieuNhapThuoc();
                frmPhieuNhapThuoc.MdiParent = frmMain;
                frmPhieuNhapThuoc.Show();
            }
            else
            {
                frm.Activate();
            }*/
        }
        
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            iRow = gridView1.FocusedRowHandle;
        }
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (iRow >= 0)
            {
                String soPhieu = gridView1.GetRowCellValue(iRow, "SoPhieu").ToString();
                DialogResult dialogResult = MessageBox.Show(soPhieu, "Xác nhận xóa 'Phiếu nhập' ?", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    long id = Convert.ToInt64(gridView1.GetRowCellValue(iRow, "ID"));
                    //int userID = 100000;

                    PhieuNhapThuoc obj_PhieuNhap = rpo_PhieuNhap.GetSingle(id);
                    obj_PhieuNhap.Xoa = true;
                    obj_PhieuNhap.NgayXoa = DateTime.Now;

                    rpo_PhieuNhap.Save(obj_PhieuNhap);


                    // Tải lại danh sách nhà cung cấp
                    LoadDS_PhieuNhap();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            else
            {
                MessageBox.Show("Hãy lựa chọn dòng cần xóa.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (iRow >= 0)
            {
                long id = Convert.ToInt64(gridView1.GetRowCellValue(iRow, "ID"));

                frmPhieuNhapThuoc frmPhieuNhap = new frmPhieuNhapThuoc();
                frmPhieuNhap.FormClosed += new FormClosedEventHandler(frmDS_PhieuNhapClosed);

                frmPhieuNhap.loadData(id);
                frmPhieuNhap.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hãy lựa chọn dòng cần sửa.");
            }
        }

        private void frmDS_PhieuNhapClosed(object sender, FormClosedEventArgs e)
        {
            LoadDS_PhieuNhap();
        }

        private void frmDSPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadNCC();
            LoadDS_PhieuNhap();
        }
        #endregion

       
    }
}