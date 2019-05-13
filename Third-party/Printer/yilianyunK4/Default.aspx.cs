using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
    printGPRS f = new printGPRS(); 

    protected void Page_Load(object sender, EventArgs e)
    {






    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Response.Write(f.SendGprsPrintContent(TextBox1.Text));




    }
}
