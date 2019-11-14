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

namespace LandSurvey.SOTwo
{
    public partial class SO2UploadDocuments : System.Web.UI.Page
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
                    //btnMSR.Enabled = false;
                    btnOtherDocument.Enabled = false;
                }
                else
                {
                    DataTable dt = new DataTable();
                    grdFamilyDocDetails.DataSource = dt;
                    grdFamilyDocDetails.DataBind();

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
               // lbllnkRegistrySearch.Text = "";
                cmbDocumentNo.Items.Clear();
                grdFamilyDocDetails.DataSource = null;
                grdFamilyDocDetails.DataBind();
               // btnMSR.Enabled = false;

                btnOtherDocument.Enabled = false;
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
                ShowAllDocumentData();
            }
        }

        protected void ShowAllDocumentData()
        {
            if (cmbVillage.SelectedIndex > 0 & cmbDocumentNo.SelectedIndex > 0)
            {
              //  lbllnkRegistrySearch.Text = "";
                dsShowAllDocData = dbFamilyDetailsData.getSO1SubmitDocument(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString());
                if (dsShowAllDocData.Tables[0].Rows.Count > 0)
                {
                   // DataTable FamilyDocDetails = dsShowAllDocData.Tables[0];
                    grdFamilyDocDetails.DataSource = dsShowAllDocData;
                    grdFamilyDocDetails.DataBind();
                 //   btnMSR.Enabled = true;
                    btnOtherDocument.Enabled = true;
                    ShowDocumentsRSR();

                }
                else
                {
                    grdFamilyDocDetails.DataSource = null;
                    grdFamilyDocDetails.DataBind();
                    //btnMSR.Enabled = false;
                    btnOtherDocument.Enabled = false;

                }
            }

        }

        protected void grdFamilyDocDetails_ServerPdfExporting(object sender, Syncfusion.JavaScript.Web.GridEventArgs e)
        {

        }

        protected void btnOtherDocument_Click(object sender, EventArgs e)
        {
            string VillageCode = cmbVillage.SelectedValue.ToString();
            string DocNo = cmbDocumentNo.SelectedValue.ToString();
            Response.Redirect(String.Format("SO2OtherDocument.aspx?Village={0}&Doc={1}", Server.UrlEncode(VillageCode), Server.UrlEncode(DocNo)));
        }

        protected void grdFamilyDocDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdFamilyDocDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdFamilyDocDetails.PageIndex = e.NewPageIndex;
            ShowAllDocumentData();
        }

        protected void btnMSR_Click(object sender, EventArgs e)
        {
            //if (FileUploadARegistrySearch.HasFiles)
            //{
            //    try
            //    {
            //        GenerateFileName("RSR", FileUploadARegistrySearch, lbllnkRegistrySearch);

            //        //InsertDocumentStatus("MSR", NewFileName);

            //    }
            //    catch (Exception ex)
            //    {


            //    }

            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Family Tree File to Upload');", true);
            //}
        

        //    string VillageCodeSel = cmbVillage.SelectedValue.ToString();
        //    string DocmentNoSel = cmbDocumentNo.SelectedValue.ToString();
        //    DataSet dsMSRFileName = dbFamilyDetailsData.GetFileNameFromDocumentStatus(VillageCodeSel, DocmentNoSel, "MSR");
        //    if (dsMSRFileName.Tables[0].Rows.Count > 0)
        //    {


        //        string MutationRegister = dsMSRFileName.Tables[0].Rows[0]["documentname"].ToString();
        //        string FilePath = Server.MapPath("~/Documents/" + VillageCodeSel + "/" + MutationRegister);
        //        if (!File.Exists(FilePath))
        //        {
        //            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Selected Survey No Mutation Register Not available');", true);
        //        }
        //        else
        //        {
        //            Response.Clear();
        //            Response.ContentType = "application/octet-stream";
        //            Response.AddHeader("Content-Disposition", "attachment; filename=" + MutationRegister);
        //            Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + MutationRegister));
        //            Response.End();


        //        }
        //    }
    }

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
                dbDocumentStatusData.villagecode = cmbVillage.SelectedValue.ToString();
                dbDocumentStatusData.documentcode = DocType;
                dbDocumentStatusData.documentname = NewFileName;
                dbDocumentStatusData.documentpath = ViewState["filepath"].ToString();
                dbDocumentStatusData.createdby = Session["UserName"].ToString();
                dbDocumentStatusData.createddate = DateTime.Today;
                dbDocumentStatusData.docno = cmbDocumentNo.SelectedValue.ToString();
                //Check For Record Exist 
                dsDocumenteExists = dbDocumentStatusData.DocumentExistRO(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString(), DocType);
                if (dsDocumenteExists.Tables[0].Rows.Count == 0)
                {
                    //string ModifiedSurveyNo = dbDocumentStatusData.surveyno;
                    //dbDocumentStatusData.surveyno = ModifiedSurveyNo.Replace("'", "");
                    dbDocumentStatusData.surveyno = "";
                    dbDocumentStatusData.familyno = "";
                    dbDocumentStatusData.titlesearchno = "";
                    dbDocumentStatusData.officename = "SO2";
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

        private void ShowDocumentsRSR()
        {
            //DataSet dsGetAllDocuments;
            //dsGetAllDocuments = dbDocumentStatusData.DocumentExistInDocStatus(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString(), "RSR", "SO2");
            //if (dsGetAllDocuments.Tables[0].Rows.Count > 0)
            //{
               
            //    for (int i = 0; i < dsGetAllDocuments.Tables[0].Rows.Count; i++)
            //    {
            //        string UploadedDocument = dsGetAllDocuments.Tables[0].Rows[i]["documentname"].ToString();
            //        string DocumentCode = dsGetAllDocuments.Tables[0].Rows[i]["documentcode"].ToString();
            //        if (DocumentCode == "RSR") { lbllnkRegistrySearch.Text = UploadedDocument; }
            //        //if (DocumentCode == "LI") { lbllnkLocalInquiry.Text = UploadedDocument; }
            //        //if (DocumentCode == "FT") { lbllinkFamilyTree.Text = UploadedDocument; }
            //        //if (DocumentCode == "CL") { lbllnkConcentLetter.Text = UploadedDocument; }
            //        //if (DocumentCode == "ID") { lbllnkIDDoc.Text = UploadedDocument; }
            //    }
            //    //}
            //}
            //else
            //{
            //   // ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Some Required Documents not uploaded');", true);
            //}
        }

        protected void lbllnkRegistrySearch_Click(object sender, EventArgs e)
        {
            //Response.Clear();
            //Response.ContentType = "application/octet-stream";
            //Response.AddHeader("Content-Disposition", "attachment; filename=" + lbllnkRegistrySearch.Text);
            //Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lbllnkRegistrySearch.Text));
            //Response.End();
        }
        //
    }
}