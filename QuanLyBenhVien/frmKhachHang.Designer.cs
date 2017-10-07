namespace QuanLyBenhVien
{
    partial class frmKhachHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhachHang));
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.radNam = new System.Windows.Forms.RadioButton();
            this.radNu = new System.Windows.Forms.RadioButton();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(501, 228);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(121, 30);
            this.btnLuu.TabIndex = 9;
            this.btnLuu.Text = "&Thêm mới";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(629, 228);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(74, 30);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Th&oát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(10, 184);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(36, 15);
            this.Label1.TabIndex = 180;
            this.Label1.Text = "Mô tả";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(112, 76);
            this.txtDiaChi.MaxLength = 500;
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(548, 44);
            this.txtDiaChi.TabIndex = 2;
            this.txtDiaChi.Tag = "";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(112, 49);
            this.txtTenKH.MaxLength = 250;
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(548, 21);
            this.txtTenKH.TabIndex = 1;
            this.txtTenKH.Tag = "";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(9, 90);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(45, 15);
            this.Label5.TabIndex = 173;
            this.Label5.Text = "Địa chỉ";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(9, 52);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(61, 15);
            this.Label4.TabIndex = 177;
            this.Label4.Text = "Tên KH(*)";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(112, 181);
            this.txtMoTa.MaxLength = 250;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(548, 21);
            this.txtMoTa.TabIndex = 12;
            this.txtMoTa.Tag = "";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(351, 128);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(31, 15);
            this.Label15.TabIndex = 180;
            this.Label15.Text = "Tuổi";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(10, 25);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(43, 15);
            this.Label2.TabIndex = 171;
            this.Label2.Text = "Mã KH";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(9, 128);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(53, 15);
            this.Label11.TabIndex = 179;
            this.Label11.Text = "Giới tính";
            // 
            // txtWebsite
            // 
            this.txtWebsite.Location = new System.Drawing.Point(449, 125);
            this.txtWebsite.MaxLength = 250;
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(42, 21);
            this.txtWebsite.TabIndex = 11;
            this.txtWebsite.Tag = "";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(112, 22);
            this.txtMaKH.MaxLength = 50;
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(548, 21);
            this.txtMaKH.TabIndex = 0;
            this.txtMaKH.Tag = "NN";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(112, 154);
            this.txtSDT.MaxLength = 20;
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(206, 21);
            this.txtSDT.TabIndex = 181;
            this.txtSDT.Tag = "";
            this.txtSDT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // radNam
            // 
            this.radNam.AutoSize = true;
            this.radNam.Checked = true;
            this.radNam.Location = new System.Drawing.Point(112, 127);
            this.radNam.Name = "radNam";
            this.radNam.Size = new System.Drawing.Size(52, 19);
            this.radNam.TabIndex = 24;
            this.radNam.TabStop = true;
            this.radNam.Text = "Nam";
            this.radNam.UseVisualStyleBackColor = true;
            // 
            // radNu
            // 
            this.radNu.AutoSize = true;
            this.radNu.Location = new System.Drawing.Point(165, 127);
            this.radNu.Name = "radNu";
            this.radNu.Size = new System.Drawing.Size(42, 19);
            this.radNu.TabIndex = 25;
            this.radNu.Text = "Nữ";
            this.radNu.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(449, 151);
            this.txtEmail.MaxLength = 15;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(211, 21);
            this.txtEmail.TabIndex = 186;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 187;
            this.label3.Text = "Email";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.txtEmail);
            this.GroupBox1.Controls.Add(this.radNu);
            this.GroupBox1.Controls.Add(this.Label10);
            this.GroupBox1.Controls.Add(this.radNam);
            this.GroupBox1.Controls.Add(this.txtSDT);
            this.GroupBox1.Controls.Add(this.txtMaKH);
            this.GroupBox1.Controls.Add(this.txtWebsite);
            this.GroupBox1.Controls.Add(this.Label11);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label15);
            this.GroupBox1.Controls.Add(this.txtMoTa);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.txtTenKH);
            this.GroupBox1.Controls.Add(this.txtDiaChi);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(12, 10);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(690, 212);
            this.GroupBox1.TabIndex = 8;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Thông tin chung";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(9, 157);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(63, 15);
            this.Label10.TabIndex = 174;
            this.Label10.Text = "Điện thoại";
            // 
            // frmKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 267);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.btnThoat);
            this.Name = "frmKhachHang";
            this.Text = "KHÁCH HÀNG";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnLuu;
        internal System.Windows.Forms.Button btnThoat;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtDiaChi;
        internal System.Windows.Forms.TextBox txtTenKH;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtMoTa;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.TextBox txtWebsite;
        internal System.Windows.Forms.TextBox txtMaKH;
        internal System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.RadioButton radNam;
        private System.Windows.Forms.RadioButton radNu;
        internal System.Windows.Forms.TextBox txtEmail;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label10;
    }
}