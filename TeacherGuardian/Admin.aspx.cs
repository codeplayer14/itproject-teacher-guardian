using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            status.Visible = false;

        }

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
            com.CommandText = "Select email,password from admin";

            SqlDataReader reader;
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                string currentEmail = reader["email"].ToString();
                string currentPass = reader["password"].ToString();

                if (currentEmail.Equals(email) && currentPass.Equals(password))
                {
              
                    Response.Redirect("AcceptRequests.aspx");
                }
            }

           
                status.Text = "Invalid credentials";
                status.Visible = true;
           

        }
        finally
        {
            con.Close();
        }


    }
}