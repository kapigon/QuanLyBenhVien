namespace QuanLyBenhVien
{
    partial class frmDanhSachPhieuNhapThuoc
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
            this.grbThaoTac = new System.Windows.Forms.GroupBox();
            this.btnView = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtTongCong = new System.Windows.Forms.TextBox();
            this.lblTongCong = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grbTimKiem = new System.Windows.Forms.GroupBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.lblLoaiDon = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.lblBacSy = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.txtKho = new System.Windows.Forms.TextBox();
            this.lblKho = new System.Windows.Forms.Label();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BacSyKeToa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDanhSachThuoc = new System.Windows.Forms.DataGridView();
            this.SoDH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbThaoTac.SuspendLayout();
            this.grbTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachThuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // grbThaoTac
            // 
            this.grbThaoTac.Controls.Add(this.btnView);
            this.grbThaoTac.Controls.Add(this.btnAdd);
            this.grbThaoTac.Controls.Add(this.btnExit);
            this.grbThaoTac.Location = new System.Drawing.Point(12, 530);
            this.grbThaoTac.Name = "grbThaoTac";
            this.grbThaoTac.Size = new System.Drawing.Size(1045, 64);
            this.grbThaoTac.TabIndex = 55;
            this.grbThaoTac.TabStop = false;
            this.grbThaoTac.Text = "Thao tác";
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
            // txtTongCong
            // 
            this.txtTongCong.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtTongCong.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTongCong.Location = new System.Drawing.Point(920, 504);
            this.txtTongCong.Name = "txtTongCong";
            this.txtTongCong.Size = new System.Drawing.Size(137, 20);
            this.txtTongCong.TabIndex = 54;
            // 
            // lblTongCong
            // 
            this.lblTongCong.AutoSize = true;
            this.lblTongCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongCong.Location = new System.Drawing.Point(815, 507);
            this.lblTongCong.Name = "lblTongCong";
            this.lblTongCong.Size = new System.Drawing.Size(68, 13);
            this.lblTongCong.TabIndex = 53;
            this.lblTongCong.Text = "Tổng cộng";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(242, 40);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(101, 20);
            this.dateTimePicker2.TabIndex = 47;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(126, 40);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(101, 20);
            this.dateTimePicker1.TabIndex = 46;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(984, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(46, 23);
            this.btnSearch.TabIndex = 45;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // grbTimKiem
            // 
            this.grbTimKiem.Controls.Add(this.dateTimePicker2);
            this.grbTimKiem.Controls.Add(this.dateTimePicker1);
            this.grbTimKiem.Controls.Add(this.btnSearch);
            this.grbTimKiem.Controls.Add(this.textBox8);
            this.grbTimKiem.Controls.Add(this.lblLoaiDon);
            this.grbTimKiem.Controls.Add(this.textBox7);
            this.grbTimKiem.Controls.Add(this.lblGhiChu);
            this.grbTimKiem.Controls.Add(this.textBox6);
            this.grbTimKiem.Controls.Add(this.lblBacSy);
            this.grbTimKiem.Controls.Add(this.textBox5);
            this.grbTimKiem.Controls.Add(this.lblDiaChi);
            this.grbTimKiem.Controls.Add(this.textBox4);
            this.grbTimKiem.Controls.Add(this.lblTenKH);
            this.grbTimKiem.Controls.Add(this.lblDenNgay);
            this.grbTimKiem.Controls.Add(this.lblTuNgay);
            this.grbTimKiem.Controls.Add(this.txtKho);
            this.grbTimKiem.Controls.Add(this.lblKho);
            this.grbTimKiem.Location = new System.Drawing.Point(12, 4);
            this.grbTimKiem.Name = "grbTimKiem";
            this.grbTimKiem.Size = new System.Drawing.Size(1045, 69);
            this.grbTimKiem.TabIndex = 52;
            this.grbTimKiem.TabStop = false;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(867, 40);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 20);
            this.textBox8.TabIndex = 44;
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
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(744, 40);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 20);
            this.textBox7.TabIndex = 42;
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
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(626, 40);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 40;
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
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(477, 40);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(131, 20);
            this.textBox5.TabIndex = 38;
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
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(360, 40);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 36;
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
            // txtKho
            // 
            this.txtKho.Location = new System.Drawing.Point(9, 40);
            this.txtKho.Name = "txtKho";
            this.txtKho.Size = new System.Drawing.Size(100, 20);
            this.txtKho.TabIndex = 30;
            // 
            // lblKho
            // 
            this.lblKho.AutoSize = true;
            this.lblKho.Location = new System.Drawing.Point(41, 17);
            this.lblKho.Name = "lblKho";
            this.lblKho.Size = new System.Drawing.Size(26, 13);
            this.lblKho.TabIndex = 29;
            this.lblKho.Text = "Kho";
            // 
            // TongTien
            // 
            this.TongTien.DataPropertyName = "TongTien";
            this.TongTien.HeaderText = "Tổng tiền";
            this.TongTien.Name = "TongTien";
            this.TongTien.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TongTien.Width = 120;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Width = 200;
            // 
            // BacSyKeToa
            // 
            this.BacSyKeToa.DataPropertyName = "BacSyKeToa";
            this.BacSyKeToa.HeaderText = "Bác sỹ kê toa";
            this.BacSyKeToa.Name = "BacSyKeToa";
            this.BacSyKeToa.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BacSyKeToa.Width = 120;
            // 
            // dgvDanhSachThuoc
            // 
            this.dgvDanhSachThuoc.AllowUserToAddRows = false;
            this.dgvDanhSachThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachThuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SoDH,
            this.NgayDH,
            this.TenKH,
            this.DiaChi,
            this.BacSyKeToa,
            this.GhiChu,
            this.TongTien});
            this.dgvDanhSachThuoc.Location = new System.Drawing.Point(12, 87);
            this.dgvDanhSachThuoc.Name = "dgvDanhSachThuoc";
            this.dgvDanhSachThuoc.Size = new System.Drawing.Size(1045, 401);
            this.dgvDanhSachThuoc.TabIndex = 51;
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
            // frmDanhSachPhieuNhapThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 599);
            this.Controls.Add(this.grbThaoTac);
            this.Controls.Add(this.txtTongCong);
            this.Controls.Add(this.lblTongCong);
            this.Controls.Add(this.grbTimKiem);
            this.Controls.Add(this.dgvDanhSachThuoc);
            this.Name = "frmDanhSachPhieuNhapThuoc";
            this.Text = "DANH SÁCH PHIẾU NHẬP THUỐC";
            this.grbThaoTac.ResumeLayout(false);
            this.grbTimKiem.ResumeLayout(false);
            this.grbTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachThuoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbThaoTac;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtTongCong;
        private System.Windows.Forms.Label lblTongCong;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox grbTimKiem;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label lblLoaiDon;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label lblBacSy;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label lblTenKH;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.TextBox txtKho;
        private System.Windows.Forms.Label lblKho;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn BacSyKeToa;
        private System.Windows.Forms.DataGridView dgvDanhSachThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
    }
}