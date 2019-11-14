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
    public partial class MutationRegister : System.Web.UI.Page
    {
        DataSet dsMutationRegister = new DataSet();
        dbReports dbReportsData = new dbReports();

        DataSet dsVillage = new DataSet();

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
                MutationRegisterGridBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void MutationRegisterGridBind()
        {

            string searchType = rdbsearchtype.SelectedValue;


            dsMutationRegister = dbReportsData.getMutationRegister(searchType, txtMutationSurveyNumber.Text);

            if (dsMutationRegister != null && dsMutationRegister.Tables[0].Rows.Count > 0)
            {

                DataTable dtMutationRegister = dsMutationRegister.Tables[0];

                ////DataTable dtMutationRegister = new DataTable();

                //// Get all DataRows where the name is the name you want.
                //IEnumerable<DataRow> rows = dtMutationRegister.Rows.Cast<DataRow>().Where(r => r["srno"].ToString() != "1");
                //// Loop through the rows and change the name.
                //rows.ToList().ForEach(r => r.SetField("mutationyear", ""));
                //rows.ToList().ForEach(r => r.SetField("mutationno", ""));
                //rows.ToList().ForEach(r => r.SetField("mutationdetail", ""));
                //rows.ToList().ForEach(r => r.SetField("field4", ""));
                //rows.ToList().ForEach(r => r.SetField("field5", ""));
                //rows.ToList().ForEach(r => r.SetField("field6", ""));

                btnExportToDoc.Visible = true;
                btnExportToXls.Visible = true;

                grdMutationFinal.DataSource = dtMutationRegister;
                grdMutationFinal.DataBind();

                Grid1.DataSource = dtMutationRegister;
                Grid1.DataBind();
            }
        }

        protected void Grid1_ServerPdfExporting(object sender, GridEventArgs e)
        {
            PdfExport exp = new PdfExport();
            MutationRegisterGridBind();
            if (dsMutationRegister.Tables[0].Rows.Count > 0)
            {
                DataTable dtSummary = dsMutationRegister.Tables[0];
                //List<DataRow> list = FamilyDetails.AsEnumerable().ToList();
                List<DataRow> list = new List<DataRow>(dtSummary.Select());

                PdfPageSettings pageSettings = new PdfPageSettings(50f);
                pageSettings.Margins.Left = 15;

                pageSettings.Margins.Right = 15;

                pageSettings.Margins.Top = 10;

                pageSettings.Margins.Bottom = 10;

                PdfDocument pdfDocument = exp.Export(Grid1.Model, (IEnumerable)list, "MutationRegister.pdf", true, true, "flat-lime", true);

                RectangleF rect = new RectangleF(0, 0, pdfDocument.PageSettings.Width, 50);
                RectangleF rect1 = new RectangleF(0, 0, pdfDocument.PageSettings.Width, 50);

                //create a header pager template
                PdfPageTemplateElement header = new PdfPageTemplateElement(rect);
                PdfPageTemplateElement header1 = new PdfPageTemplateElement(rect1);

                //create a footer pager template
                PdfPageTemplateElement footer = new PdfPageTemplateElement(rect);

                Font f = new Font("Arial", 11, FontStyle.Bold);

                PdfFont font = new PdfTrueTypeFont(f, true);

                //header.Graphics.DrawString("Land Aquisition", font, PdfBrushes.Black, new Point(250, 0)); //Add custom text to the Header
                //pdfDocument.Template.Top = header; //Append custom template to the document   

                //header1.Graphics.DrawString("All Family Details", font, PdfBrushes.Black, new Point(0, 3)); //Add custom text to the Header
                //pdfDocument.Template.Top = header1; //Append custom template to the document           
                PdfBrush brush = new PdfSolidBrush(Color.Black);
                //Add the fields in composite fields
                PdfCompositeField compositeField = new PdfCompositeField(font, brush, "Land Aquisition - SEZ Thane");
                PdfCompositeField compositeField1 = new PdfCompositeField(font, brush, "Mutation Register");
                //PdfCompositeField compositeField2 = new PdfCompositeField(font, brush, "Report");
                //PdfCompositeField compositeField3 = new PdfCompositeField(font, brush, "Family Details");
                compositeField.Bounds = header.Bounds;
                //Draw the composite field in footer
                compositeField.Draw(footer.Graphics, new PointF(200, 0));
                compositeField1.Draw(footer.Graphics, new PointF(230, 10));
                //compositeField2.Draw(footer.Graphics, new PointF(205, 20));
                //compositeField3.Draw(footer.Graphics, new PointF(228, 40));
                //Add the footer template at the bottom
                pdfDocument.Template.Top = header;

                footer.Graphics.DrawString("CopyRights", font, PdfBrushes.Gray, new Point(250, 0));//Add Custom text to footer
                pdfDocument.Template.Bottom = footer;//Add the footer template to document

                pdfDocument.Save("MutationRegister.pdf", Response, HttpReadType.Save);

            }
            else
            {

            }

        }

        protected void grdMutationFinal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string MutationNo = grdMutationFinal.DataKeys[e.Row.RowIndex].Values[0].ToString();
                string VillageCode = grdMutationFinal.DataKeys[e.Row.RowIndex].Values[1].ToString();

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


        protected void btnExportToDoc_Click(object sender, EventArgs e)
        {

            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=MutationRegister.doc");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-word";
            //using (StringWriter sw = new StringWriter())
            //{
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);

            //    //Set to False in order to export all Pages.
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
            //            // cell.CssClass = "textmode";
            //        }
            //    }

            //    grdMutationFinal.RenderControl(hw);

            //    //Style to format numbers to String.
            //    string style = @"<style> .textmode { } </style>";
            //    Response.Write(style);
            //    Response.Output.Write(sw.ToString());
            //    Response.Flush();
            //    Response.End();
            //}

            var strBody = new StringBuilder();

            StringWriter sw = new StringWriter();
            HtmlTextWriter h = new HtmlTextWriter(sw);
            grdMutationFinal.AllowPaging = false;
            this.MutationRegisterGridBind();


            grdMutationFinal.RenderControl(h);
            string str = sw.GetStringBuilder().ToString();
            //.Replace("class=\"WordWrap\"", "")
            string yourHtmlContent = str.Replace("style=\"width: 500px; height: 100px; \"", "").Replace("width: 500px;", "").Replace("width:988px", "").Replace("class=\"auto - style4\"", "").Replace("class=\"table table-striped table-bordered table-condensed\"", "");

            //-- add required formatting to html
            AddFormatting(strBody, yourHtmlContent);

            //-- download file.. of you can write code to save word in any application folder
            DownloadWord(strBody.ToString());
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void grdMutationFinal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMutationFinal.PageIndex = e.NewPageIndex;
            this.MutationRegisterGridBind();
        }

        protected void btnExportToXls_Click(object sender, EventArgs e)
        { 
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=MutationRegister.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                grdMutationFinal.AllowPaging = false;
                this.MutationRegisterGridBind();

                grdMutationFinal.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in grdMutationFinal.HeaderRow.Cells)
                {
                    cell.BackColor = grdMutationFinal.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in grdMutationFinal.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grdMutationFinal.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grdMutationFinal.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                grdMutationFinal.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        private void DownloadWord(string strBody)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.ContentType = "application/msword";
            string strFileName = "MutationRegister" + ".doc";
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
                "   {size:8.5in 11.0in; " +
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