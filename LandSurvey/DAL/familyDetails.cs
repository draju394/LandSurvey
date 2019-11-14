using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandSurvey.DAL
{
    public class familyDetails
    {
        public int familydetailid { get; set; }
        public int familyid { get; set; }
        public string surveyno { get; set; }
        public double surveyarea { get; set; }
        public double surveyrate { get; set; }
        public double areaaquired { get; set; }
        public string holdername { get; set; }
        public double holderarea { get; set; }
        public string familyno { get; set; }
        public int villagecode { get; set; }
        

    }
}