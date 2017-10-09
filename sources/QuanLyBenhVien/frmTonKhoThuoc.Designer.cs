namespace QuanLyBenhVien
{
    partial class frmTonKhoThuoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTonKhoThuoc));
            this.tabTonKhoThuoc = new System.Windows.Forms.TabControl();
            this.HangTon = new System.Windows.Forms.TabPage();
            this.ChiTietHangTon = new System.Windows.Forms.TabPage();
            this.dgvChiTietHangTon = new System.Windows.Forms.DataGridView();
            this.HangCanDate = new System.Windows.Forms.TabPage();
            this.dgvHangCanDate = new System.Windows.Forms.DataGridView();
            this.HangTonLau = new System.Windows.Forms.TabPage();
            this.dgvHangTonLau = new System.Windows.Forms.DataGridView();
            this.HangCanMin = new System.Windows.Forms.TabPage();
            this.txtPhanTram = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvHangCanMin = new System.Windows.Forms.DataGridView();
            this.Kho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TonChuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChenhLech = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoatChat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSoNgay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MaKho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaThuocTonLau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenThuocTonLau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLoHangTonLau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhapThuocTonLau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HSDThuocTonLau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHangTon = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabTonKhoThuoc.SuspendLayout();
            this.HangTon.SuspendLayout();
            this.ChiTietHangTon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHangTon)).BeginInit();
            this.HangCanDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangCanDate)).BeginInit();
            this.HangTonLau.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangTonLau)).BeginInit();
            this.HangCanMin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangCanMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangTon)).BeginInit();
            this.SuspendLayout();
            // 
            // tabTonKhoThuoc
            // 
            this.tabTonKhoThuoc.Controls.Add(this.HangTon);
            this.tabTonKhoThuoc.Controls.Add(this.ChiTietHangTon);
            this.tabTonKhoThuoc.Controls.Add(this.HangCanDate);
            this.tabTonKhoThuoc.Controls.Add(this.HangTonLau);
            this.tabTonKhoThuoc.Controls.Add(this.HangCanMin);
            this.tabTonKhoThuoc.Location = new System.Drawing.Point(13, 13);
            this.tabTonKhoThuoc.Name = "tabTonKhoThuoc";
            this.tabTonKhoThuoc.SelectedIndex = 0;
            this.tabTonKhoThuoc.Size = new System.Drawing.Size(1044, 537);
            this.tabTonKhoThuoc.TabIndex = 0;
            // 
            // HangTon
            // 
            this.HangTon.Controls.Add(this.dgvHangTon);
            this.HangTon.Controls.Add(this.txtSoNgay);
            this.HangTon.Controls.Add(this.label4);
            this.HangTon.Location = new System.Drawing.Point(4, 22);
            this.HangTon.Name = "HangTon";
            this.HangTon.Padding = new System.Windows.Forms.Padding(3);
            this.HangTon.Size = new System.Drawing.Size(1036, 511);
            this.HangTon.TabIndex = 0;
            this.HangTon.Text = "Hàng tồn";
            this.HangTon.UseVisualStyleBackColor = true;
            // 
            // ChiTietHangTon
            // 
            this.ChiTietHangTon.Controls.Add(this.dgvChiTietHangTon);
            this.ChiTietHangTon.Location = new System.Drawing.Point(4, 22);
            this.ChiTietHangTon.Name = "ChiTietHangTon";
            this.ChiTietHangTon.Padding = new System.Windows.Forms.Padding(3);
            this.ChiTietHangTon.Size = new System.Drawing.Size(1036, 511);
            this.ChiTietHangTon.TabIndex = 1;
            this.ChiTietHangTon.Text = "Chi tiết hàng tồn";
            this.ChiTietHangTon.UseVisualStyleBackColor = true;
            // 
            // dgvChiTietHangTon
            // 
            this.dgvChiTietHangTon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHangTon.Location = new System.Drawing.Point(7, 6);
            this.dgvChiTietHangTon.Name = "dgvChiTietHangTon";
            this.dgvChiTietHangTon.Size = new System.Drawing.Size(1023, 498);
            this.dgvChiTietHangTon.TabIndex = 1;
            // 
            // HangCanDate
            // 
            this.HangCanDate.Controls.Add(this.dgvHangCanDate);
            this.HangCanDate.Location = new System.Drawing.Point(4, 22);
            this.HangCanDate.Name = "HangCanDate";
            this.HangCanDate.Padding = new System.Windows.Forms.Padding(3);
            this.HangCanDate.Size = new System.Drawing.Size(1036, 511);
            this.HangCanDate.TabIndex = 2;
            this.HangCanDate.Text = "Hàng cận date";
            this.HangCanDate.UseVisualStyleBackColor = true;
            // 
            // dgvHangCanDate
            // 
            this.dgvHangCanDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangCanDate.Location = new System.Drawing.Point(7, 6);
            this.dgvHangCanDate.Name = "dgvHangCanDate";
            this.dgvHangCanDate.Size = new System.Drawing.Size(1023, 498);
            this.dgvHangCanDate.TabIndex = 1;
            // 
            // HangTonLau
            // 
            this.HangTonLau.Controls.Add(this.textBox1);
            this.HangTonLau.Controls.Add(this.label3);
            this.HangTonLau.Controls.Add(this.dgvHangTonLau);
            this.HangTonLau.Location = new System.Drawing.Point(4, 22);
            this.HangTonLau.Name = "HangTonLau";
            this.HangTonLau.Size = new System.Drawing.Size(1036, 511);
            this.HangTonLau.TabIndex = 3;
            this.HangTonLau.Text = "Hàng tồn lâu";
            this.HangTonLau.UseVisualStyleBackColor = true;
            // 
            // dgvHangTonLau
            // 
            this.dgvHangTonLau.AllowUserToAddRows = false;
            this.dgvHangTonLau.AllowUserToDeleteRows = false;
            this.dgvHangTonLau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangTonLau.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKho,
            this.MaThuocTonLau,
            this.TenThuocTonLau,
            this.SoLoHangTonLau,
            this.NgayNhapThuocTonLau,
            this.HSDThuocTonLau});
            this.dgvHangTonLau.Location = new System.Drawing.Point(7, 55);
            this.dgvHangTonLau.Name = "dgvHangTonLau";
            this.dgvHangTonLau.ReadOnly = true;
            this.dgvHangTonLau.Size = new System.Drawing.Size(1023, 450);
            this.dgvHangTonLau.TabIndex = 1;
            // 
            // HangCanMin
            // 
            this.HangCanMin.Controls.Add(this.txtPhanTram);
            this.HangCanMin.Controls.Add(this.label2);
            this.HangCanMin.Controls.Add(this.label1);
            this.HangCanMin.Controls.Add(this.dgvHangCanMin);
            this.HangCanMin.Location = new System.Drawing.Point(4, 22);
            this.HangCanMin.Name = "HangCanMin";
            this.HangCanMin.Size = new System.Drawing.Size(1036, 511);
            this.HangCanMin.TabIndex = 4;
            this.HangCanMin.Text = "Hàng cận min";
            this.HangCanMin.UseVisualStyleBackColor = true;
            // 
            // txtPhanTram
            // 
            this.txtPhanTram.Location = new System.Drawing.Point(496, 15);
            this.txtPhanTram.Name = "txtPhanTram";
            this.txtPhanTram.Size = new System.Drawing.Size(46, 20);
            this.txtPhanTram.TabIndex = 4;
            this.txtPhanTram.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhanTram_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(548, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(420, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tỷ lệ cận min";
            // 
            // dgvHangCanMin
            // 
            this.dgvHangCanMin.AllowUserToAddRows = false;
            this.dgvHangCanMin.AllowUserToDeleteRows = false;
            this.dgvHangCanMin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangCanMin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Kho,
            this.MaHang,
            this.TenThuoc,
            this.DVT,
            this.SoLuong,
            this.TonChuan,
            this.ChenhLech,
            this.HoatChat});
            this.dgvHangCanMin.Location = new System.Drawing.Point(7, 55);
            this.dgvHangCanMin.Name = "dgvHangCanMin";
            this.dgvHangCanMin.ReadOnly = true;
            this.dgvHangCanMin.Size = new System.Drawing.Size(1023, 450);
            this.dgvHangCanMin.TabIndex = 1;
            // 
            // Kho
            // 
            this.Kho.HeaderText = "Kho";
            this.Kho.Name = "Kho";
            this.Kho.ReadOnly = true;
            // 
            // MaHang
            // 
            this.MaHang.HeaderText = "Mã Hàng";
            this.MaHang.Name = "MaHang";
            this.MaHang.ReadOnly = true;
            // 
            // TenThuoc
            // 
            this.TenThuoc.HeaderText = "Tên thuốc";
            this.TenThuoc.Name = "TenThuoc";
            this.TenThuoc.ReadOnly = true;
            this.TenThuoc.Width = 250;
            // 
            // DVT
            // 
            this.DVT.HeaderText = "ĐVT";
            this.DVT.Name = "DVT";
            this.DVT.ReadOnly = true;
            this.DVT.Width = 90;
            // 
            // SoLuong
            // 
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            this.SoLuong.Width = 80;
            // 
            // TonChuan
            // 
            this.TonChuan.HeaderText = "Tồn Chuẩn";
            this.TonChuan.Name = "TonChuan";
            this.TonChuan.ReadOnly = true;
            this.TonChuan.Width = 90;
            // 
            // ChenhLech
            // 
            this.ChenhLech.HeaderText = "Chênh lệch";
            this.ChenhLech.Name = "ChenhLech";
            this.ChenhLech.ReadOnly = true;
            this.ChenhLech.Width = 90;
            // 
            // HoatChat
            // 
            this.HoatChat.HeaderText = "Hoạt chất";
            this.HoatChat.Name = "HoatChat";
            this.HoatChat.ReadOnly = true;
            this.HoatChat.Width = 180;
            // 
            // txtSoNgay
            // 
            this.txtSoNgay.Location = new System.Drawing.Point(535, 20);
            this.txtSoNgay.Name = "txtSoNgay";
            this.txtSoNgay.Size = new System.Drawing.Size(46, 20);
            this.txtSoNgay.TabIndex = 7;
            this.txtSoNgay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoNgay_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(459, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Số ngày";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(550, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(46, 20);
            this.textBox1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(474, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Số ngày";
            // 
            // MaKho
            // 
            this.MaKho.HeaderText = "Mã kho";
            this.MaKho.Name = "MaKho";
            this.MaKho.ReadOnly = true;
            // 
            // MaThuocTonLau
            // 
            this.MaThuocTonLau.HeaderText = "Mã thuốc";
            this.MaThuocTonLau.Name = "MaThuocTonLau";
            this.MaThuocTonLau.ReadOnly = true;
            // 
            // TenThuocTonLau
            // 
            this.TenThuocTonLau.HeaderText = "Tên thuốc";
            this.TenThuocTonLau.Name = "TenThuocTonLau";
            this.TenThuocTonLau.ReadOnly = true;
            this.TenThuocTonLau.Width = 480;
            // 
            // SoLoHangTonLau
            // 
            this.SoLoHangTonLau.HeaderText = "Số lô";
            this.SoLoHangTonLau.Name = "SoLoHangTonLau";
            this.SoLoHangTonLau.ReadOnly = true;
            // 
            // NgayNhapThuocTonLau
            // 
            this.NgayNhapThuocTonLau.HeaderText = "Ngày nhập";
            this.NgayNhapThuocTonLau.Name = "NgayNhapThuocTonLau";
            this.NgayNhapThuocTonLau.ReadOnly = true;
            // 
            // HSDThuocTonLau
            // 
            this.HSDThuocTonLau.HeaderText = "HSD";
            this.HSDThuocTonLau.Name = "HSDThuocTonLau";
            this.HSDThuocTonLau.ReadOnly = true;
            // 
            // dgvHangTon
            // 
            this.dgvHangTon.AllowUserToAddRows = false;
            this.dgvHangTon.AllowUserToDeleteRows = false;
            this.dgvHangTon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangTon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dgvHangTon.Location = new System.Drawing.Point(6, 56);
            this.dgvHangTon.Name = "dgvHangTon";
            this.dgvHangTon.ReadOnly = true;
            this.dgvHangTon.Size = new System.Drawing.Size(1023, 450);
            this.dgvHangTon.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã kho";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Mã thuốc";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Tên thuốc";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 480;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Số lô";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Ngày nhập";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "HSD";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // frmTonKhoThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 562);
            this.Controls.Add(this.tabTonKhoThuoc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTonKhoThuoc";
            this.Text = "TỒN KHO THUỐC";
            this.tabTonKhoThuoc.ResumeLayout(false);
            this.HangTon.ResumeLayout(false);
            this.HangTon.PerformLayout();
            this.ChiTietHangTon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHangTon)).EndInit();
            this.HangCanDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangCanDate)).EndInit();
            this.HangTonLau.ResumeLayout(false);
            this.HangTonLau.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangTonLau)).EndInit();
            this.HangCanMin.ResumeLayout(false);
            this.HangCanMin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangCanMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangTon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabTonKhoThuoc;
        private System.Windows.Forms.TabPage HangTon;
        private System.Windows.Forms.TabPage ChiTietHangTon;
        private System.Windows.Forms.TabPage HangCanDate;
        private System.Windows.Forms.TabPage HangTonLau;
        private System.Windows.Forms.TabPage HangCanMin;
        private System.Windows.Forms.DataGridView dgvChiTietHangTon;
        private System.Windows.Forms.DataGridView dgvHangCanDate;
        private System.Windows.Forms.DataGridView dgvHangTonLau;
        private System.Windows.Forms.DataGridView dgvHangCanMin;
        private System.Windows.Forms.TextBox txtPhanTram;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kho;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TonChuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChenhLech;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoatChat;
        private System.Windows.Forms.TextBox txtSoNgay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKho;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaThuocTonLau;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenThuocTonLau;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLoHangTonLau;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhapThuocTonLau;
        private System.Windows.Forms.DataGridViewTextBoxColumn HSDThuocTonLau;
        private System.Windows.Forms.DataGridView dgvHangTon;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}