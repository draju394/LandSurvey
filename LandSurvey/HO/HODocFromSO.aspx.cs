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
using System.Web.Script.Serialization;

namespace LandSurvey.HO
{
    public partial class HODocFromSO : System.Web.UI.Page
    {
        DataSet dsVillage = new DataSet();
        dbVillage dbVillageData = new dbVillage();

        DataSet dsFamilyDocNoNew = new DataSet();
        dbFamilyDetails dbFamilyDetailsData = new dbFamilyDetails();
        dbDocument dbDocumentStatusData = new dbDocument();

        DataSet dsShowAllDocData = new DataSet();

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
                    //Upload1.Enabled = false;
                    DisableLables();
                }
                else
                {
                    DataTable dt = new DataTable();
                    //grdFamilyDocDetails.DataSource = dt;
                    //grdFamilyDocDetails.DataBind();

                }
            }

        }

        protected void cmbVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVillage.SelectedIndex == -1)
            {

            }
            else
            {
                cmbDocumentNo.Items.Clear();
                DisableLables();
                string selectedVillage = cmbVillage.SelectedValue.ToString().Trim();
                dsFamilyDocNoNew = dbFamilyDetailsData.getDocumnentNoTitleSearch(selectedVillage);
                if (dsFamilyDocNoNew.Tables[0].Rows.Count > 0)
                {
                    cmbDocumentNo.DataSource = dsFamilyDocNoNew.Tables[0].DefaultView;
                    cmbDocumentNo.DataBind();
                    cmbDocumentNo.DataTextField = dsFamilyDocNoNew.Tables[0].Columns["docno"].ToString();
                    cmbDocumentNo.DataValueField = dsFamilyDocNoNew.Tables[0].Columns["docno"].ToString();
                    cmbDocumentNo.DataBind();
                }
            }
        }

        protected void cmbDocumentNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDocumentNo.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Document Number ');", true);
            }
            else
            {
                //string strFamilyNo = dbFamilyDetailsData.getFamilyNoOnDocNo(cmbDocumentNo.SelectedValue.ToString().Trim());
                //lblDocNo.Text = cmbDocumentNo.SelectedValue.ToString();
                //lblFamily.Text = strFamilyNo;
                ShowUploadedDocuments();
            }
                
        }


        private void ShowUploadedDocuments()
        {
            DataSet dsGetAllDocuments;
            DisableLables();
            dsGetAllDocuments = dbDocumentStatusData.GetHODocFromSO(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString(), "SO1");
            if (dsGetAllDocuments.Tables[0].Rows.Count > 0)
            {
                string strFamilyNo = dbFamilyDetailsData.getFamilyNoOnDocNo(cmbDocumentNo.SelectedValue.ToString().Trim());
                lblDocNo.Text = cmbDocumentNo.SelectedValue.ToString();
                lblFamily.Text = strFamilyNo;

                //string UploadedDocument = dsGetAllDocuments.Tables[0].Rows[0]["documentname"].ToString();
                //if(UploadedDocument != "")
                //{
                for (int i = 0; i < dsGetAllDocuments.Tables[0].Rows.Count; i++)
                {
                    string UploadedDocument = dsGetAllDocuments.Tables[0].Rows[i]["documentname"].ToString();
                    string DocumentCode = dsGetAllDocuments.Tables[0].Rows[i]["documentcode"].ToString();
                    string CreatedDate = dsGetAllDocuments.Tables[0].Rows[i]["createddate"].ToString();
                    if (DocumentCode == "MSR") { btnLinkMSR.Text = UploadedDocument; lblDateMSR.Text = CreatedDate.ToString(); }
                   // if (DocumentCode == "RCMS") { btnLinkRCMS.Text = UploadedDocument; lblDateRCMS.Text = CreatedDate.ToString(); }
                    if (DocumentCode == "ODMS") { btnLinkODMS.Text = UploadedDocument; lblDateODMS.Text = CreatedDate.ToString(); }
                  //  if (DocumentCode == "CRS") { btnLinkCSR.Text = UploadedDocument; lblDateCRS.Text = CreatedDate.ToString(); }
                    if (DocumentCode == "RSR") { btnLinkRSR.Text = UploadedDocument; lblDateRSR.Text = CreatedDate.ToString(); }
                   // if (DocumentCode == "RCRS") { btnLinkRCRS.Text = UploadedDocument; lblDateRCRS.Text = CreatedDate.ToString(); }
                    if (DocumentCode == "LI") { btnLinkLI.Text = UploadedDocument; lblDateLI.Text = CreatedDate.ToString(); }
                    if (DocumentCode == "FT") { btnLinkFT.Text = UploadedDocument; lblDateFT.Text = CreatedDate.ToString(); }
                 //   if (DocumentCode == "CMS") { btnLinkChkList.Text = UploadedDocument; lblDateChkList.Text = CreatedDate.ToString(); }
                }
                //}
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Documents not uploaded');", true);
                DisableLables();
                //lblLinkGhoshanaPatra.Text = "";
                //lblLinkHamiPatra.Text = "";
                //lbllinkSaleDeed.Text = "";
                //lbllinkVisarPavti.Text = "";
                //lbllnkAgreementToSale.Text = "";
                //lbllnkPowerOfAttorney.Text = "";
                //lbllnkTabaPavti.Text = "";
            }
        }

        private void DisableLables()
        {
            //btnLinkCSR.Enabled = false;
            //btnLinkFT.Enabled = false;
            //btnLinkLI.Enabled = false;
            //btnLinkMSR.Enabled = false;
            //btnLinkODMS.Enabled = false;
            //btnLinkRCMS.Enabled = false;
            //btnLinkRCRS.Enabled = false;
            //btnLinkRSR.Enabled = false;

          //  btnLinkCSR.Text = "";
            btnLinkFT.Text = "";
            btnLinkLI.Text = "";
            btnLinkMSR.Text = "";
            btnLinkODMS.Text = "";
           // btnLinkRCMS.Text = "";
          //  btnLinkRCRS.Text = "";
            btnLinkRSR.Text = "";
          //  btnLinkChkList.Text = "";

           // lblDateCRS.Enabled = false;
            lblDateFT.Enabled = false;
            lblDateLI.Enabled = false;
            lblDateMSR.Enabled = false;
            lblDateODMS.Enabled = false;
           // lblDateRCMS.Enabled = false;
           // lblDateRCRS.Enabled = false;
            lblDateRSR.Enabled = false;
          //  lblDateChkList.Enabled = false;
            lblDateRegistry.Enabled = false;

          //  lblDateCRS.Text = "";
            lblDateFT.Text = "";
            lblDateLI.Text = "";
            lblDateMSR.Text = "";
            lblDateODMS.Text = "";
           // lblDateRCMS.Text = "";
          //  lblDateRCRS.Text = "";
            lblDateRSR.Text = "";
          //  lblDateChkList.Text = "";
            lblDateRegistry.Text = "";

            lblDocNo.Text = "";
            lblFamily.Text = "";
        }

        protected void btnLinkMSR_Click(object sender, EventArgs e)
        {
            if (btnLinkMSR.Text != "")
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + btnLinkMSR.Text);
                Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + btnLinkMSR.Text));
                Response.End();
            }
        }

        protected void btnLinkRCMS_Click(object sender, EventArgs e)
        {
            //Response.Clear();
            //Response.ContentType = "application/octet-stream";
            //Response.AddHeader("Content-Disposition", "attachment; filename=" + btnLinkRCMS.Text);
            //Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + btnLinkRCMS.Text));
            //Response.End();
        }

        protected void btnLinkODMS_Click(object sender, EventArgs e)
        {
            //Response.Clear();
            //Response.ContentType = "application/octet-stream";
            //Response.AddHeader("Content-Disposition", "attachment; filename=" + btnLinkRCMS.Text);
            //Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + btnLinkRCMS.Text));
            //Response.End();
        }

        protected void btnLinkLI_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + btnLinkLI.Text);
            Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + btnLinkLI.Text));
            Response.End();
        }

        protected void btnLinkFT_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + btnLinkFT.Text);
            Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + btnLinkFT.Text));
            Response.End();
        }

        protected void btnLinkRCRS_Click(object sender, EventArgs e)
        {
            //Response.Clear();
            //Response.ContentType = "application/octet-stream";
            //Response.AddHeader("Content-Disposition", "attachment; filename=" + btnLinkRCRS.Text);
            //Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + btnLinkRCRS.Text));
            //Response.End();
        }

        protected void btnLinkRSR_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + btnLinkRSR.Text);
            Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + btnLinkRSR.Text));
            Response.End();
        }

        protected void btnLinkCSR_Click(object sender, EventArgs e)
        {
            //string FileExist = Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + btnLinkCSR.Text);
            //if (File.Exists(FileExist))
            //{
            //    Response.Clear();
            //    Response.ContentType = "application/octet-stream";
            //    Response.AddHeader("Content-Disposition", "attachment; filename=" + btnLinkCSR.Text);
            //    Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + btnLinkCSR.Text));
            //    Response.End();
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('File Not Exisits');", true);
            //    ShowUploadedDocuments();
            //}
        }

        protected void btnLinkChkList_Click(object sender, EventArgs e)
        {
            //string FileExist = Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + btnLinkChkList.Text);
            //if (File.Exists(FileExist))
            //{
            //    Response.Clear();
            //    Response.ContentType = "application/octet-stream";
            //    Response.AddHeader("Content-Disposition", "attachment; filename=" + btnLinkChkList.Text);
            //    Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + btnLinkChkList.Text));
            //    Response.End();
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Selected File Not exists on Storage');", true);
            //    ShowUploadedDocuments();
            //}
        }




        //
    }
}