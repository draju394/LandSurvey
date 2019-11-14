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

namespace LandSurvey.SOOne
{
    public partial class SOLandDocuments : System.Web.UI.Page
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
                    DataTable FamilyDocDetails = dsShowAllDocData.Tables[0];
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

        protected void grdFamilyDocDetails_ServerPdfExporting(object sender, Syncfusion.JavaScript.Web.GridEventArgs e)
        {

        }

        protected void btnView712_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Document Number ');", true);

            //var index = this.grdFamilyDocDetails.SelectedRowIndex;     //get the index of the selected row in current

            //List<Orders> data = ViewState["DataSource"] as List<Orders>;
            //if (this.grdFamilyDocDetails.PageSettings.CurrentPage > 1)
            //    index = this.grdFamilyDocDetails.PageSettings.PageSize * (this.grdFamilyDocDetails.PageSettings.CurrentPage - 1) + index;        //get index to retrieve the data from the dataSource based on the pagesize and currenpage
            //var selectedData = data[index];    //selectedData contains the current selected Row data
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

        protected void grdFamilyDocDetails_ServerEditRow(object sender, GridEventArgs e)
        {

        }

        protected void grdFamilyDocDetails_ServerCommandButtonClick(object sender, GridEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Document Number ');", true);
        }

        protected void grdFamilyDocDetails_ServerPdfExporting1(object sender, GridEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Document Number ');", true);
        }

        protected void grdFamilyDocDetails_ServerPdfExporting2(object sender, GridEventArgs e)
        {

        }

        protected void grdFamilyDocDetails_ServerRowSelected(object sender, GridEventArgs e)
        {
            //int Selectedrow = Convert.ToInt32(e.Arguments);
            //var reflector = this.grdFamilyDocDetails.ViewStateMode.GetPropertyAccessProvider();
            //var Selec = grdFamilyDocDetails.SelectedRowIndex;
            //var cellval = grdFamilyDocDetails.Columns[1];
            //var cell_value = reflector.GetValue(row, cellvalue);// Reflect the cell Value 

            for (int index = 0; index < e.Arguments.Count; index++)
            {
                var item = e.Arguments.ElementAt(index);
                var itemKey = item.Key;
                if(itemKey == "data")
                {
                    //if(itemKey.Contains("surveyno"))
                    //{
                      
                    //}
                    

                    var itemValue = item.Value;
                    


                }
             
              
            
                
            }
        }

        //
    }
}