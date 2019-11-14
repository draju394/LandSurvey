using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandSurvey.TitleSearch
{
    public partial class wordFileOpen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // frmDoc.Attributes.Add("src", "http://localhost/docs/test.doc");
           // frmDoc.Attributes.Add("src", "F:/DatarSirWork/LandSurvey/LandSurvey/LandSurvey/Docs/test1.docx");
            frmDoc.Attributes.Add("src", "http://localhost:19568/Docs/test1.docx");

        }
    }
}