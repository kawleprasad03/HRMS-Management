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
    public partial class TrainerTicketRaise : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {

            }
        }

        protected void ddlRole_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string role = ddlRole.SelectedValue;
            string query = "SELECT email FROM users WHERE urole = @Role";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Role", role);

            SqlDataReader reader = cmd.ExecuteReader();
            ddlRaiseto.Items.Clear();

            while (reader.Read())
            {
                ddlRaiseto.Items.Add(new ListItem(reader["email"].ToString()));
            }
        }

        protected void btnRaiseTicket_Click(object sender, EventArgs e)
        {
            string femail = Session["email"].ToString();
            string raiseto = ddlRaiseto.SelectedValue;
            string ticketmessage = txtTicket.Text;
            byte[] Filedata = null;
            string FileName = null;
            if (fileUploadAttachment.HasFile)
            {
                Filedata = fileUploadAttachment.FileBytes;
                FileName = fileUploadAttachment.FileName;
           
                DateTime currentdate = DateTime.Now;

                string query = "insert into ticketrasie (fromemail,raiseto,ticketmessage,attachmentname,attachment,dateofraise,status) values(@fromemail,@raiseto,@ticketmessage,@attachmentname,@attachment,@dateofraise,@status)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fromemail", femail);
                cmd.Parameters.AddWithValue("@raiseto", raiseto);
                cmd.Parameters.AddWithValue("@ticketmessage", ticketmessage);
                cmd.Parameters.AddWithValue("@attachmentname", FileName);
                cmd.Parameters.AddWithValue("@attachment", Filedata);
                cmd.Parameters.AddWithValue("@dateofraise", currentdate);
                cmd.Parameters.AddWithValue("@status", "pending");
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Ticket Raise Successfully!')</script>");
            }
            else
            {
                Response.Write("<script>alert('Please Upload File!');</script>");
            }

        }
    }
}