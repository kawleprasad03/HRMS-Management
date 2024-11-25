using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace secondwebapplication
{
    public partial class LeaveApprovalCalender : System.Web.UI.Page
    {
        SqlConnection conn;
        private DataTable eventDates;
        private DataTable dateRanges;
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Session["email"].ToString();
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            string hq = "select event_date,event_name from calenderevnet";
            SqlCommand cmd = new SqlCommand(hq, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            eventDates = new DataTable();
            sda.Fill(eventDates);

            string leaveq = $"select fromdate,todate,status from leavetrack where ename='{email}'";
            SqlCommand rangeCmd = new SqlCommand(leaveq, conn);
            SqlDataAdapter rangeSda = new SqlDataAdapter(rangeCmd);
            dateRanges = new DataTable();
            rangeSda.Fill(dateRanges);
        }

        protected void LeaveCalendar_DayRender(object sender, DayRenderEventArgs e)
        {
            foreach (DataRow row in eventDates.Rows)
            {
                DateTime eventDate = Convert.ToDateTime(row["event_date"]);
                string eventName = row["event_name"].ToString();

                if (e.Day.Date == eventDate.Date)
                {
                    e.Cell.BackColor = System.Drawing.Color.Red;  
                    e.Cell.ToolTip = eventName;  
                    e.Cell.Controls.Add(new LiteralControl("<br/>" + eventName)); 
                }
            }

            foreach (DataRow row in dateRanges.Rows)
            {
                DateTime fromDate = Convert.ToDateTime(row["fromdate"]).Date; 
                DateTime toDate = Convert.ToDateTime(row["todate"]).Date;
                string status = row["status"].ToString();

                // Check if the current day is within the range
                if (e.Day.Date >= fromDate && e.Day.Date <= toDate)
                {
                    if (status == "Approved")
                    {
                        e.Cell.BackColor = System.Drawing.Color.Green; 
                        e.Cell.ToolTip = "Date range"; 
                    }
                    if (status == "Rejected")
                    {
                        e.Cell.BackColor = System.Drawing.Color.Yellow;
                        e.Cell.ToolTip = "Date range";
                    }
                    if (status == "Pending")
                    {
                        e.Cell.BackColor = System.Drawing.Color.Gray;
                        e.Cell.ToolTip = "Date range";
                    }
                }
            }
        }
    }
}