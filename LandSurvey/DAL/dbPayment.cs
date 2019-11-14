using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using LandSurvey.DAL;

namespace LandSurvey.DAL
{
    public class dbPayment : dbConnection
    {

        DataSet ds = new DataSet();
        public int paymentid { get; set; }
        public string titlesearchno { get; set; }
        public string denno { get; set; }
        public string familyno { get; set; }
        public string surveyno { get; set; }
        public string holdername { get; set; }
        public string voucherno { get; set; }
        public DateTime voucherdate { get; set; }
        public double amountpaid { get; set; }
        public DateTime paiddate { get; set; }
        public string amounttype { get; set; }
        public string amtdocumentno { get; set; }
        public DateTime amountdocumentdate { get; set; }
        public string amtbankdetail { get; set; }
        public string clientid { get; set; }
        public string purchaserid { get; set; }
        public string remark { get; set; }
        public string amttransaction { get; set; }
        public string createdby { get; set; }
        public DateTime createddate { get; set; }
        public string modifiedby { get; set; }
        public DateTime modifieddate { get; set; }
        public string docno { get; set; }
        public string getPaymentSeqNo()
        {
            string DocumentSeqNo = null;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;

                cmd.CommandText = "select nextval ('paymentseqno')";
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

        public bool AddPaymentDetails()
        {
            bool _PValid = false;
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;
                cmd.CommandText = "Insert into paymentdetail (paymentid,titlesearchno,familyno,surveyno,holdername,voucherno," +
                                   " voucherdate, amountpaid, paiddate, amounttype,amtdocumentno,amountdocumentdate,amtbankdetail, " +
                                   " clientid,purchaserid,amttransaction,createdby,createddate, docno)" +
                                   " Values(@PYMENTID,@TITLESEARCHNO,@FAMILYNO,@SURVEYNO,@HOLDERNAME, @VOUCHERNO," +
                                   " @VOUCHERDATE, @AMOUNTPAID, @PAIDDATE,@AMOUNTTYPE,@AMTDOCUMENTNO,@AMOUNTDOCUMENTDATE,@AMTBANKDETAIL, "+
                                   " @CLIENTID,@PURCHASERID,@AMTTRANSACTION,@CREADTEDBY,@CREATEDDATE,@DOCNO)";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@PYMENTID", NpgsqlDbType.Integer).Value = paymentid;
                cmd.Parameters.Add("@TITLESEARCHNO", NpgsqlDbType.Text).Value = titlesearchno;
                cmd.Parameters.Add("@FAMILYNO", NpgsqlDbType.Text).Value = familyno;
                cmd.Parameters.Add("@SURVEYNO", NpgsqlDbType.Text).Value = surveyno;
                cmd.Parameters.Add("@HOLDERNAME", NpgsqlDbType.Text).Value = holdername;
                cmd.Parameters.Add("@VOUCHERNO", NpgsqlDbType.Text).Value = voucherno;
                cmd.Parameters.Add("@VOUCHERDATE", NpgsqlDbType.Date).Value = voucherdate;
                cmd.Parameters.Add("@AMOUNTPAID", NpgsqlDbType.Double).Value = amountpaid;
                cmd.Parameters.Add("@PAIDDATE", NpgsqlDbType.Date).Value = paiddate;
                cmd.Parameters.Add("@AMOUNTTYPE", NpgsqlDbType.Text).Value = amounttype;
                cmd.Parameters.Add("@AMTDOCUMENTNO", NpgsqlDbType.Text).Value = amtdocumentno;
                cmd.Parameters.Add("@AMOUNTDOCUMENTDATE", NpgsqlDbType.Date).Value = amountdocumentdate;
                cmd.Parameters.Add("@AMTBANKDETAIL", NpgsqlDbType.Text).Value = amtbankdetail;
                cmd.Parameters.Add("@CLIENTID", NpgsqlDbType.Text).Value = clientid;
                cmd.Parameters.Add("@PURCHASERID", NpgsqlDbType.Text).Value = purchaserid;
                cmd.Parameters.Add("@AMTTRANSACTION", NpgsqlDbType.Text).Value = amttransaction;
                cmd.Parameters.Add("@CREADTEDBY", NpgsqlDbType.Text).Value = createdby;
                cmd.Parameters.Add("@CREATEDDATE", NpgsqlDbType.Date).Value = createddate;
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
                    throw new ApplicationException("Something wrong happened in the Payment Add Module :", ex);
                }
                finally
                {
                    conReader.Close();
                    closeConnection();
                }
            }

            return _PValid;
        }

        public DataSet getPaymentDetails(string FromDate, string ToDate, string SearchType, string FamilyDocNo)
        {
            try
            {
                if (SearchType == "Daily" || SearchType == "Monthly" || SearchType == "Weekly")
                {
                    ds = FillData("Select docno,familyno,surveyno, holdername,voucherno, to_char(voucherdate,'DD/MM/YYYY') as voucherdate, to_char(amountpaid, 'FM9999999999.00') as amountpaid, amounttype from paymentdetail where voucherdate BETWEEN '" + FromDate + "' AND '" + ToDate + "' ", "PaymentDetails");
                }
                else if (SearchType == "DocNo")
                {
                    ds = FillData("Select docno,familyno,surveyno, holdername,voucherno,to_char(voucherdate,'DD/MM/YYYY') as voucherdate, to_char(amountpaid, 'FM9999999999.00') as amountpaid, amounttype from paymentdetail where docno =  '" + FamilyDocNo + "'", "PaymentDetails");
                }
                else if (SearchType == "FamNo")
                {
                    ds = FillData("Select docno,familyno,surveyno, holdername,voucherno,to_char(voucherdate,'DD/MM/YYYY') as voucherdate, to_char(amountpaid, 'FM9999999999.00') as amountpaid, amounttype from paymentdetail where familyno =  '" + FamilyDocNo + "'", "PaymentDetails");
                }
                else
                {
                    ds = FillData("Select docno,familyno,surveyno, holdername,voucherno,to_char(voucherdate,'DD/MM/YYYY') as voucherdate, to_char(amountpaid, 'FM9999999999.00') as amountpaid, amounttype from paymentdetail", "PaymentDetails");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getPaymentDetails(string VillageCode, string ToDate, string FromDate)
        {
            try
            {
                ds = FillData("Select row_number() over() as srno, docno,surveyno,familyno,holdername,voucherno,voucherdate,amountpaid,amounttype from paymentdetail where villagecode = '" + VillageCode + "' and voucherdate >= '" + FromDate + "' AND voucherdate <  '" + ToDate + "' ", "paymentdetail");
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