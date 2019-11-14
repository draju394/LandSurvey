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
    public partial class HTMLMutationFinal : System.Web.UI.Page
    {
        DataSet dsMutationFinal = new DataSet();
        dbMutationFinal objMutationFinal = new dbMutationFinal();
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
            Response.Redirect("~/Masters/frmMutationFinal.aspx", false);
        }

        protected void dpVillageName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string villagecode = Convert.ToString(dpVillageName.SelectedIndex);
                dsMutationFinal = objMutationFinal.GetReportDataForVillageCode(villagecode);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}