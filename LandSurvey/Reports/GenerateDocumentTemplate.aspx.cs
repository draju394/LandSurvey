using LandSurvey.DAL;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;

namespace LandSurvey.Reports
{
    public partial class GenerateDocumentTemplate : System.Web.UI.Page
    {
        DataSet dsFamilyInfo = new DataSet();
        DataSet dsPaymentInfo = new DataSet();
        dbReports dbReportsData = new dbReports();

        DataSet dsVillage = new DataSet();
        DataSet dsVillageDetails = new DataSet();
        DataSet dsDocNo = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    dsVillage = dbReportsData.getVillages();

                    if (dsVillage != null && dsVillage.Tables[0].Rows.Count > 0)
                    {
                        DataTable dtVillage = dsVillage.Tables[0];
                        cmbVillage.DataSource = dsVillage.Tables[0].DefaultView;
                        cmbVillage.DataBind();
                        cmbVillage.DataTextField = dsVillage.Tables[0].Columns["villagemname"].ToString();
                        cmbVillage.DataValueField = dsVillage.Tables[0].Columns["villagecode"].ToString();
                        cmbVillage.DataBind();
                    }

                    dsDocNo = dbReportsData.getDocumentNos();

                    if (dsDocNo != null && dsDocNo.Tables[0].Rows.Count > 0)
                    {
                        DataTable dtDocNo = dsDocNo.Tables[0];
                        cmbDocNo.DataSource = dsDocNo.Tables[0].DefaultView;
                        cmbDocNo.DataBind();
                        cmbDocNo.DataTextField = dsDocNo.Tables[0].Columns["docno"].ToString();
                        cmbDocNo.DataValueField = dsDocNo.Tables[0].Columns["docno"].ToString();
                        cmbDocNo.DataBind();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                int result = SummaryGridBind();

                if (result > 0)
                {
                    //string fileName = "DocInfo_" + cmbVillage.SelectedValue.ToString() + "_" + cmbDocNo.SelectedValue.ToString() + ".doc";
                    //Response.Clear();

                    //Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
                    //Response.Charset = "";
                    //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    //Response.ContentType = "application/doc";
                    //System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                    //System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                    //divGrid.RenderControl(htmlWrite);
                    //Response.Write(stringWrite.ToString());
                    //Response.End();

                    var strBody = new StringBuilder();

                    StringWriter sw = new StringWriter();
                    HtmlTextWriter h = new HtmlTextWriter(sw);
                    divGrid.RenderControl(h);
                    string str = sw.GetStringBuilder().ToString();

                    string yourHtmlContent = str.Replace("width: 500px;", "").Replace("width:988px", "").Replace("class=\"auto - style4\"", "").Replace("class=\"table table-striped table-bordered table-condensed\"", "Font-Names=\"Arial Unicode MS\"");

                    //-- add required formatting to html
                    AddFormatting(strBody, yourHtmlContent);

                    //-- download file.. of you can write code to save word in any application folder
                    DownloadWord(strBody.ToString());

                    divGrid.Visible = false;
                }
                else
                {
                    divGrid.Visible = false;
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('No data found');", true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected int SummaryGridBind()
        {
            int result = 0;
            divGrid.Visible = true;

            dsVillageDetails = dbReportsData.getVillageDetails(cmbVillage.SelectedValue);

            if (dsVillageDetails != null && dsVillageDetails.Tables[0].Rows.Count > 0)
            {
                lblVillageValue.Text = Convert.ToString(dsVillageDetails.Tables[0].Rows[0]["villagemname"]);
                lblTalukaValue.Text = Convert.ToString(dsVillageDetails.Tables[0].Rows[0]["talukamname"]);
                lblDistrictValue.Text = Convert.ToString(dsVillageDetails.Tables[0].Rows[0]["districtmname"]);
            }

            dsFamilyInfo = dbReportsData.getFamilyDetails(cmbVillage.SelectedValue, cmbDocNo.SelectedValue);

            if (dsFamilyInfo != null && dsFamilyInfo.Tables[0].Rows.Count > 0)
            {
                result = 1;
                DataTable dtSummary = dsFamilyInfo.Tables[0];
                lblDocNoValue.Text = cmbDocNo.SelectedValue;
                lblFamilyNoValue.Text = Convert.ToString(dtSummary.Rows[0]["familyno"]);
                grdFamilyInfo.DataSource = dtSummary;
                grdFamilyInfo.DataBind();
            }
            else
            {
                result = 0;
                grdFamilyInfo.DataSource = null;
                grdFamilyInfo.DataBind();
            }

            dsPaymentInfo = dbReportsData.getPaymentInfo(cmbVillage.SelectedValue, cmbDocNo.SelectedValue);

            if (dsPaymentInfo != null && dsPaymentInfo.Tables[0].Rows.Count > 0)
            {
                result = 1;
                DataTable dtSummary1 = dsPaymentInfo.Tables[0];
                grdPaymentInfo.DataSource = dtSummary1;
                grdPaymentInfo.DataBind();
            }
            else
            {
                result = 0;
                grdPaymentInfo.DataSource = null;
                grdPaymentInfo.DataBind();
            }

            return result;
        }


        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        private void DownloadWord(string strBody)
        {
            string fileName = "DocInfo_" + cmbVillage.SelectedValue.ToString() + "_" + cmbDocNo.SelectedValue.ToString();

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.ContentType = "application/msword";
            string strFileName = fileName + ".doc";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName);

            HttpContext.Current.Response.Write(strBody);
            HttpContext.Current.Response.End();
            HttpContext.Current.Response.Flush();
        }


        private void AddFormatting(StringBuilder strBody, string yourHtmlContent)
        {
            strBody.Append("<html " +
                "xmlns:o='urn:schemas-microsoft-com:office:office' " +
                "xmlns:w='urn:schemas-microsoft-com:office:word'" +
                "xmlns='http://www.w3.org/TR/REC-html40'>" +
                "<head><title>Time</title>");

            //The setting specifies document's view after it is downloaded as Print
            //instead of the default Web Layout
            strBody.Append("<!--[if gte mso 9]>" +
                "<xml>" +
                "<w:WordDocument>" +
                "<w:View>Print</w:View>" +
                "<w:Zoom>90</w:Zoom>" +
                "<w:DoNotOptimizeForBrowser/>" +
                "</w:WordDocument>" +
                "</xml>" +
                "<![endif]-->");

            strBody.Append("<style>" +
                "<!-- /* Style Definitions */" +
                "@page Section1" +
                "   {size:8.27in 11.69in; " +
                "   font-size:12.0pt; font-family:Arial Unicode MS; " +
                "   TEXT - JUSTIFY: inter - ideograph; TEXT - ALIGN: justify; class=MsoNormal;" +
                "   margin:1.0in 1.25in 1.0in 1.25in ; " +
                "   mso-header-margin:.5in; " +
                "   mso-footer-margin:.5in; mso-paper-source:0;}" +
                " div.Section1" +
                "   {page:Section1;}" +
                "-->" +
                "</style></head>");

            strBody.Append("<body lang=EN-US style='tab-interval:.5in'>" +
                "<div class=Section1>");
            strBody.Append(yourHtmlContent);
            strBody.Append("</div></body></html>");
        }

    }
}