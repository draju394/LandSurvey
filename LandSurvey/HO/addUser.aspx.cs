using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandSurvey.HO
{
    public partial class addUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               // this.username.Value = "";
                
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}