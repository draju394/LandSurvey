using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LandSurvey.DAL;
using Syncfusion.EJ.Export;
using Syncfusion.Pdf;
using Syncfusion.JavaScript.Web;
using System.Collections;
using System.Drawing;
using Syncfusion.Pdf.Graphics;
using System.IO;
using System.Configuration;

namespace LandSurvey.Client
{
    public partial class ClientApproval : System.Web.UI.Page
    {
        //public string filePath = Convert.ToString(ConfigurationManager.AppSettings["UploadFilePath"]);
        DataSet dsSummary = new DataSet();
        dbReports dbReportsData = new dbReports();
        dbDocumentStatus dbDocStatus = new dbDocumentStatus();
        dbDocument dbDocumentStatusData = new dbDocument();

        DataSet dsVillage = new DataSet();
        DataSet dsDocument = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    dsVillage = dbReportsData.getVillages();

                    if (dsVillage != null && dsVillage.Tables[0].Rows.Count > 0)
                    {
                        DataTable dtVillage = dsVillage.Tables[0];
                        cmbVillage.DataSource = dsVillage.Tables[0].DefaultView;
                        cmbVillage.DataBind();
                        cmbVillage.DataTextField = dsVillage.Tables[0].Columns["villagemname"].ToString();
                        cmbVillage.DataValueField = dsVillage.Tables[0].Columns["villagecode"].ToString();
                        cmbVillage.DataBind();
                    }

                    dsDocument = dbDocStatus.getDocumentNumber();

                    if (dsDocument != null && dsDocument.Tables[0].Rows.Count > 0)
                    {
                        DataTable dtDocument = dsDocument.Tables[0];
                        cmdDocumentNumber.DataSource = dsDocument.Tables[0].DefaultView;
                        cmdDocumentNumber.DataBind();
                        cmdDocumentNumber.DataTextField = dsDocument.Tables[0].Columns["docno"].ToString();
                        cmdDocumentNumber.DataValueField = dsDocument.Tables[0].Columns["docno"].ToString();
                        cmdDocumentNumber.DataBind();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void cmdDocumentNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string VillageCode = cmbVillage.SelectedValue;
                string DocumentNo = cmdDocumentNumber.SelectedValue;

                lblIteration1.Text = "1";
                lblIteration2.Text = "";
                lblIteration3.Text = "";

                grdDocument.DataSource = null;
                grdDocument.DataBind();

                if (DocumentNo == "Select")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Select Document No');", true);
                }

                if (VillageCode == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Select Village');", true);
                }

                string filePath = Server.MapPath("~/Documents/") + VillageCode;

                DataTable table = new DataTable();
                table.Columns.Add("id", typeof(int));
                table.Columns.Add("actionpoints", typeof(string));
                table.Columns.Add("value", typeof(string));
                table.Columns.Add("value1", typeof(string));
                table.Columns.Add("value2", typeof(string));
                table.Columns.Add("documentcode", typeof(string));
                table.Columns.Add("check", typeof(string));
                table.Columns.Add("docno", typeof(string));
                table.Columns.Add("villagecode", typeof(string));
                table.Columns.Add("uploaddoccode", typeof(string));
                table.Columns.Add("iterationno", typeof(string));

                table.Columns.Add("docname", typeof(string));
                table.Columns.Add("docname1", typeof(string));
                table.Columns.Add("docname2", typeof(string));

