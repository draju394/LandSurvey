using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace LandSurvey
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        //{
        //    if (HttpContext.Current.User != null)
        //    {
        //        if (HttpContext.Current.User.Identity.IsAuthenticated)
        //        {
        //            if (HttpContext.Current.User.Identity is FormsIdentity)
        //            {
        //                FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
        //                FormsAuthenticationTicket ticket = id.Ticket;
        //                string userData = ticket.UserData;
        //                string[] roles = userData.Split(',');
        //                HttpContext.Current.User = new GenericPrincipal(id, roles);
        //            }
        //        }
        //    }
        //}
        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started  
            if (Session["UserName"] != null)
            {
                //Redirect to Welcome Page if Session is not null  
                //Response.Redirect("Welcome.aspx");

            }
            else
            {
                //Redirect to Login Page if Session is null & Expires   
                Response.Redirect("~/UserLogin.aspx");

            }


        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends.   
            // Note: The Session_End event is raised only when the sessionstate mode  
            // is set to InProc in the Web.config file. If session mode is set to StateServer   
            // or SQLServer, the event is not raised.  

        }
    }
}