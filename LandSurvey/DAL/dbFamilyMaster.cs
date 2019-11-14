using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LandSurvey.DAL;
using System.Data;

namespace LandSurvey.DAL
{
    public class dbFamilyMaster :dbConnection
    {
        DataSet ds = new DataSet();
        public int familymasterid { get; set; }
        public string familyno { get; set; }
        public int villageid { get; set; }
        public double totalarea { get; set; }
        public string status { get; set; }
        public string villagecode { get; set; }

        public DataSet getFamilyMasterCmb(string VillageCode)
        {
            try
            {
                ds = FillData("select familyno, totalarea, status from familymaster where villagecode = '" + VillageCode +"'  ", "familymaster");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].NewRow();
                    row["familyno"] = "Please Select Family No";
                    ds.Tables[0].Rows.InsertAt(row, 0);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getFamilyAreaStatus(string FamilyNo, String VillageCode)
        {
            try
            {
                ds = FillData("select totalarea, status from familymaster where familyno = '" + FamilyNo + "' and villagecode = '" + VillageCode + "'  ", "familymaster");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        //
    }
}