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
using System.Text;

namespace LandSurvey.Reports
{
    public partial class MutationSearchReport : System.Web.UI.Page
    {
        DataSet dsMutationRegister = new DataSet();
        dbReports dbReportsData = new dbReports();

        DataSet dsVillage = new DataSet();
        DataSet dsSurveyArea = new DataSet();
        DataSet dsMutationDetails = new DataSet();
        DataTable dtSurveyNo = new DataTable();

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
                string docNo = txtDocumentNo.Text;

                if (!string.IsNullOrEmpty(docNo))
                {

                    string villageCode = cmbVillage.SelectedValue;

                    dsSurveyArea = dbReportsData.getSurveyNos(villageCode, docNo);

                    if (dsSurveyArea != null && dsSurveyArea.Tables.Count > 0)
                    {
                        dtSurveyNo = dsSurveyArea.Tables[0];

                        if (dtSurveyNo != null && dtSurveyNo.Rows.Count > 0)
                        {
                            divReport.Visible = true;
                            rptMain.DataSource = dtSurveyNo;
                            rptMain.DataBind();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Survey Nos not found');", true);
                        btnExportToDoc.Visible = false;
                        btnExportToXls.Visible = false;
                        divReport.Visible = false;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Enter Survey Nos');", true);
                    btnExportToDoc.Visible = false;
                    btnExportToXls.Visible = false;
                    divReport.Visible = false;
                }

                //MutationRegisterGridBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void rptMain_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                GridView grdMutationFinal = e.Item.FindControl("grdMutationFinal") as GridView;
                Label lblFromYear = e.Item.FindControl("lblFromYear") as Label;
                Label lblToYear = e.Item.FindControl("lblToYear") as Label;
                Label lblSurveyNo = e.Item.FindControl("lblSurveyNo") as Label;

                string searchType = "Survey";
                //mutationyear,mutationno,mutationid

                dsMutationRegister = dbReportsData.getMutationRegister(searchType, lblSurveyNo.Text);

                if (dsMutationRegister != null && dsMutationRegister.Tables[0].Rows.Count > 0)
                {
                    DataSet dsYear = null;
                    DataTable dtYear = null;

                    DataTable dtMutationRegister = dsMutationRegister.Tables[0];

                    string mutationNo = dtMutationRegister.Rows[0]["mutationno"].ToString();

                    if (!string.IsNullOrEmpty(mutationNo))
                    {

                        dsYear = dbReportsData.getMutationYearDetails(lblSurveyNo.Text, cmbVillage.SelectedValue);
                        if (dsYear != null && dsYear.Tables[0].Rows.Count > 0)
                        {
                            dtYear = dsYear.Tables[0];
                            //lblMutationNo.Text = mutationNo;
                            lblSurveyNo.Text = lblSurveyNo.Text;

                            lblFromYear.Text = dtYear.Rows[0]["frommutationyear"].ToString();
                            lblToYear.Text = dtYear.Rows[0]["tomutationyear"].ToString();
                        }

                        btnExportToDoc.Visible = true;
                        btnExportToXls.Visible = false;

                        grdMutationFinal.DataSource = dtMutationRegister;
                        grdMutationFinal.DataBind();

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('No data found');", true);
                        btnExportToDoc.Visible = false;
                        btnExportToXls.Visible = false;
                        divReport.Visible = false;
                    }
                }
            }
        }

        //protected void MutationRegisterGridBind()
        //{

        //    string searchType = rdbsearchtype.SelectedValue;


        //    dsMutationRegister = dbReportsData.getMutationRegister(searchType, txtMutationSurveyNumber.Text);

        //    if (dsMutationRegister != null && dsMutationRegister.Tables[0].Rows.Count > 0)
        //    {
        //        DataSet dsYear = null;
        //        DataTable dtYear = null;

        //        DataTable dtMutationRegister = dsMutationRegister.Tables[0];

        //        string mutationNo = dtMutationRegister.Rows[0]["mutationno"].ToString();

        //        if (!string.IsNullOrEmpty(mutationNo))
        //        {
        //            dsYear = dbReportsData.getMutationYearDetails(txtMutationSurveyNumber.Text, cmbVillage.SelectedValue);
        //            if (dsYear != null && dsYear.Tables[0].Rows.Count > 0)
        //            {
        //                dtYear = dsYear.Tables[0];
        //                //lblMutationNo.Text = mutationNo;
        //                lblSurveyNo.Text = txtMutationSurveyNumber.Text;

        //                lblFromYear.Text = dtYear.Rows[0]["frommutationyear"].ToString();
        //                lblToYear.Text = dtYear.Rows[0]["tomutationyear"].ToString();
        //            }



        //            ////DataTable dtMutationRegister = new DataTable();

        //            //// Get all DataRows where the name is the name you want.
        //            //IEnumerable<DataRow> rows = dtMutationRegister.Rows.Cast<DataRow>().Where(r => r["srno"].ToString() != "1");
        //            //// Loop through the rows and change the name.
        //            //rows.ToList().ForEach(r => r.SetField("mutationyear", ""));
        //            //rows.ToList().ForEach(r => r.SetField("mutationno", ""));
        //            //rows.ToList().ForEach(r => r.SetField("mutationdetail", ""));
        //            //rows.ToList().ForEach(r => r.SetField("field4", ""));
        //            //rows.ToList().ForEach(r => r.SetField("field5", ""));
        //            //rows.ToList().ForEach(r => r.SetField("field6", ""));

