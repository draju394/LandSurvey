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
    public class dbReports1 : dbConnection
    {
        DataSet ds = new DataSet();
        public DataSet getDocumentStatus(string DocumentNumber)
        {
            try
            {
                string str = null;
                if (!string.IsNullOrEmpty(DocumentNumber))
                {
                    str = "where ds.docno = '" + DocumentNumber + "'";
                }
                ds = FillData("Select ds.docno, max(case when dm.documentcode = 'PTS' then  'Yes' else 'No' end) as PrimaryTitleSearch," +
                                    "max(case when dm.documentcode = 'PN' then  'Yes' else 'No' end) as PublicNotice," +
                                    "max(case when dm.documentcode = 'FTS' then  'Yes' else 'No' end) as FinalTitleSearch," +
                                    "max(case when dm.documentcode = 'ATS' then 'Yes' else 'No' end) as AgreementtoSale," +
                                    "max(case when dm.documentcode = 'ASOL' then  'Yes' else 'No' end) as ApprovedbySolicitor," +
                                    "max(case when dm.documentcode = 'SD' then  'Yes' else 'No' end) as SaleDeed," +
                                    "max(case when dm.documentcode = 'RSR' then 'Yes' else 'No' end) as Registry," +
                                    "max(case when dm.documentcode = 'FM' then  'Yes' else 'No' end) as FinalMutation from documentstatus ds left outer join documentmaster dm on dm.documentcode = ds.documentcode " + str + " group by ds.docno", "DocumentStatus");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getVillages()
        {
            try
            {
                ds = FillData("select 0 as villageid, '0' as villagecode, 'Select' as villagename,'Select' as villagemname  union " +
                              "select villageid,villagecode,villagename,villagemname from village order by villagecode", "village");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getHolderNames(string VillageCode)
        {
            try
            {
                ds = FillData("Select holdername,familyno from familydetailnew where villagecode ='" + VillageCode + "' " + "group by holdername,familyno order by holdername", "familydetailnew");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getSurveyNos(string VillageCode)
        {
            try
            {
                ds = FillData("Select surveyno from familydetailnew where villagecode ='" + VillageCode + "' " + "group by surveyno order by surveyno", "familydetailnew");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getLandClassMaster()
        {
            try
            {
                ds = FillData("Select landclassid,landclasscode, landclassname, landclassmname from landclassmaster", "landclassmaster");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getVillegeSurveyDetails(string VillageCode, string LandClassCode)
        {
            try
            {
                ds = FillData("Select row_number() over(partition by familyno,surveyno order by surveynoarea) as srno,familyno,surveyno,surveynoarea,holdername,holderarea,landclass from familydetailnew where landclass = '" + LandClassCode + "' " + " and villagecode ='" + VillageCode + "' ", "familydetailnew");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getPaymentDetails(string VillageCode)
        {
            try
            {
                ds = FillData("Select row_number() over() as srno, docno,surveyno,familyno,holdername,voucherno,voucherdate,amountpaid,amounttype from paymentdetail where villagecode = '" + VillageCode + "' ", "paymentdetail");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getPaymentDetails(string VillageCode, string FamilyNo)
        {
            try
            {
                ds = FillData("Select row_number() over() as srno, docno,surveyno,familyno,holdername,voucherno,voucherdate,amountpaid,amounttype from paymentdetail where villagecode = '" + VillageCode + "' and familyno = '" + FamilyNo + "'", "paymentdetail");
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

        public DataSet getSummaryOfTitleSearchReport(string VillageCode)
        {
            try
            {
                string strQuery = null;

                if (!string.IsNullOrEmpty(VillageCode))
                {
                    strQuery = " where villagecode = '" + VillageCode + "'";
                }

                ds = FillData("Select count(distinct docno) as \"Documents Planned\", " +
                    "Count(distinct(case when documentcode = 'MSR' then docno else null end)) as \"Mutation Search Report\"," +
                    "Count(distinct(case when documentcode = 'RSR' then docno else null end)) as \"Registry Search Report\"," +
                    "Count(distinct(case when documentcode = 'PTS' then docno else null end)) as \"Primary Title Search\"," +
                    "Count(distinct(case when documentcode = 'PN' then docno else null end)) as \"Public Notice\", " +
                    "Count(distinct(case when documentcode = 'FTS' then docno else null end)) as \"Final Title Search\"," +
                    "Count(distinct(case when documentcode = 'ASOL' then docno else null end)) as \"Approved by Solicitor\"," +
                    "Count(distinct(case when documentcode = 'AC' then docno else null end)) as \"Approved by Client\", " +
                    "Count(distinct(case when documentcode = 'RPN' then docno else null end)) as \"Inputs for Public Notice\"," +
                    "Count(distinct(case when documentcode = 'ODHO' then docno else null end)) as \"Clarifications from Head Office\" from documentstatus" + strQuery, "SummaryOfTitleSearchReport");

                //ds = FillData("Select count(distinct docno) as DocumentsPlanned," +
                //               "Count (distinct(case when documentcode = 'MSR' then docno else null end)) as MutationSearchReport, " +
                //                "Count (distinct(case when documentcode = 'RSR' then docno else null end)) as RegistrySearchReport, " +
                //                "Count (distinct(case when documentcode = 'PTS' then docno else null end)) as PrimaryTitleSearch, " +
                //                "Count (distinct(case when documentcode = 'PN' then docno else null end)) as PublicNotice, " +
                //                "Count (distinct(case when documentcode = 'FTS' then docno else null end)) as FinalTitleSearch, " +
                //                "Count (distinct(case when documentcode = 'ASOL' then docno else null end)) as ApprovedbySolicitor, " +
                //                "Count (distinct(case when documentcode = 'AC' then docno else null end)) as ApprovedbyClient, " +
                //                "Count (distinct(case when documentcode = 'RPN' then docno else null end)) as InputsforPublicNotice, " +
                //                "Count (distinct(case when documentcode = 'ODHO' then docno else null end)) as ClarificationsfromHeadOffice " +
                //                "from documentstatus", "SummaryOfTitleSearchReport");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getSummaryOfDocumentExecutionReport(string VillageCode)
        {
            try
            {
                string strQuery = null;

                if (!string.IsNullOrEmpty(VillageCode))
                {
                    strQuery = " where villagecode = '" + VillageCode + "'";
                }

                ds = FillData("Select count(distinct docno) as \"Documents Planned\", " +
                    "Count (distinct(case when documentcode = 'VP' then  docno else null end)) as \"Visar Pavti\", " +
                    "Count (distinct(case when documentcode = 'ATS' then  docno else null end)) as \"Agreement to Sale\", " +
                    "Count (distinct(case when documentcode = 'SD' then  docno else null end)) as \"Sale Deed\", " +
                    "Count (distinct(case when documentcode = 'RSR' then  docno else null end)) as \"Registry\", " +
                    "Count (distinct(case when documentcode = 'FM' then  docno else null end)) as \"Final Mutation\"," +
                    "Count (distinct(case when documentcode = 'U712' then  docno else null end)) as \"Updated 7/12\" from documentstatus" + strQuery, "SummaryOfDocumentExecutionReport");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getDocumentStatus(string VillageCode, string DocumentNumber)
        {
            try
            {
                ds = FillData("Select max(case when dm.documentcode = 'MSR' then  'Yes' else null end) as MutationSearchReport," +
                                    "max(case when dm.documentcode = 'RSR' then  'Yes' else null end) as RegistrySearchReport," +
                                    "max(case when dm.documentcode = 'PTS' then  'Yes' else null end) as PrimaryTitleSearch," +
                                    "max(case when dm.documentcode = 'PN' then  'Yes' else null end) as PublicNotice," +
                                    "max(case when dm.documentcode = 'FTS' then  'Yes' else null end) as FinalTitleSearch," +
                                    "max(case when dm.documentcode = 'ASOL' then  'Yes' else null end) as ApprovedbySolicitor," +
                                    "max(case when dm.documentcode = 'AC' then  'Yes' else null end) as ApprovedbyClient," +
                                    "max(case when dm.documentcode = 'RPN' then  'Yes' else null end) as InputsforPublicNotice," +
                                    "max(case when dm.documentcode = 'ODHO' then  'Yes' else null end) as ClarificationsfromHeadOffice," +
                                    "max(case when dm.documentcode = 'VP' then 'Yes' else null end) as VisarPavti," +
                                    "max(case when dm.documentcode = 'ATS' then 'Yes' else null end) as AgreementtoSale," +
                                    "max(case when dm.documentcode = 'SD' then  'Yes' else null end) as SaleDeed," +
                                    "max(case when dm.documentcode = 'RSR' then 'Yes' else null end) as Registry," +
                                    "max(case when dm.documentcode = 'FM' then  'Yes' else null end) as FinalMutation," +
                                    "max(case when dm.documentcode = 'U712' then  'Yes' else null end) as Updated712 from documentstatus ds left outer join documentmaster dm on dm.documentcode = ds.documentcode where villagecode = '" + VillageCode + "' and docno = '" + DocumentNumber + "'", "DocumentStatus");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet getMutationRegister(string SerachType, string MutationSurveyNumber)
        {
            try
            {
                if (SerachType == "Mutation")
                {
                    ds = FillData("Select row_number() over() as srno,mutationyear,villagecode,mutationno,mutationdetail,field4,field5,field6,csurveyno as surveynos " +
                                  "from mutationregister where COALESCE(field4,'0') = '0' and COALESCE(field5,'0') = '0' and mutationno = '" + MutationSurveyNumber + "'", "MutationRegister");
                }
                else
                {
                    ds = FillData("select srno, mutationyear, villagecode, mutationno, mutationdetail, field4, field5, field6, searchno as surveynos from(Select row_number() over() as srno, mutationyear, villagecode, mutationno, mutationdetail, field4, field5, field6, csurveyno as surveynos," +
                                   "replace(regexp_split_to_table(csurveyno, ','), ' ', '') as searchno " +
                                   "from mutationregister where COALESCE(field4, '0') = '0' and COALESCE(field5, '0') = '0' and csurveyno like '%" + MutationSurveyNumber + "%') t where searchno = '" + MutationSurveyNumber + "'", "MutationRegister");

                    //ds = FillData("Select row_number() over() as srno,mutationyear,villagecode,mutationno,mutationdetail,field4,field5,field6, csurveyno as surveynos " +
                    //             "from mutationregister where COALESCE(field4,'0') = '0' and COALESCE(field5,'0') = '0' and csurveyno like '%" + MutationSurveyNumber + "%'", "MutationRegister");

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getMutationRegisterDetails(string MutationNo, string VillageCode)
        {
            try
            {
                ds = FillData("Select mutationdetail,field4,field5,field6 from mutationregister where (mutationdetail is not null or field4 is not null or field5 is not null) and csurveyno is null and villagecode = '" + VillageCode + "' and mutationno = '" + MutationNo + "'", "MutationRegisterDetails");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getMutationYearDetails(string MutationSurveyNumber, string VillageCode)
        {
            try
            {
                ds = FillData("Select min(mutationyear) as frommutationyear, max(mutationyear) as tomutationyear from (select srno, mutationyear, villagecode, mutationno, mutationdetail, field4, field5, field6, searchno as surveynos from(Select row_number() over() as srno, mutationyear, villagecode, mutationno, mutationdetail, field4, field5, field6, csurveyno as surveynos," +
                              "replace(regexp_split_to_table(csurveyno, ','), ' ', '') as searchno " +
                               "from mutationregister where COALESCE(field4, '0') = '0' and COALESCE(field5, '0') = '0' and csurveyno like '%" + MutationSurveyNumber + "%') t where searchno = '" + MutationSurveyNumber + "' order by mutationyear, mutationno) Q", "MutationRegister");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getClassOfLandOccupant(string VillageCode, string LandClassCode)
        {
            try
            {
                ds = FillData("Select documentno,familyno,surveyno,surveyarea as surveynoarea,holdername, holderarea from familydetails fd inner join landclassmaster lcm on fd.landclass = lcm.landclasscode where fd.villagecode = '" + VillageCode + "' and fd.landclass = '" + LandClassCode + "' ", "ClassOfLandOccupant");
                // ds = FillData("Select documentno,familyno,surveyno,surveynoarea,holdername, holderarea from familydetailnew fd inner join landclassmaster lcm on fd.landclass = lcm.landclasscode where fd.villagecode = '" + VillageCode + "' and fd.landclass = '" + LandClassCode + "' ", "ClassOfLandOccupant");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getLandClass()
        {
            try
            {
                ds = FillData("Select '0' as landclasscode, 'Select' as landclassname,'Select' as landclassmname union SELECT landclasscode, landclassname,landclassmname FROM landclassmaster order by landclasscode", "LandClassMaster");
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