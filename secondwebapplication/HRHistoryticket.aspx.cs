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
    public partial class HRHistoryticket : System.Web.UI.Page
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


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string selectedOption = DropDownList1.SelectedValue;

           
            BindTicketHistoryGridView(selectedOption);
        }

        private void BindTicketHistoryGridView(string period)
        {
            string email = Session["email"].ToString();
            string query = "";

            switch (period)
            {
                case "Daily":
                    query = $"SELECT id, raiseto, ticketsolution, dateofraise, status FROM ticketrasie WHERE DATEDIFF(day, dateofraise, GETDATE()) = 0 AND fromemail='{email}'";
                    break;
                case "Weekly":
                    query = $"SELECT id, raiseto, ticketsolution, dateofraise, status FROM ticketrasie WHERE DATEDIFF(week, dateofraise, GETDATE()) = 0 AND fromemail='{email}'";
                    break;
                case "Monthly":
                    query = $"SELECT id, raiseto, ticketsolution, dateofraise, status FROM ticketrasie WHERE DATEDIFF(month, dateofraise, GETDATE()) = 0 AND fromemail='{email}'";
                    break;
                case "Yearly":
                    query = $"SELECT id, raiseto, ticketsolution, dateofraise, status FROM ticketrasie WHERE DATEDIFF(year, dateofraise, GETDATE()) = 0 AND fromemail='{email}'";
                    break;
            }


            using (SqlCommand cmd = new SqlCommand(query, conn))
            {

                SqlDataReader reader = cmd.ExecuteReader();

                // Bind the result to the GridView
                GridView1.DataSource = reader;
                GridView1.DataBind();


            }

        }
    }
}