using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


namespace WebApplication1
{
    public partial class MenuDatabase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection SqlConnection = new SqlConnection(connectionString);
                {
                    SqlDataAdapter SqlDataAdapter = new SqlDataAdapter();
                    SqlCommand SqlCommand = new SqlCommand();
                    SqlConnection.Open();
                    SqlCommand.CommandText = "select * from MenuGroup";
                    SqlCommand.Connection = SqlConnection;
                    SqlDataReader dr = SqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    var count = new int();
                    count = 0;
                    int id;
                    string key;
                    Dictionary<string, int> D = new Dictionary<string, int>();
                    D.Add("Select a Group", 0);
                    while (dr.Read())
                    {
                        key = dr["MenuGroupText"].ToString();
                        id = dr.GetInt32(0);
                        // id =  dr.["MenuGroupID"].GetInt32();
                        D.Add(key, id);
                        count += 1;
                    }
                    SqlConnection.Close();
                    Ddl1.DataSource = D;
                    Ddl1.DataTextField = "Key";
                    Ddl1.DataValueField = "Value";
                    Ddl1.DataBind();

                }

            }
            else
            { //this is a post back - pull out fresh data according groupd selected value
                var x = Ddl1.SelectedValue;
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection SqlConnection = new SqlConnection(connectionString);
                {
                    SqlDataAdapter SqlDataAdapter = new SqlDataAdapter();
                    SqlCommand SqlCommand = new SqlCommand();
                    SqlConnection.Open();
                    SqlCommand.CommandText = "select MenuItemTitle,MenuItemDescriptionText,MenuItemCost from MenuItem where MenuGroupID =" + x.ToString();
                    SqlCommand.Connection = SqlConnection;
                    SqlDataReader dr = SqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    var count = new int();
                    count = 0;
                    //int id;
                    //string key;
                    Dictionary<string, int> D = new Dictionary<string, int>();
                    DataTable DT = new DataTable();
                    DT.Columns.Add("Price", typeof(string));
                    DT.Columns.Add("Item", typeof(string));
                    DT.Columns.Add("Description", typeof(string));
                    while (dr.Read())
                    {
                        DT.Rows.Add(dr["MenuItemCost"].ToString(),dr["MenuItemTitle"].ToString(),dr["MenuItemDescriptionText"].ToString());
                        //key = dr["MenuItemTitle"].ToString();
                        //id = dr.GetInt32(0);
                        // id =  dr.["MenuGroupID"].GetInt32();
                        //D.Add(key, id);
                        count += 1;
                    }
                    SqlConnection.Close();
                    DataView v = new DataView(DT);
                    v.Sort =  "Item ASC";
                    Gv1.DataSource = v;
                    Gv1.DataBind();
                    MessageLabel.Text = "";
                    //Ddl1.DataSource = D;
                    //Ddl1.DataTextField = "Key";
                    //Ddl1.DataValueField = "Value";
                    //Ddl1.DataBind();

                }

            }
        }
        protected void ItemSelect(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = Gv1.Rows[e.NewSelectedIndex];
            string c = row.Cells[2].Text;
            string price = row.Cells[1].Text;
            MessageLabel.Text = " " + c + " Added to Order - Price $ "+price + " ";
            e.Cancel = true;
        }
        protected void GroupSelected(object sender, EventArgs e)
        {
            SelectedGroup.Text = Ddl1.SelectedValue;
        }

    }
}