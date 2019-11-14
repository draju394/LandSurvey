using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LandSurvey.DAL;
using System.Data;
using System.IO;

namespace LandSurvey.Execuation
{
    public partial class DocExecution : System.Web.UI.Page
    {
        DataSet dsDistrict = new DataSet();
        dbDistrict dbDistrictData = new dbDistrict();

        DataSet dsTaluka = new DataSet();
        dbTaluka dbTalukaData = new dbTaluka();

        DataSet dsVillage = new DataSet();
        dbVillage dbVillageData = new dbVillage();

        DataSet dsFamilyMaster = new DataSet();
        DataSet dsFamilyAreaStatus = new DataSet();
        dbFamilyMaster dbFamilyMasterData = new dbFamilyMaster();

        DataSet dsFamilySurvey = new DataSet();
        DataSet dsSurveyArea = new DataSet();
        dbFamilySurvey dbfamilySurveyData = new dbFamilySurvey();
        dbFamilySurvey dbFamilySurveyUpdate = new dbFamilySurvey();

        DataSet dsFamilyDetails = new DataSet();
        dbFamilyDetails dbFamilyDetailsData = new dbFamilyDetails();
        dbFamilyDetails dbFamilyDetailsUpdateData = new dbFamilyDetails();
        dbFamilyDetails dbFamilyDetailsUpdateAll = new dbFamilyDetails();
        DataSet dsFileNumber = new DataSet();
        dbFileNo dbFileNoData = new dbFileNo();

        DataSet dsDocumentStatus = new DataSet();
        DataSet dsDocumentexists = new DataSet();
        DataSet dsDocumentExitsIN = new DataSet();
        DataSet dsDocumenttitleSearch = new DataSet();
        dbDocument dbDocumentStatusData = new dbDocument();

        DataSet dsFamilyDocNoNew = new DataSet();

        DataSet dsChkListTran = new DataSet();
        dbChkListTran dbChkListTranData = new dbChkListTran();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ////District 
                //cmbDistrict.Enabled = false;
                //dsDistrict = dbDistrictData.getDistrictData();
                //if (dsDistrict.Tables[0].Rows.Count > 0)
                //{
                //    cmbDistrict.DataSource = dsDistrict.Tables[0].DefaultView;
                //    cmbDistrict.DataBind();
                //    cmbDistrict.DataTextField = dsDistrict.Tables[0].Columns["districtmname"].ToString();
                //    cmbDistrict.DataValueField = dsDistrict.Tables[0].Columns["districtid"].ToString();
                //    cmbDistrict.DataBind();
                //}

                //// Taluka 
                //cmbTaluka.Enabled = false;
                //dsTaluka = dbTalukaData.getTalukaDataOnDistrict(1);
                //if (dsTaluka.Tables[0].Rows.Count > 0)
                //{
                //    cmbTaluka.DataSource = dsTaluka.Tables[0].DefaultView;
                //    cmbTaluka.DataBind();
                //    cmbTaluka.DataTextField = dsTaluka.Tables[0].Columns["talukamname"].ToString();
                //    cmbTaluka.DataValueField = dsTaluka.Tables[0].Columns["talukaid"].ToString();
                //    cmbTaluka.DataBind();
                //}

                //village
                dsVillage = dbVillageData.getVillageData();
                if (dsVillage.Tables[0].Rows.Count > 0)
                {
                    cmbVillage.DataSource = dsVillage.Tables[0].DefaultView;
                    cmbVillage.DataBind();
                    cmbVillage.DataTextField = dsVillage.Tables[0].Columns["villagemname"].ToString();
                    cmbVillage.DataValueField = dsVillage.Tables[0].Columns["villagecode"].ToString();
                    cmbVillage.DataBind();


                }

                DataTable dt = new DataTable();
                grdHolderName.DataSource = dt;
                grdHolderName.DataBind();

                grdCheckList.DataSource = dt;
                grdCheckList.DataBind();

