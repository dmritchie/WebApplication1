using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.Account
{
    public partial class EditUserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Context.User.Identity.IsAuthenticated) Response.Redirect("~/Account/Manage.aspx");
            if (!this.IsPostBack)
            {
                //var currentUserId = User.Identity.GetUserId();
                //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                //var currentUser = manager.FindById(User.Identity.GetUserId());
                //Name.Text = currentUser.SurName;
                //Address.Text = currentUser.Address;
                //City.Text = currentUser.City;
                //State.Text = currentUser.State;
                //Phone.Text = currentUser.Phone;
                //Email.Text = currentUser.Email;
                Email.Text = Membership.GetUser().Email;
                string ID = Membership.GetUser().ProviderUserKey.ToString();
                //Address.Text = ID;
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection SqlConnection = new SqlConnection(connectionString);
                {
                    //Ok We'll need to see if we have a profile record = if we do we will put in the fields
                    SqlDataAdapter SqlDataAdapter = new SqlDataAdapter();
                    SqlCommand SqlCommand = new SqlCommand();
                    SqlConnection.Open();
                    SqlCommand.CommandText = "select * from UserProfiles where ID='{" + ID + "}'" ;
                    SqlCommand.Connection = SqlConnection;
                    SqlDataReader dr = SqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    var count = new int();
                    count = 0;
                    while (dr.Read())
                    {
                        Name.Text = dr["FullName"].ToString();
                        Address.Text = dr["Address"].ToString();
                        City.Text = dr["City"].ToString();
                        State.Text = dr["State"].ToString();
                        Phone.Text = dr["Phone"].ToString();
                        Email.Text = dr["Email"].ToString();
                        count += 1;
                        break; //only need one record
                    }
                    if (count == 0) {
                        //set defaults to the info we have in the form
                        Name.Text = Membership.GetUser().UserName;
                        Email.Text = Membership.GetUser().Email;
                        //Address.Text = ID; //this is just for fun
                    }
                    SqlConnection.Close();
                }

                //ok see if we already have profile data for this user
                //var string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                //ds = new SqlDataSource(conStr);
                Debug.Write("Data Read");
            }
            else
            {

                //OK we got a post response so we need to update the profile

                string ID = Membership.GetUser().ProviderUserKey.ToString();
                //Address.Text = ID;
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection SqlConnection = new SqlConnection(connectionString);
                {
                    //Ok We'll need to see if we have a profile record = if we do we will put in the fields
                    SqlDataAdapter SqlDataAdapter = new SqlDataAdapter();
                    SqlCommand SqlCommand = new SqlCommand();
                    SqlConnection.Open();
                    SqlCommand.CommandText = "select * from UserProfiles where ID='{" + ID + "}'";
                    SqlCommand.Connection = SqlConnection;
                    SqlDataReader dr = SqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    var count = new int();
                    count = 0;
                    while (dr.Read())
                    {
                        //string column = dr["UserName"].ToString();
                        //string id = Convert.ToString(dr["UserId"]);
                        count += 1;
                    }
                    dr.Close();
                    if (count > 0)
                    {
                        //we have some data - so we need to do an update
                        SqlConnection.Open();
                        SqlCommand.CommandText = "UPDATE UserProfiles SET " +
                            "Address='" + Address.Text +
                            "',FullName='" + Name.Text +
                            "',City='" + City.Text +
                            "',State='" + State.Text +
                            "',Phone='" + Phone.Text +
                            "',Email='" + Email.Text +
                            "' where ID='{" + ID + "}'";
                        SqlCommand.ExecuteNonQuery();
                        SqlConnection.Close();

                    }
                    else
                    {
                        //its a new record so we need to select it
                        SqlConnection.Open();
                        SqlCommand.CommandText = "INSERT INTO UserProfiles(ID, FullName,Address,City,State,Phone,Email) VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7)";

                        SqlCommand.Parameters.AddWithValue("@p1", ID);
                        SqlCommand.Parameters.AddWithValue("@p2", Name.Text);
                        SqlCommand.Parameters.AddWithValue("@p3", Address.Text);
                        SqlCommand.Parameters.AddWithValue("@p4", City.Text);
                        SqlCommand.Parameters.AddWithValue("@p5", State.Text);
                        SqlCommand.Parameters.AddWithValue("@p6", Phone.Text);
                        SqlCommand.Parameters.AddWithValue("@p7", Email.Text);

                        SqlCommand.ExecuteNonQuery();
                        SqlConnection.Close();
                    }

                    //SqlConnection.Close();
 



                        //Name.Text = Membership.GetUser().UserName;
                        //Email.Text = Membership.GetUser().Email;
                        //Address.Text = ID; //this is just for fun
                }
                Response.Redirect("~/Account/Manage.aspx");
                Debug.Write("PostBack");
            }

        }
        protected void UpdateProfile_Click(object sender, EventArgs e)
        {
            /*
            var currentUserId = User.Identity.GetUserId();
            var dbcontext = new ApplicationDbContext();
            var store = new UserStore<ApplicationUser>(dbcontext);
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var manager = new UserManager<ApplicationUser>(store);
            var currentUser = manager.FindById(User.Identity.GetUserId());
            currentUser.SurName = Name.Text;
            currentUser.Address = Address.Text;
            currentUser.City = City.Text;
            currentUser.State = State.Text;
            currentUser.Phone = Phone.Text;
            currentUser.Email = Email.Text;
            var Result = manager.Update(currentUser);
            var Result2 = dbcontext.SaveChanges();
            */
            Debug.Write("Profile Updated\n");
        }
        protected void CancelProfile_Click(object sender, EventArgs e)
        {
            Debug.Write("Profile Edit Cancelled\n");
        }

    }

}