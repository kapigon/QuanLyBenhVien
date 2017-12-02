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
using System.Collections;


namespace QLBV_DEV
{
    public partial class frmCT_DonViTinh : DevExpress.XtraEditors.XtraForm
    {
        #region params
        long thuoc_ID   = 0;
        int iRow        = 0;
        ThuocRepository         rpo_Thuoc   = new ThuocRepository();
        DVTRepository           rpo_DVT     = new DVTRepository();
        CT_DonViTinhRepository  rpo_CT_DVT  = new CT_DonViTinhRepository();

        Thuoc                   obj_Thuoc   = new Thuoc();
        CT_DonViTinh            obj_CT_DVT  = new CT_DonViTinh();

        #endregion

        public frmCT_DonViTinh()
        {
            InitializeComponent();
            LoadDS_Thuoc();
            LoadDVT();
            grvDS_CT_DVT.DataSource = new BindingList<CT_DonViTinh>();
        }

        #region methods
        private void LoadDS_Thuoc()
        {
            try
            {
                var query = rpo_Thuoc.getListThuoc_CT_DVT();
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
                    grvDS_CT_DVT.DataSource = new BindingList<CT_DonViTinh>(query.ToList());
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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (thuoc_ID > 0)
            {
                try
                {
                    List<CT_DonViTinh> lstCT_DVT = ((IEnumerable)grvDS_CT_DVT.DataSource).Cast<CT_DonViTinh>().ToList(); ;

                    if(lstCT_DVT.Where(p=>p.QuyDoi == null || p.DVT_ID == 0).ToList().Count() > 0){
                        MessageBox.Show("Đơn vị tính và Quy đổi không được để trống.!");
                    }
                    else
                    {
                        if (gridView2.RowCount > 0)
                        {
                            CT_DonViTinh obj;
                            for (int i = 0; i < gridView2.RowCount; i++)
                            {
                                if (gridView2.GetRowCellValue(i, "ID") != null && Convert.ToInt64(gridView2.GetRowCellValue(i, "ID")) > 0)
                                {
                                    long ID = Convert.ToInt64(gridView2.GetRowCellValue(i, "ID"));
                                    obj = rpo_CT_DVT.GetSingle(ID);
                                    if (obj != null)
                                    {
                                        obj.Thuoc_ID    = thuoc_ID;
                                        obj.DVT_ID      = Convert.ToInt32(gridView2.GetRowCellValue(i, "DVT_ID"));
                                        obj.QuyDoi      = Convert.ToInt64(gridView2.GetRowCellValue(i, "QuyDoi"));
                                        //obj.TenDVT    = lstCT_DVT[i].TenDVT;
                                        obj.DVTQuyChuan = Convert.ToBoolean(gridView2.GetRowCellValue(i, "DVTQuyChuan"));
                                        obj.KichHoat    = Convert.ToBoolean(gridView2.GetRowCellValue(i, "KichHoat"));
                                    }

                                    rpo_CT_DVT.Save(obj);
                                }
                                else
                                {
                                    obj             = new CT_DonViTinh();
                                    obj.Thuoc_ID    = thuoc_ID;
                                    obj.DVT_ID      = Convert.ToInt32(gridView2.GetRowCellValue(i, "DVT_ID"));
                                    obj.QuyDoi      = Convert.ToInt64(gridView2.GetRowCellValue(i, "QuyDoi"));
                                    //obj.TenDVT    = lstCT_DVT[i].TenDVT;
                                    obj.DVTQuyChuan = Convert.ToBoolean(gridView2.GetRowCellValue(i, "DVTQuyChuan"));
                                    obj.KichHoat    = Convert.ToBoolean(gridView2.GetRowCellValue(i, "KichHoat"));

                                    rpo_CT_DVT.Create(obj);
                                }
                            }
                        }
                        LoadDS_Thuoc();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
                }
            }
        }

        private void chkColDVTQuyChuan_EditValueChanged(object sender, EventArgs e)
        {
            int row = gridView2.FocusedRowHandle;
            var search = sender as CheckEdit;

            if (search == null) return;

            bool chkDVTQuyChuan = search.Checked;
            if (chkDVTQuyChuan)
                gridView2.SetRowCellValue(row, "KichHoat", 1);

            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (i != row)
                    gridView2.SetRowCellValue(i, "DVTQuyChuan", 0);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void grvDSThuoc_Click(object sender, EventArgs e)
        {
            if (gridView1 == null || gridView1.SelectedRowsCount == 0) return;

            if (gridView1.GetRowCellDisplayText(iRow, "ID") == "") return;

            btnCapNhat.Enabled = true;

            grvDS_CT_DVT.DataSource = new BindingList<CT_DonViTinh>();

            iRow = gridView1.FocusedRowHandle;
            long id = Convert.ToInt64(gridView1.GetRowCellDisplayText(iRow, "ID"));

            txtMaThuoc.Text     = gridView1.GetRowCellDisplayText(iRow, "MaThuoc").ToString();
            txtTenThuoc.Text    = gridView1.GetRowCellDisplayText(iRow, "TenThuoc").ToString();

            thuoc_ID = id;

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
        #endregion


    }
}