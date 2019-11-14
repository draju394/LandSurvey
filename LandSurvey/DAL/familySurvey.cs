using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandSurvey.DAL
{
    public class familySurvey
    {
        public int familysurveyid { get; set; }
        public string villagecode { get; set; }
        public string familyno { get; set; }
        public string surveyno { get; set; }
        public string oldsurveyno { get; set; }
        public double surveyrate { get; set; }
        public double surveyarea { get; set; }
    }
}