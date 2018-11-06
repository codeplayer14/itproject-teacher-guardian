using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AssignGuardians : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserAuth.AuthenticateUser("Admin.aspx",true);

    }

    protected void AssignGuardian(object sender, EventArgs e)
    {
        string StudId = ListBox2.SelectedItem.Value;
        string FacId = ListBox1.SelectedItem.Value;
        string StudName = ListBox2.SelectedItem.ToString();
        string FacName = ListBox1.SelectedItem.ToString();

        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"data source=(localdb)\mssqllocaldb;initial Catalog=TeacherGuardian;Integrated Security=True;";
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Student SET FacultyId=@facid, HasGuardian=1 WHERE Id=@studid", con);
            cmd.Parameters.AddWithValue("@facid", FacId);
            cmd.Parameters.AddWithValue("@studid", StudId);
            cmd.ExecuteNonQuery();

            SqlCommand com = new SqlCommand("Insert into Guardian  values (@FacultyId,@FacultyName,@StudentId,@StudentName);", con);
            com.Parameters.AddWithValue("@FacultyId", FacId);

            com.Parameters.AddWithValue("@FacultyName", FacName);

            com.Parameters.AddWithValue("@StudentId", StudId);

            com.Parameters.AddWithValue("@StudentName", StudName);
            com.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("ERROR: " + ex);
        }
        finally
        {
            con.Close();
        }
        ListBox1.DataBind();
        ListBox2.DataBind();
    }
}