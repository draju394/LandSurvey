using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using LandSurvey.DAL;

namespace LandSurvey.DAL
{
    public class dbClient : dbConnection
    {
        DataSet ds = new DataSet();
        public int clientid { get; set; }
        public string clientname { get; set; }

        public DataSet getClientName()
        {
            try
            {
                ds = FillData("select clientid, clientname from clientmaster", "clientmaster");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].NewRow();
                    row["clientname"] = "Please Select Client";
                    ds.Tables[0].Rows.InsertAt(row, 0);
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