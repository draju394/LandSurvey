using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace LandSurvey
{
    public partial class SiteMaster : MasterPage
    {
        public int UserType;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.Page.User.Identity.IsAuthenticated)
            //{
            //    //FormsAuthentication.RedirectToLoginPage();
            //}

            if (Session["userFullName"] != null)
            {
                logOut.Visible = true;
                userName.Text = "Welcome " + Session["userFullName"];
                //Session.Clear();
               // Session.RemoveAll();
            }

            


            // UserName.Text = "Welcome " + Session["userFullName"];

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

        public Label userName
        {
            get
            {
                return this.lblUser;
            }
        }

        public LinkButton logOut
        {
            get
            {
                return this.linkLogOut;
            }
        }
        //
    }
}