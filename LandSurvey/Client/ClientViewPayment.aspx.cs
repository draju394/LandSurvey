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
    public partial class ClientViewPayment : System.Web.UI.Page
    {
        DataSet dsPaymentNotes = new DataSet();
        dbPaymentNote dbPaymentNotesData = new dbPaymentNote();
        //List<Orders> order = new List<Orders>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dsPaymentNotes = dbPaymentNotesData.getAllPaymentNotes();
                if (dsPaymentNotes.Tables[0].Rows.Count > 0)
                {
                    DataTable dtPaymentNotes = dsPaymentNotes.Tables[0];
                    grdPaymentNoteEdit.DataSource = dtPaymentNotes;
                    grdPaymentNoteEdit.DataBind();
                   // this.grdPaymentNote.ColStyles[2].Format = "N2";
                   
                }

            }
        }

        protected void grdPaymentNote_ServerPdfExporting(object sender, GridEventArgs e)
        {
            //PdfExport exp = new PdfExport();
            //dsPaymentNotes = dbPaymentNotesData.getAllPaymentNotes();
            //if (dsPaymentNotes.Tables[0].Rows.Count > 0)
            //{
            //    DataTable FamilyDetails1 = dsPaymentNotes.Tables[0];
            //    //List<DataRow> list = FamilyDetails.AsEnumerable().ToList();
            //    List<DataRow> list = new List<DataRow>(FamilyDetails1.Select());

            //    PdfPageSettings pageSettings = new PdfPageSettings(50f);
            //    pageSettings.Margins.Left = 15;

            //    pageSettings.Margins.Right = 15;

            //    pageSettings.Margins.Top = 10;

            //    pageSettings.Margins.Bottom = 10;

            //    //PdfDocument pdfDocument = exp.Export(grdPaymentNote.Model, (IEnumerable)list, "PaymentNoteAll.pdf", true, true, "flat-lime", true);
            //    PdfDocument pdfDocument = exp.Export(grdPaymentNoteEdit.Model, (IEnumerable)list, "PaymentNoteAll.pdf", true, true, "flat-lime", true);

            //    RectangleF rect = new RectangleF(0, 0, pdfDocument.PageSettings.Width, 50);
            //    RectangleF rect1 = new RectangleF(0, 0, pdfDocument.PageSettings.Width, 50);

            //    //create a header pager template
            //    PdfPageTemplateElement header = new PdfPageTemplateElement(rect);
            //    PdfPageTemplateElement header1 = new PdfPageTemplateElement(rect1);

            //    //create a footer pager template
            //    PdfPageTemplateElement footer = new PdfPageTemplateElement(rect);

            //    Font f = new Font("Arial", 11, FontStyle.Bold);

            //    PdfFont font = new PdfTrueTypeFont(f, true);


            //    PdfBrush brush = new PdfSolidBrush(Color.Black);
            //    //Add the fields in composite fields
            //    //PdfCompositeField compositeField = new PdfCompositeField(font, brush, "Land Aquisition - SEZ Thane");
            //    //PdfCompositeField compositeField1 = new PdfCompositeField(font, brush, "Family Details");
            //    //PdfCompositeField compositeField2 = new PdfCompositeField(font, brush, "Report");
            //    //PdfCompositeField compositeField3 = new PdfCompositeField(font, brush, "Family Details");
            //    //compositeField.Bounds = header.Bounds;
            //    ////Draw the composite field in footer
            //    //compositeField.Draw(footer.Graphics, new PointF(200, 0));
            //    //compositeField1.Draw(footer.Graphics, new PointF(230, 10));
            //    //compositeField2.Draw(footer.Graphics, new PointF(205, 20));
            //    //compositeField3.Draw(footer.Graphics, new PointF(228, 40));
            //    //Add the footer template at the bottom
            //    pdfDocument.Template.Top = header;

            //    footer.Graphics.DrawString("CopyRights", font, PdfBrushes.Gray, new Point(250, 0));//Add Custom text to footer
            //    pdfDocument.Template.Bottom = footer;//Add the footer template to document

            //    pdfDocument.Save("PaymentNoteAll.pdf", Response, HttpReadType.Save);

            //}
            //else
            //{

            //}
        
    }

       

        protected void grdPaymentNote_ServerEditRow(object sender, GridEventArgs e)
        {
            EditAction(e.EventType, e.Arguments["data"]);

        }

        private void EditAction(string eventType, object record)
        {
            Dictionary<string, object> KeyVal = record as Dictionary<string, object>;

            if (eventType == "endEdit")
            {
                DataSet dsEdit = new DataSet();
                foreach (KeyValuePair<string, object> keyval in KeyVal)
                {
                    

                }
            }
                //throw new NotImplementedException();
        }

        protected void grdPaymentNoteEdit_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdPaymentNoteEdit.EditIndex = -1;
            FillPaymentGrid();
        }

        protected void grdPaymentNoteEdit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdPaymentNoteEdit.EditIndex = e.NewEditIndex;
            FillPaymentGrid();
        }

        protected void grdPaymentNoteEdit_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label PaymentNoteID = grdPaymentNoteEdit.Rows[e.RowIndex].FindControl("lblPaymentNoteID") as Label;
            TextBox ApproveNote = grdPaymentNoteEdit.Rows[e.RowIndex].FindControl("txtApprove") as TextBox;
            dbPaymentNotesData.paymentnoteid =  Convert.ToInt32(PaymentNoteID.Text);
            dbPaymentNotesData.demandapprove = ApproveNote.Text;
            dbPaymentNotesData.demandapprovedate = DateTime.Today;
            bool UpdatePaymentNote = dbPaymentNotesData.UpdatePaymentNoteClient();
            if (UpdatePaymentNote)
            {
                grdPaymentNoteEdit.EditIndex = -1; grdPaymentNoteEdit.EditIndex = -1;
                FillPaymentGrid();
            }
            else
            {
               grdPaymentNoteEdit.EditIndex = -1;
               FillPaymentGrid();
            }

        }

        protected void grdPaymentNoteEdit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdPaymentNoteEdit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        //select row_number() over() as srno, t.* from(select paymentnoteid, demandnote, to_char(demanddate,'dd-mm-yyyy')as demanddate , v.villagename as villagecode, documentno, seriesno, phaseno, totaldemand, " +
        //            " case when demandsent is null then  'No' else 'Yes' end as demandsent, " +
        //            " case when demandapprove is null then 'No' else 'Yes' end as demandapprove from paymentnote, village v where paymentnote.villagecode = v.villagecode) t ", "paymentnote")

        //[Serializable]
        //public class Orders
        //{
        //    public Orders()
        //    {

        //    }
        //    public Orders(int paymentnoteid, string demandnote, DateTime demanddate, string villagecode, string documentno, string seriesno, string phaseno, double totaldemand, string demandsent, string demandapprove)
        //    {
        //        this.PayMentNoteID = paymentnoteid;
        //        this.CustomerID = customerId;
        //        this.EmployeeID = empId;
        //        this.Freight = freight;
        //        this.OrderDate = orderDate;
        //        this.ShipCity = shipCity;
        //        this.Verified = verified;
        //    }
        //    public int PayMentNoteID { get; set; }
        //    public string DemandNot { get; set; }
        //    public DateTime DemandDate { get; set; }
        //    public string VillageCode { get; set; }
        //    public string DocumentNo { get; set; }
        //    public string SeriesNo { get; set; }
        //    public bool Verified { get; set; }
        //}
        //int paymentnoteid, string demandnote, DateTime demanddate, string villagecode, string documentno, 
        //    string seriesno, string phaseno, double totaldemand, string demandsent, string demandapprove)
        //

        private void FillPaymentGrid()
        {
            dsPaymentNotes = dbPaymentNotesData.getAllPaymentNotes();
            if (dsPaymentNotes.Tables[0].Rows.Count > 0)
            {
                DataTable dtPaymentNotes = dsPaymentNotes.Tables[0];
                grdPaymentNoteEdit.DataSource = dtPaymentNotes;
                grdPaymentNoteEdit.DataBind();
                // this.grdPaymentNote.ColStyles[2].Format = "N2";

            }
        }
    }
}