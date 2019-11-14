using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using LandSurvey.DAL;
using Npgsql;
using NpgsqlTypes;

namespace LandSurvey.DAL
{
    public class dbUser :dbConnection
    {
        DataSet ds = new DataSet();
        DataSet dsSysParam = new DataSet();
        DataSet dsUserDataOnRole = new DataSet();
        DataSet dsUserDetails = new DataSet();
        string UserSquId = null;

        public int LoginID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UFName { get; set; }
        public string UMName { get; set; }
        public string USName { get; set; }
        public string UserFname { get; set; }
        public int LogType { get; set; }
        public string UserStatus { get; set; }
        public string UCreatedBy { get; set; }
        public DateTime UCreatedDate { get; set; }
        public int ULoginAttemp { get; set; }
        public Int64 ULandLine { get; set; }
        public DateTime UDOB { get; set; }
        public DateTime UJoinDate { get; set; }
        public Int64 UMobile1 { get; set; }
        public Int64 UMobile2 { get; set; }
        public string UAddressP { get; set; }
        public string UAddressC { get; set; }
        public string UEmail { get; set; }
        public int ULastCSN { get; set; }
        public string UModifiedBy { get; set; }
        public DateTime UModifiedDate { get; set; }
        public string UTitle { get; set; }
        public int UCityIdC { get; set; }
        public int UCityIdP { get; set; }
        public string UGender { get; set; }
        public string UReamrk { get; set; }

        public bool ValidRegLogUser()
        {
            bool _UserValid = false;

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;
                //cmd.CommandText = "Select * from RegLogUser where username=@userName and Password=@UserPassword";
                cmd.CommandText = "Select * from tbusermaster where username=@userName and upassword=@UserPassword";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@userName", NpgsqlDbType.Text).Value = UserName;
                cmd.Parameters.Add("@UserPassword", NpgsqlDbType.Text).Value = Password;

                try
                {
                    conReader = cmd.ExecuteReader();

                    while (conReader.Read())
                    {
                        LoginID = Convert.ToInt32(conReader["userid"]);
                        LogType = Convert.ToInt32(conReader["type"]);
                        UserFname = conReader["fullname"].ToString();
                        ULastCSN = Convert.ToInt32(conReader["lastcsn"]);
                        //LogType = (bool)conReader["type"];
                        _UserValid = true;
                    }
                }
                catch (Exception ex)
                {

                    errorTransaction();
                    throw new ApplicationException("Something wrong happened in the Login module :", ex);
                }
                finally
                {
                    conReader.Close();
                    closeConnection();
                }
            }

            return _UserValid;
        }

        public string GetMobileNo()
        {
            string UserMobileNo = "";
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                openConnection();
                NpgsqlDataReader conReader;
                conReader = null;
                cmd.CommandText = "Select mobile1 from tbusermaster where username=@userName";
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@userName", NpgsqlDbType.Text).Value = UserName;
                
                try
                {
                    conReader = cmd.ExecuteReader();

                    while (conReader.Read())
                    {
                        
                        if (string.IsNullOrEmpty(conReader["mobile1"].ToString()) )
                        {
                            UserMobileNo = "";
                        }
                        else {
                            Int64 MobileNo = Convert.ToInt64(conReader["mobile1"]);
                            UserMobileNo = MobileNo.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {

                    errorTransaction();
                    throw new ApplicationException("Something wrong happened in the Login module :", ex);
                }
                finally
                {
                    conReader.Close();
                    closeConnection();
                }
            }


            return UserMobileNo;

        }

        public DataSet SysParam()
        {
            try
            {
                dsSysParam = FillData("Select * from sysparam", "paymentdetail");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsSysParam;

        }

        public DataSet GetUserBasedOnRole(string UserRoletype)
        {
            try
            {
                dsUserDataOnRole = FillData("Select * from tbusermaster where type = '" + UserRoletype +"' ", "tbusermaster");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsUserDataOnRole;

        }

        public DataSet GetUserDetails()
        {
            try
            {
                //dsUserDetails = FillData("Select * from tbusermaster", "tbusermaster");
                //select fullname,username,(CASE type WHEN 1 THEN 'HeadOffice' WHEN 2 THEN 'Site Office One' WHEN 3 THEN 'Site Office Two'
                //WHEN 5 THEN 'Client' WHEN 4 THEN 'Solicitor' WHEN 5 THEN 'Finance' END) as type , CASE status WHEN 'A' THEN 'Active' ELSE 'InActive' END, mobile1,email, dob, joiningdate
                //from tbusermaster
                dsUserDetails = FillData("select fullname,username,(CASE type WHEN 1 THEN 'HeadOffice' WHEN 2 THEN 'Site Office One' WHEN 3 THEN 'Site Office Two' "+
                    " WHEN 5 THEN 'Client' WHEN 4 THEN 'Solicitor' WHEN 5 THEN 'Finance' END) as type , (CASE status WHEN 'A' THEN 'Active' ELSE 'InActive' END) as status, mobile1,email, dob, joiningdate " +
                    "from tbusermaster order by fullname  ", "tbusermaster");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsUserDetails;

        }

        //
    }
}