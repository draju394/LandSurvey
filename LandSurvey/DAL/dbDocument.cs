using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using NpgsqlTypes;
using LandSurvey.DAL;
using System.Data;

namespace LandSurvey.DAL
{
    public class dbDocument : dbConnection
    {
        DataSet ds = new DataSet();
        public int documentid { get; set; }
        public string villagecode { get; set; }
        public string familyno { get; set; }
        public string titlesearchno { get; set; }
        public string surveyno { get; set; }
        public string documentcode { get; set; }
        public string documentname { get; set; }
        public string documentpath { get; set; }
        public string createdby { get; set; }
        public DateTime createddate { get; set; }
        public string docno { get; set; }
        public string solicitorapproval { get; set; }
        public DateTime solicitorappdate { get; set; }
        public string solicitorremark { get; set; }
        public string clientapproval { get; set; }
        public DateTime clientappdate { get; set; }
        public string clientremark { get; set; }
        public DateTime solicitorsentdate { get; set; }
        public string uploadedby { get; set; }
        public string officename { get; set; }


        public string getDocumentSeqNo()
        {
            string DocumentSeqNo = null;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;

                cmd.CommandText = "select nextval ('seqdocstat')";
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
        
        public DataSet DocumentExist(string VillageCode, string DocNo, string SurveyNo, string DocumentCode)
        {
            try
            {
                ds = FillData("select * from documentstatus where villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' "+
                               " and surveyno IN(" + SurveyNo + ") and documentcode = '" + DocumentCode + "' ", "familymaster" );
                if (ds.Tables[0].Rows.Count > 0) 
                {
                   
                }

            }
            catch (Exception ex)
            {
                throw ex;             }
            return ds;
        }

        public DataSet DocumentExistRO(string VillageCode, string DocNo, string DocumentCode)
        {
            try
            {
                ds = FillData("select * from documentstatus where villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' " +
                               " and documentcode = '" + DocumentCode + "'  ", "documentstatus");
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

        public DataSet DocumentExistIN(string VillageCode, string DocNo, string SurveyNo)
        {
            try
            {
                ds = FillData("select * from documentstatus where villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' " +
                               " and surveyno IN (" + SurveyNo + ") and documentcode IN ('MR','DR','PN','FR') ", "familymaster");
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

        public DataSet DocumentExistDocNoRO(string VillageCode, string DocNo)
        {
            try
            {
                ds = FillData("select * from documentstatus where villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' " +
                               "  and documentcode IN ('FT','CL','LN','LE') ", "documentstatus");
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

        public DataSet DocumentTitleExist(string VillageCode, string DocNo, string SurveyNo)
        {
            try
            {
                ds = FillData("select titlesearchno from documentstatus where villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' " +
                               " and surveyno IN (" + SurveyNo + ") group by villagecode, familyno, surveyno, titlesearchno   ", "documentstatus");
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

        public DataSet DocumentTitleExistRO(string VillageCode, string DocNo)
        {
            try
            {
                ds = FillData("select titlesearchno from documentstatus where villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' " +
                               " group by villagecode, familyno, surveyno, titlesearchno   ", "familymaster");
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

        public bool AddDocumentStatus()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;
                cmd.CommandText = "Insert into documentstatus (documentid,villagecode,familyno,titlesearchno,surveyno,documentcode," +
                                   " documentname, documentpath, createdby, createddate, docno, officename)" +
                                   " Values(@DOCUMENTID,@VILLAGECODE,@FAMILYNO,@TITLESEARCHNO,@SURVEYNO, @DOCUMENTCODE," +
                                   " @DOCUMENTNAME, @DOCUMENTPATH, @CREATEDBY,@CREATEDDATE,@DOCNO, @OFFICENAME)";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@DOCUMENTID", NpgsqlDbType.Integer).Value = documentid;
                cmd.Parameters.Add("@VILLAGECODE", NpgsqlDbType.Text).Value = villagecode;
                cmd.Parameters.Add("@FAMILYNO", NpgsqlDbType.Text).Value = familyno;
                cmd.Parameters.Add("@TITLESEARCHNO", NpgsqlDbType.Text).Value = titlesearchno;
                cmd.Parameters.Add("@SURVEYNO", NpgsqlDbType.Text).Value = surveyno;
                cmd.Parameters.Add("@DOCUMENTCODE", NpgsqlDbType.Text).Value = documentcode;
                cmd.Parameters.Add("@DOCUMENTNAME", NpgsqlDbType.Text).Value = documentname;
                cmd.Parameters.Add("@DOCUMENTPATH", NpgsqlDbType.Text).Value = documentpath;
                cmd.Parameters.Add("@CREATEDBY", NpgsqlDbType.Text).Value = createdby;
                cmd.Parameters.Add("@CREATEDDATE", NpgsqlDbType.Date).Value = createddate;
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
                    throw new ApplicationException("Something wrong happened in the Document Add Module :", ex);
                }
                finally
                {
                    conReader.Close();
                    closeConnection();
                }
            }

            return _PValid;
        }


        public bool UpdateDocumentFile(string SurveyNo)
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;
                
                cmd.CommandText = " update documentstatus set documentname = @DOCUMENTNAME, documentpath = @DOCUMENTPATH where villagecode = @VILLAGECODE " +
                                  " and docno = @DOCNO and surveyno IN (" + SurveyNo + ") and documentcode = @DOCUMENTCODE";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.Add("@DOCUMENTID", NpgsqlDbType.Integer).Value = documentid;
                cmd.Parameters.Add("@VILLAGECODE", NpgsqlDbType.Text).Value = villagecode;
                cmd.Parameters.Add("@DOCNO", NpgsqlDbType.Text).Value = docno;
                //cmd.Parameters.Add("@TITLESEARCHNO", NpgsqlDbType.Text).Value = titlesearchno;
             //   cmd.Parameters.Add("@SURVEYNO", NpgsqlDbType.Text).Value = surveyno;
                cmd.Parameters.Add("@DOCUMENTCODE", NpgsqlDbType.Text).Value = documentcode;
                cmd.Parameters.Add("@DOCUMENTNAME", NpgsqlDbType.Text).Value = documentname;
                cmd.Parameters.Add("@DOCUMENTPATH", NpgsqlDbType.Text).Value = documentpath;
                //cmd.Parameters.Add("@CREATEDBY", NpgsqlDbType.Text).Value = createdby;
                //cmd.Parameters.Add("@CREATEDDATE", NpgsqlDbType.Text).Value = createddate;
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
                    throw new ApplicationException("Something wrong happened in the Document Add Module :", ex);
                }
                finally
                {
                    conReader.Close();
                    closeConnection();
                }
            }

            return _PValid;
        }


        public bool UpdateDocumentFileRO(string DocumentNo)
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;

                cmd.CommandText = " update documentstatus set documentname = @DOCUMENTNAME, documentpath = @DOCUMENTPATH where villagecode = @VILLAGECODE " +
                                  " and familyno = @FAMILYNO and titlesearchno = '" + DocumentNo + "' and documentcode = @DOCUMENTCODE";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.Add("@DOCUMENTID", NpgsqlDbType.Integer).Value = documentid;
                cmd.Parameters.Add("@VILLAGECODE", NpgsqlDbType.Text).Value = villagecode;
                cmd.Parameters.Add("@FAMILYNO", NpgsqlDbType.Text).Value = familyno;
                //cmd.Parameters.Add("@TITLESEARCHNO", NpgsqlDbType.Text).Value = titlesearchno;
                //   cmd.Parameters.Add("@SURVEYNO", NpgsqlDbType.Text).Value = surveyno;
                cmd.Parameters.Add("@DOCUMENTCODE", NpgsqlDbType.Text).Value = documentcode;
                cmd.Parameters.Add("@DOCUMENTNAME", NpgsqlDbType.Text).Value = documentname;
                cmd.Parameters.Add("@DOCUMENTPATH", NpgsqlDbType.Text).Value = documentpath;
                //cmd.Parameters.Add("@CREATEDBY", NpgsqlDbType.Text).Value = createdby;
                //cmd.Parameters.Add("@CREATEDDATE", NpgsqlDbType.Text).Value = createddate;
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
                    throw new ApplicationException("Something wrong happened in the Document Add Module :", ex);
                }
                finally
                {
                    conReader.Close();
                    closeConnection();
                }
            }

            return _PValid;
        }

        public DataSet DocumentExistMSR(string VillageCode, string DocNo, string DocCode)
        {
            try
            {
                ds = FillData("select * from documentstatus where villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' " +
                               "  and documentcode  = '" + DocCode +"' ", "documentstatus");
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

        public bool UpdateDocumentStatusFile()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;


                cmd.CommandText = " update documentstatus set documentname = @DOCUMENTNAME, documentpath = @DOCUMENTPATH where villagecode = @VILLAGECODE " +
                                  " and docno= @DOCNO and documentcode = @DOCUMENTCODE";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.Add("@DOCUMENTID", NpgsqlDbType.Integer).Value = documentid;
                cmd.Parameters.Add("@VILLAGECODE", NpgsqlDbType.Text).Value = villagecode;
                cmd.Parameters.Add("@FAMILYNO", NpgsqlDbType.Text).Value = familyno;
                cmd.Parameters.Add("@DOCNO", NpgsqlDbType.Text).Value = docno;
                //   cmd.Parameters.Add("@SURVEYNO", NpgsqlDbType.Text).Value = surveyno;
                cmd.Parameters.Add("@DOCUMENTCODE", NpgsqlDbType.Text).Value = documentcode;
                cmd.Parameters.Add("@DOCUMENTNAME", NpgsqlDbType.Text).Value = documentname;
                cmd.Parameters.Add("@DOCUMENTPATH", NpgsqlDbType.Text).Value = documentpath;
                //cmd.Parameters.Add("@CREATEDBY", NpgsqlDbType.Text).Value = createdby;
                //cmd.Parameters.Add("@CREATEDDATE", NpgsqlDbType.Text).Value = createddate;
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
                    throw new ApplicationException("Something wrong happened in the Document Add Module :", ex);
                }
                finally
                {
                    conReader.Close();
                    closeConnection();
                }
            }

            return _PValid;
        }

        public DataSet GetDocumentSO2Registry(string VillageCode, string DocNo, string OfficeName)
        {
            try
            {
                //select documentname from documentstatus where villagecode = '40' and docno = '11' and officename = 'SO2' and documentcode IN('RSR', 'LI', 'FT', 'CL', 'ID')
                ds = FillData("select documentname, documentcode from documentstatus where villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' " +
                               " and officename ='" + OfficeName+ "'  and documentcode IN('RSR', 'LI', 'FT', 'CL', 'ID')   ", "documentstatus");
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

        public DataSet DocumentExistInDocumentStatus(string VillageCode, string DocNo, string DocCode, string OfficeName)
        {
            try
            {
                ds = FillData("select * from documentstatus where villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' " +
                               "  and documentcode  IN ('RCMS','CMS', 'CRS')  and officename  = '" + OfficeName + "'", "documentstatus");
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

        public DataSet GetDocumentFromCode(string VillageCode, string DocNo, string DocCode, string OfficeName)
        {
            try
            {
                ds = FillData("select * from documentstatus where villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' " +
                               "  and documentcode  = '" + DocCode +"' and officename  = '" + OfficeName + "'", "documentstatus");
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

        public DataSet GetDocumentexecutionHO(string VillageCode, string DocNo, string OfficeName)
        {
            try
            {
                //select documentname from documentstatus where villagecode = '40' and docno = '11' and officename = 'SO2' and documentcode IN('RSR', 'LI', 'FT', 'CL', 'ID')
                ds = FillData("select documentname, documentcode from documentstatus where villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' " +
                               " and officename ='" + OfficeName + "'  and documentcode IN('VP', 'ATS', 'SD', 'GPA', 'TP','GP','HP')   ", "documentstatus");
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

        public DataSet GetHODocFromSO(string VillageCode, string DocNo, string OfficeName)
        {
            try
            {
                //select documentname from documentstatus where villagecode = '40' and docno = '11' and officename = 'SO2' and documentcode IN('RSR', 'LI', 'FT', 'CL', 'ID')
                ds = FillData("select documentname, documentcode, to_char(createddate,'DD/MM/YYYY') as createddate from documentstatus where villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' " +
                               " and officename IN ('SO1', 'SO2', 'HO')  and documentcode IN('MSR', 'RCMS', 'ODMS', 'CRS', 'RSR','RCRS','LI', 'FT','CMS')   ", "documentstatus");
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

        public DataSet GetPublicNotice(string VillageCode, string DocNo, string OfficeName)
        {
            try
            {
                //select documentname from documentstatus where villagecode = '40' and docno = '11' and officename = 'SO2' and documentcode IN('RSR', 'LI', 'FT', 'CL', 'ID')
                ds = FillData("select documentname, documentcode from documentstatus where villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' " +
                               " and officename ='" + OfficeName + "'  and documentcode IN('PN')   ", "documentstatus");
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

        public DataSet GetPTSForSite1(string VillageCode, string DocNo, string OfficeName)
        {
            try
            {
                //select documentname from documentstatus where villagecode = '40' and docno = '11' and officename = 'SO2' and documentcode IN('RSR', 'LI', 'FT', 'CL', 'ID')
                ds = FillData("select documentname, documentcode from documentstatus where villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' " +
                               " and officename ='" + OfficeName + "'  and documentcode IN('PTS')   ", "documentstatus");
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


        public DataSet DocumentExistInDocStatus(string VillageCode, string DocNo, string DocumentCode, string OfficeName)
        {
            try
            {
                ds = FillData("select * from documentstatus where villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' " +
                               " and documentcode = '" + DocumentCode + "' and officename = '" + OfficeName +"'  ", "documentstatus");
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

        public bool UpdateDocumentStatusApproval(string EntityName)
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;
                if(EntityName == "Solicitor")
                {
                    cmd.CommandText = " update documentstatus set solicitorsentdate = @SOLICITORSENTDATE, " +
                                      " sendtosolicitor = 'Yes', " +
                                      " solicitorapproval = 'No' ," +
                                      " solicitorremark = '' ," +
                                      " solicitorappdate = null" +
                                      " where villagecode = @VILLAGECODE  and docno = @DOCUMENTNO " +
                                      " and documentcode = @DOCUMENTCODE ";
                                      //" and officename  = @OFFICENAME ";
                }
                else if(EntityName == "HO")
                {
                    cmd.CommandText = " update documentstatus set hosenddate = @SOLICITORSENTDATE, " +
                                     " sendtoho = 'Yes' " +
                                     " where villagecode = @VILLAGECODE  and docno = @DOCUMENTNO " +
                                     " and documentcode = @DOCUMENTCODE ";
                                     //" and officename  = @OFFICENAME ";
                }
                else if (EntityName == "Client")
                {
                    cmd.CommandText = " update documentstatus set clientsenddate = @SOLICITORSENTDATE, " +
                                     " sendtoclient = 'Yes' " +
                                     " where villagecode = @VILLAGECODE  and docno = @DOCUMENTNO " +
                                     " and documentcode = @DOCUMENTCODE ";
                                     //" and officename  = @OFFICENAME ";
                }
                //cmd.CommandText = " update documentstatus set documentname = @DOCUMENTNAME, documentpath = @DOCUMENTPATH where villagecode = @VILLAGECODE " +
                //                  " and familyno = @FAMILYNO and titlesearchno = '" + DocumentNo + "' and documentcode = @DOCUMENTCODE";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@VILLAGECODE", NpgsqlDbType.Text).Value = villagecode;
                cmd.Parameters.Add("@DOCUMENTNO", NpgsqlDbType.Text).Value = docno;
                cmd.Parameters.Add("@DOCUMENTCODE", NpgsqlDbType.Text).Value = documentcode;
                cmd.Parameters.Add("@OFFICENAME", NpgsqlDbType.Text).Value = officename;
                cmd.Parameters.Add("@SOLICITORSENTDATE", NpgsqlDbType.Date).Value = solicitorsentdate;


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
                    throw new ApplicationException("Something wrong happened in the Document Add Module :", ex);
                }
                finally
                {
                    conReader.Close();
                    closeConnection();
                }
            }

            return _PValid;
        }

        public DataSet GetClarificationDoc(string VillageCode, string DocNo, string OfficeName)
        {
            try
            {
               ds = FillData("select documentname, documentcode from documentstatus where villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' " +
                               " and officename ='" + OfficeName + "'  and documentcode IN('CPTS', 'CFTS', 'CNOTICE')   ", "documentstatus");
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

        public DataSet HO_GetDocFromSO(string VillageCode, string DocNo, string OfficeName)
        {
            try
            {
                //ds = FillData("select row_number() over() as srno, t.* from (select holdername, surveyno, surveyarea,holderarea, areaaquired from familydetails " +
                //   " order by holdername) t ", "familydetails");

                ds = FillData("select row_number() over() as srno, t.* from( select documentname, documentcode, to_char(createddate,'DD/MM/YYYY') as createddate, "+
                               " sendtoho, to_char(hosenddate,'DD/MM/YYYY') as hosenddate , sendtosolicitor, to_char(solicitorsentdate,'DD/MM/YYYY') as solicitorsentdate , sendtoclient, to_char(clientsenddate,'DD/MM/YYYY') as clientsenddate  " +
                               " from documentstatus where villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' " +
                               " and officename IN ('SO1', 'SO2', 'HO')  and documentcode IN('PTS','FTS', 'ATS', 'SD') )t  ", "documentstatus");
                //ds = FillData("select row_number() over() as srno, t.* from(select location, dm.documentename as documentname, ds.documentname as docfile, to_char(ds.createddate,'DD/MM/YYYY') as createddate, " +
                //      "  case when ds.documentcode IS NOT NULL then  'Yes' else 'No' end as filestatus " +
                //      "  from documentmaster dm " +
                //      "  LEFT OUTER JOIN documentstatus ds ON   ds.documentcode = dm.documentcode " +
                //      "  and villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' " +
                //      "  where location IN('Site Office-1', 'Site Office-2', 'Head Office') and dm.documentcode IN('PTS','FTS', 'ATS', 'SD', 'FT') order by location) t ", "documentstatus");
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

        //
    }
}