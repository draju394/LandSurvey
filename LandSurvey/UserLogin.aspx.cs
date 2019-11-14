using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LandSurvey.DAL;
using System.Web.Security;

namespace LandSurvey
{
    public partial class UserLogin : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        DataSet dsSysParam = new DataSet();
        dbUser LogUser = new dbUser();
        bool LoginOk = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //if (this.Page.User.Identity.IsAuthenticated)
                //{
                //    FormsAuthentication.SignOut();
                //    Response.Redirect("~/UserLogin.aspx");
                //}
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUserName.Text))
            {
                //MessageBox.Show("Please Enter Valid User Name OR Password");
                //cleartext();
            }
            else if (String.IsNullOrEmpty(txtPassword.Text) || txtPassword.MaxLength < 5)
            {
                //MessageBox.Show("Please Enter Valid User Name OR Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //cleartext();
            }

            LogUser.UserName = txtUserName.Text.Trim();
            LogUser.Password = txtPassword.Text.Trim();
            LoginOk = LogUser.ValidRegLogUser();

            if (LoginOk)
            {
                dsSysParam = LogUser.SysParam();
                string strOTPStatus = "";
                if(dsSysParam.Tables[0].Rows.Count > 0)
                {
                    strOTPStatus = dsSysParam.Tables[0].Rows[0]["otpstatus"].ToString();
                }
                //Check First time login 
                Session["userFullName"] = LogUser.UserFname;
                Session["UserRole"] = LogUser.LogType;
                Session["UserName"] = LogUser.UserName;
                //Program.UserName = LogUser.UserName;
                //Program.LoginID = LogUser.LoginID;
                //Program.LogType = LogUser.LogType;
                //Program.UserFname = LogUser.UserFname;
                int userLastCcn = LogUser.ULastCSN;
                if (userLastCcn > 0)
                {
                    if (LogUser.LogType == 1)
                    {

                       // FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, true);
                        Response.Redirect("~/User/HoIndex.aspx");
                    }
                    else if(LogUser.LogType ==2)
                    {
                        // FormsAuthentication.RedirectFromLoginPage(txtUserName.Text,true);
                        //Response.Redirect("~/User/SOIndex.aspx");
                        Response.Redirect("~/User/SOIndex.aspx");
                    }
                    else if(LogUser.LogType == 3)
                    {
                        Response.Redirect("~/User/SOIndex2");
                    }
                    else if(LogUser.LogType == 4)
                    {
                        Response.Redirect("~/User/SolicitorIndex");
                    }
                    else if(LogUser.LogType == 5)
                    {
                        if(strOTPStatus == "Y")
                        {
                            Response.Redirect("~/User/otpAuthentication");
                           
                        }
                        else
                        {
                            Response.Redirect("~/User/ClientIndex");
                        }
                       
                        
                    }
                    else if (LogUser.LogType == 6)
                    {
                        if(strOTPStatus == "Y")
                        {
                            Response.Redirect("~/User/otpAuthentication");
                        }
                        else
                        {
                            Response.Redirect("~/User/AccountsIndex");
                        }
                        
                       
                    }
                }
                else
                {

                     }
            }
            else
            {
                //MessageBox.Show("Please check username and password", "Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter valid User Name and Password');", true);
            }
        }
    }
}