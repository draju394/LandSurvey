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
    public partial class login : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        dbUser LogUser = new dbUser();
        bool LoginOk = false;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LogUser.UserName = txtUserName.Text.Trim();
            LogUser.Password = txtPassword.Text.Trim();
            LoginOk = LogUser.ValidRegLogUser();
            if (LoginOk)
            {
                Console.Write("asasa");
                Console.WriteLine("Login Sucess");
                Response.Redirect("../Contact.aspx");
            }
        }
    }
}