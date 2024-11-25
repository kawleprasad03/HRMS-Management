//using iTextSharp.text.pdf;
//using iTextSharp.text;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace secondwebapplication
{
    public partial class ResignationPage : System.Web.UI.Page
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
            string name = TextBox1.Text;
            string designation = TextBox2.Text;
            string reason = TextBox3.Text;
            string dateOfLeaving = TextBox4.Text;

            string email = Session["email"].ToString();

            // Create resignation letter content
            string resignationLetter = $@"
        Masstech Solution
        

        To Whom It May Concern,

        I, {name}, holding the position of {designation}, am writing to formally resign from my position at  Masstech Solution. 
        My last working day will be {dateOfLeaving}. 

        Reason for leaving: {reason}

        I would like to take this opportunity to express my gratitude for the opportunities I have received during my time at [Your Company Name]. 
        I appreciate the support and guidance provided to me during my tenure.

        Thank you for everything.

        Sincerely,
        {name}
    ";


            string pdfPath = GeneratePdf(resignationLetter, name);

            
            SendEmail(name, pdfPath, email);

            
            StoreResignationDetails(name, designation, reason, dateOfLeaving, pdfPath, email);

            Response.Write("<script>alert('Resignation letter has been sent');</script>");
        }


        private string GeneratePdf(string content, string name)
        {
            
            string saveDirectory = Server.MapPath("~/GeneratedPDFforResignation/");

            
            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }

            
            string uniqueFileName = $"{name}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            string pdfPath = Path.Combine(saveDirectory, uniqueFileName);

            
            using (FileStream fs = new FileStream(pdfPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (PdfWriter writer = new PdfWriter(fs))
                {
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        Document document = new Document(pdf);
                        document.Add(new Paragraph(content));
                    }
                }
            }

            return pdfPath; 
        }

        private void SendEmail(string recipientName, string pdfPath,string email)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("kawleprasad03@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Resignation Letter from " + recipientName;

                
                mail.Attachments.Add(new Attachment(pdfPath));

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("kawleprasad03@gmail.com", "fzdo rrmf uhce iptx");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }

        private void StoreResignationDetails(string name, string designation, string reason, string dateOfLeaving, string pdfPath, string email)
        {
            byte[] pdfData = File.ReadAllBytes(pdfPath); 

            string query = "insert into resignation values (@Name, @Email, @Designation, @Reason, @DateOfLeaving, @PdfFile, @Status)";

          
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Designation", designation);
                cmd.Parameters.AddWithValue("@Reason", reason);
                cmd.Parameters.AddWithValue("@DateOfLeaving", dateOfLeaving);
                cmd.Parameters.AddWithValue("@PdfFile", pdfData);
                cmd.Parameters.AddWithValue("@Status", "pending");

                    
                cmd.ExecuteNonQuery();
                   
            }
            
        }

    }
}

