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
    public partial class Village2 : System.Web.UI.Page
    {
        DataSet dsVillageMaster = new DataSet();
        dbVillage dbVillageData = new dbVillage();
        

        protected void Page_Load(object sender, EventArgs e)
        {

            lblHeading.Text = "Village Master";
            dsVillageMaster = dbVillageData.getVillageData();
            if(dsVillageMaster.Tables[0].Rows.Count > 0)
            {
                grdVillage.DataSource = dsVillageMaster.Tables[0].DefaultView;
                grdVillage.DataBind();

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool boolAddVillage = false;
            string SeqVillageID = dbVillageData.getVillageSeqNo();
            dbVillageData.villageid = Convert.ToInt32(SeqVillageID.ToString());
            dbVillageData.villagecode = txtVillageCode.Text;
            dbVillageData.villagename = txtVillageName.Text;
            dbVillageData.villagemname = txtVIllageMarathiName.Text;
            boolAddVillage = dbVillageData.AddVillage();
            if (boolAddVillage)
            {
                
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Record Inserted Successfully');", true);
                //Response.Write("<script>alert('Village Data Save ');</script>");
                txtVillageCode.Text = "";
                txtVillageName.Text = "";
                txtVIllageMarathiName.Text = "";

                dsVillageMaster = dbVillageData.getVillageData();
                if (dsVillageMaster.Tables[0].Rows.Count > 0)
                {
                    grdVillage.DataSource = dsVillageMaster.Tables[0].DefaultView;
                    grdVillage.DataBind();

                }
            }
        }

        protected void grdVillage_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Sr.No.";
                e.Row.Cells[1].Text = "ID";
                e.Row.Cells[2].Text = "Code";
                e.Row.Cells[3].Text = "Name";
                e.Row.Cells[4].Text = "Marathi Name";

                e.Row.Cells[0].Width = new Unit("50px");
                e.Row.Cells[1].Width = new Unit("50px");
                e.Row.Cells[2].Width = new Unit("75px");
                e.Row.Cells[3].Width = new Unit("150px");
                e.Row.Cells[4].Width = new Unit("150px");


            }
        }

        protected void grdVillage_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdVillage.PageIndex = e.NewPageIndex;
        }
    }
}