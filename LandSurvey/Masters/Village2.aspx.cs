using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LandSurvey.DAL;
using System.Data;

namespace LandSurvey.Masters
{
    public partial class Village2 : System.Web.UI.Page
    {
        DataSet dsVillageMaster = new DataSet();
        dbVillage dbVillageData = new dbVillage();
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool boolAddVillage = false;
            string SeqVillageID = dbVillageData.getVillageSeqNo();
            dbVillageData.villageid = Convert.ToInt32(SeqVillageID.ToString());
            dbVillageData.villagecode = txtVillageCode.Text;
            dbVillageData.villagename = txtVillageName.Text;
            dbVillageData.villagemname = txtVIllageMarathiName.Text;
            boolAddVillage = dbVillageData.AddVillage();
            if (boolAddVillage)
            {
                
            }
            else
            {

            }
        }
    }
}