using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LandSurvey.DAL;
using System.IO;
using System.Drawing;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.tool.xml;

namespace LandSurvey.Masters
{
    public partial class CheckListMaster : System.Web.UI.Page
    {
        DataSet dsCheckListMaster = new DataSet();
        dbCheckList dbCheckListData = new dbCheckList();
        string AddEditMode = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            lblHeading.Text = "Check List Master";
            dsCheckListMaster = dbCheckListData.getCheckListData();
            if (dsCheckListMaster.Tables[0].Rows.Count > 0)
            {
                grdCheckList.DataSource = dsCheckListMaster.Tables[0].DefaultView;
                grdCheckList.DataBind();

            }
            DisableControls();
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.Header)
            //{
            //    e.Row.Cells[0].Text = "Sr.No.";
            //    e.Row.Cells[1].Text = "ID";
            //    e.Row.Cells[2].Text = "Check list Item";
            //    e.Row.Cells[3].Text = "Status";


            //    e.Row.Cells[0].Width = new Unit("50px");
            //    e.Row.Cells[1].Width = new Unit("50px");
            //    e.Row.Cells[2].Width = new Unit("200px");
            //    e.Row.Cells[3].Width = new Unit("50px");



            //}
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdCheckList, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }


        protected void btnSaveChkList_Click(object sender, EventArgs e)
        {
            if (txtChkListName.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Check List Name');", true);
                btnSaveChkList.Enabled = true;
            }
            else
            {
                if (AddEditMode == "Add")
                {
                    btnAdd.Enabled = false;
                    bool boolAddCheckListMaster = false;
                    string SeqChkListID = dbCheckListData.getCheckListSeqNo();
                    dbCheckListData.chklistno = Convert.ToInt32(SeqChkListID.ToString());
                    dbCheckListData.chkname = txtChkListName.Text;
                    dbCheckListData.status = cmbChkListStatus.Text;
                    dbCheckListData.createdby = Session["userFullName"].ToString();
                    dbCheckListData.createddate = DateTime.Today;
                    boolAddCheckListMaster = dbCheckListData.AddCheckListMaster();
                    if (boolAddCheckListMaster)
                    {

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Record Inserted Successfully');", true);
                        //Response.Write("<script>alert('Village Data Save ');</script>");
                        txtChkListName.Text = "";
                        txtChkListNo.Text = "";
                        btnSaveChkList.Enabled = false;
                        dsCheckListMaster = dbCheckListData.getCheckListData();
                        if (dsCheckListMaster.Tables[0].Rows.Count > 0)
                        {
                            grdCheckList.DataSource = dsCheckListMaster.Tables[0].DefaultView;
                            grdCheckList.DataBind();

                        }
                        btnEdit.Text = "Edit Check List";
                        btnAdd.Enabled = true;
                    }
                }
                else // AddEdit MOde - Edit
                {
                    btnEdit.Text = "Cancel";
                    bool boolUpdateCheckListMaster = false;
                    
                    dbCheckListData.chklistno = Convert.ToInt32(txtChkListNo.Text.ToString());
                    dbCheckListData.chkname = txtChkListName.Text;
                    dbCheckListData.status = cmbChkListStatus.Text;
                    dbCheckListData.modifiedby = Session["userFullName"].ToString();
                    dbCheckListData.modifieddate = DateTime.Today;
                    boolUpdateCheckListMaster = dbCheckListData.UpdateCheckList();
                    if(boolUpdateCheckListMaster)
                    {

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Record Updated Successfully');", true);
                        //Response.Write("<script>alert('Village Data Save ');</script>");
                        txtChkListName.Text = "";
                        txtChkListNo.Text = "";
                        btnSaveChkList.Enabled = false;
                        dsCheckListMaster = dbCheckListData.getCheckListData();
                        if (dsCheckListMaster.Tables[0].Rows.Count > 0)
                        {
                            grdCheckList.DataSource = dsCheckListMaster.Tables[0].DefaultView;
                            grdCheckList.DataBind();

                        }
                        btnEdit.Text = "Edit Check List";
                        btnAdd.Enabled = true;
                    }

                }
            }
        }

        protected void grdCheckList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grdCheckList.Rows.Count > 0)
            {

                foreach (GridViewRow row in grdCheckList.Rows)
                {
                    if (row.RowIndex == grdCheckList.SelectedIndex)
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
                //string SurveyNo = grdCheckList.SelectedRow.Cells[1].Text;
                //string HolderName = grdCheckList.SelectedRow.Cells[2].Text;
                
                txtChkListNo.Text = grdCheckList.SelectedRow.Cells[1].Text;
                txtChkListName.Text = grdCheckList.SelectedRow.Cells[2].Text;
                string ChkListStatus = grdCheckList.SelectedRow.Cells[3].Text;
                if(ChkListStatus == "Yes")
                {
                    cmbChkListStatus.Text = "Active";
                }
                EnableControls();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            txtChkListName.Enabled = true;
            txtChkListName.Text = "";
            cmbChkListStatus.Enabled = true;
            btnEdit.Text = "Cancel";
            btnSaveChkList.Enabled = true;
            btnEdit.Enabled = true;
            btnAdd.Enabled = false;
            AddEditMode = "Add";
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if(btnEdit.Text == "Cancel")
            {
                DisableControls();
                btnEdit.Text = "Edit Check List";
            }
            else
            {
                btnEdit.Enabled = false;
                txtChkListName.Enabled = true;
                cmbChkListStatus.Enabled = true;
                btnAdd.Enabled = false;
                btnSaveChkList.Enabled = true;
                AddEditMode = "Edit";
            }
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            ExportGridToPDF();
            //////Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            ////Response.ContentType = "application/pdf";

            ////Response.AddHeader("content-disposition", "attachment;filename=FileName.pdf");

            ////Response.Cache.SetCacheability(HttpCacheability.NoCache);

            ////StringWriter sw = new StringWriter();

            ////HtmlTextWriter w = new HtmlTextWriter(sw);

            ////print.RenderControl(w);


            ////string htmWrite = sw.GetStringBuilder().ToString();

            ////htmWrite = Regex.Replace(htmWrite, "</?(a|A).*?>", "");

            ////htmWrite = htmWrite.Replace("\r\n", "");

            ////StringReader reader = new StringReader(htmWrite);



            ////Document doc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);

            ////string pdfFilePath = Server.MapPath(".") + "/PDFFiles";

            ////HTMLWorker htmlparser = new HTMLWorker(doc);

            ////PdfWriter.GetInstance(doc, Response.OutputStream);



            ////doc.Open();

            ////try

            ////{

            ////    htmlparser.Parse(reader);

            ////    doc.Close();

            ////    Response.Write(doc);

            ////    Response.End();

            ////}

            ////catch (Exception ex)

            ////{ }

            ////finally

            ////{

            ////    doc.Close();

            ////}
        }

        private void DisableControls()
        {
            btnSaveChkList.Enabled = false;
            btnEdit.Enabled = false;
            txtChkListName.Enabled = false;
            txtChkListNo.Enabled = false;
            cmbChkListStatus.Enabled = false;

        }

        private void EnableControls()
        {
            btnEdit.Enabled = true;
        }

        protected void grdCheckList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCheckList.PageIndex = e.NewPageIndex;
        }
        //

        private void ExportGridToPDF()
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    grdCheckList.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
                    //Response.ContentEncoding = System.Text.Encoding.Unicode;
                    //Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }

            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "attachment;filename=CheckListMaster.pdf");
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter hw = new HtmlTextWriter(sw);
            //grdCheckList.RenderControl(hw);
            //StringReader sr = new StringReader(sw.ToString());
            //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            ////xMLWorkerHelper htmlparser = new xMLWorkerHelper(pdfDoc);
            //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            //pdfDoc.Open();
            //htmlparser.Parse(sr);
            //pdfDoc.Close();
            //Response.Write(pdfDoc);
            //Response.End();
            //grdCheckList.AllowPaging = true;
            //grdCheckList.DataBind();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }

        //
    }
}