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
    public partial class frmSeat : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmSeat()
        {
            InitializeComponent();
        }
        EFDB db = new EFDB();
        public string SellerID { get; set; }
        void LoadData()
        {
            db = new EFDB();
            var gd = from g in db.Seat where g.Seller == SellerID orderby g.Seats select g;
            gd.Load();
            this.seatBindingSource.DataSource = db.Seat.Local.ToBindingList();
        }
        private void btnLoad_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
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
            gridView1.SetRowCellValue(e.RowHandle,  colSeatId , Guid.NewGuid().ToString("N"));
            gridView1.SetRowCellValue(e.RowHandle, colSeller, SellerID);
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
            if (XtraMessageBox.Show("是否确定删除所选座位", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                gridView1.DeleteSelectedRows();
            }
        }

        private void frmSeat_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}