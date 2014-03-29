using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

namespace WebApplication1
{
    public partial class Calendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //StartDate.ForeColor = Color.LightGoldenrodYellow;
                //StartDate.ForeColor = Color.DeepPink;
                StartDate.Font.Bold = true;
                StartDate.Font.Size = FontUnit.Medium;
                StartDate.Font.Name = "Comic Sans MS";
            }  

        }
    }
}