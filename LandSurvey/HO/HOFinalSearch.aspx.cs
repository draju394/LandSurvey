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
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocToPDFConverter;

using System.Net;
using System.Collections.Specialized;
using Ionic.Zip;

namespace LandSurvey.HO
{
    public partial class HOFinalSearch : System.Web.UI.Page
    {
        DataSet dsVillage = new DataSet();
        dbVillage dbVillageData = new dbVillage();

        DataSet dsFamilyDocNoNew = new DataSet();
        dbFamilyDetails dbFamilyDetailsData = new dbFamilyDetails();

        DataSet dsShowAllDocData = new DataSet();

        dbFileNo dbFileNoData = new dbFileNo();
        dbDocument dbDocumentStatusData = new dbDocument();
        DataSet dsDocumenteExists = new DataSet();

        DataSet dsGetPublicNotice = new DataSet();

        CommonFunction CFunction = new CommonFunction();

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
                    DisableControl();
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
                DisableControl();
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
                ShowDocumentTitleSearch();
            }
        }

        protected void ShowAllDocumentData()
        {
            if (cmbVillage.SelectedIndex > 0 & cmbDocumentNo.SelectedIndex > 0)
            {

                dsShowAllDocData = dbFamilyDetailsData.getFinalDocument(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString());
                if (dsShowAllDocData.Tables[0].Rows.Count > 0)
                {
                   // DataTable FamilyDocDetails = dsShowAllDocData.Tables[0];
                    grdFamilyDocDetails.DataSource = dsShowAllDocData;
                    grdFamilyDocDetails.DataBind();
                    EnableControl();
                }
                else
                {
                    grdFamilyDocDetails.DataSource = null;
                    grdFamilyDocDetails.DataBind();
                    DisableControl();
                }
            }

        }

        private void DisableControl()
        {
            btnDownloadAll.Enabled = false;
            btnGenerateReport.Enabled = false;
            btnSendSolicitor.Enabled = false;
        }

        private void EnableControl()
        {
            btnDownloadAll.Enabled = true;
            btnGenerateReport.Enabled = true;
            btnSendSolicitor.Enabled = true;
        }

        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {

            //Syncfusion PDF 
            Syncfusion.Pdf.PdfDocument[] documents = new Syncfusion.Pdf.PdfDocument[10];
            string[] allPDFDocument = new string[10];

            List<string> listPDF = new List<string>();
            DocToPDFConverter converter = new DocToPDFConverter();
            dsShowAllDocData = dbFamilyDetailsData.getFinalDocument(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString());
            if (dsShowAllDocData.Tables[0].Rows.Count > 0)
            {
                int i = 0;
                foreach (DataRow rows in dsShowAllDocData.Tables[0].Rows)
                {
                    string DocFileName = rows["filename"].ToString();
                    if (DocFileName != "" && !string.IsNullOrEmpty(DocFileName))
                    {
                        string FileExist = Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + DocFileName);
                        if (File.Exists(FileExist))
                        {
                            string fileextension = Path.GetExtension(FileExist.ToString());
                            switch (fileextension)
                            {
                                case ".docx":
                                    WordDocument wordDocumentdocx = new WordDocument(FileExist, FormatType.Docx);
                                    string FolderNameDocx = Server.MapPath(@"~/TempFile/" + cmbVillage.SelectedValue.ToString() + "/");
                                    if (!Directory.Exists(FolderNameDocx))
                                    {
                                        Directory.CreateDirectory(FolderNameDocx);
                                    }
                                    documents[i] = converter.ConvertToPDF(wordDocumentdocx);
                                    string genfilenameDocx = wordDocumentdocx + "_" + i;
                                    //Response.WriteFile(Server.MapPath(@"~/Documents/" + lblVillageCodeHidden.Text + "/" + lbllinkRegisrationSearch.Text));
                                    documents[i].Save(FolderNameDocx + genfilenameDocx + ".pdf");
                                    allPDFDocument[i] = FolderNameDocx + genfilenameDocx + ".pdf";
                                    //documents[i].Save(@"F:\\DocToPDF1.pdf");
                                    listPDF.Add(FolderNameDocx + genfilenameDocx + ".pdf");
                                    break;

                                case ".doc":
                                    WordDocument wordDocumentDoc = new WordDocument(FileExist, FormatType.Doc);
                                    documents[i] = converter.ConvertToPDF(wordDocumentDoc);
                                    string genfilenameDoc = wordDocumentDoc + "_" + i;
                                    //Response.WriteFile(Server.MapPath(@"~/Documents/" + lblVillageCodeHidden.Text + "/" + lbllinkRegisrationSearch.Text));
                                    string FolderNameDoc = Server.MapPath(@"~/TempFile/" + cmbVillage.SelectedValue.ToString() + "/");
                                    if (!Directory.Exists(FolderNameDoc))
                                    {
                                        Directory.CreateDirectory(FolderNameDoc);
                                    }

                                    documents[i].Save(FolderNameDoc + genfilenameDoc + ".pdf");
                                    allPDFDocument[i] = FolderNameDoc + genfilenameDoc + ".pdf";
                                    //documents[i].Save(@"F:\\DocToPDF1.pdf");
                                    listPDF.Add(FolderNameDoc + genfilenameDoc + ".pdf");
                                    break;

                                case ".pdf":

                                    string FolderNamePDF = Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + DocFileName);
                                    if (!File.Exists(FolderNamePDF))
                                    {
                                        //Directory.CreateDirectory(FolderNameDoc);
                                    }
                                    else
                                    {
                                        //listPDF.Add(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + FileExist + ".pdg");
                                        listPDF.Add(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + DocFileName));
                                    }


                                    break;
                            }
                        }
                    }
                    i = i + 1;
                }//FOr End

                Syncfusion.Pdf.PdfDocument newPdf1 = new Syncfusion.Pdf.PdfDocument();
                //DocToPDFConverter converter2 = new DocToPDFConverter();

                string[] listPDFArray = listPDF.ToArray();

                Syncfusion.Pdf.PdfDocumentBase.Merge(newPdf1, listPDFArray);
                //newPdf1.Save(@"F:\\newPDFRSD.pdf");
                //newPdf1.Close(true);

                try
                {
                    string registerFileNo = dbFileNoData.getFileNo("FTS");
                    //string filename = Path.GetFileName(FControlName.FileName);
                    string fileExtension = ".pdf";
                    string VillageCode = cmbVillage.SelectedValue.ToString();
                    string DocumentNo = cmbDocumentNo.SelectedValue.ToString();
                    string NewFileName = "FTS" + "_" + VillageCode + "_" + DocumentNo + "_" + registerFileNo + fileExtension;
                    string folderName = Server.MapPath("~/Documents/" + VillageCode + "/");
                    if (!Directory.Exists(folderName))
                    {
                        Directory.CreateDirectory(folderName);
                    }
                    newPdf1.Save(folderName + NewFileName);
                    newPdf1.Close(true);
                    //  FControlName.SaveAs(folderName + NewFileName);

                    dbFileNoData.registername = "FTS";
                    dbFileNoData.currentno = Convert.ToInt32(registerFileNo) + 1;
                    dbFileNoData.UpdateFileNo();
                    lbllnkFTS.Text = NewFileName;
                    string FinalPath = folderName + NewFileName;
                    ViewState["filepath"] = FinalPath;

                    //Insert in to Document Status
                    string DocumentID = dbDocumentStatusData.getDocumentSeqNo();
                    dbDocumentStatusData.documentid = Convert.ToInt32(DocumentID);
                    dbDocumentStatusData.villagecode = cmbVillage.SelectedValue.ToString();
                    dbDocumentStatusData.documentcode = "FTS";
                    dbDocumentStatusData.documentname = NewFileName;
                    dbDocumentStatusData.documentpath = ViewState["filepath"].ToString();
                    dbDocumentStatusData.createdby = Session["UserName"].ToString();
                    dbDocumentStatusData.createddate = DateTime.Today;
                    dbDocumentStatusData.docno = cmbDocumentNo.SelectedValue.ToString();
                    //Check For Record Exist 
                    dsDocumenteExists = dbDocumentStatusData.DocumentExistRO(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString(), "FTS");
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
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Final Title Search Report File Not Uploaded');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Final Title Search Report File Uploaded');", true);
                            SendSMS("1");
                        }
                    }
                    else
                    {
                        bool DocumentFileUpdate = dbDocumentStatusData.UpdateDocumentStatusFile();
                        if (DocumentFileUpdate)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Final Title Search Report Not Uploaded');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Final Title Search Report File Update');", true);
                            SendSMS("5");
                        }
                    }
                }
                catch (Exception ex)
                {

                }

            }


            }

        protected void lbllnkFTS_Click(object sender, EventArgs e)
        {
            string FileExist = Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lbllnkFTS.Text);
            if (File.Exists(FileExist))
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + lbllnkFTS.Text);
                Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lbllnkFTS.Text));
                Response.End();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Selected File Not exists on Storage');", true);
                ShowAllDocumentData();
                ShowDocumentTitleSearch();
                
            }
        }

        private void ShowDocumentTitleSearch()
        {

            DataSet dsGetAllDocuments;
            dsGetAllDocuments = dbDocumentStatusData.GetDocumentFromCode(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString(), "FTS", "SO1");
            if (dsGetAllDocuments.Tables[0].Rows.Count > 0)
            {
                string UploadedDocument = dsGetAllDocuments.Tables[0].Rows[0]["documentname"].ToString();
                lbllnkFTS.Text = UploadedDocument;

            }
            else
            {
                lbllnkFTS.Text = "";
                //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Some Required Documents not uploaded');", true);
            }
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
                         string MobileMessage = "Document is sent to you for approval ";
                        fnCommon.sendsms("+91" + UserMobileNo, MobileMessage);

                    }
                }
            }
            //dbUserData.UserName = Session["UserName"].ToString();
            //string MobileNo = dbUserData.GetMobileNo();
            

                //String message = HttpUtility.UrlEncode("This is test Message from -- SEZTHANE");
                //using (var wb = new WebClient())
                //{
                //    byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                //    {
                //    {"apikey" , "MK7fugiPrhQ-7bOiwEjRcBqziqL2eH9r6QITPtS2K6"},
                //    //{"numbers" , "919890037859"},
                //     {"numbers" , "919890037859"},
                //    {"message" , message},
                //    {"sender" , "SEZTHA"}
                //    });
                //    string result = System.Text.Encoding.UTF8.GetString(response);
                //    //return result;
                //}
            }

        protected void btnSendSolicitor_Click(object sender, EventArgs e)
        {
            if (lbllnkFTS.Text != "")
            {
                dbDocumentStatusData.villagecode = cmbVillage.SelectedValue.ToString();
                dbDocumentStatusData.documentcode = "FTS";
                dbDocumentStatusData.docno = cmbDocumentNo.SelectedValue.ToString();
                dbDocumentStatusData.solicitorsentdate = DateTime.Today;
                dbDocumentStatusData.officename = "SO1";
                bool UpdateSolicitr = dbDocumentStatusData.UpdateDocumentStatusApproval("HO");
                if (UpdateSolicitr)
                {

                }
                else
                {
                    //Send SMS 
                    //Solicitor Role is 4 
                    SendSMS("4");
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Final Title Search Report Sent to Head Office for Approval');", true);
                }



            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('FInal Title Search Report not Generated');", true);
            }
        }

        protected void btnDownloadAll_Click(object sender, EventArgs e)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                zip.AddDirectoryByName("FinalTileSearch");
                dsShowAllDocData = dbFamilyDetailsData.getFinalDocument(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString());
                //dsShowAllDocData = dbFamilyDetailsData.getFinalDocument(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString());
                if (dsShowAllDocData.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow rows in dsShowAllDocData.Tables[0].Rows)
                    {
                        string DocFileName = rows["docfile"].ToString();
                        if (DocFileName != "" && !string.IsNullOrEmpty(DocFileName))
                        {
                            string FileExist = Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + DocFileName);
                            if (File.Exists(FileExist))
                            {
                                zip.AddFile(FileExist, "FinalTileSearch");
                            }
                        }
                    }
                }
                Response.Clear();
                Response.BufferOutput = false;
                string zipName = String.Format("PrimaryTS_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                Response.ContentType = "application/zip";
                Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                zip.Save(Response.OutputStream);
                Response.End();
            }

        }
        //
    }
}