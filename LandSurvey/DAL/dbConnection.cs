using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Configuration;

namespace LandSurvey.DAL
{
    public abstract class dbConnection
    {
        public NpgsqlConnection conn;
        public NpgsqlTransaction transaction;

        public dbConnection()
        {
            //Old Connection
            // conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=admin;Database=OTSHMS;");
            //New Connection
            string connectionString = ConfigurationManager.ConnectionStrings["LANDSURVEY"].ConnectionString;
            conn = new NpgsqlConnection(connectionString);

        }

        public class reportParam
        {
            string strServer = ConfigurationManager.AppSettings["ServerName"].ToString();
            string strDatabase = ConfigurationManager.AppSettings["DataBaseName"].ToString();
            string strUserId = ConfigurationManager.AppSettings["UserId"].ToString();
            string strPassword = ConfigurationManager.AppSettings["Password"].ToString();
            // return(strServer, strDatabase,strUserId,strPassword);

        }
        public void openConnection()
        {
            conn.Close();
            conn.Open();
            transaction = conn.BeginTransaction();
        }

        public void closeConnection()
        {
            transaction.Commit();
            conn.Close();
        }

        public void errorTransaction()
        {
            transaction.Rollback();
            conn.Close();
        }

        protected NpgsqlDataReader setDataReader(string sSQL)
        {

            NpgsqlCommand cmd = new NpgsqlCommand(sSQL, conn, transaction);
            cmd.CommandTimeout = 300;
            NpgsqlDataReader rtnReader;
            rtnReader = cmd.ExecuteReader();
            return rtnReader;
        }

        protected void ExecuteSQL(string sSQL)
        {

            NpgsqlCommand cmdDate = new NpgsqlCommand(" SET DATEFORMAT dmy", conn, transaction);
            cmdDate.ExecuteNonQuery();
            NpgsqlCommand cmd = new NpgsqlCommand(sSQL, conn, transaction);
            cmd.ExecuteNonQuery();
        }

        protected DataSet FillData(string sSQL, string sTable)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(sSQL, conn, transaction);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, sTable);
            return ds;
        }

        protected DataSet SequenceNo(string sSQL, string sTable)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(sSQL, conn, transaction);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, sTable);
            return ds;
        }
        //
    }
}