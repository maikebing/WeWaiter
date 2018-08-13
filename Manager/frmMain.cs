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

        private async  void barButtonItem1_ItemClickAsync(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WWMClient wWM = new WWMClient(new Uri("http://localhost:5000"), new Microsoft.Rest.TokenCredentials("header"));
            this.Text = await wWM.ApiValuesByIdGetAsync(1, "header");
        }
    }
}
