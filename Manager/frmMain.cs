using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WWM
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSellerAdmin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSeller seller = new frmSeller() { MdiParent = this };
            seller.Show( );
        }
    }
}
