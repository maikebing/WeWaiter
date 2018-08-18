namespace WWM
{
    partial class frmGoods
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
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnGoogls = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.goodsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGoodsID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQRCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShortName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPictureURL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchasePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSellingPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMinSellingPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoldOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSeller = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsBindingSource)).BeginInit();
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
            this.btnAdd,
            this.btnEdit,
            this.btnDelete});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 6;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.btnGoogls});
            this.ribbon.Size = new System.Drawing.Size(833, 183);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnReload
            // 
            this.btnReload.Caption = "刷新";
            this.btnReload.Id = 1;
            this.btnReload.ImageOptions.LargeImage = global::WWM.Properties.Resources.recurrence_32x32;
            this.btnReload.Name = "btnReload";
            this.btnReload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReload_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "保存";
            this.btnSave.Id = 2;
            this.btnSave.ImageOptions.LargeImage = global::WWM.Properties.Resources.save_32x32;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "添加";
            this.btnAdd.Id = 3;
            this.btnAdd.ImageOptions.LargeImage = global::WWM.Properties.Resources.add_32x32;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "编辑";
            this.btnEdit.Id = 4;
            this.btnEdit.ImageOptions.LargeImage = global::WWM.Properties.Resources.edit_32x32;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "删除";
            this.btnDelete.Id = 5;
            this.btnDelete.ImageOptions.LargeImage = global::WWM.Properties.Resources.recurrence_32x32;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnGoogls
            // 
            this.btnGoogls.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.btnGoogls.Name = "btnGoogls";
            this.btnGoogls.Text = "商家商品管理";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnReload);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSave);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAdd);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDelete);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "商品管理";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 470);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(833, 37);
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "管理";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.goodsBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 183);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(833, 287);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // goodsBindingSource
            // 
            this.goodsBindingSource.DataSource = typeof(WWM.Database.Goods);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGoodsID,
            this.colBarCode,
            this.colQRCode,
            this.colFullName,
            this.colShortName,
            this.colPictureURL,
            this.colPurchasePrice,
            this.colSellingPrice,
            this.colMinSellingPrice,
            this.colDescription,
            this.colStatus,
            this.colStock,
            this.colSoldOut,
            this.colSeller});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.EditFormPrepared += new DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventHandler(this.gridView1_EditFormPrepared);
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            // 
            // colGoodsID
            // 
            this.colGoodsID.FieldName = "GoodsID";
            this.colGoodsID.Name = "colGoodsID";
            // 
            // colBarCode
            // 
            this.colBarCode.Caption = "条形码";
            this.colBarCode.FieldName = "BarCode";
            this.colBarCode.Name = "colBarCode";
            this.colBarCode.Visible = true;
            this.colBarCode.VisibleIndex = 0;
            // 
            // colQRCode
            // 
            this.colQRCode.Caption = "二维码";
            this.colQRCode.FieldName = "QRCode";
            this.colQRCode.Name = "colQRCode";
            this.colQRCode.Visible = true;
            this.colQRCode.VisibleIndex = 1;
            // 
            // colFullName
            // 
            this.colFullName.Caption = "全名";
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 2;
            // 
            // colShortName
            // 
            this.colShortName.Caption = "简称";
            this.colShortName.FieldName = "ShortName";
            this.colShortName.Name = "colShortName";
            this.colShortName.Visible = true;
            this.colShortName.VisibleIndex = 3;
            // 
            // colPictureURL
            // 
            this.colPictureURL.Caption = "图片";
            this.colPictureURL.FieldName = "PictureURL";
            this.colPictureURL.Name = "colPictureURL";
            this.colPictureURL.Visible = true;
            this.colPictureURL.VisibleIndex = 4;
            // 
            // colPurchasePrice
            // 
            this.colPurchasePrice.Caption = "进货价";
            this.colPurchasePrice.FieldName = "PurchasePrice";
            this.colPurchasePrice.Name = "colPurchasePrice";
            this.colPurchasePrice.Visible = true;
            this.colPurchasePrice.VisibleIndex = 5;
            // 
            // colSellingPrice
            // 
            this.colSellingPrice.Caption = "售价";
            this.colSellingPrice.FieldName = "SellingPrice";
            this.colSellingPrice.Name = "colSellingPrice";
            this.colSellingPrice.Visible = true;
            this.colSellingPrice.VisibleIndex = 6;
            // 
            // colMinSellingPrice
            // 
            this.colMinSellingPrice.Caption = "最小售价";
            this.colMinSellingPrice.FieldName = "MinSellingPrice";
            this.colMinSellingPrice.Name = "colMinSellingPrice";
            this.colMinSellingPrice.Visible = true;
            this.colMinSellingPrice.VisibleIndex = 7;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "描述";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 8;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "状态";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 9;
            // 
            // colStock
            // 
            this.colStock.Caption = "库存";
            this.colStock.FieldName = "Stock";
            this.colStock.Name = "colStock";
            this.colStock.Visible = true;
            this.colStock.VisibleIndex = 10;
            // 
            // colSoldOut
            // 
            this.colSoldOut.Caption = "停售";
            this.colSoldOut.FieldName = "SoldOut";
            this.colSoldOut.Name = "colSoldOut";
            this.colSoldOut.Visible = true;
            this.colSoldOut.VisibleIndex = 11;
            // 
            // colSeller
            // 
            this.colSeller.Caption = "gridColumn1";
            this.colSeller.FieldName = "Seller";
            this.colSeller.Name = "colSeller";
            // 
            // frmGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 507);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "frmGoods";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "商家商品管理";
            this.Load += new System.EventHandler(this.frmGoods_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage btnGoogls;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnReload;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource goodsBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsID;
        private DevExpress.XtraGrid.Columns.GridColumn colBarCode;
        private DevExpress.XtraGrid.Columns.GridColumn colQRCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colShortName;
        private DevExpress.XtraGrid.Columns.GridColumn colPictureURL;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchasePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colSellingPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colMinSellingPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colStock;
        private DevExpress.XtraGrid.Columns.GridColumn colSoldOut;
        private DevExpress.XtraGrid.Columns.GridColumn colSeller;
    }
}