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

namespace LandSurvey.SOOne
{
    public partial class SOSubmitDocuments : System.Web.UI.Page
    {
        DataSet dsVillage = new DataSet();
        dbVillage dbVillageData = new dbVillage();

        DataSet dsFamilyDocNoNew = new DataSet();
        dbFamilyDetails dbFamilyDetailsData = new dbFamilyDetails();

        DataSet dsShowAllDocData = new DataSet();

        dbFileNo dbFileNoData = new dbFileNo();
        dbFamilyDetails dbFamilyDetailsUpdateAll = new dbFamilyDetails();
       
        DataSet dsFamilyDocumnetNo = new DataSet();
       // dbFileNo dbFileNoData = new dbFileNo();
        dbDocument dbDocumentStatusData = new dbDocument();
        DataSet dsDocumenttitleSearch = new DataSet();
        DataSet dsDocumenteExists = new DataSet();

        DataSet dsDocumentExitsShow = new DataSet();
        dbDocument dbDocumentStatusDataShow = new dbDocument();
      //  dbFamilyDetails dbFamilyDetailsUpdateAll = new dbFamilyDetails();

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
                    ButtonDisabled();

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
                cmbDocumentNo.Items.Clear();
                grdFamilyDocDetails.DataSource = null;
                grdFamilyDocDetails.DataBind();
                ButtonDisabled();
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
                // For Mutation Register 
                int DocFileNo = Convert.ToInt32(dbFileNoData.getFileNo("DOCNO"));
                txtDocNo.Text = "TS_" + cmbVillage.SelectedValue.ToString() + "_" + cmbDocumentNo.SelectedValue.ToString() + "_" + DocFileNo.ToString("000");
                //Show Mutation Register 
                dsDocumentExitsShow = dbDocumentStatusDataShow.DocumentExistMSR(cmbVillage.SelectedValue.ToString().Trim(), cmbDocumentNo.SelectedValue.ToString().Trim(), "MSR");
                if (dsDocumentExitsShow.Tables[0].Rows.Count > 0)
                {
                    lbllinkMR.Text = dsDocumentExitsShow.Tables[0].Rows[0]["documentname"].ToString();
                }
                else
                {
                    lbllinkMR.Text = "File Not Uploaded";
                }
                //For Other Document 
               // int DocFileNoOther = Convert.ToInt32(dbFileNoData.getFileNo("DOCNO"));
                txtDocNo.Text = "TS_" + cmbVillage.SelectedValue.ToString() + "_" + cmbDocumentNo.SelectedValue.ToString() + "_" + DocFileNo.ToString("000");
                //Show Mutation Register 
                dsDocumentExitsShow = dbDocumentStatusDataShow.DocumentExistMSR(cmbVillage.SelectedValue.ToString().Trim(), cmbDocumentNo.SelectedValue.ToString().Trim(), "ODMS");
                if (dsDocumentExitsShow.Tables[0].Rows.Count > 0)
                {
                    LinkBtnOtherDoc.Text = dsDocumentExitsShow.Tables[0].Rows[0]["documentname"].ToString(); 
                }
                else
                {
                    LinkBtnOtherDoc.Text = "File Not Uploaded";
                }
            }
        }

        protected void ShowAllDocumentData()
        {
            if (cmbVillage.SelectedIndex > 0 & cmbDocumentNo.SelectedIndex > 0)
            {

                dsShowAllDocData = dbFamilyDetailsData.getSO1SubmitDocument(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString());
                if (dsShowAllDocData.Tables[0].Rows.Count > 0)
                {
                  //  DataTable FamilyDocDetails = dsShowAllDocData.Tables[0];
                    grdFamilyDocDetails.DataSource = dsShowAllDocData;
                    grdFamilyDocDetails.DataBind();
                    ButtonEnable();

                }
                else
                {
                    grdFamilyDocDetails.DataSource = null;
                    grdFamilyDocDetails.DataBind();

                }
            }

        }

        protected void grdFamilyDocDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdFamilyDocDetails.PageIndex = e.NewPageIndex;
            ShowAllDocumentData();
        }

        protected void lbllinkMR_Click(object sender, EventArgs e)
        {
            string FileExist = Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lbllinkMR.Text);
            if (File.Exists(FileExist))
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + lbllinkMR.Text);
                Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lbllinkMR.Text));
                Response.End();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Selected File Not exists on Storage');", true);
                ShowAllDocumentData();
                
            }
        }

      

        protected void btnMSR_Click(object sender, EventArgs e)
        {
            string VillageCodeSel = cmbVillage.SelectedValue.ToString();
            string DocmentNoSel = cmbDocumentNo.SelectedValue.ToString();
            DataSet dsMSRFileName = dbFamilyDetailsData.GetFileNameFromDocumentStatus(VillageCodeSel, DocmentNoSel, "MSR");
            if (dsMSRFileName.Tables[0].Rows.Count > 0)
            {


                string MutationRegister = dsMSRFileName.Tables[0].Rows[0]["documentname"].ToString();
                string FilePath = Server.MapPath("~/Documents/" + VillageCodeSel + "/" + MutationRegister);
                if (!File.Exists(FilePath))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Selected Survey No Mutation Register Not available');", true);
                }
                else
                {
                    Response.Clear();
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + MutationRegister);
                    Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + MutationRegister));
                    Response.End();


                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Mutation Register Not Uploaded by Head Office');", true);
            }
        }

        protected void LinkBtnOtherDoc_Click(object sender, EventArgs e)
        {
            string FileExist = Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + LinkBtnOtherDoc.Text);
            if (File.Exists(FileExist))
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + LinkBtnOtherDoc.Text);
                Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + LinkBtnOtherDoc.Text));
                Response.End();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Selected File Not exists on Storage');", true);
                ShowAllDocumentData();

            }
        }

        protected void btnMutationRemarkSave_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFiles)
            {
                if (cmbVillage.SelectedIndex > 0 & cmbDocumentNo.SelectedIndex > 0)
                {
                    DataSet dsFamilyDocumnetNoGridData = dbFamilyDetailsData.getFamilyOnDocumentSearch(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString());
                    if (dsFamilyDocumnetNoGridData.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            //bool validateCMB = CheckcmbValue();
                            //if (validateCMB)
                            //{
                                string registerFileNo = dbFileNoData.getFileNo("MSR");
                                string filename = Path.GetFileName(FileUploadControl.FileName);
                                string fileExtension = System.IO.Path.GetExtension(FileUploadControl.PostedFile.FileName);
                                string VillageCodeFolder = cmbVillage.SelectedValue.ToString().Trim();
                                string FamilyDocNo = cmbDocumentNo.SelectedValue.ToString().Trim();
                                string NewFileName = "MSR_" + VillageCodeFolder + "_" + FamilyDocNo + "_" + registerFileNo + fileExtension;
                                string folderName = Server.MapPath("~/Documents/" + VillageCodeFolder + "/");
                                if (!Directory.Exists(folderName))
                                {
                                    Directory.CreateDirectory(folderName);
                                }
                                FileUploadControl.SaveAs(folderName + NewFileName);
                                //update MR File Number
                                dbFileNoData.registername = "MSR";
                                dbFileNoData.currentno = Convert.ToInt32(registerFileNo) + 1;
                                dbFileNoData.UpdateFileNo();
                                lbllinkMR.Text = NewFileName;
                                string FinalPath = folderName + NewFileName;
                                ViewState["filepath"] = FinalPath;

                                InsertDocumentStatus("MSR", NewFileName);

                                //Update family Details Table with Doc No 
                                for (int i = 0; i < dsFamilyDocumnetNoGridData.Tables[0].Rows.Count; i++)
                                {
                                    dbFamilyDetailsUpdateAll.villagecode = cmbVillage.SelectedValue.ToString().Trim();
                                    // dbFamilyDetailsUpdateAll.familyno = cmbFamily.SelectedValue.ToString().Trim();
                                    dbFamilyDetailsUpdateAll.surveyno = dsFamilyDocumnetNoGridData.Tables[0].Rows[i]["surveyno"].ToString();
                                    dbFamilyDetailsUpdateAll.docno = cmbDocumentNo.SelectedValue.ToString().Trim();
                                    dbFamilyDetailsUpdateAll.documentno = txtDocNo.Text;
                                    bool updateFamilyDetailDocNo = dbFamilyDetailsUpdateAll.UpdateFamilyDetailDocNo();
                                    if (updateFamilyDetailDocNo)
                                    {

                                    }
                                    else
                                    {

                                    }
                                }
                                //update DOCNO File Number
                                string CurrentDocNO = txtDocNo.Text.Substring(txtDocNo.Text.Length - 3);
                                //string fileExtension = filename.Substring(filename.Length - 3);
                                dbFileNoData.registername = "DOCNO";
                                dbFileNoData.currentno = Convert.ToInt32(CurrentDocNO) + 1;
                                dbFileNoData.UpdateFileNo();
                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Mutation Remark File uploaded Successfully : ');" + txtDocNo.Text, true);
                                ShowAllDocumentData();
                               // btnMutationRemarkSave.Enabled = false;

                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }




            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Mutation Register to upload');", true);
                ShowAllDocumentData();
                    
            }
        }

        private bool InsertDocumentStatus(string DocType, string fileName)
        {
            if (cmbDocumentNo.SelectedIndex < 0 )
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Document Number');", true);
                return false;
            }
            else if (txtDocNo.Text.Length < 3)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Document Number');", true);
                return false;
            }
            else if (cmbVillage.SelectedIndex < 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select Village');", true);
                return false;
            }
            else
            {
                string DocumentID = dbDocumentStatusData.getDocumentSeqNo();
                dbDocumentStatusData.documentid = Convert.ToInt32(DocumentID);
                dbDocumentStatusData.villagecode = cmbVillage.SelectedValue.ToString().Trim();
                //dbDocumentStatusData.familyno = cmbFamily.SelectedValue.ToString().Trim();
                dbDocumentStatusData.familyno = "";
                dbDocumentStatusData.surveyno = "";
                //Check Existing Title Search Exist 
                //dsDocumenttitleSearch = dbDocumentStatusData.DocumentTitleExist(cmbVillage.SelectedValue.ToString().Trim(), cmbFamily.SelectedValue.ToString().Trim(), cmbFamilySurvey.SelectedValue.ToString().Trim());
                dsDocumenttitleSearch = dbDocumentStatusData.DocumentTitleExistRO(cmbVillage.SelectedValue.ToString().Trim(), cmbDocumentNo.SelectedValue.ToString().Trim());
                if (dsDocumenttitleSearch.Tables[0].Rows.Count > 0)
                {

                    dbDocumentStatusData.titlesearchno = dsDocumenttitleSearch.Tables[0].Rows[0]["titlesearchno"].ToString();

                }
                else
                {
                    dbDocumentStatusData.titlesearchno = txtDocNo.Text.ToString();
                }
                dbDocumentStatusData.documentcode = DocType;
                dbDocumentStatusData.documentname = fileName;
                dbDocumentStatusData.documentpath = ViewState["filepath"].ToString();
                dbDocumentStatusData.createdby = Session["UserName"].ToString();
                dbDocumentStatusData.createddate = DateTime.Today;
                dbDocumentStatusData.docno = cmbDocumentNo.SelectedValue.ToString().Trim();
                //Check For Record Exist 
                dsDocumenteExists = dbDocumentStatusData.DocumentExistRO(cmbVillage.SelectedValue.ToString().Trim(), cmbDocumentNo.SelectedValue.ToString().Trim(), DocType);
                if (dsDocumenteExists.Tables[0].Rows.Count == 0)
                {
                    string ModifiedSurveyNo = dbDocumentStatusData.surveyno;
                    dbDocumentStatusData.surveyno = ModifiedSurveyNo.Replace("'", "");
                    bool DocInsert = dbDocumentStatusData.AddDocumentStatus();
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('File Already exist now updating');", true);
                    // ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "element.onclick = function(){ return confirm('Are you sure you want to delete?'); };",true);
                    bool DocumentFileUpdate = dbDocumentStatusData.UpdateDocumentStatusFile();
                    if (DocumentFileUpdate)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('New File Not Updated');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('New File updated');", true);
                    }
                }
                return true;
            }

        }

        protected void btnOtherDocument_Click(object sender, EventArgs e)
        {
            if (FileUploadOther.HasFiles)
            {
                try
                {
                    GenerateFileName("ODMS", FileUploadOther, LinkBtnOtherDoc);

                    //InsertDocumentStatus("MSR", NewFileName);

                }
                catch (Exception ex)
                {


                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Public Notice File to Upload');", true);
            }

            //
            ////if (FileUploadOther.HasFiles)
            ////{
            ////    if (cmbVillage.SelectedIndex > 0 & cmbDocumentNo.SelectedIndex > 0)
            ////    {
            ////        DataSet dsFamilyDocumnetNoGridData = dbFamilyDetailsData.getFamilyOnDocumentSearch(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString());
            ////        if (dsFamilyDocumnetNoGridData.Tables[0].Rows.Count > 0)
            ////        {
            ////            try
            ////            {
            ////                string registerFileNo = dbFileNoData.getFileNo("ODMS");
            ////                string filename = Path.GetFileName(FileUploadOther.FileName);
            ////                string fileExtension = System.IO.Path.GetExtension(FileUploadOther.PostedFile.FileName);
            ////                string VillageCodeFolder = cmbVillage.SelectedValue.ToString().Trim();
            ////                string FamilyDocNo = cmbDocumentNo.SelectedValue.ToString().Trim();
            ////                string NewFileName = "ODMS_" + VillageCodeFolder + "_" + FamilyDocNo + "_" + registerFileNo + fileExtension;
            ////                string folderName = Server.MapPath("~/Documents/" + VillageCodeFolder + "/");
            ////                if (!Directory.Exists(folderName))
            ////                {
            ////                    Directory.CreateDirectory(folderName);
            ////                }
            ////                FileUploadControl.SaveAs(folderName + NewFileName);
            ////                //update MR File Number
            ////                dbFileNoData.registername = "ODMS";
            ////                dbFileNoData.currentno = Convert.ToInt32(registerFileNo) + 1;
            ////                dbFileNoData.UpdateFileNo();
            ////                LinkBtnOtherDoc.Text = NewFileName;
            ////                string FinalPath = folderName + NewFileName;
            ////                ViewState["filepath"] = FinalPath;

            ////                InsertDocumentStatus("ODMS", NewFileName);

            ////                //Update family Details Table with Doc No 
            ////                for (int i = 0; i < dsFamilyDocumnetNoGridData.Tables[0].Rows.Count; i++)
            ////                {
            ////                    dbFamilyDetailsUpdateAll.villagecode = cmbVillage.SelectedValue.ToString().Trim();
            ////                    // dbFamilyDetailsUpdateAll.familyno = cmbFamily.SelectedValue.ToString().Trim();
            ////                    dbFamilyDetailsUpdateAll.surveyno = dsFamilyDocumnetNoGridData.Tables[0].Rows[i]["surveyno"].ToString();
            ////                    dbFamilyDetailsUpdateAll.docno = cmbDocumentNo.SelectedValue.ToString().Trim();
            ////                    dbFamilyDetailsUpdateAll.documentno = txtDocNo.Text;
            ////                    bool updateFamilyDetailDocNo = dbFamilyDetailsUpdateAll.UpdateFamilyDetailDocNo();
            ////                    if (updateFamilyDetailDocNo)
            ////                    {

            ////                    }
            ////                    else
            ////                    {

            ////                    }
            ////                }
            ////                //update DOCNO File Number
            ////                string CurrentDocNO = txtDocNo.Text.Substring(txtDocNo.Text.Length - 3);
            ////                //string fileExtension = filename.Substring(filename.Length - 3);
            ////                dbFileNoData.registername = "DOCNO";
            ////                dbFileNoData.currentno = Convert.ToInt32(CurrentDocNO) + 1;
            ////                dbFileNoData.UpdateFileNo();
            ////                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Other Document File Uploaded Successfully ');" + txtDocNo.Text, true);
            ////                ShowAllDocumentData();
            ////               // btnMutationRemarkSave.Enabled = false;

            ////            }
            ////            catch (Exception ex)
            ////            {

            ////            }
            ////        }
            //    }




            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Other Document to upload');", true);
            //    ShowAllDocumentData();

            //}
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
                    dbDocumentStatusData.officename = "SO1";
                    bool DocInsert = dbDocumentStatusData.AddDocumentStatus();
                    if (DocInsert)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('New File Not Uploaded');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('New Other Document File Uploaded');", true);
                    }
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
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('New Other Document File Update');", true);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void grdFamilyDocDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ButtonEnable()
        {
            
            btnMutationRemarkSave.Enabled = true;
            btnOtherDocument.Enabled = true;
            FileUploadControl.Enabled = true;
            FileUploadOther.Enabled = true;
            LinkBtnOtherDoc.Enabled = true;
            lbllinkMR.Enabled = true;
        }

        private void ButtonDisabled()
        {
            btnMutationRemarkSave.Enabled = false;
            btnOtherDocument.Enabled = false;
            FileUploadControl.Enabled = false;
            FileUploadOther.Enabled = false;
            LinkBtnOtherDoc.Enabled = false;
            lbllinkMR.Enabled = false;
            LinkBtnOtherDoc.Text = "";
            lbllinkMR.Text = "";


        }

        protected void btnOtherDocuments_Click(object sender, EventArgs e)
        {
            string VillageCode = cmbVillage.SelectedValue.ToString();
            string DocNo = cmbDocumentNo.SelectedValue.ToString();
            Response.Redirect(String.Format("SO1OtherDocument.aspx?Village={0}&Doc={1}", Server.UrlEncode(VillageCode), Server.UrlEncode(DocNo)));
        }
        //
    }
}