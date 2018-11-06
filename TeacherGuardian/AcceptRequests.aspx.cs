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

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        gridview1.SelectedRow.BackColor = System.Drawing.Color.Blue;
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
            string FacName = row.Cells[4].Text;
            string FacId = row.Cells[5].Text;
            string StudName = row.Cells[2].Text;
            string StudId = row.Cells[3].Text;
            try
            {
                con.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=TGdatabase;Integrated Security=True";
                con.Open();
                SqlCommand com = new SqlCommand("DELETE FROM Request WHERE RequestId=@reqid", con);
                com.Parameters.AddWithValue("reqid", ReqId);
                com.ExecuteNonQuery();
                SqlCommand cmd = new SqlCommand("UPDATE Student SET FacultyId=@facid, HasGuardian=\'True\' WHERE Id=@studid", con);
                cmd.Parameters.AddWithValue("facid", FacId);
                cmd.Parameters.AddWithValue("studid", StudId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Label1.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
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
                con.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=TGdatabase;Integrated Security=True";
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