using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LandSurvey.DAL;
using System.Data;
using System.IO;
using System.Drawing;

namespace LandSurvey.Payment
{
    public partial class TSPayment : System.Web.UI.Page
    {
        DataSet dsVillage = new DataSet();
        dbVillage dbVillageData = new dbVillage();

        DataSet dsFamilyMaster = new DataSet();
        DataSet dsFamilyAreaStatus = new DataSet();
        dbFamilyMaster dbFamilyMasterData = new dbFamilyMaster();

        DataSet dsFamilyDetails = new DataSet();
        dbFamilyDetails dbFamilyDetailsData = new dbFamilyDetails();

        DataSet dsDocumentNo = new DataSet();

        DataSet dsClient = new DataSet();
        dbClient dbClientData = new dbClient();

        DataSet dsPurchaser = new DataSet();
        dbPurchaser dbPurchaserData = new dbPurchaser();

        DataSet dsPaymentDetails = new DataSet();
        dbPayment dbPaymentDetailsData = new dbPayment();

          DataSet dsFamilyDocNoNew = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dsVillage = dbVillageData.getVillageName();
                if (dsVillage.Tables[0].Rows.Count > 0)
                {
                    cmbVillage.DataSource = dsVillage.Tables[0].DefaultView;
                    cmbVillage.DataBind();
                    cmbVillage.DataTextField = dsVillage.Tables[0].Columns["villagemname"].ToString();
                    cmbVillage.DataValueField = dsVillage.Tables[0].Columns["villagecode"].ToString();
                    cmbVillage.DataBind();

                }
                dsClient = dbClientData.getClientName();
                if(dsClient.Tables[0].Rows.Count > 0)
                {

                    cmbClientName.DataSource = dsClient.Tables[0].DefaultView;
                    cmbClientName.DataBind();
                    cmbClientName.DataTextField = dsClient.Tables[0].Columns["clientname"].ToString();
                    cmbClientName.DataValueField = dsClient.Tables[0].Columns["clientid"].ToString();
                    cmbClientName.DataBind();
                }

                dsPurchaser = dbPurchaserData.getPurchaserName();
                if (dsPurchaser.Tables[0].Rows.Count > 0)
                {

                    cmbPurchaser.DataSource = dsPurchaser.Tables[0].DefaultView;
                    cmbPurchaser.DataBind();
                    cmbPurchaser.DataTextField = dsPurchaser.Tables[0].Columns["purchasername"].ToString();
                    cmbPurchaser.DataValueField = dsPurchaser.Tables[0].Columns["purchaserid"].ToString();
                    cmbPurchaser.DataBind();
                }

                DataTable dt = new DataTable();
                grdHolderName.DataSource = dt;
                grdHolderName.DataBind();
                lblFamilyTotArea.Text = "";
                lblStatus.Text = "";
                lblHolderName.Text = "";
                lblSurveyNo.Text = "";

