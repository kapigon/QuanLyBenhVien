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
            LoadDS_Thuoc();
        }
        
        #region methods
        private void LoadDS_Thuoc()
        {
            if (db.Thuoc.ToList().Count() > 0)
            {
                grvDSThuoc.DataSource = new BindingList<Thuoc>(db.Thuoc.Where(p=>p.KichHoat == true || p.KichHoat == null).ToList());

            }
            else
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }
        private void LoadNhomThuoc()
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

            cbbColNhomThuoc.DataSource = result.ToList();
            cbbColNhomThuoc.DisplayMember = "TenNhom";
            cbbColNhomThuoc.ValueMember = "ID";
        }
        #endregion

        #region events
        private void frmDSThuoc_Load(object sender, EventArgs e)
        {
            LoadNhomThuoc();
        }

        
        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemNCC_KH f_ncc_kh = new frmThemNCC_KH();
            f_ncc_kh.FormClosed += new FormClosedEventHandler(frmDSThuoc_Closed);
            f_ncc_kh.ShowDialog();
        }

        private void frmDSThuoc_Closed(object sender, FormClosedEventArgs e)
        {
            LoadDS_Thuoc();
        }
        

        private void btnTim_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cbbNhomThuoc.EditValue.ToString());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (thuoc_ID > 0)
            {
                frmThemThuoc frmThemThuoc = new frmThemThuoc();
                frmThemThuoc.FormClosed += new FormClosedEventHandler(frmDSThuoc_Closed);
                frmThemThuoc.loadData(thuoc_ID);
                frmThemThuoc.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hãy lựa chọn dòng cần sửa.");
            }
        }

        private void frmNCC_KHClosed(object sender, FormClosedEventArgs e)
        {
            LoadDS_Thuoc();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (thuoc_ID > 0)
            {
                String ten = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TenThuoc").ToString();
                DialogResult dialogResult = MessageBox.Show(ten, "Xác nhận xóa 'Nhà Cung Cấp' ?", MessageBoxButtons.YesNo);
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
        #endregion
    }
}