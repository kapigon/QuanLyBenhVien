namespace QuanLyBenhVien.Reports
{
    partial class frmBaoCao
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
            this.crvBaoCao = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.rptNhanVien = new QuanLyBenhVien.Reports.rptNhanVien();
            this.SuspendLayout();
            // 
            // crvBaoCao
            // 
            this.crvBaoCao.ActiveViewIndex = -1;
            this.crvBaoCao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvBaoCao.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvBaoCao.Location = new System.Drawing.Point(0, 0);
            this.crvBaoCao.Name = "crvBaoCao";
            this.crvBaoCao.Size = new System.Drawing.Size(860, 625);
            this.crvBaoCao.TabIndex = 0;
            // 
            // frmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 625);
            this.Controls.Add(this.crvBaoCao);
            this.Name = "frmBaoCao";
            this.Text = "frmBaoCao";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvBaoCao;
        private rptNhanVien rptNhanVien;
    }
}