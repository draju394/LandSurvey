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
    public partial class frmMutationFinal : System.Web.UI.Page
    {
        DataSet dsMutationFinal = new DataSet();
        dbMutationFinal objMutationFinal = new dbMutationFinal();
        dbInwardOutwardReg dbInOutWardReg = new dbInwardOutwardReg();
        dbCommonFunctions objcmnfun = new dbCommonFunctions();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblHeading.Text = "Mutation Entry";
            dsMutationFinal = objMutationFinal.getMutationFinalData();
            if (dsMutationFinal.Tables[0].Rows.Count > 0)
            {
                grdMutationFinal.DataSource = dsMutationFinal.Tables[0].DefaultView;
                grdMutationFinal.DataBind();

            }

            if (!IsPostBack)
            {
                DataSet ds1 = dbInOutWardReg.GetVillageMaster();
                objcmnfun.Binddropdown(ds1.Tables[0],ref dpVillageName, "villagemname", "villagecode");

            }
        }

        protected void grdMutationFinal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    e.Row.Cells[0].Text = "";
                    e.Row.Cells[1].Text = "Sr.No.";
                    e.Row.Cells[2].Text = "Village Code";
                    e.Row.Cells[3].Text = "Village Name";
                    e.Row.Cells[4].Text = "Mutation No";
                    e.Row.Cells[5].Text = "Mutation Date";
                    e.Row.Cells[6].Text = "Survey No";
                    e.Row.Cells[7].Text = "Remarks";
                    e.Row.Cells[8].Text = "Mutation Order Rec";
                    e.Row.Cells[9].Text = "Mutated 712 Rec";

                    e.Row.Cells[0].Width = new Unit("50px");
                    e.Row.Cells[1].Width = new Unit("40px");
                    e.Row.Cells[2].Width = new Unit("40px");
                    e.Row.Cells[3].Width = new Unit("150px");
                    e.Row.Cells[4].Width = new Unit("150px");
                    e.Row.Cells[5].Width = new Unit("150px");
                    e.Row.Cells[6].Width = new Unit("150px");
                    e.Row.Cells[7].Width = new Unit("200px");
                    e.Row.Cells[8].Width = new Unit("150px");
                    e.Row.Cells[9].Width = new Unit("150px");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void grdMutationFinal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMutationFinal.PageIndex = e.NewPageIndex;
        }

        protected void grdMutationFinal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = grdMutationFinal.SelectedRow;
                int villagecode = Convert.ToInt32(row.Cells[2].Text);
                Session["VillageCode"] = villagecode;

                //DataTable dtData = ((DataTable)dpVillageName.DataSource);
                //for (int i = 0; i < dtData.Rows.Count; i++)
                //{
                //    if (dtData.Rows[i]["villagemname"].ToString() == row.Cells[3].Text.ToString())
                //    {
                //        i++;
                //        dpVillageName.SelectedIndex = i;
                //        break;
                //    }
                //}

                txtMutationNo.Text = row.Cells[4].Text;
                txtMutaionDate.Text = row.Cells[5].Text;
                txtSurveyNo.Text = row.Cells[6].Text;
                txtRemarks.Text = row.Cells[7].Text;
                txtMutationOrderRec.Text = row.Cells[8].Text;
                txtMutated_712_Rec.Text = row.Cells[9].Text;      
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool boolAddRecord = false;
                objMutationFinal.villagecode = Convert.ToString(dpVillageName.SelectedIndex);
                objMutationFinal.mutationno = txtMutationNo.Text;
                objMutationFinal.mutationdate = txtMutaionDate.Text;
                objMutationFinal.surveyno = txtSurveyNo.Text;
                objMutationFinal.remarks = txtRemarks.Text;
                objMutationFinal.mutationorderrec = txtMutationOrderRec.Text;
                objMutationFinal.mutated712rec = txtMutated_712_Rec.Text;
                boolAddRecord = objMutationFinal.AddMutationFinalData();
                if (boolAddRecord)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Record Inserted Successfully');", true);
                    dpVillageName.SelectedIndex = 0;
                    txtMutationNo.Text = "";
                    txtMutaionDate.Text = "";
                    txtSurveyNo.Text = "";
                    txtRemarks.Text = "";
                    txtMutationOrderRec.Text = "";
                    txtMutated_712_Rec.Text = "";

                    dsMutationFinal = objMutationFinal.getMutationFinalData();
                    if (dsMutationFinal.Tables[0].Rows.Count > 0)
                    {
                        grdMutationFinal.DataSource = dsMutationFinal.Tables[0].DefaultView;
                        grdMutationFinal.DataBind();

                    }
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
                bool boolEditRecord = false;
                objMutationFinal.villagecode = Convert.ToString(dpVillageName.SelectedIndex);
                objMutationFinal.mutationno = txtMutationNo.Text;
                objMutationFinal.mutationdate = txtMutaionDate.Text;
                objMutationFinal.surveyno = txtSurveyNo.Text;
                objMutationFinal.remarks = txtRemarks.Text;
                objMutationFinal.mutationorderrec = txtMutationOrderRec.Text;
                objMutationFinal.mutated712rec = txtMutated_712_Rec.Text;
                boolEditRecord = objMutationFinal.EditMutationFinalData();
                if (boolEditRecord)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Record Updated Successfully');", true);
                    dpVillageName.SelectedIndex = 0;
                    txtMutationNo.Text = "";
                    txtMutaionDate.Text = "";
                    txtSurveyNo.Text = "";
                    txtRemarks.Text = "";
                    txtMutationOrderRec.Text = "";
                    txtMutated_712_Rec.Text = "";

                    dsMutationFinal = objMutationFinal.getMutationFinalData();
                    if (dsMutationFinal.Tables[0].Rows.Count > 0)
                    {
                        grdMutationFinal.DataSource = dsMutationFinal.Tables[0].DefaultView;
                        grdMutationFinal.DataBind();

                    }
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
                bool boolDeleteRecord = false;
                objMutationFinal.villagecode = Convert.ToString(dpVillageName.SelectedIndex);
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
                    txtMutaionDate.Text = "";
                    txtSurveyNo.Text = "";
                    txtRemarks.Text = "";
                    txtMutationOrderRec.Text = "";
                    txtMutated_712_Rec.Text = "";

                    dsMutationFinal = objMutationFinal.getMutationFinalData();
                    if (dsMutationFinal.Tables[0].Rows.Count > 0)
                    {
                        grdMutationFinal.DataSource = dsMutationFinal.Tables[0].DefaultView;
                        grdMutationFinal.DataBind();

                    }
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
    }
}