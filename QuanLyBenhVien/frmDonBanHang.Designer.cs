namespace QuanLyBenhVien
{
    partial class frmDonBanHang
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtTenNhaThuoc1 = new System.Windows.Forms.TextBox();
            this.txtTenNhaThuoc = new System.Windows.Forms.TextBox();
            this.tabLoaiDonThuoc = new System.Windows.Forms.TabControl();
            this.tabBanLe = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabKeDon = new System.Windows.Forms.TabPage();
            this.cachedrptNhanVien1 = new QuanLyBenhVien.Reports.CachedrptNhanVien();
            this.panel1.SuspendLayout();
            this.tabLoaiDonThuoc.SuspendLayout();
            this.tabBanLe.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.txtTenNhaThuoc1);
            this.panel1.Controls.Add(this.txtTenNhaThuoc);
            this.panel1.Location = new System.Drawing.Point(30, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 96);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(649, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tổng hóa đơn trong ngày";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(408, 61);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(32, 13);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Ngày";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(408, 25);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(29, 13);
            this.lblUser.TabIndex = 5;
            this.lblUser.Text = "User";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(799, 18);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(40, 20);
            this.textBox5.TabIndex = 4;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(459, 57);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(122, 20);
            this.textBox4.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(459, 18);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(122, 20);
            this.textBox3.TabIndex = 2;
            // 
            // txtTenNhaThuoc1
            // 
            this.txtTenNhaThuoc1.Location = new System.Drawing.Point(16, 58);
            this.txtTenNhaThuoc1.Name = "txtTenNhaThuoc1";
            this.txtTenNhaThuoc1.Size = new System.Drawing.Size(317, 20);
            this.txtTenNhaThuoc1.TabIndex = 1;
            // 
            // txtTenNhaThuoc
            // 
            this.txtTenNhaThuoc.Location = new System.Drawing.Point(16, 19);
            this.txtTenNhaThuoc.Name = "txtTenNhaThuoc";
            this.txtTenNhaThuoc.Size = new System.Drawing.Size(317, 20);
            this.txtTenNhaThuoc.TabIndex = 0;
            this.txtTenNhaThuoc.Text = "Nhà Thuốc ...";
            // 
            // tabLoaiDonThuoc
            // 
            this.tabLoaiDonThuoc.Controls.Add(this.tabBanLe);
            this.tabLoaiDonThuoc.Controls.Add(this.tabKeDon);
            this.tabLoaiDonThuoc.Location = new System.Drawing.Point(30, 155);
            this.tabLoaiDonThuoc.Name = "tabLoaiDonThuoc";
            this.tabLoaiDonThuoc.SelectedIndex = 0;
            this.tabLoaiDonThuoc.Size = new System.Drawing.Size(860, 156);
            this.tabLoaiDonThuoc.TabIndex = 1;
            // 
            // tabBanLe
            // 
            this.tabBanLe.Controls.Add(this.label4);
            this.tabBanLe.Controls.Add(this.textBox6);
            this.tabBanLe.Controls.Add(this.label2);
            this.tabBanLe.Controls.Add(this.textBox2);
            this.tabBanLe.Controls.Add(this.label1);
            this.tabBanLe.Controls.Add(this.textBox1);
            this.tabBanLe.Location = new System.Drawing.Point(4, 22);
            this.tabBanLe.Name = "tabBanLe";
            this.tabBanLe.Padding = new System.Windows.Forms.Padding(3);
            this.tabBanLe.Size = new System.Drawing.Size(852, 130);
            this.tabBanLe.TabIndex = 0;
            this.tabBanLe.Text = "Bán Lẻ";
            this.tabBanLe.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(670, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Giới Tính";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(736, 15);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(27, 20);
            this.textBox6.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(552, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tuổi";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(603, 15);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(37, 20);
            this.textBox2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Khách Hàng";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(92, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(366, 20);
            this.textBox1.TabIndex = 6;
            // 
            // tabKeDon
            // 
            this.tabKeDon.Location = new System.Drawing.Point(4, 22);
            this.tabKeDon.Name = "tabKeDon";
            this.tabKeDon.Padding = new System.Windows.Forms.Padding(3);
            this.tabKeDon.Size = new System.Drawing.Size(852, 130);
            this.tabKeDon.TabIndex = 1;
            this.tabKeDon.Text = "Bán Theo Kê Đơn";
            this.tabKeDon.UseVisualStyleBackColor = true;
            // 
            // DonBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 511);
            this.Controls.Add(this.tabLoaiDonThuoc);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DonBanHang";
            this.Text = "DonBanHang";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabLoaiDonThuoc.ResumeLayout(false);
            this.tabBanLe.ResumeLayout(false);
            this.tabBanLe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtTenNhaThuoc1;
        private System.Windows.Forms.TextBox txtTenNhaThuoc;
        private System.Windows.Forms.TabControl tabLoaiDonThuoc;
        private System.Windows.Forms.TabPage tabBanLe;
        private System.Windows.Forms.TabPage tabKeDon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private Reports.CachedrptNhanVien cachedrptNhanVien1;
    }
}