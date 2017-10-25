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
    public partial class frmTonKhoTheoThuoc : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities db = new HospitalEntities();
        ThuocRepository rpo_Thuoc = new ThuocRepository();
        #endregion

        public frmTonKhoTheoThuoc()
        {
            InitializeComponent();
            LoadDS_TonKhoTheoThuoc();

            //Cách Binding dữ liệu
            //textEdit1.DataBindings.Add(new Binding("Text", grvTonKhoTheoThuoc.DataSource, "TenThuoc", true, DataSourceUpdateMode.Never));
        }


        private void LoadDS_TonKhoTheoThuoc()
        {
            //Lấy danh sách tồn kho theo từng loại thuốc
            //var query = from thuoc in db.Thuoc
            //            join nhomthuoc in db.NhomThuoc on thuoc.NhomThuoc_ID equals nhomthuoc.ID
            //            join hangsanxuat in db.HangSanXuat on thuoc.HangSanXuat_ID equals hangsanxuat.ID

            //var query = from thuoc in db.Thuoc
            //            from nhomthuoc in db.NhomThuoc
            //            from hangsanxuat in db.HangSanXuat
            //            where thuoc.HangSanXuat_ID == hangsanxuat.ID 
            //                  ||
            //                  thuoc.NhomThuoc_ID == nhomthuoc.ID

            var query = from thuoc in db.Thuoc
                        join nhomthuoc in db.NhomThuoc on thuoc.NhomThuoc_ID equals nhomthuoc.ID                         
                       // join hangsanxuat in db.HangSanXuat on thuoc.HangSanXuat_ID equals hangsanxuat.ID                      
                        

                        select new
                        {
                            Id          = thuoc.ID,
                            MaThuoc     = thuoc.MaThuoc,
                            TenThuoc    = thuoc.TenThuoc,

                            TonKho      = thuoc.TonKho,
                           // HangSanXuat = hangsanxuat.TenHangSX,
                            NhomThuoc = nhomthuoc.TenNhom
                        };
            grvTonKhoTheoThuoc.DataSource = query.ToList();
        }
    }
}