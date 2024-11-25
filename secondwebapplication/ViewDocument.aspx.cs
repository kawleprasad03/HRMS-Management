using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace secondwebapplication
{
    public partial class ViewDocument : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();

            if (!IsPostBack)
            {
                getdata();
            }

        }

        public void getdata()
        {
            string email = Session["email"].ToString();
            string q = $"exec fetchpro '{email}'";
            //string q = "exec fetchpro  '"+ email+"' ";
            SqlDataAdapter adapter = new SqlDataAdapter(q, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }


  

        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "view" || e.CommandName == "Download")
            {
                string[] args = e.CommandArgument.ToString().Split('|');
                string Documents_Name = args[0];
                string email = args[1];
 
                string query = "SELECT Documents FROM  Documents_generations WHERE Email_id= @Email_id";  
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    //cmd.Parameters.AddWithValue("@Documents_Name", Documents_Name);
                    cmd.Parameters.AddWithValue("@Email_id", email);
                    object reader = cmd.ExecuteScalar();

                    byte[] fileData = (byte[])reader;
                    string contentType = "application/pdf";  

                    if (e.CommandName == "view")
                    {
                        Response.Clear();
                        Response.ContentType = contentType; 
                        Response.AddHeader("Content-Disposition", $"inline; filename={Documents_Name}.pdf");
                        Response.OutputStream.Write(fileData, 0, fileData.Length);
                        Response.Flush();
                        Response.End();
                    }
                    else if (e.CommandName == "Download")
                    {
                        Response.Clear();
                        Response.ContentType = contentType;
                        Response.AddHeader("Content-Disposition", $"attachment; filename={Documents_Name}.pdf"); 
                        Response.BinaryWrite(fileData);
                        Response.Flush();
                        Response.End();
                    }
                        
                }
                

            }
        }

    }
}