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
    public partial class frmCapNhatGia : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities db = new HospitalEntities();
        int thuoc_ID = 0;
        int iRow;
        ThuocRepository rpo_Thuoc = new ThuocRepository();

        #endregion

        public frmCapNhatGia()
        {
            InitializeComponent();
            LoadNhomThuoc();
            LoadTenThuoc();
            LoadHoatChat();
            LoadHangSanXuat();
            LoadDS_Thuoc();
        }
        
        #region methods
        private void LoadDS_Thuoc()
        {
            var query = from thuoc in db.Thuoc
                        from nhomthuoc in db.NhomThuoc.Where(nt => nt.ID == thuoc.NhomThuoc_ID).DefaultIfEmpty()
                        from hoatchat in db.HoatChat.Where(hc => hc.ID == thuoc.HoatChat_ID).DefaultIfEmpty()//on thuoc.HoatChat_ID equals hoatchat.ID
                        select new
                        {
                            ID                      = thuoc.ID,
                            TenThuoc                = thuoc.TenThuoc,
                            MaThuoc                 = thuoc.MaThuoc,
                            TenNhom                 = nhomthuoc.TenNhom,
                            TenHoatChat             = hoatchat.TenHoatChat,
                            ThoiGianCanhBaoHetHan   = thuoc.ThoiGianCanhBaoHetHan,
                            TonKhoToiThieu          = thuoc.TonKhoToiThieu,
                            GiaBanLe                = thuoc.GiaBanLe,
                            GiaBanBuon              = thuoc.GiaBanBuon
                        };
            if (query.ToList().Count() > 0)
            {
                grvDSThuoc.DataSource = query.ToList();
                //grvDSThuoc.DataSource = new BindingList<Thuoc>(db.Thuoc.Where(p=>p.KichHoat == true || p.KichHoat == null).ToList());

            }
        }
        private void LoadTenThuoc()
        {
            var result = from ncc in db.Thuoc
                         select new
                         {
                             ID = ncc.ID,
                             TenThuoc = ncc.TenThuoc,
                             MaThuoc  = ncc.MaThuoc,
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
                             TenNhom = ncc.TenNhom,
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
                             TenHoatChat = ncc.TenHoatChat,
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
                             TenHangSX = ncc.TenHangSX,
                         };

            cbbHangSanXuat.Properties.DataSource = result.ToList();
            cbbHangSanXuat.Properties.DisplayMember = "TenHangSX";
            cbbHangSanXuat.Properties.ValueMember = "ID";

        }
        #endregion

        #region events                
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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

        }
        #endregion

        
    }
}