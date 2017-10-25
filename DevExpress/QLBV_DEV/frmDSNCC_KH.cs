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

namespace QLBV_DEV
{
    public partial class frmDSNCC_KH : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities db = new HospitalEntities();
        int ncc_kh_ID = 0;
        NCC_KHRepository rpo_NCC_KH = new NCC_KHRepository();

        #endregion

        public frmDSNCC_KH()
        {
            InitializeComponent();
            LoadDS_NCC_KH();
        }

        #region methods
        private void LoadDS_NCC_KH()
        {
           /* var result = from nv in db.NCC_KH
                         select nv;
            grvDSNCC_KH.DataSource = result.ToList();*/
            var query = from ncc_kh in db.NCC_KH
                        join loaiNCC_KH in db.LoaiNCC_KH on ncc_kh.LoaiNCC_KH_ID equals loaiNCC_KH.ID 
                        select new
                        {
                            ID              = ncc_kh.ID,
                            MaNCC_KH        = ncc_kh.MaNCC_KH,
                            TenNCC_KH       = ncc_kh.TenNCC_KH,
                            LoaiNCC_KH_ID   = loaiNCC_KH.TenLoaiNCC_KH,
                            DiaChi          = ncc_kh.DiaChi,
                            SDT             = ncc_kh.DienThoai,
                            MST             = ncc_kh.MST,
                            KichHoat        = ncc_kh.KichHoat
                        };
            
            if (query.ToList().Count() > 0)
            {
                grvDSNCC_KH.DataSource = query.ToList();
                //grvDSNCC_KH.DataSource = new BindingList<NCC_KH>(db.NCC_KH.ToList());
            }
            else
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }
        private void LoadLoaiNCC_KH()
        {
            var result = from ncc in db.LoaiNCC_KH
                         select new
                         {
                             ID = ncc.ID,
                             TenLoaiNCC_KH = ncc.TenLoaiNCC_KH
                         };
            cbbLoaiNCC_KH.Properties.DataSource = new BindingList<LoaiNCC_KH>(db.LoaiNCC_KH.ToList());
            cbbLoaiNCC_KH.Properties.DisplayMember = "TenLoaiNCC_KH";
            cbbLoaiNCC_KH.Properties.ValueMember = "ID";

            //cbbColLoaiNCC_KH.DataSource = result.ToList();
            //cbbColLoaiNCC_KH.DisplayMember = "TenLoaiNCC_KH";
            //cbbColLoaiNCC_KH.ValueMember = "ID";
        }
        #endregion

        #region events
        private void frmDSNCC_KH_Load(object sender, EventArgs e)
        {
            LoadLoaiNCC_KH();
        }

        
        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemNCC_KH f_ncc_kh = new frmThemNCC_KH();
            f_ncc_kh.FormClosed += new FormClosedEventHandler(frmDSNCC_KHClosed);
            f_ncc_kh.ShowDialog();
        }

        private void frmDSNCC_KHClosed(object sender, FormClosedEventArgs e)
        {
            LoadDS_NCC_KH();
        }
        

        private void btnTim_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(cbbLoaiNCC_KH.EditValue.ToString());
            String maNCC_KH =txtMaNCC_KH.Text.Trim();
            int loai_CCC_KH = Convert.ToInt32(cbbLoaiNCC_KH.EditValue);
            String tenNCC_KH = txtTenNCC_KH.Text.Trim();

            var query = rpo_NCC_KH.search(maNCC_KH, loai_CCC_KH, tenNCC_KH);
            grvDSNCC_KH.DataSource = new BindingList<NCC_KH>(query.ToList());

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (ncc_kh_ID > 0)
            {
                frmThemNCC_KH frmNCC_KH = new frmThemNCC_KH();
                frmNCC_KH.FormClosed += new FormClosedEventHandler(frmNCC_KHClosed);
                frmNCC_KH.loadData(ncc_kh_ID);
                frmNCC_KH.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hãy lựa chọn dòng cần sửa.");
            }
        }

        private void frmNCC_KHClosed(object sender, FormClosedEventArgs e)
        {
            LoadDS_NCC_KH();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (ncc_kh_ID > 0)
            {
                String ten = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TenNCC_KH").ToString();
                DialogResult dialogResult = MessageBox.Show(ten, "Xác nhận xóa?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    NCC_KH objNCC_KH = rpo_NCC_KH.GetSingle(ncc_kh_ID);
                    //do something
                    /*NCC_KH objNCC_KH = db.NCC_KH.Where(p => p.ID == ncc_kh_ID).SingleOrDefault();
                    db.NCC_KH.Remove(objNCC_KH);
                    db.SaveChanges();
                    */
                    objNCC_KH.KichHoat = false;
                    rpo_NCC_KH.Save(objNCC_KH);
                    

                    // Tải lại danh sách nhà cung cấp
                    LoadDS_NCC_KH();
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
        #endregion

        private void grvDSNCC_KH_Click(object sender, EventArgs e)
        {
            // dừng xử lý nếu không kích vào dòng có dữ liệu
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID") == null)
                return;

            string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString();
            ncc_kh_ID = Convert.ToInt32(id);
            //MessageBox.Show(id);
        }
    }
}