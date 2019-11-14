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
    public partial class SummaryOfTitleSearchReport : System.Web.UI.Page
    {
        DataSet dsSummary = new DataSet();
        dbReports dbReportsData = new dbReports();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    DataSet dsVillage = dbReportsData.getVillages();
                    if (dsVillage != null && dsVillage.Tables[0].Rows.Count > 0)
                    {
                       //cmbVillage.Items.Clear();
                        DataTable dtVillage = dsVillage.Tables[0];
                        cmbVillage.DataSource = dtVillage; //dsVillage.Tables[0].DefaultView;
                        cmbVillage.DataTextField = dtVillage.Columns["villagemname"].ToString();
                        cmbVillage.DataValueField = dtVillage.Columns["villagecode"].ToString();
                        cmbVillage.DataBind();
                    }

                }
                //if (cmbVillage.SelectedIndex == -1)
                //    SummaryGridBind(null);
            }
            catch (Exception)
            {
                throw;
            }
        }


        protected void SummaryGridBind(string VillageCode)
        {
            if (VillageCode == "0")
                VillageCode = "";

            dsSummary = dbReportsData.getSummaryOfTitleSearchReport(VillageCode);

            if (dsSummary != null && dsSummary.Tables[0].Rows.Count > 0)
            {
                DataTable dtSummary = dsSummary.Tables[0];
                Grid1.DataSource = dtSummary;
                Grid1.DataBind();

                DataTable dt = dtSummary;
                {
                    DataTable dt2 = new DataTable();
                    for (int i = 0; i <= dt.Rows.Count; i++)
                    {
                        dt2.Columns.Add();
                    }
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        dt2.Rows.Add();
                        dt2.Rows[i][0] = dt.Columns[i].ColumnName;
                    }
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            dt2.Rows[i][j + 1] = dt.Rows[j][i];
                        }
                    }

                    this.Chart1.DataSource = dt2;
                    this.DataBind();
                }
            }
        }





        protected void Grid1_ServerPdfExporting(object sender, GridEventArgs e)
        {
            PdfExport exp = new PdfExport();

            string VillageCode = cmbVillage.SelectedValue;
            SummaryGridBind(VillageCode);


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

                PdfDocument pdfDocument = exp.Export(Grid1.Model, (IEnumerable)list, "SummaryOfTitleSearchReport.pdf", true, true, "flat-lime", true);

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
                PdfCompositeField compositeField1 = new PdfCompositeField(font, brush, "Summary Of Title Search Report");
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

                pdfDocument.Save("SummaryOfTitleSearchReport.pdf", Response, HttpReadType.Save);

            }
            else
            {

            }

        }

        protected void cmbVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string VillageCode = cmbVillage.SelectedValue;
                SummaryGridBind(VillageCode);
            }
            catch (Exception)
            {

                throw;
            }


        }

    }
}