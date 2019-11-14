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
    public class dbFamilyDetails : dbConnection
    {
        DataSet ds = new DataSet();
        public int familydetailid { get; set; }
        public int familyid { get; set; }
        public string surveyno { get; set; }
        public double surveyarea { get; set; }
        public double surveyrate { get; set; }
        public double areaaquired { get; set; }
        public string holdername { get; set; }
        public double holderarea { get; set; }
        public string familyno { get; set; }
        public string villagecode { get; set; }
        public string documentno { get; set; }
        public string pdffilename { get; set; }
        public string docno { get; set; }
        public string landclass { get; set; }
       

        public DataSet getFamilyDetails(string VillageCode, string FamilyNo, string SurveyNo)
        {
            try
            {
                ds = FillData("select row_number() over() as srno, t.* from (select holdername, holderarea, areaaquired from familydetails " +
                                " where familyno = '" +FamilyNo + "' and villagecode = '" + VillageCode + "' and surveyno = '" + SurveyNo + "' order by holdername) t ", "familymaster");
                if (ds.Tables[0].Rows.Count > 0)
                {
                   // ds.Tables[0].TableName = "FirstTable";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getFamilyDetailsMultipleSurvey(string VillageCode, string DocNo, string SurveyNo)
        {
            try
            {
                ds = FillData("select row_number() over() as srno, t.* from (select familydetailid, holdername, surveyno, surveyarea, surveyrate, holderarea, areaaquired from familydetails " +
                                " where docno = '" + DocNo + "' and villagecode = '" + VillageCode + "' and surveyno IN(" + SurveyNo + ") order by surveyno) t ", "familymaster");
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

        public bool UpdateFamilyDetails()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;

                cmd.CommandText = " update familydetails set surveyarea = @SURVEYAREA, surveyrate = @SURVEYRATE, holderarea = @HOLDERAREA,  " +
                                    " areaaquired = @AQUIREDAREA, documentno = @DOCUMENTNO where familydetailid = @FAMILYDETAILID ";
                                  
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                
                cmd.Parameters.Add("@SURVEYAREA", NpgsqlDbType.Double).Value = surveyarea;
                cmd.Parameters.Add("@SURVEYRATE", NpgsqlDbType.Double).Value = surveyrate;
                cmd.Parameters.Add("@HOLDERAREA", NpgsqlDbType.Double).Value = holderarea;
                cmd.Parameters.Add("@AQUIREDAREA", NpgsqlDbType.Double).Value = areaaquired;
                cmd.Parameters.Add("@DOCUMENTNO", NpgsqlDbType.Text).Value = documentno;
                cmd.Parameters.Add("@FAMILYDETAILID", NpgsqlDbType.Text).Value = familydetailid;
               
               
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
                    throw new ApplicationException("Something wrong happened in the Family Details Module :", ex);
                }
                finally
                {
                    conReader.Close();
                    closeConnection();
                }
            }

            return _PValid;
        }

        public bool UpdateFamilyDetailDocNo()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;

                //cmd.CommandText = " update familydetails set documentno = @DOCUMENTNO " +
                //                  " where villagecode = @VILLAGECODE and familyno = @FAMILYNO and docno = @DOCNO ";
                cmd.CommandText = " update familydetails set documentno = @DOCUMENTNO " +
                                " where villagecode = @VILLAGECODE and docno = @DOCNO ";

                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@DOCUMENTNO", NpgsqlDbType.Text).Value = documentno;
                cmd.Parameters.Add("@VILLAGECODE", NpgsqlDbType.Text).Value = villagecode;
                //-
                cmd.Parameters.Add("@FAMILYNO", NpgsqlDbType.Text).Value = familyno;
                cmd.Parameters.Add("@DOCNO", NpgsqlDbType.Text).Value = docno;



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
                    throw new ApplicationException("Something wrong happened in the Family Survey Module :", ex);
                }
                finally
                {
                    conReader.Close();
                    closeConnection();
                }
            }

            return _PValid;
        }

        public DataSet getFamilyDetailsDocumentNo(string VillageCode, string FamilyNo)
        {
            try
            {
                ds = FillData("select docno from familydetails where villagecode='" + VillageCode + "' and familyno='" + FamilyNo +"' "+
                             " and documentno !='' group by docno order by documentno ", "familydetails");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].NewRow();
                    row["documentno"] = "Please Select document No";
                    ds.Tables[0].Rows.InsertAt(row, 0);
                }
                else
                {
                    DataRow row = ds.Tables[0].NewRow();
                    row["documentno"] = "Document not available";
                    ds.Tables[0].Rows.InsertAt(row, 0);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getDocumnentNoTitleSearch(string VillageCode)
        {
            try
            {
                ds = FillData("select docno from familydetails where villagecode='" + VillageCode + "' " +
                             " and documentno !='' group by docno order by cast(docno as int) ", "familydetails");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].NewRow();
                    row["docno"] = "Please Select document No";
                    ds.Tables[0].Rows.InsertAt(row, 0);
                }
                else
                {
                    DataRow row = ds.Tables[0].NewRow();
                    row["docno"] = "Document not available";
                    ds.Tables[0].Rows.InsertAt(row, 0);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getFamilyDetailsOnDocument(string VillageCode, string DocNo)
        {
            try
            {
                ds = FillData("select row_number() over() as srno, t.* from (select holdername, holderarea, surveyno, surveyarea, areaaquired from familydetails " +
                                " where villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' and documentno !='' order by holdername) t ", "familydetails");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // ds.Tables[0].TableName = "FirstTable";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getFamilyDetailsDocumentNoNew(string VillageCode, string FamilyNo)
        {
            try
            {
                ds = FillData("select docno from familydetails where villagecode='" + VillageCode + "' and familyno='" + FamilyNo + "' " +
                             " and docno !='' group by docno order by docno ", "familydetails");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //DataRow row = ds.Tables[0].NewRow();
                    //row["documentno"] = "Please Select document No";
                    //ds.Tables[0].Rows.InsertAt(row, 0);
                }
                else
                {
                    DataRow row = ds.Tables[0].NewRow();
                    row["docno"] = "Document not available";
                    ds.Tables[0].Rows.InsertAt(row, 0);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getVillageDocNo(string VillageCode)
        {
            try
            {
                //ds = FillData("select docno::integer from familydetails where villagecode='" + VillageCode + "'  " +
                //             " and docno !='' group by docno order by docno ", "familydetails");
                ds = FillData("select docno from familydetails where villagecode='" + VillageCode + "'  " +
                            " and docno !='' group by docno order by cast(docno as int) ", "familydetails");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].NewRow();
                    row["docno"] = "Please Select Document No";
                    ds.Tables[0].Rows.InsertAt(row, 0);
                }
                else
                {
                    DataRow row = ds.Tables[0].NewRow();
                    row["docno"] = "Document not available";
                    ds.Tables[0].Rows.InsertAt(row, 0);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getVillageDocNoForSO(string VillageCode)
        {
            try
            {
                //ds = FillData("select docno::integer from familydetails where villagecode='" + VillageCode + "'  " +
                //             " and docno !='' group by docno order by docno ", "familydetails");
                ds = FillData("select docno from familydetails where villagecode='" + VillageCode + "'  " +
                            " and docno !='' and documentno != '' group by docno order by cast(docno as int) ", "familydetails");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].NewRow();
                    row["docno"] = "Please Select Document No";
                    ds.Tables[0].Rows.InsertAt(row, 0);
                }
                else
                {
                    DataRow row = ds.Tables[0].NewRow();
                    row["docno"] = "Document not available";
                    ds.Tables[0].Rows.InsertAt(row, 0);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet Get712PDFFileName(string VillageCode, String DocNO, String SurveyNo)
        {
            try
            {
                ds = FillData("select pdffilename from familydetails where villagecode='" + VillageCode + "'  " +
                            " and docno = '" + DocNO + "' and surveyno = '" + SurveyNo + "' group by pdffilename ", "familydetails");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    
                }
                else
                {
                    
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;

        }

        public DataSet GetMutationRegister(string VillageCode, String DocumentCode, String SurveyNo)
        {
            try
            {
                ds = FillData("select documentname from documentstatus where villagecode='" + VillageCode + "'  " +
                            " and documentcode = '" + DocumentCode + "' and surveyno = '" + SurveyNo + "' ", "documentstatus");
                if (ds.Tables[0].Rows.Count > 0)
                {

                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;

        }

        public DataSet getFamilyDetailsAllData()
        {
            try
            {
                ds = FillData("select row_number() over() as srno, t.* from (select holdername, surveyno, surveyarea,holderarea, areaaquired from familydetails " +
                                " order by holdername) t ", "familydetails");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // ds.Tables[0].TableName = "FirstTable";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getFamilyDetailsAllDataOnDocNo(string SelectedFamilyNo)
        {
            try
            {
                ds = FillData("select row_number() over() as srno, t.* from (select holdername, surveyno, surveyarea,holderarea, areaaquired from familydetails " +
                                " where familyno = '" + SelectedFamilyNo + "' order by holdername) t ", "familydetails");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // ds.Tables[0].TableName = "FirstTable";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet getFamilyNumberAllData()
        {
            try
            {
                ds = FillData("select row_number() over() as srno, t.* from (select holdername, surveyno, surveyarea,holderarea, areaaquired from familydetails " +
                                " order by holdername) t ", "familydetails");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // ds.Tables[0].TableName = "FirstTable";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getFamilyNumber(string VillageCode)
        {
            try
            {
                //ds = FillData("select docno::integer from familydetails where villagecode='" + VillageCode + "'  " +
                //             " and docno !='' group by docno order by docno ", "familydetails");
                ds = FillData("select familyno from familydetails where villagecode='" + VillageCode + "'  " +
                            " group by familyno order by familyno ", "familydetails");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].NewRow();
                    row["familyno"] = "Please Select Family No";
                    ds.Tables[0].Rows.InsertAt(row, 0);
                }
                else
                {
                    DataRow row = ds.Tables[0].NewRow();
                    row["familyno"] = "Family no not available";
                    ds.Tables[0].Rows.InsertAt(row, 0);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getFamilyOnDocumentSearch(string VillageCode, string DocNo)
        {
            try
            {
                ds = FillData("select row_number() over() as srno, t.* from (select docno, familyno, surveyno, surveyarea, surveyrate from familydetails " +
                                " where villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' order by holdername) t ", "familydetails");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // ds.Tables[0].TableName = "FirstTable";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getSOOfficeDocument(string VillageCode, string DocNo)
        {
            try
            {
                //                select row_number() over() as srno, t.* from(select location, documentename, documentstatus.documentname, documentstatus.createddate from documentmaster
                //LEFT JOIN documentstatus ON   documentstatus.documentcode = documentmaster.documentcode
                //  and documentstatus.villagecode = '40' and documentstatus.docno = '10'
                //  where location IN('Site Office-1', 'Site Office-2')) t
                 //ds = FillData("select row_number() over() as srno, t.* from(select location, documentename, documentstatus.documentname, documentstatus.createddate from documentmaster " +
                 //               " LEFT JOIN documentstatus ON   documentstatus.documentcode = documentmaster.documentcode" +
                 //               " and villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' "+
                 //               " where location IN('Site Office-1', 'Site Office-2')) t ", "familydetails");

                //ds = FillData("select row_number() over() as srno, t.* from(select location, dm.documentename as documentname, ds.documentname as docfile, to_char(ds.createddate,'DD/MM/YYYY') as createddate, " +
                //        "  case when ds.documentcode IS NOT NULL then  'Yes' else 'No' end as filestatus " +
                //        "  from documentmaster dm " +
                //        "  LEFT OUTER JOIN documentstatus ds ON   ds.documentcode = dm.documentcode " +
                //        "  and villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' " +
                //        "  where location IN('Site Office-1', 'Site Office-2') and dm.documentcode IN('MSR', 'CMS', 'CRS', 'RCMS', 'ODMS', 'RSR', 'RCRS', 'LI', 'FT') order by location) t ", "documentstatus");
                //"  where location IN('Site Office-1', 'Site Office-2') and dm.documentcode IN('MSR', 'CMS', 'RCMS', 'ODMS', 'CRS', 'RSR', 'RCRS', 'LI', 'FT') order by location) t ", "documentstatus");
                ds = FillData("select row_number() over() as srno, t.* from(select location, dm.documentename as documentname, ds.documentname as docfile, to_char(ds.createddate,'DD/MM/YYYY') as createddate, " +
                       "  case when ds.documentcode IS NOT NULL then  'Yes' else 'No' end as filestatus " +
                       "  from documentmaster dm " +
                       "  LEFT OUTER JOIN documentstatus ds ON   ds.documentcode = dm.documentcode " +
                       "  and villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' " +
                       "  where location IN('Site Office-1', 'Site Office-2') and dm.documentcode IN('MSR','ODMS', 'RSR', 'LI', 'FT') order by location) t ", "documentstatus");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // ds.Tables[0].TableName = "FirstTable";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getFinalDocument(string VillageCode, string DocNo)
        {
            try
            {
                //                select row_number() over() as srno, t.* from(select location, documentename, documentstatus.documentname, documentstatus.createddate from documentmaster
                //LEFT JOIN documentstatus ON   documentstatus.documentcode = documentmaster.documentcode
                //  and documentstatus.villagecode = '40' and documentstatus.docno = '10'
                //  where location IN('Site Office-1', 'Site Office-2')) t
                //ds = FillData("select row_number() over() as srno, t.* from(select documentename, documentstatus.documentname, documentstatus.solicitorsentdate, documentstatus.solicitorapproval," +
                //                "documentstatus.solicitorappdate from documentmaster " +
                //               " LEFT JOIN documentstatus ON   documentstatus.documentcode = documentmaster.documentcode" +
                //               " and villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' " +
                //               " where location IN('Head Office')) t ", "familydetails");
                ds = FillData(" select row_number() over() as srno, t.* from(select documentename, documentstatus.documentname as filename, " +
                             " to_char(documentstatus.createddate,'DD-MM-YYYY') as docdate from documentmaster " +
                             " LEFT JOIN documentstatus ON   documentstatus.documentcode = documentmaster.documentcode " +
                              " and villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' " +
                              "where documentmaster.documentcode IN('PTS', 'PN', 'RPN', 'ODHO')) t ", "familydetails");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // ds.Tables[0].TableName = "FirstTable";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public string getFamilyNoOnDocNo(string DocNo)
        {
            string FamilyNo = null;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;

                cmd.CommandText = "select familyno from familydetails where docno= '" + DocNo + "' group by familyno";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                try
                {
                    conReader = cmd.ExecuteReader();
                    while (conReader.Read())
                    {
                        FamilyNo = Convert.ToString(conReader.GetValue(0));
                    }

                }
                catch (Exception ex)
                {
                    errorTransaction();
                    throw new ApplicationException("Something wrong happened in the Family Module :", ex);
                }
                finally
                {
                    conReader.Close();
                    closeConnection();
                }

                return FamilyNo;
            }
        }

        public DataSet getHOSolicitDocumentSubmitted(string VillageCode, string DocNo)
        {
            try
            {
                //select row_number() over() as srno, t.* from(select documentename, documentstatus.documentname, documentstatus.solicitorsentdate, documentstatus.solicitorapproval,
                //documentstatus.solicitorappdate from documentmaster
                //               LEFT JOIN documentstatus ON   documentstatus.documentcode = documentmaster.documentcode
                //               and villagecode = '40' and docno = '10'
                //               where location IN('Head Office')) t

                ds = FillData("select row_number() over() as srno, t.* from(select documentename, documentstatus.documentname, documentstatus.solicitorsentdate, documentstatus.solicitorapproval," +
                                "documentstatus.solicitorappdate from documentmaster " +
                               " LEFT JOIN documentstatus ON   documentstatus.documentcode = documentmaster.documentcode" +
                               " and villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' " +
                               " where location IN('Head Office')) t ", "familydetails");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // ds.Tables[0].TableName = "FirstTable";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getDocumentExecution(string VillageCode, string DocNo)
        {
            try
            {
                //                select row_number() over() as srno, t.* from(select location, documentename, documentstatus.documentname, documentstatus.createddate from documentmaster
                //LEFT JOIN documentstatus ON   documentstatus.documentcode = documentmaster.documentcode
                //  and documentstatus.villagecode = '40' and documentstatus.docno = '10'
                //  where location IN('Site Office-1', 'Site Office-2')) t
                ds = FillData("select row_number() over() as srno, t.* from(select location, documentename, documentstatus.documentname, documentstatus.createddate from documentmaster " +
                               " LEFT JOIN documentstatus ON   documentstatus.documentcode = documentmaster.documentcode" +
                               " and villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' " +
                               " where location IN('Site Office-2')) t ", "familydetails");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // ds.Tables[0].TableName = "FirstTable";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        //SO-One 
        public DataSet getSO1LandDocument(string SelectedVillageCode, string SelectedDocumentNo)
        {
            try
            {
                ds = FillData("select row_number() over() as srno, t.* from (select familyno, surveyno, surveyarea, landclass, holdername, holderarea, areaaquired  from familydetails" +
                                " where villagecode = '" + SelectedVillageCode + "'and docno = '" + SelectedDocumentNo + "' order by holdername) t ", "familydetails");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // ds.Tables[0].TableName = "FirstTable";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getSO1SubmitDocument(string SelectedVillageCode, string SelectedDocumentNo)
        {
            try
            {
                ds = FillData("select row_number() over() as srno, t.* from (select familyno, surveyno from familydetails" +
                               " where villagecode = '" + SelectedVillageCode + "'and docno = '" + SelectedDocumentNo + "' order by holdername) t ", "familydetails");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // ds.Tables[0].TableName = "FirstTable";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getSO1SubmitCheckList(string SelectedVillageCode, string SelectedDocumentNo, string OfficeName)
        {
            try
            {
                ds = FillData("select row_number() over() as srno, t.* from(select chklistno,chkname, siteofficereamrk from checklistmaster "+
                        " LEFT JOIN chklisttran ON chklisttran.chklstno = checklistmaster.chklistno "+
                        " and villagecode = '"+ SelectedVillageCode + "'and docno = '" + SelectedDocumentNo + "' and officename = '" + OfficeName + "'   order by chklisttranno) t ", "familydetails");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // ds.Tables[0].TableName = "FirstTable";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        //So-One End


        //Mutation Register 
        public DataSet GetFileNameFromDocumentStatus(string VillageCode, string DocumentNo, string DocumentCode )
        {
            try
            {
                ds = FillData("select documentname from documentstatus where villagecode='" + VillageCode + "'  " +
                            " and docno = '" + DocumentNo + "' and documentcode ='" + DocumentCode + "' ", "documentstatus");
                if (ds.Tables[0].Rows.Count > 0)
                {

                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;

        }


        public string getDocNo712(string VillageCode, string DocNo, string SurveyNo)
        {
            string PDF712File = null;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;

                //cmd.CommandText = "select familyno from familydetails where docno= '" + DocNo + "' group by familyno";
                cmd.CommandText = " select pdffilename from familydetails where villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' " +
                                    " and surveyno = '" + SurveyNo + "'  group by pdffilename ";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                try
                {
                    conReader = cmd.ExecuteReader();
                    while (conReader.Read())
                    {
                        PDF712File = Convert.ToString(conReader.GetValue(0));
                    }

                }
                catch (Exception ex)
                {
                    errorTransaction();
                    throw new ApplicationException("Something wrong happened in the Family Module :", ex);
                }
                finally
                {
                    conReader.Close();
                    closeConnection();
                }

                return PDF712File;
            }
        }

        //Solicitor Daya

        public DataSet SolicitorApprovalData(string VillageCode, string DocumentNo)
        {
            try
            {
                //ds = FillData("select documentid, documentname, solicitorsentdate, solicitorapproval, solicitorremark, solicitorappdate " +
                //                 "from documentstatus " +
                //                " where villagecode = '40' and docno = '1' and documentcode in ('PTS', 'PN', 'FTS', 'ODHO', 'SD', 'ATS') ", "dicumentstatus");

                ds = FillData("select dm.documentename as docname, ds.documentname, ds.solicitorsentdate, ds.solicitorapproval, " +
                             " ds.solicitorremark, ds.solicitorappdate from documentmaster dm " +
                             " LEFT OUTER JOIN documentstatus ds ON   ds.documentcode = dm.documentcode " +
                             " and villagecode = '" + villagecode + "'  and docno = '" + DocumentNo + "' " +
                             " where dm.documentcode  in ('PTS', 'PN', 'FTS', 'ODHO', 'SD', 'ATS') ", "documentstatus");
                if (ds.Tables[0].Rows.Count > 0)
                {

                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;

        }

        public DataSet Get712files(string VillageCode, string DocName)
        {
            try
            {

                ds = FillData("select trim(pdffilename) as pdffilename  from familydetails" +
                              " where villagecode = '" + VillageCode + "' and docno = '" + DocName + "' ", "failydetails");

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

        public DataSet getDocumentSurveyNo(string VillageCode, string DocNo)
        {
            try
            {
                ds = FillData("select surveyno from familydetails" +
                                 " where villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' " +
                                 " group by surveyno", "familydetails");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // ds.Tables[0].TableName = "FirstTable";
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