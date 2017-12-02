using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Entity;
using QLBV_DEV.Repository;

using System.Data.Entity.Validation;
using System.Diagnostics;

using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;


namespace QLBV_DEV
{
    public partial class frmDonViTinh_QuyDoi : DevExpress.XtraEditors.XtraForm
    {
        #region params
        DVTRepository           rpo_DVT     = new DVTRepository();
        CT_DonViTinhRepository  rpo_CT_DVT  = new CT_DonViTinhRepository();
        private frmThemThuoc frmThemThuoc;
        #endregion

        public frmDonViTinh_QuyDoi()
        {
            InitializeComponent();
            grvDS_CT_DVT.DataSource = new BindingList<CT_DonViTinh>();
            LoadDVT();
        }

        public frmDonViTinh_QuyDoi(frmThemThuoc _frmThemThuoc)
        {
            frmThemThuoc = _frmThemThuoc;
            InitializeComponent();
            grvDS_CT_DVT.DataSource = new BindingList<CT_DonViTinh>();
            LoadDVT();
        }
        
        private void LoadDVT()
        {
            try
            {
                cbbColDVT.DataSource    = rpo_DVT.GetAll().ToList();
                cbbColDVT.DisplayMember = "TenDVT";
                cbbColDVT.ValueMember   = "ID";
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }

        public void LoadData(List<CT_DonViTinh> lstCT_DVT)
        {
            grvDS_CT_DVT.DataSource = new BindingList<CT_DonViTinh>(lstCT_DVT.ToList());
        }

        private void cbbColDVT_EditValueChanged(object sender, EventArgs e)
        {
            int _index = gridView1.FocusedRowHandle;

            var search = sender as LookUpEdit;
            if (search == null) return;

            var id = (search.EditValue == null || search.EditValue == DBNull.Value) ? 0 : Convert.ToInt32(search.EditValue);

            //search.Properties.DataSource
            var listDVT = search.Properties.DataSource as List<DonViTinh>;
            if (listDVT == null) return;

            var x = listDVT.FirstOrDefault(t => t.ID == id);

            var ctXuat = gridView1.GetFocusedRow() as CT_DonViTinh;
            if (ctXuat == null) return;
            ctXuat.TenDVT = x.TenDVT;

            gridView1.PostEditor();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            List<CT_DonViTinh> lstCT_DVT = ((BindingList<CT_DonViTinh>)grvDS_CT_DVT.DataSource).ToList();
            frmThemThuoc.setValueLookUpEdit(lstCT_DVT);
            this.Close();
        }

        private void chkColDVTQuyChuan_EditValueChanged(object sender, EventArgs e)
        {
            int row = gridView1.FocusedRowHandle;
            var search = sender as CheckEdit;

            if (search == null) return;
            
            bool chkDVTQuyChuan = search.Checked;
            if (chkDVTQuyChuan)
                gridView1.SetRowCellValue(row, "KichHoat", 1);

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if(i != row)
                    gridView1.SetRowCellValue(i, "DVTQuyChuan", 0);
            }
        }

        // Thêm số thứ tự tự động tăng GridControl
        //bool indicatorIcon = true;
        private void grvDS_CT_DVT_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
             GridView view = (GridView)sender;
            if (e.Info.IsRowIndicator && e.RowHandle >=0)
            {
                e.Info.DisplayText = (e.RowHandle+1).ToString();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}