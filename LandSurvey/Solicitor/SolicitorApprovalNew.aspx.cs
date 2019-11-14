using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LandSurvey.DAL;
using System.IO;


namespace LandSurvey.Solicitor
{
    public partial class SolicitorApprovalNew : System.Web.UI.Page
    {
        DataSet dsDocApproval = new DataSet();
        dbDocumentStatus dbDocSolicitorAll = new dbDocumentStatus();
        dbFileNo dbFileNoData = new dbFileNo();
        dbDocument dbDocumentStatusData = new dbDocument();
        DataSet dsDocumenteExists = new DataSet();
        dbDocumentStatus dbDocumentStatusUpdateData = new dbDocumentStatus();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string VillageCode = Server.UrlDecode(Request.QueryString["Village"]);
                string VillageMarathiName = Server.UrlDecode(Request.QueryString["VName"]);
                string DocNo = Server.UrlDecode(Request.QueryString["Doc"]);
                lblVillageCode.Text = VillageMarathiName;
                LblDocNo.Text = DocNo;
                ShowAllDocumentsApproval();
            }
        }

        private void ShowAllDocumentsApproval()
        {
            dsDocApproval = dbDocSolicitorAll.getSolicitorAllDocumentsForApproval(Server.UrlDecode(Request.QueryString["Village"].ToString()), Server.UrlDecode(Request.QueryString["Doc"].ToString()));
            if(dsDocApproval.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsDocApproval.Tables[0].Rows.Count; i++)
                {
                    string UploadedDocument = dsDocApproval.Tables[0].Rows[i]["documentname"].ToString();
                    string DocumentCode = dsDocApproval.Tables[0].Rows[i]["documentcode"].ToString();
                    string DocRemark = dsDocApproval.Tables[0].Rows[i]["solicitorremark"].ToString();
                    string ApproveDate = dsDocApproval.Tables[0].Rows[i]["solicitorappdate"].ToString();
                    string ApproveStatus = dsDocApproval.Tables[0].Rows[i]["solicitorapproval"].ToString();
                    //PTS Start
                    if (DocumentCode == "PTS")
                    {
                        lbllinkPTS.Text = UploadedDocument;
                        txtPTSRemark.Text = DocRemark;
                        lblApproveDatePTS.Text = ApproveDate;
                        if(ApproveStatus == "Yes")
                        {
                            rdButtonPTSApprove.SelectedIndex = 0;
                        }
                        else
                        {
                            rdButtonPTSApprove.SelectedIndex = 1;
                        }

                    }
                    if(DocumentCode == "UQPTS")
                    {
                        lblLinkPTSQueries.Text = UploadedDocument;
                    }

                    if (DocumentCode == "CPTS")
                    {
                        lbllinkCPTS.Text = UploadedDocument;
                    }

                    //PTS END
                    //FTS Start
                    if (DocumentCode == "FTS")
                    {
                        lblLinkFTS.Text = UploadedDocument;
                        txtFTSRemark.Text = DocRemark;
                        lblApproveDateFTS.Text = ApproveDate;
                        if (ApproveStatus == "Yes")
                        {
                            rdButtonFTSApprov.SelectedIndex = 0;
                        }
                        else
                        {
                            rdButtonFTSApprov.SelectedIndex = 1;
                        }

                    }
                    if (DocumentCode == "UQFTS")
                    {
                        lblLinkFTSQueries.Text = UploadedDocument;
                    }
                    
                    if(DocumentCode == "CFTS")
                    {
                        lblLinkCFTS.Text = UploadedDocument;
                    }

                    //FTS End

                    //Public Notice 
                    if (DocumentCode == "PN")
                    {
                        lblLinkPN.Text = UploadedDocument;
                        txtPNRemark.Text = DocRemark;
                        lblApprovDatePN.Text = ApproveDate;
                        if (ApproveStatus == "Yes")
                        {
                            rdButtonApprovePN.SelectedIndex = 0;
                        }
                        else
                        {
                            rdButtonApprovePN.SelectedIndex = 1;
                        }

                    }
                    if (DocumentCode == "CPN")
                    {
                        lblLinkCPN.Text = UploadedDocument;
                    }
                    if (DocumentCode == "UQPN")
                    {
                        lblLinkPNQueries.Text = UploadedDocument;
                    }

                    //End Public Notice 
                    //Start ATS
                    if (DocumentCode == "ATS")
                    {
                        lblLinkATS.Text = UploadedDocument;
                        txtATSRemark.Text = DocRemark;
                        lblApproveATSDate.Text = ApproveDate;
                        if (ApproveStatus == "Yes")
                        {
                            rdButtonApproveATS.SelectedIndex = 0;
                        }
                        else
                        {
                            rdButtonApproveATS.SelectedIndex = 1;
                        }

                    }
                    if (DocumentCode == "UQATS")
                    {
                        lblLinkATSQueries.Text = UploadedDocument;
                    }

                    //END ATS

                    //Start SD
                    if (DocumentCode == "SD")
                    {
                        lblLinkSD.Text = UploadedDocument;
                        txtSDRemark.Text = DocRemark;
                        lblApproveSDDate.Text = ApproveDate;
                        if (ApproveStatus == "Yes")
                        {
                            rdButtonApproveSD.SelectedIndex = 0;
                        }
                        else
                        {
                            rdButtonApproveSD.SelectedIndex = 1;
                        }

                    }
                    if (DocumentCode == "UQSD")
                    {
                        lblLinkUploadSDQueries.Text = UploadedDocument;
                    }

                    //END ATS
                }
            }
        }

        protected void btnUploadPTSQuery_Click(object sender, EventArgs e)
        {
            if (FileUploadPTS.HasFiles)
            {
                try
                {
                    GenerateFileName("UQPTS", FileUploadPTS, lblLinkPTSQueries);

                    //InsertDocumentStatus("MSR", NewFileName);

                }
                catch (Exception ex)
                {


                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select file to upload');", true);
            }
        }

        private void GenerateFileName(string DocType, FileUpload FControlName, LinkButton LinkDoc)
        {
            try
            {

                string registerFileNo = dbFileNoData.getFileNo(DocType);
                string filename = Path.GetFileName(FControlName.FileName);
                string fileExtension = System.IO.Path.GetExtension(FControlName.PostedFile.FileName);
                string VillageCode = Server.UrlDecode(Request.QueryString["Village"]);
               // VillageCode = Server.UrlDecode(Request.QueryString["Village"]);
                string DocumentNo = LblDocNo.Text;
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
                dbDocumentStatusData.docno = LblDocNo.Text;
                //Check For Record Exist 
                dsDocumenteExists = dbDocumentStatusData.DocumentExistRO(VillageCode, LblDocNo.Text, DocType);
                if (dsDocumenteExists.Tables[0].Rows.Count == 0)
                {
                    //string ModifiedSurveyNo = dbDocumentStatusData.surveyno;
                    //dbDocumentStatusData.surveyno = ModifiedSurveyNo.Replace("'", "");
                    dbDocumentStatusData.surveyno = "";
                    dbDocumentStatusData.familyno = "";
                    dbDocumentStatusData.titlesearchno = "";
                    dbDocumentStatusData.officename = "Solicitor";
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
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('New File Uploaded');", true);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void lblLinkPTSQueries_Click(object sender, EventArgs e)
        {
            ShowLinkFile(lblLinkPTSQueries.Text);
        }

        protected void lblLinkFTSQueries_Click(object sender, EventArgs e)
        {
            ShowLinkFile(lblLinkFTSQueries.Text);
        }

        protected void lbllinkPTS_Click(object sender, EventArgs e)
        {
            ShowLinkFile(lbllinkPTS.Text);
        }

        protected void lblLinkFTS_Click(object sender, EventArgs e)
        {
            ShowLinkFile(lblLinkFTS.Text);
        }

        private void ShowLinkFile( string LblLinkFile)
        {
            string FileExist = Server.MapPath(@"~/Documents/" + Server.UrlDecode(Request.QueryString["Village"]) + "/" + LblLinkFile);
            if (File.Exists(FileExist))
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + LblLinkFile);
                Response.WriteFile(Server.MapPath(@"~/Documents/" + Server.UrlDecode(Request.QueryString["Village"]) + "/" + LblLinkFile));
                Response.End();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Selected File Not exists on Storage');", true);
            }
        }

        protected void btnApprovePTS_Click(object sender, EventArgs e)
        {

            UpdateDocument("PTS");
        }

        private void UpdateDocument(string DocType)
        {
            bool UpdateDocType = false;
            //Update Document Status 
            dbDocumentStatusUpdateData.villagecode = Server.UrlDecode(Request.QueryString["Village"]);
            dbDocumentStatusUpdateData.documentcode = DocType;
            dbDocumentStatusUpdateData.docno = Server.UrlDecode(Request.QueryString["Doc"]);
          
            dbDocumentStatusUpdateData.solicitorappdate = DateTime.Today;
            if (DocType == "PTS")
            {
                dbDocumentStatusUpdateData.solicitorremark = txtPTSRemark.Text;
                dbDocumentStatusUpdateData.solicitorapproval = rdButtonPTSApprove.SelectedValue;
            }
            if (DocType == "FTS")
            {
                dbDocumentStatusUpdateData.solicitorremark = txtFTSRemark.Text;
                dbDocumentStatusUpdateData.solicitorapproval = rdButtonFTSApprov.SelectedValue;
            }
            if (DocType == "PN")
            {
                dbDocumentStatusUpdateData.solicitorremark = txtPNRemark.Text;
                dbDocumentStatusUpdateData.solicitorapproval = rdButtonApprovePN.SelectedValue;
            }
            if (DocType == "ATS")
            {
                dbDocumentStatusUpdateData.solicitorremark = txtATSRemark.Text;
                dbDocumentStatusUpdateData.solicitorapproval = rdButtonApproveATS.SelectedValue;
            }
            if (DocType == "SD")
            {
                dbDocumentStatusUpdateData.solicitorremark = txtSDRemark.Text;
                dbDocumentStatusUpdateData.solicitorapproval = rdButtonApproveSD.SelectedValue;
            }

            UpdateDocType = dbDocumentStatusUpdateData.UpdateDocumentStatusSolicitor();
            if (UpdateDocType)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert(' " + DocType + " Document Not Approved');", true);
               
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + DocType + " Document Approved');", true);
                ShowAllDocumentsApproval();
            }
        }

        protected void btnUploadFTSQueries_Click(object sender, EventArgs e)
        {
            if (FileUploadFTS.HasFiles)
            {
                try
                {
                    GenerateFileName("UQFTS", FileUploadFTS, lblLinkFTSQueries);

                    //InsertDocumentStatus("MSR", NewFileName);

                }
                catch (Exception ex)
                {


                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select file to upload');", true);
            }
        }

        protected void btnApproveFTS_Click(object sender, EventArgs e)
        {
            UpdateDocument("FTS");
        }

        protected void lblLinkPN_Click(object sender, EventArgs e)
        {
            ShowLinkFile(lblLinkPN.Text);
        }

        protected void lblLinkCPN_Click(object sender, EventArgs e)
        {
            ShowLinkFile(lblLinkCPN.Text);
        }

        protected void btnUploadPNQueries_Click(object sender, EventArgs e)
        {
            if (FileUploadPN.HasFiles)
            {
                try
                {
                    GenerateFileName("UQPN", FileUploadPN, lblLinkPNQueries);
                }
                catch (Exception ex)
                {

                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select file to upload');", true);
            }
        }

        protected void lblLinkPNQueries_Click(object sender, EventArgs e)
        {
            ShowLinkFile(lblLinkPNQueries.Text);
        }

        protected void btnApprovePN_Click(object sender, EventArgs e)
        {
            UpdateDocument("PN");
        }

        protected void lblLinkATS_Click(object sender, EventArgs e)
        {
            ShowLinkFile(lblLinkATS.Text);
        }

        protected void btnUploadATSQuerie_Click(object sender, EventArgs e)
        {
            if (FileUploadATS.HasFiles)
            {
                try
                {
                    GenerateFileName("UQATS", FileUploadATS, lblLinkATSQueries);
                }
                catch (Exception ex)
                {

                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select file to upload');", true);
            }
        }

        protected void lblLinkATSQueries_Click(object sender, EventArgs e)
        {
            ShowLinkFile(lblLinkATSQueries.Text);
        }

        protected void btnApproveATS_Click(object sender, EventArgs e)
        {
            UpdateDocument("ATS");
        }

        protected void lblLinkSD_Click(object sender, EventArgs e)
        {
            ShowLinkFile(lblLinkSD.Text);
        }

        protected void btnUploadSDQueries_Click(object sender, EventArgs e)
        {
            if (FileUploadSD.HasFiles)
            {
                try
                {
                    GenerateFileName("UQSD", FileUploadSD, lblLinkUploadSDQueries);
                }
                catch (Exception ex)
                {

                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select file to upload');", true);
            }
        }

        protected void lblLinkUploadSDQueries_Click(object sender, EventArgs e)
        {
            ShowLinkFile(lblLinkUploadSDQueries.Text);
        }

        protected void btnApproveSD_Click(object sender, EventArgs e)
        {
            UpdateDocument("SD");
        }

        protected void btnHOApproval_Click(object sender, EventArgs e)
        {
            SendSMS("1");
        }

        private void SendSMS(string UserRole)
        {
            dbUser dbUserData = new dbUser();
            CommonFunction fnCommon = new CommonFunction();
            DataSet dsUserTypeData = new DataSet();

            //Get User Mobile based on Role 
            dsUserTypeData = dbUserData.GetUserBasedOnRole(UserRole);
            if (dsUserTypeData.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow rows in dsUserTypeData.Tables[0].Rows)
                {
                    string UserMobileNo = rows["mobile1"].ToString();
                    if (string.IsNullOrEmpty(UserMobileNo))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Mobile Number Not available, Please contact administrator');", true);
                        //  Response.Redirect("~/UserLogin.aspx");
                    }
                    else
                    {
                        string FromName = "Solicitor";
                        string DocNo = LblDocNo.Text;
                        //string MobileMessage = "Document is sent to you for approval ";
                        //Document No. %%| DocNo ^{ "inputtype" : "text", "maxlength" : "20"}%% sent you from %%| FromName ^{ "inputtype" : "text", "maxlength" : "20"}%%
                        string MobileMessage = "Document No. " + DocNo + "  sent you from " + FromName  ;
                        fnCommon.sendsms("+91" + UserMobileNo, MobileMessage);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('SMS Send to Head Office');", true);

                    }
                }
                //}
            }
        }
        //
    }
}