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
    public partial class EmpRegister : System.Web.UI.Page
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
            byte[] imageData = null;
            //string urole = DropDownList1.SelectedValue;
            if (FileUpload1.HasFile)
            {
                imageData = FileUpload1.FileBytes;
            }
            else 
            {
                Response.Write("<script>alert('Please Upload File!');</script>");
            }
                if (username != "" && email != "" && password != "")
            {
                string urole = "Trainee";
                string q = $"exec NewAccount @username,@email,@pass,@urole,@profilePhoto";

                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@username",username);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@pass", password);
                cmd.Parameters.AddWithValue("@urole", urole);
                cmd.Parameters.AddWithValue("@profilePhoto", imageData);


                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('User created!');</script>");

                string qurey = $"insert into leavetable (ename,cl,pl,sl) values('{email}','{6}','{12}','{6}')";

                SqlCommand cm = new SqlCommand(qurey, conn);
                cm.ExecuteNonQuery();

                SqlCommand cme = new SqlCommand($"insert into empdocuments (ename) values('{email}')", conn);
                cme.ExecuteNonQuery();
            }
            else
            {
                Response.Write("<script>alert('All field are required');</script>");
            }
        }
    }
}