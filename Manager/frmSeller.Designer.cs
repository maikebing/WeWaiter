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
            this.btnAdmin = new DevExpress.XtraBars.BarButtonItem();
            this.btnAdminSeat = new DevExpress.XtraBars.BarButtonItem();
            this.btnRed = new DevExpress.XtraBars.BarButtonItem();
            this.btnUploadHeadPic = new DevExpress.XtraBars.BarButtonItem();
            this.btnCatalog = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.sellerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSellerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBulletin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAvatar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFoodScore = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMinPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRankRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRatingCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colScore = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSellCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServiceScore = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTableNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrintID = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.btnEdit,
            this.btnAdmin,
            this.btnAdminSeat,
            this.btnRed,
            this.btnUploadHeadPic,
            this.btnCatalog});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 12;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(1038, 183);
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
            // btnAdmin
            // 
            this.btnAdmin.Caption = "管理商品";
            this.btnAdmin.Id = 7;
            this.btnAdmin.ImageOptions.Image = global::WWM.Properties.Resources.product_16x16;
            this.btnAdmin.ImageOptions.LargeImage = global::WWM.Properties.Resources.product_32x32;
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdmin_ItemClick);
            // 
            // btnAdminSeat
            // 
            this.btnAdminSeat.Caption = "管理座位";
            this.btnAdminSeat.Id = 8;
            this.btnAdminSeat.ImageOptions.Image = global::WWM.Properties.Resources.tablecellmargins_16x16;
            this.btnAdminSeat.ImageOptions.LargeImage = global::WWM.Properties.Resources.tablecellmargins_32x32;
            this.btnAdminSeat.Name = "btnAdminSeat";
            this.btnAdminSeat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdminSeat_ItemClick);
            // 
            // btnRed
            // 
            this.btnRed.Caption = "管理红包";
            this.btnRed.Id = 9;
            this.btnRed.ImageOptions.Image = global::WWM.Properties.Resources.currency_16x16;
            this.btnRed.ImageOptions.LargeImage = global::WWM.Properties.Resources.currency_32x32;
            this.btnRed.Name = "btnRed";
            // 
            // btnUploadHeadPic
            // 
            this.btnUploadHeadPic.Caption = "上传店铺顶部图片";
            this.btnUploadHeadPic.Id = 10;
            this.btnUploadHeadPic.ImageOptions.Image = global::WWM.Properties.Resources.editwrappoints_16x16;
            this.btnUploadHeadPic.ImageOptions.LargeImage = global::WWM.Properties.Resources.editwrappoints_32x32;
            this.btnUploadHeadPic.Name = "btnUploadHeadPic";
            this.btnUploadHeadPic.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUploadHeadPic_ItemClick);
            // 
            // btnCatalog
            // 
            this.btnCatalog.Caption = "商家分类管理";
            this.btnCatalog.Id = 11;
            this.btnCatalog.ImageOptions.Image = global::WWM.Properties.Resources.cellsautoheight__16x16;
            this.btnCatalog.ImageOptions.LargeImage = global::WWM.Properties.Resources.cellsautoheight__32x32;
            this.btnCatalog.Name = "btnCatalog";
            this.btnCatalog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCatalog_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "商家信息管理";
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
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnAdmin);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnAdminSeat);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnRed);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnCatalog);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "管理";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnUploadHeadPic);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "其他";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 517);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1038, 37);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.sellerBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 183);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1038, 334);
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
            this.colName,
            this.colDescription,
            this.colBulletin,
            this.colAvatar,
            this.colFoodScore,
            this.colMinPrice,
            this.colRankRate,
            this.colRatingCount,
            this.colScore,
            this.colSellCount,
            this.colServiceScore,
            this.colTableNumber,
            this.colDeleted,
            this.colPrintID});
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
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            // 
            // colBulletin
            // 
            this.colBulletin.FieldName = "Bulletin";
            this.colBulletin.Name = "colBulletin";
            this.colBulletin.Visible = true;
            this.colBulletin.VisibleIndex = 2;
            // 
            // colAvatar
            // 
            this.colAvatar.FieldName = "Avatar";
            this.colAvatar.Name = "colAvatar";
            this.colAvatar.Visible = true;
            this.colAvatar.VisibleIndex = 3;
            // 
            // colFoodScore
            // 
            this.colFoodScore.FieldName = "FoodScore";
            this.colFoodScore.Name = "colFoodScore";
            this.colFoodScore.Visible = true;
            this.colFoodScore.VisibleIndex = 4;
            // 
            // colMinPrice
            // 
            this.colMinPrice.FieldName = "MinPrice";
            this.colMinPrice.Name = "colMinPrice";
            this.colMinPrice.Visible = true;
            this.colMinPrice.VisibleIndex = 5;
            // 
            // colRankRate
            // 
            this.colRankRate.FieldName = "RankRate";
            this.colRankRate.Name = "colRankRate";
            this.colRankRate.Visible = true;
            this.colRankRate.VisibleIndex = 6;
            // 
            // colRatingCount
            // 
            this.colRatingCount.FieldName = "RatingCount";
            this.colRatingCount.Name = "colRatingCount";
            this.colRatingCount.Visible = true;
            this.colRatingCount.VisibleIndex = 7;
            // 
            // colScore
            // 
            this.colScore.FieldName = "Score";
            this.colScore.Name = "colScore";
            this.colScore.Visible = true;
            this.colScore.VisibleIndex = 8;
            // 
            // colSellCount
            // 
            this.colSellCount.FieldName = "SellCount";
            this.colSellCount.Name = "colSellCount";
            this.colSellCount.Visible = true;
            this.colSellCount.VisibleIndex = 9;
            // 
            // colServiceScore
            // 
            this.colServiceScore.FieldName = "ServiceScore";
            this.colServiceScore.Name = "colServiceScore";
            this.colServiceScore.Visible = true;
            this.colServiceScore.VisibleIndex = 10;
            // 
            // colTableNumber
            // 
            this.colTableNumber.FieldName = "TableNumber";
            this.colTableNumber.Name = "colTableNumber";
            this.colTableNumber.Visible = true;
            this.colTableNumber.VisibleIndex = 11;
            // 
            // colDeleted
            // 
            this.colDeleted.FieldName = "Deleted";
            this.colDeleted.Name = "colDeleted";
            this.colDeleted.Visible = true;
            this.colDeleted.VisibleIndex = 12;
            // 
            // colPrintID
            // 
            this.colPrintID.FieldName = "PrintID";
            this.colPrintID.Name = "colPrintID";
            this.colPrintID.Visible = true;
            this.colPrintID.VisibleIndex = 13;
            // 
            // frmSeller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 554);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "frmSeller";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "商家管理";
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
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnAdmin;
        private DevExpress.XtraGrid.Columns.GridColumn colSellerID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colBulletin;
        private DevExpress.XtraGrid.Columns.GridColumn colAvatar;
        private DevExpress.XtraGrid.Columns.GridColumn colFoodScore;
        private DevExpress.XtraGrid.Columns.GridColumn colMinPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colRankRate;
        private DevExpress.XtraGrid.Columns.GridColumn colRatingCount;
        private DevExpress.XtraGrid.Columns.GridColumn colScore;
        private DevExpress.XtraGrid.Columns.GridColumn colSellCount;
        private DevExpress.XtraGrid.Columns.GridColumn colServiceScore;
        private DevExpress.XtraGrid.Columns.GridColumn colTableNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colDeleted;
        private DevExpress.XtraGrid.Columns.GridColumn colPrintID;
        private DevExpress.XtraBars.BarButtonItem btnAdminSeat;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnRed;
        private DevExpress.XtraBars.BarButtonItem btnUploadHeadPic;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem btnCatalog;
    }
}