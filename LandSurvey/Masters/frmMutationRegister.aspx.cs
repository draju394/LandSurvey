using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LandSurvey.DAL;
using System.Data;


namespace LandSurvey.Masters
{
    public partial class frmMutationRegister : System.Web.UI.Page
    {
        DataSet dsMutationFinal = new DataSet();
        dbMutationRegister1 objMutationFinal = new dbMutationRegister1();
        dbInwardOutwardReg dbInOutWardReg = new dbInwardOutwardReg();
        dbCommonFunctions objcmnfun = new dbCommonFunctions();

        protected void Page_Load(object sender, EventArgs e)
        {

            //dsMutationFinal = objMutationFinal.getMutationRegisterData("", "");
            //if (dsMutationFinal.Tables[0].Rows.Count > 0)
            //{
            //    grdMutationFinal.DataSource = dsMutationFinal.Tables[0].DefaultView;
            //    grdMutationFinal.DataBind();
            //}

            if (!IsPostBack)
            {
                DataSet ds1 = dbInOutWardReg.GetVillageMaster();
                objcmnfun.Binddropdown(ds1.Tables[0], ref dpVillageName, "villagemname", "villagecode");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool boolAddRecord = false;
                objMutationFinal.villagecode = Convert.ToString(dpVillageName.SelectedValue);
                objMutationFinal.mutationno = txtMutationNo.Text;
                objMutationFinal.mutationyear = txtMutaionYear.Text;
                objMutationFinal.surveyno = txtSurveyNo.Text;
                objMutationFinal.remarks = txtRemarks.Text;
                objMutationFinal.mutationdetails = txtMutationDetails.Text;

                boolAddRecord = objMutationFinal.AddMutationFinalData();
                if (boolAddRecord)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Record Inserted Successfully');", true);
                    dpVillageName.SelectedIndex = 0;
                    txtMutationNo.Text = "";
                    txtMutaionYear.Text = "";
                    txtSurveyNo.Text = "";
                    txtRemarks.Text = "";
                    txtMutationDetails.Text = "";

                    //dsMutationFinal = objMutationFinal.getMutationRegisterData("", "");
                    //if (dsMutationFinal.Tables[0].Rows.Count > 0)
                    //{
                    //    grdMutationFinal.DataSource = dsMutationFinal.Tables[0].DefaultView;
                    //    grdMutationFinal.DataBind();
                    //}
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(lblMutationId.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Some thing went wrong');", true);
                    return;
                }

                bool boolEditRecord = false;
                objMutationFinal.villagecode = Convert.ToString(dpVillageName.SelectedValue);
                objMutationFinal.mutationno = txtMutationNo.Text;
                objMutationFinal.mutationyear = txtMutaionYear.Text;
                objMutationFinal.surveyno = txtSurveyNo.Text;
                objMutationFinal.remarks = txtRemarks.Text;
                objMutationFinal.mutationdetails = txtMutationDetails.Text;
                objMutationFinal.mutationid = Convert.ToInt32(lblMutationId.Text);

                boolEditRecord = objMutationFinal.EditMutationFinalData();
                if (boolEditRecord)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Record Updated Successfully');", true);
                    dpVillageName.SelectedIndex = 0;
                    txtMutationNo.Text = "";
                    txtMutaionYear.Text = "";
                    txtSurveyNo.Text = "";
                    txtRemarks.Text = "";
                    txtMutationDetails.Text = "";
                    lblMutationId.Text = "";

                    // grdMutationFinal.DataSource = null;
                    // grdMutationFinal.DataBind();

                    btnEdit.Visible = false;
                    btnSave.Visible = true;
                    tblMain.Visible = false;
                    //trExists.Visible = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(lblMutationId.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Some thing went wrong');", true);
                    return;
                }

                bool boolDeleteRecord = false;

                objMutationFinal.villagecode = Convert.ToString(dpVillageName.SelectedValue);
                objMutationFinal.mutationno = txtMutationNo.Text;

                boolDeleteRecord = objMutationFinal.DeleteMutationFinalData();
                if (boolDeleteRecord)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Record Deleted Successfully');", true);
                    dpVillageName.SelectedIndex = 0;
                    txtMutationNo.Text = "";
                    txtMutaionYear.Text = "";
                    txtSurveyNo.Text = "";
                    txtRemarks.Text = "";
                    txtMutationDetails.Text = "";
                    lblMutationId.Text = "";
                    tblMain.Visible = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reports/HTMLMutationFinal.aspx", false);
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                string VillageCode = dpVillageName.SelectedValue;
                string MutationNo = txtMutationNo.Text;
                tblMain.Visible = true;
                dsMutationFinal = objMutationFinal.getMutationRegisterData(MutationNo, VillageCode);

                if (dsMutationFinal.Tables[0].Rows.Count > 0)
                {
                    int MutationId = Convert.ToInt32(dsMutationFinal.Tables[0].Rows[0]["mutationid"].ToString());

                    DataSet ds = objMutationFinal.getMutationRegisterData(MutationId);
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dtSummary = ds.Tables[0];

                        foreach (DataRow dr in dtSummary.Select())
                        {
                            lblMutationId.Text = MutationId.ToString();
                            dpVillageName.SelectedValue = dr["villagecode"].ToString();
                            txtMutationNo.Text = dr["mutationno"].ToString();
                            txtMutaionYear.Text = dr["mutationyear"].ToString();
                            txtSurveyNo.Text = dr["surveynos"].ToString();
                            txtRemarks.Text = dr["mutremarks"].ToString();
                            txtMutationDetails.Text = dr["mutationdetail"].ToString();

                            btnEdit.Visible = true;
                            btnSave.Visible = false;
                            btnDelete.Visible = true;

                            dpVillageName.Focus();
                        }
                    }
                }


                //if (dsMutationFinal.Tables[0].Rows.Count > 0)
                //{
                //    //grdMutationFinal.DataSource = dsMutationFinal.Tables[0].DefaultView;
                //    // grdMutationFinal.DataBind();
                //    // trExists.Visible = true;
                //}
                //else
                //   // trExists.Visible = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                btnEdit.Visible = false;
                btnSave.Visible = true;
                lblMutationId.Text = "";
                dpVillageName.SelectedIndex = 0;
                txtMutationNo.Text = "";
                txtMutaionYear.Text = "";
                txtSurveyNo.Text = "";
                txtRemarks.Text = "";
                txtMutationDetails.Text = "";
                tblMain.Visible = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void grdMutationFinal_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                bool boolDeleteRecord = false;


                objMutationFinal.mutationno = txtMutationNo.Text;
                objMutationFinal.villagecode = dpVillageName.SelectedValue;

                boolDeleteRecord = objMutationFinal.DeleteMutationFinalData();
                if (boolDeleteRecord)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Record Deleted Successfully');", true);

                    dpVillageName.SelectedIndex = 0;
                    txtMutationNo.Text = "";
                    txtMutaionYear.Text = "";
                    txtSurveyNo.Text = "";
                    txtRemarks.Text = "";
                    txtMutationDetails.Text = "";
                    lblMutationId.Text = "";

                    //grdMutationFinal.DataSource = null;
                    // grdMutationFinal.DataBind();

                    btnEdit.Visible = false;
                    btnSave.Visible = true;
                    // trExists.Visible = false;


                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void grdMutationFinal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //try
            //{
            //    if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != grdMutationFinal.EditIndex)
            //    {
            //        (e.Row.Cells[0].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this record?');";
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }
    }
}