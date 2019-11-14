using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LandSurvey.DAL;
using System.Data;
using Npgsql;
using NpgsqlTypes;

namespace LandSurvey.DAL
{
    public class dbFamilySurvey :dbConnection
    {
        DataSet ds = new DataSet();
        public int familysurveyid { get; set; }
        public string villagecode { get; set; }
        public string familyno { get; set; }
        public string surveyno { get; set; }
        public string oldsurveyno { get; set; }
        public double surveyrate { get; set; }
        public double surveyarea { get; set; }
        public string documentno { get; set; }

        public DataSet getFamilySurveyCmb(string VillageCode, string DocNo)
        {
            try
            {
                ds = FillData("select DISTINCT(surveyno) from familydetails where docno = '" + DocNo + "' and villagecode = '" + VillageCode + "' ", "familymaster");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].NewRow();
                    row["surveyno"] = "Please Select Survey No";
                    ds.Tables[0].Rows.InsertAt(row, 0);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getFamilySurveyCmbNew(string VillageCode, string DocNo)
        {
            try
            {
                ds = FillData("select DISTINCT(surveyno) from familydetails where docno = '" + DocNo + "' and villagecode = '" + VillageCode + "' ", "familymaster");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].NewRow();
                    row["surveyno"] = "Please Select Survey No";
                    ds.Tables[0].Rows.InsertAt(row, 0);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getSurveyArea( String VillageCode, string FamilyNo, string SurveyNo)
        {
            try
            {
                ds = FillData("select surveyarea, surveyrate from familysurvey where familyno = '" + FamilyNo + "' and "+
                              "villagecode = '" + VillageCode + "' and surveyno = '" + SurveyNo + "'", "familysurvey");
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

        public bool UpdateFamilySurvey()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;

                cmd.CommandText = " update familysurvey set documentno = @DOCUMENTNO "+
                                  " where villagecode = @VILLAGECODE and familyno = @FAMILYNO and surveyno = @SURVEYNO ";

                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@DOCUMENTNO", NpgsqlDbType.Text).Value = documentno;
                cmd.Parameters.Add("@VILLAGECODE", NpgsqlDbType.Text).Value = villagecode;
                cmd.Parameters.Add("@FAMILYNO", NpgsqlDbType.Text).Value = familyno;
                cmd.Parameters.Add("@SURVEYNO", NpgsqlDbType.Text).Value = surveyno;
                


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
                    throw new ApplicationException("Something wrong happened in the Family Survey Module :", ex);
                }
                finally
                {
                    conReader.Close();
                    closeConnection();
                }
            }

            return _PValid;
        }


        //
    }
}