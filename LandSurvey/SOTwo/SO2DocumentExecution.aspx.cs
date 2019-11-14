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
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace LandSurvey.SOTwo
{
    public partial class SO2DocumentExecution : System.Web.UI.Page
    {
        DataSet dsVillage = new DataSet();
        dbVillage dbVillageData = new dbVillage();

        DataSet dsFamilyDocNoNew = new DataSet();
        dbFamilyDetails dbFamilyDetailsData = new dbFamilyDetails();

        DataSet dsShowAllDocData = new DataSet();

        string mbno, mseg, ckuser, ckpass;
        private HttpWebRequest req;
        private CookieContainer cookieCntr;
        private string strNewValue;
        public static string responseee;
        private HttpWebResponse response;
        string lblError;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                dsVillage = dbVillageData.getVillageName();
                if (dsVillage.Tables[0].Rows.Count > 0)
                {
                    cmbVillage.DataSource = dsVillage.Tables[0].DefaultView;
                    cmbVillage.DataBind();
                    cmbVillage.DataTextField = dsVillage.Tables[0].Columns["villagemname"].ToString();
                    cmbVillage.DataValueField = dsVillage.Tables[0].Columns["villagecode"].ToString();
                    cmbVillage.DataBind();
                    //Upload1.Enabled = false;

                }
                else
                {
                    DataTable dt = new DataTable();
                    grdFamilyDocDetails.DataSource = dt;
                    grdFamilyDocDetails.DataBind();

                }
            }
        }

        protected void cmbVillage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVillage.SelectedIndex == -1)
            {

            }
            else
            {
                cmbDocumentNo.Items.Clear();
                string selectedVillage = cmbVillage.SelectedValue.ToString().Trim();
                dsFamilyDocNoNew = dbFamilyDetailsData.getDocumnentNoTitleSearch(selectedVillage);
                if (dsFamilyDocNoNew.Tables[0].Rows.Count > 0)
                {
                    cmbDocumentNo.DataSource = dsFamilyDocNoNew.Tables[0].DefaultView;
                    cmbDocumentNo.DataBind();
                    cmbDocumentNo.DataTextField = dsFamilyDocNoNew.Tables[0].Columns["docno"].ToString();
                    cmbDocumentNo.DataValueField = dsFamilyDocNoNew.Tables[0].Columns["docno"].ToString();
                    cmbDocumentNo.DataBind();
                }
            }
        }

        protected void grdFamilyDocDetails_ServerPdfExporting(object sender, Syncfusion.JavaScript.Web.GridEventArgs e)
        {

        }

        protected void cmbDocumentNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDocumentNo.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Document Number ');", true);
            }
            else
            {
                string strFamilyNo = dbFamilyDetailsData.getFamilyNoOnDocNo(cmbDocumentNo.SelectedValue.ToString().Trim());

                ShowAllDocumentData();
            }
        }

        protected void ShowAllDocumentData()
        {
            if (cmbVillage.SelectedIndex > 0 & cmbDocumentNo.SelectedIndex > 0)
            {

                dsShowAllDocData = dbFamilyDetailsData.getDocumentExecution(cmbVillage.SelectedValue.ToString(), cmbDocumentNo.SelectedValue.ToString());
                if (dsShowAllDocData.Tables[0].Rows.Count > 0)
                {
                    DataTable FamilyDocDetails = dsShowAllDocData.Tables[0];
                    grdFamilyDocDetails.DataSource = FamilyDocDetails;
                    grdFamilyDocDetails.DataBind();

                }
                else
                {
                    grdFamilyDocDetails.DataSource = null;
                    grdFamilyDocDetails.DataBind();

                }
            }

        }

        protected void btnRegistrationSearch_Click(object sender, EventArgs e)
        {
            //string yourmobilenumber = "9890037859";
            //string yourpassword = "rajendra$123";
            //string body = "Hi All";
            //string recipientNo = "9403180206";
            //HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("http://ubaid.tk/sms/sms.aspx?uid=" + yourmobilenumber + "&pwd=" + yourpassword + "&msg=" + body + "&phone=" + recipientNo + "&provider=way2sms");
            //HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            //System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            //string responseString = respStreamReader.ReadToEnd();
            //respStreamReader.Close();
            //myResp.Close();

            try
            {
                //Session["id"] = txtuname.Text;
                //Session["pw"] = txtpwd.Text;
                mbno = "9403180206";
                mseg = "Hi All";

                connect();
                sendSms(mbno, mseg);
                //txttono.Text = "";
                //txtmsg.Text = "";
            }
            catch (Exception ex)
            {
                //lblError.Text = ex.Message;
                //lblError.Visible = true;
            }
        }

        public void connect()
        {
            //ckuser = Session["id"].ToString();
            //ckpass = Session["pw"].ToString();

            ckuser = "9890037859";
            ckpass = "rajendra$123";

            try
            {
                this.req = (HttpWebRequest)WebRequest.Create("http://wwwd.way2sms.com/auth.cl");

                this.req.CookieContainer = new CookieContainer();
                this.req.AllowAutoRedirect = false;
                this.req.Method = "POST";
                this.req.ContentType = "application/x-www-form-urlencoded";
                this.strNewValue = "username=" + ckuser + "&password=" + ckpass;
                this.req.ContentLength = this.strNewValue.Length;
                StreamWriter writer = new StreamWriter(this.req.GetRequestStream(), Encoding.ASCII);
                writer.Write(this.strNewValue);                writer.Close();
                this.response = (HttpWebResponse)this.req.GetResponse();
                this.cookieCntr = this.req.CookieContainer;
                this.response.Close();
                this.req = (HttpWebRequest)WebRequest.Create("http://wwwd.way2sms.com//jsp/InstantSMS.jsp?val=0");
                this.req.CookieContainer = this.cookieCntr;
                this.req.Method = "GET";
                this.response = (HttpWebResponse)this.req.GetResponse();
                responseee = new StreamReader(this.response.GetResponseStream()).ReadToEnd();
                int index = Regex.Match(responseee, "custf").Index;
                responseee = responseee.Substring(index, 0x12);
                responseee = responseee.Replace("\"", "").Replace(">", "").Trim();
                this.response.Close();
                lblError = "connected";
            }
            catch (Exception)
            {
                lblError= "Error connecting to the server...";
                Session["error"] = "Error connecting to the server...";
            }
        }

        public void sendSms(string mbno, string mseg)
        {
            if ((mbno != "") && (mseg != ""))
            {
                try
                {
                    this.req = (HttpWebRequest)WebRequest.Create("http://wwwd.way2sms.com//FirstServletsms?custid=");
                    this.req.AllowAutoRedirect = false;
                    this.req.CookieContainer = this.cookieCntr;
                    this.req.Method = "POST";
                    this.req.ContentType = "application/x-www-form-urlencoded";
                    this.strNewValue = "custid=undefined&HiddenAction=instantsms&Action=" + responseee + "&login=&pass=&MobNo=" + this.mbno + "&textArea=" + this.mseg;

                    string msg = this.mseg;
                    string mbeno = this.mbno;

                    this.req.ContentLength = this.strNewValue.Length;
                    StreamWriter writer = new StreamWriter(this.req.GetRequestStream(), Encoding.ASCII);
                    writer.Write(this.strNewValue);
                    writer.Close();
                    this.response = (HttpWebResponse)this.req.GetResponse();

                    this.response.Close();
                    lblError = "Message Sent..... " + mbeno + ": " + msg;
                }
                catch (Exception)
                {
                    lblError = "Error Sending msg....check your connection...";
                }
            }
            else
            {
                lblError = "Mob no or msg missing";
            }
        }
        //
    }
}