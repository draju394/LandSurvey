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
    public class dbReports : dbConnection
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



        public DataSet getSurveyArea(string surveyno)
        {
            try
            {
                ds = FillData("Select distinct surveyno,surveyarea from familydetails where surveyno in ('" + surveyno + "')", "SurveyArea");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }

        public DataSet getSurveyNos(string VillageCode, string DocNo)
        {
            try
            {
                ds = FillData("Select distinct row_number() over() as id,docno,surveyno,surveyarea,villagecode from familydetails where villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' and surveyarea > 0", "SurveyNos");
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

                    ds = FillData("Select row_number() over() as srno,mutationyear,villagecode,mutationno,mutationdetail,field4,field5,field6,csurveyno,csurveyno as surveynos,mutationid " +

                                  "from mutationregister where COALESCE(field4,'') = '' and COALESCE(field5,'') = '' and csurveyno is not null and mutationno = '" + MutationSurveyNumber + "' order by cast(mutationyear as int),cast(mutationno as int), cast(mutationid as int)", "MutationRegister");

                }

                else
                {

                    ds = FillData("select srno, mutationyear, villagecode, mutationno, mutationdetail, field4, field5, field6,csurveyno, searchno as surveynos, mutationid from(Select row_number() over() as srno, mutationyear, villagecode, mutationno, mutationdetail, field4, field5, field6,csurveyno, csurveyno as surveynos," +

                                   "replace(regexp_split_to_table(csurveyno, ','), ' ', '') as searchno,mutationid " +

                                   "from mutationregister where COALESCE(field4, '') = '' and COALESCE(field5, '') = '' and csurveyno like '%" + MutationSurveyNumber + "%') t where searchno = '" + MutationSurveyNumber + "' order by cast(mutationyear as int),cast(mutationno as int), cast(mutationid as int)", "MutationRegister");

                }

            }

            catch (Exception ex)

            {

                throw ex;

            }

            return ds;

        }



        public DataSet getMutationRegisterDetails(string MutationNo, string VillageCode) //GC

        {

            try

            {

                ds = FillData("Select mutationid, mutationdetail,field4,field5,field6 from mutationregister where (mutationdetail is not null or field4 is not null or field5 is not null) and csurveyno is null and villagecode = '" + VillageCode + "' and mutationno = '" + MutationNo + "' order by mutationid ", "MutationRegisterDetails");

            }

            catch (Exception ex)

            {

                throw ex;

            }

            return ds;

        }

        public DataSet getFamilyDetails(string VillageCode, string DocNo)
        {
            try
            {
                ds = FillData("Select surveyno, holdernamem, surveyarea,familyno from familydetails where villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' ", "familydetails");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
  

        //public DataSet getMutationRegister(string SerachType, string MutationSurveyNumber)

        //{

        //    try

        //    {



        //        if (SerachType == "Mutation")

        //        {

        //            ds = FillData("Select row_number() over() as srno,mutationyear,villagecode,mutationno,mutationdetail,field4,field5,field6,csurveyno,csurveyno as surveynos " +

        //                          "from mutationregister where COALESCE(field4,'') = '' and COALESCE(field5,'') = '' and csurveyno is not null and mutationno = '" + MutationSurveyNumber + "' order by cast(mutationno as int)", "MutationRegister");

        //        }

        //        else

        //        {

        //            ds = FillData("select srno, mutationyear, villagecode, mutationno, mutationdetail, field4, field5, field6,csurveyno, searchno as surveynos from(Select row_number() over() as srno, mutationyear, villagecode, mutationno, mutationdetail, field4, field5, field6,csurveyno, csurveyno as surveynos," +

        //                           "replace(regexp_split_to_table(csurveyno, ','), ' ', '') as searchno " +

        //                           "from mutationregister where COALESCE(field4, '') = '' and COALESCE(field5, '') = '' and csurveyno like '%" + MutationSurveyNumber + "%') t where searchno = '" + MutationSurveyNumber + "' order by cast(mutationno as int)", "MutationRegister");

        //        }

        //    }

        //    catch (Exception ex)

        //    {

        //        throw ex;

        //    }

        //    return ds;

        //}



        //public DataSet getMutationRegisterDetails(string MutationNo, string VillageCode)

        //{

        //    try

        //    {

        //        ds = FillData("Select mutationdetail,field4,field5,field6 from mutationregister where (mutationdetail is not null or field4 is not null or field5 is not null) and csurveyno is null and villagecode = '" + VillageCode + "' and mutationno = '" + MutationNo + "'", "MutationRegisterDetails");

        //    }

        //    catch (Exception ex)

        //    {

        //        throw ex;

        //    }

        //    return ds;

        //}



        public DataSet getMutationYearDetails(string MutationSurveyNumber, string VillageCode)

        {

            try

            {

                ds = FillData("Select min(mutationyear) as frommutationyear, max(mutationyear) as tomutationyear from (select srno, mutationyear, villagecode, mutationno, mutationdetail, field4, field5, field6, searchno as surveynos from(Select row_number() over() as srno, mutationyear, villagecode, mutationno, mutationdetail, field4, field5, field6, csurveyno as surveynos," +

                              "replace(regexp_split_to_table(csurveyno, ','), ' ', '') as searchno " +

                               "from mutationregister where COALESCE(field4, '') = '' and COALESCE(field5, '') = '' and csurveyno like '%" + MutationSurveyNumber + "%') t where searchno = '" + MutationSurveyNumber + "' order by mutationyear, mutationno) Q", "MutationRegister");



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

                ds = FillData("Select docno,familyno,surveyno,surveyarea as surveynoarea,holdername, holderarea from familydetails fd inner join landclassmaster lcm on fd.landclass = lcm.landclasscode where fd.villagecode = '" + VillageCode + "' and fd.landclass = '" + LandClassCode + "' ", "ClassOfLandOccupant");

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

       
        public DataSet getHolderName()
        {
            try
            {
                ds = FillData("select 'Select' as holdernamem  union " +
                              "Select holdernamem from eighta where holdernamem != '' group by holdernamem order by holdernamem", "eighta");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        //public DataSet getEightaDetails(string VillageCode, string HolderName)
        //{
        //    try
        //    {
        //        ds = FillData("Select* from(Select Khatano, Khatanamem, Surveyno, holdernamem, khatanamem, holderarea, assessment, potkharaba, Mutno from eighta where villagecode = '" + VillageCode + "' and holdernamem = '" + HolderName + "' " +
        //            " union " +
        //            " Select '99999' as Khatano, 'एकूण' as holdernamem, Count(1) :: character varying as Surveyno,null as khatanamee,null as khatanamem, sum(holderarea) as holderarea, null as assessment,sum(potkharaba) as potkharaba, null as Mutno from eighta where villagecode = '" + VillageCode + "' and holdernamem = '" + HolderName + "' ) Q order by Khatano", "Eighta");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}

        public DataSet getVillageDetails(string VillageCode)
        {
            try
            {
                ds = FillData("Select v.villagemname, t.talukamname, d.districtmname from village v inner join taluka t on t.talukaid = v.talukaid " +
                              "inner join district d on d.districtid = t.districtid  where v.villagecode = '" + VillageCode + "'", "Eighta");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getDocumentNos()
        {
            try
            {
                ds = FillData("select 0 as dno,'Select' as docno  union " +
                              "Select docno :: integer as dno, docno from familydetails group by docno order by dno", "docno");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        //public DataSet getFamilyDetails(string VillageCode, string DocNo)
        //{
        //    try
        //    {
        //        ds = FillData("Select surveyno, holdername, surveyarea,familyno from familydetails where villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' ", "familydetails");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}

        public DataSet getPaymentInfo(string VillageCode, string DocNo)
        {
            try
            {
                ds = FillData("Select holdername, amountpaid, amtdocumentno, amountdocumentdate, amtbankdetail from paymentdetail where villagecode = '" + VillageCode + "' and docno = '" + DocNo + "' ", "paymentinfo");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getEightaDetails(string VillageCode, string HolderName)
        {
            try
            {
                ds = FillData("Select* from(Select Khatano,surveyarea, Khatanamem, Surveyno, holdernamem, khatanamem, holderarea, assessment, potkharaba, Mutno from eighta where villagecode = '" + VillageCode + "' and holdernamem = '" + HolderName + "' " +
                    " union " +
                    " Select '99999' as Khatano, null as surveyarea, '????' as holdernamem, Count(1) :: character varying as Surveyno,null as khatanamee,null as khatanamem, sum(holderarea) as holderarea, null as assessment,sum(potkharaba) as potkharaba, null as Mutno from eighta where villagecode = '" + VillageCode + "' and holdernamem = '" + HolderName + "' ) Q order by Khatano", "Eighta");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        #region 20191028

        public DataSet getKhatedarNames(string khatano)
        {
            try
            {
                ds = FillData("select khatanamem, khatano, array_to_string(array_agg(distinct holdernamem), ',') as khatedar from eighta where khatano = '" + khatano + "' group by khatano,khatanamem", "Khatedar");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getEightaDetailsByKhataNo(string VillageCode, string khatano)
        {
            try
            {
                ds = FillData("Select * from(Select ROW_NUMBER () OVER (ORDER BY holdernamem) as sr, Khatano,surveyarea, Khatanamem, Surveyno, holdernamem,  holderarea, assessment, potkharaba, Mutno from eighta where villagecode = '" + VillageCode + "' and khatano = '" + khatano + "' " +
                    " union " +
                    " Select 99999 as sr, null as Khatano, sum(surveyarea) as surveyarea, 'Total ' as Khatanamem, Count(1) :: character varying as Surveyno, null as holdernamem, sum(holderarea) as holderarea, null as assessment,sum(potkharaba) as potkharaba, null as Mutno from eighta where villagecode = '" + VillageCode + "' and khatano = '" + khatano + "' ) Q order by sr", "Eighta");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }




        #endregion
        //
    }
}