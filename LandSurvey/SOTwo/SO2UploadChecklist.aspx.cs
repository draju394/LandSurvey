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
    public partial class SO2UploadChecklist : System.Web.UI.Page
    {
        DataSet dsVillage = new DataSet();
        dbVillage dbVillageData = new dbVillage();

        DataSet dsFamilyDocNoNew = new DataSet();
        dbFamilyDetails dbFamilyDetailsData = new dbFamilyDetails();

        DataSet dsShowAllDocData = new DataSet();
        DataSet dsChkListTran = new DataSet();
        dbChkListTran dbChkListTranData = new dbChkListTran();
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
                    FillGrid();
                    btnCheckListSO2.Enabled = false;
                    btnSaveChklist.Enabled = false;


                }
                else
                {
                    DataTable dt = new DataTable();
                    grdCheckListEdit.DataSource = dt;
                    grdCheckListEdit.DataBind();
                    btnCheckListSO2.Enabled = false;
                    btnSaveChklist.Enabled = false;

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
                btnCheckListSO2.Enabled = false;
                btnSaveChklist.Enabled = false;
                grdCheckListEdit.DataSource = null;
                grdCheckListEdit.DataBind();
                btnCheckListSO2.Enabled = false;
                lbllinkCheckListSo2.Text = null;
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
                //ShowAllDocumentData();
                FillGrid();
                ShowDocumentsSO2Registry();
                btnCheckListSO2.Enabled = true;
            }
        }

        public void FillGrid()
        {
            if (cmbVillage.SelectedIndex > 0 & cmbDocumentNo.SelectedIndex > 0)
            {

                dsShowAllDocData = dbFamilyDetailsData.getSO1SubmitCheckList(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString(),"SO2");
                if (dsShowAllDocData.Tables[0].Rows.Count > 0)
                {
                    //  DataTable FamilyDocDetails = dsShowAllDocData.Tables[0];
                    grdCheckListEdit.DataSource = dsShowAllDocData;
                    grdCheckListEdit.DataBind();
                    grdCheckListEdit.Columns[3].HeaderStyle.Width = 30;
                    grdCheckListEdit.Columns[4].HeaderStyle.Width = 130;
                    btnCheckListSO2.Enabled = true;
                    btnSaveChklist.Enabled = true;
                }
                else
                {
                    grdCheckListEdit.DataSource = null;
                    grdCheckListEdit.DataBind();
                    btnCheckListSO2.Enabled = false;
                    btnSaveChklist.Enabled = false;

                }
            }
           
        }
             

        protected void grdFamilyDocDetails_ServerEditRow(object sender, GridEventArgs e)
        {
            
        }

        protected void grdCheckListEdit_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

       

        protected void grdCheckListEdit_RowEditing1(object sender, GridViewEditEventArgs e)
        {
            grdCheckListEdit.EditIndex = e.NewEditIndex;
            FillGrid();
        }

        protected void grdCheckListEdit_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label ChkListTranID = grdCheckListEdit.Rows[e.RowIndex].FindControl("ChkListTranID") as Label;
            TextBox SORemark = grdCheckListEdit.Rows[e.RowIndex].FindControl("chklistremark") as TextBox;
            dbChkListTranData.chklisttranno = Convert.ToInt32(ChkListTranID.Text.ToString());
            dbChkListTranData.siteofficereamrk = SORemark.Text.ToString();
            dbChkListTranData.villagecode = cmbVillage.SelectedValue.ToString().Trim();
            dbChkListTranData.docno = cmbDocumentNo.SelectedValue.ToString().Trim();
            dbChkListTranData.officename = "SO2";
            Int32 MCheckListNo = Convert.ToInt32(ChkListTranID.Text);
            bool CheckRecordExist = dbChkListTranData.CheckRecordExist(cmbVillage.SelectedValue.ToString().Trim(), cmbDocumentNo.SelectedValue.ToString().Trim(), MCheckListNo,"SO2");
            if (CheckRecordExist)
            {
                Boolean UpdateChkListTran = dbChkListTranData.UpdateChkListTranSO();
                FillGrid();
            }
            else
            {
                //Insert
                string ChkListTranNo = dbChkListTranData.getCheckListTranSeqNo();
                dbChkListTranData.chklisttranno = Convert.ToInt32(ChkListTranNo.ToString());
                Label ChkListName = grdCheckListEdit.Rows[e.RowIndex].FindControl("lblchklistname") as Label;
                dbChkListTranData.chklistname = ChkListName.Text;
                dbChkListTranData.familyno = "";
                Label ChkListMasterNo = grdCheckListEdit.Rows[e.RowIndex].FindControl("ChkListTranID") as Label;
                dbChkListTranData.chklstno = Convert.ToInt32(ChkListMasterNo.Text);
                Boolean InsertChkListTran = dbChkListTranData.AddCheckListTranSO();
                FillGrid();

            }

            grdCheckListEdit.EditIndex = -1;
            FillGrid();
        }

        protected void grdCheckListEdit_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdCheckListEdit.EditIndex = -1;
            FillGrid();
        }

        protected void grdCheckListEdit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdCheckListEdit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCheckListEdit.PageIndex = e.NewPageIndex;
            FillGrid();
        }

        protected void btnCheckListSO2_Click(object sender, EventArgs e)
        {
            if (FileUploadCheckListSO2.HasFiles)
            {
                try
                {
                    GenerateFileName("RCRS", FileUploadCheckListSO2, lbllinkCheckListSo2);

                    //InsertDocumentStatus("MSR", NewFileName);

                }
                catch (Exception ex)
                {


                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Choose File to Upload');", true);
            }
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
                dbDocumentStatusData.villagecode = VillageCode;
                dbDocumentStatusData.documentcode = DocType;
                dbDocumentStatusData.documentname = NewFileName;
                dbDocumentStatusData.documentpath = ViewState["filepath"].ToString();
                dbDocumentStatusData.createdby = Session["UserName"].ToString();
                dbDocumentStatusData.createddate = DateTime.Today;
                dbDocumentStatusData.docno = DocumentNo;
                //Check For Record Exist 
                dsDocumenteExists = dbDocumentStatusData.DocumentExistRO(VillageCode,DocumentNo, DocType);
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

        protected void lbllinkCheckListSo2_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + lbllinkCheckListSo2.Text);
            Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lbllinkCheckListSo2.Text));
            Response.End();
        }

        private void ShowDocumentsSO2Registry()
        {
            DataSet dsGetDocumentName;
            lbllinkCheckListSo2.Text = "";
            lblLinkChkList1.Text = "";
            dsGetDocumentName = dbDocumentStatusData.DocumentExistInDocumentStatus(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString(), "RCRS","SO2");
            if (dsGetDocumentName.Tables[0].Rows.Count > 0)
            {
                //string UploadedDocument = dsGetAllDocuments.Tables[0].Rows[0]["documentname"].ToString();
                //if(UploadedDocument != "")
                //{
                for (int i = 0; i < dsGetDocumentName.Tables[0].Rows.Count; i++)
                {
                    string UploadedDocument = dsGetDocumentName.Tables[0].Rows[i]["documentname"].ToString();
                    string DocumentCode = dsGetDocumentName.Tables[0].Rows[i]["documentcode"].ToString();
                    if (DocumentCode == "RCRS") { lbllinkCheckListSo2.Text = UploadedDocument; }
                    if (DocumentCode == "CRS") { lblLinkChkList1.Text = UploadedDocument; }
                    //if (DocumentCode == "FT") { lbllinkFamilyTree.Text = UploadedDocument; }
                    //if (DocumentCode == "CL") { lbllnkConcentLetter.Text = UploadedDocument; }
                    //if (DocumentCode == "ID") { lbllnkIDDoc.Text = UploadedDocument; }
                }
                //}
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Some Required Documents not uploaded');", true);
            }
        }

        protected void btnSaveChklist_Click(object sender, EventArgs e)
        {
            GenerateCheckListDoc();
        }

       

        private void GenerateCheckListDoc()
        {
            lblLinkChkList1.Text = "";
            string registerFileNo = dbFileNoData.getFileNo("CRS");
            //string ChkFileName = Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + "Rajendra.doc");
            string ChkFileName = "CRS_" + cmbVillage.SelectedValue.ToString() + "_" + cmbDocumentNo.SelectedValue.ToString() + "_" + registerFileNo + ".doc";
            Response.Clear();
            //Response.AddHeader("content-disposition", "attachment;filename=FileName.doc");
            Response.AddHeader("content-disposition", "attachment;filename=" + ChkFileName + "");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/doc";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            So1CheckList.RenderControl(htmlWrite);
            string path = Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + ChkFileName);
            StreamWriter sWriter = new StreamWriter(path);
            //FileUpload FileChk = new FileUpload();
            //FileChk. = ChkFileName.ToString();

            sWriter.Write(stringWrite.ToString());
            sWriter.Close();


            //update MR File Number
            dbFileNoData.registername = "CRS";
            dbFileNoData.currentno = Convert.ToInt32(registerFileNo) + 1;
            dbFileNoData.UpdateFileNo();
            lblLinkChkList1.Text = ChkFileName;
           
            //Insert in to Document Status
            string DocumentID = dbDocumentStatusData.getDocumentSeqNo();
            dbDocumentStatusData.documentid = Convert.ToInt32(DocumentID);
            dbDocumentStatusData.villagecode = cmbVillage.SelectedValue.ToString();
            dbDocumentStatusData.documentcode = "CRS";
            dbDocumentStatusData.documentname = ChkFileName;
            dbDocumentStatusData.documentpath = path;
            dbDocumentStatusData.createdby = Session["UserName"].ToString();
            dbDocumentStatusData.createddate = DateTime.Today;
            dbDocumentStatusData.docno = cmbDocumentNo.SelectedValue.ToString();
            //Check For Record Exist 
            dsDocumenteExists = dbDocumentStatusData.DocumentExistInDocStatus(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString(), "CRS", "SO2");
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
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Check List Remark Not Uploaded');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Check List Remark updated');", true);
                }
            }

            Response.Write(stringWrite.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void lblLinkChkList1_Click(object sender, EventArgs e)
        {
            string FileExist = Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lblLinkChkList1.Text);
            if (File.Exists(FileExist))
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + lblLinkChkList1.Text);
                Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lblLinkChkList1.Text));
                Response.End();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('File Not Exisits');", true);
                ShowDocumentsSO2Registry();
            }
        }
        //
    }
}