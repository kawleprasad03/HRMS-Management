using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace secondwebapplication
{
    public partial class Register : System.Web.UI.Page
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
            string username = TextBox1.Text;
            string email = TextBox2.Text;
            string password = TextBox3.Text;
            string urole = "User";
            string q = $"exec NewAccount '{username}','{email}','{password}','{urole}'";

            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('User created');window.location.href='Login.aspx';</script>");

            string qurey = $"insert into leavetable (ename,cl,pl,sl) values('{email}','{6}','{12}','{6}')";

            SqlCommand cm = new SqlCommand(qurey, conn);
            cm.ExecuteNonQuery();

            SqlCommand cme = new SqlCommand($"insert into empdocuments (ename) values('{email}')", conn);
            cme.ExecuteNonQuery();

        }
    }
}