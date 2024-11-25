using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace secondwebapplication
{
    public partial class TaskAssign : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                BindCheckBoxList();
            }
        }

        private void BindCheckBoxList()
        {
            

            
            string query = "SELECT email FROM users where urole='Trainee'";

            

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            
            CheckBoxList1.DataSource = reader;
            CheckBoxList1.DataTextField = "email";   
            CheckBoxList1.DataValueField = "email";    
            CheckBoxList1.DataBind();

            CheckBoxList1.Items.Insert(0, new ListItem("Select All", "SelectAll"));

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string taskname = TextBox1.Text;
            byte[] attachment = null;
            string assigndate = DateTime.Now.ToString("dd-MM-yyyy");
            if (FileUpload1.HasFile)
            {
                attachment = FileUpload1.FileBytes;

            

                List<string> emails = new List<string>();
                foreach (ListItem item in CheckBoxList1.Items)
                {
                    if (item.Selected)  
                    {
                        emails.Add(item.Value);  
                    }
                }

                if (emails.Count > 0)
                {
                    foreach (var email in emails)
                    {
                        string q = "insert into taskassign (email,taskname,attachment,assigndate,status) values(@email,@taskname,@attachment,@assigndate,@status)";
                        using (SqlCommand cmd = new SqlCommand(q, conn))
                        {
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.Parameters.AddWithValue("@taskname", taskname);
                            cmd.Parameters.AddWithValue("@attachment", attachment);
                            cmd.Parameters.AddWithValue("@assigndate", assigndate);
                            cmd.Parameters.AddWithValue("@status", "incomplete");
                            cmd.ExecuteNonQuery();

                        }
                    }

                }
                Response.Write("<script>alert('Task Assign Successfully!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Please Upload File!');</script>");
            }

        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckBoxList1.Items[0].Selected)
            {
                foreach (ListItem item in CheckBoxList1.Items)
                {
                    item.Selected = true;
                }
            }
        }
    }
}