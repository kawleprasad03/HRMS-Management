using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iTextSharp.text.pdf.PdfDocument;
using System.Reflection.Emit;
using System.Collections;
using System.Net.Mail;
using System.Net;

namespace secondwebapplication
{
    public partial class GeneratePayslip : System.Web.UI.Page
    {
        SqlConnection conn;
        Dictionary<string, int> monthdigit = new Dictionary<string, int>() {
            {"Jan", 1 }, {"Feb",2}, {"Mar",3}, {"Apr",4}, {"May",5},{"June",6},{"Jul",7},{"Aug",8},{"Sep",9},{"Oct",10},{"Nov",11},{"Dec",12},
        };
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = TextBox1.Text;
            string month = DropDownList1.SelectedValue;

            //string pdfPath = "D:\\task\\pdffile\\payslip.pdf";

 

            SqlCommand cmd = new SqlCommand($"select * from users where email='{email}'", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            string name = rdr["username"].ToString();

            SqlCommand cd = new SqlCommand($"select fromdate,todate,totalnumday from leavetrack where ename='{email}' and status='Approved'", conn);
            SqlDataReader rd = cd.ExecuteReader();
            int countleave = 0;
            int yearc = 2024;
            if (rd.HasRows) {
                while (rd.Read()) {
                    DateTime givedate = DateTime.Parse(rd["fromdate"].ToString());
                    int monthnumber = givedate.Month;
                    int yearnumber = givedate.Year;
                    if (monthdigit[month] == monthnumber)
                    {
                        if (countleave == 0) {
                            yearc = yearnumber;
                        }
                        countleave += int.Parse(rd["totalnumday"].ToString());
                    }
                }
            }

            SqlCommand cmdb = new SqlCommand($"select cl,pl,sl from leavetable where ename='{email}'", conn);
            SqlDataReader rdb = cmdb.ExecuteReader();
            rdb.Read();
            int cl = int.Parse(rdb["cl"].ToString());
            int pl = int.Parse(rdb["pl"].ToString());
            int sl = int.Parse(rdb["sl"].ToString());
            int totalbalanceleave = cl + pl + sl;
            int dayInmonth = DateTime.DaysInMonth(yearc, monthdigit[month]);
            int presentday = dayInmonth - countleave;
            //Label1.Text = countleave.ToString() + " " + dayInmonth.ToString() + " " + presentday.ToString() + " " + totalbalanceleave.ToString();



            string saveDirectory = Server.MapPath("~/GeneratedPDFs/");

           
            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }

            
            string uniqueFileName = $"{email}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            
            string pdfPath = Path.Combine(saveDirectory, uniqueFileName);

            // Create and save the PDF
            //CreateAndSavePDF(name, email, doj, designation, pdfPath);

            //Document doc = new Document();  
            Document doc = new Document();
            byte[] pdfBytes;

            using (MemoryStream ms = new MemoryStream())
            {


                
                PdfWriter.GetInstance(doc, ms);

                doc.Open();

                
                doc.Add(new Paragraph($"Name : {name}\nEmail ID : {email}\nPresent Days : {presentday}\nAbsent Days : {countleave}\nBalance Leave : {totalbalanceleave}\nNet Salary : 25000"));

                doc.Close();
                pdfBytes = ms.ToArray();
            }

           


            string query = "INSERT INTO payslips (ename, month, payslip) VALUES (@ename, @month, @payslip)";

            using (SqlCommand cmdp = new SqlCommand(query, conn))
            {
                
                cmdp.Parameters.AddWithValue("@ename", email);  
                cmdp.Parameters.AddWithValue("@month", month + yearc.ToString());  
                cmdp.Parameters.AddWithValue("@payslip", pdfBytes);  

                
                cmdp.ExecuteNonQuery();
              
            }

            string Directorysave = Server.MapPath("~/GeneratedPDFsformail/");

            
            if (!Directory.Exists(Directorysave))
            {
                Directory.CreateDirectory(Directorysave);
            }

            
            string FileName = $"{email}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

           
            string pdfPathformail = Path.Combine(Directorysave, FileName);
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream(pdfPathformail, FileMode.Create));

            document.Open();

          
            document.Add(new Paragraph($"Name : {name}\nEmail ID : {email}\nPresent Days : {presentday}\nAbsent Days : {countleave}\nBalance Leave : {totalbalanceleave}\nNet Salary : 25000"));

            document.Close();

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("kawleprasad03@gmail.com");
            mail.To.Add(email);
            mail.Subject = "PalySlip Generated";
            mail.Body = $"Check your payslip for {month} month";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("kawleprasad03@gmail.com", "fzdo rrmf uhce iptx");
            smtp.EnableSsl = true;

            Attachment attachment = new Attachment(pdfPathformail);
            mail.Attachments.Add(attachment);
            smtp.Send(mail);


           

            Response.Write("<script>alert('Payslip generated !')</script>");


        }
    }
}