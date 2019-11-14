using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using LandSurvey.DAL;

namespace LandSurvey.DAL
{
    public class dbVillage : dbConnection
    {
        DataSet ds = new DataSet();
        public int villageid { get; set; }
        public string villagecode { get; set; }
        public string villagename { get; set; }
        public string villagemname { get; set; }
        public string createdby { get; set; }
        public string createddate { get; set; }

        public string getVillageSeqNo()
        {
            string VillageSeqNo = null;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;

                cmd.CommandText = "select nextval ('villageseqno')";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                try
                {
                    conReader = cmd.ExecuteReader();
                    while (conReader.Read())
                    {
                        VillageSeqNo = Convert.ToString(conReader.GetValue(0));
                    }

                }
                catch (Exception ex)
                {
                    errorTransaction();
                    throw new ApplicationException("Something wrong happened in the Village Module :", ex);
                }
                finally
                {
                    conReader.Close();
                    closeConnection();
                }

                return VillageSeqNo;
            }
        }

        public bool AddVillage()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;
                cmd.CommandText = "Insert into village (villageid,villagecode,villagename,villagemname,createdby,createddate)" +
                                   " Values(@VILLAGEID,@VILLAGECODE,@VILLAGENAME,@VILLAGEMNAME,@CREATEDBY,@CREATEDDATE)";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@VILLAGEID", NpgsqlDbType.Integer).Value = villageid;
                cmd.Parameters.Add("@VILLAGECODE", NpgsqlDbType.Text).Value = villagecode;
                cmd.Parameters.Add("@VILLAGENAME", NpgsqlDbType.Text).Value = villagename;
                cmd.Parameters.Add("@VILLAGEMNAME", NpgsqlDbType.Text).Value = villagemname;
                cmd.Parameters.Add("@CREATEDBY", NpgsqlDbType.Text).Value = createdby;
                cmd.Parameters.Add("@CREATEDDATE", NpgsqlDbType.Text).Value = createddate;
                try
                {
                    conReader = cmd.ExecuteReader();

                    while (conReader.Read())
                    {
                        // LoginID = Convert.ToInt32(conReader["userid"]);
                        // LogType = Convert.ToInt32(conReader["type"]);
                        //LogType = (bool)conReader["type"];
                        _PValid = true;
                    }
                }
                catch (Exception ex)
                {

                    errorTransaction();
                    throw new ApplicationException("Something wrong happened in the Department Add Module :", ex);
                }
                finally
                {
                    conReader.Close();
                    closeConnection();
                }
            }

            return _PValid;
        }

        public DataSet getVillageData()
        {
            try
            {
                ds = FillData("select row_number() over() as srno, t.* from (select villageid, villagecode, villagename, villagemname " +
                   " from village order by villageid desc ) t ", "village");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].NewRow();
                    row["villagename"] = "Please Select Village Name";
                    ds.Tables[0].Rows.InsertAt(row, 0);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getVillageName()
        {
            try
            {
                ds = FillData("select villageid, villagecode, villagename, villagemname " +
                   " from village order by villageid desc ", "village");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].NewRow();
                    row["villagemname"] = "Please Select Villiage Name";
                    ds.Tables[0].Rows.InsertAt(row, 0);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getAllVillageData()
        {
            try
            {
                ds = FillData("select villageid, villagecode, villagename, villagemname " +
                   " from village order by villageid desc ", "village");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //DataRow row = ds.Tables[0].NewRow();
                    //row["villagemname"] = "Please Select Villiage Name";
                    //ds.Tables[0].Rows.InsertAt(row, 0);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public string getVillageNameMarathi(string VillageCode)
        {
            string VillageMarathiName = null;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;

                //cmd.CommandText = "select familyno from familydetails where docno= '" + DocNo + "' group by familyno";
                cmd.CommandText = " select villagemname from village where villagecode = '" + VillageCode + "' ";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                try
                {
                    conReader = cmd.ExecuteReader();
                    while (conReader.Read())
                    {
                        VillageMarathiName = Convert.ToString(conReader.GetValue(0));
                    }

                }
                catch (Exception ex)
                {
                    errorTransaction();
                    throw new ApplicationException("Something wrong happened in the Vilage Module :", ex);
                }
                finally
                {
                    conReader.Close();
                    closeConnection();
                }

                return VillageMarathiName;
            }
        }
        //
    }
    
}