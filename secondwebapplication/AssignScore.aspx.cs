using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace secondwebapplication
{
    public partial class AssignScore : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                
            }
        }

        private void BindGridView(string status)
        {
            string query = $"select email, taskname, solution, score from taskassign where status='{status}'";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                //btnAdd.Enabled = false;
                
            }
            
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                string score = DataBinder.Eval(e.Row.DataItem, "score").ToString();

                
                TextBox txtScore = (TextBox)e.Row.FindControl("txtScore");
                Button btnAdd = (Button)e.Row.FindControl("btnAdd");

                
                if (!string.IsNullOrEmpty(score))
                {
                    txtScore.ReadOnly = true;
                    btnAdd.Enabled = false;  
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                //string taskname = e.CommandArgument.ToString();
                string[] args = e.CommandArgument.ToString().Split('|');
                string taskname = args[0]; 
                string email = args[1];
             
                DownloadFile(taskname,email);
            }
            else if (e.CommandName == "AddScore")
            {
                string[] args = e.CommandArgument.ToString().Split('|');
                string taskname = args[0];
                string email = args[1];
                GridViewRow row = (GridViewRow)((Button)e.CommandSource).NamingContainer;
                TextBox txtScore = (TextBox)row.FindControl("txtScore");
                string score = txtScore.Text;

                
                UpdateScore(taskname, score, email);


                Button btnAdd = (Button)e.CommandSource;
                btnAdd.Enabled = false;
                txtScore.ReadOnly = true;
            }
        }

        private void DownloadFile(string taskname,string email)
        {
            
            string query = "select solution from taskassign where taskname = @TaskName and email=@email";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TaskName", taskname);
                cmd.Parameters.AddWithValue("@email", email);
                
                byte[] fileData = (byte[])cmd.ExecuteScalar();
                string filename = "SolutionFor" + taskname;
                if (fileData != null)
                {
                    Response.Clear();
                    Response.ContentType = "application/pdf";  
                    Response.AddHeader("Content-Disposition", $"attachment; filename={filename}.pdf");
                    Response.BinaryWrite(fileData);
                    Response.Flush();
                    Response.End();
                }
            }
            
        }

        private void UpdateScore(string taskname, string score, string email)
        {
            string query = "update taskassign set score = @Score where taskname = @TaskName and email = @email";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Score", score);
                cmd.Parameters.AddWithValue("@TaskName", taskname);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.ExecuteNonQuery();
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string status = DropDownList1.SelectedValue;
            //string score = txtScore.Text;
            BindGridView(status);
        }
    }
}