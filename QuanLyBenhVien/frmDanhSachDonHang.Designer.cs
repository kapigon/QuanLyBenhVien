namespace QuanLyBenhVien
{
    partial class frmDanhSachDonHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExit = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvDanhSachThuoc = new System.Windows.Forms.DataGridView();
            this.grbTimKiem = new System.Windows.Forms.GroupBox();
            this.cbbLoaiDon = new System.Windows.Forms.ComboBox();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblLoaiDon = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtBacSyKeToa = new System.Windows.Forms.TextBox();
            this.lblBacSy = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.txtSoDH = new System.Windows.Forms.TextBox();
            this.lblSoDH = new System.Windows.Forms.Label();
            this.txtTongCong = new System.Windows.Forms.TextBox();
            this.lblTongCong = new System.Windows.Forms.Label();
            this.grbThaoTac = new System.Windows.Forms.GroupBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoDH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BacSyKeToa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachThuoc)).BeginInit();
            this.grbTimKiem.SuspendLayout();
            this.grbThaoTac.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(201, 25);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 23);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(105, 25);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(80, 23);
            this.btnView.TabIndex = 10;
            this.btnView.Text = "Xem";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(9, 25);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvDanhSachThuoc
            // 
            this.dgvDanhSachThuoc.AllowUserToAddRows = false;
            this.dgvDanhSachThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachThuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.SoDH,
            this.NgayDH,
            this.TenKH,
            this.DiaChi,
            this.BacSyKeToa,
            this.GhiChu,
            this.TongTien});
            this.dgvDanhSachThuoc.Location = new System.Drawing.Point(10, 88);
            this.dgvDanhSachThuoc.Name = "dgvDanhSachThuoc";
            this.dgvDanhSachThuoc.Size = new System.Drawing.Size(1045, 401);
            this.dgvDanhSachThuoc.TabIndex = 8;
            this.dgvDanhSachThuoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSachThuoc_CellClick);
            // 
            // grbTimKiem
            // 
            this.grbTimKiem.Controls.Add(this.cbbLoaiDon);
            this.grbTimKiem.Controls.Add(this.dtpDenNgay);
            this.grbTimKiem.Controls.Add(this.dtpTuNgay);
            this.grbTimKiem.Controls.Add(this.btnSearch);
            this.grbTimKiem.Controls.Add(this.lblLoaiDon);
            this.grbTimKiem.Controls.Add(this.txtGhiChu);
            this.grbTimKiem.Controls.Add(this.lblGhiChu);
            this.grbTimKiem.Controls.Add(this.txtBacSyKeToa);
            this.grbTimKiem.Controls.Add(this.lblBacSy);
            this.grbTimKiem.Controls.Add(this.txtDiaChi);
            this.grbTimKiem.Controls.Add(this.lblDiaChi);
            this.grbTimKiem.Controls.Add(this.txtTenKH);
            this.grbTimKiem.Controls.Add(this.lblTenKH);
            this.grbTimKiem.Controls.Add(this.lblDenNgay);
            this.grbTimKiem.Controls.Add(this.lblTuNgay);
            this.grbTimKiem.Controls.Add(this.txtSoDH);
            this.grbTimKiem.Controls.Add(this.lblSoDH);
            this.grbTimKiem.Location = new System.Drawing.Point(10, 5);
            this.grbTimKiem.Name = "grbTimKiem";
            this.grbTimKiem.Size = new System.Drawing.Size(1045, 69);
            this.grbTimKiem.TabIndex = 12;
            this.grbTimKiem.TabStop = false;
            // 
            // cbbLoaiDon
            // 
            this.cbbLoaiDon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLoaiDon.FormattingEnabled = true;
            this.cbbLoaiDon.Items.AddRange(new object[] {
            "Bán lẻ",
            "Theo đơn"});
            this.cbbLoaiDon.Location = new System.Drawing.Point(865, 39);
            this.cbbLoaiDon.Name = "cbbLoaiDon";
            this.cbbLoaiDon.Size = new System.Drawing.Size(104, 21);
            this.cbbLoaiDon.TabIndex = 48;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(242, 40);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(101, 20);
            this.dtpDenNgay.TabIndex = 47;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(126, 40);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(101, 20);
            this.dtpTuNgay.TabIndex = 46;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(984, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(46, 23);
            this.btnSearch.TabIndex = 45;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblLoaiDon
            // 
            this.lblLoaiDon.AutoSize = true;
            this.lblLoaiDon.Location = new System.Drawing.Point(894, 17);
            this.lblLoaiDon.Name = "lblLoaiDon";
            this.lblLoaiDon.Size = new System.Drawing.Size(49, 13);
            this.lblLoaiDon.TabIndex = 43;
            this.lblLoaiDon.Text = "Loại đơn";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(744, 40);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(100, 20);
            this.txtGhiChu.TabIndex = 42;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(773, 17);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(44, 13);
            this.lblGhiChu.TabIndex = 41;
            this.lblGhiChu.Text = "Ghi chú";
            // 
            // txtBacSyKeToa
            // 
            this.txtBacSyKeToa.Location = new System.Drawing.Point(626, 40);
            this.txtBacSyKeToa.Name = "txtBacSyKeToa";
            this.txtBacSyKeToa.Size = new System.Drawing.Size(100, 20);
            this.txtBacSyKeToa.TabIndex = 40;
            // 
            // lblBacSy
            // 
            this.lblBacSy.AutoSize = true;
            this.lblBacSy.Location = new System.Drawing.Point(640, 17);
            this.lblBacSy.Name = "lblBacSy";
            this.lblBacSy.Size = new System.Drawing.Size(72, 13);
            this.lblBacSy.TabIndex = 39;
            this.lblBacSy.Text = "Bác sỹ kê toa";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(477, 40);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(131, 20);
            this.txtDiaChi.TabIndex = 38;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(524, 17);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(40, 13);
            this.lblDiaChi.TabIndex = 37;
            this.lblDiaChi.Text = "Địa chỉ";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(360, 40);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(100, 20);
            this.txtTenKH.TabIndex = 36;
            // 
            // lblTenKH
            // 
            this.lblTenKH.AutoSize = true;
            this.lblTenKH.Location = new System.Drawing.Point(389, 17);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(44, 13);
            this.lblTenKH.TabIndex = 35;
            this.lblTenKH.Text = "Tên KH";
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(270, 17);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(53, 13);
            this.lblDenNgay.TabIndex = 33;
            this.lblDenNgay.Text = "Đến ngày";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(155, 17);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(46, 13);
            this.lblTuNgay.TabIndex = 31;
            this.lblTuNgay.Text = "Từ ngày";
            // 
            // txtSoDH
            // 
            this.txtSoDH.Location = new System.Drawing.Point(9, 40);
            this.txtSoDH.Name = "txtSoDH";
            this.txtSoDH.Size = new System.Drawing.Size(100, 20);
            this.txtSoDH.TabIndex = 30;
            // 
            // lblSoDH
            // 
            this.lblSoDH.AutoSize = true;
            this.lblSoDH.Location = new System.Drawing.Point(41, 17);
            this.lblSoDH.Name = "lblSoDH";
            this.lblSoDH.Size = new System.Drawing.Size(39, 13);
            this.lblSoDH.TabIndex = 29;
            this.lblSoDH.Text = "Số ĐH";
            // 
            // txtTongCong
            // 
            this.txtTongCong.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtTongCong.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTongCong.Location = new System.Drawing.Point(918, 505);
            this.txtTongCong.Name = "txtTongCong";
            this.txtTongCong.Size = new System.Drawing.Size(137, 20);
            this.txtTongCong.TabIndex = 49;
            // 
            // lblTongCong
            // 
            this.lblTongCong.AutoSize = true;
            this.lblTongCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongCong.Location = new System.Drawing.Point(813, 508);
            this.lblTongCong.Name = "lblTongCong";
            this.lblTongCong.Size = new System.Drawing.Size(68, 13);
            this.lblTongCong.TabIndex = 48;
            this.lblTongCong.Text = "Tổng cộng";
            // 
            // grbThaoTac
            // 
            this.grbThaoTac.Controls.Add(this.btnView);
            this.grbThaoTac.Controls.Add(this.btnAdd);
            this.grbThaoTac.Controls.Add(this.btnExit);
            this.grbThaoTac.Location = new System.Drawing.Point(10, 531);
            this.grbThaoTac.Name = "grbThaoTac";
            this.grbThaoTac.Size = new System.Drawing.Size(1045, 64);
            this.grbThaoTac.TabIndex = 50;
            this.grbThaoTac.TabStop = false;
            this.grbThaoTac.Text = "Thao tác";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // SoDH
            // 
            this.SoDH.DataPropertyName = "SoDH";
            this.SoDH.HeaderText = "Số ĐH";
            this.SoDH.Name = "SoDH";
            this.SoDH.Width = 80;
            // 
            // NgayDH
            // 
            this.NgayDH.DataPropertyName = "NgayDH";
            this.NgayDH.HeaderText = "Ngày ĐH";
            this.NgayDH.Name = "NgayDH";
            this.NgayDH.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // TenKH
            // 
            this.TenKH.DataPropertyName = "TenKH";
            this.TenKH.HeaderText = "Tên KH";
            this.TenKH.Name = "TenKH";
            this.TenKH.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TenKH.Width = 200;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DiaChi.Width = 180;
            // 
            // BacSyKeToa
            // 
            this.BacSyKeToa.DataPropertyName = "BacSyKeToa";
            this.BacSyKeToa.HeaderText = "Bác sỹ kê toa";
            this.BacSyKeToa.Name = "BacSyKeToa";
            this.BacSyKeToa.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BacSyKeToa.Width = 120;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Width = 200;
            // 
            // TongTien
            // 
            this.TongTien.DataPropertyName = "TongTien";
            this.TongTien.HeaderText = "Tổng tiền";
            this.TongTien.Name = "TongTien";
            this.TongTien.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TongTien.Width = 120;
            // 
            // frmDanhSachDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 599);
            this.Controls.Add(this.grbThaoTac);
            this.Controls.Add(this.txtTongCong);
            this.Controls.Add(this.lblTongCong);
            this.Controls.Add(this.grbTimKiem);
            this.Controls.Add(this.dgvDanhSachThuoc);
            this.Name = "frmDanhSachDonHang";
            this.Text = "DANH SÁCH ĐƠN HÀNG";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachThuoc)).EndInit();
            this.grbTimKiem.ResumeLayout(false);
            this.grbTimKiem.PerformLayout();
            this.grbThaoTac.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvDanhSachThuoc;
        private System.Windows.Forms.GroupBox grbTimKiem;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblLoaiDon;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtBacSyKeToa;
        private System.Windows.Forms.Label lblBacSy;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label lblTenKH;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.TextBox txtSoDH;
        private System.Windows.Forms.Label lblSoDH;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.TextBox txtTongCong;
        private System.Windows.Forms.Label lblTongCong;
        private System.Windows.Forms.GroupBox grbThaoTac;
        private System.Windows.Forms.ComboBox cbbLoaiDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn BacSyKeToa;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;

    }
}