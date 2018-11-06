using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Faculty : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        string email = emailIdBox.Text;
        string password = passwordBox.Text;
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"data source=(localdb)\MSSQLLocalDB;initial catalog=TeacherGuardian";

        try
        {
            con.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "Select email,password from Faculty";

            SqlDataReader reader;
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                string currentEmail = reader["email"].ToString();
                string currentPass = reader["password"].ToString();


                if (currentEmail.Equals(email) && currentPass.Equals(password))
                {
                    Session["userId"] = reader["facultyid"];
                    Session["userName"] = reader["facultyname"];
                    Response.Redirect("Default.aspx");
                }
            }
            

        }
        finally
        {
            con.Close();
        }


     }
}