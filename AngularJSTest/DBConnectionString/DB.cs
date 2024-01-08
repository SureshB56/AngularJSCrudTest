using AngularJSTest.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace AngularJSTest.DBConnectionString
{
    public class DB : SqlConnectionSetting
    {
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        // Add Record

        public int PostUserInfo(UserInfo UserInfo)
        {

            using (IDbConnection con = SqlConn)
            {
                con.Open();
                var UserParam = new DynamicParameters();
                UserParam.Add("@Action", "Insert");
                UserParam.Add("@UserTableID", UserInfo.UserTableID);
                UserParam.Add("@FirstName", UserInfo.FirstName);
                UserParam.Add("@LastName", UserInfo.LastName);
                UserParam.Add("@Email", UserInfo.Email);
                UserParam.Add("@PhoneNumber", UserInfo.PhoneNumber);
                UserParam.Add("@Address", UserInfo.Address);
                UserParam.Add("@City", UserInfo.City);
                UserParam.Add("@State", UserInfo.State);
                UserParam.Add("@Country", UserInfo.Country);
                UserParam.Add("@PostalCode", UserInfo.PostalCode);
                UserParam.Add("@IsSucced", dbType: DbType.Int64, direction: ParameterDirection.Output);
                var query = con.Execute("UspUserInsertDetails", UserParam, commandType: CommandType.StoredProcedure);
                var output = UserParam.Get<Int64>("@IsSucced");
                return Convert.ToInt32(output);
            }

        }
        //Display all record

        public List<UserInfo> GetUserRoleList(string Name, string Email, string PhoneNumber)
        {
            using (IDbConnection con = SqlConn)
            {
                con.Open();

                var UserParam = new DynamicParameters();
                UserParam.Add("@Name", Name);
                UserParam.Add("@Email", Email);
                UserParam.Add("@PhoneNumber", PhoneNumber);

                List<UserInfo> UserRoleList = con.Query<UserInfo>("GetUserRoles", UserParam, commandType: CommandType.StoredProcedure).ToList();

                con.Close();
                return UserRoleList;
            }
        } 




        // Delete record

        //public void deletedata(int id)

        //{

        //    SqlCommand com = new SqlCommand("Sp_register_delete", con);

        //    com.CommandType = CommandType.StoredProcedure;

        //    com.Parameters.AddWithValue("@Sr_no", id);

        //    con.Open();

        //    com.ExecuteNonQuery();

        //    con.Close();

        //}

    }
}