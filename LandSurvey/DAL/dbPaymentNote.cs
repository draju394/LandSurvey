using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LandSurvey.DAL;
using Npgsql;
using NpgsqlTypes;
using System.Data;

namespace LandSurvey.DAL
{
    public class dbPaymentNote : dbConnection
    {
        DataSet ds = new DataSet();
        public int paymentnoteid { get; set; }
        public string villagecode { get; set; }
        public string documentno { get; set; }
        public string seriesno { get; set; }
        public string phaseno { get; set; }
        public string demandno { get; set; }
        public DateTime demanddate { get; set; }
        public double docarea { get; set; }
        public double tokenamt { get; set; }
        public double regcharges { get; set; }
        public double processcharges { get; set; }
        public double stampduty { get; set; }
        public double misccharges { get; set; }
        public double totaldemand { get; set; }
        public string demandsent { get; set; }
        public DateTime demandsentdate { get; set; }
        public string demandapprove { get; set; }
        public DateTime demandapprovedate { get; set; }
        public string officename { get; set; }
        public string createdby { get; set; }
        public DateTime createddate { get; set; }
        public string demandnote { get; set; }

        public string getPaymentNoteSeqNo()
        {
            string DocumentSeqNo = null;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;

                cmd.CommandText = "select nextval ('paymentnoteseqno')";
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
                    throw new ApplicationException("Something wrong happened in the Payment Module :", ex);
                }
                finally
                {
                    conReader.Close();
                    closeConnection();
                }

                return DocumentSeqNo;
            }
        }

        public bool AddPaymentNote()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;
                cmd.CommandText = "Insert into paymentnote (paymentnoteid,villagecode,documentno,seriesno,phaseno,demandno," +
                                   " demanddate, docarea, tokenamt, regcharges,processcharges,stampduty,misccharges, " +
                                   " totaldemand,officename,createdby,createddate, demandnote)" +
                                   " Values(@PYMENTNOTEID,@VILLAGECODE,@DOCUMENTNO,@SERIESNO,@PHASENO, @DEMANDNO," +
                                   " @DEMANDDATE, @DOCAREA, @TOKENAMT,@RECHARGEAMT,@PROCESSCHARGE,@STAMPDUTY,@MISCCHARGES, " +
                                   " @TOTALDEMAND,@OFIICENAME,@CREADTEDBY,@CREATEDDATE,@DEMANDNOTE)";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@PYMENTNOTEID", NpgsqlDbType.Integer).Value = paymentnoteid;
                cmd.Parameters.Add("@VILLAGECODE", NpgsqlDbType.Text).Value = villagecode;
                cmd.Parameters.Add("@DOCUMENTNO", NpgsqlDbType.Text).Value = documentno;
                cmd.Parameters.Add("@SERIESNO", NpgsqlDbType.Text).Value = seriesno;
                cmd.Parameters.Add("@PHASENO", NpgsqlDbType.Text).Value = phaseno;
                cmd.Parameters.Add("@DEMANDNO", NpgsqlDbType.Text).Value = demandno;
                cmd.Parameters.Add("@DEMANDDATE", NpgsqlDbType.Date).Value = demanddate;
                cmd.Parameters.Add("@DOCAREA", NpgsqlDbType.Double).Value = docarea;
                cmd.Parameters.Add("@TOKENAMT", NpgsqlDbType.Double).Value = tokenamt;
                cmd.Parameters.Add("@RECHARGEAMT", NpgsqlDbType.Double).Value = regcharges;
                cmd.Parameters.Add("@PROCESSCHARGE", NpgsqlDbType.Double).Value = processcharges;
                cmd.Parameters.Add("@STAMPDUTY", NpgsqlDbType.Double).Value = stampduty;
                cmd.Parameters.Add("@MISCCHARGES", NpgsqlDbType.Double).Value = misccharges;
                cmd.Parameters.Add("@TOTALDEMAND", NpgsqlDbType.Double).Value = totaldemand;
                cmd.Parameters.Add("@OFIICENAME", NpgsqlDbType.Text).Value = officename;
                cmd.Parameters.Add("@CREADTEDBY", NpgsqlDbType.Text).Value = createdby;
                cmd.Parameters.Add("@CREATEDDATE", NpgsqlDbType.Date).Value = createddate;
                cmd.Parameters.Add("@DEMANDNOTE", NpgsqlDbType.Text).Value = demandnote;
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
                    throw new ApplicationException("Something wrong happened in the Payment NOte Add Module :", ex);
                }
                finally
                {
                    conReader.Close();
                    closeConnection();
                }
            }

            return _PValid;
        }


        public DataSet getAllPaymentNotes()
        {
            try
            {
                ds = FillData("select row_number() over() as srno, t.* from(select paymentnoteid,demandnote, to_char(demanddate,'dd-mm-yyyy')as demanddate , v.villagename as villagecode, documentno, seriesno, phaseno, totaldemand, " +
                    " case when demandsent is null then  'No' else 'Yes' end as demandsent, " +
                    " case when demandapprove is null then 'No' else 'Yes' end as demandapprove from paymentnote, village v where paymentnote.villagecode = v.villagecode) t order by demanddate desc ", "paymentnote");

               // select demandno, demanddate, villagecode, documentno, seriesno, phaseno, totaldemand, demandsent, demandapprove  from paymentnote
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

        public bool UpdatePaymentNoteClient()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;

                cmd.CommandText = " update paymentnote set demandapprove = @DEMANDAPPROVE, demandapprovedate = @DEMANDAPPROVEDATE" +
                                    " where paymentnoteid = @PAYMENTNOTEID";

                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@DEMANDAPPROVE", NpgsqlDbType.Text).Value = demandapprove;
                cmd.Parameters.Add("@PAYMENTNOTEID", NpgsqlDbType.Integer).Value = paymentnoteid;
                cmd.Parameters.Add("@DEMANDAPPROVEDATE", NpgsqlDbType.Date).Value = demandapprovedate;
               

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
                    throw new ApplicationException("Something wrong happened in the Payment Note Module :", ex);
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