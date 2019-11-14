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
    public class dbDocumentStatus : dbConnection
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        #region Solicitor Approval (2019-09-21)
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
        public string clientappdate { get; set; }
        public string clientremark { get; set; }
        public DateTime solicitorsentdate { get; set; }
        public string type { get; set; }

        public string approvetype { get; set; }

        public DataSet getDocumentNumber()
        {
            //try
            //{
            //    ds = FillData("select  docno from documentstatus group by docno order by docno desc", "DocumentStatus");
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //return ds;
            try
            {
                ds = FillData("select 99999999 as dno, 'Select' as docno union " +
                       "select docno :: integer as dno, docno from documentstatus group by docno order by dno desc", "DocumentStatus");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getDocumentsForApproval(string VillageCode, string DocumentNo)
        {
            try
            {
                ds = FillData("select documentid,documentpath,solicitorapproval,solicitorremark,villagecode,docno,documentcode,documentname from documentstatus where villagecode = '" + VillageCode + "' and docno = '" + DocumentNo + "' and documentcode in ('PTS','PN','FTS','ODHO')", "DocumentMaster");
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public bool UpdateDocumentStatus()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
              openConnection();
              NpgsqlDataReader conReader;
                conReader = null;
               if (type == "query")
                {
                    cmd.CommandText = "INSERT INTO documentstatus(documentid, villagecode, familyno, titlesearchno, surveyno, documentcode, documentname, documentpath, createdby, createddate, docno," +
                                      "solicitorapproval, solicitorappdate, solicitorremark, clientapproval, clientappdate, clientremark, solicitorsentdate)" +
                                      "VALUES(@documentid, @villagecode, '0', @documentcode,  null, @documentcode, @documentname, @documentpath, @createdby, @createddate, @docno, null, null, null, null, null, null, null)";
                }
                else
                {
                    cmd.CommandText = "Update documentstatus set solicitorapproval = @solicitorapproval, solicitorappdate = @solicitorappdate, solicitorremark = @solicitorremark where villagecode = @villagecode and  documentcode = @documentcode and docno = @docno";
                }
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@villagecode", NpgsqlDbType.Text).Value = villagecode;
                cmd.Parameters.Add("@documentcode", NpgsqlDbType.Text).Value = documentcode;
                cmd.Parameters.Add("@docno", NpgsqlDbType.Text).Value = docno;
                if (type == "query")
                {
                    cmd.Parameters.Add("@documentpath", NpgsqlDbType.Text).Value = documentpath;
                    cmd.Parameters.Add("@documentname", NpgsqlDbType.Text).Value = documentname;
                    cmd.Parameters.Add("@createdby", NpgsqlDbType.Text).Value = createdby;
                    cmd.Parameters.Add("@createddate", NpgsqlDbType.Date).Value = createddate;
                    cmd.Parameters.Add("@documentid", NpgsqlDbType.Text).Value = documentid;
                }
                else
                {
                    cmd.Parameters.Add("@solicitorapproval", NpgsqlDbType.Text).Value = solicitorapproval;
                    cmd.Parameters.Add("@solicitorappdate", NpgsqlDbType.Date).Value = solicitorappdate;
                    cmd.Parameters.Add("@solicitorremark", NpgsqlDbType.Text).Value = solicitorremark;
                }
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


        #endregion

        public DataSet getSolicitorDocumentsForApproval()
        {
            try
            {
                //ds = FillData("select ds.villagecode, v.villagemname, docno, to_char(ds.createddate, 'DD/MM/YYYY') as createddate , "+
                //              "to_char(solicitorsentdate,'DD/MM/YYYY') as solicitorsentdate , solicitorapproval, to_char(solicitorappdate,'DD/MM/YYYY') as solicitorappdate  " +
                //               " from documentstatus ds, village v where sendtosolicitor ='Yes' and ds.villagecode = v.villagecode" +
                //               " group by ds.villagecode, v.villagemname, docno, ds.createddate, solicitorsentdate, solicitorapproval, solicitorappdate", "DocumentMaster");

                ds = FillData("select distinct on(docno)ds.villagecode, v.villagemname, docno, to_char(ds.createddate, 'DD/MM/YYYY') as createddate , " +
                        "to_char(solicitorsentdate, 'DD/MM/YYYY') as solicitorsentdate , solicitorapproval, to_char(solicitorappdate, 'DD/MM/YYYY') as solicitorappdate " +
                        "from documentstatus ds, village v where sendtosolicitor = 'Yes' and ds.villagecode = v.villagecode", "DocumentStatus");

            }

            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getSolicitorAllDocumentsForApproval(string VillageCode, string DocumentNo)
        {
            try
            {
                ds = FillData("select documentid,documentpath,solicitorapproval,solicitorremark,to_char(solicitorappdate,'DD/MM/YYYY') as solicitorappdate ,villagecode,docno,documentcode, " +
                    " documentname from documentstatus where villagecode = '" + VillageCode + "' and docno = '" + DocumentNo + "' "+ 
                    " and documentcode in ('PTS','PN','FTS','ODMS','SD','ATS','UQPTS','UQFTS', 'CPTS', 'CFTS', 'CPN', 'UQATS','UQSD','UQPN')", "DocumentMaster");
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public bool UpdateDocumentStatusSolicitor()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;
               
                cmd.CommandText = "Update documentstatus set solicitorapproval = @solicitorapproval, solicitorappdate = @solicitorappdate, "+
                                  " solicitorremark = @solicitorremark where villagecode = @villagecode and  documentcode = @documentcode  " +
                                  " and docno = @docno";
                
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@villagecode", NpgsqlDbType.Text).Value = villagecode;
                cmd.Parameters.Add("@documentcode", NpgsqlDbType.Text).Value = documentcode;
                cmd.Parameters.Add("@docno", NpgsqlDbType.Text).Value = docno;
                cmd.Parameters.Add("@solicitorapproval", NpgsqlDbType.Text).Value = solicitorapproval;
                cmd.Parameters.Add("@solicitorappdate", NpgsqlDbType.Date).Value = solicitorappdate;
                cmd.Parameters.Add("@solicitorremark", NpgsqlDbType.Text).Value = solicitorremark;
               
                try
                {
                    conReader = cmd.ExecuteReader();
                    while (conReader.Read())
                    {
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
        //
    }

}