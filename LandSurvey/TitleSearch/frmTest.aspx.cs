using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LandSurvey.DAL;
using Syncfusion.EJ.Export;
using Syncfusion.Pdf;
using Syncfusion.JavaScript.Web;
using System.Collections;
using System.Drawing;
using Syncfusion.Pdf.Graphics;
using System.IO;

namespace LandSurvey.TitleSearch
{
    public partial class frmTest : System.Web.UI.Page
    {
        DataSet dsVillage = new DataSet();
        dbVillage dbVillageData = new dbVillage();

        DataSet dsFamilyDocNoNew = new DataSet();
        dbFamilyDetails dbFamilyDetailsData = new dbFamilyDetails();

        DataSet dsShowAllDocData = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            dsShowAllDocData = dbFamilyDetailsData.getSO1LandDocument("40", "17");
            if (dsShowAllDocData.Tables[0].Rows.Count > 0)
            {
                DataTable FamilyDocDetails = dsShowAllDocData.Tables[0];
                Grid1.DataSource = FamilyDocDetails;
                Grid1.DataBind();

            }
            else
            {
                Grid1.DataSource = null;
                Grid1.DataBind();

            }
        }

        protected void Grid1_ServerCommandButtonClick(object sender, Syncfusion.JavaScript.Web.GridEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Document Number ');", true);
        }
    }
}