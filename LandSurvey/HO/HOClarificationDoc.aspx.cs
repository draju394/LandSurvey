using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LandSurvey.DAL;
using System.IO;
using System.Data;

namespace LandSurvey.HO
{
    public partial class HOClarificationDoc : System.Web.UI.Page
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
                ShowClarificationDoc();

            }
        }

        protected void btnClrPTS_Click(object sender, EventArgs e)
        {
            if (FileUploadClrPTS.HasFiles)
            {
                try
                {
                    GenerateFileName("CPTS", FileUploadClrPTS, lbllinkClrPTS);

                }
                catch (Exception ex)
                {


                }

            }
        }

        protected void btnClrFTS_Click(object sender, EventArgs e)
        {
            if (FileUploadClrFTS.HasFiles)
            {
                try
                {
                    GenerateFileName("CFTS", FileUploadClrFTS, lbllnkClrFTS);

                }
                catch (Exception ex)
                {


                }

            }
        }

        protected void btnClrNotice_Click(object sender, EventArgs e)
        {
            if (FileUploadClrNotice.HasFiles)
            {
                try
                {
                    GenerateFileName("CPN", FileUploadClrNotice, lbllinkClrNotice);

                }
                catch (Exception ex)
                {


                }

            }
        }

        protected void lbllinkClrPTS_Click(object sender, EventArgs e)
        {
            string FileExist = Server.MapPath(@"~/Documents/" + Server.UrlDecode(Request.QueryString["Village"]) + "/" + lbllinkClrPTS.Text);
            if (File.Exists(FileExist))
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + lbllinkClrPTS.Text);
                Response.WriteFile(Server.MapPath(@"~/Documents/" + Server.UrlDecode(Request.QueryString["Village"]) + "/" + lbllinkClrPTS.Text));
                Response.End();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('File Not Exisits');", true);
               // ShowGridHolderDataNew();
            }
        }

        protected void lbllnkClrFTS_Click(object sender, EventArgs e)
        {
            string FileExist = Server.MapPath(@"~/Documents/" + Server.UrlDecode(Request.QueryString["Village"]) + "/" + lbllnkClrFTS.Text);
            if (File.Exists(FileExist))
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + lbllnkClrFTS.Text);
                Response.WriteFile(Server.MapPath(@"~/Documents/" + Server.UrlDecode(Request.QueryString["Village"]) + "/" + lbllnkClrFTS.Text));
                Response.End();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('File Not Exisits');", true);
                // ShowGridHolderDataNew();
            }
        }

        protected void lbllinkClrNotice_Click(object sender, EventArgs e)
        {
            string FileExist = Server.MapPath(@"~/Documents/" + Server.UrlDecode(Request.QueryString["Village"]) + "/" + lbllinkClrNotice.Text);
            if (File.Exists(FileExist))
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + lbllinkClrNotice.Text);
                Response.WriteFile(Server.MapPath(@"~/Documents/" + Server.UrlDecode(Request.QueryString["Village"]) + "/" + lbllinkClrNotice.Text));
                Response.End();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('File Not Exisits');", true);
                // ShowGridHolderDataNew();
            }
        }

        private void GenerateFileName(string DocType, FileUpload FControlName, LinkButton LinkDoc)
        {
            try
            { 

                string registerFileNo = dbFileNoData.getFileNo(DocType);
                string filename = Path.GetFileName(FControlName.FileName);
                string fileExtension = System.IO.Path.GetExtension(FControlName.PostedFile.FileName);
                string VillageCode = lblVillageCode.Text;
                VillageCode = lblVillageCodeHidden.Text;
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
                dbDocumentStatusData.villagecode = lblVillageCodeHidden.Text;
                dbDocumentStatusData.documentcode = DocType;
                dbDocumentStatusData.documentname = NewFileName;
                dbDocumentStatusData.documentpath = ViewState["filepath"].ToString();
                dbDocumentStatusData.createdby = Session["UserName"].ToString();
                dbDocumentStatusData.createddate = DateTime.Today;
                dbDocumentStatusData.docno = LblDocNo.Text;
                //Check For Record Exist 
                dsDocumenteExists = dbDocumentStatusData.DocumentExistRO(lblVillageCodeHidden.Text, LblDocNo.Text, DocType);
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

        private void ShowClarificationDoc()
        {
            DataSet dsGetAllDocuments;
            dsGetAllDocuments = dbDocumentStatusData.GetClarificationDoc(lblVillageCodeHidden.Text, LblDocNo.Text, "HO");
            if (dsGetAllDocuments.Tables[0].Rows.Count > 0)
            {
                //string UploadedDocument = dsGetAllDocuments.Tables[0].Rows[0]["documentname"].ToString();
                //if(UploadedDocument != "")
                //{
                for (int i = 0; i < dsGetAllDocuments.Tables[0].Rows.Count; i++)
                {
                    string UploadedDocument = dsGetAllDocuments.Tables[0].Rows[i]["documentname"].ToString();
                    string DocumentCode = dsGetAllDocuments.Tables[0].Rows[i]["documentcode"].ToString();
                    if (DocumentCode == "CPTS") { lbllinkClrPTS.Text = UploadedDocument; }
                    if (DocumentCode == "CFTS") { lbllnkClrFTS.Text = UploadedDocument; }
                    if (DocumentCode == "CPN") { lbllinkClrNotice.Text = UploadedDocument; }
                   
                }
                //}
            }
            else
            {
               // ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Some Required Documents not uploaded');", true);
            }
        }
        ///
    }
}