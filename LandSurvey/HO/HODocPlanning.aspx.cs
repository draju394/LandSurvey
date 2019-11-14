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

namespace LandSurvey.HO
{
    public partial class HoDocPlanning : System.Web.UI.Page
    {
        DataSet dsVillage = new DataSet();
        dbVillage dbVillageData = new dbVillage();

        DataSet dsFamilyDocNoNew = new DataSet();
        dbFamilyDetails dbFamilyDetailsData = new dbFamilyDetails();
        DataSet dsFamilyDocumnetNo = new DataSet();
        dbFileNo dbFileNoData = new dbFileNo();
        dbDocument dbDocumentStatusData = new dbDocument();
        DataSet dsDocumenttitleSearch = new DataSet();
        DataSet dsDocumenteExists = new DataSet();

        DataSet dsDocumentExitsShow = new DataSet();
        dbDocument dbDocumentStatusDataShow = new dbDocument();
        dbFamilyDetails dbFamilyDetailsUpdateAll = new dbFamilyDetails();

        public object ConfirmMessageResponse { get; private set; }

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
                   
                }
                else
                { 
                    DataTable dt = new DataTable();
                    grdFamilyDocDetails.DataSource = dt;
                    grdFamilyDocDetails.DataBind();
                    
                }

                btnMutationSave.Enabled = false;
                btnWithoutFile.Enabled = false;
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
                string selectedVillage = cmbVillage.SelectedValue.ToString().Trim();
                dsFamilyDocNoNew = dbFamilyDetailsData.getVillageDocNo(selectedVillage);
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
                btnMutationSave.Enabled = true;
                btnWithoutFile.Enabled = true;
                string selectedVillage = cmbVillage.SelectedValue.ToString().Trim();
                string selectedDocNo = cmbDocumentNo.SelectedValue.ToString().Trim();

                ShowGridHolderDataNew();

                    // Upload1.Enabled = true;
                int DocFileNo = Convert.ToInt32(dbFileNoData.getFileNo("DOCNO"));
                    txtDocNo.Text = "TS_" + selectedVillage + "_" + selectedDocNo + "_" + DocFileNo.ToString("000");
                    //Show Mutation Register 
                    dsDocumentExitsShow = dbDocumentStatusDataShow.DocumentExistMSR(cmbVillage.SelectedValue.ToString().Trim(), cmbDocumentNo.SelectedValue.ToString().Trim(), "MSR");
                    if (dsDocumentExitsShow.Tables[0].Rows.Count > 0)
                    {
                        lbllinkMR.Text = dsDocumentExitsShow.Tables[0].Rows[0]["documentname"].ToString();
                    }
                    else
                    {
                        lbllinkMR.Text = "Mutation Register Not Found";
                    }
            }

                
        }

       

        protected void lbllinkMR_Click(object sender, EventArgs e)
        {
            string FileExist = Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lbllinkMR.Text);
            if(File.Exists(FileExist))
            { 
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + lbllinkMR.Text);
            Response.WriteFile(Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + lbllinkMR.Text));
            Response.End();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('File Not Exisits');", true);
                ShowGridHolderDataNew();
            }
        }

        protected void Upload1_Complete(object sender, UploadBoxCompleteEventArgs e)
        {
            lbllinkMR.Text = e.Name;
        }

        
        protected void btnMutationSave_Click(object sender, EventArgs e)
        {

            //string confirmValue = Request.Form["confirm_value"];
            //if (confirmValue == "Yes")
            //{
            //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
            //}
            //else
            //{
            //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            //}


            if (FileUploadControl.HasFiles)
            {
                //DataTable dt = (DataTable)(grdFamilyDocDetails.Model.DataSource); 
                //var dat = dt.Rows.Count; // get the count from datatable 
                // var grdData = this.grdFamilyDocDetails.DataSource;
                //var count =grdData.
                if (cmbVillage.SelectedIndex > 0 & cmbDocumentNo.SelectedIndex > 0)
                {
                    DataSet dsFamilyDocumnetNoGridData = dbFamilyDetailsData.getFamilyOnDocumentSearch(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString());
                    if (dsFamilyDocumnetNoGridData.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            bool validateCMB = CheckcmbValue();
                            if (validateCMB)
                            {
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
                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Mutation register file uploaded and saved successfully');" + txtDocNo.Text, true);
                                ShowGridHolderDataNew();
                                btnMutationSave.Enabled = false;
                                btnWithoutFile.Enabled = false;
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select Family No, Village and Survey ');", true);

                            }



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
                ShowGridHolderDataNew();
            }
        }

        private bool CheckcmbValue()
        {
            if (cmbDocumentNo.SelectedIndex < 0)
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

        private bool InsertDocumentStatus(string DocType, string fileName)
        {
            if (txtDocNo.Text.Length < 3)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Document Number');", true);
                return false;
            }
            //else if (cmbFamily.SelectedIndex < 0)
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select family number');", true);
            //    return false;
            //}
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

                ///

                dbDocumentStatusData.documentcode = DocType;
                dbDocumentStatusData.documentname = fileName;
                dbDocumentStatusData.documentpath = ViewState["filepath"].ToString();
                dbDocumentStatusData.createdby = "RSD";
                dbDocumentStatusData.createddate = DateTime.Today;
                dbDocumentStatusData.docno = cmbDocumentNo.SelectedValue.ToString().Trim();
                dbDocumentStatusData.officename = "HO";
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
                    bool DocumentFileUpdate = dbDocumentStatusData.UpdateDocumentFileRO(cmbDocumentNo.SelectedValue.ToString().Trim());
                    if (DocumentFileUpdate)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('New File updated');", true);
                    }
                }
                return true;
            }

        }

        protected void ShowGridHolderDataNew()
        {
            if(cmbVillage.SelectedIndex >0 & cmbDocumentNo.SelectedIndex >0 )
            {
                dsFamilyDocumnetNo = dbFamilyDetailsData.getFamilyOnDocumentSearch(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString());
                if (dsFamilyDocumnetNo.Tables[0].Rows.Count > 0)
                {
                    DataTable FamilyDocDetails = dsFamilyDocumnetNo.Tables[0];
                    grdFamilyDocDetails.DataSource = FamilyDocDetails;
                    grdFamilyDocDetails.DataBind();

                }
                else
                {
                    grdFamilyDocDetails.DataSource = null;
                    grdFamilyDocDetails.DataBind();

                }
            }

        }

        protected void cmbDocumentNo_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void btnWithoutFile_Click(object sender, EventArgs e)
        {
           // InsertDocumentStatus("MSR", "");
            //Update family Details Table with Doc No 
            DataSet dsFamilyDocumnetNoGridData = dbFamilyDetailsData.getFamilyOnDocumentSearch(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString());
            if (dsFamilyDocumnetNoGridData.Tables[0].Rows.Count > 0)
            {

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
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Document Executed without Mutation register file');" + txtDocNo.Text, true);
                ShowGridHolderDataNew();
                btnMutationSave.Enabled = false;
                btnWithoutFile.Enabled = false;
            }

        }

        protected void grdFamilyDocDetails_ServerPdfExporting(object sender, GridEventArgs e)
        {

        }

        ///
    }
}