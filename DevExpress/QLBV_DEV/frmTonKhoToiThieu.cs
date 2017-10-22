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
    public partial class frmTonKhoToiThieu : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities db = new HospitalEntities();
        ThuocRepository rpo_Thuoc = new ThuocRepository();
        #endregion
        public frmTonKhoToiThieu()
        {
            InitializeComponent();
            LoadDS_TonKhoToiThieu();
        }

        private void LoadDS_TonKhoToiThieu()
        {
                        var query = from thuoc in db.Thuoc
                        join nhomthuoc in db.NhomThuoc on thuoc.NhomThuoc_ID equals nhomthuoc.ID                         
                       // join hangsanxuat in db.HangSanXuat on thuoc.HangSanXuat_ID equals hangsanxuat.ID                      
                        where thuoc.TonKho < thuoc.TonKhoToiThieu

                        select new
                        {
                            Id          = thuoc.ID,
                            MaThuoc     = thuoc.MaThuoc,
                            TenThuoc    = thuoc.TenThuoc,

                            TonKho      = thuoc.TonKho,
                            TonKhoToiThieu = thuoc.TonKhoToiThieu,
                           // HangSanXuat = hangsanxuat.TenHangSX,
                            NhomThuoc = nhomthuoc.TenNhom
                        };
            grvTonKhoToiThieu.DataSource = query.ToList();
        }
    }
}