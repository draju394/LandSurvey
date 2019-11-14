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

namespace LandSurvey.Accounts
{
    public partial class PaymentNoteList : System.Web.UI.Page
    {
        DataSet dsPaymentNotes = new DataSet();
        dbPaymentNote dbPaymentNotesData = new dbPaymentNote();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dsPaymentNotes = dbPaymentNotesData.getAllPaymentNotes();
                if(dsPaymentNotes.Tables[0].Rows.Count > 0)
                {
                    DataTable dtPaymentNotes = dsPaymentNotes.Tables[0];
                    grdPaymentNote.DataSource = dtPaymentNotes;
                    grdPaymentNote.DataBind();

                }

            }

        }

        protected void btnAddPaymentNote_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Accounts/PaymentNote");
        }

        protected void grdPaymentNote_ServerPdfExporting(object sender, Syncfusion.JavaScript.Web.GridEventArgs e)
        {
            PdfExport exp = new PdfExport();
            dsPaymentNotes = dbPaymentNotesData.getAllPaymentNotes();
            if (dsPaymentNotes.Tables[0].Rows.Count > 0)
            {
                DataTable FamilyDetails1 = dsPaymentNotes.Tables[0];
                //List<DataRow> list = FamilyDetails.AsEnumerable().ToList();
                List<DataRow> list = new List<DataRow>(FamilyDetails1.Select());

                PdfPageSettings pageSettings = new PdfPageSettings(50f);
                pageSettings.Margins.Left = 15;

                pageSettings.Margins.Right = 15;

                pageSettings.Margins.Top = 10;

                pageSettings.Margins.Bottom = 10;

                PdfDocument pdfDocument = exp.Export(grdPaymentNote.Model, (IEnumerable)list, "PaymentNoteAll.pdf", true, true, "flat-lime", true);

                RectangleF rect = new RectangleF(0, 0, pdfDocument.PageSettings.Width, 50);
                RectangleF rect1 = new RectangleF(0, 0, pdfDocument.PageSettings.Width, 50);

                //create a header pager template
                PdfPageTemplateElement header = new PdfPageTemplateElement(rect);
                PdfPageTemplateElement header1 = new PdfPageTemplateElement(rect1);

                //create a footer pager template
                PdfPageTemplateElement footer = new PdfPageTemplateElement(rect);

                Font f = new Font("Arial", 11, FontStyle.Bold);

                PdfFont font = new PdfTrueTypeFont(f, true);

                    
                PdfBrush brush = new PdfSolidBrush(Color.Black);
                //Add the fields in composite fields
                //PdfCompositeField compositeField = new PdfCompositeField(font, brush, "Land Aquisition - SEZ Thane");
                //PdfCompositeField compositeField1 = new PdfCompositeField(font, brush, "Family Details");
                //PdfCompositeField compositeField2 = new PdfCompositeField(font, brush, "Report");
                //PdfCompositeField compositeField3 = new PdfCompositeField(font, brush, "Family Details");
                //compositeField.Bounds = header.Bounds;
                ////Draw the composite field in footer
                //compositeField.Draw(footer.Graphics, new PointF(200, 0));
                //compositeField1.Draw(footer.Graphics, new PointF(230, 10));
                //compositeField2.Draw(footer.Graphics, new PointF(205, 20));
                //compositeField3.Draw(footer.Graphics, new PointF(228, 40));
                //Add the footer template at the bottom
                pdfDocument.Template.Top = header;

                footer.Graphics.DrawString("CopyRights", font, PdfBrushes.Gray, new Point(250, 0));//Add Custom text to footer
                pdfDocument.Template.Bottom = footer;//Add the footer template to document

                pdfDocument.Save("PaymentNoteAll.pdf", Response, HttpReadType.Save);

            }
            else
            {

            }
        }
    }
}