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
    public class dbPurchaser : dbConnection
    {
        DataSet ds = new DataSet();
        public int purchaserid { get; set; }
        public string purchasername { get; set; }

        public DataSet getPurchaserName()
        {
            try
            {
                ds = FillData("select purchaserid, purchasername from purchasermaster", "purchasermaster");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].NewRow();
                    row["purchasername"] = "Please Select Purchaser";
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