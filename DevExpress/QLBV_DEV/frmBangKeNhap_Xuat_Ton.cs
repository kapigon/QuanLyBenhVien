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
    public partial class frmBangKeNhap_Xuat_Ton : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities db = new HospitalEntities();
        PhieuNhapThuocRepository rpo_PhieuNhap = new PhieuNhapThuocRepository();

        int phieuNhapID = 0;

        int iRow;
        #endregion

        public frmBangKeNhap_Xuat_Ton()
        {
            InitializeComponent();
            LoadDoanhThuTheoNgay();
        }

        #region methods
        private void LoadDoanhThuTheoNgay()
        {
            //var result = from nv in db.PhieuNhapThuoc
            //             where nv.Xoa == false
            //             select nv;
            //var result = rpo_PhieuNhap.GetAllNotDelete();
            var result = from ct_phieuxuat in db.CT_Thuoc_PhieuXuat
                         join phieuxuat in db.PhieuXuatThuoc on ct_phieuxuat.PhieuXuatHang_ID equals phieuxuat.ID
                         join ct_phieunhap in db.CT_Thuoc_PhieuNhap on ct_phieuxuat.CT_Thuoc_PhieuNhap_ID equals ct_phieunhap.ID
                         join thuoc in db.Thuoc on ct_phieunhap.Thuoc_ID equals thuoc.ID
                         join dvt in db.DonViTinh on ct_phieuxuat.DVT_Theo_DVT_Thuoc_ID equals dvt.ID

                        //join ncc_kh in db.NCC_KH on phieunhap.NCC_KH_ID equals ncc_kh.ID
                         //from ncc_kh in db.NCC_KH.Where(ncc => ncc.ID == phieunhap.NCC_KH_ID).DefaultIfEmpty()
                        where phieuxuat.NgayTao == DateTime.Today
                        //orderby phieunhap.ID ascending
                        select new
                        {
                            ID          = thuoc.ID,
                            MaThuoc     = thuoc.MaThuoc,
                            TenThuoc    = thuoc.TenThuoc,
                            SoLuong     = ct_phieuxuat.SoLuong,
                            GiaBan      = ct_phieuxuat.GiaBan,
                            DVT         = dvt.TenDVT,
                            NgayBan     = phieuxuat.NgayTao,
                            TongTien    = ct_phieuxuat.TongTien
                            //SoPhieu     = phieux.SoPhieu,
                            //SoHoaDon    = phieunhap.SoHoaDon,
                            //NgayNhap    = phieunhap.NgayNhap,
                            //NCC_KH_ID   = ncc_kh.TenNCC_KH,
                            //ThueSuat    = phieunhap.ThueSuat + "%",
                            //ChietKhau   = phieunhap.ChietKhau,
                            //TongTienTra = phieunhap.TongTienTra
                        };
            grdDS_BanHang.DataSource = result.ToList();
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

                    PhieuNhapThuoc obj_PhieuNhap = rpo_PhieuNhap.GetSingle(id);
                    obj_PhieuNhap.Xoa = true;
                    obj_PhieuNhap.NgayXoa = DateTime.Now;

                    rpo_PhieuNhap.Save(obj_PhieuNhap);


                    // Tải lại danh sách nhà cung cấp
                    LoadDoanhThuTheoNgay();
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
            LoadDoanhThuTheoNgay();
        }

        private void frmDSPhieuNhap_Load(object sender, EventArgs e)
        {
            
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //int ncc_kh_ID       = Convert.ToInt32(cbbNCC_KH.EditValue); 
            //String soPhieu      = txtSoPhieu.Text.Trim();
            //DateTime tuNgay     = Convert.ToDateTime(dateTuNgay.EditValue);
            //DateTime denNgay    = Convert.ToDateTime(dateDenNgay.EditValue);
            //String soHoaDon     = txtSoHoaDon.Text.Trim();

            //var query = rpo_PhieuNhap.search(ncc_kh_ID, soPhieu, tuNgay, denNgay, soHoaDon);
            //grdDS_BanHang.DataSource = new BindingList<PhieuNhapThuoc>(query.ToList());
        }
        #endregion
    }
}