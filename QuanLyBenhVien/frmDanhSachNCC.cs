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
    public partial class frmDanhSachNCC : Form
    {
        HospitalEntities db = new HospitalEntities();
        int nccID = 0;
        DataGridViewRow dgvRow = new DataGridViewRow();
        public frmDanhSachNCC()
        {
            InitializeComponent();
            LoadNhaCungCap();
            addBinding();
        }

       

        #region methods
        private void LoadNhaCungCap()
        {
            /*var result = from nv in db.NhaCungCaps
                         where nv.KichHoat == true
                         select nv;
            dgvDanhSachThuoc.DataSource = result.ToList();*/
            DataTable dt = new DataTable();
            var query = from ncc in db.NhaCungCaps
                        select new {
                            ID = ncc.ID,
                            MaNCC = ncc.MaNCC,
                            TenNCC = ncc.TenNCC,
                            DiaChi = ncc.DiaChi,
                            Email = ncc.Email,
                            DienThoai = ncc.DienThoai,
                            KichHoat = ncc.KichHoat
                        };
            DataRow dr = null;
            
            if(query.ToList().Count() > 0){
                /*for(int i = 0; i < query.ToList().Count(); i ++){
                    dgvDanhSachThuoc.Rows.Add();
                    dgvDanhSachThuoc.Rows[i].Cells[0].Value = query.ToList()[i].ID;
                    dgvDanhSachThuoc.Rows[i].Cells[1].Value = query.ToList()[i].MaNCC;
                    dgvDanhSachThuoc.Rows[i].Cells[2].Value = query.ToList()[i].TenNCC;
                    dgvDanhSachThuoc.Rows[i].Cells[3].Value = query.ToList()[i].DiaChi;
                    dgvDanhSachThuoc.Rows[i].Cells[4].Value = query.ToList()[i].Email;
                    dgvDanhSachThuoc.Rows[i].Cells[5].Value = query.ToList()[i].SDT;
                    dgvDanhSachThuoc.Rows[i].Cells[6].Value = query.ToList()[i].KichHoat;
                    //dgvDanhSachThuoc.Rows.Add("001", "1234", "432423", "1111", "111", true);
                }*/
                dgvDanhSachThuoc.DataSource = query.ToList();
                dgvRow = dgvDanhSachThuoc.Rows[0];
                nccID = Convert.ToInt32(dgvRow.Cells[0].Value);
                dgvDanhSachThuoc.ReadOnly = true;

            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            
            /*dt.Columns.Add("MaNCC", typeof(string));
            dt.Columns.Add("TenNCC", typeof(string));
            dt.Columns.Add("DiaChi", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("SDT", typeof(string));
            dt.Columns.Add("KichHoat", typeof(string));
            
            foreach(var row in query){
                    dr = dt.NewRow();
                    dr["MaNCC"] = row.MaNCC;
                    dr["TenNCC"] = row.TenNCC;
                    dr["DiaChi"] = row.DiaChi;
                    dr["Email"] = row.Email;
                    dr["SDT"] = row.SDT;
                    dr["KichHoat"] = row.KichHoat;

                    dt.Rows.Add(dr);
                }
             dgvDanhSachThuoc.DataSource = dt;
             * */
        }
        private void addBinding()
        {
           // nccID = Convert.ToInt32(new Binding("Text", dgvDanhSachThuoc.DataSource, 'ID'));
        }
        #endregion

        #region events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNhaCungCap nhaCC = new frmNhaCungCap();
            nhaCC.FormClosed += new FormClosedEventHandler(frmNhaCCClosed);
            nhaCC.ShowDialog();
        }
        private void frmNhaCCClosed(object sender, FormClosedEventArgs e)
        {
            LoadNhaCungCap();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (nccID > 0)
            {
                DialogResult dialogResult = MessageBox.Show(dgvRow.Cells[2].Value.ToString(), "Xác nhận xóa 'Nhà Cung Cấp' ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                    NhaCungCap objNCC = db.NhaCungCaps.Where(p => p.ID == nccID).SingleOrDefault();
                    db.NhaCungCaps.Remove(objNCC);
                    db.SaveChanges();

                    // Tải lại danh sách nhà cung cấp
                    LoadNhaCungCap();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (nccID > 0)
            {
                frmNhaCungCap frmNCC = new frmNhaCungCap();
                frmNCC.FormClosed += new FormClosedEventHandler(frmNCCClosed);
                frmNCC.loadData(nccID);
                frmNCC.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hãy lựa chọn dòng cần sửa.");
            }
        }

        private void frmNCCClosed(object sender, FormClosedEventArgs e)
        {
            LoadNhaCungCap();
        }
        #endregion

        private void dgvDanhSachThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            dgvRow = dgvDanhSachThuoc.Rows[index];
            nccID = Convert.ToInt32(dgvRow.Cells[0].Value);
            MessageBox.Show(index.ToString());
        }

        
    }
}
