using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace secondwebapplication
{
    public partial class AddDocument : System.Web.UI.Page
    {
        private SqlConnection conn;

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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = Session["email"].ToString(); // Retrieve employee email from session
            string selectedFileType = DropDownList1.SelectedValue;

            if (FileUpload1.HasFile)
            {
                string fileName = FileUpload1.FileName;
                byte[] fileData = FileUpload1.FileBytes;
                string fileExtension = System.IO.Path.GetExtension(fileName).ToLower();

                // Prepare SQL query based on selected document type
                string query = string.Empty;

                switch (selectedFileType)
                {
                    case "Aadhar Card":
                        query = "UPDATE empdocuments SET AadharCard = @FileData, AadharCardName = @FileName WHERE ename = @Ename";
                        fileName = "AadharCard" + fileExtension;
                        break;
                    case "Pan Card":
                        query = "UPDATE empdocuments SET PanCard = @FileData, PanCardName = @FileName WHERE ename = @Ename";
                        fileName = "PanCard" + fileExtension;
                        break;
                    case "SSC Result":
                        query = "UPDATE empdocuments SET SSCResult = @FileData, SSCResultName = @FileName WHERE ename = @Ename";
                        fileName = "SSCResult" + fileExtension;
                        break;
                    case "HSC Result":
                        query = "UPDATE empdocuments SET HSCResult = @FileData, HSCResultName = @FileName WHERE ename = @Ename";
                        fileName = "HSCResult" + fileExtension;
                        break;
                    default:
                        Response.Write("<script>alert('Please select a valid document type.');</script>");
                        return;
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FileData", fileData);
                    cmd.Parameters.AddWithValue("@FileName", fileName);
                    cmd.Parameters.AddWithValue("@Ename", email);

                    
                    cmd.ExecuteNonQuery();
                    
                }

                // Reload and bind files to GridView
                BindGridView();
                Response.Write("<script>alert('Data uploaded !');</script>");
            }
            else
            {
                Response.Write("<script>alert('Please select a file to upload!');</script>");
            }
        }

        private void BindGridView()
        {
            string email = Session["email"].ToString();
            string query = "SELECT AadharCardName AS FileName, AadharCard AS FileData FROM empdocuments WHERE ename = @Ename " +
               "UNION SELECT PanCardName, PanCard FROM empdocuments WHERE ename = @Ename " +
               "UNION SELECT SSCResultName, SSCResult FROM empdocuments WHERE ename = @Ename " +
               "UNION SELECT HSCResultName, HSCResult FROM empdocuments WHERE ename = @Ename";


            List<FileDocument> documents = new List<FileDocument>();

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Ename", email);
                
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(0) && !reader.IsDBNull(1)) // Ensure data exists
                    {
                        documents.Add(new FileDocument
                        {
                            FileName = reader["FileName"].ToString(),
                            FileData = (byte[])reader["FileData"]
                        });
                    }
                }
               
            }

            GridViewFiles.DataSource = documents;
            GridViewFiles.DataBind();
        }

        protected void GridViewFiles_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Download" || e.CommandName == "View")
            {
                string fileName = e.CommandArgument.ToString(); // Get the file name from CommandArgument
                byte[] fileData = null;

                string fileExtension = System.IO.Path.GetExtension(fileName).ToLower();

                // Set content type based on file extension
                string contentType = string.Empty;
                switch (fileExtension)
                {
                    case ".pdf":
                        contentType = "application/pdf";
                        break;
                    case ".png":
                        contentType = "image/png";
                        break;
                    case ".jpg":
                        contentType = "image/jpg";
                        break;
                    case ".jpeg":
                        contentType = "image/jpeg";
                        break;
                    default:
                        contentType = "application/octet-stream"; // Default binary content type
                        break;
                }

                // Find the file data based on file name
                string email = Session["email"].ToString();
                
                string query = "SELECT AadharCard AS FileData FROM empdocuments WHERE AadharCardName = @FileName AND ename = @Ename " +
               "UNION SELECT PanCard FROM empdocuments WHERE PanCardName = @FileName AND ename = @Ename " +
               "UNION SELECT SSCResult FROM empdocuments WHERE SSCResultName = @FileName AND ename = @Ename " +
               "UNION SELECT HSCResult FROM empdocuments WHERE HSCResultName = @FileName AND ename = @Ename";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FileName", fileName);
                    cmd.Parameters.AddWithValue("@Ename", email);
                    
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(0)) // Ensure data exists
                        {
                            fileData = (byte[])reader["FileData"];
                        }
                    }
                    
                }


                if (fileData != null)
                {
                    Response.Clear();
                    if (e.CommandName == "Download")
                    {
                        // Adjust based on file type
                        Response.ContentType = contentType;
                        Response.AddHeader("Content-Disposition", $"attachment; filename={fileName}");
                        Response.OutputStream.Write(fileData, 0, fileData.Length);
                    }
                    else if (e.CommandName == "View")
                    {
                        // Adjust based on file type
                        Response.ContentType = contentType;
                        Response.AddHeader("Content-Disposition", $"inline; filename={fileName}");
                        Response.OutputStream.Write(fileData, 0, fileData.Length);
                    }
                    Response.Flush();
                    Response.End();
                }
            }

        }

        private class FileDocument
        {
            public string FileName { get; set; }
            public byte[] FileData { get; set; }
        }

        
    }
}

