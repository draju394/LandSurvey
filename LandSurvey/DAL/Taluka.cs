using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandSurvey.DAL
{
    public class Taluka
    {
        public int talukaid { get; set; }
        public string talukacode { get; set; }
        public string talukaname { get; set; }
        public string talukafullname { get; set; }
        public int districtid { get; set; }
        public string talukamname { get; set; }
    }
}