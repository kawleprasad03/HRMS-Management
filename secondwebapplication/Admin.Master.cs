using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace secondwebapplication
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
            Label1.Text = Session["email"].ToString();
        }

        //protected void Logout_Click(object sender, EventArgs e)
        //{
        //    Session.Abandon();
        //    Response.Redirect("Login.aspx");
        //}

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

       
    }
}