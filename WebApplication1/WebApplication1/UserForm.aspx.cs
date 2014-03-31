using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class UserForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Int32.Parse((string)e.CommandArgument);
            string EmailAddress = (string)GridView1.DataKeys[index].Values["EMail"];
            string FName = (string)GridView1.DataKeys[index].Values["FullName"];
            string url = "mailto:" + EmailAddress;
            //string s = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
            string s = "window.open('" + url + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);

        }

    }
}