        //            btnExportToDoc.Visible = true;
        //            btnExportToXls.Visible = false;
        //            divReport.Visible = true;

        //            grdMutationFinal.DataSource = dtMutationRegister;
        //            grdMutationFinal.DataBind();

        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('No data found');", true);
        //            btnExportToDoc.Visible = false;
        //            btnExportToXls.Visible = false;
        //            divReport.Visible = false;
        //        }
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('No data found');", true);
        //        btnExportToDoc.Visible = false;
        //        btnExportToXls.Visible = false;
        //        divReport.Visible = false;


        //    }
        //}


        protected void grdMutationFinal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    GridView grdMutationFinal = (GridView)rptMain.FindControl("grdMutationFinal");

                    DataRowView dr = (DataRowView)e.Row.DataItem;

                    string MutationNo = dr["mutationno"].ToString();
                    string VillageCode = dr["villagecode"].ToString();

                    GridView grdMutationChild = (e.Row.FindControl("grdMutationChild") as GridView);

                    DataSet dsChild = dbReportsData.getMutationRegisterDetails(MutationNo, VillageCode);

                    if (dsChild != null && dsChild.Tables[0].Rows.Count > 0)
                    {

                        DataTable dtChild = dsChild.Tables[0];

                        grdMutationChild.DataSource = dtChild;
                        grdMutationChild.DataBind();
                        grdMutationChild.Rows[0].Cells[0].Font.Bold = true;
                        grdMutationChild.Rows[0].Cells[1].Font.Bold = true;
                        grdMutationChild.Rows[0].Cells[2].Font.Bold = true;
                    }
                    else
                    {
                        grdMutationChild.DataSource = null;
                        grdMutationChild.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void btnExportToDoc_Click(object sender, EventArgs e)
        {
            //Response.Clear();
            //Response.AddHeader("content-disposition", "attachment;filename=FileName.doc");
            //Response.Charset = "";
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.ContentType = "application/doc";
            //System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            //System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            //divReport.RenderControl(htmlWrite);
            //Response.Write(stringWrite.ToString());
            //Response.End();
            //string yourHtmlContent = "<b>Hello!.. </b><i>This is Kaptain! तारीख 05 / 06 / 1931 सदर जमीन गुलाम कादीर हाजी मुल्ला याने बाबन धाकल्या मुरुमकर यांस र. रुपये 225 ला दिनांक 03 / 02 / 193138 / 0 रोजी फरोक्त दिली. (नोंद)</i>";

            var strBody = new StringBuilder();

            StringWriter sw = new StringWriter();
            HtmlTextWriter h = new HtmlTextWriter(sw);
            divReport.RenderControl(h);
            string str = sw.GetStringBuilder().ToString();

            string yourHtmlContent = str.Replace("width: 500px;", "").Replace("width:988px", "").Replace("class=\"auto - style4\"", "").Replace("class=\"table table-striped table-bordered table-condensed\"", "Font-Names=\"Arial Unicode MS\"");

            //-- add required formatting to html
            AddFormatting(strBody, yourHtmlContent);

            //-- download file.. of you can write code to save word in any application folder
            DownloadWord(strBody.ToString());

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        //protected void grdMutationFinal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    grdMutationFinal.PageIndex = e.NewPageIndex;
        //    this.MutationRegisterGridBind();
        //}

        protected void btnExportToXls_Click(object sender, EventArgs e)
        {
            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=MutationRegister.xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //using (StringWriter sw = new StringWriter())
            //{
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);

            //    //To Export all pages
            //    grdMutationFinal.AllowPaging = false;
            //    this.MutationRegisterGridBind();

            //    grdMutationFinal.HeaderRow.BackColor = Color.White;
            //    foreach (TableCell cell in grdMutationFinal.HeaderRow.Cells)
            //    {
            //        cell.BackColor = grdMutationFinal.HeaderStyle.BackColor;
            //    }
            //    foreach (GridViewRow row in grdMutationFinal.Rows)
            //    {
            //        row.BackColor = Color.White;
            //        foreach (TableCell cell in row.Cells)
            //        {
            //            if (row.RowIndex % 2 == 0)
            //            {
            //                cell.BackColor = grdMutationFinal.AlternatingRowStyle.BackColor;
            //            }
            //            else
            //            {
            //                cell.BackColor = grdMutationFinal.RowStyle.BackColor;
            //            }
            //            cell.CssClass = "textmode";
            //        }
            //    }

            //    grdMutationFinal.RenderControl(hw);

            //    //style to format numbers to string
            //    string style = @"<style> .textmode { } </style>";
            //    Response.Write(style);
            //    Response.Output.Write(sw.ToString());
            //    Response.Flush();
            //    Response.End();
            //}
        }

        private void DownloadWord(string strBody)
        {
            string fileName = "MSR_"; //docno,surveyno,surveyarea,villagecode

            if (dtSurveyNo != null && dtSurveyNo.Rows.Count > 0)
            {
                fileName = fileName + dtSurveyNo.Rows[0]["villagecode"].ToString() + "_" + dtSurveyNo.Rows[0]["docno"].ToString();
            }
            else if (cmbVillage.SelectedValue.ToString() != "0" && !string.IsNullOrEmpty(txtDocumentNo.Text))
            {
                fileName = fileName + cmbVillage.SelectedValue.ToString() + "_" + txtDocumentNo.Text.ToString();
            }
            else
            {
                fileName = "MutationSearchReport";
            }

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.ContentType = "application/msword";
          //  HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
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