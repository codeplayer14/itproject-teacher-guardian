using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submitRequest_Click(object sender, EventArgs e)
    {
        string facultyId = Session["userId"].ToString();
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

    }
}