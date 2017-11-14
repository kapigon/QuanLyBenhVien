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


namespace QLBV_DEV
{
    public partial class frmCT_DonViTinh : DevExpress.XtraEditors.XtraForm
    {
        #region params
        long thuoc_ID   = 0;
        long ct_dvt_ID  = 0;
        int iRow        = 0;
        int iRow_CT     = 0;
        ThuocRepository         rpo_Thuoc   = new ThuocRepository();
        DVTRepository           rpo_DVT     = new DVTRepository();
        CT_DonViTinhRepository  rpo_CT_DVT  = new CT_DonViTinhRepository();

        Thuoc                   obj_Thuoc   = new Thuoc();
        CT_DonViTinh            obj_CT_DVT  = new CT_DonViTinh();

        bool isUpdate = false;
        #endregion

        public frmCT_DonViTinh()
        {
            InitializeComponent();
            LoadDS_Thuoc();
            LoadDVT();
        }

        #region methods
        private void LoadDS_Thuoc()
        {
            try
            {
                var query = rpo_Thuoc.search(0, 0, 0, true);
                if (query.ToList().Count() > 0)
                {
                    grvDSThuoc.DataSource = query.ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }

        private void LoadDS_CT_DVT(long t_ID)
        {
            try
            {
                var query = rpo_CT_DVT.GetAll(t_ID);
                if (query.ToList().Count() > 0)
                {
                    grvDS_CT_DVT.DataSource = query.ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }

        private void LoadDVT()
        {
            try
            {
                var result = rpo_DVT.GetAll();
                cbbDVT.Properties.DataSource = result.ToList();
                cbbDVT.Properties.DisplayMember = "TenDVT";
                cbbDVT.Properties.ValueMember = "ID";

                cbbCol_DVT.DataSource = result.ToList();
                cbbCol_DVT.DisplayMember = "TenDVT";
                cbbCol_DVT.ValueMember = "ID";
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }

        #endregion

        #region events
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dxValidate.Validate() == true && thuoc_ID > 0)
            {
                try
                {
                    if (rpo_CT_DVT.GetSingle(thuoc_ID, Convert.ToInt32(cbbDVT.EditValue)) != null)
                    {
                        MessageBox.Show(cbbDVT.Text + " đã tồn tại. Vui lòng chọn ĐVT khác");
                    }
                    else
                    {
                        obj_CT_DVT = new CT_DonViTinh()
                        {
                            Thuoc_ID = thuoc_ID,
                            DVT_ID = Convert.ToInt32(cbbDVT.EditValue),
                            QuyDoi = Convert.ToInt64(txtQuyDoi.Text),
                            KichHoat = chkKichHoat.Checked
                        };

                        // Tạo mới 1 chi tiết đơn vị tính theo thuoc_ID
                        rpo_CT_DVT.Create(obj_CT_DVT);

                        // Load lại danh sách chi tiết đơn vị tính
                        LoadDS_CT_DVT(thuoc_ID);

                        // Xóa trắng để nhập tiếp
                        Xoatrang();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dxValidate.Validate() == true && ct_dvt_ID > 0)
            {
                CT_DonViTinh obj = rpo_CT_DVT.GetSingle(thuoc_ID, Convert.ToInt32(cbbDVT.EditValue)) ;
                if (obj != null && obj.ID != ct_dvt_ID)
                {
                    MessageBox.Show(cbbDVT.Text + " đã tồn tại. Vui lòng chọn ĐVT khác");
                }
                else
                {
                    obj.ID = ct_dvt_ID;
                    obj.Thuoc_ID = thuoc_ID;
                    obj.DVT_ID = Convert.ToInt32(cbbDVT.EditValue);
                    obj.QuyDoi = Convert.ToInt64(txtQuyDoi.Text);
                    obj.KichHoat = chkKichHoat.Checked;

                    // Tạo mới 1 chi tiết đơn vị tính theo thuoc_ID
                    rpo_CT_DVT.Save(obj);

                    // Load lại danh sách chi tiết đơn vị tính
                    LoadDS_CT_DVT(thuoc_ID);

                    // Xóa trắng để nhập tiếp
                    Xoatrang();
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Xoatrang()
        {
            //txtTenThuoc.Text    = "";
            //txtMaThuoc.Text     = "";
            cbbDVT.EditValue    = 0;
            txtQuyDoi.Text      = ""; 
        }

        private void grvDSThuoc_Click(object sender, EventArgs e)
        {
            if (gridView1 == null || gridView1.SelectedRowsCount == 0) return;

            if (gridView1.GetRowCellDisplayText(iRow, "ID") == "") return;

            btnThem.Enabled     = true;
            btnCapNhat.Enabled  = false;
            Xoatrang();
            grvDS_CT_DVT.DataSource = null;

            long id = Convert.ToInt64(gridView1.GetRowCellDisplayText(iRow, "ID"));

            txtMaThuoc.Text     = gridView1.GetRowCellDisplayText(iRow, "MaThuoc").ToString();
            txtTenThuoc.Text    = gridView1.GetRowCellDisplayText(iRow, "TenThuoc").ToString();

            thuoc_ID = id;
            isUpdate = true;

            /// Load danh sách Chi tiết đơn vị tính theo Thuoc_ID
            LoadDS_CT_DVT(thuoc_ID);
        }

        // Thêm số thứ tự tự động tăng GridControl
        //bool indicatorIcon = true;
        private void grvDSThuoc_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
             GridView view = (GridView)sender;
            if (e.Info.IsRowIndicator && e.RowHandle >=0)
            {
                e.Info.DisplayText = (e.RowHandle+1).ToString();
            }
        }


        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            iRow = gridView1.FocusedRowHandle;
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            iRow_CT = gridView2.FocusedRowHandle;
        }

        private void grvDS_CT_DVT_Click(object sender, EventArgs e)
        {
            if (gridView2 == null || gridView2.SelectedRowsCount == 0) return;

            if (gridView2.GetRowCellDisplayText(iRow_CT, "ID") == "") return;

            btnCapNhat.Enabled = true;
            long id             = Convert.ToInt64(gridView2.GetRowCellDisplayText(iRow_CT, "ID"));

            ct_dvt_ID           = id;
            cbbDVT.EditValue    = gridView2.GetRowCellValue(iRow_CT, "DVT_ID");
            txtQuyDoi.Text      = gridView2.GetRowCellValue(iRow_CT, "QuyDoi").ToString();
            chkKichHoat.Checked = Convert.ToBoolean(gridView2.GetRowCellValue(iRow_CT, "KichHoat"));
        }

        #endregion


    }
}