                DisableControls();
            }

        }

        protected void cmbVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVillage.SelectedIndex == -1)
            {
                // MessageBox.Show("Please select vaild District name");
                //cmbVillage.Select();
            }
            else
            {
                //cmbFamily.Items.Clear();
                cmbDocumentNo.Items.Clear();
                string selectedVillage = cmbVillage.SelectedValue.ToString().Trim();

                //dsFamilyMaster = dbFamilyMasterData.getFamilyMasterCmb(selectedVillage);
                //if (dsFamilyMaster.Tables[0].Rows.Count > 0)
                //{
                //    cmbFamily.DataSource = dsFamilyMaster.Tables[0].DefaultView;
                //    cmbFamily.DataBind();
                //    cmbFamily.DataTextField = dsFamilyMaster.Tables[0].Columns["familyno"].ToString();
                //    cmbFamily.DataValueField = dsFamilyMaster.Tables[0].Columns["familyno"].ToString();
                //    cmbFamily.DataBind();


                //}

                //New Code after Demo 
                dsFamilyDocNoNew = dbFamilyDetailsData.getDocumnentNoTitleSearch(selectedVillage);
                if (dsFamilyDocNoNew.Tables[0].Rows.Count > 0)
                {
                    cmbDocumentNo.DataSource = dsFamilyDocNoNew.Tables[0].DefaultView;
                    cmbDocumentNo.DataBind();
                    cmbDocumentNo.DataTextField = dsFamilyDocNoNew.Tables[0].Columns["docno"].ToString();
                    cmbDocumentNo.DataValueField = dsFamilyDocNoNew.Tables[0].Columns["docno"].ToString();
                    cmbDocumentNo.DataBind();
                    grdHolderName.DataSource = null;
                    grdHolderName.DataBind();

                }
            }
            //if (cmbVillage.SelectedIndex == -1)
            //{

            //}
            //else
            //{
            //    cmbFamily.Items.Clear();
            //    string selectedVillage = cmbVillage.SelectedValue.ToString().Trim();

            //    dsFamilyMaster = dbFamilyMasterData.getFamilyMasterCmb(selectedVillage);
            //    if (dsFamilyMaster.Tables[0].Rows.Count > 0)
            //    {
            //        cmbFamily.DataSource = dsFamilyMaster.Tables[0].DefaultView;
            //        cmbFamily.DataBind();
            //        cmbFamily.DataTextField = dsFamilyMaster.Tables[0].Columns["familyno"].ToString();
            //        cmbFamily.DataValueField = dsFamilyMaster.Tables[0].Columns["familyno"].ToString();
            //        cmbFamily.DataBind();


            //    }
            //}
        }

        protected void cmbFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFamily.SelectedIndex == -1)
            {
                // MessageBox.Show("Please select vaild District name");
                //cmbVillage.Select();
            }
            else
            {
                lblFamilyTotArea.Text = "";
                lblStatus.Text = "";
                cmbDocumentNo.Items.Clear();
                string selectedVillage = cmbVillage.SelectedValue.ToString().Trim();
                string selectFamilyNo = cmbFamily.SelectedValue.ToString().Trim();

                dsDocumentNo = dbFamilyDetailsData.getFamilyDetailsDocumentNo(selectedVillage, selectFamilyNo);
                if (dsDocumentNo.Tables[0].Rows.Count > 0)
                {
                    cmbDocumentNo.DataSource = dsDocumentNo.Tables[0].DefaultView;
                    cmbDocumentNo.DataBind();
                    cmbDocumentNo.DataTextField = dsDocumentNo.Tables[0].Columns["documentno"].ToString();
                    cmbDocumentNo.DataValueField = dsDocumentNo.Tables[0].Columns["documentno"].ToString();
                    cmbDocumentNo.DataBind();


                }
                //Get Area and Status
                lblFamilyTotArea.Text = "";
                lblStatus.Text = "";
                dsFamilyAreaStatus = dbFamilyMasterData.getFamilyAreaStatus(cmbFamily.SelectedValue.ToString(), cmbVillage.SelectedValue.ToString());
                if (dsFamilyAreaStatus.Tables[0].Rows.Count == 1)
                {
                    lblFamilyTotArea.Text = dsFamilyAreaStatus.Tables[0].Rows[0]["totalarea"].ToString();
                    String strStatusFamily = dsFamilyAreaStatus.Tables[0].Rows[0]["status"].ToString();
                    if (strStatusFamily == "N")
                    { lblStatus.Text = "Not Aquired"; }
                    else { lblStatus.Text = "Aquired"; };

                }

            }
        }

        protected void cmbDocumentNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbDocumentNo.SelectedIndex == -1)
            {

            }
            else
            {
                string selectedVillage = cmbVillage.SelectedValue.ToString().Trim();
                string selectFamilyNo = cmbFamily.SelectedValue.ToString().Trim();
                string selectedDocument = cmbDocumentNo.SelectedValue.ToString().Trim();
                dsFamilyDetails = dbFamilyDetailsData.getFamilyDetailsOnDocument(selectedVillage,  selectedDocument);
                if (dsFamilyDetails.Tables[0].Rows.Count > 0)
                {
                    grdHolderName.DataSource = dsFamilyDetails;
                    grdHolderName.DataBind();
                    lblHolderName.Text = "";
                    lblSurveyNo.Text = "";
                }
            }
        }

        protected void grdHolderName_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (grdHolderName.Rows.Count > 0)
            {
               
                foreach (GridViewRow row in grdHolderName.Rows)
                {
                    if (row.RowIndex == grdHolderName.SelectedIndex)
                    {
                        row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                        row.ToolTip = string.Empty;
                    }
                    else
                    {
                        row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                        row.ToolTip = "Click to select this row.";
                    }
                }
                string SurveyNo = grdHolderName.SelectedRow.Cells[1].Text;
                string HolderName = grdHolderName.SelectedRow.Cells[2].Text;
                lblSurveyNo.Text = SurveyNo;
                lblHolderName.Text = HolderName;
                EnableControls();
            }
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdHolderName, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void btnSavePayment_Click(object sender, EventArgs e)
        {
            if (cmbPaymentType.SelectedIndex < 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Payment Type');", true);
               
            }
            else if (txtVoucherNo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Voucher No');", true);
                
            }
            else if (VoucherDate.Value == "" )
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select Voucher Date');", true);
                
            }
            else if (PaymentDate.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select Payment Date');", true);
            }
            else if( cmbPaymentMode.SelectedIndex < 0 )
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select Payment Mode');", true);
            }
            else if(txtAmount.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Amount');", true);
            }
            else
            {
                //Insert into Payment table 
                string PaymentID = dbPaymentDetailsData.getPaymentSeqNo();
                dbPaymentDetailsData.paymentid = Convert.ToInt32(PaymentID.ToString());
                dbPaymentDetailsData.titlesearchno = cmbDocumentNo.SelectedValue.ToString();
                dbPaymentDetailsData.familyno = cmbFamily.SelectedValue.ToString();
                dbPaymentDetailsData.surveyno = lblSurveyNo.Text;
                dbPaymentDetailsData.holdername = lblHolderName.Text;
                dbPaymentDetailsData.voucherno = txtVoucherNo.Text;
                dbPaymentDetailsData.voucherdate = Convert.ToDateTime(VoucherDate.Value.ToString());
                dbPaymentDetailsData.amountpaid = Convert.ToDouble(txtAmount.Text);
                dbPaymentDetailsData.paiddate = Convert.ToDateTime(PaymentDate.Value.ToString());
                dbPaymentDetailsData.amounttype = cmbPaymentMode.SelectedValue.ToString();
                dbPaymentDetailsData.amtdocumentno = txtChequeDDNo.Text;
                if (ChequeDate.Value.ToString() != "")
                {
                    dbPaymentDetailsData.amountdocumentdate = Convert.ToDateTime(ChequeDate.Value.ToString());
                } else { dbPaymentDetailsData.amountdocumentdate = DateTime.MinValue;  }
                dbPaymentDetailsData.amtbankdetail = txtBankDetails.Text;
                dbPaymentDetailsData.clientid = cmbClientName.SelectedValue.ToString();
                dbPaymentDetailsData.purchaserid = cmbPurchaser.SelectedValue.ToString();
                dbPaymentDetailsData.amttransaction = cmbPaymentType.SelectedValue.ToString();
                dbPaymentDetailsData.createdby = "RSD";
                dbPaymentDetailsData.createddate = DateTime.Today;
                dbPaymentDetailsData.docno = cmbDocumentNo.SelectedValue.ToString();
                bool AddPaymentDetails = dbPaymentDetailsData.AddPaymentDetails();
                if(AddPaymentDetails)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sucessfully Insert Payment Details ');", true);
                    DisableControls();
                }


            }

       }

        private void DisableControls()
        {
            cmbPaymentMode.Enabled = false;
            txtVoucherNo.Enabled = false;
            VoucherDate.Disabled = true;
            PaymentDate.Disabled = true;
            cmbPaymentMode.Enabled = false;
            cmbPaymentMode.Enabled = false;
            txtAmount.Enabled = false;
            txtChequeDDNo.Enabled = false;
            txtBankDetails.Enabled = false;
            ChequeDate.Disabled = true;
            cmbPurchaser.Enabled = false;
            cmbClientName.Enabled = false;
            btnSavePayment.Enabled = false;
          
        }

        private void EnableControls()
        {
            cmbPaymentMode.Enabled = true;
            txtVoucherNo.Enabled = true;
            VoucherDate.Disabled = false;
            PaymentDate.Disabled = false;
            cmbPaymentMode.Enabled = true;
            cmbPaymentMode.Enabled = true;
            txtAmount.Enabled = true;
            txtChequeDDNo.Enabled = true;
            txtBankDetails.Enabled = true;
            ChequeDate.Disabled = false;
            cmbPurchaser.Enabled = true;
            cmbClientName.Enabled = true;
            btnSavePayment.Enabled = true;

        }

        protected void grdHolderName_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdHolderName.PageIndex = e.NewPageIndex;
            dsFamilyDetails = dbFamilyDetailsData.getFamilyDetailsOnDocument(cmbVillage.SelectedValue.ToString().Trim(), cmbDocumentNo.SelectedValue.ToString().Trim());
            if (dsFamilyDetails.Tables[0].Rows.Count > 0)
            {
                grdHolderName.DataSource = dsFamilyDetails;
                grdHolderName.DataBind();
               
            }
        }

        ///
    }
}