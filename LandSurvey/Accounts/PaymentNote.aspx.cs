using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LandSurvey.DAL;

namespace LandSurvey.Accounts
{
    public partial class PaymentNote : System.Web.UI.Page
    {
        DataSet dsVillage = new DataSet();
        dbVillage dbVillageData = new dbVillage();

        DataSet dsFamilyDocNoNew = new DataSet();
        dbFamilyDetails dbFamilyDetailsData = new dbFamilyDetails();

        dbFileNo dbFileNoData = new dbFileNo();
        dbPaymentNote dbPaymentNoteData = new dbPaymentNote();

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
                EnableControl();
                string DataBaseNumber = dbFileNoData.getFileNo("PNOTE");
                txtDemandNo.Text = "PNOTE" + "_" + cmbVillage.SelectedValue.ToString() + "_" + cmbDocumentNo.SelectedValue.ToString() + "_" + DataBaseNumber;
               // txtDemandDate.Text = DateTime.Today.ToString("dd-MM-yyyy");

                //string strFamilyNo = dbFamilyDetailsData.getFamilyNoOnDocNo(cmbDocumentNo.SelectedValue.ToString().Trim());
                //lblDocNo.Text = cmbDocumentNo.SelectedValue.ToString();
                //lblFamily.Text = strFamilyNo;
                // ShowAllDocumentData();
                //  ShowDocumentTitleSearch();
            }
        }

        private void DisableControl()
        {
            txtDemandNo.Enabled = false;
          //  txtDemandDate.Enabled = false;
            cmbSeriesNo.Enabled = false;
            cmbPhaseNo.Enabled = false;
            txtDocArea.Enabled = false;
            txtTokenAmount.Enabled = false;
            txtRegistrationCharges.Enabled = false;
            txtStampDuty.Enabled = false;
            txtMiscAmount.Enabled = false;
            txtTotalDemand.Enabled = false;
            txtProcessing.Enabled = false;
            btnSavePaymentNote.Enabled = false;
            txtDemandNoteEntry.Enabled = false;
        }

        private void EnableControl()
        {
            txtDemandNo.Enabled = false;
          //  txtDemandDate.Enabled = false;
            cmbSeriesNo.Enabled = true;
            cmbPhaseNo.Enabled = true;
            txtDocArea.Enabled = true;
            txtTokenAmount.Enabled = true;
            txtRegistrationCharges.Enabled = true;
            txtStampDuty.Enabled = true;
            txtMiscAmount.Enabled = true;
            txtTotalDemand.Enabled = true;
            txtProcessing.Enabled = true;
            btnSavePaymentNote.Enabled = true;
            txtDemandNoteEntry.Enabled = true;
        }

        protected void btnSavePaymentNote_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDemandNoteEntry.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Demand Note No');", true);

            }
            else if (txtTokenAmount.Text  == "" )
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Token Amount');", true);

            }
            //else if (txtRegistrationCharges.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Registration Charges');", true);

            //}
            //else if (txtStampDuty.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Stamp Duty');", true);

            //}
            else if (DemandDate.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select Demand Date');", true);

            }
            //else if (txtMiscAmount.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Miscellaneous Amount');", true);
            //}
            else if (txtTotalDemand.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Miscellaneous Amount');", true);
            }
            else
            {
                //Insert into Payment table 
                string PaymentNoteID = dbPaymentNoteData.getPaymentNoteSeqNo();
                dbPaymentNoteData.paymentnoteid = Convert.ToInt32(PaymentNoteID.ToString());
                dbPaymentNoteData.villagecode = cmbVillage.SelectedValue.ToString();
                dbPaymentNoteData.documentno = cmbDocumentNo.SelectedValue.ToString();
                dbPaymentNoteData.seriesno = cmbSeriesNo.SelectedValue.ToString();
                dbPaymentNoteData.phaseno = cmbPhaseNo.SelectedValue.ToString();
                dbPaymentNoteData.demandno = txtDemandNo.Text;
                dbPaymentNoteData.demanddate = Convert.ToDateTime(DemandDate.Value.ToString());
                if (String.IsNullOrEmpty(txtDocArea.Text)){ dbPaymentNoteData.docarea = 0;}
                else { dbPaymentNoteData.docarea = Convert.ToDouble(txtDocArea.Text); }

                if (String.IsNullOrEmpty(txtTokenAmount.Text)) { dbPaymentNoteData.tokenamt = 0; }
                else { dbPaymentNoteData.tokenamt = Convert.ToDouble(txtTokenAmount.Text); }

                if (String.IsNullOrEmpty(txtRegistrationCharges.Text)) { dbPaymentNoteData.regcharges = 0; }
                else { dbPaymentNoteData.regcharges = Convert.ToDouble(txtRegistrationCharges.Text); }

                if (String.IsNullOrEmpty(txtStampDuty.Text)) { dbPaymentNoteData.stampduty = 0; }
                else { dbPaymentNoteData.stampduty = Convert.ToDouble(txtStampDuty.Text); }

                if (String.IsNullOrEmpty(txtProcessing.Text)) { dbPaymentNoteData.processcharges = 0; }
                else { dbPaymentNoteData.processcharges = Convert.ToDouble(txtProcessing.Text); }

                if (String.IsNullOrEmpty(txtMiscAmount.Text)) { dbPaymentNoteData.misccharges = 0; }
                else { dbPaymentNoteData.misccharges = Convert.ToDouble(txtMiscAmount.Text); }

    
                if (String.IsNullOrEmpty(txtTotalDemand.Text)) { dbPaymentNoteData.totaldemand = 0; }
                else { dbPaymentNoteData.totaldemand = Convert.ToDouble(txtTotalDemand.Text); }

                dbPaymentNoteData.officename = "Finance";
                dbPaymentNoteData.createdby = Session["userFullName"].ToString();
                dbPaymentNoteData.createddate = DateTime.Today;
                dbPaymentNoteData.demandnote = txtDemandNoteEntry.Text;
                bool AddPaymentNote = dbPaymentNoteData.AddPaymentNote();
                if (AddPaymentNote)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Payment Note Created Successfully');", true);

                    DisableControl();
                    //update DOCNO File Number
                  //  string CurrentDocNO = txtDocNo.Text.Substring(txtDocNo.Text.Length - 3);
                    dbFileNoData.registername = "PNOTE";
                   // dbFileNoData.currentno = Convert.ToInt32(CurrentDocNO) + 1;
                    dbFileNoData.UpdateFileNoNew();

                }


            }
        }

        protected void btnPaymentList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Accounts/PaymentNoteList");
        }

        //
    }
}