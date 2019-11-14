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
    public class dbFinalData : dbConnection
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public string villagecode { get; set; }
        public decimal totalvillagearea { get; set; }
        public decimal proposedareaacq { get; set; }
        public string denno { get; set; }
        public decimal atsareaacq { get; set; }
        public decimal rsdareaacq { get; set; }
        public decimal totalareaacq { get; set; }
        public decimal tempatsarea { get; set; }
        public decimal temprsdarea { get; set; }
        public decimal balanceareaacq { get; set; }

        public DataSet getFinalData()
        {
            try
            {
                ds = FillData("select row_number() over() as srno, t.* from(select M.villagecode, villagemname, totalvillagearea, proposedareaacq, denno, atsareaacq, rsdareaacq, totalareaacq, tempatsarea, temprsdarea, balanceareaacq from tblfinaldata M join village V on M.villagecode = V.villagecode) t", "FinalData");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public bool AddFinalData()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;
                cmd.CommandText = "Insert into tblfinaldata (villagecode,totalvillagearea,proposedareaacq,denno,atsareaacq,rsdareaacq,totalareaacq,tempatsarea,temprsdarea,balanceareaacq)" +
                                    "Values(@villagecode,@totalvillagearea,@proposedareaacq,@denno,@atsareaacq,@rsdareaacq,@totalareaacq,@tempatsarea,@temprsdarea,@balanceareaacq)";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@villagecode", NpgsqlDbType.Text).Value = villagecode;
                cmd.Parameters.Add("@totalvillagearea", NpgsqlDbType.Text).Value = totalvillagearea;
                cmd.Parameters.Add("@proposedareaacq", NpgsqlDbType.Text).Value = proposedareaacq;
                cmd.Parameters.Add("@denno", NpgsqlDbType.Text).Value = denno;
                cmd.Parameters.Add("@atsareaacq", NpgsqlDbType.Text).Value = atsareaacq;
                cmd.Parameters.Add("@rsdareaacq", NpgsqlDbType.Text).Value = rsdareaacq;
                cmd.Parameters.Add("@totalareaacq", NpgsqlDbType.Text).Value = totalareaacq;
                cmd.Parameters.Add("@tempatsarea", NpgsqlDbType.Text).Value = tempatsarea;
                cmd.Parameters.Add("@temprsdarea", NpgsqlDbType.Text).Value = temprsdarea;
                cmd.Parameters.Add("@balanceareaacq", NpgsqlDbType.Text).Value = balanceareaacq;
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

        public bool EditFinalData()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;
                cmd.CommandText = "Update tblfinaldata set villagecode=@villagecode,totalvillagearea=@totalvillagearea,proposedareaacq=@proposedareaacq,denno=@denno,atsareaacq=@atsareaacq,rsdareaacq=@rsdareaacq,totalareaacq=@totalareaacq,tempatsarea=@tempatsarea,temprsdarea=@temprsdarea,balanceareaacq=@balanceareaacq where villagecode=@villagecode";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@villagecode", NpgsqlDbType.Text).Value = villagecode;
                cmd.Parameters.Add("@totalvillagearea", NpgsqlDbType.Text).Value = totalvillagearea;
                cmd.Parameters.Add("@proposedareaacq", NpgsqlDbType.Text).Value = proposedareaacq;
                cmd.Parameters.Add("@denno", NpgsqlDbType.Text).Value = denno;
                cmd.Parameters.Add("@atsareaacq", NpgsqlDbType.Text).Value = atsareaacq;
                cmd.Parameters.Add("@rsdareaacq", NpgsqlDbType.Text).Value = rsdareaacq;
                cmd.Parameters.Add("@totalareaacq", NpgsqlDbType.Text).Value = totalareaacq;
                cmd.Parameters.Add("@tempatsarea", NpgsqlDbType.Text).Value = tempatsarea;
                cmd.Parameters.Add("@temprsdarea", NpgsqlDbType.Text).Value = temprsdarea;
                cmd.Parameters.Add("@balanceareaacq", NpgsqlDbType.Text).Value = balanceareaacq;
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

        public bool DeleteFinalData()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;
                cmd.CommandText = "delete from tblfinaldata where villagecode=@villagecode";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@villagecode", NpgsqlDbType.Text).Value = villagecode;
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
                ds = FillData("", "FinalDataForReport");
            }
            catch (Exception)
            {

                throw;
            }
            return ds;
        }

        public DataSet GetReportDataForAllVillages()
        {
            try
            {
                ds = FillData("", "FinalDataForReport");
            }
            catch (Exception)
            {

                throw;
            }
            return ds;
        }
    }
}