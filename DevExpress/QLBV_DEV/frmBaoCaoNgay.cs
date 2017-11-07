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
    public partial class frmBaoCaoNgay : DevExpress.XtraEditors.XtraForm
    {
        #region params
        CT_Thuoc_PhieuXuatRepository rpo_CT_PhieuXuat = new CT_Thuoc_PhieuXuatRepository();

        int phieuNhapID = 0;

        int iRow;
        #endregion

        public frmBaoCaoNgay()
        {
            InitializeComponent();
            LoadNCC();
            LoadDoanhThuTheoNgay();

            dateTuNgay.EditValue = DateTime.Now;
            dateDenNgay.EditValue = DateTime.Now;
        }

        #region methods
        private void LoadDoanhThuTheoNgay()
        {
            try
            {
                DateTime tuNgay = Convert.ToDateTime(dateTuNgay.EditValue);
                DateTime denNgay = Convert.ToDateTime(dateDenNgay.EditValue);

                tuNgay = Convert.ToDateTime(tuNgay.ToShortDateString());
                denNgay = Convert.ToDateTime(denNgay.ToShortDateString());

                var result = rpo_CT_PhieuXuat.search(0, "", tuNgay, denNgay, "");
                grdDS_BanHang.DataSource = result.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }

        private void LoadNCC()
        {
            try
            {
                NCC_KHRepository rpo_NCC_KH = new NCC_KHRepository();
                // lấy ra KH và vừa là NCC vừa là KH
                cbbNCC_KH.Properties.DataSource = new BindingList<NCC_KH>(rpo_NCC_KH.GetAllByType(2, 2).ToList());
                //cbbNCC.DataSource = result.ToList();
                cbbNCC_KH.Properties.DisplayMember = "TenNCC_KH";
                cbbNCC_KH.Properties.ValueMember = "ID";

                cbbCol_NCC_KH.DataSource = new BindingList<NCC_KH>(rpo_NCC_KH.GetAllByType(2, 2).ToList());
                cbbCol_NCC_KH.DisplayMember = "TenNCC_KH";
                cbbCol_NCC_KH.ValueMember = "ID";
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }

        #endregion

        #region events
       
        
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            iRow = gridView1.FocusedRowHandle;
        }
                
        private void frmDS_PhieuNhapClosed(object sender, FormClosedEventArgs e)
        {
            LoadDoanhThuTheoNgay();
        }

        private void frmDSPhieuNhap_Load(object sender, EventArgs e)
        {
            
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int ncc_kh_ID       = Convert.ToInt32(cbbNCC_KH.EditValue); 
            String soPhieu      = txtSoPhieu.Text.Trim();
            DateTime tuNgay     = Convert.ToDateTime(dateTuNgay.EditValue);
            DateTime denNgay    = Convert.ToDateTime(dateDenNgay.EditValue);
            String soHoaDon     = txtSoHoaDon.Text.Trim();

            tuNgay = Convert.ToDateTime(tuNgay.ToShortDateString());
            denNgay = Convert.ToDateTime(denNgay.ToShortDateString());

            try
            {
                var query = rpo_CT_PhieuXuat.search(ncc_kh_ID, soPhieu, tuNgay, denNgay, soHoaDon);
                grdDS_BanHang.DataSource = query.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
            
        }
                
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            sfdDS_BanHang.Filter = "Excel files (*.xls or .xlsx)|.xls;*.xlsx";
            if (sfdDS_BanHang.ShowDialog() == DialogResult.OK)
            {
                grdDS_BanHang.ExportToXls(sfdDS_BanHang.FileName);
            }
        }
        #endregion


    }
}