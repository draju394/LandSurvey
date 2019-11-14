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

namespace LandSurvey.Reports
{
    public partial class RptVillageMaster : System.Web.UI.Page
    {
        DataSet dsAllVillageDetails = new DataSet();
        dbVillage dbVillageAllData = new dbVillage();

        protected void Page_Load(object sender, EventArgs e)
        {
            AllVillageGridBind();
        }

        protected void AllVillageGridBind()
        {
            dsAllVillageDetails = dbVillageAllData.getAllVillageData();
            if (dsAllVillageDetails.Tables[0].Rows.Count > 0)
            {
                DataTable FamilyDetails = dsAllVillageDetails.Tables[0];
                grdVillageM.DataSource = FamilyDetails;
                grdVillageM.DataBind();

            }
        }

        protected void grdVillageM_ServerPdfExporting(object sender, GridEventArgs e)
        {
            PdfExport exp = new PdfExport();
            DataTable VillageDetails = dsAllVillageDetails.Tables[0];
            //List<DataRow> list = FamilyDetails.AsEnumerable().ToList();
            List<DataRow> listVillage = new List<DataRow>(VillageDetails.Select());

            //PdfDocument pdfDocument = exp.Export(grdVillageM.Model, (IEnumerable)listVillage, "AllVillageDetails.pdf", true, true, "flat-lime", true);
            exp.Export(grdVillageM.Model, (IEnumerable)listVillage, "AllVillageDetails.pdf", false, false, true, "flat-saffron");
            //exp.Export(obj, DataSource, "Export.pdf", false, false, true, "flat-saffron");
        }
        //
    }
}