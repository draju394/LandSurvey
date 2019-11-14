using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandSurvey.DAL
{
    public class familyMaster
    {
        public int familymasterid { get; set; }
        public string familyno { get; set; }
        public int villageid { get; set; }
        public double totalarea { get; set; }
        public string status { get; set; }
        public string villagecode { get; set; }

    }
}