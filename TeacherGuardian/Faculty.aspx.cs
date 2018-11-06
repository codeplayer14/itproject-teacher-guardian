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
        int flag = 0;
        string email = emailIdBox.Text;
        string password = passwordBox.Text;
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"data source=(localdb)\MSSQLLocalDB;initial catalog=TeacherGuardian";

        try
        {
            con.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "Select email,password,facultyname,facultyid from Faculty";

            SqlDataReader reader;
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                string currentEmail = reader["email"].ToString();
                string currentPass = reader["password"].ToString();
                string facultyName = reader["FacultyName"].ToString();
                string facultyid = reader["facultyid"].ToString();

                if (currentEmail.Equals(email) && currentPass.Equals(password))
                {
                    flag = 1;
                    HttpCookie cookie = new HttpCookie("user");
                    cookie["authenticated"] = true.ToString();
                    Response.Cookies.Add(cookie);
                    Session["userid"] = facultyid;
                    Session["username"] = facultyName;
                    Response.Redirect("ViewAdd.aspx");
                }
            }

            if (flag == 0)
            {

                status.Text = "Invalid credentials";
                status.Visible = true;
            }
            

        }
        finally
        {
            con.Close();
        }


     }
}