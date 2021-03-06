﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBenhVien
{
    public partial class frmTinhTP : Form
    {
        HospitalEntities db = new HospitalEntities();
        public frmTinhTP()
        {
            InitializeComponent();
        }

        #region method
        private bool isEmpty()
        {
            if (txtQuocGia.Text.Trim() != "" && txtTenTinhTP.Text.Trim() != "")
            {
                return false;
            }
            return true;
        }

        private bool save(TinhTP tinhTP)
        {
            try
            {
                db.TinhTPs.Add(tinhTP);
                db.SaveChanges();

                return true;

            }catch(Exception e){
                MessageBox.Show(e.Message);
                return false;
            }
            
        }
        #endregion

        #region event
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isEmpty())
            {
                frmMsgOK frmOK = new frmMsgOK();
                frmOK.HienThi("Thông tin bạn nhập vào chưa hợp lệ", "Thông báo");
                frmOK.ShowDialog();
            }
            else
            {
                TinhTP tinhTP = new TinhTP() { TenTinhTP = txtTenTinhTP.Text, QuocGia = txtQuocGia.Text };

                if (save(tinhTP))
                {
                    txtTenTinhTP.Text = "";
                    txtQuocGia.Text = "";
                }                
            }

        }
        #endregion
    }
}