                btnSaveDocNo.Enabled = false;
            }
        }

        protected void cmbVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVillage.SelectedIndex == -1)
            {
                // MessageBox.Show("Please select vaild District name");
                //cmbVillage.Select();
            }
            else
            {
                cmbFamily.Items.Clear();
                string selectedVillage = cmbVillage.SelectedValue.ToString().Trim();

                dsFamilyMaster = dbFamilyMasterData.getFamilyMasterCmb(selectedVillage);
                if (dsFamilyMaster.Tables[0].Rows.Count > 0)
                {
                    cmbFamily.DataSource = dsFamilyMaster.Tables[0].DefaultView;
                    cmbFamily.DataBind();
                    cmbFamily.DataTextField = dsFamilyMaster.Tables[0].Columns["familyno"].ToString();
                    cmbFamily.DataValueField = dsFamilyMaster.Tables[0].Columns["familyno"].ToString();
                    cmbFamily.DataBind();


                }
            }
        }

        protected void cmbFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFamily.SelectedIndex == -1)
            {
                // MessageBox.Show("Please select vaild District name");
                //cmbVillage.Select();
            }
            else
            {

                string selectedVillage = cmbVillage.SelectedValue.ToString().Trim();
                string selectFamilyNo = cmbFamily.SelectedValue.ToString().Trim();
                // Fill Document No Cmb box as per 15 Aug 
                dsFamilyDocNoNew = dbFamilyDetailsData.getFamilyDetailsDocumentNoNew(selectedVillage, selectFamilyNo);
                if (dsFamilyDocNoNew.Tables[0].Rows.Count > 0)
                {
                    cmbFamilyDocNo.DataSource = dsFamilyDocNoNew.Tables[0].DefaultView;
                    cmbFamilyDocNo.DataBind();
                    cmbFamilyDocNo.DataTextField = dsFamilyDocNoNew.Tables[0].Columns["docno"].ToString();
                    cmbFamilyDocNo.DataValueField = dsFamilyDocNoNew.Tables[0].Columns["docno"].ToString();
                    cmbFamilyDocNo.DataBind();


                }


                dsFamilySurvey = dbfamilySurveyData.getFamilySurveyCmb(selectedVillage, selectFamilyNo);
                if (dsFamilySurvey.Tables[0].Rows.Count > 0)
                {
                    //List Box with Multiple Selection 
                    lstBoxSurveyNo.DataSource = dsFamilySurvey.Tables[0].DefaultView;
                    lstBoxSurveyNo.DataBind();
                    lstBoxSurveyNo.DataTextField = dsFamilySurvey.Tables[0].Columns["surveyno"].ToString();
                    lstBoxSurveyNo.DataValueField = dsFamilySurvey.Tables[0].Columns["surveyno"].ToString();
                    lstBoxSurveyNo.DataBind();
                    //Document Number
                    int DocFileNo = Convert.ToInt32(dbFileNoData.getFileNo("DOCNO"));
                    txtDocNo.Text = "TS_" + selectedVillage + "_" + selectFamilyNo + "_" + DocFileNo.ToString("000");
                }
                //Get Area and Status
                lblFamilyTotArea.Text = "";
                lblStatus.Text = "";
                dsFamilyAreaStatus = dbFamilyMasterData.getFamilyAreaStatus(cmbFamily.SelectedValue.ToString(), cmbVillage.SelectedValue.ToString());
                if (dsFamilyAreaStatus.Tables[0].Rows.Count == 1)
                {
                    lblFamilyTotArea.Text = dsFamilyAreaStatus.Tables[0].Rows[0]["totalarea"].ToString();
                    String strStatusFamily = dsFamilyAreaStatus.Tables[0].Rows[0]["status"].ToString();
                    if (strStatusFamily == "N")
                    { lblStatus.Text = "Not Aquired"; }
                    else { lblStatus.Text = "Aquired"; };

                }

            }
        }

        protected void grdHolderName_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            grdHolderName.PageIndex = e.NewPageIndex;
        }

        private bool CheckcmbValue()
        {
            if (cmbFamily.SelectedIndex < 0)
            {
                return false;
            }
            else if (cmbVillage.SelectedIndex < 0)
            {
                return false;
            }
            else
            {
                return true;
            }


        }

        protected void btnMutation_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                lbllinkMR.Text = "";
                // Village_Code: 01, Family_No: 60, TSN_No: 01 and if Mutation Reg PDF is
                //uploaded the Name should be MR_01_60_01_001
                //   Last 001 is the Running Mutation Number

                try
                {
                    bool validateCMB = CheckcmbValue();
                    if (validateCMB)
                    {

                        string registerFileNo = dbFileNoData.getFileNo("MR");
                        string filename = Path.GetFileName(FileUploadControl.FileName);
                        //string fileExtension = filename.Substring(filename.Length - 3);
                        string fileExtension = System.IO.Path.GetExtension(FileUploadControl.PostedFile.FileName);
                        string VillageCodeFolder = cmbVillage.SelectedValue.ToString().Trim();
                        string FamilyNoName = cmbFamily.SelectedValue.ToString().Trim();
                        string NewFileName = "MR_" + VillageCodeFolder + "_" + FamilyNoName + "_" + registerFileNo + fileExtension;
                        //  string NewFileName = "MR_" + VillageCodeFolder + "_" + FamilyNoName + "_" + registerFileNo + "." + fileExtension;
                        string folderName = Server.MapPath("~/Documents/" + VillageCodeFolder + "/");
                        if (!Directory.Exists(folderName))
                        {
                            Directory.CreateDirectory(folderName);
                        }
                        FileUploadControl.SaveAs(folderName + NewFileName);
                        //FileUploadControl.SaveAs(folderName + filename);
                        // FileUploadControl.SaveAs(Server.MapPath("~/Documents/") + filename);
                        // StatusLabel.Text = "Upload status: File uploaded!";

                        //update MR File Number
                        dbFileNoData.registername = "MR";
                        dbFileNoData.currentno = Convert.ToInt32(registerFileNo) + 1;
                        dbFileNoData.UpdateFileNo();
                        lbllinkMR.Text = NewFileName;
                        string FinalPath = folderName + NewFileName;
                        ViewState["filepath"] = FinalPath;

                        InsertDocumentStatus("MR", NewFileName);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select Family No, Village and Survey ');", true);
                    }
                }
                catch (Exception ex)
                {
                    // StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Document Not Saved ');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select  File to Upload');", true);
            }
        }

        private bool InsertDocumentStatus(string DocType, string fileName)
        {
            if (txtDocNo.Text.Length < 3)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Document Number');", true);
                return false;
            }
            else if (cmbFamily.SelectedIndex < 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select family number');", true);
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
                dbDocumentStatusData.familyno = cmbFamily.SelectedValue.ToString().Trim();
                dbDocumentStatusData.surveyno = selectedListItems();
                //Check Existing Title Search Exist 
                //dsDocumenttitleSearch = dbDocumentStatusData.DocumentTitleExist(cmbVillage.SelectedValue.ToString().Trim(), cmbFamily.SelectedValue.ToString().Trim(), cmbFamilySurvey.SelectedValue.ToString().Trim());
                dsDocumenttitleSearch = dbDocumentStatusData.DocumentTitleExist(cmbVillage.SelectedValue.ToString().Trim(), cmbFamily.SelectedValue.ToString().Trim(), selectedListItems());
                if (dsDocumenttitleSearch.Tables[0].Rows.Count > 0)
                {

                    dbDocumentStatusData.titlesearchno = dsDocumenttitleSearch.Tables[0].Rows[0]["titlesearchno"].ToString();

                }
                else
                {
                    // dbDocumentStatusData.titlesearchno = cmbVillage.SelectedValue.ToString().Trim() + "_" + cmbFamily.SelectedValue.ToString().Trim() + "-" + cmbFamilySurvey.SelectedValue.ToString().Trim() + "_" + DocumentID;
                    //dbDocumentStatusData.titlesearchno = cmbVillage.SelectedValue.ToString().Trim() + "_" + cmbFamily.SelectedValue.ToString().Trim() + "-" + selectedListItems() + "_" + DocumentID;
                    //string titleSearch = cmbVillage.SelectedValue.ToString().Trim() + "_" + cmbFamily.SelectedValue.ToString().Trim() + "-" + selectedListItems() + "_" + DocumentID;
                    //dbDocumentStatusData.titlesearchno = titleSearch.Replace("'", "");
                    dbDocumentStatusData.titlesearchno = txtDocNo.Text.ToString();
                }

                ///

                dbDocumentStatusData.documentcode = DocType;
                dbDocumentStatusData.documentname = fileName;
                dbDocumentStatusData.documentpath = ViewState["filepath"].ToString();
                dbDocumentStatusData.createdby = "RSD";
                dbDocumentStatusData.createddate = DateTime.Today;
                dbDocumentStatusData.docno = cmbFamilyDocNo.SelectedValue.ToString().Trim();
                //Check For Record Exist 
                dsDocumentexists = dbDocumentStatusData.DocumentExist(cmbVillage.SelectedValue.ToString().Trim(), cmbFamily.SelectedValue.ToString().Trim(), selectedListItems(), DocType);
                if (dsDocumentexists.Tables[0].Rows.Count == 0)
                {
                    string ModifiedSurveyNo = dbDocumentStatusData.surveyno;
                    dbDocumentStatusData.surveyno = ModifiedSurveyNo.Replace("'", "");
                    bool DocInsert = dbDocumentStatusData.AddDocumentStatus();
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('File Already exist now updating');", true);
                    // ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "element.onclick = function(){ return confirm('Are you sure you want to delete?'); };",true);
                    bool DocumentFileUpdate = dbDocumentStatusData.UpdateDocumentFile(selectedListItems());
                    if (DocumentFileUpdate)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('New File updated');", true);
                    }
                }
                return true;
            }

           
        }
        ///RSD -------Here 

        protected void lbllinkMR_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + lbllinkMR.Text);
            Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lbllinkMR.Text));
            Response.End();
        }

        protected void lblLinkDrFile_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + lblLinkDrFile.Text);
            Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lblLinkDrFile.Text));
            Response.End();
        }

        protected void btnRegistration_Click(object sender, EventArgs e)
        {

            if (FileUploadControlDR.HasFile)
            {
                lblLinkDrFile.Text = "";
                // Village_Code: 01, Family_No: 60, TSN_No: 01 and if Mutation Reg PDF is
                //uploaded the Name should be MR_01_60_01_001
                //   Last 001 is the Running Mutation Number

                try
                {
                    bool validateCMB = CheckcmbValue();
                    if (validateCMB)
                    {

                        string registerFileNo = dbFileNoData.getFileNo("DR");
                        string filename = Path.GetFileName(FileUploadControlDR.FileName);
                        //string fileExtension = filename.Substring(filename.Length - 3);
                        string fileExtension = System.IO.Path.GetExtension(FileUploadControlDR.PostedFile.FileName);
                        string VillageCodeFolder = cmbVillage.SelectedValue.ToString().Trim();
                        string FamilyNoName = cmbFamily.SelectedValue.ToString().Trim();
                        string NewFileName = "DR_" + VillageCodeFolder + "_" + FamilyNoName + "_" + registerFileNo + fileExtension;
                        //  string NewFileName = "MR_" + VillageCodeFolder + "_" + FamilyNoName + "_" + registerFileNo + "." + fileExtension;
                        string folderName = Server.MapPath("~/Documents/" + VillageCodeFolder + "/");
                        if (!Directory.Exists(folderName))
                        {
                            Directory.CreateDirectory(folderName);
                        }
                        FileUploadControlDR.SaveAs(folderName + NewFileName);
                        //FileUploadControl.SaveAs(folderName + filename);
                        // FileUploadControl.SaveAs(Server.MapPath("~/Documents/") + filename);
                        // StatusLabel.Text = "Upload status: File uploaded!";

                        //update MR File Number
                        dbFileNoData.registername = "DR";
                        dbFileNoData.currentno = Convert.ToInt32(registerFileNo) + 1;
                        dbFileNoData.UpdateFileNo();
                        lblLinkDrFile.Text = NewFileName;
                        string FinalPath = folderName + NewFileName;
                        ViewState["filepath"] = FinalPath;

                        InsertDocumentStatus("DR", NewFileName);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select Family No, Village and Survey ');", true);
                    }
                }
                catch (Exception ex)
                {
                    // StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select  File to Upload');", true);
            }
        }

        protected void btnPublicNotice_Click(object sender, EventArgs e)
        {
            if (FileUploadControlPN.HasFile)
            {
                lblLinkPR.Text = "";
                // Village_Code: 01, Family_No: 60, TSN_No: 01 and if Mutation Reg PDF is
                //uploaded the Name should be MR_01_60_01_001
                //   Last 001 is the Running Mutation Number

                try
                {
                    bool validateCMB = CheckcmbValue();
                    if (validateCMB)
                    {

                        string registerFileNo = dbFileNoData.getFileNo("PN");
                        string filename = Path.GetFileName(FileUploadControlPN.FileName);
                        string fileExtension = System.IO.Path.GetExtension(FileUploadControlPN.PostedFile.FileName);
                        string VillageCodeFolder = cmbVillage.SelectedValue.ToString().Trim();
                        string FamilyNoName = cmbFamily.SelectedValue.ToString().Trim();
                        string NewFileName = "PN_" + VillageCodeFolder + "_" + FamilyNoName + "_" + registerFileNo + fileExtension;
                        string folderName = Server.MapPath("~/Documents/" + VillageCodeFolder + "/");
                        if (!Directory.Exists(folderName))
                        {
                            Directory.CreateDirectory(folderName);
                        }
                        FileUploadControlPN.SaveAs(folderName + NewFileName);

                        //update PN File Number
                        dbFileNoData.registername = "PN";
                        dbFileNoData.currentno = Convert.ToInt32(registerFileNo) + 1;
                        dbFileNoData.UpdateFileNo();
                        lblLinkPR.Text = NewFileName;
                        string FinalPath = folderName + NewFileName;
                        ViewState["filepath"] = FinalPath;

                        InsertDocumentStatus("PN", NewFileName);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select Family No, Village and Survey ');", true);
                    }
                }
                catch (Exception ex)
                {
                    // StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select  File to Upload');", true);
            }
        }

        protected void btnFinalRemark_Click(object sender, EventArgs e)
        {
            if (FileUploadControlFR.HasFile)
            {
                lblLinkFR.Text = "";
                // Village_Code: 01, Family_No: 60, TSN_No: 01 and if Mutation Reg PDF is
                //uploaded the Name should be MR_01_60_01_001
                //   Last 001 is the Running Mutation Number

                try
                {
                    bool validateCMB = CheckcmbValue();
                    if (validateCMB)
                    {

                        string registerFileNo = dbFileNoData.getFileNo("FR");
                        string filename = Path.GetFileName(FileUploadControlFR.FileName);
                        string fileExtension = System.IO.Path.GetExtension(FileUploadControlFR.PostedFile.FileName);
                        string VillageCodeFolder = cmbVillage.SelectedValue.ToString().Trim();
                        string FamilyNoName = cmbFamily.SelectedValue.ToString().Trim();
                        string NewFileName = "FR_" + VillageCodeFolder + "_" + FamilyNoName + "_" + registerFileNo + fileExtension;
                        string folderName = Server.MapPath("~/Documents/" + VillageCodeFolder + "/");
                        if (!Directory.Exists(folderName))
                        {
                            Directory.CreateDirectory(folderName);
                        }
                        FileUploadControlFR.SaveAs(folderName + NewFileName);

                        //update FR File Number
                        dbFileNoData.registername = "FR";
                        dbFileNoData.currentno = Convert.ToInt32(registerFileNo) + 1;
                        dbFileNoData.UpdateFileNo();
                        lblLinkFR.Text = NewFileName;
                        string FinalPath = folderName + NewFileName;
                        ViewState["filepath"] = FinalPath;

                        InsertDocumentStatus("FR", NewFileName);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select Family No, Village and Survey ');", true);
                    }
                }
                catch (Exception ex)
                {
                    // StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select  File to Upload');", true);
            }



        }

        protected void lblLinkPR_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + lblLinkPR.Text);
            Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lblLinkPR.Text));
            Response.End();
        }

        protected void lblLinkFR_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + lblLinkFR.Text);
            Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lblLinkFR.Text));
            Response.End();
        }

        protected void btnMRTemplate_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + "MRTemplate.docx");
            Response.WriteFile(Server.MapPath(@"~/Docs/" + "MRTemplate.docx"));
            Response.End();
        }

        protected void btnDRTemplate_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + "DPTemplate.docx");
            Response.WriteFile(Server.MapPath(@"~/Docs/" + "DPTemplate.docx"));
            Response.End();
        }

        protected void btnPNTemplate_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + "PNTemplate.docx");
            Response.WriteFile(Server.MapPath(@"~/Docs/" + "PNTemplate.docx"));
            Response.End();
        }

        protected void btnFRTemplate_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + "FRTemplate.docx");
            Response.WriteFile(Server.MapPath(@"~/Docs/" + "FRTemplate.docx"));
            Response.End();
        }

        protected void lstBoxSurveyNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBoxSurveyNo.SelectedIndex == -1)
            {

            }
            else
            {
                lblLinkDrFile.Text = "";
                lbllinkMR.Text = "";
                string selectedVillage = cmbVillage.SelectedValue.ToString().Trim();
                string selectFamilyNo = cmbFamily.SelectedValue.ToString().Trim();
                //
                string selectedSurveyNoMultiple = "";
                foreach (ListItem item in lstBoxSurveyNo.Items)
                {
                    if (item.Selected)
                    {
                        //  selectedSurveyNoMultiple += item.Text + "," + item.Value + "\\n";
                        selectedSurveyNoMultiple += "'" + item.Text + "'" + ",";
                    }
                }

                selectedSurveyNoMultiple = selectedSurveyNoMultiple.Remove(selectedSurveyNoMultiple.Length - 1);
                //

                string selectedSurveyNo = lstBoxSurveyNo.SelectedValue.ToString().Trim();
                //Show Grid Data 
                ShowGridHolderData(selectedVillage, selectFamilyNo, selectedSurveyNoMultiple);

                //dsFamilyDetails = dbFamilyDetailsData.getFamilyDetailsMultipleSurvey(selectedVillage, selectFamilyNo, selectedSurveyNoMultiple);
                if (dsFamilyDetails.Tables[0].Rows.Count > 0)
                {
                    //Added RSD 23-08-2019
                    ShowCheckListGrid(selectedVillage, selectFamilyNo, cmbFamilyDocNo.SelectedValue.ToString().Trim());


                    //Select File Name from Document if Exist 

                    dsDocumentExitsIN = dbDocumentStatusData.DocumentExistIN(cmbVillage.SelectedValue.ToString().Trim(), cmbFamily.SelectedValue.ToString().Trim(), selectedListItems());
                    if (dsDocumentExitsIN.Tables[0].Rows.Count > 0)
                    {
                        string DocType = "";
                        for (int i = 0; i < dsDocumentExitsIN.Tables[0].Rows.Count; i++)
                        {
                            DocType = dsDocumentExitsIN.Tables[0].Rows[i]["documentcode"].ToString();
                            if (DocType == "MR")
                            {
                                lbllinkMR.Text = dsDocumentExitsIN.Tables[0].Rows[i]["documentname"].ToString();
                                lbllinkMR.Text = dsDocumentExitsIN.Tables[0].Rows[i]["documentname"].ToString();
                            }
                            if (DocType == "DR")
                            {
                                lblLinkDrFile.Text = dsDocumentExitsIN.Tables[0].Rows[i]["documentname"].ToString();
                            }
                            if (DocType == "PN")
                            {
                                lblLinkPR.Text = dsDocumentExitsIN.Tables[0].Rows[i]["documentname"].ToString();
                            }
                            if (DocType == "FR")
                            {
                                lblLinkFR.Text = dsDocumentExitsIN.Tables[0].Rows[i]["documentname"].ToString();
                            }
                        }
                    }
                }
                else
                {
                    //lblSurveyArea.Text = "";
                    //grdHolderName.DataSource = null;
                    //grdHolderName.DataBind();
                }

            }
        }

        protected void ShowGridHolderData(string selectedVillage, string selectFamilyNo, string selectedSurveyNoMultiple)
        {
            dsFamilyDetails = dbFamilyDetailsData.getFamilyDetailsMultipleSurvey(selectedVillage, selectFamilyNo, selectedSurveyNoMultiple);
            if (dsFamilyDetails.Tables[0].Rows.Count > 0)
            {
                grdHolderName.DataSource = dsFamilyDetails;
                grdHolderName.DataBind();
                btnSaveDocNo.Enabled = true;
            }
            else
            {
                grdHolderName.DataSource = null;
                grdHolderName.DataBind();

            }

        }
        protected void grdHolderName_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdHolderName.EditIndex = e.NewEditIndex;
            //grdHolderName.DataSource = dsFamilyDetails;
            //grdHolderName.DataBind();
            //cmbVillage.SelectedValue.ToString().Trim(), cmbFamily.SelectedValue.ToString().Trim(), cmbFamilySurvey.SelectedValue.ToString().Trim());
            ShowGridHolderData(cmbVillage.SelectedValue.ToString().Trim(), cmbFamily.SelectedValue.ToString().Trim(), selectedListItems());

        }

        protected void grdHolderName_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (txtDocNo.Text != "")
            {
                Label id = grdHolderName.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
                TextBox SurveyArea = grdHolderName.Rows[e.RowIndex].FindControl("txt_SrArea") as TextBox;
                TextBox SurveyRate = grdHolderName.Rows[e.RowIndex].FindControl("txt_SrRate") as TextBox;
                TextBox HolderArea = grdHolderName.Rows[e.RowIndex].FindControl("txt_HolderArea") as TextBox;
                TextBox AquiredArea = grdHolderName.Rows[e.RowIndex].FindControl("txt_AquiredArea") as TextBox;
                dbFamilyDetailsUpdateData.surveyarea = Convert.ToDouble(SurveyArea.Text.ToString());
                dbFamilyDetailsUpdateData.surveyrate = Convert.ToDouble(SurveyRate.Text.ToString());
                dbFamilyDetailsUpdateData.holderarea = Convert.ToDouble(HolderArea.Text.ToString());
                dbFamilyDetailsUpdateData.areaaquired = Convert.ToDouble(AquiredArea.Text.ToString());
                dbFamilyDetailsUpdateData.familydetailid = Convert.ToInt32(id.Text.ToString());
                dbFamilyDetailsUpdateData.documentno = txtDocNo.Text.ToString();
                Boolean UpdateFamilyDetails = dbFamilyDetailsUpdateData.UpdateFamilyDetails();
                grdHolderName.EditIndex = -1;
                ShowGridHolderData(cmbVillage.SelectedValue.ToString().Trim(), cmbFamily.SelectedValue.ToString().Trim(), selectedListItems());
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Document No');", true);
            }
        }

        protected string selectedListItems()
        {
            string ItemSelected = "";

            foreach (ListItem item in lstBoxSurveyNo.Items)
            {
                if (item.Selected)
                {
                    //  selectedSurveyNoMultiple += item.Text + "," + item.Value + "\\n";
                    ItemSelected += "'" + item.Text + "'" + ",";
                }
            }
            // selectedSurveyNoMultiple = selectedSurveyNoMultiple.Remove(selectedSurveyNoMultiple.Length - 1);
            return ItemSelected = ItemSelected.Remove(ItemSelected.Length - 1);
        }

        protected void grdHolderName_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdHolderName.EditIndex = -1;
            ShowGridHolderData(cmbVillage.SelectedValue.ToString().Trim(), cmbFamily.SelectedValue.ToString().Trim(), selectedListItems());
        }

        protected void btnSaveDocNo_Click(object sender, EventArgs e)
        {
            if (grdHolderName.Rows.Count > 0)
            {
                //update Family Servey no 

                //Get District Survey No
                DataSet dsForDistinctData = dbFamilyDetailsData.getFamilyDetailsMultipleSurvey(cmbVillage.SelectedValue.ToString().Trim(), cmbFamily.SelectedValue.ToString().Trim(), selectedListItems());

                DataTable DtD = dsForDistinctData.Tables[0].DefaultView.ToTable(true, "surveyno");

                //for (int i = 0; i < grdHolderName.Rows.Count; i++)
                for (int i = 0; i < DtD.Rows.Count; i++)
                {
                    //string surveyNoGrid = ((Label)grdHolderName.Rows[i].FindControl("lbl_SurveyNo")).Text;
                    string surveyNoGrid = DtD.Rows[i]["surveyno"].ToString();
                    dbFamilySurveyUpdate.villagecode = cmbVillage.SelectedValue.ToString().Trim();
                    dbFamilySurveyUpdate.familyno = cmbFamily.SelectedValue.ToString().Trim();
                    dbFamilySurveyUpdate.surveyno = surveyNoGrid;
                    dbFamilySurveyUpdate.documentno = txtDocNo.Text;
                    bool UpdateFamilySurvey = dbFamilySurveyUpdate.UpdateFamilySurvey();
                    if (UpdateFamilySurvey)
                    {

                    }
                    else
                    {

                    }

                }
                //Update family Details Table with Doc No 
                for (int i = 0; i < dsForDistinctData.Tables[0].Rows.Count; i++)
                {
                    dbFamilyDetailsUpdateAll.villagecode = cmbVillage.SelectedValue.ToString().Trim();
                    dbFamilyDetailsUpdateAll.familyno = cmbFamily.SelectedValue.ToString().Trim();
                    dbFamilyDetailsUpdateAll.surveyno = dsForDistinctData.Tables[0].Rows[i]["surveyno"].ToString();
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Survey Number Updated with Document Number : ');" + txtDocNo.Text, true);
                btnSaveDocNo.Enabled = false;
                btnNewDocument.Enabled = true;


            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Survey Details Not found');", true);
            }

        }

        protected void btnNewDocument_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TitleSearch/TitleSearch11");
        }

        //protected void grdHolderName_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        //{
        //    grdHolderName.PageIndex = e.NewPageIndex;
        //    ShowGridHolderData(cmbVillage.SelectedValue.ToString().Trim(), cmbFamily.SelectedValue.ToString().Trim(), selectedListItems());
        //}

        ///23 Aug 2019 Show SO Check List 
        protected void ShowCheckListGrid(string selectedVillage, string selectFamilyNo, string selectedDocNo)
        {

            dsChkListTran = dbChkListTranData.getChkListTran(selectedVillage, selectedDocNo);
            if (dsChkListTran.Tables[0].Rows.Count > 0)
            {
                grdCheckList.DataSource = dsChkListTran;
                grdCheckList.DataBind();

            }
            else
            {
                grdCheckList.DataSource = null;
                grdCheckList.DataBind();

            }

        }

        protected void grdCheckList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdCheckList.EditIndex = e.NewEditIndex;
            ShowCheckListGrid(cmbVillage.SelectedValue.ToString().Trim(), cmbFamily.SelectedValue.ToString().Trim(), cmbFamilyDocNo.SelectedValue.ToString().Trim());
        }

        protected void grdCheckList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label ChkListTranID = grdCheckList.Rows[e.RowIndex].FindControl("lbl_IDChKList") as Label;
            TextBox HoRemark = grdCheckList.Rows[e.RowIndex].FindControl("txt_HORemark") as TextBox;
            dbChkListTranData.chklisttranno = Convert.ToInt32(ChkListTranID.Text.ToString());
            dbChkListTranData.headofficeremark = HoRemark.Text.ToString();
            Boolean UpdateChkListTran = dbChkListTranData.UpdateChkListTranHO();

            grdCheckList.EditIndex = -1;
            ShowCheckListGrid(cmbVillage.SelectedValue.ToString().Trim(), cmbFamily.SelectedValue.ToString().Trim(), cmbFamilyDocNo.SelectedValue.ToString().Trim());

        }

        protected void grdCheckList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdCheckList.EditIndex = -1;
            ShowCheckListGrid(cmbVillage.SelectedValue.ToString().Trim(), cmbFamily.SelectedValue.ToString().Trim(), cmbFamilyDocNo.SelectedValue.ToString().Trim());

        }



        //
    }
}