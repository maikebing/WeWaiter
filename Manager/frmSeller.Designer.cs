namespace WWM
{
    partial class frmSeller
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
            this.components = new System.ComponentModel.Container();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnReload = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.sellerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSellerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShortName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMapURL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogoURL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOwnerWeixinID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOwnerPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOwnerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOwnerIDNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sellerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnReload,
            this.btnSave,
            this.btnDelete,
            this.btnAdd,
            this.btnEdit});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 7;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(813, 183);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnReload
            // 
            this.btnReload.Caption = "刷新";
            this.btnReload.Id = 1;
            this.btnReload.ImageOptions.Image = global::WWM.Properties.Resources.recurrence_16x16;
            this.btnReload.ImageOptions.LargeImage = global::WWM.Properties.Resources.recurrence_32x32;
            this.btnReload.Name = "btnReload";
            this.btnReload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReload_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "保存";
            this.btnSave.Id = 2;
            this.btnSave.ImageOptions.Image = global::WWM.Properties.Resources.save_16x16;
            this.btnSave.ImageOptions.LargeImage = global::WWM.Properties.Resources.save_32x32;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "删除";
            this.btnDelete.Id = 3;
            this.btnDelete.ImageOptions.Image = global::WWM.Properties.Resources.removeitem_16x16;
            this.btnDelete.ImageOptions.LargeImage = global::WWM.Properties.Resources.removeitem_32x32;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "添加";
            this.btnAdd.Id = 4;
            this.btnAdd.ImageOptions.Image = global::WWM.Properties.Resources.add_16x16;
            this.btnAdd.ImageOptions.LargeImage = global::WWM.Properties.Resources.add_32x32;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "编辑";
            this.btnEdit.Id = 5;
            this.btnEdit.ImageOptions.Image = global::WWM.Properties.Resources.edit_16x16;
            this.btnEdit.ImageOptions.LargeImage = global::WWM.Properties.Resources.edit_32x32;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnReload);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSave);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAdd);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDelete);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "管理";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 517);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(813, 37);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.sellerBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 183);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(813, 334);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // sellerBindingSource
            // 
            this.sellerBindingSource.DataSource = typeof(WWM.Database.Seller);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSellerID,
            this.colFullName,
            this.colShortName,
            this.colAddress,
            this.colMapURL,
            this.colLogoURL,
            this.colOwnerWeixinID,
            this.colOwnerPhone,
            this.colOwnerName,
            this.colOwnerIDNumber});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "添加新卖家";
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridView1.OptionsEditForm.EditFormColumnCount = 2;
            this.gridView1.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.EditFormPrepared += new DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventHandler(this.gridView1_EditFormPrepared);
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            // 
            // colSellerID
            // 
            this.colSellerID.FieldName = "SellerID";
            this.colSellerID.Name = "colSellerID";
            this.colSellerID.Visible = true;
            this.colSellerID.VisibleIndex = 0;
            // 
            // colFullName
            // 
            this.colFullName.Caption = "商家全名";
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 1;
            // 
            // colShortName
            // 
            this.colShortName.Caption = "商家简写名称";
            this.colShortName.FieldName = "ShortName";
            this.colShortName.Name = "colShortName";
            this.colShortName.Visible = true;
            this.colShortName.VisibleIndex = 2;
            // 
            // colAddress
            // 
            this.colAddress.Caption = "注册地址";
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 3;
            // 
            // colMapURL
            // 
            this.colMapURL.Caption = "地图链接";
            this.colMapURL.FieldName = "MapURL";
            this.colMapURL.Name = "colMapURL";
            this.colMapURL.Visible = true;
            this.colMapURL.VisibleIndex = 4;
            // 
            // colLogoURL
            // 
            this.colLogoURL.Caption = "LOGO链接";
            this.colLogoURL.FieldName = "LogoURL";
            this.colLogoURL.Name = "colLogoURL";
            this.colLogoURL.Visible = true;
            this.colLogoURL.VisibleIndex = 5;
            // 
            // colOwnerWeixinID
            // 
            this.colOwnerWeixinID.Caption = "微信所有者注册ID";
            this.colOwnerWeixinID.FieldName = "OwnerWeixinID";
            this.colOwnerWeixinID.Name = "colOwnerWeixinID";
            this.colOwnerWeixinID.Visible = true;
            this.colOwnerWeixinID.VisibleIndex = 6;
            // 
            // colOwnerPhone
            // 
            this.colOwnerPhone.Caption = "电话号码";
            this.colOwnerPhone.FieldName = "OwnerPhone";
            this.colOwnerPhone.Name = "colOwnerPhone";
            this.colOwnerPhone.Visible = true;
            this.colOwnerPhone.VisibleIndex = 7;
            // 
            // colOwnerName
            // 
            this.colOwnerName.Caption = "所有者姓名";
            this.colOwnerName.FieldName = "OwnerName";
            this.colOwnerName.Name = "colOwnerName";
            this.colOwnerName.Visible = true;
            this.colOwnerName.VisibleIndex = 8;
            // 
            // colOwnerIDNumber
            // 
            this.colOwnerIDNumber.Caption = "所有者身份证";
            this.colOwnerIDNumber.FieldName = "OwnerIDNumber";
            this.colOwnerIDNumber.Name = "colOwnerIDNumber";
            this.colOwnerIDNumber.Visible = true;
            this.colOwnerIDNumber.VisibleIndex = 9;
            // 
            // frmSeller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 554);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "frmSeller";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "frmSeller";
            this.Load += new System.EventHandler(this.frmSeller_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sellerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnReload;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource sellerBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colSellerID;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colShortName;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colMapURL;
        private DevExpress.XtraGrid.Columns.GridColumn colLogoURL;
        private DevExpress.XtraGrid.Columns.GridColumn colOwnerWeixinID;
        private DevExpress.XtraGrid.Columns.GridColumn colOwnerPhone;
        private DevExpress.XtraGrid.Columns.GridColumn colOwnerName;
        private DevExpress.XtraGrid.Columns.GridColumn colOwnerIDNumber;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
    }
}