using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class States : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //we have to add this dynamic control on every load
            Button b = new Button();
            dyncontrol.Controls.Add(b);
            b.Text = "Back to Home";
            b.PostBackUrl = "/";
            if (!this.IsPostBack)
            {
                USStates s = new USStates();
                Dictionary<string, string> L;
                Literal1.Mode = LiteralMode.PassThrough;
                Literal1.Text = s.AsHtmlTable();
                L = s.AsDictionary();
                Ddl1.DataSource = L;
                Ddl1.DataTextField = "Value";
                Ddl1.DataValueField = "Key";
                Ddl1.DataBind();
                SState.Text = "No State Selected";
                Gv1.AllowSorting = true;
                Gv1.DataSource = s.AsDataTable();
                Gv1.DataBind();
            }
            else
            {
            }
        }
        protected void StateSelected(object sender, EventArgs e)
        {
            SState.Text=Ddl1.SelectedValue;
        }
        protected void GridViewSortEventHandler(object sender, GridViewSortEventArgs e)
        {
            USStates s = new USStates();
            DataView v = new DataView(s.AsDataTable());
            v.Sort = e.SortExpression + " ASC";
            Gv1.DataSource = v;
            Gv1.DataBind();
        }
    }
    //A state objects holds the name and abbreviation of a state
    public class State
    {
        public string Name, Abbreviation;
        public State(string N, string A)
        {
            Name = N;
            Abbreviation = A;
        }
    }
    public class USStates
    {
        public object[] States;
        public USStates()
        {
            States = new object[5];
            States[0] = new State("Florida","FL");
            States[1] = new State("Georgia","GA");
            States[2] = new State("South Carolina", "SC");
            States[3] = new State("North Carolina", "NC");
            States[4] = new State("Virginia", "VA");
        }
        public string AsHtmlTable()
        {
            string H;
            H = "<table>";
            foreach (State e in States)
            {
                if (e != null)
                {
                    H += "<tr><td>" + e.Name + "</td><td>" + e.Abbreviation + "</td></tr>";
                }
            }
            H += "</table>";
            return H;
        }
        public DataTable AsDataTable()
        { 
            DataTable DT = new DataTable();
            DT.Columns.Add("State", typeof(string));
            DT.Columns.Add("Abbreviation", typeof(string));
            foreach (State e in States)
            {
                if( e != null )
                {
                    DT.Rows.Add(e.Name,e.Abbreviation);
                }
            }
            return DT;
        }

        public Dictionary<string, string> AsDictionary()
        {
            Dictionary<string,string> D = new Dictionary<string,string>();
            foreach (State e in States)
            {
                if( e != null )
                {
                    D.Add(e.Abbreviation,e.Name);
                }
            }
            return D;
        }
    }
}