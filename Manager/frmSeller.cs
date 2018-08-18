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

namespace WWM
{
    public partial class frmSeller : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmSeller()
        {
            InitializeComponent();
        }
        EFDB db = new EFDB();
        private void btnReload_ItemClick(object sender, ItemClickEventArgs e)
        {
            db = new EFDB();
            db.Seller.Load();
            sellerBindingSource.DataSource = db.Seller.Local.ToBindingList();
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

        private void frmSeller_Load(object sender, EventArgs e)
        {
            btnReload.PerformClick();
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetRowCellValue(e.RowHandle, colSellerID, Guid.NewGuid().ToString().Replace("-", ""));
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
            if (XtraMessageBox.Show("是否确定删除所选商家", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                gridView1.DeleteSelectedRows();
            }

        }

        private void btnAdmin_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() is Seller pjt)
            {
                new frmGoods()
                {
                    MdiParent = this.MdiParent,
                    OwnnerID = pjt.SellerID,
                    Text = $"编辑[{pjt.Name}]的商品"
                }.Show();
            }

        }
    }
}