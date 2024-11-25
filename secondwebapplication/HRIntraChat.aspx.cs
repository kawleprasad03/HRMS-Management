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
    public partial class HRIntraChat : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                LoadEmployees();
            }
        }

        private void LoadEmployees()
        {
            string email = Session["email"].ToString();
            SqlCommand cmd = new SqlCommand($"Select username,email from users where email != '{email}'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            ddlEmployees.DataSource = reader;
            ddlEmployees.DataTextField = "email";
            ddlEmployees.DataValueField = "email";
            ddlEmployees.DataBind();

        }

        protected void btnLoadChat_Click(object sender, EventArgs e)
        {
            LoadChat();
        }

        private void LoadChat()
        {
            string selectedEmail = ddlEmployees.SelectedValue;
            litChat.Text = GetChatHistory(selectedEmail);
        }

        private string GetChatHistory(string toemail)
        {
            
            string chatHistory = "";
            string fromemail = Session["email"].ToString(); 

            
            SqlCommand cmd = new SqlCommand(
                "SELECT fromemail, message FROM Chat WHERE (toemail = @ToEmail AND fromemail = @FromEmail) OR (toemail = @FromEmail AND fromemail = @ToEmail)", conn);
            cmd.Parameters.AddWithValue("@ToEmail", toemail);
            cmd.Parameters.AddWithValue("@FromEmail", fromemail);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string senderEmail = reader["fromemail"].ToString();
                string message = reader["message"].ToString();

                
                if (senderEmail == fromemail)
                {
                    chatHistory += $"<div style='text-align: right;'>{senderEmail}: {message}</div>";
                }
               
                else
                {
                    chatHistory += $"<div style='text-align: left;'>{senderEmail}: {message}</div>";
                }
                
            }

            reader.Close(); 
            return chatHistory;

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string fromemail = Session["email"].ToString();
            string toemail = ddlEmployees.SelectedValue;
            string message = txtMessage.Text;

            if (message != "")
            {
                SaveChat(fromemail, toemail, message);
                txtMessage.Text = ""; 
                LoadChat(); 

            }
            else
            {
                Response.Write("<script>alert('Please enter Message!')</script>");
            }

        }

        private void SaveChat(string fromemail, string toemail, string message)
        {

           
            SqlCommand cmd = new SqlCommand("insert into Chat (fromemail, toemail, message) values (@SenderEmail, @ReceiverEmail, @Message)", conn);
            cmd.Parameters.AddWithValue("@SenderEmail", fromemail);
            cmd.Parameters.AddWithValue("@ReceiverEmail", toemail);
            cmd.Parameters.AddWithValue("@Message", message);
            cmd.ExecuteNonQuery();

        }

        protected void ddlEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadChat();
        }
    }
}