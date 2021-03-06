﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBV_DEV.Repository;
using DevExpress.XtraGrid.Views.Grid;

namespace QLBV_DEV
{
    public partial class frmDS_Thuoc : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities db = new HospitalEntities();
        int thuoc_ID = 0;
        int iRow;
        ThuocRepository rpo_Thuoc = new ThuocRepository();

        #endregion

        public frmDS_Thuoc()
        {
            InitializeComponent();

            LoadNhomThuoc();
            LoadTenThuoc();
            LoadHoatChat();
            LoadHangSanXuat();
            LoadNuocSanXuat();
            LoadDS_Thuoc();

            //gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator; 
        }
        
        #region methods
        private void LoadDS_Thuoc()
        {
            try
            {
                var query = rpo_Thuoc.DS_Thuoc();
                if (query.ToList().Count() > 0)
                {
                    grvDSThuoc.DataSource = query.ToList();
                    //grvDSThuoc.DataSource = new BindingList<Thuoc>(db.Thuoc.Where(p=>p.KichHoat == true || p.KichHoat == null).ToList());

                }
                else
                {
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }
        private void LoadTenThuoc()
        {
            try
            {
                var result = from ncc in db.Thuoc
                             select new
                             {
                                 ID = ncc.ID,
                                 TenThuoc = ncc.TenThuoc,
                                 MaThuoc  = ncc.MaThuoc
                             };
                cbbTenThuoc.Properties.DataSource = result.ToList();
                cbbTenThuoc.Properties.DisplayMember = "TenThuoc";
                cbbTenThuoc.Properties.ValueMember = "ID";
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }

        private void LoadNhomThuoc()
        {
            try
            {
                var result = from ncc in db.NhomThuoc
                             select new
                             {
                                 ID = ncc.ID,
                                 TenNhom = ncc.TenNhom
                             };
                cbbNhomThuoc.Properties.DataSource = result.ToList();
                cbbNhomThuoc.Properties.DisplayMember = "TenNhom";
                cbbNhomThuoc.Properties.ValueMember = "ID";

                //cbbColNhomThuoc.DataSource = result.ToList();
                //cbbColNhomThuoc.DisplayMember = "TenNhom";
                //cbbColNhomThuoc.ValueMember = "ID";
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }
        }
        private void LoadHoatChat()
        {
            try
            {
                var result = from ncc in db.HoatChat
                             select new
                             {
                                 ID = ncc.ID,
                                 TenHoatChat = ncc.TenHoatChat
                             };

                cbbHoatChat.Properties.DataSource = result.ToList();
                cbbHoatChat.Properties.DisplayMember = "TenHoatChat";
                cbbHoatChat.Properties.ValueMember = "ID";
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }

        }
        private void LoadHangSanXuat()
        {
            try
            {
                var result = from ncc in db.HangSanXuat
                             select new
                             {
                                 ID = ncc.ID,
                                 TenHangSX = ncc.TenHangSX
                             };

                cbbHangSanXuat.Properties.DataSource = result.ToList();
                cbbHangSanXuat.Properties.DisplayMember = "TenHangSX";
                cbbHangSanXuat.Properties.ValueMember = "ID";
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }

        }

        private void LoadNuocSanXuat()
        {
            try
            {
                var result = from ncc in db.NuocSanXuat
                             select new
                             {
                                 ID = ncc.ID,
                                 TenNuoc = ncc.TenNuoc
                             };

                cbbNuocSanXuat.Properties.DataSource = result.ToList();
                cbbNuocSanXuat.Properties.DisplayMember = "TenNuoc";
                cbbNuocSanXuat.Properties.ValueMember = "ID";
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }

        }
        #endregion

        #region events
        private void frmDSThuoc_Load(object sender, EventArgs e)
        {
            
        }

        
        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemThuoc frmThemThuoc = new frmThemThuoc();
            frmThemThuoc.FormClosed += new FormClosedEventHandler(frmDSThuoc_Closed);
            frmThemThuoc.ShowInTaskbar = false;
            frmThemThuoc.ShowDialog();
        }

        private void frmDSThuoc_Closed(object sender, FormClosedEventArgs e)
        {
            LoadDS_Thuoc();
            LoadTenThuoc();
        }
        

        private void btnTim_Click(object sender, EventArgs e)
        {

            long thuoc_Id       = Convert.ToInt64(cbbTenThuoc.EditValue);
            int nhomthuoc_Id    = Convert.ToInt32(cbbNhomThuoc.EditValue);
            int hoatchat_Id     = Convert.ToInt32(cbbHoatChat.EditValue) ;
            int hangsanxuat_Id  = Convert.ToInt32(cbbHangSanXuat.EditValue);
            int nuocsanxuat_Id  = Convert.ToInt32(cbbNuocSanXuat.EditValue);
            bool kichhoat       = Convert.ToBoolean(chkKichHoat.EditValue);

            try
            {
                var query = rpo_Thuoc.search(thuoc_Id, nhomthuoc_Id, hoatchat_Id, hangsanxuat_Id, nuocsanxuat_Id, kichhoat);
                grvDSThuoc.DataSource = new BindingList<Thuoc>(query.ToList());
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }  
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (thuoc_ID > 0)
            {
                try
                {
                    frmThemThuoc frmThemThuoc = new frmThemThuoc();
                    frmThemThuoc.FormClosed += new FormClosedEventHandler(frmDSThuoc_Closed);
                    frmThemThuoc.loadData(thuoc_ID);
                    frmThemThuoc.ShowInTaskbar = false;
                    frmThemThuoc.ShowDialog();
                }
                catch (Exception)
                {
                    MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
                }
            }
            else
            {
                MessageBox.Show("Hãy lựa chọn dòng cần sửa.");
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (thuoc_ID > 0)
            {
                try
                {
                    String ten = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TenThuoc").ToString();
                    DialogResult dialogResult = MessageBox.Show(ten, "Xác nhận xóa?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //do something
                        Thuoc obj_Thuoc = rpo_Thuoc.GetSingle(thuoc_ID);
                        obj_Thuoc.KichHoat = false;
                        rpo_Thuoc.Save(obj_Thuoc);
                        //rpo_Thuoc.Delete(thuoc_ID);

                        // Tải lại danh sách nhà cung cấp
                        LoadDS_Thuoc();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
                }
            }
            else
            {
                MessageBox.Show("Hãy lựa chọn dòng cần xóa.");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void grvDSThuoc_Click(object sender, EventArgs e)
        {
            // dừng xử lý nếu không kích vào dòng có dữ liệu
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID") == null)
                return;

            string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString();
            thuoc_ID = Convert.ToInt32(id);
            //MessageBox.Show(id);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            iRow = gridView1.FocusedRowHandle;
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            sfdDSThuoc.Filter = "Excel files (*.xls or .xlsx)|.xls;*.xlsx";
            if (sfdDSThuoc.ShowDialog() == DialogResult.OK)
            {
                grvDSThuoc.ExportToXls(sfdDSThuoc.FileName);
            }
        }
        #endregion

        #region Sothutu
        //Tạo số thứ tự tăng tự động cho 1 gridView. Dùng cho cả trường hợp group.
        //Thêm dòng sau vào dưới InitializeComponent():
        //gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator; 
        //Sử dụng thư viện:
        //using DevExpress.XtraGrid.Views.Grid;

        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
            {
                if (!gridView1.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
                {
                    if (e.Info.IsRowIndicator) //Nếu là dòng Indicator
                    {
                        if (e.RowHandle < 0)
                        {
                            e.Info.ImageIndex = 0;
                            e.Info.DisplayText = string.Empty;
                        }
                        else
                        {
                            e.Info.ImageIndex = -1; //Không hiển thị hình
                            e.Info.DisplayText = (e.RowHandle + 1).ToString(); //Số thứ tự tăng dần
                        }
                        SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước của vùng hiển thị Text
                        Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                        BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); })); //Tăng kích thước nếu Text vượt quá
                    }
                }
                else
                {
                    e.Info.ImageIndex = -1;
                    e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                    SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                    Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); }));
                }
            }
            catch (Exception)
            {
                MessageBox.Show(QLBV_DEV.Helpers.ErrorMessages.show(1));
            }

        }
        #endregion


    }
}