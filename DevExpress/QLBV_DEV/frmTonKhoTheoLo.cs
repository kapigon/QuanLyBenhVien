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
    public partial class frmTonKhoTheoLo : DevExpress.XtraEditors.XtraForm
    {
        #region params
        HospitalEntities db = new HospitalEntities();
        ThuocRepository rpo_Thuoc = new ThuocRepository();
        #endregion

        public frmTonKhoTheoLo()
        {
            InitializeComponent();
        }

        private void frmTonKhoTheoLo_Load(object sender, EventArgs e)
        {
            LoadDS_TonKhoTheoLo();
        }

        private void LoadDS_TonKhoTheoLo()
        {
            //Lấy danh sách thuốc theo lô
            var query = from thuoc_phieunhap in db.CT_Thuoc_PhieuNhap
                        join thuoc in db.Thuoc on thuoc_phieunhap.Thuoc_ID equals thuoc.ID
                        join kho in db.Kho on thuoc_phieunhap.Kho_ID equals kho.ID
                        join vitri in db.ViTri on thuoc_phieunhap.ViTri_ID equals vitri.ID
                        select new
                        {
                            Id = thuoc_phieunhap.Thuoc_ID,
                            MaThuoc = thuoc.MaThuoc,
                            TenThuoc = thuoc.TenThuoc,
                            SoLo = thuoc_phieunhap.Kho_ID,
                            TonKho =thuoc_phieunhap.TonKho,
                            TenKho = kho.TenKho,
                            ViTri = vitri.TenViTri,
                            HSD = thuoc_phieunhap.HSD
                        };
            grvTonKhoTheoLo.DataSource = query.ToList();
        }
    }
}