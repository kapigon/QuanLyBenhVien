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

            LoadNhomThuoc();
            LoadTenThuoc();
            LoadHoatChat();
            LoadHangSanXuat();
            LoadNuocSanXuat();
            LoadDS_Thuoc();
        }
        
        #region methods
        private void LoadDS_Thuoc()
        {
            var query = from thuoc in db.Thuoc
                        join nhomthuoc in db.NhomThuoc on thuoc.NhomThuoc_ID equals nhomthuoc.ID
                        from hoatchat in db.HoatChat.Where(hc => hc.ID == thuoc.HoatChat_ID).DefaultIfEmpty()//on thuoc.HoatChat_ID equals hoatchat.ID
                        select new
                        {
                            ID = thuoc.ID,
                            TenThuoc = thuoc.TenThuoc,
                            MaThuoc = thuoc.MaThuoc,
                            TenNhom = nhomthuoc.TenNhom,
                            HoatChat = hoatchat.TenHoatChat,
                            ThoiGianCanhBaoHetHan = thuoc.ThoiGianCanhBaoHetHan,
                            TonKhoToiThieu = thuoc.TonKhoToiThieu,
                            KichHoat = thuoc.KichHoat
                        };
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
        private void LoadTenThuoc()
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

            //cbbColNhomThuoc.DataSource = result.ToList();
            //cbbColNhomThuoc.DisplayMember = "TenNhom";
            //cbbColNhomThuoc.ValueMember = "ID";
        }
        private void LoadHoatChat()
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
        private void LoadHangSanXuat()
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

        private void LoadNuocSanXuat()
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

            int thuoc_Id = 0;
            //String tenthuoc = cbbTenThuoc.Text.Trim();
            int nhomthuoc_Id = cbbNhomThuoc.EditValue != "" ? Convert.ToInt32(cbbNhomThuoc.EditValue) : 0;
            int hoatchat_Id = cbbHoatChat.EditValue != "" ? Convert.ToInt32(cbbHoatChat.EditValue) : 0;
            int hangsanxuat_Id = cbbHangSanXuat.EditValue != "" ? Convert.ToInt32(cbbHangSanXuat.EditValue) : 0;
            int nuocsanxuat_Id = Convert.ToInt32(cbbNuocSanXuat.EditValue);
            bool kichhoat = Convert.ToBoolean(chkKichHoat.EditValue);

                 
            var query = rpo_Thuoc.search(thuoc_Id, nhomthuoc_Id, hoatchat_Id, hangsanxuat_Id, nuocsanxuat_Id, kichhoat);
            grvDSThuoc.DataSource = new BindingList<Thuoc>(query.ToList());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (thuoc_ID > 0)
            {
                frmThemThuoc frmThemThuoc = new frmThemThuoc();
                frmThemThuoc.FormClosed += new FormClosedEventHandler(frmDSThuoc_Closed);
                frmThemThuoc.loadData(thuoc_ID);
                frmThemThuoc.ShowInTaskbar = false;
                frmThemThuoc.ShowDialog();
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