using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

namespace secondwebapplication
{
    public partial class Offerletter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            string email = TextBox2.Text;
            string doj = TextBox3.Text;
            string designation = TextBox4.Text;

            //string pdfPath = "D:\\task\\pdffile\\offerletter.pdf";

            //using (FileStream fs = new FileStream(pdfPath, FileMode.Create, FileAccess.Write, FileShare.None))
            //{
            //    Document emptyDoc = new Document();
            //    PdfWriter.GetInstance(emptyDoc, fs);

            //    emptyDoc.Open();

            //    // Optionally add a blank page (to avoid "no pages" error)
            //    emptyDoc.NewPage();

            //    emptyDoc.Close(); // Ensure the empty document is saved and the file is overwritten
            //}

            //Document doc = new Document();


            //PdfWriter.GetInstance(doc, new FileStream(pdfPath, FileMode.Create));


            //doc.Open();


            //doc.Add(new Paragraph($"Hello, {name} \n Email: {email} \n Date of Join : {doj} \n designation : {designation}\nWe are pleased to offer you the position of {designation} at Masstech. We were thoroughly impressed by your qualifications, experience, and interview performance, and we believe you will make a valuable addition to our team."));


            ////Font font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.RED);
            ////doc.Add(new Paragraph("This is bold red text.", font));


            //doc.Close();

            string saveDirectory = Server.MapPath("~/GeneratedPDFs/");

            // Ensure directory exists
            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }

            // Create a unique filename using email and current timestamp
            string uniqueFileName = $"{email}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            // Combine the directory path and unique file name
            string pdfPath = Path.Combine(saveDirectory, uniqueFileName);

            // Create and save the PDF
            CreateAndSavePDF(name, email, doj, designation, pdfPath);

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("kawleprasad03@gmail.com");
            mail.To.Add(email);
            mail.Subject = "Offer Letter";
            mail.Body = $"Your offer letter has been generated and is attached for your consideration.";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("kawleprasad03@gmail.com", "fzdo rrmf uhce iptx");
            smtp.EnableSsl = true;
            
            Attachment attachment = new Attachment(pdfPath);
            mail.Attachments.Add(attachment);
            smtp.Send(mail);
            Response.Write("<script>alert('Email sent successfully!')</script>");


        }

        private void CreateAndSavePDF(string name, string email, string doj, string designation, string pdfPath)
        {
            Document doc = new Document();

            // PdfWriter to create a new file at the specified path
            PdfWriter.GetInstance(doc, new FileStream(pdfPath, FileMode.Create));

            doc.Open();

            // Add content to the PDF
            doc.Add(new Paragraph($"Hello, {name} \nEmail: {email} \nDate of Joining: {doj} \nWe are pleased to offer you the position of {designation} at Masstech.\nYour annual cost to company is ₹ 250000.\n Your qualifications, experience, and interview performance greatly impressed us, and we are confident that you will be a valuable addition to our organization."));

            doc.Close();

        }
    }
}