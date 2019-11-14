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
using Syncfusion.DocIO.DLS;
using Syncfusion.DocToPDFConverter;

namespace LandSurvey.HO
{
    public partial class HOSolicitorDoc : System.Web.UI.Page
    {
        DataSet dsVillage = new DataSet();
        dbVillage dbVillageData = new dbVillage();

        DataSet dsFamilyDocNoNew = new DataSet();
        dbFamilyDetails dbFamilyDetailsData = new dbFamilyDetails();

        DataSet dsDocSubmittedtoSolicitor = new DataSet();

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
                    btnClarificationDocument.Enabled = false;
                }
                else
                {
                    DataTable dt = new DataTable();
                    grdFamilyDocDetails.DataSource = dt;
                    grdFamilyDocDetails.DataBind();
                    btnClarificationDocument.Enabled = false;
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
                //lblDocNo.Text = cmbDocumentNo.SelectedValue.ToString();
                //lblFamily.Text = strFamilyNo;
                ShowAllDocumentData();
                
            }
        }

        protected void ShowAllDocumentData()
        {
            if (cmbVillage.SelectedIndex > 0 & cmbDocumentNo.SelectedIndex > 0)
            {

                dsDocSubmittedtoSolicitor = dbFamilyDetailsData.getHOSolicitDocumentSubmitted(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString());
                if (dsDocSubmittedtoSolicitor.Tables[0].Rows.Count > 0)
                {
                    DataTable FamilyDocDetails = dsDocSubmittedtoSolicitor.Tables[0];
                    grdFamilyDocDetails.DataSource = FamilyDocDetails;
                    grdFamilyDocDetails.DataBind();
                    btnClarificationDocument.Enabled = true;

                }
                else
                {
                    grdFamilyDocDetails.DataSource = null;
                    grdFamilyDocDetails.DataBind();
                    btnClarificationDocument.Enabled = false;

                }
            }

        }

        protected void grdFamilyDocDetails_ServerPdfExporting(object sender, GridEventArgs e)
        {

        }

        protected void btnClarificationDocument_Click(object sender, EventArgs e)
        {
            string VillageCode = cmbVillage.SelectedValue.ToString();
            string DocNo = cmbDocumentNo.SelectedValue.ToString();
            Response.Redirect(String.Format("HOClarificationDoc.aspx?Village={0}&Doc={1}", Server.UrlEncode(VillageCode), Server.UrlEncode(DocNo)));
        }

        protected void btnDownloadDocument_Click(object sender, EventArgs e)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                zip.AddDirectoryByName("SolicitorDoc");
                dsDocSubmittedtoSolicitor = dbFamilyDetailsData.getHOSolicitDocumentSubmitted(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString());
                if (dsDocSubmittedtoSolicitor.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow rows in dsDocSubmittedtoSolicitor.Tables[0].Rows)
                    {
                        string DocFileName = rows["documentname"].ToString();
                        if (DocFileName != "" && !string.IsNullOrEmpty(DocFileName))
                        {
                            string FileExist = Server.MapPath(@"~/Documents/" + cmbVillage.SelectedValue.ToString() + "/" + DocFileName);
                            if (File.Exists(FileExist))
                            {
                                zip.AddFile(FileExist, "SolicitorDoc");
                            }
                        }
                    }
                }
                Response.Clear();
                Response.BufferOutput = false;
                string zipName = String.Format("Solicitor_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                Response.ContentType = "application/zip";
                Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                zip.Save(Response.OutputStream);
                Response.End();
            }
        }
        //
    }
}