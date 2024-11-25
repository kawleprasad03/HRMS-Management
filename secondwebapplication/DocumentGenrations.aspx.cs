using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace secondwebapplication
{
    public partial class DocumentGenrations : System.Web.UI.Page
    {
        private SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            if (FileUpload1.HasFile && !string.IsNullOrEmpty(TextBox1.Text) && !string.IsNullOrEmpty(TextBox2.Text))
            {
                try
                {
                    
                    string email = TextBox1.Text;
                    string documentsName = TextBox2.Text;
                    byte[] fileData = FileUpload1.FileBytes;  

                   
                    string query = "exec doc_generationpro @Email_id, @Documents, @Documents_Name";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email_id", email);
                    cmd.Parameters.AddWithValue("@Documents", fileData);
                    cmd.Parameters.AddWithValue("@Documents_Name", documentsName);


                    cmd.ExecuteNonQuery();


                    SendDocumentByEmail(email, documentsName, fileData);
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please fill all fields and upload a document.');</script>");
            }
        }

        private void SendDocumentByEmail(string Email_id, string Documents_Name, byte[] fileData)

        {

            try
            {
                
                MailMessage mailMessage = new MailMessage();

                mailMessage.From = new MailAddress("kawleprasad03@gmail.com");  
                mailMessage.To.Add(new MailAddress(Email_id));  
                mailMessage.Subject = "Your Document";
                mailMessage.Body = "Please find the attached document.";

              
                MemoryStream ms = new MemoryStream(fileData);
                Attachment attachment = new Attachment(ms, Documents_Name); 
               
                mailMessage.Attachments.Add(attachment);

                
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;

                smtpClient.Credentials = new NetworkCredential("kawleprasad03@gmail.com", "fzdo rrmf uhce iptx");  
                smtpClient.EnableSsl = true;  

                
                smtpClient.Send(mailMessage);

               
                Response.Write("<script>alert('Mail sent successfully to " + Email_id + "');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Failed to send email. Error: " + ex.Message + "');</script>");
            }
        }
    }
}