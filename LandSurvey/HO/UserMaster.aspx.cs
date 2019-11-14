using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LandSurvey.DAL;

namespace LandSurvey.HO
{
    public partial class UserMaster : System.Web.UI.Page
    {
        DataSet dsUserDetails = new DataSet();
        dbUser dbUserData = new dbUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dsUserDetails = dbUserData.GetUserDetails();
                if(dsUserDetails.Tables[0].Rows.Count > 0)
                {
                    grdUserDetails.DataSource = dsUserDetails;
                    grdUserDetails.DataBind();
                }

            }

        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HO/addUser");
        }

        //
    }
}