using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandSurvey.DAL
{
    /// <summary>
    /// Summary description for gridHandler
    /// </summary>
    public class gridHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}