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
    public partial class ViewPayslips : System.Web.UI.Page
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
            string query = $"SELECT ename, month FROM payslips where ename = '{email}'";


            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                GridView1.DataSource = reader;
                GridView1.DataBind();
            }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Download" || e.CommandName == "View")
            {
                // Retrieve the CommandArgument (ename, month)
                string[] args = e.CommandArgument.ToString().Split(',');
                string employeeName = args[0];
                string month = args[1];

                // Get the PDF from the database based on employee name and month
                byte[] fileData = GetPdfData(employeeName, month);

                if (fileData != null)
                {
                    string fileName = $"{employeeName}_{month}.pdf"; // Customize the file name

                    if (e.CommandName == "Download")
                    {
                        // Set the response for downloading the file
                        Response.Clear();
                        Response.ContentType = "application/pdf"; // Adjust content type as necessary
                        Response.AddHeader("Content-Disposition", $"attachment; filename={fileName}");
                        Response.OutputStream.Write(fileData, 0, fileData.Length);
                        Response.Flush();
                        Response.End();
                    }
                    else if (e.CommandName == "View")
                    {
                        // Set the response for viewing the file
                        Response.Clear();
                        Response.ContentType = "application/pdf"; // Adjust content type as necessary
                        Response.AddHeader("Content-Disposition", $"inline; filename={fileName}");
                        Response.OutputStream.Write(fileData, 0, fileData.Length);
                        Response.Flush();
                        Response.End();
                    }
                }
            }

            
           
        }

        private byte[] GetPdfData(string employeeName, string month)
        {
            byte[] pdfData = null;

            string query = "SELECT payslip FROM payslips WHERE ename = @ename AND month = @month";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ename", employeeName);
                cmd.Parameters.AddWithValue("@month", month);
                object result = cmd.ExecuteScalar();
                if (result != null && result is byte[])
                {
                    pdfData = (byte[])result;
                }
                
            }

            // Log for debugging
            if (pdfData == null)
            {
                // Log the error or set a breakpoint here to debug
                System.Diagnostics.Debug.WriteLine("No PDF data found for employee: " + employeeName + ", month: " + month);
            }

            return pdfData;
        }
    }
}