                table.Rows.Add(1, "Primary Title Search Document", "", "", "", "PTS", "download", "", "", "PTS", "1", "", "", "");
                table.Rows.Add(2, "Accept Primary Search Document", "", "", "", "PTS", "approval", "", "", "PTS", "1", "", "", "");
                table.Rows.Add(3, "Upload Queries-PTS", "", "", "", "PTS", "query", "", "", "UQCPTS", "1", "", "", "");
                table.Rows.Add(4, "Clarification Documents from H.O.-PTSQ", "", "", "", "ODHO", "download", "", "", "ODHO", "1", "", "", "");
                table.Rows.Add(5, "Final Title Search Document", "", "", "", "FTS", "download", "", "", "FTS", "1", "", "", "");
                table.Rows.Add(6, "Accept Final Search Document", "", "", "", "FTS", "approval", "", "", "FTS", "1", "", "", "");
                table.Rows.Add(7, "Upload Queries-FTS", "", "", "", "FTS", "query", "", "", "UQCFTS", "1", "", "", "");
                table.Rows.Add(8, "Clarification Documents From H.O.-FTS,", "", "", "", "FTS", "download", "", "", "HOFTS", "1", "", "", "");

                table.Rows.Add(9, "Sale Deed", "", "", "", "SD", "download", "", "", "SD", "1", "", "", "");
                table.Rows.Add(10, "Accept Sale Deed", "", "", "", "SD", "approval", "", "", "SD", "1", "", "", "");
                table.Rows.Add(11, "Upload Queries-SD", "", "", "", "SD", "query", "", "", "UQSD", "1", "", "", "");

                table.Rows.Add(12, "Agreement to Sale", "", "", "", "ATS", "download", "", "", "ATS", "1", "", "", "");
                table.Rows.Add(13, "Accept Agreement to Sale", "", "", "", "ATS", "approval", "", "", "ATS", "1", "", "", "");
                table.Rows.Add(14, "Upload Queries-ATS", "", "", "", "ATS", "query", "", "", "UQATS", "1", "", "", "");

                //PTS,OHDO,FTS
                dsDocument = dbDocStatus.getDocumentsForApproval(VillageCode, DocumentNo);

