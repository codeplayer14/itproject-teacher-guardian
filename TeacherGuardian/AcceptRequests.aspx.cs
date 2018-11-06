using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AcceptRequests : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserAuth.AuthenticateUser("Admin.aspx",true);

        }

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        gridview1.SelectedRow.BackColor = System.Drawing.Color.LightGreen;
        GridViewRow row = gridview1.SelectedRow;
        if (row == null)
            return;
        string ReqId = row.Cells[0].Text;
        string FacName = row.Cells[3].Text;
        string FacId = row.Cells[4].Text;
        string StudName = row.Cells[1].Text;
        string StudId = row.Cells[2].Text;

    }
        protected void AcceptSelected(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            GridViewRow row = gridview1.SelectedRow;
            if (row == null)
                return;
            string ReqId = row.Cells[1].Text;
            string FacName = row.Cells[3].Text;
            string FacId = row.Cells[2].Text;
            string StudName = row.Cells[5].Text;
            string StudId = row.Cells[4].Text;
            try
            {
            System.Diagnostics.Debug.WriteLine("VALUE: " + FacId + StudId);
                con.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=TeacherGuardian;Integrated Security=True";
                con.Open();
                SqlCommand com = new SqlCommand("DELETE FROM Request WHERE RequestId=@reqid", con);
                com.Parameters.AddWithValue("@reqid", ReqId);
                com.ExecuteNonQuery();

                com = new SqlCommand("UPDATE Student SET FacultyId=@facid, HasGuardian=1 WHERE Id=@studid", con);
                com.Parameters.AddWithValue("@facid", FacId);
                com.Parameters.AddWithValue("@studid", StudId);
                com.ExecuteNonQuery();

            com = new SqlCommand("Insert into Guardian  values (@FacultyId,@FacultyName,@StudentId,@StudentName);",con);
            com.Parameters.AddWithValue("@FacultyId",FacId);

            com.Parameters.AddWithValue("@FacultyName",FacName);

            com.Parameters.AddWithValue("@StudentId",StudId);

            com.Parameters.AddWithValue("@StudentName",StudName);


            com.ExecuteNonQuery();
            
            }
            catch (Exception ex)
            {
            System.Diagnostics.Debug.WriteLine(ex);
                //Label1.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        gridview1.DataBind();
        }

        protected void DeclineSelected(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            GridViewRow row = gridview1.SelectedRow;
            if (row == null)
                return;
            string ReqId = row.Cells[1].Text;
            string FacName = row.Cells[4].Text;
            string FacId = row.Cells[5].Text;
            string StudName = row.Cells[2].Text;
            string StudId = row.Cells[3].Text;
            try
            {
                con.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=TeacherGuardian;Integrated Security=True";
                con.Open();
                SqlCommand com = new SqlCommand("DELETE FROM Request WHERE RequestId=@reqid", con);
                com.Parameters.AddWithValue("reqid", ReqId);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
        }
    }