using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    string facultyId;
    string facultyName;
    protected void Page_Load(object sender, EventArgs e)
    {

        facultyId = Session["userId"].ToString();
         facultyName = Session["userName"].ToString();
        
    }

    protected void submitRequest_Click(object sender, EventArgs e)
    {
        List<String> studentIdList = new List<String>();
        List<String> studentNameList = new List<String>();
        foreach(GridViewRow row in gv.Rows)
        {
            if (((CheckBox)row.FindControl("hasGuardian")).Checked)
            {

              
                studentIdList.Add(row.Cells[0].Text);
                studentNameList.Add(row.Cells[1].Text);
                
            }

        }
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"data source=(localdb)\MSSQLLocalDB;initial catalog=TeacherGuardian";
        string names = "";
        try
        {
            con.Open();

            for(int i = 0; i < studentIdList.Count; i++)
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "Insert into request values (@FacultyId,@FacultyName,@StudentId,@StudentName)";
                com.Parameters.AddWithValue("@FacultyId", facultyId);
                com.Parameters.AddWithValue("@FacultyName", facultyName);
                com.Parameters.AddWithValue("@StudentId", studentIdList.ElementAt(i));
                com.Parameters.AddWithValue("@StudentName", studentNameList.ElementAt(i));
                names += " | " + studentNameList.ElementAt(i)+" | ";
                com.ExecuteNonQuery();

                com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "Update student set hasGuardian=2 where id=@id";
                com.Parameters.AddWithValue("@id", studentIdList.ElementAt(i));
                com.ExecuteNonQuery();
            }

            
            
        }catch(Exception ex)
        {
            System.Diagnostics.Debug.Write(ex);
        }
        finally
        {
            con.Close();
        }
        status.Text = "Request sent for: " + names;
        gv.DataBind();

    }
}