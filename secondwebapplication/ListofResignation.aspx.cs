using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

namespace secondwebapplication
{
    public partial class ListofResignation : System.Web.UI.Page
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
            
            string query = "select id, email, designation, attachment from resignation where status = @pending"; 
            
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@pending", "pending");

            SqlDataReader reader = cmd.ExecuteReader();
            GridViewResignations.DataSource = reader;
            GridViewResignations.DataBind();
                
            
        }

        protected void GridViewResignations_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string email = Convert.ToString(e.CommandArgument);

            if (e.CommandName == "Approve")
            {
                UpdateResignationStatus(email, "Approved");
                SendEmail(email, "Your resignation has been approved.");
            }
            else if (e.CommandName == "Reject")
            {
                UpdateResignationStatus(email, "Rejected");
                SendEmail(email, "Your resignation has been rejected.");
            }
            else if (e.CommandName == "Download")
            {
                
                string emailtodownload = e.CommandArgument.ToString();
                DownloadAttachment(emailtodownload);
            }

           
            BindGridView();
        }

        private void UpdateResignationStatus(string email, string status)
        {
            string query = $"update resignation set status = '{status}' where email = '{email}'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();


            //using (SqlCommand cmd = new SqlCommand(query, conn))
            //{ 
            //    cmd.Parameters.AddWithValue("@status", status);
            //    cmd.Parameters.AddWithValue("@email", email);

            //    cmd.ExecuteNonQuery();

            //}
        }

        private void SendEmail(string Email, string body)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("kawleprasad03@gmail.com");
                mail.To.Add(Email);
                mail.Subject = "Resignation Status Update";
                mail.Body = body;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("kawleprasad03@gmail.com", "fzdo rrmf uhce iptx");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }

        private void DownloadAttachment(string emailtodownload)
        {
            byte[] pdfData = null;
            string fileName = string.Empty;

           
            string query = "select attachment, name from resignation WHERE email = @email";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@email", emailtodownload);
                

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        pdfData = (byte[])reader["attachment"];
                        fileName = reader["name"] + "_ResignationLetter.pdf"; 
                    }
                }
            }
            

            if (pdfData != null)
            {
                Response.ContentType = "application/pdf"; 
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.BinaryWrite(pdfData);
                Response.End();
            }
            else
            {
                Response.Write("No attachment found.");
            }

        }
    }
}