﻿namespace QuanLyBenhVien
{
    partial class frmPhieuNhapThuoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhieuNhapThuoc));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSoSeri = new System.Windows.Forms.TextBox();
            this.lblSeri = new System.Windows.Forms.Label();
            this.txtSoHD = new System.Windows.Forms.TextBox();
            this.lblSoHD = new System.Windows.Forms.Label();
            this.dtpNgayHD = new System.Windows.Forms.DateTimePicker();
            this.lblNgayHD = new System.Windows.Forms.Label();
            this.txtThueSuat = new System.Windows.Forms.TextBox();
            this.lblThueSuat = new System.Windows.Forms.Label();
            this.lblSoPhieu = new System.Windows.Forms.Label();
            this.txtSoPhieu = new System.Windows.Forms.TextBox();
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.lblNhaCungCap = new System.Windows.Forms.Label();
            this.btnThemNhaCC = new System.Windows.Forms.Button();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboNhaCungCap = new System.Windows.Forms.ComboBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.dgrCTPhieuNhap = new System.Windows.Forms.DataGridView();
            this.MaThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaVach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DVT = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.GiaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanSuDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrCTPhieuNhap)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSoSeri);
            this.groupBox1.Controls.Add(this.lblSeri);
            this.groupBox1.Controls.Add(this.txtSoHD);
            this.groupBox1.Controls.Add(this.lblSoHD);
            this.groupBox1.Controls.Add(this.dtpNgayHD);
            this.groupBox1.Controls.Add(this.lblNgayHD);
            this.groupBox1.Controls.Add(this.txtThueSuat);
            this.groupBox1.Controls.Add(this.lblThueSuat);
            this.groupBox1.Location = new System.Drawing.Point(970, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 130);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin hóa đơn";
            // 
            // txtSoSeri
            // 
            this.txtSoSeri.Location = new System.Drawing.Point(85, 48);
            this.txtSoSeri.Name = "txtSoSeri";
            this.txtSoSeri.Size = new System.Drawing.Size(100, 20);
            this.txtSoSeri.TabIndex = 15;
            // 
            // lblSeri
            // 
            this.lblSeri.AutoSize = true;
            this.lblSeri.Location = new System.Drawing.Point(15, 51);
            this.lblSeri.Name = "lblSeri";
            this.lblSeri.Size = new System.Drawing.Size(39, 13);
            this.lblSeri.TabIndex = 14;
            this.lblSeri.Text = "Số seri";
            // 
            // txtSoHD
            // 
            this.txtSoHD.Location = new System.Drawing.Point(85, 74);
            this.txtSoHD.Name = "txtSoHD";
            this.txtSoHD.Size = new System.Drawing.Size(100, 20);
            this.txtSoHD.TabIndex = 13;
            // 
            // lblSoHD
            // 
            this.lblSoHD.AutoSize = true;
            this.lblSoHD.Location = new System.Drawing.Point(15, 77);
            this.lblSoHD.Name = "lblSoHD";
            this.lblSoHD.Size = new System.Drawing.Size(39, 13);
            this.lblSoHD.TabIndex = 12;
            this.lblSoHD.Text = "Số HĐ";
            // 
            // dtpNgayHD
            // 
            this.dtpNgayHD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayHD.Location = new System.Drawing.Point(85, 100);
            this.dtpNgayHD.Name = "dtpNgayHD";
            this.dtpNgayHD.Size = new System.Drawing.Size(100, 20);
            this.dtpNgayHD.TabIndex = 11;
            // 
            // lblNgayHD
            // 
            this.lblNgayHD.AutoSize = true;
            this.lblNgayHD.Location = new System.Drawing.Point(15, 103);
            this.lblNgayHD.Name = "lblNgayHD";
            this.lblNgayHD.Size = new System.Drawing.Size(51, 13);
            this.lblNgayHD.TabIndex = 10;
            this.lblNgayHD.Text = "Ngày HĐ";
            // 
            // txtThueSuat
            // 
            this.txtThueSuat.Location = new System.Drawing.Point(85, 22);
            this.txtThueSuat.Name = "txtThueSuat";
            this.txtThueSuat.Size = new System.Drawing.Size(100, 20);
            this.txtThueSuat.TabIndex = 9;
            this.txtThueSuat.Text = "10%";
            this.txtThueSuat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblThueSuat
            // 
            this.lblThueSuat.AutoSize = true;
            this.lblThueSuat.Location = new System.Drawing.Point(15, 25);
            this.lblThueSuat.Name = "lblThueSuat";
            this.lblThueSuat.Size = new System.Drawing.Size(55, 13);
            this.lblThueSuat.TabIndex = 8;
            this.lblThueSuat.Text = "Thuế suất";
            // 
            // lblSoPhieu
            // 
            this.lblSoPhieu.AutoSize = true;
            this.lblSoPhieu.Location = new System.Drawing.Point(621, 25);
            this.lblSoPhieu.Name = "lblSoPhieu";
            this.lblSoPhieu.Size = new System.Drawing.Size(50, 13);
            this.lblSoPhieu.TabIndex = 0;
            this.lblSoPhieu.Text = "Số Phiếu";
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Location = new System.Drawing.Point(691, 22);
            this.txtSoPhieu.Name = "txtSoPhieu";
            this.txtSoPhieu.Size = new System.Drawing.Size(101, 20);
            this.txtSoPhieu.TabIndex = 1;
            // 
            // lblNgayNhap
            // 
            this.lblNgayNhap.AutoSize = true;
            this.lblNgayNhap.Location = new System.Drawing.Point(621, 51);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(61, 13);
            this.lblNgayNhap.TabIndex = 2;
            this.lblNgayNhap.Text = "Ngày Nhập";
            // 
            // lblNhaCungCap
            // 
            this.lblNhaCungCap.AutoSize = true;
            this.lblNhaCungCap.Location = new System.Drawing.Point(12, 25);
            this.lblNhaCungCap.Name = "lblNhaCungCap";
            this.lblNhaCungCap.Size = new System.Drawing.Size(75, 13);
            this.lblNhaCungCap.TabIndex = 4;
            this.lblNhaCungCap.Text = "Nhà cung cấp";
            // 
            // btnThemNhaCC
            // 
            this.btnThemNhaCC.Image = ((System.Drawing.Image)(resources.GetObject("btnThemNhaCC.Image")));
            this.btnThemNhaCC.Location = new System.Drawing.Point(550, 20);
            this.btnThemNhaCC.Name = "btnThemNhaCC";
            this.btnThemNhaCC.Size = new System.Drawing.Size(29, 24);
            this.btnThemNhaCC.TabIndex = 6;
            this.btnThemNhaCC.TabStop = false;
            this.btnThemNhaCC.UseVisualStyleBackColor = true;
            this.btnThemNhaCC.Click += new System.EventHandler(this.btnThemNhaCC_Click);
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayNhap.Location = new System.Drawing.Point(691, 48);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(101, 20);
            this.dtpNgayNhap.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboNhaCungCap);
            this.groupBox2.Controls.Add(this.txtGhiChu);
            this.groupBox2.Controls.Add(this.lblGhiChu);
            this.groupBox2.Controls.Add(this.dtpNgayNhap);
            this.groupBox2.Controls.Add(this.btnThemNhaCC);
            this.groupBox2.Controls.Add(this.lblSoPhieu);
            this.groupBox2.Controls.Add(this.txtSoPhieu);
            this.groupBox2.Controls.Add(this.lblNhaCungCap);
            this.groupBox2.Controls.Add(this.lblNgayNhap);
            this.groupBox2.Location = new System.Drawing.Point(12, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(816, 130);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin chung";
            // 
            // cboNhaCungCap
            // 
            this.cboNhaCungCap.FormattingEnabled = true;
            this.cboNhaCungCap.Location = new System.Drawing.Point(101, 22);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Size = new System.Drawing.Size(439, 21);
            this.cboNhaCungCap.TabIndex = 12;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(101, 100);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(691, 20);
            this.txtGhiChu.TabIndex = 9;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(12, 103);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(44, 13);
            this.lblGhiChu.TabIndex = 8;
            this.lblGhiChu.Text = "Ghi chú";
            // 
            // dgrCTPhieuNhap
            // 
            this.dgrCTPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrCTPhieuNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaThuoc,
            this.MaVach,
            this.TenThuoc,
            this.SoLuong,
            this.DVT,
            this.GiaNhap,
            this.ThanhTien,
            this.HanSuDung});
            this.dgrCTPhieuNhap.Location = new System.Drawing.Point(13, 175);
            this.dgrCTPhieuNhap.Name = "dgrCTPhieuNhap";
            this.dgrCTPhieuNhap.Size = new System.Drawing.Size(1159, 399);
            this.dgrCTPhieuNhap.TabIndex = 2;
            // 
            // MaThuoc
            // 
            this.MaThuoc.HeaderText = "Mã thuốc";
            this.MaThuoc.Name = "MaThuoc";
            this.MaThuoc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // MaVach
            // 
            this.MaVach.HeaderText = "Mã vạch";
            this.MaVach.Name = "MaVach";
            this.MaVach.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // TenThuoc
            // 
            this.TenThuoc.HeaderText = "Tên thuốc";
            this.TenThuoc.Name = "TenThuoc";
            this.TenThuoc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TenThuoc.Width = 400;
            // 
            // SoLuong
            // 
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SoLuong.Width = 80;
            // 
            // DVT
            // 
            this.DVT.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.DVT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DVT.HeaderText = "ĐVT";
            this.DVT.Items.AddRange(new object[] {
            "a",
            "a1",
            "a2"});
            this.DVT.Name = "DVT";
            this.DVT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DVT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // GiaNhap
            // 
            this.GiaNhap.HeaderText = "Giá nhập";
            this.GiaNhap.Name = "GiaNhap";
            // 
            // ThanhTien
            // 
            this.ThanhTien.HeaderText = "Thành tiền";
            this.ThanhTien.Name = "ThanhTien";
            // 
            // HanSuDung
            // 
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.HanSuDung.DefaultCellStyle = dataGridViewCellStyle2;
            this.HanSuDung.HeaderText = "Hạn sử dụng";
            this.HanSuDung.Name = "HanSuDung";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnLuu);
            this.groupBox3.Location = new System.Drawing.Point(12, 591);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(268, 102);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thao tác";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(72, 19);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // frmPhieuNhapThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 709);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dgrCTPhieuNhap);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPhieuNhapThuoc";
            this.Text = "PHIẾU NHẬP THUỐC";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrCTPhieuNhap)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnThemNhaCC;
        private System.Windows.Forms.Label lblNhaCungCap;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.TextBox txtSoPhieu;
        private System.Windows.Forms.Label lblSoPhieu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.DateTimePicker dtpNgayHD;
        private System.Windows.Forms.TextBox txtThueSuat;
        private System.Windows.Forms.Label lblThueSuat;
        private System.Windows.Forms.Label lblNgayHD;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgrCTPhieuNhap;
        private System.Windows.Forms.TextBox txtSoSeri;
        private System.Windows.Forms.Label lblSeri;
        private System.Windows.Forms.TextBox txtSoHD;
        private System.Windows.Forms.Label lblSoHD;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.ComboBox cboNhaCungCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaVach;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewComboBoxColumn DVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanSuDung;
        private System.Windows.Forms.Button btnLuu;
    }
}