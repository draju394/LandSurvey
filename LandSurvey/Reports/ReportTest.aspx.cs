﻿using System;
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
    public partial class ReportTest : System.Web.UI.Page
    {
        DataSet dsFamilyDetails = new DataSet();
        dbFamilyDetails dbFamilyDetailsData = new dbFamilyDetails();
        DataSet dsFamilyNumber = new DataSet();
        DataSet dsVillage = new DataSet();
        dbVillage dbVillageData = new dbVillage();
        DataSet dsSelectedFamilyDetails = new DataSet();
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
                dsVillage = dbVillageData.getVillageName();
                if (dsVillage.Tables[0].Rows.Count > 0)
                {
                    cmbVillage.DataSource = dsVillage.Tables[0].DefaultView;
                    cmbVillage.DataBind();
                    cmbVillage.DataTextField = dsVillage.Tables[0].Columns["villagemname"].ToString();
                    cmbVillage.DataValueField = dsVillage.Tables[0].Columns["villagecode"].ToString();
                    cmbVillage.DataBind();
                }
            }
                       
            FamilyDetailsGridBind();
        }

       
        protected void FamilyDetailsGridBind()
        {
            if (cmbVillage.SelectedIndex >= 0 & cmbFamilyNo.SelectedIndex >= 0)
            {
                dsFamilyDetails = dbFamilyDetailsData.getFamilyDetailsAllDataOnDocNo(cmbFamilyNo.SelectedValue.ToString());
            }
            else
            {
                dsFamilyDetails = dbFamilyDetailsData.getFamilyDetailsAllData();
            }
          
            if (dsFamilyDetails.Tables[0].Rows.Count > 0)
            {
                DataTable FamilyDetails = dsFamilyDetails.Tables[0];
                Grid1.DataSource = FamilyDetails;
                Grid1.DataBind();

            }
        }

        protected void cmbVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVillage.SelectedIndex == 0)
            {
                FamilyDetailsGridBind();
            }
            else
            {
                cmbFamilyNo.Items.Clear();
                string selectedVillage = cmbVillage.SelectedValue.ToString().Trim();
                dsFamilyNumber = dbFamilyDetailsData.getFamilyNumber(selectedVillage.ToString());
                if (dsFamilyNumber.Tables[0].Rows.Count > 0)
                {
                    cmbFamilyNo.DataSource = dsFamilyNumber.Tables[0].DefaultView;
                    cmbFamilyNo.DataBind();
                    cmbFamilyNo.DataTextField = dsFamilyNumber.Tables[0].Columns["familyno"].ToString();
                    cmbFamilyNo.DataValueField = dsFamilyNumber.Tables[0].Columns["familyno"].ToString();
                    cmbFamilyNo.DataBind();
                }

            }
        }

        protected void cmbFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string SelectedFamilyNo = cmbFamilyNo.SelectedValue.ToString().Trim();
            //DataTable dt = new DataTable();
            //Grid1.DataSource = dt;
            //Grid1.DataBind();
            //Grid1.DataSource = null;
            //Grid1.DataBind();
            //dsFamilyDetails.Clear();
            //dsFamilyDetails = dbFamilyDetailsData.getFamilyDetailsAllDataOnDocNo(SelectedFamilyNo);
            FamilyDetailsGridBind();
            //if (dsFamilyDetails.Tables[0].Rows.Count > 0)
            //{

            //    DataTable FamilyDetailsNew = dsFamilyDetails.Tables[0];
            //    Grid1.DataSource = FamilyDetailsNew;
            //    Grid1.DataBind();

            //}

        }

        //protected void cmbVillageName_ValueSelect(object sender, ComboBoxEventArgs e)
        //{

        //    var selectedVillage = e.Value;

        //    dsFamilyNumber = dbFamilyDetailsData.getFamilyNumber(selectedVillage.ToString());
        //    if (dsFamilyNumber.Tables[0].Rows.Count > 0)
        //    {
        //        cmbFamilyNo.DataSource = dsFamilyNumber.Tables[0].DefaultView;
        //        cmbFamilyNo.DataBind();
        //        cmbFamilyNo.DataTextField = dsFamilyNumber.Tables[0].Columns["familyno"].ToString();
        //        cmbFamilyNo.DataValueField = dsFamilyNumber.Tables[0].Columns["familyno"].ToString();
        //        cmbFamilyNo.DataBind();

        //    }

        //}
        protected void Grid1_ServerPdfExporting(object sender, GridEventArgs e)
        {
            PdfExport exp = new PdfExport();
            if (dsFamilyDetails.Tables[0].Rows.Count > 0)
            {
                DataTable FamilyDetails1 = dsFamilyDetails.Tables[0];
                //List<DataRow> list = FamilyDetails.AsEnumerable().ToList();
                List<DataRow> list = new List<DataRow>(FamilyDetails1.Select());

                PdfPageSettings pageSettings = new PdfPageSettings(50f);
                pageSettings.Margins.Left = 15;

                pageSettings.Margins.Right = 15;

                pageSettings.Margins.Top = 10;

                pageSettings.Margins.Bottom = 10;

                PdfDocument pdfDocument = exp.Export(Grid1.Model, (IEnumerable)list, "FamilyDetails.pdf", true, true, "flat-lime", true);

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
                PdfCompositeField compositeField1 = new PdfCompositeField(font, brush, "Family Details");
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

                pdfDocument.Save("FamilyDetails.pdf", Response, HttpReadType.Save);

            }
            else
            {

            }

        }

       




        //
    }
   
}