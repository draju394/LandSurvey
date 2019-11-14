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
    public class dbMutationFinal : dbConnection
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public string villagecode { get; set; }
        public string mutationno { get; set; }
        public string mutationdate { get; set; }
        public string surveyno { get; set; }
        public string remarks { get; set; }
        public string mutationorderrec { get; set; }
        public string mutated712rec { get; set; }


        public DataSet getMutationFinalData()
        {
            try
            {
                ds = FillData("select row_number() over() as srno, t.* from(select M.villagecode, villagemname, mutationno, mutationdate, surveyno, remarks, mutationorderrec, mutated712rec from tblmutationfinal M join village V on M.villagecode = V.villagecode) t", "MutationFinal");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public bool AddMutationFinalData()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;
                cmd.CommandText = "Insert into tblmutationfinal (villagecode,mutationno,mutationdate,surveyno,remarks,mutationorderrec,mutated712rec)" +
                                    "Values(@villagecode,@mutationno,@mutationdate,@surveyno,@remarks,@mutationorderrec,@mutated712rec)";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@villagecode", NpgsqlDbType.Text).Value = villagecode;
                cmd.Parameters.Add("@mutationno", NpgsqlDbType.Text).Value = mutationno;
                cmd.Parameters.Add("@mutationdate", NpgsqlDbType.Text).Value = mutationdate;
                cmd.Parameters.Add("@surveyno", NpgsqlDbType.Text).Value = surveyno;
                cmd.Parameters.Add("@remarks", NpgsqlDbType.Text).Value = remarks;
                cmd.Parameters.Add("@mutationorderrec", NpgsqlDbType.Text).Value = mutationorderrec;
                cmd.Parameters.Add("@mutated712rec", NpgsqlDbType.Text).Value = mutated712rec;
                try
                {
                    conReader = cmd.ExecuteReader();

                    while (conReader.Read())
                    {
                        //LoginID = Convert.ToInt32(conReader["userid"]);
                        //LogType = Convert.ToInt32(conReader["type"]);
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

        public bool EditMutationFinalData()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;
                cmd.CommandText = "Update tblmutationfinal set villagecode=@villagecode,mutationno=@mutationno,mutationdate=@mutationdate,surveyno=@surveyno,remarks=@remarks,mutationorderrec=@mutationorderrec,mutated712rec=@mutated712rec where villagecode=@villagecode and mutationno=@mutationno";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@villagecode", NpgsqlDbType.Text).Value = villagecode;
                cmd.Parameters.Add("@mutationno", NpgsqlDbType.Text).Value = mutationno;
                cmd.Parameters.Add("@mutationdate", NpgsqlDbType.Text).Value = mutationdate;
                cmd.Parameters.Add("@surveyno", NpgsqlDbType.Text).Value = surveyno;
                cmd.Parameters.Add("@remarks", NpgsqlDbType.Text).Value = remarks;
                cmd.Parameters.Add("@mutationorderrec", NpgsqlDbType.Text).Value = mutationorderrec;
                cmd.Parameters.Add("@mutated712rec", NpgsqlDbType.Text).Value = mutated712rec;
                try
                {
                    conReader = cmd.ExecuteReader();

                    while (conReader.Read())
                    {
                        //LoginID = Convert.ToInt32(conReader["userid"]);
                        //LogType = Convert.ToInt32(conReader["type"]);
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

        public bool DeleteMutationFinalData()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;
                cmd.CommandText = "delete from tblmutationfinal where villagecode=@villagecode and mutationno=@mutationno";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@villagecode", NpgsqlDbType.Text).Value = villagecode;
                cmd.Parameters.Add("@mutationno", NpgsqlDbType.Text).Value = mutationno;
                try
                {
                    conReader = cmd.ExecuteReader();

                    while (conReader.Read())
                    {
                        //LoginID = Convert.ToInt32(conReader["userid"]);
                        //LogType = Convert.ToInt32(conReader["type"]);
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

        public DataSet GetReportDataForVillageCode(string villagecode)
        {
            try
            {
                ds = FillData("select  mutationno, mutationdate, surveyno, remarks, mutationorderrec, mutated712rec from tblmutationfinal where villagecode='"+ villagecode + "' order by mutationno","MutationFinalDataForReport");
            }
            catch (Exception)
            {

                throw;
            }
            return ds;
        }

    }
}