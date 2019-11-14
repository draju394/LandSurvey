using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LandSurvey.DAL;
using System.Web.Services;
using System.IO;

namespace LandSurvey.TitleSearch
{
    public partial class TitleSearch : System.Web.UI.Page
    {
        DataSet dsDistrict = new DataSet();
        dbDistrict dbDistrictData = new dbDistrict();

        DataSet dsTaluka = new DataSet();
        dbTaluka dbTalukaData = new dbTaluka();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Get All List Data 
                //Get District Data for Combo
                dsDistrict = dbDistrictData.getDistrictData();
                if (dsDistrict.Tables[0].Rows.Count > 0)
                {
                    //cmbDistrict.DataSource = dsDistrict.Tables[0].DefaultView;
                    //cmbDistrict.DataBind();
                    //cmbDistrict.DataTextField = dsDistrict.Tables[0].Columns["districtmname"].ToString();
                    //cmbDistrict.DataValueField = dsDistrict.Tables[0].Columns["districtid"].ToString();
                    //cmbDistrict.DataBind();


                }

                DataTable dt = new DataTable();
                
                grdHolderHo.DataSource = dt;
                grdHolderHo.DataBind();

                
            }
            else
            {


            }
        }

        protected void btnMutation_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUploadControl.FileName);
                    FileUploadControl.SaveAs(Server.MapPath("~/") + filename);
                    StatusLabel.Text = "Upload status: File uploaded!";
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }

        [WebMethod]
        public static string GetCurrentTime()
        {
            return "Hello "  + Environment.NewLine + "The Current Time is: "
                + DateTime.Now.ToString();

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUploadControl.FileName);
                    FileUploadControl.SaveAs(Server.MapPath("~/") + filename);
                    StatusLabel.Text = "Upload status: File uploaded!";
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }

        protected void btnRemark0_Click(object sender, EventArgs e)
        {

        }
        //protected void cmbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    cmbTaluka.Items.Clear();
        //    int selectedDistrict = Convert.ToInt32(cmbDistrict.SelectedItem.Value.ToString().Trim());
        //    dsTaluka = dbTalukaData.getTalukaDataOnDistrict(selectedDistrict);
        //    if (dsTaluka.Tables[0].Rows.Count > 0)
        //    {
        //        cmbTaluka.DataSource = dsTaluka.Tables[0].DefaultView;
        //        cmbTaluka.DataBind();
        //        cmbTaluka.DataTextField = dsTaluka.Tables[0].Columns["talukamname"].ToString();
        //        cmbTaluka.DataValueField = dsTaluka.Tables[0].Columns["talukaid"].ToString();
        //        cmbTaluka.DataBind();


        //    }
        //}


        //
    }
}