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
    public partial class frmDSPhieuXuat : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities db = new HospitalEntities();
        PhieuXuatThuocRepository rpo_PhieuXuat = new PhieuXuatThuocRepository();

        int phieuXuatID = 0;

        int iRow;
        #endregion

        public frmDSPhieuXuat()
        {
            InitializeComponent();
        }

        #region methods
        private void LoadDS_PhieuXuat()
        {
            //var result = from nv in db.PhieuNhapThuoc
            //             where nv.Xoa == false
            //             select nv;
            //var result = rpo_PhieuNhap.GetAllNotDelete();
            var result = from phieuxuat in db.PhieuXuatThuoc
                        join ncc_kh in db.NCC_KH on phieuxuat.NCC_KH_ID equals ncc_kh.ID
                        where phieuxuat.Xoa != true
                        orderby phieuxuat.ID ascending
                        select new
                        {
                            ID          = phieuxuat.ID,
                            SoPhieu     = phieuxuat.SoPhieu,
                            SoHoaDon    = phieuxuat.SoHoaDon,
                            NgayTao     = phieuxuat.NgayTao,
                            NCC_KH_ID   = ncc_kh.TenNCC_KH,
                            ChietKhau   = phieuxuat.ChietKhau,
                            //TongTien    = phieuxuat.TongTienTra
                        };
            grdDS_PhieuNhap.DataSource = result.ToList();
        }

        private void LoadNCC()
        {
            NCC_KHRepository rpo_NCC_KH = new NCC_KHRepository();
            // lấy ra NCC và vừa là NCC vừa là KH
            cbbNCC_KH.Properties.DataSource = new BindingList<NCC_KH>(rpo_NCC_KH.GetAllByType(1, 2).ToList());
            //cbbNCC.DataSource = result.ToList();
            cbbNCC_KH.Properties.DisplayMember = "TenNCC_KH";
            cbbNCC_KH.Properties.ValueMember = "ID";

            cbbCol_NCC_KH.DataSource = new BindingList<NCC_KH>(rpo_NCC_KH.GetAllByType(1, 2).ToList());
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
                DialogResult dialogResult = MessageBox.Show(soPhieu, "Xác nhận xóa?", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    long id = Convert.ToInt64(gridView1.GetRowCellValue(iRow, "ID"));
                    //int userID = 100000;

                    PhieuNhapThuoc obj_PhieuNhap = rpo_PhieuXuat.GetSingle(id);
                    obj_PhieuNhap.Xoa = true;
                    obj_PhieuNhap.NgayXoa = DateTime.Now;

                    rpo_PhieuXuat.Save(obj_PhieuNhap);


                    // Tải lại danh sách nhà cung cấp
                    LoadDS_PhieuXuat();
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
            LoadDS_PhieuXuat();
        }

        private void frmDSPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadNCC();
            LoadDS_PhieuXuat();
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int ncc_kh_ID       = Convert.ToInt32(cbbNCC_KH.EditValue); 
            String soPhieu      = txtSoPhieu.Text.Trim();
            DateTime tuNgay     = Convert.ToDateTime(dateTuNgay.EditValue);
            DateTime denNgay    = Convert.ToDateTime(dateDenNgay.EditValue);
            String soHoaDon     = txtSoHoaDon.Text.Trim();

            var query = rpo_PhieuXuat.search(ncc_kh_ID, soPhieu, tuNgay, denNgay, soHoaDon);
            grdDS_PhieuNhap.DataSource = new BindingList<PhieuNhapThuoc>(query.ToList());
        }
        #endregion
    }
}