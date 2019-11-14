using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;

namespace LandSurvey
{
    public partial class _Default : Page
    {
        public int UserType;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["userFullName"] != null)
            //{
            //    Master.logOut.Visible = true;
            //    Master.userName.Text = "Welcom " + Session["userFullName"];
            //    Session.Clear();
            //    Session.RemoveAll();
            //}
            //if (!this.Page.User.Identity.IsAuthenticated)
            //{
            //    FormsAuthentication.RedirectToLoginPage();
            //}
        }

        protected int IsAdmin
        {

            get
            {
                UserType = Convert.ToInt32(Session["UserRole"].ToString());
                //if (UserRole == 2)
                //{
                return this.UserType;
                //}

            }
            set
            {
                int UserRole = Convert.ToInt32(Session["UserRole"].ToString());
                if (UserRole == 2)
                {
                    this.UserType = value;
                }
            }
        }
        //
    }
}