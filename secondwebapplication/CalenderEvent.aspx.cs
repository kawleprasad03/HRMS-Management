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
    public partial class CaldenderEvent : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string date, type, name;
            date = TextBox2.Text;
            type = DropDownList1.SelectedValue;
            name = TextBox3.Text;

            string q = " exec calevent '" + date + "','" + type + "','" + name + "'";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();

            Response.Write("<script> alert('Calender Event Created!');</script>");

        }


    }
}