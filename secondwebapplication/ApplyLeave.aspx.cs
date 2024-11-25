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
    public partial class ApplyLeave : System.Web.UI.Page
    {
        //const int cl = 6;
        //const int sl = 6;
        //const int pl = 12;
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string email = Session["email"].ToString();
            string reason = TextBox3.Text;
            string f = fromd.Text;
            string d = tod.Text;
            DateTime fromdate = DateTime.Parse(f);
            DateTime todate = DateTime.Parse(d);
            TimeSpan dateDifference = todate - fromdate;
            int numberOfDays = dateDifference.Days;
            numberOfDays++;
            //Label6.Text = numberOfDays.ToString();
            string leavetype = DropDownList1.SelectedValue;
            SqlCommand cd = new SqlCommand($"select * from leavetable where ename='{email}'",conn);
            SqlDataReader rdr = cd.ExecuteReader();
            rdr.Read();
            string cl = rdr["cl"].ToString();
            string pl = rdr["pl"].ToString();
            string sl = rdr["sl"].ToString();

            if (leavetype.Equals("CL") && numberOfDays <= int.Parse(cl))
            {
                
                int clleave =  int.Parse(cl)  - numberOfDays;
                SqlCommand cm = new SqlCommand($"update leavetable set cl='{clleave}' where ename='{email}'", conn);
                cm.ExecuteNonQuery();
                string q = $"insert into leavetrack values('{email}','{f}','{d}','{leavetype}','{reason}','Pending','{numberOfDays}')";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Leave Applyed Successfully!');</script>");
            }
            else if (leavetype.Equals("SL") && numberOfDays <= int.Parse(sl))
            {
                int slleave = int.Parse(sl) - numberOfDays;
                SqlCommand cm = new SqlCommand($"update leavetable set sl='{slleave}' where ename='{email}'",conn);
                cm.ExecuteNonQuery();
                string q = $"insert into leavetrack values('{email}','{f}','{d}','{leavetype}','{reason}','Pending','{numberOfDays}')";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Leave Applyed Successfully!');</script>");
            }
            else if (leavetype.Equals("PL") && numberOfDays <= int.Parse(pl))
            {
                int plleave = int.Parse(pl) - numberOfDays;
                SqlCommand cm = new SqlCommand($"update leavetable set pl='{plleave}' where ename='{email}'", conn);
                cm.ExecuteNonQuery();
                string q = $"insert into leavetrack values('{email}','{f}','{d}','{leavetype}','{reason}','Pending', '{numberOfDays}')";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Leave Applyed Successfully!');</script>");  //window.location.href='Login.aspx';
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string email = Session["email"].ToString();
            SqlCommand cm = new SqlCommand($"select * from leavetable where ename='{email}'",conn);
            SqlDataReader rdr = cm.ExecuteReader();
            rdr.Read();
            string bcl = rdr["cl"].ToString();
            string bpl = rdr["pl"].ToString();
            string bsl = rdr["sl"].ToString();
            Label6.Text = $"CL : {bcl}<br/>PL : {bpl}<br/>SL : {bsl}";

        }
    }
}