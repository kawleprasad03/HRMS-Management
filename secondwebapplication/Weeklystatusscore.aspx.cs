using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace secondwebapplication
{
    public partial class Weeklystatusscore : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                LoadWeeks();
            }
        }

        private void LoadWeeks()
        {
            string query = "select weeknumber from empbestweek group by weeknumber";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DropDownList1.DataSource = reader;
            DropDownList1.DataTextField = "weeknumber";
            DropDownList1.DataValueField = "weeknumber";
            DropDownList1.DataBind();

            DropDownList1.Items.Insert(0, new ListItem("Select Option", "Selected Option"));
            DropDownList1.Items[0].Selected = true;
            DropDownList1.Items[0].Attributes.Add("disabled", "true");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string weekvalue = DropDownList1.SelectedValue;
            string query = "select username,profilephoto,totalscore from empbestweek where weeknumber = @weekvalue";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {

                cmd.Parameters.AddWithValue("@weekvalue", weekvalue);

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);


                if (dt.Rows.Count > 0)
                {

                    DataList1.DataSource = dt;
                    DataList1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('No records found!')</script>");
                    DataList1.DataSource = null;
                    DataList1.DataBind();
                }


            }
        }
    }
}