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
using DevExpress.XtraGrid.Views.Grid;

namespace QLBV_DEV
{
    public partial class frmKiemKe : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities db = new HospitalEntities();
        int thuoc_ID = 0;
        int iRow;
        CT_Thuoc_PhieuNhapRepository rpo_CT_Thuoc = new CT_Thuoc_PhieuNhapRepository();

        #endregion

        public frmKiemKe()
        {
            InitializeComponent();
            LoadDS_Thuoc();
            LoadNhomThuoc();
            LoadTenThuoc();
            LoadHoatChat();
            LoadHangSanXuat();
            LoadNuocSanXuat();
            LoadSoLo();
            LoadKhoHang();
            LoadViTri();
            LoadDVT();
            gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
        }
        
        #region methods
        private void LoadDS_Thuoc()
        {
            var query = from ct_thuoc_nhap in db.CT_Thuoc_PhieuNhap
                        join thuoc in db.Thuoc on ct_thuoc_nhap.Thuoc_ID equals thuoc.ID
                        //from pdc in db.PhieuDieuChinh.Where(pdc => pdc.CT_Thuoc_PhieuNhap_ID == ct_thuoc_nhap.ID).DefaultIfEmpty()
                       
                        //join pdc in db.PhieuDieuChinh on ct_thuoc_nhap.ID equals pdc.CT_Thuoc_PhieuNhap_ID
                        //join nhomthuoc in db.NhomThuoc on thuoc.NhomThuoc_ID equals nhomthuoc.ID
                        //from hoatchat in db.HoatChat.Where(hc => hc.ID == thuoc.HoatChat_ID).DefaultIfEmpty()//on thuoc.HoatChat_ID equals hoatchat.ID
                        //from hangsanxuat in db.HangSanXuat.Where(hsx => hsx.ID == thuoc.HangSanXuat_ID).DefaultIfEmpty()

                        /*
                        * Xử lý công số lượng tăng giảm trong phiếu điều chỉnh
                        * join tinhtong in
                           (from pdc in db.PhieuDieuChinh
                            group pdc by pdc.CT_Thuoc_PhieuNhap_ID into gr_ID
                           select new {
                               CT_Thuoc_PhieuNhap_ID = gr_ID.FirstOrDefault().CT_Thuoc_PhieuNhap_ID,
                               SoLuongTang = gr_ID.Sum(p => p.SoLuongTang),
                               SoLuongGiam = gr_ID.Sum(p => p.SoLuongGiam)
                           }) on ct_thuoc_nhap.ID equals tinhtong.CT_Thuoc_PhieuNhap_ID*/
                        select new
                        {
                            ID          = ct_thuoc_nhap.ID,
                            ThuocID     = thuoc.ID,
                            MaThuoc     = thuoc.MaThuoc,
                            TenThuoc    = thuoc.TenThuoc,
                            DVT         = thuoc.DVT_Le_ID,
                            HSD         = ct_thuoc_nhap.HSD,
                            SoLo        = ct_thuoc_nhap.SoLo,
                            TonKho      = ct_thuoc_nhap.TonKho,
                            TonSoSach   = ct_thuoc_nhap.TonKho,
                            KichHoat    = thuoc.KichHoat
                            //TonKho = ct_thuoc_nhap.TonKho + tinhtong.SoLuongTang - tinhtong.SoLuongGiam,
                            //TenNhom = nhomthuoc.TenNhom,
                            //HoatChat = hoatchat.TenHoatChat,
                            //ThoiGianCanhBaoHetHan = thuoc.ThoiGianCanhBaoHetHan,
                            //TonKhoToiThieu = thuoc.TonKhoToiThieu,
                        };
            if (query.ToList().Count() > 0)
            {
                grvDSThuoc.DataSource = query.ToList();
                //grvDSThuoc.DataSource = new BindingList<Thuoc>(db.Thuoc.Where(p=>p.KichHoat == true || p.KichHoat == null).ToList());

            }
        }
        private void LoadTenThuoc()
        {
            var result = from t in db.Thuoc
                         select new
                         {
                             ID = t.ID,
                             TenThuoc = t.TenThuoc,
                             MaThuoc  = t.MaThuoc,
                         };
            cbbTenThuoc.Properties.DataSource = result.ToList();
            cbbTenThuoc.Properties.DisplayMember = "TenThuoc";
            cbbTenThuoc.Properties.ValueMember = "ID";
        }

