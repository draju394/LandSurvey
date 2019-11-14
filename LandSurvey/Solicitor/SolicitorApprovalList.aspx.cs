using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LandSurvey.DAL;
using System.Data;

namespace LandSurvey.Solicitor
{
    public partial class SolicitorApprovalList : System.Web.UI.Page
    {
        DataSet dsSolicitorList = new DataSet();
        dbDocumentStatus dbSolictiorListData = new dbDocumentStatus();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShowSolicitorApprovalData();
            }
        }

        protected void grdSolicitorApproval_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdSolicitorApproval_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void ShowSolicitorApprovalData()
        {
           

                dsSolicitorList = dbSolictiorListData.getSolicitorDocumentsForApproval();
                if (dsSolicitorList.Tables[0].Rows.Count > 0)
                {
                    grdSolicitorApproval.DataSource = dsSolicitorList;
                    grdSolicitorApproval.DataBind();
                  

                }
                else
                {
                    grdSolicitorApproval.DataSource = null;
                    grdSolicitorApproval.DataBind();

                }
            

        }

        protected void btnApproveDocument_Click(object sender, EventArgs e)
        {
            if(grdSolicitorApproval.SelectedIndex >=0 )
            {
                string VillageCode = grdSolicitorApproval.Rows[grdSolicitorApproval.SelectedIndex].Cells[1].Text;
                string DocumentNo = grdSolicitorApproval.Rows[grdSolicitorApproval.SelectedIndex].Cells[3].Text;
                string VillageName = grdSolicitorApproval.Rows[grdSolicitorApproval.SelectedIndex].Cells[2].Text;
                Response.Redirect(String.Format("SolicitorApprovalNew.aspx?Village={0}&Doc={1}&VName={2}", Server.UrlEncode(VillageCode), Server.UrlEncode(DocumentNo), Server.UrlEncode(VillageName)));
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Record for Approval');", true);
            }
           
          
        }

        //
    }
}