                if (dsDocument != null && dsDocument.Tables[0].Rows.Count > 0)
                {
                    btnSave.Visible = true;
                    btnReset.Visible = true;

                    foreach (DataRow dr in dsDocument.Tables[0].Select())
                    {
                        string vCode = dr["villagecode"].ToString();
                        string dNo = dr["docno"].ToString();
                        string docCode = dr["documentcode"].ToString();
                        string docName = dr["documentname"].ToString();
                        string docPath = dr["documentpath"].ToString();

                        DataRow drUpdate = table.AsEnumerable().Where(r => ((string)r["documentcode"]).Equals(docCode) && ((string)r["check"]).Equals("download")).FirstOrDefault(); // getting the row to edit , change it as you need

                        if (drUpdate != null)
                        {
                            if ((docName.Contains("1.do") && docPath.Contains("1.do")) || (docName.Contains("1.pdf") && docPath.Contains("1.pdf")))
                            {
                                //1 iteration
                                lblIteration1.Text = "1";

                                string chkFilePath = dr["documentpath"].ToString();

                                if (System.IO.File.Exists(chkFilePath))
                                {
                                    drUpdate["value"] = dr["documentpath"].ToString();
                                    drUpdate["docname"] = dr["documentname"] != DBNull.Value ? (dr["documentname"].ToString()) : "No File";
                                }
                                else
                                {
                                    drUpdate["value"] = "";
                                    drUpdate["docname"] = "No File";
                                }

                                drUpdate["value1"] = "";
                                drUpdate["value2"] = "";

                                drUpdate["docname1"] = "";
                                drUpdate["docname2"] = "";


                            }
                            else if ((docName.Contains("1.do") && docPath.Contains("2.do")) || (docName.Contains("1.pdf") && docPath.Contains("2.pdf")))
                            {
                                //2 iteration 
                                lblIteration1.Text = "1";
                                lblIteration2.Text = "2";
                                //1 Iteration
                                if (System.IO.File.Exists(filePath + "\\" + docName.Replace("2.do", "1.do")))
                                {
                                    drUpdate["value"] = filePath + "\\" + docName.Replace("2.do", "1.do");
                                    drUpdate["docname"] = !string.IsNullOrEmpty(docName.Replace("2.do", "1.do")) ? (docName.Replace("2.do", "1.do")) : "No File";
                                }
                                else if (System.IO.File.Exists(filePath + "\\" + docName.Replace("2.pdf", "1.pdf")))
                                {
                                    drUpdate["value"] = filePath + "\\" + docName.Replace("2.pdf", "1.pdf");
                                    drUpdate["docname"] = !string.IsNullOrEmpty(docName.Replace("2.pdf", "1.pdf")) ? (docName.Replace("2.pdf", "1.pdf")) : "No File";
                                }
                                else
                                {
                                    drUpdate["value"] = "";
                                    drUpdate["docname"] = "No File";
                                }
                                //2 iteration 
                                string chkFilePath = dr["documentpath"].ToString();

                                if (System.IO.File.Exists(chkFilePath))
                                {
                                    drUpdate["value1"] = dr["documentpath"].ToString();
                                    drUpdate["docname1"] = dr["documentname"] != DBNull.Value ? (dr["documentname"].ToString()) : "No File";

                                }
                                else
                                {
                                    drUpdate["value1"] = "";
                                    drUpdate["docname1"] = "No File";
                                }

                                drUpdate["docname2"] = "";
                                drUpdate["value2"] = "";


                            }
                            if ((docName.Contains("2.do") && docPath.Contains("3.do")) || (docName.Contains("2.pdf") && docPath.Contains("3.pdf")))
                            {
                                //3 iteration
                                lblIteration1.Text = "1";
                                lblIteration2.Text = "2";
                                lblIteration3.Text = "3";

                                //docName = docName.Replace("2.do", "1.do");

                                //1 Iteration
                                if (System.IO.File.Exists(filePath + "\\" + docName.Replace("2.do", "1.do")))
                                {
                                    drUpdate["value"] = filePath + "\\" + docName.Replace("2.do", "1.do");
                                    drUpdate["docname"] = !string.IsNullOrEmpty(docName.Replace("2.do", "1.do")) ? (docName.Replace("2.do", "1.do")) : "No File";
                                }
                                else if (System.IO.File.Exists(filePath + "\\" + docName.Replace("2.pdf", "1.pdf")))
                                {
                                    drUpdate["value"] = filePath + "\\" + docName.Replace("2.pdf", "1.pdf");
                                    drUpdate["docname"] = !string.IsNullOrEmpty(docName.Replace("2.pdf", "1.pdf")) ? (docName.Replace("2.pdf", "1.pdf")) : "No File";
                                }
                                else
                                {
                                    drUpdate["value"] = "";
                                    drUpdate["docname"] = "No File";
                                }

                                //2 Iteration
                                if (System.IO.File.Exists(filePath + "\\" + docName.Replace("3.do", "2.do")))
                                {
                                    drUpdate["value1"] = filePath + "\\" + docName.Replace("3.do", "2.do");
                                    drUpdate["docname1"] = !string.IsNullOrEmpty(docName.Replace("3.do", "2.do")) ? (docName.Replace("3.do", "2.do")) : "No File";
                                }
                                else if (System.IO.File.Exists(filePath + "\\" + docName.Replace("3.pdf", "2.pdf")))
                                {
                                    drUpdate["value1"] = filePath + "\\" + docName.Replace("3.pdf", "2.pdf");
                                    drUpdate["docname1"] = !string.IsNullOrEmpty(docName.Replace("3.pdf", "2.pdf")) ? (docName.Replace("3.pdf", "2.pdf")) : "No File";
                                }
                                else
                                {
                                    drUpdate["value1"] = "";
                                    drUpdate["docname1"] = "No File";
                                }

                                //3 Iteration
                                string chkFilePath = dr["documentpath"].ToString();

                                if (System.IO.File.Exists(chkFilePath))
                                {
                                    drUpdate["value2"] = dr["documentpath"].ToString();

                                    string dname = dr["documentname"].ToString();

                                    if (dname.Contains("_2."))
                                        dname = dname.Replace("_2.", "_3.");

                                    //drUpdate["docname2"] = dr["documentname"] != DBNull.Value ? (dr["documentname"].ToString()) : "No File";

                                    drUpdate["docname2"] = dname != string.Empty ? (dname) : "No File";
                                }
                                else
                                {
                                    drUpdate["value2"] = "";
                                    drUpdate["docname2"] = "No File";
                                }

                                //drUpdate["value"] = filePath + "\\" + docName.Replace("2.do", "1.do");
                                //drUpdate["value1"] = filePath + "\\" + docName.Replace("3.do", "2.do");
                                //drUpdate["value2"] = dr["documentpath"].ToString();

                                //drUpdate["docname"] = !string.IsNullOrEmpty(docName.Replace("2.do", "1.do")) ? docName.Replace("2.do", "1.do") : "No File";
                                //drUpdate["docname1"] = !string.IsNullOrEmpty(docName.Replace("3.do", "2.do")) ? docName.Replace("3.do", "2.do") : "No File";
                                //drUpdate["docname2"] = dr["documentname"] != DBNull.Value ? (dr["documentname"].ToString()) : "No File";
                            }
                        }
                    }

                    string IterationNo = "1";

                    if (lblIteration1.Text == "1" && lblIteration2.Text == "" && lblIteration3.Text == "")
                        IterationNo = "1";
                    else if (lblIteration1.Text == "1" && lblIteration2.Text == "2" && lblIteration3.Text == "")
                        IterationNo = "2";
                    else if (lblIteration1.Text == "1" && lblIteration2.Text == "2" && lblIteration3.Text == "3")
                        IterationNo = "3";

                    var rowsToUpdate = table.AsEnumerable();

                    foreach (var row in rowsToUpdate)
                    {
                        row.SetField("villagecode", VillageCode);
                        row.SetField("docno", DocumentNo);
                        row.SetField("iterationno", IterationNo);
                    }

                    grdDocument.DataSource = table;
                    grdDocument.DataBind();
                }
                else
                {
                    btnSave.Visible = false;
                    btnReset.Visible = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void grdDocument_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "download")
                {
                    //int index = Convert.ToInt32(e.CommandArgument);
                    string url = e.CommandArgument.ToString();
                    DownloadFile(url);
                }
                if (e.CommandName == "download1")
                {
                    string url = e.CommandArgument.ToString();
                    DownloadFile(url);
                }
                if (e.CommandName == "download2")
                {
                    //int index = Convert.ToInt32(e.CommandArgument);
                    string url = e.CommandArgument.ToString();
                    DownloadFile(url);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void DownloadFile(string url)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(url);
            if (file.Exists)
            {
                Response.Clear();
                Response.AppendHeader("Content-Disposition:", "attachment; filename=" + file.Name);
                Response.AppendHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.TransmitFile(file.FullName);
                Response.End();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('NO FILE PRESENT');", true);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = Server.MapPath("~/Documents/");

                int cellNo = 0;
                if (lblIteration1.Text == "1" && lblIteration2.Text == "" && lblIteration3.Text == "")
                    cellNo = 0;
                else if (lblIteration1.Text == "1" && lblIteration2.Text == "2" && lblIteration3.Text == "")
                    cellNo = 1;
                else if (lblIteration1.Text == "1" && lblIteration2.Text == "2" && lblIteration3.Text == "3")
                    cellNo = 2;

                for (int i = 0; i < grdDocument.Rows.Count; i++)
                {

                    string villagecode = grdDocument.DataKeys[i].Values[0].ToString();
                    string docno = grdDocument.DataKeys[i].Values[1].ToString();
                    string documentcode = grdDocument.DataKeys[i].Values[2].ToString();
                    string uploaddoccode = grdDocument.DataKeys[i].Values[3].ToString();

                    RadioButtonList rblApproval = (RadioButtonList)grdDocument.Rows[i].Cells[cellNo].FindControl("rblApproval" + cellNo.ToString());
                    FileUpload fuQueryUpload = (FileUpload)grdDocument.Rows[i].Cells[cellNo].FindControl("fuQueryUpload" + cellNo.ToString());

                    string action = rblApproval.ToolTip.ToString();
                    string filename = "", folderPath = filePath + villagecode + "\\";

                    if (action.Contains("query"))
                    {
                        if (fuQueryUpload.HasFile)
                        {
                            //"FR_40_17_12.sql"
                            string sSystemFileName = Path.GetFileName(fuQueryUpload.PostedFile.FileName);
                            string sFileExtention = Path.GetExtension(sSystemFileName);

                            filename = uploaddoccode + "_" + villagecode + "_" + docno + "_" + "1" + sFileExtention;

                            string ValidExtensions = ".pdf,.xls,.xlsx,.doc,.docx,";
                            if (ValidExtensions.ToLower().Contains(sFileExtention.Trim().ToLower() + ","))
                            {
                                if (!Directory.Exists(folderPath))
                                {
                                    Directory.CreateDirectory(folderPath);
                                }

                                {
                                    fuQueryUpload.SaveAs(folderPath + filename);
                                }
                            }
                        }
                    }
                    bool bValid = false;
                    dbDocStatus.villagecode = villagecode;
                    dbDocStatus.docno = docno;
                    dbDocStatus.documentcode = documentcode;
                    dbDocStatus.type = action;
                    dbDocStatus.approvetype = "client";

                    if (action == "query" && !string.IsNullOrEmpty(filename))
                    {
                        string DocumentID = dbDocumentStatusData.getDocumentSeqNo();
                        dbDocStatus.documentid = Convert.ToInt32(DocumentID);
                        dbDocStatus.documentname = filename;
                        dbDocStatus.solicitorapproval = rblApproval.SelectedValue;
                        dbDocStatus.solicitorappdate = DateTime.Today;
                        dbDocStatus.documentpath = folderPath + filename;
                        dbDocStatus.createdby = "RSD";
                        dbDocStatus.createddate = DateTime.Today;
                        dbDocStatus.documentcode = uploaddoccode;

                        bValid = dbDocStatus.UpdateDocumentStatus();
                    }
                    if (action == "approval")
                    {
                        dbDocStatus.solicitorapproval = rblApproval.SelectedValue;
                        dbDocStatus.solicitorappdate = DateTime.Today;
                        bValid = dbDocStatus.UpdateDocumentStatus();
                    }
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Record Inserted Successfully');", true);
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
                cmbVillage.SelectedIndex = 0;
                cmdDocumentNumber.SelectedIndex = 0;
                btnSave.Visible = false;
                btnReset.Visible = false;
                grdDocument.DataSource = null;
                grdDocument.DataBind();

                lblIteration1.Text = "";
                lblIteration2.Text = "";
                lblIteration3.Text = "";
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
                if (lblIteration1.Text == "1" && lblIteration2.Text == "" && lblIteration3.Text == "")
                {
                    e.Row.Cells[1].Visible = true;
                    e.Row.Cells[2].Visible = false;
                    e.Row.Cells[3].Visible = false;
                }
                else if (lblIteration1.Text == "1" && lblIteration2.Text == "2" && lblIteration3.Text == "")
                {
                    e.Row.Cells[1].Visible = true;
                    e.Row.Cells[2].Visible = true;
                    e.Row.Cells[3].Visible = false;
                }
                else if (lblIteration1.Text == "1" && lblIteration2.Text == "2" && lblIteration3.Text == "3")
                {
                    e.Row.Cells[1].Visible = true;
                    e.Row.Cells[2].Visible = true;
                    e.Row.Cells[3].Visible = true;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}