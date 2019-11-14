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
    public class dbDocumentMaster : dbConnection
    {
        DataSet ds = new DataSet();
        public int documentid { get; set; }
        public string documentcode { get; set; }
        public string documentename { get; set; }
        public string documentmname { get; set; }
        //public string createdby { get; set; }
        //public string createddate { get; set; }

        public DataSet getDocumentData()
        {
            try
            {
                ds = FillData("select row_number() over() as srno, t.* from (select documentid ,documentcode, documentename,documentmname from documentmaster order by documentcode desc ) t", "DocumentMaster");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public string getDocumentSeqNo()
        {
            string DocumentSeqNo = null;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;

                cmd.CommandText = "select nextval ('documentseqno')";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                try
                {
                    conReader = cmd.ExecuteReader();
                    while (conReader.Read())
                    {
                        DocumentSeqNo = Convert.ToString(conReader.GetValue(0));
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

                return DocumentSeqNo;
            }
        }

        public bool AddDocument()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;
                cmd.CommandText = "Insert into documentmaster (documentid,documentcode,documentename,documentmname)" +
                                   " Values(@documentid,@documentcode,@documentename,@documentmname)";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@documentid", NpgsqlDbType.Integer).Value = documentid;
                cmd.Parameters.Add("@documentcode", NpgsqlDbType.Text).Value = documentcode;
                cmd.Parameters.Add("@documentename", NpgsqlDbType.Text).Value = documentename;
                cmd.Parameters.Add("@documentmname", NpgsqlDbType.Text).Value = documentmname;
                //cmd.Parameters.Add("@CREATEDBY", NpgsqlDbType.Text).Value = createdby;
                //cmd.Parameters.Add("@CREATEDDATE", NpgsqlDbType.Text).Value = createddate;
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

        public bool EditDocument()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;
                cmd.CommandText = "update documentmaster set documentcode=@documentcode,documentename=@documentename,documentmname=@documentmname where documentid =@documentid";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@documentid", NpgsqlDbType.Integer).Value = documentid;
                cmd.Parameters.Add("@documentcode", NpgsqlDbType.Text).Value = documentcode;
                cmd.Parameters.Add("@documentename", NpgsqlDbType.Text).Value = documentename;
                cmd.Parameters.Add("@documentmname", NpgsqlDbType.Text).Value = documentmname;
                //cmd.Parameters.Add("@CREATEDBY", NpgsqlDbType.Text).Value = createdby;
                //cmd.Parameters.Add("@CREATEDDATE", NpgsqlDbType.Text).Value = createddate;
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

        public bool DeleteDocument()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;
                cmd.CommandText = "delete from documentmaster where documentid =@documentid";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@documentid", NpgsqlDbType.Integer).Value = documentid;
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

    }
}