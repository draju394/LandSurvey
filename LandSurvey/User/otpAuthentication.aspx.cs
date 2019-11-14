using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LandSurvey.DAL;

namespace LandSurvey.User
{
    public partial class otpAuthentication : System.Web.UI.Page
    {
        dbUser dbUserData = new dbUser();
        CommonFunction fnCommon = new CommonFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Session["UserName"]
                if (Session["UserName"] != null)
                {
                    //logOut.Visible = true;
                    //userName.Text = "Welcome " + Session["userFullName"];
                    ////Session.Clear();
                    //// Session.RemoveAll();
                    ///
                    //Get Mobile Name and send OTP First 
                    dbUserData.UserName = Session["UserName"].ToString();
                    string MobileNo = dbUserData.GetMobileNo();
                    if(string.IsNullOrEmpty(MobileNo))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Mobile Number Not available for this Login, Please contact administrator');", true);
                      //  Response.Redirect("~/UserLogin.aspx");
                    }
                    else
                    {
                        //Generate OTP
                        string UserOTP = fnCommon.GenratedOTP();
                        //Insert into Table;
                        Session["UserOTP"] = UserOTP;
                        string MobileMessage = "Thank you for logging in iParkPMC. Your verification code is " + UserOTP;
                        fnCommon.sendsms("+91" + MobileNo, MobileMessage);
                        lblMobile.Text = MobileNo;
                        lblUser.Text = Session["UserName"].ToString();
                    }
                }
            }
        }

        protected void btnSubmitUser_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtOTP.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter OTP recieved on your register mobile');", true);
            }
            else
            {
                string SessionOTP = "";
                SessionOTP = Session["UserOTP"].ToString();
                if (txtOTP.Text == SessionOTP)
                {
                    if (Session["UserRole"].ToString() == "5")
                    { Response.Redirect("~/User/ClientIndex"); }

                    if (Session["UserRole"].ToString() == "6")
                    { Response.Redirect("~/User/AccountsIndex"); }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter Valid OTP');", true);
                }

            }
        }



        //
    }
}