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
using System.Reflection;

namespace LandSurvey.HO
{
    public partial class HODocExecution : System.Web.UI.Page
    {
        DataSet dsVillage = new DataSet();
        dbVillage dbVillageData = new dbVillage();

        DataSet dsFamilyDocNoNew = new DataSet();
        dbFamilyDetails dbFamilyDetailsData = new dbFamilyDetails();

        DataSet dsShowAllDocData = new DataSet();
        dbFileNo dbFileNoData = new dbFileNo();
        dbDocument dbDocumentStatusData = new dbDocument();
        DataSet dsDocumenteExists = new DataSet();
        

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
                    ButtonDisable();

                }
                else
                {
                    //DataTable dt = new DataTable();
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
                ButtonDisable();
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
                string strFamilyNo = dbFamilyDetailsData.getFamilyNoOnDocNo(cmbDocumentNo.SelectedValue.ToString().Trim());
                ButttonEnable();
                ShowUploadedDocuments();
               // ShowAllDocumentData();
            }
        }

        //protected void ShowAllDocumentData()
        //{
        //    if (cmbVillage.SelectedIndex > 0 & cmbDocumentNo.SelectedIndex > 0)
        //    {

        //        dsShowAllDocData = dbFamilyDetailsData.getDocumentExecution(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString());
        //        if (dsShowAllDocData.Tables[0].Rows.Count > 0)
        //        {
        //            DataTable FamilyDocDetails = dsShowAllDocData.Tables[0];
        //            grdFamilyDocDetails.DataSource = FamilyDocDetails;
        //            grdFamilyDocDetails.DataBind();

        //        }
        //        else
        //        {
        //            grdFamilyDocDetails.DataSource = null;
        //            grdFamilyDocDetails.DataBind();

        //        }
        //    }

        //}

        private void ButttonEnable()
        {
            btnAgreementToSale.Enabled = true;
            btnGhoshnaPatrs.Enabled = true;
            btnHamiPatra.Enabled = true;
            btnPowerOfAttorney.Enabled = true;
            btnSaleDeed.Enabled = true;
            btnTabaPavti.Enabled = true;
            btnVisarPavti.Enabled = true;
            FileUploadAgreementtoSale.Enabled = true;

            PanelAllUploadDoc.Enabled = true;
        }
        
        private void ButtonDisable()
        {
            btnAgreementToSale.Enabled = false;
            btnGhoshnaPatrs.Enabled = false;
            btnHamiPatra.Enabled = false;
            btnPowerOfAttorney.Enabled = false;
            btnSaleDeed.Enabled = false;
            btnTabaPavti.Enabled = false;
            btnVisarPavti.Enabled = false;
            PanelAllUploadDoc.Enabled = false;
            lblLinkGhoshanaPatra.Text = "";
            lblLinkHamiPatra.Text = "";
            lbllinkSaleDeed.Text = "";
            lbllinkVisarPavti.Text = "";
            lbllnkAgreementToSale.Text = "";
            lbllnkPowerOfAttorney.Text = "";
            lbllnkTabaPavti.Text = "";
        }

        protected void btnVisarPavti_Click(object sender, EventArgs e)
        {
            if (FileUploadVisarPavati.HasFiles)
            {
                try
                {
                    GenerateFileName("VP", FileUploadVisarPavati, lbllinkVisarPavti);
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void btnAgreementToSale_Click(object sender, EventArgs e)
        {
            if (FileUploadAgreementtoSale.HasFiles)
            {
                try
                {
                    GenerateFileName("ATS", FileUploadAgreementtoSale, lbllnkAgreementToSale);
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void btnSaleDeed_Click(object sender, EventArgs e)
        {
            if (FileUploadSaleDeed.HasFiles)
            {
                try
                {
                    GenerateFileName("SD", FileUploadSaleDeed, lbllinkSaleDeed);
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void btnPowerOfAttorney_Click(object sender, EventArgs e)
        {
            if (FileUploadPowerOfAttorney.HasFiles)
            {
                try
                {
                    GenerateFileName("GPA", FileUploadPowerOfAttorney, lbllnkPowerOfAttorney);
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void btnTabaPavti_Click(object sender, EventArgs e)
        {
            if (FileUploadTabaPavti.HasFiles)
            {
                try
                {
                    GenerateFileName("TP", FileUploadTabaPavti, lbllnkTabaPavti);
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void btnGhoshnaPatrs_Click(object sender, EventArgs e)
        {
            if (FileUploadGhoshanaPatra.HasFiles)
            {
                try
                {
                    GenerateFileName("GP", FileUploadGhoshanaPatra, lblLinkGhoshanaPatra);
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void btnHamiPatra_Click(object sender, EventArgs e)
        {
            if (FileUploadHamiPatra.HasFiles)
            {
                try
                {
                    GenerateFileName("HP", FileUploadHamiPatra, lblLinkHamiPatra);
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void lblLinkHamiPatra_Click(object sender, EventArgs e)
        {
            if (lblLinkHamiPatra.Text != "File Not Uploaded")
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + lblLinkHamiPatra.Text);
                Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lblLinkHamiPatra.Text));
                Response.End();
            }
        }

        protected void lbllinkVisarPavti_Click(object sender, EventArgs e)
        {
            if(lbllinkVisarPavti.Text != "File Not Uploaded")
            { 
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + lbllinkVisarPavti.Text);
                Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lbllinkVisarPavti.Text));
                Response.End();
            }
        }

        protected void lbllnkAgreementToSale_Click(object sender, EventArgs e)
        {
            if (lbllnkAgreementToSale.Text != "File Not Uploaded")
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + lbllnkAgreementToSale.Text);
                Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lbllnkAgreementToSale.Text));
                Response.End();
            }
        }

        protected void lbllinkSaleDeed_Click(object sender, EventArgs e)
        {
            if (lbllinkSaleDeed.Text != "File Not Uploaded")
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + lbllinkSaleDeed.Text);
                Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lbllinkSaleDeed.Text));
                Response.End();
            }
        }

        protected void lbllnkPowerOfAttorney_Click(object sender, EventArgs e)
        {
            if (lbllinkSaleDeed.Text != "File Not Uploaded")
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + lbllnkPowerOfAttorney.Text);
                Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lbllnkPowerOfAttorney.Text));
                Response.End();
            }
        }

        protected void lbllnkTabaPavti_Click(object sender, EventArgs e)
        {
            if (lbllnkTabaPavti.Text != "File Not Uploaded")
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + lbllnkTabaPavti.Text);
                Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lbllnkTabaPavti.Text));
                Response.End();
            }
        }

        protected void lblLinkGhoshanaPatra_Click(object sender, EventArgs e)
        {
            if (lbllnkTabaPavti.Text != "File Not Uploaded")
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + lblLinkGhoshanaPatra.Text);
                Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lblLinkGhoshanaPatra.Text));
                Response.End();
            }
        }
        //private void DisableControls(System.Web.UI.Control control)
        //{
        //    foreach (System.Web.UI.Control c in control.Controls)
        //    {
        //        // Get the Enabled property by reflection.
        //        Type type = c.GetType();
        //        PropertyInfo prop = type.GetProperty("Enabled");

        //        // Set it to False to disable the control.
        //        if (prop != null)
        //        {
        //            prop.SetValue(c, false, null);
        //        }

        //        // Recurse into child controls.
        //        if (c.Controls.Count > 0)
        //        {
        //            this.DisableControls(c);
        //        }
        //    }
        //}
        //

        private void GenerateFileName(string DocType, FileUpload FControlName, LinkButton LinkDoc)
        {
            try
            {

                string registerFileNo = dbFileNoData.getFileNo(DocType);
                string filename = Path.GetFileName(FControlName.FileName);
                string fileExtension = System.IO.Path.GetExtension(FControlName.PostedFile.FileName);
                string VillageCode = cmbVillage.SelectedValue.ToString();
                string DocumentNo = cmbDocumentNo.SelectedValue.ToString();
                string NewFileName = DocType + "_" + VillageCode + "_" + DocumentNo + "_" + registerFileNo + fileExtension;
                string folderName = Server.MapPath("~/Documents/" + VillageCode + "/");
                if (!Directory.Exists(folderName))
                {
                    Directory.CreateDirectory(folderName);
                }
                FControlName.SaveAs(folderName + NewFileName);
                //update MR File Number
                dbFileNoData.registername = DocType;
                dbFileNoData.currentno = Convert.ToInt32(registerFileNo) + 1;
                dbFileNoData.UpdateFileNo();
                LinkDoc.Text = NewFileName;
                string FinalPath = folderName + NewFileName;
                ViewState["filepath"] = FinalPath;

                //Insert in to Document Status
                string DocumentID = dbDocumentStatusData.getDocumentSeqNo();
                dbDocumentStatusData.documentid = Convert.ToInt32(DocumentID);
                dbDocumentStatusData.villagecode = VillageCode;
                dbDocumentStatusData.documentcode = DocType;
                dbDocumentStatusData.documentname = NewFileName;
                dbDocumentStatusData.documentpath = ViewState["filepath"].ToString();
                dbDocumentStatusData.createdby = Session["UserName"].ToString();
                dbDocumentStatusData.createddate = DateTime.Today;
                dbDocumentStatusData.docno = DocumentNo;
                //Check For Record Exist 
                dsDocumenteExists = dbDocumentStatusData.DocumentExistRO(VillageCode, DocumentNo, DocType);
                if (dsDocumenteExists.Tables[0].Rows.Count == 0)
                {
                    //string ModifiedSurveyNo = dbDocumentStatusData.surveyno;
                    //dbDocumentStatusData.surveyno = ModifiedSurveyNo.Replace("'", "");
                    dbDocumentStatusData.surveyno = "";
                    dbDocumentStatusData.familyno = "";
                    dbDocumentStatusData.titlesearchno = "";
                    dbDocumentStatusData.officename = "HO";
                    bool DocInsert = dbDocumentStatusData.AddDocumentStatus();
                }
                else
                {
                    bool DocumentFileUpdate = dbDocumentStatusData.UpdateDocumentStatusFile();
                    if (DocumentFileUpdate)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('New File Not Uploaded');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('New File updated');", true);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ShowUploadedDocuments()
        {
            DataSet dsGetAllDocuments;
            dsGetAllDocuments = dbDocumentStatusData.GetDocumentexecutionHO(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString(), "HO");
            if (dsGetAllDocuments.Tables[0].Rows.Count > 0)
            {
                //string UploadedDocument = dsGetAllDocuments.Tables[0].Rows[0]["documentname"].ToString();
                //if(UploadedDocument != "")
                //{
                for (int i = 0; i < dsGetAllDocuments.Tables[0].Rows.Count; i++)
                {
                    string UploadedDocument = dsGetAllDocuments.Tables[0].Rows[i]["documentname"].ToString();
                    string DocumentCode = dsGetAllDocuments.Tables[0].Rows[i]["documentcode"].ToString();
                    if (DocumentCode == "VP") { lbllinkVisarPavti.Text = UploadedDocument; }
                    if (DocumentCode == "ATS") { lbllnkAgreementToSale.Text = UploadedDocument; }
                    if (DocumentCode == "SD") { lbllinkSaleDeed.Text = UploadedDocument; }
                    if (DocumentCode == "GPA") { lbllnkPowerOfAttorney.Text = UploadedDocument; }
                    if (DocumentCode == "TP") { lbllnkTabaPavti.Text = UploadedDocument; }
                    if (DocumentCode == "GP") { lblLinkGhoshanaPatra.Text = UploadedDocument; }
                    if (DocumentCode == "HP") { lblLinkHamiPatra.Text = UploadedDocument; }
                }
                //}
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Documents not uploaded');", true);
                lblLinkGhoshanaPatra.Text = "";
                lblLinkHamiPatra.Text = "";
                lbllinkSaleDeed.Text = "";
                lbllinkVisarPavti.Text = "";
                lbllnkAgreementToSale.Text = "";
                lbllnkPowerOfAttorney.Text = "";
                lbllnkTabaPavti.Text = "";
                lblLinkPN.Text = "";
            }
        }

        protected void btnPN_Click(object sender, EventArgs e)
        {
            if (FileUploadPN.HasFiles)
            {
                try
                {
                    GenerateFileName("PN", FileUploadPN, lblLinkPN);
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void lblLinkPN_Click(object sender, EventArgs e)
        {
            if (lblLinkPN.Text != "File Not Uploaded")
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + lblLinkPN.Text);
                Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lblLinkPN.Text));
                Response.End();
            }
        }


        //
    }
}