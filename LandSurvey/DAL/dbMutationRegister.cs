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

    public class dbMutationRegister : dbConnection

    {

        DataSet ds = new DataSet();

        DataTable dt = new DataTable();



        public string villagecode { get; set; }

        public string mutationno { get; set; }

        public string mutationyear { get; set; }

        public string remarks { get; set; }

        public string mutationdetails { get; set; }

        public int mutationid { get; set; }



        public string mutationdate { get; set; }

        public string surveyno { get; set; }



        public string mutremarks { get; set; }



        public string field4 { get; set; }

        public string field5 { get; set; }

        public string field6 { get; set; }

        public string field7 { get; set; }





        public string mutationorderrec { get; set; }

        public string mutated712rec { get; set; }



        public string getMutationRegisterSeqNo()

        {

            string MutationRegisterSeqNo = null;

            using (NpgsqlCommand cmd = new NpgsqlCommand())

            {

                openConnection();

                NpgsqlDataReader conReader;

                conReader = null;



                cmd.CommandText = "select nextval ('mutationregisterseqno')";

                cmd.Connection = conn;

                cmd.Transaction = transaction;

                cmd.CommandType = CommandType.Text;

                try

                {

                    conReader = cmd.ExecuteReader();

                    while (conReader.Read())

                    {

                        MutationRegisterSeqNo = Convert.ToString(conReader.GetValue(0));

                    }



                }

                catch (Exception ex)

                {

                    errorTransaction();

                    throw new ApplicationException("Something wrong happened in the Mutation Register Module :", ex);

                }

                finally

                {

                    conReader.Close();

                    closeConnection();

                }



                return MutationRegisterSeqNo;

            }

        }



        public string getMutationSurveySeqNo()

        {

            string MutationSurveySeqNo = null;

            using (NpgsqlCommand cmd = new NpgsqlCommand())

            {

                openConnection();

                NpgsqlDataReader conReader;

                conReader = null;



                cmd.CommandText = "select nextval ('mutationsurveyseqno')";

                cmd.Connection = conn;

                cmd.Transaction = transaction;

                cmd.CommandType = CommandType.Text;

                try

                {

                    conReader = cmd.ExecuteReader();

                    while (conReader.Read())

                    {

                        MutationSurveySeqNo = Convert.ToString(conReader.GetValue(0));

                    }



                }

                catch (Exception ex)

                {

                    errorTransaction();

                    throw new ApplicationException("Something wrong happened in the Mutation Survey Module :", ex);

                }

                finally

                {

                    conReader.Close();

                    closeConnection();

                }



                return MutationSurveySeqNo;

            }

        }





        public DataSet getMutationRegisterData(string MutationNo, string VillageCode)

        {

            try

            {

                string strQuery = null;



                if (!string.IsNullOrEmpty(VillageCode) && !string.IsNullOrEmpty(MutationNo))

                {

                    strQuery = " and mr.mutationno = '" + MutationNo + "' and mr.villagecode = '" + VillageCode + "' order by cast(mr.mutationno as int)";

                }

               // order by cast(docno as int)

                ds = FillData("select row_number() over() as srno, mr.mutationid, mr.villagecode, v.villagemname, mr.mutationno, mr.mutationyear, mr.mutationdetail, mr.mutremarks," +

                               "mr.csurveyno as surveynos from mutationregister mr join village v on mr.villagecode = v.villagecode where COALESCE(mr.field4,'') = '' and COALESCE(mr.field5,'') = '' " + strQuery , "MutationRegister");

            }

            catch (Exception ex)

            {

                throw ex;

            }

            return ds;

        }





        public DataSet getMutationRegisterData(int MutationId)

        {

            try

            {

                ds = FillData("select mr.mutationid, mr.villagecode, v.villagemname, mr.mutationno, mr.mutationyear, mr.mutationdetail,mr.mutremarks," +

                              "mr.csurveyno as surveynos from mutationregister mr join village v on mr.villagecode = v.villagecode where mr.mutationid = " + MutationId + "", "MutationRegister");

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



            int mutationsurveyid = Convert.ToInt32(getMutationRegisterSeqNo());



            using (NpgsqlCommand cmd = new NpgsqlCommand())

            {

                openConnection();

                NpgsqlDataReader conReader;

                conReader = null;



                cmd.CommandText = "Insert into mutationregister(mutationid,villagecode,mutationno,mutationyear,mutationdetail,mutremarks,csurveyno)" +

                                    "Values(@mutationid,@villagecode,@mutationno,@mutationyear,@mutationdetail,@remarks,@surveynos)";

                cmd.Connection = conn;

                cmd.Transaction = transaction;

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@villagecode", NpgsqlDbType.Text).Value = villagecode;

                cmd.Parameters.Add("@mutationno", NpgsqlDbType.Text).Value = mutationno;

                cmd.Parameters.Add("@mutationyear", NpgsqlDbType.Text).Value = mutationyear;

                cmd.Parameters.Add("@surveynos", NpgsqlDbType.Text).Value = surveyno;

                cmd.Parameters.Add("@remarks", NpgsqlDbType.Text).Value = remarks;

                cmd.Parameters.Add("@mutationdetail", NpgsqlDbType.Text).Value = mutationdetails;

                cmd.Parameters.Add("@mutationid", NpgsqlDbType.Numeric).Value = mutationsurveyid;



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

                conReader = null; //,

                cmd.CommandText = "Update mutationregister set villagecode = @villagecode, mutationno = @mutationno, mutationyear = @mutationyear, mutremarks = @remarks, mutationdetail = @mutationdetail,csurveyno = @surveynos where mutationid = @mutationid";

                cmd.Connection = conn;

                cmd.Transaction = transaction;

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@villagecode", NpgsqlDbType.Text).Value = villagecode;

                cmd.Parameters.Add("@mutationno", NpgsqlDbType.Text).Value = mutationno;

                cmd.Parameters.Add("@mutationyear", NpgsqlDbType.Text).Value = mutationyear;

                cmd.Parameters.Add("@remarks", NpgsqlDbType.Text).Value = remarks;

                cmd.Parameters.Add("@mutationdetail", NpgsqlDbType.Text).Value = mutationdetails;

                cmd.Parameters.Add("@mutationid", NpgsqlDbType.Numeric).Value = mutationid;

                cmd.Parameters.Add("@surveynos", NpgsqlDbType.Text).Value = surveyno;



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



        private bool AddMutationSurveyNos()

        {

            bool _PValid = false;



            DeleteMutationSurveyData();



            {

                string input = surveyno;

                string[] surveynoArray = input.Split(',');



                foreach (string item in surveynoArray)

                {

                    _PValid = AddMutationSurveyData(item);

                }

            }

            return _PValid;

        }



        public bool AddMutationSurveyData(string SurveyNo)

        {

            bool _PValid = false;

            using (NpgsqlCommand cmd = new NpgsqlCommand())

            {

                int mutationsurveyid = Convert.ToInt32(getMutationSurveySeqNo());



                openConnection();

                NpgsqlDataReader conReader;

                conReader = null;



                cmd.CommandText = "Insert into mutationsurvey (mutationsurveyid,villagecode,mutationno,surveyno)" +

                                    "Values(@mutationsurveyid,@villagecode,@mutationno,@surveyno)";

                cmd.Connection = conn;

                cmd.Transaction = transaction;

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@villagecode", NpgsqlDbType.Text).Value = villagecode;

                cmd.Parameters.Add("@mutationno", NpgsqlDbType.Text).Value = mutationno;

                cmd.Parameters.Add("@surveyno", NpgsqlDbType.Text).Value = SurveyNo;

                cmd.Parameters.Add("@mutationsurveyid", NpgsqlDbType.Integer).Value = mutationsurveyid;



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



        public bool DeleteMutationSurveyData()

        {

            bool _PValid = false;

            using (NpgsqlCommand cmd = new NpgsqlCommand())

            {

                openConnection();

                NpgsqlDataReader conReader;

                conReader = null;

                cmd.CommandText = "delete from mutationsurvey where villagecode=@villagecode and mutationno=@mutationno";

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



        public bool DeleteMutationFinalData()

        {

            bool _PValid = false;

            using (NpgsqlCommand cmd = new NpgsqlCommand())

            {

                openConnection();

                NpgsqlDataReader conReader;

                conReader = null;

                cmd.CommandText = "delete from mutationregister where villagecode = @villagecode and mutationno = @mutationno ";

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

                ds = FillData("select  mutationno, mutationdate, surveyno, remarks, mutationorderrec, mutated712rec from tblmutationfinal where villagecode='" + villagecode + "' order by mutationno", "MutationFinalDataForReport");

            }

            catch (Exception)

            {



                throw;

            }

            return ds;

        }



    }

}