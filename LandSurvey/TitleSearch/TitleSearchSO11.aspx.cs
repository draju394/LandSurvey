using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LandSurvey.DAL;
using System.Data;
using System.IO;
using System.Net;

namespace LandSurvey.TitleSearch
{
    public partial class TitleSearchSO11 : System.Web.UI.Page
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

        DataSet dsFamilyDetails = new DataSet();
        dbFamilyDetails dbFamilyDetailsData = new dbFamilyDetails();

        DataSet dsFileNumber = new DataSet();
        dbFileNo dbFileNoData = new dbFileNo();

        DataSet dsDocumentStatus = new DataSet();
        DataSet dsDocumentexists = new DataSet();
        DataSet dsDocumentExitsIN = new DataSet();
        DataSet dsDocumenttitleSearch = new DataSet();
        dbDocument dbDocumentStatusData = new dbDocument();
        DataSet dsDocumentNo = new DataSet();
        string MRDocFileNamePath = "";

        DataSet dsCheckListMaster = new DataSet();
        dbCheckList dbCheckListData = new dbCheckList();

        DataSet dsFamilyDocNoNew = new DataSet();

        DataSet dsChkListTran = new DataSet();
        dbChkListTran dbChkListTranData = new dbChkListTran();

        DataSet ds712PDFFile = new DataSet();
        DataSet dsMutationregister = new DataSet();
        dbFamilyDetails dbFamilyDetailsDataRD = new dbFamilyDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                              

                //village
                dsVillage = dbVillageData.getVillageName();
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

                //grdHolderName.Columns[1].Visible = false;
                grdCheckList.Columns[1].Visible = false;
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
                //cmbFamily.Items.Clear();
                string selectedVillage = cmbVillage.SelectedValue.ToString().Trim();