        private void LoadNhomThuoc()
        {
            var result = from nt in db.NhomThuoc
                         select new
                         {
                             ID = nt.ID,
                             TenNhom = nt.TenNhom,
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
            var result = from hc in db.HoatChat
                         select new
                         {
                             ID = hc.ID,
                             TenHoatChat = hc.TenHoatChat,
                         };

            cbbHoatChat.Properties.DataSource = result.ToList();
            cbbHoatChat.Properties.DisplayMember = "TenHoatChat";
            cbbHoatChat.Properties.ValueMember = "ID";

        }
        private void LoadHangSanXuat()
        {
            var result = from hsx in db.HangSanXuat
                         select new
                         {
                             ID = hsx.ID,
                             TenHangSX = hsx.TenHangSX,
                         };

            cbbHangSanXuat.Properties.DataSource = result.ToList();
            cbbHangSanXuat.Properties.DisplayMember = "TenHangSX";
            cbbHangSanXuat.Properties.ValueMember = "ID";

        }

        private void LoadNuocSanXuat()
        {
            var result = from nsx in db.NuocSanXuat
                         select new
                         {
                             ID = nsx.ID,
                             TenNuoc = nsx.TenNuoc,
                         };

            cbbNuocSanXuat.Properties.DataSource = result.ToList();
            cbbNuocSanXuat.Properties.DisplayMember = "TenNuoc";
            cbbNuocSanXuat.Properties.ValueMember = "ID";

        }
        private void LoadSoLo()
        {
            var result = from ct_t in db.CT_Thuoc_PhieuNhap
                         join pnt in db.PhieuNhapThuoc on ct_t.PhieuNhapHang_ID equals pnt.ID
                         select new
                         {
                             ID = ct_t.ID,
                             SoLo = pnt.ID + (ct_t.SoLo != null && ct_t.SoLo != "" ? " - " + ct_t.SoLo : ""),
                         };

            cbbSoLo.Properties.DataSource = result.ToList();
            cbbSoLo.Properties.DisplayMember = "SoLo";
            cbbSoLo.Properties.ValueMember = "ID";

        }
        private void LoadKhoHang()
        {
            var result = from k in db.Kho
                         select new
                         {
                             ID = k.ID,
                             TenKho = k.TenKho,
                         };

            cbbKhoHang.Properties.DataSource = result.ToList();
            cbbKhoHang.Properties.DisplayMember = "TenKho";
            cbbKhoHang.Properties.ValueMember = "ID";

        }

        private void LoadViTri()
        {
            var result = from vt in db.ViTri
                         select new
                         {
                             ID = vt.ID,
                             TenViTri = vt.TenViTri,
                         };

            cbbViTri.Properties.DataSource = result.ToList();
            cbbViTri.Properties.DisplayMember = "TenViTri";
            cbbViTri.Properties.ValueMember = "ID";

        }
        private void LoadDVT()
        {
            var result = from dvt in db.DonViTinh
                         select new
                         {
                             ID = dvt.ID,
                             TenDVT = dvt.TenDVT,
                         };

            cbbColDVT.DataSource = result.ToList();
            cbbColDVT.DisplayMember = "TenDVT";
            cbbColDVT.ValueMember = "ID";

        }
        #endregion

        #region events
        private void frmDSThuoc_Load(object sender, EventArgs e)
        {
            
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            frmPhieuDieuChinh frmPhieuDieuChinh = new frmPhieuDieuChinh();
            frmPhieuDieuChinh.FormClosed += new FormClosedEventHandler(frmDSThuoc_Closed);
            frmPhieuDieuChinh.loadData(gridView1);
            frmPhieuDieuChinh.ShowInTaskbar = false;
            frmPhieuDieuChinh.ShowDialog();
        }

        private void frmDSThuoc_Closed(object sender, FormClosedEventArgs e)
        {
            LoadDS_Thuoc();
        }
        
        private void btnTim_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(cbbNhomThuoc.EditValue.ToString());
            //int thuoc_id = 0;
            //String tenthuoc = cbbTenThuoc.Text.Trim();
            //int nhomthuoc_ID = cbbNhomThuoc.EditValue != "" ? Convert.ToInt32(cbbNhomThuoc.EditValue) : 0;
            //int hoatchat_ID = cbbHoatChat.EditValue != "" ? Convert.ToInt32(cbbHoatChat.EditValue) : 0;
            //int hangsanxuat_Id = cbbHangSanXuat.EditValue != "" ? Convert.ToInt32(cbbHangSanXuat.EditValue) : 0;
            //bool kichhoat = Convert.ToBoolean(chkKichHoat.EditValue);


            //var query = rpo_Thuoc.search(thuoc_id, tenthuoc, nhomthuoc_ID, hoatchat_ID, hangsanxuat_Id, kichhoat);
            //grvDSThuoc.DataSource = new BindingList<Thuoc>(query.ToList());
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
        #endregion

        
    }
}