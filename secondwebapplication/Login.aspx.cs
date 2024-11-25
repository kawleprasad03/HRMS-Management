using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace secondwebapplication
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = TextBox1.Text;
            string pass = TextBox2.Text;

            string q = $"exec Loginproc '{email}','{pass}'";

            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                
                while (rdr.Read())
                {
                    if (rdr["email"].Equals(email) && rdr["pass"].Equals(pass) && rdr["urole"].Equals("Trainee"))
                    {
                        Session["email"] = email;
                        Response.Redirect("UserHome.aspx");
                    }
                    else if(rdr["email"].Equals(email) && rdr["pass"].Equals(pass) && rdr["urole"].Equals("Admin"))
                    {
                        Session["email"] = email;
                        Response.Redirect("AdminHome.aspx");
                    }
                    else if (rdr["email"].Equals(email) && rdr["pass"].Equals(pass) && rdr["urole"].Equals("Trainer"))
                    {
                        Session["email"] = email;
                        Response.Redirect("TrainerHome.aspx");
                    }
                }
                
            }
            else
            {
                Response.Write("<script>alert('Invalid Username and Password');</script>");
            }
        }
    }
}