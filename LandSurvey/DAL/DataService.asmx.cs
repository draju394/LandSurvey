using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Data;

namespace LandSurvey.DAL
{
    /// <summary>
    /// Summary description for DataService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DataService : System.Web.Services.WebService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["LANDSURVEY"].ConnectionString;
        [WebMethod]
        public void  GetDistrict()
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["LANDSURVEY"].ConnectionString;
            List<District> District = new List<District>();
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                NpgsqlCommand cmd = new NpgsqlCommand("select districtid, districtmname from district", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    District district = new District();
                    district.districtid = Convert.ToInt32(rdr["districtid"]);
                    district.districtmname = rdr["districtmname"].ToString();
                    District.Add(district);
                    Console.WriteLine(district.districtmname);

                }

            }
            
            JavaScriptSerializer js = new JavaScriptSerializer();

            Context.Response.Write(js.Serialize(District));

        }

        //[WebMethod]
        //public void GetTaluka(int DistrictID)
        //{
        //    //string connectionString = ConfigurationManager.ConnectionStrings["LANDSURVEY"].ConnectionString;
        //    List<Taluka> TalukaList = new List<Taluka>();
        //    using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
        //    {
        //        NpgsqlCommand cmd = new NpgsqlCommand("select talukaid, talukamname from taluka where districtid = @DistrictID", con);
        //        cmd.CommandType = CommandType.Text;
        //        NpgsqlParameter param = new NpgsqlParameter()
        //        {
        //            ParameterName = "@DistrictID",
        //            Value = DistrictID,
        //        };
        //        cmd.Parameters.Add(param);

        //        con.Open();
        //        NpgsqlDataReader rdr = cmd.ExecuteReader();
        //        while (rdr.Read())
        //        {
        //            Taluka taluka = new Taluka();
        //            taluka.talukaid = Convert.ToInt32(rdr["talukaid"]);
        //            taluka.talukamname = rdr["talukamname"].ToString();
        //            //taluka.districtid = Convert.ToInt32(rdr["districtid"]);
        //            TalukaList.Add(taluka);
        //            Console.WriteLine(taluka.talukamname);

        //        }

        //    }

        //    JavaScriptSerializer js = new JavaScriptSerializer();

        //    Context.Response.Write(js.Serialize(TalukaList));

        //}

        [WebMethod]
        public void GetTaluka()
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["LANDSURVEY"].ConnectionString;
            List<Taluka> TalukaList = new List<Taluka>();
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                NpgsqlCommand cmd = new NpgsqlCommand("select talukaid, talukamname from taluka ", con);
                cmd.CommandType = CommandType.Text;
                NpgsqlParameter param = new NpgsqlParameter()
                {
                    //ParameterName = "@DistrictID",
                    //Value = DistrictID,
                };
                cmd.Parameters.Add(param);

                con.Open();
                NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Taluka taluka = new Taluka();
                    taluka.talukaid = Convert.ToInt32(rdr["talukaid"]);
                    taluka.talukamname = rdr["talukamname"].ToString();
                    //taluka.districtid = Convert.ToInt32(rdr["districtid"]);
                    TalukaList.Add(taluka);
                    Console.WriteLine(taluka.talukamname);

                }

            }

            JavaScriptSerializer js = new JavaScriptSerializer();

            Context.Response.Write(js.Serialize(TalukaList));

        }

        [WebMethod]
        public void GetVillage(int TalukaID)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["LANDSURVEY"].ConnectionString;
            List<VIllage> VillageList = new List<VIllage>();
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                NpgsqlCommand cmd = new NpgsqlCommand("select villageid, villagemname, villagecode from village where talukaid = @TalukaID", con);
                cmd.CommandType = CommandType.Text;
                NpgsqlParameter param = new NpgsqlParameter()
                {
                    ParameterName = "@TalukaID",
                    Value = TalukaID,
                };
                cmd.Parameters.Add(param);

                con.Open();
                NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    VIllage village = new VIllage();
                    village.villageid = Convert.ToInt32(rdr["villageid"]);
                    village.villagemname = rdr["villagemname"].ToString();
                    village.villagecode = rdr["villagecode"].ToString();
                    //taluka.districtid = Convert.ToInt32(rdr["districtid"]);
                    VillageList.Add(village);
                    Console.WriteLine(village.villagemname);

                }

            }

            JavaScriptSerializer js = new JavaScriptSerializer();

            Context.Response.Write(js.Serialize(VillageList));

        }
        [WebMethod]
        public void GetFamilyNo(string VillageCode)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["LANDSURVEY"].ConnectionString;
            List<familyMaster> FamilyMasterList = new List<familyMaster>();
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                NpgsqlCommand cmd = new NpgsqlCommand("select familymasterid, familyno,totalarea,status from familymaster where villagecode = @VillageCode", con);
                cmd.CommandType = CommandType.Text;
                NpgsqlParameter param = new NpgsqlParameter()
                {
                    ParameterName = "@VillageCode",
                    Value = VillageCode,
                };
                cmd.Parameters.Add(param);

                con.Open();
                NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    familyMaster familyM = new familyMaster();
                    familyM.familymasterid = Convert.ToInt32(rdr["familymasterid"]);
                    familyM.familyno = rdr["familyno"].ToString();
                    familyM.totalarea = Convert.ToDouble(rdr["totalarea"]);
                    familyM.status = rdr["status"].ToString();
                    FamilyMasterList.Add(familyM);
                   

                }

            }

            JavaScriptSerializer js = new JavaScriptSerializer();

            Context.Response.Write(js.Serialize(FamilyMasterList));

        }
        // Family Survey Details 

        [WebMethod]
        public void GetFamilySurveyNo(string FamilyNo, string VillageCode)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["LANDSURVEY"].ConnectionString;
            List<familySurvey> FamilySurveyList = new List<familySurvey>();
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                NpgsqlCommand cmd = new NpgsqlCommand("select familysurveyid, surveyno, familyno from familysurvey where familyno = @FamilyNo and villagecode = '"+ VillageCode +"' ", con);
                cmd.CommandType = CommandType.Text;

                NpgsqlParameter param = new NpgsqlParameter()
                {

                    ParameterName = "@FamilyNo",
                    Value = FamilyNo,
                    
                    
                };
                cmd.Parameters.Add(param);

                con.Open();
                NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    familySurvey familySu = new familySurvey();

                    familySu.familysurveyid = Convert.ToInt32(rdr["familysurveyid"]);
                    familySu.familyno = rdr["familyno"].ToString();
                    familySu.surveyno = rdr["surveyno"].ToString();

                    FamilySurveyList.Add(familySu);


                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(FamilySurveyList));

        }
        //

        // fill grid  

        [WebMethod]
        public void GetFamilyDetailsGrid(string SurveyNo, string VillageCode)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["LANDSURVEY"].ConnectionString;
            List<familyDetails> FamilyDetailsGridList = new List<familyDetails>();
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                //select surveyno, villagecode, holdername, holderarea, areaaquired from familydetails where surveyno = '55' and villagecode = '10'
                NpgsqlCommand cmd = new NpgsqlCommand("select surveyno, villagecode, holdername, holderarea, areaaquired from familydetails where surveyno = @SurveyNo and villagecode = '" + VillageCode + "' ", con);
                cmd.CommandType = CommandType.Text;

                NpgsqlParameter param = new NpgsqlParameter()
                {

                    ParameterName = "@SurveyNo",
                    Value = SurveyNo,


                };
                cmd.Parameters.Add(param);

                con.Open();
                NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    familyDetails familyDetailsGrid = new familyDetails();

                    familyDetailsGrid.surveyno = rdr["surveyno"].ToString();
                    familyDetailsGrid.villagecode = Convert.ToInt32(rdr["villagecode"].ToString());
                    familyDetailsGrid.holdername = rdr["holdername"].ToString();
                //    familyDetailsGrid.holderarea = Convert.ToDouble(rdr["holderarea"].ToString());
                //    familyDetailsGrid.areaaquired = Convert.ToDouble(rdr["areaaquired"].ToString());

                    FamilyDetailsGridList.Add(familyDetailsGrid);

                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(FamilyDetailsGridList));
           // return FamilyDetailsGridList.ToArray();

        }


        [WebMethod]
        public static string GetFamilyDetailsGridNew(string SurveyNo, string VillageCode)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LANDSURVEY"].ConnectionString;
            List<familyDetails> FamilyDetailsGridList = new List<familyDetails>();
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand cmd1 = new NpgsqlCommand())
                {
                    cmd1.CommandText = "select surveyno, villagecode, holdername, holderarea, areaaquired from familydetails where surveyno = '" + SurveyNo + "' and villagecode = '" + VillageCode + "' ";
                    cmd1.Connection = con;
                    using (NpgsqlDataAdapter sda = new NpgsqlDataAdapter(cmd1))
                    {

                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        return ds.GetXml();
                    }
                }
                    //select surveyno, villagecode, holdername, holderarea, areaaquired from familydetails where surveyno = '55' and villagecode = '10'
                   // NpgsqlCommand cmd = new NpgsqlCommand("select surveyno, villagecode, holdername, holderarea, areaaquired from familydetails where surveyno = @SurveyNo and villagecode = '" + VillageCode + "' ", con);
                //cmd.CommandType = CommandType.Text;

                //NpgsqlParameter param = new NpgsqlParameter()
               // {

                 //   ParameterName = "@SurveyNo",
                   /// Value = SurveyNo,


                //};
                //cmd.Parameters.Add(param);

                //con.Open();
                //NpgsqlDataReader rdr = cmd.ExecuteReader();
                //while (rdr.Read())
                //{
                  //  familyDetails familyDetailsGrid = new familyDetails();

                    //familyDetailsGrid.surveyno = rdr["surveyno"].ToString();
                    //familyDetailsGrid.villagecode = Convert.ToInt32(rdr["villagecode"].ToString());
                    //familyDetailsGrid.holdername = rdr["holdername"].ToString();
                    //    familyDetailsGrid.holderarea = Convert.ToDouble(rdr["holderarea"].ToString());
                    //    familyDetailsGrid.areaaquired = Convert.ToDouble(rdr["areaaquired"].ToString());

                    //FamilyDetailsGridList.Add(familyDetailsGrid);

                //}
            }
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //Context.Response.Write(js.Serialize(FamilyDetailsGridList));
            // return FamilyDetailsGridList.ToArray();

        }

        //
    }
}
