using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace secondwebapplication
{
    public partial class BestScoreResult : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                //BindDataList();
            }
        }

        //private void BindDataList()
        //{
        //    string query = @"select Top (3) u.username, u.profilephoto, t.score FROM users u JOIN taskassign t ON u.email = t.email WHERE t.score IS NOT NULL ORDER BY CAST(t.score AS INT) DESC;";  //OFFSET 0 ROWS FETCH NEXT 3 ROWS ONLY

        //    using (SqlCommand cmd = new SqlCommand(query, conn))
        //    {
               
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        DataTable dt = new DataTable();
        //        dt.Load(reader);

        //        DataList1.DataSource = dt;
        //        DataList1.DataBind();
        //    }
            
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {

            DateTime fromDate = Convert.ToDateTime(TextBox1.Text).Date;
            DateTime toDate = Convert.ToDateTime(TextBox2.Text).Date;

            
            string formattedFromDate = fromDate.ToString("yyyy-MM-dd");
            string formattedToDate = toDate.ToString("yyyy-MM-dd");


            string query = @"
                    SELECT TOP 3 u.username, u.profilephoto, SUM(CAST(t.score AS INT)) AS total_score
                    FROM taskassign t
                    INNER JOIN users u ON t.email = u.email
                    WHERE TRY_CONVERT(DATE, t.assigndate, 105) >= @fromDate
                    AND TRY_CONVERT(DATE, t.submitdate, 105) <= @toDate 
                    AND t.score IS NOT NULL
                    GROUP BY u.username, u.profilephoto
                    ORDER BY SUM(CAST(t.score AS INT)) DESC";


            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                
                cmd.Parameters.AddWithValue("@fromDate", formattedFromDate);
                cmd.Parameters.AddWithValue("@toDate", formattedToDate);

                
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            DateTime fromDate = Convert.ToDateTime(TextBox1.Text).Date;
            DateTime toDate = Convert.ToDateTime(TextBox2.Text).Date;


            string formattedFromDate = fromDate.ToString("yyyy-MM-dd");
            string formattedToDate = toDate.ToString("yyyy-MM-dd");

            string weekstatus = TextBox3.Text;
            //string query = $@"INSERT INTO empbestweek ('{weekstatus}', username, profilephoto, totalscore)
            //        SELECT TOP 3 u.username, u.profilephoto, SUM(CAST(t.score AS INT)) AS total_score
            //        FROM taskassign t
            //        INNER JOIN users u ON t.email = u.email
            //        WHERE TRY_CONVERT(DATE, t.assigndate, 105) >= @fromDate
            //        AND TRY_CONVERT(DATE, t.submitdate, 105) <= @toDate 
            //        AND t.score IS NOT NULL
            //        GROUP BY u.username, u.profilephoto
            //        ORDER BY SUM(CAST(t.score AS INT)) DESC";

            string query = $@"
    INSERT INTO empbestweek (weeknumber, username, profilephoto, totalscore)
    SELECT 
        '{weekstatus}', 
        u.username,
        u.profilephoto,
        SUM(CAST(t.score AS INT)) AS total_score
    FROM taskassign t
    INNER JOIN users u ON t.email = u.email
    WHERE TRY_CONVERT(DATE, t.assigndate, 105) >= @fromDate
    AND TRY_CONVERT(DATE, t.submitdate, 105) <= @toDate 
    AND t.score IS NOT NULL
    GROUP BY u.username, u.profilephoto
    ORDER BY SUM(CAST(t.score AS INT)) DESC
    OFFSET 0 ROWS FETCH NEXT 3 ROWS ONLY";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@fromDate", formattedFromDate);
            cmd.Parameters.AddWithValue("@toDate", formattedToDate);

            cmd.ExecuteNonQuery();
        }
    }
}