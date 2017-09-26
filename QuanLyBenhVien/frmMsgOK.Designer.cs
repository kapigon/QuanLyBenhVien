namespace QuanLyBenhVien
{
    partial class frmMsgOK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMsgOK));
            this.btnOK = new System.Windows.Forms.Button();
            this.lblloiNhac = new System.Windows.Forms.Label();
            this.picInfomation = new System.Windows.Forms.PictureBox();
            this.picStop = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picInfomation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStop)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(136, 60);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 30);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "  Đóng";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // lblloiNhac
            // 
            this.lblloiNhac.AutoSize = true;
            this.lblloiNhac.Location = new System.Drawing.Point(57, 10);
            this.lblloiNhac.Name = "lblloiNhac";
            this.lblloiNhac.Size = new System.Drawing.Size(48, 13);
            this.lblloiNhac.TabIndex = 3;
            this.lblloiNhac.Text = "Lời nhắc";
            // 
            // picInfomation
            // 
            this.picInfomation.Image = ((System.Drawing.Image)(resources.GetObject("picInfomation.Image")));
            this.picInfomation.Location = new System.Drawing.Point(12, 12);
            this.picInfomation.Name = "picInfomation";
            this.picInfomation.Size = new System.Drawing.Size(32, 32);
            this.picInfomation.TabIndex = 4;
            this.picInfomation.TabStop = false;
            // 
            // picStop
            // 
            this.picStop.Image = ((System.Drawing.Image)(resources.GetObject("picStop.Image")));
            this.picStop.Location = new System.Drawing.Point(12, 12);
            this.picStop.Name = "picStop";
            this.picStop.Size = new System.Drawing.Size(32, 32);
            this.picStop.TabIndex = 5;
            this.picStop.TabStop = false;
            // 
            // frmMsgOK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 110);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblloiNhac);
            this.Controls.Add(this.picInfomation);
            this.Controls.Add(this.picStop);
            this.Name = "frmMsgOK";
            this.Text = "THÔNG BÁO";
            ((System.ComponentModel.ISupportInitialize)(this.picInfomation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Label lblloiNhac;
        internal System.Windows.Forms.PictureBox picInfomation;
        internal System.Windows.Forms.PictureBox picStop;
    }
}