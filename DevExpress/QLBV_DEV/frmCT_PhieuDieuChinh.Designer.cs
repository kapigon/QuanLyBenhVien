namespace QLBV_DEV
{
    partial class frmCT_PhieuDieuChinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCT_PhieuDieuChinh));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.grvCT_PhieuDieuChinh = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaThuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenThuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoLuongKiemKe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TonSoSach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtColTonSoSach = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.SoLuongTang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoLuongGiam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvCT_PhieuDieuChinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColTonSoSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Controls.Add(this.btnThoat);
            this.layoutControl1.Controls.Add(this.grvCT_PhieuDieuChinh);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(769, 247, 250, 350);
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControl1.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControl1.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControl1.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(857, 382);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Teal;
            this.labelControl1.Location = new System.Drawing.Point(200, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.labelControl1.Size = new System.Drawing.Size(456, 33);
            this.labelControl1.StyleController = this.layoutControl1;
            this.labelControl1.TabIndex = 19;
            this.labelControl1.Text = "SỐ LƯỢNG THUỐC ĐIỀU CHỈNH THEO KIỂM KÊ";
            // 
            // btnThoat
            // 
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(12, 335);
            this.btnThoat.MaximumSize = new System.Drawing.Size(100, 35);
            this.btnThoat.MinimumSize = new System.Drawing.Size(100, 35);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 35);
            this.btnThoat.StyleController = this.layoutControl1;
            this.btnThoat.TabIndex = 16;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // grvCT_PhieuDieuChinh
            // 
            this.grvCT_PhieuDieuChinh.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.grvCT_PhieuDieuChinh.Location = new System.Drawing.Point(12, 49);
            this.grvCT_PhieuDieuChinh.MainView = this.gridView1;
            this.grvCT_PhieuDieuChinh.Name = "grvCT_PhieuDieuChinh";
            this.grvCT_PhieuDieuChinh.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemCheckEdit1,
            this.txtColTonSoSach});
            this.grvCT_PhieuDieuChinh.Size = new System.Drawing.Size(833, 282);
            this.grvCT_PhieuDieuChinh.TabIndex = 10;
            this.grvCT_PhieuDieuChinh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaThuoc,
            this.TenThuoc,
            this.ID,
            this.SoLuongKiemKe,
            this.TonSoSach,
            this.SoLuongTang,
            this.SoLuongGiam,
            this.GhiChu,
            this.gridColumn7});
            this.gridView1.GridControl = this.grvCT_PhieuDieuChinh;
            this.gridView1.Name = "gridView1";
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // MaThuoc
            // 
            this.MaThuoc.Caption = "Mã thuốc";
            this.MaThuoc.FieldName = "MaThuoc";
            this.MaThuoc.Name = "MaThuoc";
            this.MaThuoc.Visible = true;
            this.MaThuoc.VisibleIndex = 0;
            // 
            // TenThuoc
            // 
            this.TenThuoc.Caption = "Tên thuốc";
            this.TenThuoc.FieldName = "TenThuoc";
            this.TenThuoc.Name = "TenThuoc";
            this.TenThuoc.Visible = true;
            this.TenThuoc.VisibleIndex = 1;
            // 
            // ID
            // 
            this.ID.AppearanceHeader.Options.UseTextOptions = true;
            this.ID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // SoLuongKiemKe
            // 
            this.SoLuongKiemKe.AppearanceCell.Options.UseTextOptions = true;
            this.SoLuongKiemKe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SoLuongKiemKe.AppearanceHeader.Options.UseTextOptions = true;
            this.SoLuongKiemKe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SoLuongKiemKe.Caption = "Số lượng kiểm kê";
            this.SoLuongKiemKe.FieldName = "SoLuongKiemKe";
            this.SoLuongKiemKe.Name = "SoLuongKiemKe";
            this.SoLuongKiemKe.OptionsColumn.ReadOnly = true;
            this.SoLuongKiemKe.Visible = true;
            this.SoLuongKiemKe.VisibleIndex = 2;
            // 
            // TonSoSach
            // 
            this.TonSoSach.AppearanceCell.Options.UseTextOptions = true;
            this.TonSoSach.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TonSoSach.AppearanceHeader.Options.UseTextOptions = true;
            this.TonSoSach.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TonSoSach.Caption = "Tồn sổ sách";
            this.TonSoSach.ColumnEdit = this.txtColTonSoSach;
            this.TonSoSach.FieldName = "TonSoSach";
            this.TonSoSach.Name = "TonSoSach";
            this.TonSoSach.Visible = true;
            this.TonSoSach.VisibleIndex = 3;
            // 
            // txtColTonSoSach
            // 
            this.txtColTonSoSach.AutoHeight = false;
            this.txtColTonSoSach.Name = "txtColTonSoSach";
            // 
            // SoLuongTang
            // 
            this.SoLuongTang.AppearanceCell.Options.UseTextOptions = true;
            this.SoLuongTang.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SoLuongTang.AppearanceHeader.Options.UseTextOptions = true;
            this.SoLuongTang.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SoLuongTang.Caption = "Số lượng tăng";
            this.SoLuongTang.FieldName = "SoLuongTang";
            this.SoLuongTang.Name = "SoLuongTang";
            this.SoLuongTang.OptionsColumn.ReadOnly = true;
            this.SoLuongTang.Visible = true;
            this.SoLuongTang.VisibleIndex = 4;
            // 
            // SoLuongGiam
            // 
            this.SoLuongGiam.AppearanceCell.Options.UseTextOptions = true;
            this.SoLuongGiam.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SoLuongGiam.AppearanceHeader.Options.UseTextOptions = true;
            this.SoLuongGiam.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SoLuongGiam.Caption = "Số lượng giảm";
            this.SoLuongGiam.FieldName = "SoLuongGiam";
            this.SoLuongGiam.Name = "SoLuongGiam";
            this.SoLuongGiam.OptionsColumn.ReadOnly = true;
            this.SoLuongGiam.Visible = true;
            this.SoLuongGiam.VisibleIndex = 5;
            // 
            // GhiChu
            // 
            this.GhiChu.AppearanceHeader.Options.UseTextOptions = true;
            this.GhiChu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GhiChu.Caption = "Ghi chú";
            this.GhiChu.FieldName = "GhiChu";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Visible = true;
            this.GhiChu.VisibleIndex = 6;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "CT_Thuoc_PhieuNhap_ID";
            this.gridColumn7.FieldName = "CT_Thuoc_PhieuNhap_ID";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // Root
            // 
            this.Root.CustomizationFormText = "Root";
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem7,
            this.layoutControlItem11,
            this.layoutControlItem5});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(857, 382);
            this.Root.Text = "Root";
            this.Root.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.grvCT_PhieuDieuChinh;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 37);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(837, 286);
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.btnThoat;
            this.layoutControlItem11.CustomizationFormText = "layoutControlItem11";
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 323);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(837, 39);
            this.layoutControlItem11.Text = "layoutControlItem11";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.labelControl1;
            this.layoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(837, 37);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // frmCT_PhieuDieuChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 382);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmCT_PhieuDieuChinh";
            this.Text = "Chi tiết phiếu điều chỉnh";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvCT_PhieuDieuChinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColTonSoSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl grvCT_PhieuDieuChinh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn SoLuongKiemKe;
        private DevExpress.XtraGrid.Columns.GridColumn TonSoSach;
        private DevExpress.XtraGrid.Columns.GridColumn SoLuongTang;
        private DevExpress.XtraGrid.Columns.GridColumn SoLuongGiam;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtColTonSoSach;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn GhiChu;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn MaThuoc;
        private DevExpress.XtraGrid.Columns.GridColumn TenThuoc;
    }
}