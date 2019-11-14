using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using LandSurvey.DAL;


namespace LandSurvey.DAL
{
    public class dbFileDetails : dbConnection
    {
        DataSet ds = new DataSet();
        public int FileNo { get; set; }
        public string FileName { get; set; }

        public string getFileNo(string varFileName)
        {
            string dbFileNo = null;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;

                cmd.CommandText = "select currentno from fileno where registername = '" + varFileName +"' ";
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


        //
    }
}