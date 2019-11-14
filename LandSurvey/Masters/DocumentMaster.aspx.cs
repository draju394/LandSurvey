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
    public partial class DocumentMaster : System.Web.UI.Page
    {
        DataSet dsDocument = new DataSet();
        dbDocumentMaster dbDocument = new dbDocumentMaster();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //if (!IsPostBack)
                //{
                    lblHeading.Text = "Document Master";
                    dsDocument = dbDocument.getDocumentData();
                    if (dsDocument.Tables[0].Rows.Count > 0)
                    {
                        grdDocument.DataSource = dsDocument.Tables[0].DefaultView;
                        grdDocument.DataBind();

                    }

                //}
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void grdDocument_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    e.Row.Cells[0].Text = "";
                    e.Row.Cells[1].Text = "Sr.No.";
                    e.Row.Cells[2].Text = "ID";
                    e.Row.Cells[3].Text = "Code";
                    e.Row.Cells[4].Text = "Name";
                    e.Row.Cells[5].Text = "Marathi Name";

                    e.Row.Cells[0].Width = new Unit("50px");
                    e.Row.Cells[1].Width = new Unit("50px");
                    e.Row.Cells[2].Width = new Unit("50px");
                    e.Row.Cells[3].Width = new Unit("150px");
                    e.Row.Cells[4].Width = new Unit("150px");
                    e.Row.Cells[5].Width = new Unit("150px");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void grdDocument_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDocument.PageIndex = e.NewPageIndex;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool boolAddDocument = false;
                string SeqDocumentID = dbDocument.getDocumentSeqNo();
                dbDocument.documentid = Convert.ToInt32(SeqDocumentID.ToString());
                dbDocument.documentcode = txtDocumentCode.Text;
                dbDocument.documentename = txtDocumentName.Text;
                dbDocument.documentmname = txtDocumentMarathiName.Text;
                boolAddDocument = dbDocument.AddDocument();
                if (boolAddDocument)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Record Inserted Successfully');", true);
                    txtDocumentCode.Text = "";
                    txtDocumentName.Text = "";
                    txtDocumentMarathiName.Text = "";

                    dsDocument = dbDocument.getDocumentData();
                    if (dsDocument.Tables[0].Rows.Count > 0)
                    {
                        grdDocument.DataSource = dsDocument.Tables[0].DefaultView;
                        grdDocument.DataBind();

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void grdDocument_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = grdDocument.SelectedRow;
                int documentid = Convert.ToInt32(row.Cells[2].Text);
                Session["documentid"] = documentid;
                txtDocumentCode.Text = row.Cells[3].Text;
                txtDocumentName.Text = row.Cells[4].Text;
                txtDocumentMarathiName.Text = row.Cells[5].Text;
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
                bool boolEditDocument = false;
                dbDocument.documentid = Convert.ToInt32(Session["documentid"]);
                dbDocument.documentcode = txtDocumentCode.Text;
                dbDocument.documentename = txtDocumentName.Text;
                dbDocument.documentmname = txtDocumentMarathiName.Text;
                boolEditDocument = dbDocument.EditDocument();
                if (boolEditDocument)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Record Updated Successfully');", true);
                    txtDocumentCode.Text = "";
                    txtDocumentName.Text = "";
                    txtDocumentMarathiName.Text = "";

                    dsDocument = dbDocument.getDocumentData();
                    if (dsDocument.Tables[0].Rows.Count > 0)
                    {
                        grdDocument.DataSource = dsDocument.Tables[0].DefaultView;
                        grdDocument.DataBind();

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
                bool boolDeleteDocument = false;
                dbDocument.documentid = Convert.ToInt32(Session["documentid"]);
                boolDeleteDocument = dbDocument.DeleteDocument();
                if (boolDeleteDocument)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Record Deleted Successfully');", true);
                    txtDocumentCode.Text = "";
                    txtDocumentName.Text = "";
                    txtDocumentMarathiName.Text = "";

                    dsDocument = dbDocument.getDocumentData();
                    if (dsDocument.Tables[0].Rows.Count > 0)
                    {
                        grdDocument.DataSource = dsDocument.Tables[0].DefaultView;
                        grdDocument.DataBind();
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