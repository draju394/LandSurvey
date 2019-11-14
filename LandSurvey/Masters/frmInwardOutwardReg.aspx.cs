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
    public partial class frmInwardOutwardReg : System.Web.UI.Page
    {
        DataSet dsInOutWardReg = new DataSet();
        dbInwardOutwardReg dbInOutWardReg = new dbInwardOutwardReg();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            
                lblHeading.Text = "InwardOutwardReg Master";
                dsInOutWardReg = dbInOutWardReg.getInOutWardRegData();
                if (dsInOutWardReg.Tables[0].Rows.Count > 0)
                {
                    grdInwardOutwardReg.DataSource = dsInOutWardReg.Tables[0].DefaultView;
                    grdInwardOutwardReg.DataBind();

                }
            if (!IsPostBack)
            {
                DataSet ds = dbInOutWardReg.GetDocumentMaster();
                Binddropdown(ds.Tables[0], dpreceiveddocumenttype, "documentmname", "documentcode");
                Binddropdown(ds.Tables[0], dpsentdocumenttype, "documentmname", "documentcode");

                DataSet ds1 = dbInOutWardReg.GetVillageMaster();
                Binddropdown(ds1.Tables[0], dpVillageName, "villagemname", "villagecode");
            }

        }

        protected void grdInwardOutwardReg_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    e.Row.Cells[0].Text = "";
                    e.Row.Cells[1].Text = "Sr.No.";
                    e.Row.Cells[2].Text = "IO Number";
                    e.Row.Cells[3].Text = "Received Document Type";
                    e.Row.Cells[4].Text = "Received From";
                    e.Row.Cells[5].Text = "Received Document Remark";
                    e.Row.Cells[6].Text = "Received By";
                    e.Row.Cells[7].Text = "Inward No";
                    e.Row.Cells[8].Text = "Inward Date";
                    e.Row.Cells[9].Text = "Inward Section";
                    e.Row.Cells[10].Text = "Sent Document Type";
                    e.Row.Cells[11].Text = "Sent To";
                    e.Row.Cells[12].Text = "Sent Document Remark";
                    e.Row.Cells[13].Text = "Sent By";
                    e.Row.Cells[14].Text = "Outward No";
                    e.Row.Cells[15].Text = "Outward Date";
                    e.Row.Cells[16].Text = "Outward Section";
                    e.Row.Cells[17].Text = "Outward Mode";
                    e.Row.Cells[18].Text = "Village Name";

                    e.Row.Cells[0].Width = new Unit("50px");
                    e.Row.Cells[1].Width = new Unit("40px");
                    e.Row.Cells[2].Width = new Unit("40px");
                    e.Row.Cells[3].Width = new Unit("150px");
                    e.Row.Cells[4].Width = new Unit("150px");
                    e.Row.Cells[5].Width = new Unit("150px");
                    e.Row.Cells[6].Width = new Unit("150px");
                    e.Row.Cells[7].Width = new Unit("50px");
                    e.Row.Cells[8].Width = new Unit("150px");
                    e.Row.Cells[9].Width = new Unit("150px");
                    e.Row.Cells[10].Width = new Unit("150px");
                    e.Row.Cells[11].Width = new Unit("150px");
                    e.Row.Cells[12].Width = new Unit("150px");
                    e.Row.Cells[13].Width = new Unit("150px");
                    e.Row.Cells[14].Width = new Unit("50px");
                    e.Row.Cells[15].Width = new Unit("150px");
                    e.Row.Cells[16].Width = new Unit("150px");
                    e.Row.Cells[17].Width = new Unit("150px");
                    e.Row.Cells[18].Width = new Unit("150px");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void grdInwardOutwardReg_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdInwardOutwardReg.PageIndex = e.NewPageIndex;
        }

        public void Binddropdown(DataTable dt,DropDownList dropdownlist, string dataTextField, string dataValueField)
        {
            try
            {
                dropdownlist.DataSource = dt;
                dropdownlist.DataTextField = dataTextField;
                dropdownlist.DataValueField = dataValueField;
                dropdownlist.DataBind();
                dropdownlist.Items.Insert(0, new ListItem("--Select--", "0"));
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
                string SeqIono = dbInOutWardReg.getInwardOutwardSeqNo();
                dbInOutWardReg.ionumber = Convert.ToInt32(SeqIono.ToString());
                dbInOutWardReg.receiveddocumentcode = Convert.ToString(Session["receiveddoccode"]);
                dbInOutWardReg.receivedfrom = txtreceivedfrom.Text;
                dbInOutWardReg.receiveddocremark = txtReceivedDocRemark.Text;
                dbInOutWardReg.receivedby = txtReceivedBy.Text;
                dbInOutWardReg.inwardno = txtInwardNo.Text;
                dbInOutWardReg.inwarddate = txtInwardDate.Text;
                dbInOutWardReg.inwardsection = txtInwardSection.Text;
                dbInOutWardReg.sentdocumentcode = Convert.ToString(Session["sentdoccode"]);
                dbInOutWardReg.sentto = txtSentTo.Text;
                dbInOutWardReg.sentdocremark = txtSentDocRemark.Text;
                dbInOutWardReg.sentby = txtSentBy.Text;
                dbInOutWardReg.outwardno = txtOutwardNo.Text;
                dbInOutWardReg.outwarddate = txtOutwardDate.Text;
                dbInOutWardReg.outwardsection = txtOutwardSection.Text;
                dbInOutWardReg.outwardmode = txtOutwardMode.Text;
                dbInOutWardReg.villagecode = Convert.ToString(Convert.ToString(Session["villagecode"]));
                boolAddRecord = dbInOutWardReg.AddInwardOutwardReg();
                if (boolAddRecord)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Record Inserted Successfully');", true);
                    dpreceiveddocumenttype.SelectedIndex = 0;
                    txtreceivedfrom.Text = "";
                    txtReceivedDocRemark.Text = "";
                    txtReceivedBy.Text = "";
                    txtInwardNo.Text = "";
                    txtInwardDate.Text = "";
                    txtInwardSection.Text = "";
                    dpsentdocumenttype.SelectedIndex = 0;
                    txtSentTo.Text = "";
                    txtSentDocRemark.Text = "";
                    txtSentBy.Text = "";
                    txtOutwardNo.Text = "";
                    txtOutwardDate.Text = "";
                    txtOutwardSection.Text = "";
                    txtOutwardMode.Text = "";
                    dpVillageName.SelectedIndex = 0;
                   
                    dsInOutWardReg = dbInOutWardReg.getInOutWardRegData();
                    if (dsInOutWardReg.Tables[0].Rows.Count > 0)
                    {
                        grdInwardOutwardReg.DataSource = dsInOutWardReg.Tables[0].DefaultView;
                        grdInwardOutwardReg.DataBind();

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void dpreceiveddocumenttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session["receiveddoccode"] = dpreceiveddocumenttype.SelectedIndex;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void dpsentdocumenttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session["sentdoccode"] = dpsentdocumenttype.SelectedIndex;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void dpVillageName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session["villagecode"] = dpVillageName.SelectedIndex;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void grdInwardOutwardReg_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = grdInwardOutwardReg.SelectedRow;
                int ionumber = Convert.ToInt32(row.Cells[2].Text);
                Session["ionumber"] = ionumber;
                dpreceiveddocumenttype.SelectedIndex =Convert.ToInt32(row.Cells[3].Text);
                txtreceivedfrom.Text = row.Cells[4].Text;
                txtReceivedDocRemark.Text = row.Cells[5].Text;
                txtReceivedBy.Text = row.Cells[6].Text;
                txtInwardNo.Text = row.Cells[7].Text;
                txtInwardDate.Text = row.Cells[8].Text;
                txtInwardSection.Text = row.Cells[9].Text;
                dpsentdocumenttype.SelectedIndex = Convert.ToInt32(row.Cells[10].Text);
                txtSentTo.Text = row.Cells[11].Text;
                txtSentDocRemark.Text = row.Cells[12].Text;
                txtSentBy.Text = row.Cells[13].Text;
                txtOutwardNo.Text = row.Cells[14].Text;
                txtOutwardDate.Text = row.Cells[15].Text;
                txtOutwardSection.Text = row.Cells[16].Text;
                txtOutwardMode.Text = row.Cells[17].Text;

                //DataTable dtData = ((DataTable)dpVillageName.DataSource);
                //for (int i = 0; i < dtData.Rows.Count; i++)
                //{
                //    if (dtData.Rows[i]["villagemname"].ToString() == row.Cells[18].Text.ToString())
                //    {
                //        i++;
                //        dpVillageName.SelectedIndex = i;
                //        break;
                //    }
                //}

                // dpVillageName.SelectedIndex= Convert.ToInt32(row.Cells[18].Text);
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
                dbInOutWardReg.ionumber = Convert.ToInt32(Session["ionumber"]);
                dbInOutWardReg.receiveddocumentcode = Convert.ToString(Session["receiveddoccode"]);
                dbInOutWardReg.receivedfrom = txtreceivedfrom.Text;
                dbInOutWardReg.receiveddocremark = txtReceivedDocRemark.Text;
                dbInOutWardReg.receivedby = txtReceivedBy.Text;
                dbInOutWardReg.inwardno = txtInwardNo.Text;
                dbInOutWardReg.inwarddate = txtInwardDate.Text;
                dbInOutWardReg.inwardsection = txtInwardSection.Text;
                dbInOutWardReg.sentdocumentcode = Convert.ToString(Session["sentdoccode"]);
                dbInOutWardReg.sentto = txtSentTo.Text;
                dbInOutWardReg.sentdocremark = txtSentDocRemark.Text;
                dbInOutWardReg.sentby = txtSentBy.Text;
                dbInOutWardReg.outwardno = txtOutwardNo.Text;
                dbInOutWardReg.outwarddate = txtOutwardDate.Text;
                dbInOutWardReg.outwardsection = txtOutwardSection.Text;
                dbInOutWardReg.outwardmode = txtOutwardMode.Text;
                dbInOutWardReg.villagecode = Convert.ToString(Convert.ToString(Session["villagecode"]));
                boolEditRecord = dbInOutWardReg.EditInwardOutwardReg();
                if (boolEditRecord)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Record Updated Successfully');", true);
                    dpreceiveddocumenttype.SelectedIndex = 0;
                    txtreceivedfrom.Text = "";
                    txtReceivedDocRemark.Text = "";
                    txtReceivedBy.Text = "";
                    txtInwardNo.Text = "";
                    txtInwardDate.Text = "";
                    txtInwardSection.Text = "";
                    dpsentdocumenttype.SelectedIndex = 0;
                    txtSentTo.Text = "";
                    txtSentDocRemark.Text = "";
                    txtSentBy.Text = "";
                    txtOutwardNo.Text = "";
                    txtOutwardDate.Text = "";
                    txtOutwardSection.Text = "";
                    txtOutwardMode.Text = "";
                    dpVillageName.SelectedIndex = 0;

                    dsInOutWardReg = dbInOutWardReg.getInOutWardRegData();
                    if (dsInOutWardReg.Tables[0].Rows.Count > 0)
                    {
                        grdInwardOutwardReg.DataSource = dsInOutWardReg.Tables[0].DefaultView;
                        grdInwardOutwardReg.DataBind();

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
                dbInOutWardReg.ionumber = Convert.ToInt32(Session["ionumber"]);
                boolDeleteRecord = dbInOutWardReg.DeleteInwardOutwardReg();
                if (boolDeleteRecord)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Record Deleted Successfully');", true);
                    dpreceiveddocumenttype.SelectedIndex = 0;
                    txtreceivedfrom.Text = "";
                    txtReceivedDocRemark.Text = "";
                    txtReceivedBy.Text = "";
                    txtInwardNo.Text = "";
                    txtInwardDate.Text = "";
                    txtInwardSection.Text = "";
                    dpsentdocumenttype.SelectedIndex = 0;
                    txtSentTo.Text = "";
                    txtSentDocRemark.Text = "";
                    txtSentBy.Text = "";
                    txtOutwardNo.Text = "";
                    txtOutwardDate.Text = "";
                    txtOutwardSection.Text = "";
                    txtOutwardMode.Text = "";
                    dpVillageName.SelectedIndex = 0;

                    dsInOutWardReg = dbInOutWardReg.getInOutWardRegData();
                    if (dsInOutWardReg.Tables[0].Rows.Count > 0)
                    {
                        grdInwardOutwardReg.DataSource = dsInOutWardReg.Tables[0].DefaultView;
                        grdInwardOutwardReg.DataBind();

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}