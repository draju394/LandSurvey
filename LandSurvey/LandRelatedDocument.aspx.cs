using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;
using LandSurvey.DAL;
using System.Linq;
using System.Text;
using System.IO;

namespace LandSurvey
{
    public partial class LandRelatedDocument : System.Web.UI.Page
    {
        DataSet dsSummary = new DataSet();
        dbReports dbReportsData = new dbReports();

        DataSet dsVillage = new DataSet();
        DataSet dsVillageDetails = new DataSet();
        DataSet dsHolderName = new DataSet();

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

                    dsHolderName = dbReportsData.getHolderName();

                    if (dsHolderName != null && dsHolderName.Tables[0].Rows.Count > 0)
                    {
                        DataTable dtHolderName = dsHolderName.Tables[0];
                        cmbHolderName.DataSource = dsHolderName.Tables[0].DefaultView;
                        cmbHolderName.DataBind();
                        cmbHolderName.DataTextField = dsHolderName.Tables[0].Columns["holdernamem"].ToString();
                        cmbHolderName.DataValueField = dsHolderName.Tables[0].Columns["holdernamem"].ToString();
                        cmbHolderName.DataBind();
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
                SummaryGridBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void SummaryGridBind()
        {
            divGrid.Visible = true;

            dsVillageDetails = dbReportsData.getVillageDetails(cmbVillage.SelectedValue);

            if (dsVillageDetails != null && dsVillageDetails.Tables[0].Rows.Count > 0)
            {
                lblVillageValue.Text = Convert.ToString(dsVillageDetails.Tables[0].Rows[0]["villagemname"]);
                lblTalukaValue.Text = Convert.ToString(dsVillageDetails.Tables[0].Rows[0]["talukamname"]);
                lblDistrictValue.Text = Convert.ToString(dsVillageDetails.Tables[0].Rows[0]["districtmname"]);
            }

            dsSummary = dbReportsData.getEightaDetails(cmbVillage.SelectedValue, cmbHolderName.SelectedValue);

            if (dsSummary != null && dsSummary.Tables[0].Rows.Count > 0)
            {
                DataTable dtSummary = dsSummary.Tables[0];
                hdnKhataNo.Value = dtSummary.Rows[0]["Khatano"].ToString();
                IEnumerable<DataRow> rows = dtSummary.Rows.Cast<DataRow>().Where(r => r["Khatano"].ToString() == "99999");
                rows.ToList().ForEach(r => r.SetField("Khatano", ""));
                rows.ToList().ForEach(r => r.SetField("holdernamem", ""));
                grdLandRelatedDoc.DataSource = dtSummary;
                grdLandRelatedDoc.DataBind();

                int grdRowCount = grdLandRelatedDoc.Rows.Count;
                int grdColCount = grdLandRelatedDoc.Columns.Count;

                //for (int i = 0; i < grdColCount; i++)
                //grdLandRelatedDoc.Rows[grdRowCount].Cells[i].Font.Bold = true;

                btnExportToDoc.Visible = true;
            }
            else
            {
                grdLandRelatedDoc.DataSource = null;
                grdLandRelatedDoc.DataBind();

                btnExportToDoc.Visible = false;
            }
        }

        protected void btnExportToPdf_Click(object sender, EventArgs e)
        {
            try
            {
                grdLandRelatedDoc.AllowPaging = false;
                grdLandRelatedDoc.DataBind();

                BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\ARIALUNI.TTF", BaseFont.IDENTITY_H, true);

                iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable(grdLandRelatedDoc.Columns.Count);
                int[] widths = new int[grdLandRelatedDoc.Columns.Count];
                for (int x = 0; x < grdLandRelatedDoc.Columns.Count; x++)
                {
                    widths[x] = (int)grdLandRelatedDoc.Columns[x].ItemStyle.Width.Value;
                    string cellText = Server.HtmlDecode(grdLandRelatedDoc.HeaderRow.Cells[x].Text);

                    //Set Font and Font Color
                    iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
                    font.Color = new iTextSharp.text.BaseColor(Color.Black);
                    iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new Phrase(12, cellText, font));

                    //Set Header Row BackGround Color
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(Color.White);


                    table.AddCell(cell);
                }
                table.SetWidths(widths);

                for (int i = 0; i < grdLandRelatedDoc.Rows.Count; i++)
                {
                    if (grdLandRelatedDoc.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        {
                            for (int j = 0; j < grdLandRelatedDoc.Columns.Count; j++)
                            {
                                string cellText = Server.HtmlDecode(grdLandRelatedDoc.Rows[i].Cells[j].Text);

                                //Set Font and Font Color
                                iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
                                font.Color = new iTextSharp.text.BaseColor(Color.Black);
                                iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new Phrase(12, cellText, font));

                                //Set Color of row
                                if (i % 2 == 0)
                                {
                                    //Set Row BackGround Color
                                    cell.BackgroundColor = new iTextSharp.text.BaseColor(Color.White);
                                }

                                table.AddCell(cell);
                            }
                        }
                    }
                }

                //Create the PDF Document
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                pdfDoc.Add(table);
                pdfDoc.Close();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
            catch (Exception)
            {
                throw;
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

            if (grdLandRelatedDoc.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('No data found');", true);
                return;
            }
           

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

        }
        private void DownloadWord(string strBody)
        {
            string fileName = "EightA_"; //docno,surveyno,surveyarea,villagecode
            fileName = fileName + cmbVillage.SelectedValue.ToString() + "_" + hdnKhataNo.Value.ToString();

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
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }


        protected void grdLandRelatedDoc_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                TableHeaderCell cell = new TableHeaderCell();

                string strHead = "गाव : " + lblVillageValue.Text + "तालुका : " + lblTalukaValue.Text + "जिल्हा : " + lblDistrictValue.Text;

                cell.Text = strHead;
                cell.ColumnSpan = 8;
                row.Controls.Add(cell);

                //cell = new TableHeaderCell();
                //cell.ColumnSpan = 2;
                //cell.Text = "Employees";
                //row.Controls.Add(cell);

                row.BackColor = Color.White;
                grdLandRelatedDoc.HeaderRow.Parent.Controls.AddAt(0, row);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}