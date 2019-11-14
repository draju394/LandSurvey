using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LandSurvey.DAL;
using Ionic.Zip;
using System.IO;

namespace LandSurvey.HO
{
    public partial class HODOCSiteOne : System.Web.UI.Page
    {
        DataSet dsVillage = new DataSet();
        dbVillage dbVillageData = new dbVillage();

        DataSet dsFamilyDocNoNew = new DataSet();
        dbFamilyDetails dbFamilyDetailsData = new dbFamilyDetails();
        dbDocument dbDocumentStatusData = new dbDocument();

        DataSet dsShowAllDocData = new DataSet();
        DataSet dsGetAllDocuments = new DataSet();

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
                    DisableControl();
                }
                else
                {
                    DataTable dt = new DataTable();
                    //grdFamilyDocDetails.DataSource = dt;
                    //grdFamilyDocDetails.DataBind();

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
                
                dsGetAllDocuments = dbDocumentStatusData.HO_GetDocFromSO(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString(), "SO1");
                if (dsGetAllDocuments.Tables[0].Rows.Count > 0)
                {
                    grdSiteOfficeDocAll.DataSource = dsGetAllDocuments;
                    grdSiteOfficeDocAll.DataBind();
                    EnablesControl();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Documents not Generated ');", true);
                }
            }
        }

        protected void btnSubmitDoc_Click(object sender, EventArgs e)
        {
            bool UpdateSolicitr = false;
            if (cmbSelectClient.SelectedValue.ToString() != "") 
            {
               
                dbDocumentStatusData.villagecode = cmbVillage.SelectedValue.ToString();
             
                dbDocumentStatusData.docno = cmbDocumentNo.SelectedValue.ToString();
                dbDocumentStatusData.solicitorsentdate = DateTime.Today;
                dbDocumentStatusData.officename = "HO";
                //dsGetAllDocuments = dbDocumentStatusData.HO_GetDocFromSO(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString(), "SO1");
                //  dsShowAllDocData = dbFamilyDetailsData.getSOOfficeDocument(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString());
                //if (dsGetAllDocuments.Tables[0].Rows.Count > 0)
                //{
                    foreach (GridViewRow row in grdSiteOfficeDocAll.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[0].FindControl("chkSelect") as CheckBox);
                            if (chkRow.Checked)
                            {
                                string name = row.Cells[1].Text;
                                // string country = (row.Cells[2].FindControl("lblCountry") as Label).Text;
                                // dt.Rows.Add(name, country);
                                string DocumentCode = row.Cells[2].Text;
                                dbDocumentStatusData.documentcode = DocumentCode;
                                dbDocumentStatusData.solicitorapproval = "No";
                                if (cmbSelectClient.SelectedValue.ToString() == "Solicitor")
                                {
                                    UpdateSolicitr = dbDocumentStatusData.UpdateDocumentStatusApproval("Solicitor");
                                }
                                else
                                {
                                    UpdateSolicitr = dbDocumentStatusData.UpdateDocumentStatusApproval("Client");
                                }
                            }
                        }
                    }
                    //foreach (DataRow rows in dsGetAllDocuments.Tables[0].Rows)
                    //{
                    //    string DocumentCode = rows["documentcode"].ToString();
                    //    dbDocumentStatusData.documentcode = DocumentCode;
                    //    if (cmbSelectClient.SelectedValue.ToString() == "Solicitor")
                    //    {
                    //        UpdateSolicitr = dbDocumentStatusData.UpdateDocumentStatusApproval("Solicitor");
                    //    }
                    //    else
                    //    {
                    //        UpdateSolicitr = dbDocumentStatusData.UpdateDocumentStatusApproval("Client");
                    //    }

                    //} // For Each End

                //} //If End
                //End For Loop
                if (UpdateSolicitr)
                {

                }
                else
                {
                    //Send SMS 
                    SendSMS("1");
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Document sent for Approval');", true);
                    dsGetAllDocuments = dbDocumentStatusData.HO_GetDocFromSO(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString(), "SO1");
                    if (dsGetAllDocuments.Tables[0].Rows.Count > 0)
                    {
                        grdSiteOfficeDocAll.DataSource = dsGetAllDocuments;
                        grdSiteOfficeDocAll.DataBind();

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Documents not Generated ');", true);
                    }
                }



            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enable to Send Document for Approval');", true);
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

        protected void btnDownloadDoc_Click(object sender, EventArgs e)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                zip.AddDirectoryByName("HOAllDocument");
                dsGetAllDocuments = dbDocumentStatusData.HO_GetDocFromSO(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString(), "SO1");
                //  dsShowAllDocData = dbFamilyDetailsData.getSOOfficeDocument(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString());
                if (dsGetAllDocuments.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow rows in dsGetAllDocuments.Tables[0].Rows)
                    {
                        string DocFileName = rows["documentname"].ToString();
                        if (DocFileName != "" && !string.IsNullOrEmpty(DocFileName))
                        {
                            string FileExist = Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + DocFileName);
                            if (File.Exists(FileExist))
                            {
                                zip.AddFile(FileExist, "HOAllDocument");
                            }
                        }
                    }
                }
                Response.Clear();
                Response.BufferOutput = false;
                string zipName = String.Format("HOAllDocument_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                Response.ContentType = "application/zip";
                Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                zip.Save(Response.OutputStream);
                Response.End();
            }
        }

        private void DisableControl()
        {
            btnDownloadDoc.Enabled = false;
            btnSubmitDoc.Enabled = false;
            cmbSelectClient.Enabled = false;
        }
        private void EnablesControl()
        {
            btnDownloadDoc.Enabled = true;
            btnSubmitDoc.Enabled = true;
            cmbSelectClient.Enabled = true;
        }
        //
    }
}