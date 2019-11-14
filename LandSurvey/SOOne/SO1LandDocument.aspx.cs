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
using System.Net;

namespace LandSurvey.SOOne
{
    public partial class SO1LandDocument : System.Web.UI.Page
    {
        DataSet dsVillage = new DataSet();
        dbVillage dbVillageData = new dbVillage();

        DataSet dsFamilyDocNoNew = new DataSet();
        dbFamilyDetails dbFamilyDetailsData = new dbFamilyDetails();

        DataSet dsShowAllDocData = new DataSet();

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
                    ButtonDisabled();

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
                grdFamilyDocDetails.DataSource = null;
                grdFamilyDocDetails.DataBind();
                ButtonDisabled();

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
                string strFamilyNo = dbFamilyDetailsData.getFamilyNoOnDocNo(cmbDocumentNo.SelectedValue.ToString().Trim());

                ShowAllDocumentData();
            }
        }

        protected void ShowAllDocumentData()
        {
            if (cmbVillage.SelectedIndex > 0 & cmbDocumentNo.SelectedIndex > 0)
            {

                dsShowAllDocData = dbFamilyDetailsData.getSO1LandDocument(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString());
                if (dsShowAllDocData.Tables[0].Rows.Count > 0)
                {
                   // DataTable FamilyDocDetails = dsShowAllDocData.Tables[0];
                    grdFamilyDocDetails.DataSource = dsShowAllDocData;
                    grdFamilyDocDetails.DataBind();
                    ButtonEnable();
                }
                else
                {
                    grdFamilyDocDetails.DataSource = null;
                    grdFamilyDocDetails.DataBind();

                }
            }

        }

        protected void btnView712_Click(object sender, EventArgs e)
        {
            if(grdFamilyDocDetails.SelectedIndex >=0 )
            {
                //Show 7/12   
                string Sel_SurveyNo = grdFamilyDocDetails.SelectedRow.Cells[3].Text;
                string PDFFileName712 = dbFamilyDetailsData.getDocNo712(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString(), Sel_SurveyNo);
        
                if(PDFFileName712 != "")
                {
                    string FilePath = Server.MapPath("~/7-12PDF/" + PDFFileName712.Trim() + ".pdf");
                    if (!File.Exists(FilePath))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Selected Survey No 7/12 Not available');", true);
                    }
                    else
                    {
                        Response.Clear();
                        Response.Clear();
                        Response.ContentType = "application/octet-stream";
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + PDFFileName712 + ".pdf");
                        Response.WriteFile(Server.MapPath(@"~/7-12PDF/" + PDFFileName712.Trim() + ".pdf"));
                        Response.End();

                       
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Family Details Survey No ');", true);
            }
        }

        protected void btnViewMutation_Click(object sender, EventArgs e)
        {
            string VillageCodeSel = cmbVillage.SelectedValue.ToString();
            string DocmentNoSel = cmbDocumentNo.SelectedValue.ToString();
            DataSet dsMSRFileName = dbFamilyDetailsData.GetFileNameFromDocumentStatus(VillageCodeSel, DocmentNoSel, "MSR");
            if (dsMSRFileName.Tables[0].Rows.Count > 0)
            {


                string MutationRegister = dsMSRFileName.Tables[0].Rows[0]["documentname"].ToString();
                string FilePath = Server.MapPath("~/Documents/" + VillageCodeSel + "/" + MutationRegister);
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

        protected void grdFamilyDocDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string selectedIndex; 
        }

        protected void grdFamilyDocDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdFamilyDocDetails.PageIndex = e.NewPageIndex;
            ShowAllDocumentData();
        }

        private void ButtonEnable()
        {
            btnView712.Enabled = true;
            btnView8A.Enabled = true;
            btnViewMutation.Enabled = true;
        }

        private void ButtonDisabled()
        {
            btnView712.Enabled = false;
            btnView8A.Enabled = false;
            btnViewMutation.Enabled = false;
        }
        //
    }

}

