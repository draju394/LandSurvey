using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandSurvey.DAL
{
    public class VIllage
    {
        public int villageid { get; set; }
        public string villagecode { get; set; }
        public string villagename { get; set; }
        public string villagemname { get; set; }
        public string createdby { get; set; }
        public string createddate { get; set; }
    }
}