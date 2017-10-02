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
            this.HangCanDate = new System.Windows.Forms.TabPage();
            this.HangTonLau = new System.Windows.Forms.TabPage();
            this.HangCanMin = new System.Windows.Forms.TabPage();
            this.dgvHangTon = new System.Windows.Forms.DataGridView();
            this.dgvChiTietHangTon = new System.Windows.Forms.DataGridView();
            this.dgvHangCanDate = new System.Windows.Forms.DataGridView();
            this.dgvHangTonLau = new System.Windows.Forms.DataGridView();
            this.dgvHangCanMin = new System.Windows.Forms.DataGridView();
            this.tabTonKhoThuoc.SuspendLayout();
            this.HangTon.SuspendLayout();
            this.ChiTietHangTon.SuspendLayout();
            this.HangCanDate.SuspendLayout();
            this.HangTonLau.SuspendLayout();
            this.HangCanMin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangTon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHangTon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangCanDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangTonLau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangCanMin)).BeginInit();
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
            // HangTonLau
            // 
            this.HangTonLau.Controls.Add(this.dgvHangTonLau);
            this.HangTonLau.Location = new System.Drawing.Point(4, 22);
            this.HangTonLau.Name = "HangTonLau";
            this.HangTonLau.Size = new System.Drawing.Size(1036, 511);
            this.HangTonLau.TabIndex = 3;
            this.HangTonLau.Text = "Hàng tồn lâu";
            this.HangTonLau.UseVisualStyleBackColor = true;
            // 
            // HangCanMin
            // 
            this.HangCanMin.Controls.Add(this.dgvHangCanMin);
            this.HangCanMin.Location = new System.Drawing.Point(4, 22);
            this.HangCanMin.Name = "HangCanMin";
            this.HangCanMin.Size = new System.Drawing.Size(1036, 511);
            this.HangCanMin.TabIndex = 4;
            this.HangCanMin.Text = "Hàng cận min";
            this.HangCanMin.UseVisualStyleBackColor = true;
            // 
            // dgvHangTon
            // 
            this.dgvHangTon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangTon.Location = new System.Drawing.Point(7, 7);
            this.dgvHangTon.Name = "dgvHangTon";
            this.dgvHangTon.Size = new System.Drawing.Size(1023, 498);
            this.dgvHangTon.TabIndex = 0;
            // 
            // dgvChiTietHangTon
            // 
            this.dgvChiTietHangTon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHangTon.Location = new System.Drawing.Point(7, 6);
            this.dgvChiTietHangTon.Name = "dgvChiTietHangTon";
            this.dgvChiTietHangTon.Size = new System.Drawing.Size(1023, 498);
            this.dgvChiTietHangTon.TabIndex = 1;
            // 
            // dgvHangCanDate
            // 
            this.dgvHangCanDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangCanDate.Location = new System.Drawing.Point(7, 6);
            this.dgvHangCanDate.Name = "dgvHangCanDate";
            this.dgvHangCanDate.Size = new System.Drawing.Size(1023, 498);
            this.dgvHangCanDate.TabIndex = 1;
            // 
            // dgvHangTonLau
            // 
            this.dgvHangTonLau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangTonLau.Location = new System.Drawing.Point(7, 6);
            this.dgvHangTonLau.Name = "dgvHangTonLau";
            this.dgvHangTonLau.Size = new System.Drawing.Size(1023, 498);
            this.dgvHangTonLau.TabIndex = 1;
            // 
            // dgvHangCanMin
            // 
            this.dgvHangCanMin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangCanMin.Location = new System.Drawing.Point(7, 6);
            this.dgvHangCanMin.Name = "dgvHangCanMin";
            this.dgvHangCanMin.Size = new System.Drawing.Size(1023, 498);
            this.dgvHangCanMin.TabIndex = 1;
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
            this.ChiTietHangTon.ResumeLayout(false);
            this.HangCanDate.ResumeLayout(false);
            this.HangTonLau.ResumeLayout(false);
            this.HangCanMin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangTon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHangTon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangCanDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangTonLau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangCanMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabTonKhoThuoc;
        private System.Windows.Forms.TabPage HangTon;
        private System.Windows.Forms.TabPage ChiTietHangTon;
        private System.Windows.Forms.TabPage HangCanDate;
        private System.Windows.Forms.DataGridView dgvHangTon;
        private System.Windows.Forms.TabPage HangTonLau;
        private System.Windows.Forms.TabPage HangCanMin;
        private System.Windows.Forms.DataGridView dgvChiTietHangTon;
        private System.Windows.Forms.DataGridView dgvHangCanDate;
        private System.Windows.Forms.DataGridView dgvHangTonLau;
        private System.Windows.Forms.DataGridView dgvHangCanMin;
    }
}