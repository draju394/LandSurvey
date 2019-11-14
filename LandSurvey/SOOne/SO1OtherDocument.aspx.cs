using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandSurvey.SOOne
{
    public partial class SO1OtherDocument : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string VillageCode = Server.UrlDecode(Request.QueryString["Village"]);
            string DocNo = Server.UrlDecode(Request.QueryString["Doc"]);
            lblVillageCode.Text = VillageCode;
        }
    }
}