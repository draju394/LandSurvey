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

namespace LandSurvey.Client
{
    public partial class FindDocumentStatus : System.Web.UI.Page
    {
        DataSet dsSummary = new DataSet();
        dbReports dbReportsData = new dbReports();
        dbDocumentStatus dbDocStatus = new dbDocumentStatus();
        DataSet dsVillage = new DataSet();
        DataSet dsDocument = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    dsDocument = dbDocStatus.getDocumentNumber();

                    if (dsDocument != null && dsDocument.Tables[0].Rows.Count > 0)
                    {
                        DataTable dtDocument = dsDocument.Tables[0];
                        cmdDocumentNumber.DataSource = dsDocument.Tables[0].DefaultView;
                        cmdDocumentNumber.DataBind();
                        cmdDocumentNumber.DataTextField = dsDocument.Tables[0].Columns["docno"].ToString();
                        cmdDocumentNumber.DataValueField = dsDocument.Tables[0].Columns["docno"].ToString();
                        cmdDocumentNumber.DataBind();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void SummaryGridBind()
        {
            string DocumentNo = cmdDocumentNumber.SelectedValue;

            dsSummary = dbReportsData.getDocumentStatus(DocumentNo);

            if (dsSummary != null && dsSummary.Tables[0].Rows.Count > 0)
            {
                DataTable dtSummary = dsSummary.Tables[0];
                Grid1.DataSource = dtSummary;
                Grid1.DataBind();
            }
            else
            {
                Grid1.DataSource = null;
                Grid1.DataBind();
            }

        }

        protected void Grid1_ServerPdfExporting(object sender, GridEventArgs e)
        {
            PdfExport exp = new PdfExport();
            SummaryGridBind();
            if (dsSummary.Tables[0].Rows.Count > 0)
            {
                DataTable dtSummary = dsSummary.Tables[0];
                //List<DataRow> list = FamilyDetails.AsEnumerable().ToList();
                List<DataRow> list = new List<DataRow>(dtSummary.Select());

                PdfPageSettings pageSettings = new PdfPageSettings(50f);
                pageSettings.Margins.Left = 15;

                pageSettings.Margins.Right = 15;

                pageSettings.Margins.Top = 10;

                pageSettings.Margins.Bottom = 10;

                PdfDocument pdfDocument = exp.Export(Grid1.Model, (IEnumerable)list, "FindDocumentStatus.pdf", true, true, "flat-lime", true);

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
                PdfCompositeField compositeField1 = new PdfCompositeField(font, brush, "Find Document Status");
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

                pdfDocument.Save("FindDocumentStatus.pdf", Response, HttpReadType.Save);

            }
            else
            {

            }

        }

        protected void cmdDocumentNumber_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}