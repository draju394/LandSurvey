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
    public class dbInwardOutwardReg : dbConnection
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public int ionumber { get; set; }
        public string receiveddocumentcode { get; set; }
        public string receivedfrom { get; set; }
        public string receiveddocremark { get; set; }
        public string receivedby { get; set; }
        public string inwardno { get; set; }
        public string inwarddate { get; set; }
        public string inwardsection { get; set; }
        public string sentdocumentcode { get; set; }
        public string sentto { get; set; }
        public string sentdocremark { get; set; }
        public string sentby { get; set; }
        public string outwardno { get; set; }
        public string outwarddate { get; set; }
        public string outwardsection { get; set; }
        public string outwardmode { get; set; }
        public string villagecode { get; set; }
        //public string createdby { get; set; }
        //public string createddate { get; set; }

        public DataSet getInOutWardRegData()
        {
            try
            {
                ds = FillData("select row_number() over() as srno, t.* from(select ionumber, receiveddocumentcode, receivedfrom, receiveddocremark, receivedby, inwardno, inwarddate::date, " +
                                "inwardsection,sentdocumentcode, sentto, sentdocremark, sentby, outwardno, outwarddate::date, outwardsection, outwardmode, villagemname from tblinwardoutwardreg IO " +
                                    "join village V on IO.villagecode = V.villagecode order by ionumber desc) t", "Inwardoutwardreg");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetDocumentMaster()
        {
            try
            {
                ds = FillData("select documentcode, documentmname from documentmaster ", "DocumentMaster");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetVillageMaster()
        {
            try
            {
                ds = FillData("select villagecode, villagemname from village order by villagecode ", "VillagMaster");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public string getInwardOutwardSeqNo()
        {
            string IOSeqNo = null;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;

                cmd.CommandText = "select nextval ('inwardoutwardseqno')";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                try
                {
                    conReader = cmd.ExecuteReader();
                    while (conReader.Read())
                    {
                        IOSeqNo = Convert.ToString(conReader.GetValue(0));
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

                return IOSeqNo;
            }
        }

        public bool AddInwardOutwardReg()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;
                cmd.CommandText = "Insert into tblinwardoutwardreg (ionumber,receiveddocumentcode,receivedfrom,receiveddocremark,receivedby,inwardno,inwarddate,inwardsection,sentdocumentcode,sentto,sentdocremark,sentby,outwardno,outwarddate,outwardsection,outwardmode,villagecode)" +
                                    "Values(@ionumber,@receiveddocumentcode,@receivedfrom,@receiveddocremark,@receivedby,@inwardno,@inwarddate,@inwardsection,@sentdocumentcode,@sentto,@sentdocremark,@sentby,@outwardno,@outwarddate,@outwardsection,@outwardmode,@villagecode)";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@ionumber", NpgsqlDbType.Integer).Value = ionumber;
                cmd.Parameters.Add("@receiveddocumentcode", NpgsqlDbType.Text).Value = receiveddocumentcode;
                cmd.Parameters.Add("@receivedfrom", NpgsqlDbType.Text).Value = receivedfrom;
                cmd.Parameters.Add("@receiveddocremark", NpgsqlDbType.Text).Value = receiveddocremark;
                cmd.Parameters.Add("@receivedby", NpgsqlDbType.Text).Value = receivedby;
                cmd.Parameters.Add("@inwardno", NpgsqlDbType.Text).Value = inwardno;
                cmd.Parameters.Add("@inwarddate", NpgsqlDbType.Text).Value = inwarddate;
                cmd.Parameters.Add("@inwardsection", NpgsqlDbType.Text).Value = inwardsection;
                cmd.Parameters.Add("@sentdocumentcode", NpgsqlDbType.Text).Value = sentdocumentcode;
                cmd.Parameters.Add("@sentto", NpgsqlDbType.Text).Value = sentto;
                cmd.Parameters.Add("@sentdocremark", NpgsqlDbType.Text).Value = sentdocremark;
                cmd.Parameters.Add("@sentby", NpgsqlDbType.Text).Value = sentby;
                cmd.Parameters.Add("@outwardno", NpgsqlDbType.Text).Value = outwardno;
                cmd.Parameters.Add("@outwarddate", NpgsqlDbType.Text).Value = outwarddate;
                cmd.Parameters.Add("@outwardsection", NpgsqlDbType.Text).Value = outwardsection;
                cmd.Parameters.Add("@outwardmode", NpgsqlDbType.Text).Value = outwardmode;
                cmd.Parameters.Add("@villagecode", NpgsqlDbType.Text).Value = villagecode;
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

        public bool EditInwardOutwardReg()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;
                cmd.CommandText = "Update tblinwardoutwardreg set receiveddocumentcode=@receiveddocumentcode,receivedfrom=@receivedfrom,receiveddocremark=@receiveddocremark,receivedby=@receivedby,inwardno=@inwardno,inwarddate=@inwarddate," +
                                    "inwardsection=@inwardsection,sentdocumentcode=@sentdocumentcode,sentto=@sentto,sentdocremark=@sentdocremark,sentby=@sentby,outwardno=@outwardno,outwarddate=@outwarddate,outwardsection=@outwardsection," +
                                    "outwardmode=@outwardmode,villagecode=@villagecode where ionumber=@ionumber";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@ionumber", NpgsqlDbType.Integer).Value = ionumber;
                cmd.Parameters.Add("@receiveddocumentcode", NpgsqlDbType.Text).Value = receiveddocumentcode;
                cmd.Parameters.Add("@receivedfrom", NpgsqlDbType.Text).Value = receivedfrom;
                cmd.Parameters.Add("@receiveddocremark", NpgsqlDbType.Text).Value = receiveddocremark;
                cmd.Parameters.Add("@receivedby", NpgsqlDbType.Text).Value = receivedby;
                cmd.Parameters.Add("@inwardno", NpgsqlDbType.Text).Value = inwardno;
                cmd.Parameters.Add("@inwarddate", NpgsqlDbType.Text).Value = inwarddate;
                cmd.Parameters.Add("@inwardsection", NpgsqlDbType.Text).Value = inwardsection;
                cmd.Parameters.Add("@sentdocumentcode", NpgsqlDbType.Text).Value = sentdocumentcode;
                cmd.Parameters.Add("@sentto", NpgsqlDbType.Text).Value = sentto;
                cmd.Parameters.Add("@sentdocremark", NpgsqlDbType.Text).Value = sentdocremark;
                cmd.Parameters.Add("@sentby", NpgsqlDbType.Text).Value = sentby;
                cmd.Parameters.Add("@outwardno", NpgsqlDbType.Text).Value = outwardno;
                cmd.Parameters.Add("@outwarddate", NpgsqlDbType.Text).Value = outwarddate;
                cmd.Parameters.Add("@outwardsection", NpgsqlDbType.Text).Value = outwardsection;
                cmd.Parameters.Add("@outwardmode", NpgsqlDbType.Text).Value = outwardmode;
                cmd.Parameters.Add("@villagecode", NpgsqlDbType.Text).Value = villagecode;
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

        public bool DeleteInwardOutwardReg()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;
                cmd.CommandText = "delete from tblinwardoutwardreg where ionumber =@ionumber";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@ionumber", NpgsqlDbType.Integer).Value = ionumber;
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

        public DataSet getInOutWardRegDataForReport()
        {
            try
            {
                ds = FillData("select ionumber, receiveddocumentcode, receivedfrom, receiveddocremark, receivedby, inwardno, inwarddate::date, " +
                                "inwardsection,sentdocumentcode, sentto, sentdocremark, sentby, outwardno, outwarddate::date, outwardsection, outwardmode, villagename from tblinwardoutwardreg IO " +
                                    "join village V on IO.villagecode = V.villagecode", "Inwardoutwardreg");
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