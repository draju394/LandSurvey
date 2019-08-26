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


        //
    }
}