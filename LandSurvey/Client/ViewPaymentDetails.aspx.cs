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
    public partial class ViewPaymentDetails : System.Web.UI.Page
    {
        DataSet dsPayDetails = new DataSet();
        dbReports dbReportsData = new dbReports();
        dbPayment dbPayment = new dbPayment();

        DataSet dsVillage = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {

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
                
                DateTime? dtFromDate, dtToDate;

                if (!string.IsNullOrEmpty(txtFromDate.Text.Trim()))
                    dtFromDate = Convert.ToDateTime(txtFromDate.Text.Trim());
                else
                    dtFromDate = null;

                if (!string.IsNullOrEmpty(txtToDate.Text.Trim()))
                    dtToDate = Convert.ToDateTime(txtToDate.Text.Trim());
                else
                    dtToDate = null;

                if (dtFromDate != null && dtToDate != null)
                {
                    if (dtFromDate > dtToDate)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert(' From date should be less than To date.');", true);
                        return;
                    }
                }

                BindGridBind();
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void BindGridBind()
        {
            string value = rblSearch.SelectedValue;

            string FromDate = null, ToDate = null, SearchType = value, FamilyDocNo = null;

            if (value == "Daily" || value == "Monthly" || value == "Weekly")
            {
                if (value == "Daily")
                {
                    FromDate = DateTime.Today.ToString();
                    ToDate = DateTime.Today.ToString();
                }
                else
                {
                    FromDate = txtFromDate.Text;
                    ToDate = txtToDate.Text;
                }
            }
            else if (value == "DocNo")
            {
                FamilyDocNo = txtDocumentNumber.Text;
            }
            else if (value == "FamNo")
            {
                FamilyDocNo = txtFamilyNo.Text;
            }

            dsPayDetails = dbPayment.getPaymentDetails(FromDate, ToDate, SearchType, FamilyDocNo);

            if (dsPayDetails != null && dsPayDetails.Tables[0].Rows.Count > 0)
            {
                DataTable dtSummary = dsPayDetails.Tables[0];
                grdPayDetails.DataSource = dtSummary;
                grdPayDetails.DataBind();
            }
            else
            {
                grdPayDetails.DataSource = null;
                grdPayDetails.DataBind();
            }

        }

        protected void grdPayDetails_ServerPdfExporting(object sender, GridEventArgs e)
        {
            PdfExport exp = new PdfExport();
            BindGridBind();
            if (dsPayDetails.Tables[0].Rows.Count > 0)
            {
                DataTable dtSummary = dsPayDetails.Tables[0];
                //List<DataRow> list = FamilyDetails.AsEnumerable().ToList();
                List<DataRow> list = new List<DataRow>(dtSummary.Select());

                PdfPageSettings pageSettings = new PdfPageSettings(50f);
                pageSettings.Margins.Left = 15;

                pageSettings.Margins.Right = 15;

                pageSettings.Margins.Top = 10;

                pageSettings.Margins.Bottom = 10;

                PdfDocument pdfDocument = exp.Export(grdPayDetails.Model, (IEnumerable)list, "FindDocumentStatus.pdf", true, true, "flat-lime", true);

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

        protected void rblSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string value = rblSearch.SelectedValue;

                if (value == "Monthly" || value == "Weekly")
                {
                    txtFromDate.Text = "";
                    txtToDate.Text = "";
                    trDateRange.Visible = true;
                    trDocNos.Visible = false;
                    trFamNo.Visible = false;
                }
                else if (value == "DocNo")
                {
                    txtDocumentNumber.Text = "";
                    trDocNos.Visible = true;
                    trDateRange.Visible = false;
                    trFamNo.Visible = false;
                }
                else if (value == "FamNo")
                {
                    txtFamilyNo.Text = "";
                    trFamNo.Visible = true;
                    trDocNos.Visible = false;
                    trDateRange.Visible = false;
                }
            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}