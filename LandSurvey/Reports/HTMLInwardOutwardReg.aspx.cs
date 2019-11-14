using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LandSurvey.DAL;
using System.Data;
using System.Text;
using System.Globalization;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf.parser;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;
using System.Globalization;
using System.IO;


namespace LandSurvey.Reports
{
    public partial class HTMLInwardOutwardReg : System.Web.UI.Page
    {
        DataSet dsInOutWardReg = new DataSet();
        dbInwardOutwardReg dbInOutWardReg = new dbInwardOutwardReg();


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                dsInOutWardReg = dbInOutWardReg.getInOutWardRegDataForReport();
                Response.Write(createhtml());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public StringBuilder createhtml()
        {
            try
            {
                StringBuilder sb = new StringBuilder();      
                sb.Append("<body>");
                sb.Append("<br/><br/>");
                sb.Append("<table border='0' width='100%' height='10%' cellspacing='0' cellpadding='0'>");
                sb.Append("<tr>");
                sb.Append("<td width='100%' align='right' valign='top' colspan='2'>" + DateTime.Now.ToString("dd/MM/yyyy"));
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td width='100%'  valign='top' align='center' colspan='2'>");
                sb.Append("<p align='center'><font size='4'><b>Inward Outward Registration</b>");
                sb.Append("</font></td><br/><br/>");
                sb.Append("</tr>");
                sb.Append("</table>");
                sb.Append("<table border='1' width='100%' cellspacing='0' cellpadding='0'>");
                sb.Append("<tr>");
                sb.Append("<td width='4%' valign='top' align='center' colspan='2'>");
                sb.Append("Io No.</td>");
                sb.Append("<td width='6%' valign='top' colspan='2'>");
                sb.Append("Received Document Type</td>");
                sb.Append("<td width='6%' valign='top' colspan='2'>");
                sb.Append("Received From</td>");
                sb.Append("<td width='6%' valign='top' colspan='2'>");
                sb.Append("Received Remark</td>");
                sb.Append("<td width='6%' valign='top' colspan='2'>");
                sb.Append("Received By</td>");
                sb.Append("<td width='6%' valign='top' colspan='2'>");
                sb.Append("Inward No</td>");
                sb.Append("<td width='6%' valign='top' colspan='2'>");
                sb.Append("Inward Date</td>");
                sb.Append("<td width='6%' valign='top' colspan='2'>");
                sb.Append("Inward Section</td>");
                sb.Append("<td width='6%' valign='top' colspan='2'>");
                sb.Append("sent Document Type</td>");
                sb.Append("<td width='6%' valign='top' colspan='2'>");
                sb.Append("Sent To</td>");
                sb.Append("<td width='6%' valign='top' colspan='2'>");
                sb.Append("Sent Remark</td>");
                sb.Append("<td width='6%' valign='top' colspan='2'>");
                sb.Append("Sent By</td>");
                sb.Append("<td width='6%' valign='top' colspan='2'>");
                sb.Append("Outward No</td>");
                sb.Append("<td width='6%' valign='top' colspan='2'>");
                sb.Append("Outward Date</td>");
                sb.Append("<td width='6%' valign='top' colspan='2'>");
                sb.Append("Outward Section</td>");
                sb.Append("<td width='6%' valign='top' colspan='2'>");
                sb.Append("Outward Mode</td>");
                sb.Append("<td width='6%' valign='top' colspan='2'>");
                sb.Append("Village Name</td>");
                sb.Append("</tr>");
                if (dsInOutWardReg.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsInOutWardReg.Tables[0].Rows)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td width='4%' valign='top' align='left' colspan='2'>&nbsp;");
                        sb.Append(dr["ionumber"].ToString() + "</td>");     
                        sb.Append("<td width='6%' valign='top' align='left' colspan='2'>&nbsp;&nbsp;");
                        sb.Append(dr["receiveddocumentcode"].ToString() + "</td>");
                        sb.Append("<td width='6%' valign='top' align='left' colspan='2'>&nbsp;&nbsp;");
                        sb.Append(dr["receivedfrom"].ToString() + "</td>");
                        sb.Append("<td width='6%' valign='top' align='left' colspan='2'>&nbsp;&nbsp;");
                        sb.Append(dr["receiveddocremark"].ToString() + "</td>");
                        sb.Append("<td width='6%' valign='top' align='left' colspan='2'>&nbsp;");
                        sb.Append(dr["receivedby"].ToString() + "</td>");
                        sb.Append("<td width='6%' valign='top' align='left' colspan='2'>&nbsp;&nbsp;");
                        sb.Append(dr["inwardno"].ToString() + "</td>");
                        sb.Append("<td width='6%' valign='top' align='left' colspan='2'>&nbsp;&nbsp;");
                        sb.Append(dr["inwarddate"].ToString() + "</td>");
                        sb.Append("<td width='6%' valign='top' align='left' colspan='2'>&nbsp;&nbsp;");
                        sb.Append(dr["inwardsection"].ToString() + "</td>");
                        sb.Append("<td width='6%' valign='top' align='left' colspan='2'>&nbsp;&nbsp;");
                        sb.Append(dr["sentdocumentcode"].ToString() + "</td>");
                        sb.Append("<td width='6%' valign='top' align='left' colspan='2'>&nbsp;&nbsp;");
                        sb.Append(dr["sentto"].ToString() + "</td>");
                        sb.Append("<td width='6%' valign='top' align='left' colspan='2'>&nbsp;&nbsp;");
                        sb.Append(dr["sentdocremark"].ToString() + "</td>");
                        sb.Append("<td width='6%' valign='top' align='left' colspan='2'>&nbsp;");
                        sb.Append(dr["sentby"].ToString() + "</td>");
                        sb.Append("<td width='6%' valign='top' align='left' colspan='2'>&nbsp;&nbsp;");
                        sb.Append(dr["outwardno"].ToString() + "</td>");
                        sb.Append("<td width='6%' valign='top' align='left' colspan='2'>&nbsp;&nbsp;");
                        sb.Append(dr["outwarddate"].ToString() + "</td>");
                        sb.Append("<td width='6%' valign='top' align='left' colspan='2'>&nbsp;&nbsp;");
                        sb.Append(dr["outwardsection"].ToString() + "</td>");
                        sb.Append("<td width='6%' valign='top' align='left' colspan='2'>&nbsp;&nbsp;");
                        sb.Append(dr["outwardmode"].ToString() + "</td>");
                        sb.Append("<td width='6%' valign='top' align='left' colspan='2'>&nbsp;&nbsp;");
                        sb.Append(dr["villagename"].ToString() + "</td>");
                        sb.Append("</tr>");
                    }
                }
                else
                {
                    sb.Append("<tr>");
                    sb.Append("<td width='4%' valign='top' colspan='2'>");
                    sb.Append(" &nbsp;</td>");
                    sb.Append("<td width='6%' valign='top' colspan='2'>");
                    sb.Append("&nbsp;</td>");
                    sb.Append("<td width='6%' valign='top' colspan='2'>");
                    sb.Append("&nbsp;</td>");
                    sb.Append("<td width='6%' valign='top' colspan='2'>");
                    sb.Append("&nbsp;</td>");
                    sb.Append("<td width='6%' valign='top' colspan='2'>");
                    sb.Append("&nbsp;</td>");
                    sb.Append("<td width='6%' valign='top' colspan='2'>");
                    sb.Append("&nbsp;</td>");
                    sb.Append("<td width='6%' valign='top' colspan='2'>");
                    sb.Append("&nbsp;</td>");
                    sb.Append("<td width='6%' valign='top' colspan='2'>");
                    sb.Append("&nbsp;</td>");
                    sb.Append("<td width='6%' valign='top' colspan='2'>");
                    sb.Append("&nbsp;</td>");
                    sb.Append("<td width='6%' valign='top' colspan='2'>");
                    sb.Append("&nbsp;</td>");
                    sb.Append("<td width='6%' valign='top' colspan='2'>");
                    sb.Append("&nbsp;</td>");
                    sb.Append("<td width='6%' valign='top' colspan='2'>");
                    sb.Append("&nbsp;</td>");
                    sb.Append("<td width='6%' valign='top' colspan='2'>");
                    sb.Append("&nbsp;</td>");
                    sb.Append("<td width='6%' valign='top' colspan='2'>");
                    sb.Append("&nbsp;</td>");
                    sb.Append("<td width='6%' valign='top' colspan='2'>");
                    sb.Append("&nbsp;</td>");
                    sb.Append("<td width='6%' valign='top' colspan='2'>");
                    sb.Append("&nbsp;</td>");
                    sb.Append("<td width='6%' valign='top' colspan='2'>");
                    sb.Append("&nbsp;</td>");
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                return sb;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void createPDF()
        {
            try
            {
                StringWriter sw = new StringWriter();
                HtmlTextWriter hTextWriter = new HtmlTextWriter(sw);
                Document document = new Document();
                MemoryStream ms = new MemoryStream();
                string html = sw.ToString();
                string htmlDisplayText = Convert.ToString(createhtml());
                PdfWriter writer = PdfWriter.GetInstance(document, ms);
                StringReader se = new StringReader(htmlDisplayText);
                HTMLWorker obj = new HTMLWorker(document);
                document.Open();
                obj.Parse(se);
                document.Close();
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment; filename=Inwardoutwardreg.pdf");
                Response.ContentType = "application/pdf";
                Response.Buffer = true;
                Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
                Response.OutputStream.Flush();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Masters/frmInwardOutwardReg.aspx", false);
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        protected void btnExportToPDF_Click(object sender, EventArgs e)
        {
            createPDF();
        }

        protected void ExportToExcel()
        {
            try
            {
                string attachment = "attachment; filename=Inwardoutwardreg.xls";
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/vnd.ms-excel";
                string tab = "";
                foreach (DataColumn dc in dsInOutWardReg.Tables[0].Columns)
                {
                    Response.Write(tab + dc.ColumnName);
                    tab = "\t";
                }
                Response.Write("\n");
                int i;
                foreach (DataRow dr in dsInOutWardReg.Tables[0].Rows)
                {
                    tab = "";
                    for (i = 0; i < dsInOutWardReg.Tables[0].Columns.Count; i++)
                    {
                        Response.Write(tab + dr[i].ToString());
                        tab = "\t";
                    }
                    Response.Write("\n");
                }
                Response.End();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}