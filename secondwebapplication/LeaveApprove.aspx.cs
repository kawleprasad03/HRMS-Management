using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace secondwebapplication
{
    public partial class LeaveApprove : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            string q = "SELECT lt.ename, lt.fromdate, lt.todate, lt.ltype, lt.reason, lt.status,lb.cl, lb.pl, lb.sl, lt.totalnumday FROM leavetrack lt JOIN leavetable lb ON lt.ename = lb.ename WHERE lt.status = 'pending';";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Approved")
            {

                int rowIndex = Convert.ToInt32(e.CommandArgument);


                GridViewRow row = GridView1.Rows[rowIndex];


                string ename = row.Cells[0].Text;
                string fromdate = row.Cells[1].Text;
                string todate = row.Cells[2].Text;
                string leaveType = row.Cells[3].Text;
                string reason = row.Cells[4].Text;
                string q = $"update leavetrack set status='Approved' where ename='{ename}'";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("kawleprasad03@gmail.com");
                mail.To.Add(ename);
                mail.Subject = "Leave Application";
                mail.Body = $"Your leave from {fromdate} to {todate} has been Approved!";
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("kawleprasad03@gmail.com", "fzdo rrmf uhce iptx");
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);
                Response.Write("<script>alert('Leave Accepted!');window.location.href='LeaveApprove.aspx';</script>");
            }
            else if (e.CommandName == "Rejected")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);


                GridViewRow row = GridView1.Rows[rowIndex];


                string ename = row.Cells[0].Text;
                string fromdate = row.Cells[1].Text;
                string todate = row.Cells[2].Text;
                string leaveType = row.Cells[3].Text;
                string reason = row.Cells[4].Text;
                string cl = row.Cells[5].Text;
                string pl = row.Cells[6].Text;
                string sl = row.Cells[7].Text;
                string totalnumday = row.Cells[8].Text;


                if (leaveType.Equals("CL"))
                {

                    int adddays = int.Parse(cl) + int.Parse(totalnumday);
                    SqlCommand cd = new SqlCommand($"update leavetable set cl='{adddays}'", conn);
                    cd.ExecuteNonQuery();
                }
                if (leaveType.Equals("PL"))
                {
                    int adddays = int.Parse(totalnumday) + int.Parse(pl);
                    SqlCommand cd = new SqlCommand($"update leavetable set pl='{adddays}'", conn);
                    cd.ExecuteNonQuery();
                }
                if (leaveType.Equals("SL"))
                {
                    int adddays = int.Parse(totalnumday) - int.Parse(sl);
                    SqlCommand cd = new SqlCommand($"update leavetable set sl='{adddays}'", conn);
                    cd.ExecuteNonQuery();
                }
                string q = $"update leavetrack set status='Rejected' where ename='{ename}' and fromdate='{fromdate}' and todate='{todate}'";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("kawleprasad03@gmail.com");
                mail.To.Add(ename);
                mail.Subject = "Leave Application";
                mail.Body = $"Your leave request has been rejected!";
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("kawleprasad03@gmail.com", "fzdo rrmf uhce iptx");
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);
                Response.Write("<script>alert('Leave Rejected!');window.location.href='LeaveApprove.aspx';</script>");
            }
        }
    }
}