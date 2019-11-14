using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using NpgsqlTypes;
using LandSurvey.DAL;
using System.Data;

namespace LandSurvey.DAL
{
    public class dbTaluka : dbConnection
    {
        DataSet ds = new DataSet();
        public int talukaid { get; set; }
        public string talukacode { get; set; }
        public string talukaname { get; set; }
        public string talukafullname { get; set; }
        public int districtid { get; set; }
        public string talukamname { get; set; }

        public DataSet getTalukaDataOnDistrict(int districtid)
        {
            try
            {
                ds = FillData("select talukaid, talukamname from taluka where districtid =  " + districtid + "  ", "taluka");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    //DataRow row = ds.Tables[0].NewRow();
                    //row["talukamname"] = "Please Select Taluka";
                    //ds.Tables[0].Rows.InsertAt(row, 0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        ///
    }
}