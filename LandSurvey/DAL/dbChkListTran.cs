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
    public class dbChkListTran : dbConnection
    {
        DataSet ds = new DataSet();
        public int chklisttranno { get; set; }
        public string chklistname { get; set; }
        public string documentno { get; set; }
        public string siteofficereamrk { get; set; }
        public string headofficeremark { get; set; }
        public string villagecode { get; set; }
        public string familyno { get; set; }
        public string docno { get; set; }
        public int chklstno { get; set; }
        public string officename { get; set; }

        public DataSet getChkListTran(string VillageCode, string DocNo)
        {
            try
            {
                //SELECT checklistmaster.chkname, siteofficereamrk, headofficeremark FROM checklistmaster LEFT JOIN chklisttran ON chklisttran.chklstno = checklistmaster.chklistno;

                ds = FillData("select row_number() over() as srno, t.* from(select chklistno,chkname, siteofficereamrk, headofficeremark from checklistmaster " +
                                " LEFT JOIN chklisttran ON chklisttran.chklstno = checklistmaster.chklistno" +
                                " and villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' order by chklisttranno) t ", "chklisttran");
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

        public bool UpdateChkListTranHO()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;

                cmd.CommandText = " update chklisttran set headofficeremark = @HOREMARK " +
                                    " where chklstno = @CHKLISTMASTERID ";

                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@HOREMARK", NpgsqlDbType.Text).Value = headofficeremark;
                cmd.Parameters.Add("@CHKLISTMASTERID", NpgsqlDbType.Integer).Value = chklstno;


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
                    throw new ApplicationException("Something wrong happened in the Check List Module :", ex);
                }
                finally
                {
                    conReader.Close();
                    closeConnection();
                }
            }

            return _PValid;
        }

        public bool CheckRecordExist(string VillageCode, string DocNo, int MCheckListNo, string OfficeName)
        {
            bool _PValid = false;
            ds = FillData("select * from chklisttran where villagecode = '" + VillageCode + "'  " +
                  " and chklstno = " + MCheckListNo + "  and docno = '" + DocNo + "' and officename = '" + OfficeName + "' ", "chklisttran");
            if (ds.Tables[0].Rows.Count > 0)
            {
                _PValid = true;
            }

            return _PValid;
        }

        public bool UpdateChkListTranSO()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;

                cmd.CommandText = " update chklisttran set siteofficereamrk = @SOREMARK " +
                                    " where chklstno = @CHKLISTTRANID and villagecode =@VILLAGECODE and docno = @DOCNO  and officename = @OFFICENAME ";

                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@SOREMARK", NpgsqlDbType.Text).Value = siteofficereamrk;
                cmd.Parameters.Add("@CHKLISTTRANID", NpgsqlDbType.Integer).Value = chklisttranno;
                cmd.Parameters.Add("@VILLAGECODE", NpgsqlDbType.Text).Value = villagecode;
                cmd.Parameters.Add("@DOCNO", NpgsqlDbType.Text).Value = docno;
                cmd.Parameters.Add("@OFFICENAME", NpgsqlDbType.Text).Value = officename;



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
                    throw new ApplicationException("Something wrong happened in the Check List Module :", ex);
                }
                finally
                {
                    conReader.Close();
                    closeConnection();
                }
            }

            return _PValid;
        }

        public bool AddCheckListTranSO()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;
                cmd.CommandText = "Insert into chklisttran (chklisttranno,chklistname,siteofficereamrk,villagecode,familyno," +
                                   " docno, chklstno, officename)" +
                                   " Values(@CHKLISTTRANNO,@CHKLISTNAME,@SITEOFFICEREMARK,@VILLAGECODE,@FAMILYNO, " +
                                   " @DOCNO, @CHKLISTNO,@OFFICENAME )";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@CHKLISTTRANNO", NpgsqlDbType.Integer).Value = chklisttranno;
                cmd.Parameters.Add("@CHKLISTNAME", NpgsqlDbType.Text).Value = chklistname;
                cmd.Parameters.Add("@SITEOFFICEREMARK", NpgsqlDbType.Text).Value = siteofficereamrk;
                cmd.Parameters.Add("@VILLAGECODE", NpgsqlDbType.Text).Value = villagecode;
                cmd.Parameters.Add("@FAMILYNO", NpgsqlDbType.Text).Value = familyno;
                cmd.Parameters.Add("@DOCNO", NpgsqlDbType.Text).Value = docno;
                cmd.Parameters.Add("@CHKLISTNO", NpgsqlDbType.Integer).Value = chklstno;
                cmd.Parameters.Add("@OFFICENAME", NpgsqlDbType.Text).Value = officename;

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


        public string getCheckListTranSeqNo()
        {
            string CheckListTranSeqNo = null;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;

                cmd.CommandText = "select nextval ('checklisttranseq')";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                try
                {
                    conReader = cmd.ExecuteReader();
                    while (conReader.Read())
                    {
                        CheckListTranSeqNo = Convert.ToString(conReader.GetValue(0));
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

                return CheckListTranSeqNo;
            }
        }
        ///
    }
}