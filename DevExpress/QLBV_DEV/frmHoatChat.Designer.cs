namespace QLBV_DEV
{
    partial class frmHoatChat
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
            DevExpress.XtraPrinting.BarCode.Code39Generator code39Generator1 = new DevExpress.XtraPrinting.BarCode.Code39Generator();
            this.barCodeControl1 = new DevExpress.XtraEditors.BarCodeControl();
            this.SuspendLayout();
            // 
            // barCodeControl1
            // 
            this.barCodeControl1.AutoModule = true;
            this.barCodeControl1.Location = new System.Drawing.Point(84, 79);
            this.barCodeControl1.Name = "barCodeControl1";
            this.barCodeControl1.Orientation = DevExpress.XtraPrinting.BarCode.BarCodeOrientation.UpsideDown;
            this.barCodeControl1.Padding = new System.Windows.Forms.Padding(10, 2, 10, 0);
            this.barCodeControl1.ShowText = false;
            this.barCodeControl1.Size = new System.Drawing.Size(134, 72);
            code39Generator1.WideNarrowRatio = 3F;
            this.barCodeControl1.Symbology = code39Generator1;
            this.barCodeControl1.TabIndex = 0;
            // 
            // frmHoatChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 305);
            this.Controls.Add(this.barCodeControl1);
            this.Name = "frmHoatChat";
            this.Text = "frmHoatChat";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.BarCodeControl barCodeControl1;
    }
}