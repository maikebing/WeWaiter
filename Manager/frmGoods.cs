using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using WWM.Database;
using System.Data.Entity;
using DevExpress.XtraEditors;
using System.IO;

namespace WWM
{
    public partial class frmGoods : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmGoods()
        {
            InitializeComponent();
        }
        EFDB db = new EFDB();
        private void frmGoods_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public string SellerID { get; set; }
        public void LoadData()
        {
            db = new EFDB();
            var  cbs = from g in db.Catalog where g.SellerID == SellerID orderby g.OrderBy select g;
            cbs.Load();
            catalogBindingSource.DataSource = db.Catalog.Local.ToBindingList();
            var gd = from g in db.Goods where g.Seller == SellerID orderby g.Name  select g ;
            gd.Load();
            goodsBindingSource.DataSource = db.Goods.Local.ToBindingList();
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (db.ChangeTracker.HasChanges())
            {
                try
                {
                    int result = db.SaveChanges();
                    XtraMessageBox.Show(result > 0 ? "保存完成" : "未保存任何数据");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
            else
            {
                XtraMessageBox.Show("没有需要保存的数据。");
            }
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetRowCellValue(e.RowHandle,  colGoodsID, Guid.NewGuid().ToString("N"));
            gridView1.SetRowCellValue(e.RowHandle, colSeller,  SellerID);
        }

        private void btnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView1.AddNewRow();
            gridView1.ShowEditForm();
        }

        private void btnEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView1.ShowEditForm();
        }

        private void gridView1_EditFormPrepared(object sender, DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventArgs e)
        {
            (e.Panel.Parent as Form).StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("是否确定删除所选商品", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                gridView1.DeleteSelectedRows();
            }
        }

        private void btnReload_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
        }

        private void btnUploadIcon_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() is Goods pjt)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename =$"{pjt.Seller}/Goods/{pjt.GoodsID}_Icon{ new FileInfo(openFileDialog.FileName).Extension}";
                    if (Utils.OSS.CopyFile(openFileDialog.FileName, filename))
                    {
                        pjt.Icon = filename;
                        //   gridView1.SetFocusedRowCellValue(colAvatar, filename);
                    }
                }
            }
        }

        private void btnUploadImage_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() is Goods pjt)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = $"{pjt.Seller}/Goods/{pjt.GoodsID}_Image{ new FileInfo(openFileDialog.FileName).Extension}";
                    if (Utils.OSS.CopyFile(openFileDialog.FileName, filename))
                    {
                        pjt.Image = filename;
                        //   gridView1.SetFocusedRowCellValue(colAvatar, filename);
                    }
                }
            }
        }
    }
}