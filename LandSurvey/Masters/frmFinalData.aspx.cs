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
    public partial class frmFinalData : System.Web.UI.Page
    {
        DataSet dsFinalData = new DataSet();
        dbFinalData objFinal = new dbFinalData();
        dbInwardOutwardReg dbInOutWardReg = new dbInwardOutwardReg();
        dbCommonFunctions objcmnfun = new dbCommonFunctions();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblHeading.Text = "Final Data";
            dsFinalData = objFinal.getFinalData();
            if (dsFinalData.Tables[0].Rows.Count > 0)
            {
                grdFinalData.DataSource = dsFinalData.Tables[0].DefaultView;
                grdFinalData.DataBind();

            }

            if (!IsPostBack)
            {
                DataSet ds1 = dbInOutWardReg.GetVillageMaster();
                objcmnfun.Binddropdown(ds1.Tables[0], ref dpVillageName, "villagemname", "villagecode");

            }
        }

        protected void grdFinalData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    e.Row.Cells[0].Text = "";
                    e.Row.Cells[1].Text = "Sr.No.";
                    e.Row.Cells[2].Text = "Village Code";
                    e.Row.Cells[3].Text = "Village Name";
                    e.Row.Cells[4].Text = "Total Village Area";
                    e.Row.Cells[5].Text = "Proposed Area Acq";
                    e.Row.Cells[6].Text = "DEN No ";
                    e.Row.Cells[7].Text = "ATS Area Acq";
                    e.Row.Cells[8].Text = "RSD Area Acq";
                    e.Row.Cells[9].Text = "Total Area Acq";
                    e.Row.Cells[10].Text = "Temp ATS Area";
                    e.Row.Cells[11].Text = "Temp RSD Area";
                    e.Row.Cells[12].Text = "Balance Area Acq";

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
                    e.Row.Cells[10].Width = new Unit("150px");
                    e.Row.Cells[11].Width = new Unit("150px");
                    e.Row.Cells[12].Width = new Unit("150px");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void grdFinalData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdFinalData.PageIndex = e.NewPageIndex;
        }

        protected void grdFinalData_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = grdFinalData.SelectedRow;
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

                txtTotalVillageArea.Text = row.Cells[4].Text;
                txtProposedAreaAcq.Text = row.Cells[5].Text;
                txtDENNo.Text = row.Cells[6].Text;
                txtATSAreaAcq.Text = row.Cells[7].Text;
                txtRSDAreaAcq.Text = row.Cells[8].Text;
                txtTotalAreaAcq.Text = row.Cells[9].Text;
                txtTempATSArea.Text = row.Cells[10].Text;
                txtTempRSDArea.Text = row.Cells[11].Text;
                txtBalanceAreaAcq.Text = row.Cells[12].Text;
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
                objFinal.villagecode = Convert.ToString(dpVillageName.SelectedIndex);
                objFinal.totalvillagearea = Convert.ToDecimal(txtTotalVillageArea.Text);
                objFinal.proposedareaacq = Convert.ToDecimal(txtProposedAreaAcq.Text);
                objFinal.denno = txtDENNo.Text;
                objFinal.atsareaacq = Convert.ToDecimal(txtATSAreaAcq.Text);
                objFinal.rsdareaacq = Convert.ToDecimal(txtRSDAreaAcq.Text);
                objFinal.totalareaacq = Convert.ToDecimal(txtTotalAreaAcq.Text);
                objFinal.tempatsarea = Convert.ToDecimal(txtTempATSArea.Text);
                objFinal.temprsdarea = Convert.ToDecimal(txtTempRSDArea.Text);
                objFinal.balanceareaacq = Convert.ToDecimal(txtBalanceAreaAcq.Text);
                boolAddRecord = objFinal.AddFinalData();
                if (boolAddRecord)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Record Inserted Successfully');", true);
                    dpVillageName.SelectedIndex = 0;
                    txtTotalVillageArea.Text = "";
                    txtProposedAreaAcq.Text = "";
                    txtDENNo.Text = "";
                    txtATSAreaAcq.Text = "";
                    txtRSDAreaAcq.Text = "";
                    txtTotalAreaAcq.Text = "";
                    txtTempATSArea.Text = "";
                    txtTempRSDArea.Text = "";
                    txtBalanceAreaAcq.Text = "";

                    dsFinalData = objFinal.getFinalData();
                    if (dsFinalData.Tables[0].Rows.Count > 0)
                    {
                        grdFinalData.DataSource = dsFinalData.Tables[0].DefaultView;
                        grdFinalData.DataBind();

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
                objFinal.villagecode = Convert.ToString(dpVillageName.SelectedIndex);
                objFinal.totalvillagearea = Convert.ToDecimal(txtTotalVillageArea.Text);
                objFinal.proposedareaacq = Convert.ToDecimal(txtProposedAreaAcq.Text);
                objFinal.denno = txtDENNo.Text;
                objFinal.atsareaacq = Convert.ToDecimal(txtATSAreaAcq.Text);
                objFinal.rsdareaacq = Convert.ToDecimal(txtRSDAreaAcq.Text);
                objFinal.totalareaacq = Convert.ToDecimal(txtTotalAreaAcq.Text);
                objFinal.tempatsarea = Convert.ToDecimal(txtTempATSArea.Text);
                objFinal.temprsdarea = Convert.ToDecimal(txtTempRSDArea.Text);
                objFinal.balanceareaacq = Convert.ToDecimal(txtBalanceAreaAcq.Text);
                boolEditRecord = objFinal.EditFinalData();
                if (boolEditRecord)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Record Updated Successfully');", true);
                    dpVillageName.SelectedIndex = 0;
                    txtTotalVillageArea.Text = "";
                    txtProposedAreaAcq.Text = "";
                    txtDENNo.Text = "";
                    txtATSAreaAcq.Text = "";
                    txtRSDAreaAcq.Text = "";
                    txtTotalAreaAcq.Text = "";
                    txtTempATSArea.Text = "";
                    txtTempRSDArea.Text = "";
                    txtBalanceAreaAcq.Text = "";

                    dsFinalData = objFinal.getFinalData();
                    if (dsFinalData.Tables[0].Rows.Count > 0)
                    {
                        grdFinalData.DataSource = dsFinalData.Tables[0].DefaultView;
                        grdFinalData.DataBind();

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
                objFinal.villagecode = Convert.ToString(dpVillageName.SelectedIndex);
                boolDeleteRecord = objFinal.DeleteFinalData();
                if (boolDeleteRecord)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Record Deleted Successfully');", true);
                    dpVillageName.SelectedIndex = 0;
                    txtTotalVillageArea.Text = "";
                    txtProposedAreaAcq.Text = "";
                    txtDENNo.Text = "";
                    txtATSAreaAcq.Text = "";
                    txtRSDAreaAcq.Text = "";
                    txtTotalAreaAcq.Text = "";
                    txtTempATSArea.Text = "";
                    txtTempRSDArea.Text = "";
                    txtBalanceAreaAcq.Text = "";

                    dsFinalData = objFinal.getFinalData();
                    if (dsFinalData.Tables[0].Rows.Count > 0)
                    {
                        grdFinalData.DataSource = dsFinalData.Tables[0].DefaultView;
                        grdFinalData.DataBind();

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
            Response.Redirect("~/Reports/HTMLFinalData.aspx", false);
        }
    }
}