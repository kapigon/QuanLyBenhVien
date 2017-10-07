using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBenhVien
{
    public partial class frmToolManage : Form
    {
        public frmToolManage()
        {
            InitializeComponent();
        }


        #region events
        private void lnkDanhMucNhaCungCap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDanhSachNCC dsNCC = new frmDanhSachNCC();
            dsNCC.FormClosed += new FormClosedEventHandler(callBackAfterClose);
            this.Hide();
            dsNCC.ShowDialog();
        }

        private void lnkDanhSachDonThuoc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDanhSachDonHang dsDonHang = new frmDanhSachDonHang();
            dsDonHang.FormClosed += new FormClosedEventHandler(callBackAfterClose);
            this.Hide();
            dsDonHang.ShowDialog();
        }

        private void lnkDonBanThuoc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPhieuXuatThuoc donBanHang = new frmPhieuXuatThuoc();
            donBanHang.FormClosed += new FormClosedEventHandler(callBackAfterClose);
            this.Hide();
            donBanHang.ShowDialog();
        }

        private void lnkNhapKho_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPhieuNhapThuoc phieuNhapThuoc = new frmPhieuNhapThuoc();
            phieuNhapThuoc.FormClosed += new FormClosedEventHandler(callBackAfterClose);
            this.Hide();
            phieuNhapThuoc.ShowDialog();
        }

        private void lnkTonKho_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmTonKhoThuoc tonkho = new frmTonKhoThuoc();
            tonkho.FormClosed += new FormClosedEventHandler(callBackAfterClose);
            this.Hide();
            tonkho.ShowDialog();
        }

        private void callBackAfterClose(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        #endregion

        
    }
}
