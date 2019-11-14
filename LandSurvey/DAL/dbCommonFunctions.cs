using System.Web;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using LandSurvey.DAL;
using System.Web.UI.WebControls;

namespace LandSurvey.DAL
{
    public class dbCommonFunctions : dbConnection
    {
        public void Binddropdown(DataTable dt,ref DropDownList dropdownlist, string dataTextField, string dataValueField)
        {
                dropdownlist.DataSource = dt;
                dropdownlist.DataTextField = dataTextField;
                dropdownlist.DataValueField = dataValueField;
                dropdownlist.DataBind();
                dropdownlist.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
}