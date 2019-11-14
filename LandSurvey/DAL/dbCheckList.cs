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
    public class dbCheckList : dbConnection
    {
        //RSD Created 26/08
        DataSet ds = new DataSet();
        public int chklistno { get; set; }
        public string chkname { get; set; }
        public string status { get; set; }
        public string createdby { get; set; }
        public DateTime createddate { get; set; }
        public string modifiedby { get; set; }
        public DateTime modifieddate { get; set; }

        public string getCheckListSeqNo()
        {
            string CheckListSeqNo = null;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;

                cmd.CommandText = "select nextval ('checklistseq')";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                try
                {
                    conReader = cmd.ExecuteReader();
                    while (conReader.Read())
                    {
                        CheckListSeqNo = Convert.ToString(conReader.GetValue(0));
                    }

                }
                catch (Exception ex)
                {
                    errorTransaction();
                    throw new ApplicationException("Something wrong happened in the Check List Module :", ex);
                }
                finally
                {
                    conReader.Close();
                    closeConnection();
                }

                return CheckListSeqNo;
            }
        }

        public DataSet getCheckListData()
        {
            try
            {
                ds = FillData("select row_number() over() as srno, t.* from (select chklistno, chkname, status" +
                   " from checklistmaster order by chklistno) t ", "checklistmaster");
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

        public bool AddCheckListMaster()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;
                cmd.CommandText = "Insert into checklistmaster (chklistno,chkname,status,createdby,createddate)" +
                                   " Values(@CHKLISTNO,@CHKNAME,@STATUS,@CREATEDBY,@CREATEDDATE)";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@CHKLISTNO", NpgsqlDbType.Integer).Value = chklistno;
                cmd.Parameters.Add("@CHKNAME", NpgsqlDbType.Text).Value = chkname;
                cmd.Parameters.Add("@STATUS", NpgsqlDbType.Text).Value = status;
                cmd.Parameters.Add("@CREATEDBY", NpgsqlDbType.Text).Value = createdby;
                cmd.Parameters.Add("@CREATEDDATE", NpgsqlDbType.Date).Value = createddate;
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
                    throw new ApplicationException("Something wrong happened in the Check List Add Module :", ex);
                }
                finally
                {
                    conReader.Close();
                    closeConnection();
                }
            }

            return _PValid;
        }

        public bool UpdateCheckList()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;

                cmd.CommandText = " update checklistmaster set chkname = @CHKNAME, status = @STATUS, modifiedby = @MODIFIEDBY,  " +
                                    " modifieddate = @MODIFIEDDATE where chklistno = @CHECKLISTNO ";

                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@CHKNAME", NpgsqlDbType.Text).Value = chkname;
                cmd.Parameters.Add("@STATUS", NpgsqlDbType.Text).Value = status;
                cmd.Parameters.Add("@MODIFIEDBY", NpgsqlDbType.Text).Value = modifiedby;
                cmd.Parameters.Add("@MODIFIEDDATE", NpgsqlDbType.Date).Value = modifieddate;
                cmd.Parameters.Add("@CHECKLISTNO", NpgsqlDbType.Integer).Value = chklistno;
              
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
                    throw new ApplicationException("Something wrong happened in the CheckList Module :", ex);
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