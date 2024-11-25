using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace secondwebapplication
{
    public partial class CheckTask : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            string email = Session["email"].ToString();
            string query = $"SELECT email,taskname FROM taskassign where email='{email}' and status='incomplete'";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
            if (e.CommandName == "Upload")
            {
                string taskname = e.CommandArgument.ToString();
                string email = Session["email"].ToString();
                string submitdate = DateTime.Now.ToString("dd-MM-yyyy");
                GridViewRow row = (GridViewRow)((Button)e.CommandSource).NamingContainer; // Get the current row
                FileUpload fileUpload = (FileUpload)row.FindControl("FileUpload1");
                //FileUpload fileUpload = (FileUpload)GridView1.row[e.rowindex].FindControl("FileUpload1");
                // FileUpload fileUpload = GridView1.Rows[e.RowIndex].FindControl("FileUpload1") as FileUpload;
                if (fileUpload.HasFile)
                {
                    byte[] fileData;

                    //using (var binaryReader = new System.IO.BinaryReader(fileUpload.PostedFile.InputStream))
                    //{
                    //    fileData = binaryReader.ReadBytes(fileUpload.PostedFile.ContentLength);
                    //}
                    using (var binaryReader = new System.IO.BinaryReader(fileUpload.PostedFile.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(fileUpload.PostedFile.ContentLength);
                    }

                 
                    string query = "UPDATE taskassign SET solution = @Attachment,status=@status,submitdate=@submitdate WHERE email = @Email AND taskname = @TaskName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Attachment", fileData);
                        cmd.Parameters.AddWithValue("@status", "complete");
                        cmd.Parameters.AddWithValue("@submitdate", submitdate);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@TaskName", taskname);


                        int rowsAffected = cmd.ExecuteNonQuery(); 

                        if (rowsAffected > 0)
                        {
                            Response.Write("<script>alert('Solution uploaded successfully!');window.location.href='CheckTask.aspx'</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('No record was updated. Please check your input.');</script>");
                        }
                    }
                    
                }    
                else
                {
                    Response.Write("<script>alert('Please select a file to upload.');</script>");
                }
            }
            else if (e.CommandName == "Download")
            {
                string taskname = e.CommandArgument.ToString();
                string email = Session["email"].ToString();
                byte[] fileData = null;

                string query = $"SELECT attachment FROM taskassign WHERE email = '{email}' and taskname='{taskname}'";
                SqlCommand cmd = new SqlCommand(query, conn);

                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    fileData = (byte[])result;  
                }

                if (fileData != null)
                {
                   
                    Response.Clear();
                    Response.ContentType = "application/pdf";  
                    string fileName = $"{taskname}.pdf"; 
                    Response.AddHeader("Content-Disposition", $"attachment; filename=\"{fileName}\"");  
                    Response.OutputStream.Write(fileData, 0, fileData.Length);  
                    Response.Flush();
                    Response.End();
                }

                


                
            }
        }
    }
}