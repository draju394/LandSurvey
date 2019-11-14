using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LandSurvey.DAL;
using System.Data;
using System.Text;
using System.Globalization;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf.parser;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace LandSurvey.Reports
{
    public partial class HTMLFinalData : System.Web.UI.Page
    {
        DataSet dsFinal = new DataSet();
        dbFinalData objFinal = new dbFinalData();
        dbInwardOutwardReg dbInOutWardReg = new dbInwardOutwardReg();
        dbCommonFunctions objcmnfun = new dbCommonFunctions();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds1 = dbInOutWardReg.GetVillageMaster();
                objcmnfun.Binddropdown(ds1.Tables[0], ref dpVillageName, "villagemname", "villagecode");

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Masters/frmFinalData.aspx", false);
        }

        protected void dpVillageName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string villagecode = Convert.ToString(dpVillageName.SelectedIndex);
                dsFinal = objFinal.GetReportDataForVillageCode(villagecode);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void rdbvillagename_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(rdbvillagename.Text)== "Single Village")
                {
                    lblVillageName.Visible = true;
                    dpVillageName.Visible = true;
                }
                else
                {
                    lblVillageName.Visible = false;
                    dpVillageName.Visible = false;
                    dpVillageName.SelectedIndex = 0;
                    dsFinal = objFinal.GetReportDataForAllVillages();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}