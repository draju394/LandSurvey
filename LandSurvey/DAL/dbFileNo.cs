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
    public class dbFileNo:dbConnection 
    {
        DataSet ds = new DataSet();
        public int currentno { get; set; }
        public string registername { get; set; }

        public string getFileNo(string varFileName)
        {
            string dbFileNo = null;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;

                cmd.CommandText = "select currentno from fileno where registername = '" + varFileName + "' ";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                try
                {
                    conReader = cmd.ExecuteReader();
                    while (conReader.Read())
                    {
                        dbFileNo = Convert.ToString(conReader.GetValue(0));
                    }

                }
                catch (Exception ex)
                {
                    errorTransaction();
                    throw new ApplicationException("Something wrong happened in the System Module :", ex);
                }
                finally
                {
                    conReader.Close();
                    closeConnection();
                }

                return dbFileNo;
            }
        }

        public bool UpdateFileNo()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;
                cmd.CommandText = "Update fileno set currentno= @CUREENTNO where registername = @REGISTERNAME";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@CUREENTNO", NpgsqlDbType.Integer).Value = currentno;
                cmd.Parameters.Add("@REGISTERNAME", NpgsqlDbType.Text).Value = registername;
                
                try
                {
                    conReader = cmd.ExecuteReader();

                    while (conReader.Read())
                    {
                
                        _PValid = true;
                    }
                }
                catch (Exception ex)
                {

                    errorTransaction();
                    throw new ApplicationException("Something wrong happened in the File Module :", ex);
                }
                finally
                {
                    conReader.Close();
                    closeConnection();
                }
            }

            return _PValid;
        }

        public bool UpdateFileNoNew()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;
                cmd.CommandText = "Update fileno set currentno= currentno + 1 where registername = @REGISTERNAME";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
              //  cmd.Parameters.Add("@CUREENTNO", NpgsqlDbType.Integer).Value = currentno;
                cmd.Parameters.Add("@REGISTERNAME", NpgsqlDbType.Text).Value = registername;

                try
                {
                    conReader = cmd.ExecuteReader();

                    while (conReader.Read())
                    {

                        _PValid = true;
                    }
                }
                catch (Exception ex)
                {

                    errorTransaction();
                    throw new ApplicationException("Something wrong happened in the File Module :", ex);
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