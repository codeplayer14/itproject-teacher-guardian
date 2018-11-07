using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Report : System.Web.UI.Page
{
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        UserAuth.AuthenticateUser("Admin.aspx",true);
            
        if (Request.QueryString["searchParam"] != null)
        {
            string searchParam = Request.QueryString["searchParam"].ToString();

            string searchValue = Request.QueryString["searchValue"].ToString();

            SqlConnection con = new SqlConnection(); ;
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            try
            {

                con.Open();
                System.Diagnostics.Debug.WriteLine("VALUES: " + searchParam + " " + searchValue);
                
                SqlDataAdapter sda = new SqlDataAdapter("Select * from Guardian g  inner join student s on g.studentid = s.id",con);
                
                ds = new DataSet();
                sda.Fill(ds,"details");
                ds.Tables[0].DefaultView.RowFilter = searchParam +"='"+ searchValue+"'";
                gv.DataSourceID = null;
                gv.DataSource = ds.Tables[0].DefaultView;
                gv.DataBind();
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                con.Close();

            }
        }
    }

    protected void search_Click(object sender, EventArgs e)
    {
        string queryString = "searchParam=" +Server.UrlEncode(Category.SelectedValue) + " &searchValue=" + Server.UrlEncode(categoryValue.Text);
        Response.Redirect("Report.aspx?"+queryString);
    }

    protected void showAll_Click(object sender, EventArgs e)
    {
        Response.Redirect("Report.aspx");
    }
}