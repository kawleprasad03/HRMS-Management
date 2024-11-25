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
    public partial class HRMyticket : System.Web.UI.Page
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
            string query = "SELECT id, raiseto, ticketmessage, attachmentname, dateofraise, status FROM ticketrasie WHERE status = 'Pending' and raiseto=@rasieto";


            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@rasieto", email);


            SqlDataReader reader = cmd.ExecuteReader();

            gvTickets.DataSource = reader;
            gvTickets.DataBind();


        }

        protected void gvTickets_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int ticketId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Download")
            {
                DownloadAttachment(ticketId);
            }
        }

        private void DownloadAttachment(int ticketId)
        {
            string query = "SELECT attachmentname, attachment FROM ticketrasie WHERE id = @TicketId";


            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TicketId", ticketId);


                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string fileName = reader["attachmentname"].ToString();
                    byte[] fileData = (byte[])reader["attachment"];

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

                    Response.Clear();
                    Response.ContentType = contentType;
                    Response.AddHeader("Content-Disposition", $"attachment;filename={fileName}");
                    Response.BinaryWrite(fileData);
                    Response.End();
                }


            }

        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            string ticketid = hfTicketId.Value;
            string solution = TextBox1.Text;
            string query = "UPDATE ticketrasie SET ticketsolution = @Solution, status = @status WHERE id = @TicketId";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Solution", solution);
            cmd.Parameters.AddWithValue("@status", "closed");
            cmd.Parameters.AddWithValue("@TicketId", ticketid);

            cmd.ExecuteNonQuery();

            BindGridView();
            Response.Write("<script>alert('Solution Add Successfully!')</script>");

        }
    }
}