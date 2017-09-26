namespace QuanLyBenhVien
{
    partial class frmNhaCungCap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhaCungCap));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMaNCC = new System.Windows.Forms.TextBox();
            this.mskFax = new System.Windows.Forms.MaskedTextBox();
            this.btnThemTinhTP = new System.Windows.Forms.Button();
            this.mskDienThoai = new System.Windows.Forms.MaskedTextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.cboTinhTP = new System.Windows.Forms.ComboBox();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtTenNCC = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.txtMST = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtNganHang = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label21 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtMaNCC);
            this.GroupBox1.Controls.Add(this.mskFax);
            this.GroupBox1.Controls.Add(this.btnThemTinhTP);
            this.GroupBox1.Controls.Add(this.mskDienThoai);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.txtMoTa);
            this.GroupBox1.Controls.Add(this.cboTinhTP);
            this.GroupBox1.Controls.Add(this.txtWebsite);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.txtEmail);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.txtTenNCC);
            this.GroupBox1.Controls.Add(this.txtDiaChi);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.Label15);
            this.GroupBox1.Controls.Add(this.Label8);
            this.GroupBox1.Controls.Add(this.Label13);
            this.GroupBox1.Controls.Add(this.txtTaiKhoan);
            this.GroupBox1.Controls.Add(this.Label11);
            this.GroupBox1.Controls.Add(this.txtMST);
            this.GroupBox1.Controls.Add(this.Label10);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.txtNganHang);
            this.GroupBox1.Controls.Add(this.Label9);
            this.GroupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(12, 50);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(690, 322);
            this.GroupBox1.TabIndex = 5;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Thông tin chung";
            // 
            // txtMaNCC
            // 
            this.txtMaNCC.Location = new System.Drawing.Point(112, 22);
            this.txtMaNCC.MaxLength = 50;
            this.txtMaNCC.Name = "txtMaNCC";
            this.txtMaNCC.Size = new System.Drawing.Size(548, 21);
            this.txtMaNCC.TabIndex = 0;
            this.txtMaNCC.Tag = "NN";
            // 
            // mskFax
            // 
            this.mskFax.Location = new System.Drawing.Point(449, 208);
            this.mskFax.Mask = "(9999) 000-0000";
            this.mskFax.Name = "mskFax";
            this.mskFax.Size = new System.Drawing.Size(211, 21);
            this.mskFax.TabIndex = 9;
            this.mskFax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnThemTinhTP
            // 
            this.btnThemTinhTP.Image = ((System.Drawing.Image)(resources.GetObject("btnThemTinhTP.Image")));
            this.btnThemTinhTP.Location = new System.Drawing.Point(628, 126);
            this.btnThemTinhTP.Name = "btnThemTinhTP";
            this.btnThemTinhTP.Size = new System.Drawing.Size(32, 24);
            this.btnThemTinhTP.TabIndex = 4;
            this.btnThemTinhTP.TabStop = false;
            this.btnThemTinhTP.UseVisualStyleBackColor = true;
            this.btnThemTinhTP.Click += new System.EventHandler(this.btnThemTinhTP_Click);
            // 
            // mskDienThoai
            // 
            this.mskDienThoai.Location = new System.Drawing.Point(112, 208);
            this.mskDienThoai.Mask = "(9999) 000-0000";
            this.mskDienThoai.Name = "mskDienThoai";
            this.mskDienThoai.Size = new System.Drawing.Size(206, 21);
            this.mskDienThoai.TabIndex = 8;
            this.mskDienThoai.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(10, 25);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(53, 15);
            this.Label2.TabIndex = 171;
            this.Label2.Text = "Mã NCC";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(112, 288);
            this.txtMoTa.MaxLength = 200;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(548, 21);
            this.txtMoTa.TabIndex = 12;
            this.txtMoTa.Tag = "";
            // 
            // cboTinhTP
            // 
            this.cboTinhTP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTinhTP.FormattingEnabled = true;
            this.cboTinhTP.Location = new System.Drawing.Point(112, 126);
            this.cboTinhTP.Name = "cboTinhTP";
            this.cboTinhTP.Size = new System.Drawing.Size(497, 23);
            this.cboTinhTP.TabIndex = 3;
            // 
            // txtWebsite
            // 
            this.txtWebsite.Location = new System.Drawing.Point(112, 261);
            this.txtWebsite.MaxLength = 50;
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(548, 21);
            this.txtWebsite.TabIndex = 11;
            this.txtWebsite.Tag = "";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(9, 52);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(71, 15);
            this.Label4.TabIndex = 177;
            this.Label4.Text = "Tên NCC(*)";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(112, 234);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(548, 21);
            this.txtEmail.TabIndex = 10;
            this.txtEmail.Tag = "";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(9, 91);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(45, 15);
            this.Label5.TabIndex = 173;
            this.Label5.Text = "Địa chỉ";
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.Location = new System.Drawing.Point(112, 49);
            this.txtTenNCC.MaxLength = 30;
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.Size = new System.Drawing.Size(548, 21);
            this.txtTenNCC.TabIndex = 1;
            this.txtTenNCC.Tag = "";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(112, 77);
            this.txtDiaChi.MaxLength = 50;
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(548, 44);
            this.txtDiaChi.TabIndex = 2;
            this.txtDiaChi.Tag = "";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(10, 291);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(36, 15);
            this.Label1.TabIndex = 180;
            this.Label1.Text = "Mô tả";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(9, 130);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(49, 15);
            this.Label6.TabIndex = 172;
            this.Label6.Text = "Tỉnh TP";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(10, 264);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(52, 15);
            this.Label15.TabIndex = 180;
            this.Label15.Text = "Website";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(351, 158);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(75, 15);
            this.Label8.TabIndex = 176;
            this.Label8.Text = "Số tài khoản";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(351, 211);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(26, 15);
            this.Label13.TabIndex = 178;
            this.Label13.Text = "Fax";
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Location = new System.Drawing.Point(449, 155);
            this.txtTaiKhoan.MaxLength = 15;
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(211, 21);
            this.txtTaiKhoan.TabIndex = 6;
            this.txtTaiKhoan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(9, 237);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(39, 15);
            this.Label11.TabIndex = 179;
            this.Label11.Text = "Email";
            // 
            // txtMST
            // 
            this.txtMST.Location = new System.Drawing.Point(112, 155);
            this.txtMST.MaxLength = 10;
            this.txtMST.Name = "txtMST";
            this.txtMST.Size = new System.Drawing.Size(206, 21);
            this.txtMST.TabIndex = 5;
            this.txtMST.Tag = "";
            this.txtMST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(9, 211);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(63, 15);
            this.Label10.TabIndex = 174;
            this.Label10.Text = "Điện thoại";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(9, 158);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(67, 15);
            this.Label7.TabIndex = 169;
            this.Label7.Text = "Mã số thuế";
            // 
            // txtNganHang
            // 
            this.txtNganHang.Location = new System.Drawing.Point(112, 182);
            this.txtNganHang.MaxLength = 50;
            this.txtNganHang.Name = "txtNganHang";
            this.txtNganHang.Size = new System.Drawing.Size(548, 21);
            this.txtNganHang.TabIndex = 7;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(9, 188);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(40, 15);
            this.Label9.TabIndex = 175;
            this.Label9.Text = "Mở tại";
            // 
            // Label21
            // 
            this.Label21.AutoSize = true;
            this.Label21.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.Location = new System.Drawing.Point(12, 15);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(149, 24);
            this.Label21.TabIndex = 4;
            this.Label21.Text = "Nhà cung cấp";
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(627, 385);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 30);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Th&oát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(533, 385);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 30);
            this.btnLuu.TabIndex = 6;
            this.btnLuu.Text = "&Ghi";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // frmNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 427);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLuu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNhaCungCap";
            this.Text = "NHÀ CUNG CẤP";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox txtMaNCC;
        internal System.Windows.Forms.MaskedTextBox mskFax;
        internal System.Windows.Forms.Button btnThemTinhTP;
        internal System.Windows.Forms.MaskedTextBox mskDienThoai;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtMoTa;
        internal System.Windows.Forms.ComboBox cboTinhTP;
        internal System.Windows.Forms.TextBox txtWebsite;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtEmail;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtTenNCC;
        internal System.Windows.Forms.TextBox txtDiaChi;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.TextBox txtTaiKhoan;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.TextBox txtMST;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txtNganHang;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label21;
        internal System.Windows.Forms.Button btnThoat;
        internal System.Windows.Forms.Button btnLuu;
    }
}