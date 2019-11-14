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
using Ionic.Zip;
using Spire.Doc;
using Spire.Xls;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using System.Net;
using System.Collections.Specialized;

namespace LandSurvey.HO
{
    public partial class HoPrimaryTS : System.Web.UI.Page
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
                    grdSiteOfficeDoc.DataSource = dt;
                    grdSiteOfficeDoc.DataBind();

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
                ShowPTS();
            }
        }

        protected void ShowAllDocumentData()
        {
            if (cmbVillage.SelectedIndex > 0 & cmbDocumentNo.SelectedIndex > 0)
            {

                dsShowAllDocData = dbFamilyDetailsData.getSOOfficeDocument(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString());
                if (dsShowAllDocData.Tables[0].Rows.Count > 0)
                {
                   // DataTable FamilyDocDetails = dsShowAllDocData.Tables[0];
                    grdSiteOfficeDoc.DataSource = dsShowAllDocData;
                    grdSiteOfficeDoc.DataBind();
                    EnableControl();
                    ShowPublicNoticeFile();
                }
                else
                {
                    grdSiteOfficeDoc.DataSource = null;
                    grdSiteOfficeDoc.DataBind();
                    DisableControl();
                    lbllinkPN.Text = "";
                }
            }

        }

        protected void grdFamilyDocDetails_ServerPdfExporting(object sender, GridEventArgs e)
        {

        }

        protected void grdSiteOfficeDoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdSiteOfficeDoc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void lbllinkPN_Click(object sender, EventArgs e)
        {
            string FileExist = Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lbllinkPN.Text);
            if (File.Exists(FileExist))
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + lbllinkPN.Text);
                Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lbllinkPN.Text));
                Response.End();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Selected File Not exists on Storage');", true);
                ShowAllDocumentData();
                ShowDocumentTitleSearch();
                ShowPTS();
            }
        }

        protected void btnGeneratePN_Click(object sender, EventArgs e)
        {
            if (grdSiteOfficeDoc.SelectedIndex >= 0)
            {

                string Sel_FileName = grdSiteOfficeDoc.SelectedRow.Cells[4].Text;
                if(string.IsNullOrEmpty(Sel_FileName))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Selected record is empty');", true);
                }
                else
                {
                    string FilePath = Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + Sel_FileName.Trim());
                    if (!File.Exists(FilePath))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Selected File Not exists on Storage');", true);
                    }
                    else
                    {
                        Response.Clear();
                        Response.Clear();
                        Response.ContentType = "application/octet-stream";
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + Sel_FileName);
                        Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + Sel_FileName.Trim()));
                        Response.End();


                    }
                }

            }
                //if (FileUploadControl.HasFiles)
                //{
                //    try
                //    {
                //        GenerateFileName("PN", FileUploadControl, lbllinkPN);

                //        //InsertDocumentStatus("MSR", NewFileName);

                //    }
                //    catch (Exception ex)
                //    {


                //    }

                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Public Notice File to Upload');", true);
                //}

            }

        private void GenerateFileName(string DocType, FileUpload FControlName, LinkButton LinkDoc)
        {


            //try
            //{

            //    string registerFileNo = dbFileNoData.getFileNo(DocType);
            //    string filename = Path.GetFileName(FControlName.FileName);
            //    string fileExtension = System.IO.Path.GetExtension(FControlName.PostedFile.FileName);
            //    string VillageCode = cmbVillage.SelectedValue.ToString();
            //    string DocumentNo = cmbDocumentNo.SelectedValue.ToString();
            //    string NewFileName = DocType + "_" + VillageCode + "_" + DocumentNo + "_" + registerFileNo + fileExtension;
            //    string folderName = Server.MapPath("~/Documents/" + VillageCode + "/");
            //    if (!Directory.Exists(folderName))
            //    {
            //        Directory.CreateDirectory(folderName);
            //    }
            //    FControlName.SaveAs(folderName + NewFileName);
               
            //    dbFileNoData.registername = DocType;
            //    dbFileNoData.currentno = Convert.ToInt32(registerFileNo) + 1;
            //    dbFileNoData.UpdateFileNo();
            //    LinkDoc.Text = NewFileName;
            //    string FinalPath = folderName + NewFileName;
            //    ViewState["filepath"] = FinalPath;

            //    //Insert in to Document Status
            //    string DocumentID = dbDocumentStatusData.getDocumentSeqNo();
            //    dbDocumentStatusData.documentid = Convert.ToInt32(DocumentID);
            //    dbDocumentStatusData.villagecode = cmbVillage.SelectedValue.ToString();
            //    dbDocumentStatusData.documentcode = DocType;
            //    dbDocumentStatusData.documentname = NewFileName;
            //    dbDocumentStatusData.documentpath = ViewState["filepath"].ToString();
            //    dbDocumentStatusData.createdby = Session["UserName"].ToString();
            //    dbDocumentStatusData.createddate = DateTime.Today;
            //    dbDocumentStatusData.docno = cmbDocumentNo.SelectedValue.ToString();
            //    //Check For Record Exist 
            //    dsDocumenteExists = dbDocumentStatusData.DocumentExistRO(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString(), DocType);
            //    if (dsDocumenteExists.Tables[0].Rows.Count == 0)
            //    {
            //        //string ModifiedSurveyNo = dbDocumentStatusData.surveyno;
            //        //dbDocumentStatusData.surveyno = ModifiedSurveyNo.Replace("'", "");
            //        dbDocumentStatusData.surveyno = "";
            //        dbDocumentStatusData.familyno = "";
            //        dbDocumentStatusData.titlesearchno = "";
            //        dbDocumentStatusData.officename = "HO";
            //        bool DocInsert = dbDocumentStatusData.AddDocumentStatus();
            //        if (DocInsert)
            //        {
            //            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('New File Not Uploaded');", true);
            //        }
            //        else
            //        {
            //            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('New Public Notice File Uploaded');", true);
            //        }
            //    }
            //    else
            //    {
            //        bool DocumentFileUpdate = dbDocumentStatusData.UpdateDocumentStatusFile();
            //        if (DocumentFileUpdate)
            //        {
            //            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('New File Not Uploaded');", true);
            //        }
            //        else
            //        {
            //            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('New Public Notice File Update');", true);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
        }

        private void ShowPublicNoticeFile()
        {
            lbllinkPN.Text = "";
            dsGetPublicNotice = dbDocumentStatusData.GetPublicNotice(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString(), "HO");
            if (dsGetPublicNotice.Tables[0].Rows.Count > 0)
            {
                string UploadedDocument = dsGetPublicNotice.Tables[0].Rows[0]["documentname"].ToString();
                string DocumentCode = dsGetPublicNotice.Tables[0].Rows[0]["documentcode"].ToString();
                if (DocumentCode == "PN") { lbllinkPN.Text = UploadedDocument; }
            }
        }

        private void ShowPTS()
        {
            lbllinkPN.Text = "";
            dsGetPublicNotice = dbDocumentStatusData.GetPTSForSite1(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString(), "SO1");
            if (dsGetPublicNotice.Tables[0].Rows.Count > 0)
            {
                string UploadedDocument = dsGetPublicNotice.Tables[0].Rows[0]["documentname"].ToString();
                string DocumentCode = dsGetPublicNotice.Tables[0].Rows[0]["documentcode"].ToString();
                if (DocumentCode == "PTS") { lbllnkTS.Text = UploadedDocument; }
            }
        }
        private void DisableControl()
        {
            btnDownloadAll.Enabled = false;
            btnGeneratePN.Enabled = false;
            btnGenerateReport.Enabled = false;
            btnSendSolicitor.Enabled = false;

        }

        private void EnableControl()
        {
            btnDownloadAll.Enabled = true;
            btnGeneratePN.Enabled = true;
            btnGenerateReport.Enabled = true;
            btnSendSolicitor.Enabled = true;
        }

        protected void btnDownloadAll_Click(object sender, EventArgs e)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                zip.AddDirectoryByName("PrimaryTileSearch");
                dsShowAllDocData = dbFamilyDetailsData.getSOOfficeDocument(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString());
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
                                zip.AddFile(FileExist, "PrimaryTileSearch");
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



            //dsShowAllDocData = dbFamilyDetailsData.getSOOfficeDocument(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString());
            //if (dsShowAllDocData.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow rows in dsShowAllDocData.Tables[0].Rows)
            //    {
            //        string DocFileName = rows["docfile"].ToString();
            //        if (DocFileName != "" && !string.IsNullOrEmpty(DocFileName))
            //        {
            //            string FileExist = Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + DocFileName);
            //            if(File.Exists(FileExist))
            //            {
            //                Response.Clear();
            //                Response.ContentType = "application/octet-stream";
            //                Response.AddHeader("Content-Disposition", "attachment; filename=" + DocFileName);
            //                Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + DocFileName));
            //                Response.End();
            //                Response.Redirect(FileExist);
            //            }
                                                
            //        }

            //    }
            //}



            //    string folderPath = @"C:\SEZThaneDownload\";                                                
            //if (!Directory.Exists(folderPath))
            //{
                
            //    Directory.CreateDirectory(folderPath);
            //}

            //foreach (GridViewRow row in grdSiteOfficeDoc.Rows) 
            //{
            //    //for (int i = 0; i < grdSiteOfficeDoc.Columns.Count; i++)
            //    //{
            //        string  cellText = row.Cells[4].Text.Trim();
                
            //    string FileName = cellText;
            //    if(FileName != "" && !string.IsNullOrEmpty(FileName))
            //    {
            //        Response.Clear();
            //        Response.ContentType = "application/octet-stream";
            //        Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName);
            //        Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + FileName));
            //      //  Response.End();
            //    }
            //    // String FilePath = "C:/...."; //Replace this
                //System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                //Response.ClearContent();
                //Response.Clear();
                //Response.ContentType = "text/plain";
                //Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
                // Response.TransmitFile(folderPath +"/" + FileName);
                //Response.Flush();
                //Response.End();

                //Response.ContentType = "image/jpeg";
                //Response.AppendHeader("Content-Disposition", "attachment; filename=SailBig.jpg");
                //Response.TransmitFile(Server.MapPath("~/images/sailbig.jpg"));
                //Response.End();



               
                //}
            //}
        }

        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
           
            //Syncfusion PDF 
            Syncfusion.Pdf.PdfDocument[] documents = new Syncfusion.Pdf.PdfDocument[10];
            string[] allPDFDocument = new string[10];

            List<string> listPDF = new List<string>();
            DocToPDFConverter converter = new DocToPDFConverter();
            dsShowAllDocData = dbFamilyDetailsData.getSOOfficeDocument(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString());
            if (dsShowAllDocData.Tables[0].Rows.Count > 0)
            {
               

                int i = 0;
                foreach (DataRow rows in dsShowAllDocData.Tables[0].Rows)
                {
                    string DocFileName = rows["docfile"].ToString();
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
                                //RSD
                                case ".doc":
                                    WordDocument wordDocumentDoc = new WordDocument(FileExist, FormatType.Doc);
                                    string FolderNameDoc = Server.MapPath(@"~/TempFile/" + cmbVillage.SelectedValue.ToString() + "/");
                                    if (!Directory.Exists(FolderNameDoc))
                                    {
                                        Directory.CreateDirectory(FolderNameDoc);
                                    }
                                    documents[i] = converter.ConvertToPDF(wordDocumentDoc);
                                    string genfilenameDoc = wordDocumentDoc + "_" + i;
                                    //Response.WriteFile(Server.MapPath(@"~/Documents/" + lblVillageCodeHidden.Text + "/" + lbllinkRegisrationSearch.Text));
                                    documents[i].Save(FolderNameDoc + genfilenameDoc + ".pdf");
                                    allPDFDocument[i] = FolderNameDoc + genfilenameDoc + ".pdf";
                                    //documents[i].Save(@"F:\\DocToPDF1.pdf");
                                    listPDF.Add(FolderNameDoc + genfilenameDoc + ".pdf");
                                    break;

                                case ".pdf":
                                    
                                    string FolderNamePDF = Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/"+ DocFileName);
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

                //Get All 7/12 File 
                DataSet dsGet712Files = new DataSet();
                List<string> listPDF712File = new List<string>();
                dsGet712Files = dbFamilyDetailsData.Get712files(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString());
                if(dsGet712Files.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow rows in dsGet712Files.Tables[0].Rows)
                    {
                        string PDFFileName712 = rows["pdffilename"].ToString();
                        if (PDFFileName712 != "" && !string.IsNullOrEmpty(PDFFileName712))
                        {
                            string FileExist = Server.MapPath(@"~/7-12PDF/" + PDFFileName712 +".pdf");
                            if (File.Exists(FileExist))
                            {
                                listPDF712File.Add(FileExist);
                            }
                        }
                    }
                    //Create 712 PDF FIle One
                    Syncfusion.Pdf.PdfDocument PDFFile712 = new Syncfusion.Pdf.PdfDocument();
                 
                    //Syncfusion.Pdf.PdfDocumentBase.Merge(PDFFile712, listPDFArray712);

                    //listPDF.Add(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + DocFileName));
                }


                //End 712file

                Syncfusion.Pdf.PdfDocument newPdf1 = new Syncfusion.Pdf.PdfDocument();
                //DocToPDFConverter converter2 = new DocToPDFConverter();

                string[] listPDFArray = listPDF.ToArray();
                string[] listPDFArray712 = listPDF712File.ToArray();
                Syncfusion.Pdf.PdfDocumentBase.Merge(newPdf1, listPDFArray);
                Syncfusion.Pdf.PdfDocumentBase.Merge(newPdf1, listPDFArray712);
                //newPdf1.Save(@"F:\\newPDFRSD.pdf");
                //newPdf1.Close(true);

                try
                {
                    string registerFileNo = dbFileNoData.getFileNo("PTS");
                    //string filename = Path.GetFileName(FControlName.FileName);
                    string fileExtension = ".pdf";
                    string VillageCode = cmbVillage.SelectedValue.ToString();
                    string DocumentNo = cmbDocumentNo.SelectedValue.ToString();
                    string NewFileName = "PTS" + "_" + VillageCode + "_" + DocumentNo + "_" + registerFileNo + fileExtension;
                    string folderName = Server.MapPath("~/Documents/" + VillageCode + "/");
                    if (!Directory.Exists(folderName))
                    {
                        Directory.CreateDirectory(folderName);
                    }
                    newPdf1.Save(folderName + NewFileName);
                    newPdf1.Close(true);
                  //  FControlName.SaveAs(folderName + NewFileName);

                    dbFileNoData.registername = "PTS";
                    dbFileNoData.currentno = Convert.ToInt32(registerFileNo) + 1;
                    dbFileNoData.UpdateFileNo();
                    lbllnkTS.Text = NewFileName;
                    string FinalPath = folderName + NewFileName;
                    ViewState["filepath"] = FinalPath;

                    //Insert in to Document Status
                    string DocumentID = dbDocumentStatusData.getDocumentSeqNo();
                    dbDocumentStatusData.documentid = Convert.ToInt32(DocumentID);
                    dbDocumentStatusData.villagecode = cmbVillage.SelectedValue.ToString();
                    dbDocumentStatusData.documentcode = "PTS";
                    dbDocumentStatusData.documentname = NewFileName;
                    dbDocumentStatusData.documentpath = ViewState["filepath"].ToString();
                    dbDocumentStatusData.createdby = Session["UserName"].ToString();
                    dbDocumentStatusData.createddate = DateTime.Today;
                    dbDocumentStatusData.docno = cmbDocumentNo.SelectedValue.ToString();
                    //Check For Record Exist 
                    dsDocumenteExists = dbDocumentStatusData.DocumentExistRO(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString(), "PTS");
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
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Primary Title Search Report File Not Uploaded');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Primary Title Search Report File Uploaded');", true);
                            SendSMS("5");
                        }
                    }
                    else
                    {
                        bool DocumentFileUpdate = dbDocumentStatusData.UpdateDocumentStatusFile();
                        if (DocumentFileUpdate)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Primary Title Search Report Not Uploaded');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Primary Title Search Report File Update');", true);
                            SendSMS("5");
                        }
                    }
                }
                catch (Exception ex)
                {

                }

            }

        }


        

        protected void lbllinkPrimaryTS_Click(object sender, EventArgs e)
        {

        }


        protected void lbllnkTS_Click(object sender, EventArgs e)
        {
            string FileExist = Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lbllnkTS.Text);
            if (File.Exists(FileExist))
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + lbllnkTS.Text);
                Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lbllnkTS.Text));
                Response.End();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Selected File Not exists on Storage');", true);
                ShowAllDocumentData();
                ShowDocumentTitleSearch();
                ShowPTS();
            }
        }

        private void ShowDocumentTitleSearch()
        {
           
            DataSet dsGetAllDocuments;
            dsGetAllDocuments = dbDocumentStatusData.DocumentExistInDocumentStatus(cmbVillage.SelectedValue.ToString(),cmbDocumentNo.SelectedValue.ToString(),"PTS","SO1");
            if (dsGetAllDocuments.Tables[0].Rows.Count > 0)
            {
                string UploadedDocument = dsGetAllDocuments.Tables[0].Rows[0]["documentname"].ToString();
                lbllnkTS.Text = UploadedDocument;
                
            }
            else
            {
                lbllnkTS.Text = "";
                //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Some Required Documents not uploaded');", true);
            }
        }

        protected void btnSendSolicitor_Click(object sender, EventArgs e)
        {
            if(lbllnkTS.Text != "")
            {
                dbDocumentStatusData.villagecode = cmbVillage.SelectedValue.ToString();
                dbDocumentStatusData.documentcode = "PTS";
                dbDocumentStatusData.docno = cmbDocumentNo.SelectedValue.ToString();
                dbDocumentStatusData.solicitorsentdate = DateTime.Today;
                dbDocumentStatusData.officename = "SO1";
                bool UpdateSolicitr = dbDocumentStatusData.UpdateDocumentStatusApproval("HO");
                if(UpdateSolicitr)
                {

                }
                else
                {
                    //Send SMS 
                    SendSMS("1");
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Primary Title Search Report Sent to Head Office for Approval');", true);
                }
                


            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Primary Title Search Report not Generated');", true);
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
                //}
            }
        }

        private void GetAll712Files()
        {

        }
            //
        }
    }