                //New Code after Demo
                cmbFamilyDocNo.Items.Clear();
                //dsFamilyDocNoNew = dbFamilyDetailsData.getVillageDocNo(selectedVillage);
                dsFamilyDocNoNew = dbFamilyDetailsData.getVillageDocNoForSO(selectedVillage);
                if (dsFamilyDocNoNew.Tables[0].Rows.Count > 0)
                {
                    cmbFamilyDocNo.DataSource = dsFamilyDocNoNew.Tables[0].DefaultView;
                    cmbFamilyDocNo.DataBind();
                    cmbFamilyDocNo.DataTextField = dsFamilyDocNoNew.Tables[0].Columns["docno"].ToString();
                    cmbFamilyDocNo.DataValueField = dsFamilyDocNoNew.Tables[0].Columns["docno"].ToString();
                    cmbFamilyDocNo.DataBind();
                    grdHolderName.DataSource = null;
                    grdHolderName.DataBind();

                }
            }
        }

        protected void cmbFamilyDocNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFamilyDocNo.SelectedIndex == -1)
            {
                // MessageBox.Show("Please select vaild District name");
                //cmbVillage.Select();
            }
            else
            {
                cmbDocumentNo.Items.Clear();
                string selectedVillage = cmbVillage.SelectedValue.ToString().Trim();
                string selectDocNo = cmbFamilyDocNo.SelectedValue.ToString().Trim();
                
                //RSD Populate Grid 
                lblLinkCL.Text = "";
                lbllinkFT.Text = "";
                dsFamilyDetails = dbFamilyDetailsData.getFamilyDetailsOnDocument(selectedVillage, selectDocNo);
                if (dsFamilyDetails.Tables[0].Rows.Count > 0)
                {
                    grdHolderName.DataSource = dsFamilyDetails;
                    grdHolderName.DataBind();

                    FillCheckListGrid();
                    ShowCheckListGrid();
                    //Select File Name from Document if Exist 

                    dsDocumentExitsIN = dbDocumentStatusData.DocumentExistDocNoRO(cmbVillage.SelectedValue.ToString().Trim(), cmbFamilyDocNo.SelectedValue.ToString().Trim());
                    if (dsDocumentExitsIN.Tables[0].Rows.Count > 0)
                    {
                        string DocType = "";
                        for (int i = 0; i < dsDocumentExitsIN.Tables[0].Rows.Count; i++)
                        {
                            DocType = dsDocumentExitsIN.Tables[0].Rows[i]["documentcode"].ToString();
                            if (DocType == "FT")
                            {
                                lbllinkFT.Text = dsDocumentExitsIN.Tables[0].Rows[i]["documentname"].ToString();
                                lbllinkFT.Text = dsDocumentExitsIN.Tables[0].Rows[i]["documentname"].ToString();
                            }
                            if (DocType == "CL")
                            {
                                lblLinkCL.Text = dsDocumentExitsIN.Tables[0].Rows[i]["documentname"].ToString();
                            }
                            if (DocType == "LN")
                            {
                                lblLinkLN.Text = dsDocumentExitsIN.Tables[0].Rows[i]["documentname"].ToString();
                            }
                            if (DocType == "LE")
                            {
                                lblLinkLE.Text = dsDocumentExitsIN.Tables[0].Rows[i]["documentname"].ToString();
                            }
                        }
                    }
                }
                else
                {

                    grdHolderName.DataSource = null;
                    grdHolderName.DataBind();
                }

            }
        }

        protected void ShowGridHolderData(string selectedVillage, string selectDocNo)
        {
            dsFamilyDetails = dbFamilyDetailsData.getFamilyDetailsOnDocument(cmbVillage.SelectedValue.ToString(), cmbFamilyDocNo.SelectedValue.ToString());
            if (dsFamilyDetails.Tables[0].Rows.Count > 0)
            {
                grdHolderName.DataSource = dsFamilyDetails;
                grdHolderName.DataBind();
               
            }
            else
            {
                grdHolderName.DataSource = null;
                grdHolderName.DataBind();

            }

        }

        protected void grdHolderName_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            grdHolderName.PageIndex = e.NewPageIndex;
            ShowGridHolderData(cmbVillage.SelectedValue.ToString().Trim(), cmbFamilyDocNo.SelectedValue.ToString().Trim());
        }
       

        protected void cmbDocumentNo_SelectedIndexChanged(object sender, EventArgs e)
        {
       

        }
       
        
        private bool CheckcmbValue()
        {
            if (cmbVillage.SelectedIndex < 0)
            {
                return false;
            }
            else if (cmbFamilyDocNo.SelectedIndex < 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private bool InsertDocumentStatus(string DocType, string fileName)
        {
            if (cmbFamilyDocNo.SelectedIndex < 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select family number');", true);
                return false;
            }
            else if (cmbVillage.SelectedIndex < 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select Village');", true);
                return false;
            }
            //else if (cmbDocumentNo.SelectedIndex < 0)
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select survey No.');", true);
            //    return false;
            //}
            else
            {
                string DocumentID = dbDocumentStatusData.getDocumentSeqNo();
                dbDocumentStatusData.documentid = Convert.ToInt32(DocumentID);
                dbDocumentStatusData.villagecode = cmbVillage.SelectedValue.ToString().Trim();
                dbDocumentStatusData.familyno = "";
                dbDocumentStatusData.surveyno = cmbDocumentNo.SelectedValue.ToString().Trim();
                //Check Existing Title Search Exist 
                dsDocumenttitleSearch = dbDocumentStatusData.DocumentTitleExistRO(cmbVillage.SelectedValue.ToString().Trim(), cmbFamilyDocNo.SelectedValue.ToString().Trim());
                if (dsDocumenttitleSearch.Tables[0].Rows.Count > 0)
                {
                    dbDocumentStatusData.titlesearchno = dsDocumenttitleSearch.Tables[0].Rows[0]["titlesearchno"].ToString();
                }
                else
                {
                   // dbDocumentStatusData.titlesearchno = cmbVillage.SelectedValue.ToString().Trim() + "_" + cmbFamily.SelectedValue.ToString().Trim() + "-" + cmbDocumentNo.SelectedValue.ToString().Trim() + "_" + DocumentID;
                    dbDocumentStatusData.titlesearchno = cmbDocumentNo.SelectedValue.ToString().Trim();
                }

                dbDocumentStatusData.docno = cmbFamilyDocNo.SelectedValue.ToString().Trim();
                dbDocumentStatusData.documentcode = DocType;
                dbDocumentStatusData.documentname = fileName;
                dbDocumentStatusData.documentpath = ViewState["filepath"].ToString();
                dbDocumentStatusData.createdby = "RSD";
                dbDocumentStatusData.createddate = DateTime.Today;
                //Check For Record Exist 
                dsDocumentexists = dbDocumentStatusData.DocumentExistRO(cmbVillage.SelectedValue.ToString().Trim(), cmbFamilyDocNo.SelectedValue.ToString().Trim(), DocType);
                if (dsDocumentexists.Tables[0].Rows.Count == 0)
                {

                    bool DocInsert = dbDocumentStatusData.AddDocumentStatus();
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('File Already exist now updating');", true);
                    // ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "element.onclick = function(){ return confirm('Are you sure you want to delete?'); };",true);
                    bool DocumentFileUpdate = dbDocumentStatusData.UpdateDocumentFileRO(cmbDocumentNo.SelectedValue.ToString().Trim());
                    if (DocumentFileUpdate)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('New File updated');", true);
                    }
                }
                return true;
            }
        }

        protected void lbllinkMR_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + lbllinkFT.Text);
            Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lbllinkFT.Text));
            Response.End();
        }

        protected void lblLinkDrFile_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + lblLinkCL.Text);
            Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lblLinkCL.Text));
            Response.End();
        }

        protected void btnPublicNotice_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnFinalRemark_Click(object sender, EventArgs e)
        {
            

        }

        protected void lblLinkPR_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + lblLinkLN.Text);
            Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lblLinkLN.Text));
            Response.End();
        }

        protected void lblLinkFR_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + lblLinkLE.Text);
            Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lblLinkLE.Text));
            Response.End();
        }


        protected void btnFamilyHistory_Click(object sender, EventArgs e)
        {
          
            if (FileUploadControl.HasFile)
            {
                lbllinkFT.Text = "";
                // Village_Code: 01, Family_No: 60, TSN_No: 01 and if Mutation Reg PDF is
                //uploaded the Name should be MR_01_60_01_001
                //   Last 001 is the Running Mutation Number

                try
                {
                    bool validateCMB = CheckcmbValue();
                    if (validateCMB)
                    {

                        string registerFileNo = dbFileNoData.getFileNo("FH");
                        string filename = Path.GetFileName(FileUploadControl.FileName);
                        //string fileExtension = filename.Substring(filename.Length - 3);
                        string fileExtension = System.IO.Path.GetExtension(FileUploadControl.PostedFile.FileName);
                        string VillageCodeFolder = cmbVillage.SelectedValue.ToString().Trim();
                        string FamilyDocNo = cmbFamilyDocNo.SelectedValue.ToString().Trim();
                        string NewFileName = "FT_" + VillageCodeFolder + "_" + FamilyDocNo + "_" + registerFileNo + fileExtension;
                        //  string NewFileName = "MR_" + VillageCodeFolder + "_" + FamilyNoName + "_" + registerFileNo + "." + fileExtension;
                        string folderName = Server.MapPath("~/Documents/" + VillageCodeFolder + "/");
                        if (!Directory.Exists(folderName))
                        {
                            Directory.CreateDirectory(folderName);
                        }
                        FileUploadControl.SaveAs(folderName + NewFileName);

                        //update MR File Number
                        dbFileNoData.registername = "FT";
                        dbFileNoData.currentno = Convert.ToInt32(registerFileNo) + 1;
                        dbFileNoData.UpdateFileNo();
                        lbllinkFT.Text = NewFileName;
                        string FinalPath = folderName + NewFileName;
                        ViewState["filepath"] = FinalPath;

                        InsertDocumentStatus("FT", NewFileName);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select Village and Document Number ');", true);
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



        protected void FillCheckListGrid()
        {
            dsCheckListMaster = dbCheckListData.getCheckListData();
            if(dsCheckListMaster.Tables[0].Rows.Count >0)
            {

                //grdCheckList.DataSource = dsCheckListMaster;
                //grdCheckList.DataBind();
            }
        }

        

        ///23 Aug 2019 Show SO Check List 
        protected void ShowCheckListGrid()
        {
           // dsCheckListMaster = dbCheckListData.getCheckListData();
           dsChkListTran = dbChkListTranData.getChkListTran(cmbVillage.SelectedValue.ToString().Trim(), cmbFamilyDocNo.SelectedValue.ToString().Trim());
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
            ShowCheckListGrid();
        }

        protected void grdCheckList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label ChkListTranID = grdCheckList.Rows[e.RowIndex].FindControl("lbl_IDChKList") as Label;
            TextBox SORemark = grdCheckList.Rows[e.RowIndex].FindControl("txt_SiteOfficeRemark") as TextBox;
            dbChkListTranData.chklisttranno = Convert.ToInt32(ChkListTranID.Text.ToString());
            dbChkListTranData.siteofficereamrk = SORemark.Text.ToString();
            dbChkListTranData.villagecode = cmbVillage.SelectedValue.ToString().Trim();
            dbChkListTranData.docno = cmbFamilyDocNo.SelectedValue.ToString().Trim();
            Int32 MCheckListNo = Convert.ToInt32(ChkListTranID.Text);
            bool CheckRecordExist = dbChkListTranData.CheckRecordExist(cmbVillage.SelectedValue.ToString().Trim(), cmbFamilyDocNo.SelectedValue.ToString().Trim(), MCheckListNo,"SO2");
            if(CheckRecordExist)
            {
                Boolean UpdateChkListTran = dbChkListTranData.UpdateChkListTranSO();
                ShowCheckListGrid();
            }
            else
            {
                //Insert
                string ChkListTranNo = dbChkListTranData.getCheckListTranSeqNo();
                dbChkListTranData.chklisttranno = Convert.ToInt32(ChkListTranNo.ToString());
                Label ChkListName = grdCheckList.Rows[e.RowIndex].FindControl("lbl_ChkListName") as Label;
                dbChkListTranData.chklistname = ChkListName.Text;
                dbChkListTranData.familyno = "";
                Label ChkListMasterNo = grdCheckList.Rows[e.RowIndex].FindControl("lbl_IDChKList") as Label;
                dbChkListTranData.chklstno = Convert.ToInt32(ChkListMasterNo.Text);
                Boolean InsertChkListTran = dbChkListTranData.AddCheckListTranSO();
                ShowCheckListGrid();

            }

            grdCheckList.EditIndex = -1;
            ShowCheckListGrid();
        }

        protected void grdCheckList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdCheckList.EditIndex = -1;
            ShowCheckListGrid();
        }

        protected void grdCheckList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCheckList.PageIndex = e.NewPageIndex;
            ShowCheckListGrid();

            //dsCheckListMaster = dbCheckListData.getCheckListData();
            //if (dsCheckListMaster.Tables[0].Rows.Count > 0)
            //{
            //    grdCheckList.DataSource = dsCheckListMaster;
            //    grdCheckList.DataBind();
            //}
        }

        protected void btnConcentLetter_Click(object sender, EventArgs e)
        {
            if (FileUploadControlDR.HasFile)
            {
                lblLinkCL.Text = "";
                // Village_Code: 01, Family_No: 60, TSN_No: 01 and if Mutation Reg PDF is
                //uploaded the Name should be MR_01_60_01_001
                //   Last 001 is the Running Mutation Number

                try
                {
                    bool validateCMB = CheckcmbValue();
                    if (validateCMB)
                    {
                        string registerFileNo = dbFileNoData.getFileNo("CL");
                        string filename = Path.GetFileName(FileUploadControlDR.FileName);
                        //string fileExtension = filename.Substring(filename.Length - 3);
                        string fileExtension = System.IO.Path.GetExtension(FileUploadControlDR.PostedFile.FileName);
                        string VillageCodeFolder = cmbVillage.SelectedValue.ToString().Trim();
                        string FamilyDocNo = cmbFamilyDocNo.SelectedValue.ToString().Trim();
                        string NewFileName = "CL_" + VillageCodeFolder + "_" + FamilyDocNo + "_" + registerFileNo + fileExtension;
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
                        dbFileNoData.registername = "CL";
                        dbFileNoData.currentno = Convert.ToInt32(registerFileNo) + 1;
                        dbFileNoData.UpdateFileNo();
                        lblLinkCL.Text = NewFileName;
                        string FinalPath = folderName + NewFileName;
                        ViewState["filepath"] = FinalPath;

                        InsertDocumentStatus("CL", NewFileName);
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

        protected void btnLocalNotice_Click(object sender, EventArgs e)
        {
            if (FileUploadControlPN.HasFile)
            {
                lblLinkLN.Text = "";
                // Village_Code: 01, Family_No: 60, TSN_No: 01 and if Mutation Reg PDF is
                //uploaded the Name should be MR_01_60_01_001
                //   Last 001 is the Running Mutation Number

                try
                {
                    bool validateCMB = CheckcmbValue();
                    if (validateCMB)
                    {

                        string registerFileNo = dbFileNoData.getFileNo("LN");
                        string filename = Path.GetFileName(FileUploadControlPN.FileName);
                        string fileExtension = System.IO.Path.GetExtension(FileUploadControlPN.PostedFile.FileName);
                        string VillageCodeFolder = cmbVillage.SelectedValue.ToString().Trim();
                        string FamilyDocNo = cmbFamilyDocNo.SelectedValue.ToString().Trim();
                        string NewFileName = "LN_" + VillageCodeFolder + "_" + FamilyDocNo + "_" + registerFileNo + fileExtension;
                        string folderName = Server.MapPath("~/Documents/" + VillageCodeFolder + "/");
                        if (!Directory.Exists(folderName))
                        {
                            Directory.CreateDirectory(folderName);
                        }
                        FileUploadControlPN.SaveAs(folderName + NewFileName);

                        //update PN File Number
                        dbFileNoData.registername = "LN";
                        dbFileNoData.currentno = Convert.ToInt32(registerFileNo) + 1;
                        dbFileNoData.UpdateFileNo();
                        lblLinkLN.Text = NewFileName;
                        string FinalPath = folderName + NewFileName;
                        ViewState["filepath"] = FinalPath;

                        InsertDocumentStatus("LN", NewFileName);
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

        protected void btnLocalEnquiry_Click(object sender, EventArgs e)
        {
            if (FileUploadControlFR.HasFile)
            {
                lblLinkLE.Text = "";
                // Village_Code: 01, Family_No: 60, TSN_No: 01 and if Mutation Reg PDF is
                //uploaded the Name should be MR_01_60_01_001
                //   Last 001 is the Running Mutation Number

                try
                {
                    bool validateCMB = CheckcmbValue();
                    if (validateCMB)
                    {

                        string registerFileNo = dbFileNoData.getFileNo("LE");
                        string filename = Path.GetFileName(FileUploadControlFR.FileName);
                        string fileExtension = System.IO.Path.GetExtension(FileUploadControlFR.PostedFile.FileName);
                        string VillageCodeFolder = cmbVillage.SelectedValue.ToString().Trim();
                        string FamilyDocNo = cmbFamilyDocNo.SelectedValue.ToString().Trim();
                        string NewFileName = "LE_" + VillageCodeFolder + "_" + FamilyDocNo + "_" + registerFileNo + fileExtension;
                        string folderName = Server.MapPath("~/Documents/" + VillageCodeFolder + "/");
                        if (!Directory.Exists(folderName))
                        {
                            Directory.CreateDirectory(folderName);
                        }
                        FileUploadControlFR.SaveAs(folderName + NewFileName);

                        //update FR File Number
                        dbFileNoData.registername = "LE";
                        dbFileNoData.currentno = Convert.ToInt32(registerFileNo) + 1;
                        dbFileNoData.UpdateFileNo();
                        lblLinkLE.Text = NewFileName;
                        string FinalPath = folderName + NewFileName;
                        ViewState["filepath"] = FinalPath;

                        InsertDocumentStatus("LE", NewFileName);
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

        protected void grdHolderName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnViewMutation_Click(object sender, EventArgs e)
        {
            if (grdHolderName.SelectedIndex >= 0)
            {
                string SelectedSurveyNo = grdHolderName.SelectedRow.Cells[2].Text;
                string VillageCode = cmbVillage.SelectedValue.ToString().Trim();
                dsMutationregister = dbFamilyDetailsDataRD.GetMutationRegister(cmbVillage.SelectedValue.ToString().Trim(), "MR", SelectedSurveyNo.Trim());
                if (dsMutationregister.Tables[0].Rows.Count > 0)
                {


                   string MutationRegister = dsMutationregister.Tables[0].Rows[0]["documentname"].ToString();
                   string FilePath = Server.MapPath("~/Documents/" + VillageCode + "/" + MutationRegister);
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


            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select  Holder Data');", true);
            }
        }

        protected void btnView712_Click(object sender, EventArgs e)
        {
            if (grdHolderName.SelectedIndex >= 0)
            {
                string SelectedSurveyNo = grdHolderName.SelectedRow.Cells[2].Text;
                ds712PDFFile = dbFamilyDetailsDataRD.Get712PDFFileName(cmbVillage.SelectedValue.ToString().Trim(), cmbFamilyDocNo.SelectedValue.ToString().Trim(), SelectedSurveyNo.Trim());
                if(ds712PDFFile.Tables[0].Rows.Count > 0)
                {
                    string PDFFileName = ds712PDFFile.Tables[0].Rows[0]["pdffilename"].ToString();
                    string FilePath = Server.MapPath("~/7-12PDF/" + PDFFileName + ".pdf" );
                    if (!File.Exists(FilePath))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Selected Survey No 7/12 Not available');", true);
                    }
                    else
                    {
                        Response.Clear();
                        //Response.ClearContent();
                        //Response.ClearHeaders();

                        WebClient User = new WebClient();
                        Byte[] FileBuffer = User.DownloadData(FilePath);
                        if (FileBuffer != null)
                        {
                            Response.ContentType = "application/pdf";
                            //Response.AddHeader("content-length", FileBuffer.Length.ToString());
                          //  Response.AddHeader("content-disposition", "inline;filename=" + PDFFileName + ".pdf");
                            Response.AddHeader("content-disposition", "inline;filename=" + PDFFileName + ".pdf");
                            Response.BinaryWrite(FileBuffer);
                            Response.Flush(); Response.End();

                            //Response.Write("<script>window.open('<Link to PDF on Server>','_blank');</script>");
                            //ClientScript.RegisterStartupScript(this.GetType(), "open", "window.open('" + FilePath + "','_blank', 'fullscreen=yes');", true);
                        }
                    }
                }
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select  Holder Data');", true);
            }
        }

        ///
    }
}