using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LandSurvey.DAL;
using System.IO;
using System.Data;

namespace LandSurvey.SOTwo
{
    public partial class SO2OtherDocument : System.Web.UI.Page
    {
        dbFileNo dbFileNoData = new dbFileNo();
        dbDocument dbDocumentStatusData = new dbDocument();
        DataSet dsDocumenteExists = new DataSet();
        dbVillage dbVillageData = new dbVillage();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string VillageCode = Server.UrlDecode(Request.QueryString["Village"]);
                string VillageMarathiName = dbVillageData.getVillageNameMarathi(VillageCode);
                string DocNo = Server.UrlDecode(Request.QueryString["Doc"]);
                lblVillageCode.Text = VillageMarathiName;
                LblDocNo.Text = DocNo;
                lblVillageCodeHidden.Text = VillageCode;
                //Show Already Uploaded Files
                ShowDocumentsSO2Registry();
                
            }
        }

        protected void btnRegistrationSearch_Click(object sender, EventArgs e)
        {
            if (FileUploadRegistrationSearch.HasFiles)
            {
                try
                {
                    GenerateFileName("RSR", FileUploadRegistrationSearch, lbllinkRegisrationSearch);

                    //InsertDocumentStatus("MSR", NewFileName);

                }
                catch(Exception ex)
                {


                }

            }

        }

        protected void btnLocalInquiry_Click(object sender, EventArgs e)
        {
            if (FileUploadLocalInquiry.HasFiles)
            {
                try
                {
                    GenerateFileName("LI", FileUploadLocalInquiry, lbllnkLocalInquiry);

                    //InsertDocumentStatus("MSR", NewFileName);

                }
                catch (Exception ex)
                {


                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Local Inquiry File to Upload');", true);
            }
        }

        protected void btnFamilytree_Click(object sender, EventArgs e)
        {
            if (FileUploadFamilyTree.HasFiles)
            {
                try
                {
                    GenerateFileName("FT", FileUploadFamilyTree, lbllinkFamilyTree);

                    //InsertDocumentStatus("MSR", NewFileName);

                }
                catch (Exception ex)
                {


                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Family Tree File to Upload');", true);
            }
        }

        protected void btnConcentLetter_Click(object sender, EventArgs e)
        {
            if (FileUploadConcentLetter.HasFiles)
            {
                try
                {
                    GenerateFileName("CL", FileUploadConcentLetter, lbllnkConcentLetter);

                    //InsertDocumentStatus("MSR", NewFileName);

                }
                catch (Exception ex)
                {


                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Concent Letter File to Upload');", true);
            }
        }

        protected void btnIDDoc_Click(object sender, EventArgs e)
        {
            if (FileUploadIDDoc.HasFiles)
            {
                try
                {
                    GenerateFileName("ID", FileUploadIDDoc, lbllnkIDDoc);

                    //InsertDocumentStatus("MSR", NewFileName);

                }
                catch (Exception ex)
                {


                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Identification Document File to Upload');", true);
            }
        }

       
        private void GenerateFileName( string DocType, FileUpload FControlName, LinkButton LinkDoc)
        {
            try
            {  

            string registerFileNo = dbFileNoData.getFileNo(DocType);
            string filename = Path.GetFileName(FControlName.FileName);
            string fileExtension = System.IO.Path.GetExtension(FControlName.PostedFile.FileName);
            string VillageCode = lblVillageCode.Text;
            VillageCode = lblVillageCodeHidden.Text;
            string DocumentNo = LblDocNo.Text;
            string NewFileName = DocType + "_" +  VillageCode + "_" + DocumentNo + "_" + registerFileNo + fileExtension;
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
                dbDocumentStatusData.villagecode = lblVillageCodeHidden.Text;
                dbDocumentStatusData.documentcode = DocType;
                dbDocumentStatusData.documentname = NewFileName;
                dbDocumentStatusData.documentpath = ViewState["filepath"].ToString();
                dbDocumentStatusData.createdby = Session["UserName"].ToString();
                dbDocumentStatusData.createddate = DateTime.Today;
                dbDocumentStatusData.docno = LblDocNo.Text;
                //Check For Record Exist 
                dsDocumenteExists = dbDocumentStatusData.DocumentExistRO(lblVillageCode.Text,LblDocNo.Text, DocType);
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

        protected void lbllinkRegisrationSearch_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + lbllinkRegisrationSearch.Text);
            Response.WriteFile(Server.MapPath(@"~/Documents/" + lblVillageCodeHidden.Text + "/" + lbllinkRegisrationSearch.Text));
            Response.End();
        }

        protected void lbllnkLocalInquiry_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + lbllnkLocalInquiry.Text);
            Response.WriteFile(Server.MapPath(@"~/Documents/" + lblVillageCodeHidden.Text + "/" + lbllnkLocalInquiry.Text));
            Response.End();
        }

        protected void lbllinkFamilyTree_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + lbllinkFamilyTree.Text);
            Response.WriteFile(Server.MapPath(@"~/Documents/" + lblVillageCodeHidden.Text + "/" + lbllinkFamilyTree.Text));
            Response.End();
        }

        protected void lbllnkConcentLetter_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + lbllnkConcentLetter.Text);
            Response.WriteFile(Server.MapPath(@"~/Documents/" + lblVillageCodeHidden.Text + "/" + lbllnkConcentLetter.Text));
            Response.End();
        }

        protected void lbllnkIDDoc_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + lbllnkIDDoc.Text);
            Response.WriteFile(Server.MapPath(@"~/Documents/" + lblVillageCodeHidden.Text + "/" + lbllnkIDDoc.Text));
            Response.End();
        }
        private void ShowDocumentsSO2Registry()
        {
            DataSet dsGetAllDocuments;
            dsGetAllDocuments = dbDocumentStatusData.GetDocumentSO2Registry(lblVillageCodeHidden.Text, LblDocNo.Text, "SO2");
            if(dsGetAllDocuments.Tables[0].Rows.Count > 0)
            {
                //string UploadedDocument = dsGetAllDocuments.Tables[0].Rows[0]["documentname"].ToString();
                //if(UploadedDocument != "")
                //{
                    for (int i = 0; i < dsGetAllDocuments.Tables[0].Rows.Count; i++)
                    {
                    string UploadedDocument = dsGetAllDocuments.Tables[0].Rows[i]["documentname"].ToString();
                    string DocumentCode = dsGetAllDocuments.Tables[0].Rows[i]["documentcode"].ToString(); 
                    if (DocumentCode == "RSR"){lbllinkRegisrationSearch.Text = UploadedDocument;}
                    if (DocumentCode == "LI") { lbllnkLocalInquiry.Text = UploadedDocument; }
                    if (DocumentCode == "FT") { lbllinkFamilyTree.Text = UploadedDocument; }
                    if (DocumentCode == "CL") { lbllnkConcentLetter.Text = UploadedDocument; }
                    if (DocumentCode == "ID") { lbllnkIDDoc.Text = UploadedDocument; }
                }
                //}
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Some Required Documents not uploaded');", true);
            }
        }

        ///
    }
}