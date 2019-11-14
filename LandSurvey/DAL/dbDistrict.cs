using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using NpgsqlTypes;
using System.Data;

namespace LandSurvey.DAL
{
    public class dbDistrict : dbConnection
    {
        DataSet ds = new DataSet();
        public int districtid { get; set; }
        public string districtcode { get; set; }
        public string districtname { get; set; }
        public string districtfullname { get; set; }
        public string districtmname { get; set; }

        public DataSet getDistrictData()
        {
            try
            {
                ds = FillData("select districtid, districtmname from district ", "district");
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

        ///
    }
}