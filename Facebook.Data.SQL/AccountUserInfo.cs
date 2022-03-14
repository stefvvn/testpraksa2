using Facebook.Entities;
using Facebook.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Data.SQL

{
    public class AccountUserInfoData : SqlBaseData, IAccountUserInfo
    {
        public AccountUserInfoEntities GetUserByID(int Id)
        {
            AccountUserInfoEntities user = new AccountUserInfoEntities();
            GetCommand("GetUserById");
            AddParameterWithValue("@userIdNumber", SqlDbType.Int, Id);
            SqlDataReader dr = Command.ExecuteReader();

            if (dr.Read())
            {
                user.UserIdNumber = (int)dr.GetValue(dr.GetOrdinal("userIdNumber"));
                user.UserName = dr.GetValue(dr.GetOrdinal("userName")).ToString();
                user.FirstName = dr.GetValue(dr.GetOrdinal("firstName")).ToString();
                user.City = dr.GetValue(dr.GetOrdinal("city")).ToString();
                user.LastName = dr.GetValue(dr.GetOrdinal("lastName")).ToString();
                user.Gender = (byte)dr.GetValue(dr.GetOrdinal("gender"));
                user.DateOfBirth = (DateTime)dr.GetValue(dr.GetOrdinal("dateOfBirth"));
                user.ProfileDescription = dr.GetValue(dr.GetOrdinal("profileDescription")).ToString();
                user.EmailAddress = dr.GetValue(dr.GetOrdinal("emailAddress")).ToString();
                user.DateMade = (DateTime)dr.GetValue(dr.GetOrdinal("dateMade"));
            }
            CloseConnection();
            return user;
        }
        public AccountUserInfoEntities InsertUser(AccountUserInfoEntities user)
        {
            GetCommand("InsertUser");
            {
                AddParameterWithValue("@userName", SqlDbType.VarChar, user.UserName);
                AddParameterWithValue("@firstName", SqlDbType.VarChar, user.FirstName);
                AddParameterWithValue("@lastName", SqlDbType.VarChar, user.LastName);
                AddParameterWithValue("@emailAddress", SqlDbType.VarChar, user.EmailAddress);
                AddParameterWithValue("@city", SqlDbType.VarChar, user.City);
                AddParameterWithValue("@gender", SqlDbType.TinyInt, user.Gender);
                AddParameterWithValue("@dateOfBirth", SqlDbType.DateTime, user.DateOfBirth);
                AddParameterWithValue("@profileDescription", SqlDbType.Text, user.ProfileDescription);
                Command.ExecuteNonQuery();
            }
            return user;
        }
        public AccountUserInfoEntities UpdateUserAccountInfo(AccountUserInfoEntities user)
        {
            GetCommand("UpdateUserAccountInfo");
            {
                AddParameterWithValue("@userIdNumber", SqlDbType.Int, user.UserIdNumber);
                AddParameterWithValue("@userName", SqlDbType.VarChar, user.UserName);
                AddParameterWithValue("@firstName", SqlDbType.VarChar, user.FirstName);
                AddParameterWithValue("@lastName", SqlDbType.VarChar, user.LastName);
                AddParameterWithValue("@emailAddress", SqlDbType.VarChar, user.EmailAddress);
                AddParameterWithValue("@city", SqlDbType.VarChar, user.City);
                AddParameterWithValue("@gender", SqlDbType.TinyInt, user.Gender);
                AddParameterWithValue("@dateOfBirth", SqlDbType.DateTime, user.DateOfBirth);
                AddParameterWithValue("@profileDescription", SqlDbType.Text, user.ProfileDescription);
                Command.ExecuteNonQuery();
            }
            return user;
        }
        public List<AccountUserInfoEntities> GetUserList()
        {
            List<AccountUserInfoEntities> users = new List<AccountUserInfoEntities>();
            GetCommand("GetAllUsers");
            SqlDataReader dr = Command.ExecuteReader();
            while (dr.Read())
            {
                AccountUserInfoEntities user = new AccountUserInfoEntities();
                user.UserIdNumber = (int)dr.GetValue(dr.GetOrdinal("userIdNumber"));
                user.FirstName = dr.GetValue(dr.GetOrdinal("firstName")).ToString();
                user.City = dr.GetValue(dr.GetOrdinal("city")).ToString();
                user.LastName = dr.GetValue(dr.GetOrdinal("lastName")).ToString();
                user.Gender = (byte)dr.GetValue(dr.GetOrdinal("gender"));
                user.DateOfBirth = (DateTime)dr.GetValue(dr.GetOrdinal("dateOfBirth"));
                user.ProfileDescription = dr.GetValue(dr.GetOrdinal("profileDescription")).ToString();
                user.EmailAddress = dr.GetValue(dr.GetOrdinal("emailAddress")).ToString();
                user.DateMade = (DateTime)dr.GetValue(dr.GetOrdinal("dateMade"));
                user.UserName = dr.GetValue(dr.GetOrdinal("username")).ToString();
                users.Add(user);
            }
            dr.Close();
            return users;
        }
        public AccountUserInfoEntities DeleteUserByID(int Id)
        {
            AccountUserInfoEntities user = new AccountUserInfoEntities();
            GetCommand("DeleteUserById");
            AddParameterWithValue("@UserIdNumber", SqlDbType.Int, Id);
            Command.ExecuteNonQuery();
            return user;
        }
        public List<AccountUserInfoEntities> GetUserByCity(string City)
        {
            List<AccountUserInfoEntities> users = new List<AccountUserInfoEntities>();
            GetCommand("GetUserByCity");
            AddParameterWithValue("@city", SqlDbType.VarChar, City);
            SqlDataReader dr = Command.ExecuteReader();
            while (dr.Read())
            {
                AccountUserInfoEntities user = new AccountUserInfoEntities();
                user.UserIdNumber = (int)dr.GetValue(dr.GetOrdinal("userIdNumber"));
                user.EmailAddress = dr.GetValue(dr.GetOrdinal("emailAddress")).ToString();
                user.FirstName = dr.GetValue(dr.GetOrdinal("firstName")).ToString();
                user.City = dr.GetValue(dr.GetOrdinal("city")).ToString();
                user.LastName = dr.GetValue(dr.GetOrdinal("lastName")).ToString();
                user.UserName = dr.GetValue(dr.GetOrdinal("userName")).ToString();
                users.Add(user);
            }
            dr.Close();
            return users;
        }
        public List<AccountUserInfoEntities> GetUserListById(int Id)
        {
            List<AccountUserInfoEntities> users = new List<AccountUserInfoEntities>();
            GetCommand("GetUserById");
            AddParameterWithValue("@userIdNumber", SqlDbType.Int, Id);
            SqlDataReader dr = Command.ExecuteReader();
            while (dr.Read())
            {
                AccountUserInfoEntities user = new AccountUserInfoEntities();
                //user.UserIdNumber = (int)dr.GetValue(dr.GetOrdinal("userIdNumber"));
                user.UserIdNumber = dr.GetIntValue("userIdNumber");
                user.UserName = dr.GetValue(dr.GetOrdinal("userName")).ToString();
                user.FirstName = dr.GetValue(dr.GetOrdinal("firstName")).ToString();
                user.City = dr.GetValue(dr.GetOrdinal("city")).ToString();
                user.LastName = dr.GetValue(dr.GetOrdinal("lastName")).ToString();
                user.Gender = (byte)dr.GetValue(dr.GetOrdinal("gender"));
                user.DateOfBirth = (DateTime)dr.GetValue(dr.GetOrdinal("dateOfBirth"));
                user.ProfileDescription = dr.GetValue(dr.GetOrdinal("profileDescription")).ToString();
                user.EmailAddress = dr.GetValue(dr.GetOrdinal("emailAddress")).ToString();
                user.DateMade = (DateTime)dr.GetValue(dr.GetOrdinal("dateMade"));
                users.Add(user);
            }
            dr.Close();
            return users;
        }

        public List<AccountUserInfoEntities> GetUsersMultiParam(string username, string emailaddress, string firstname, string lastname, string city)
        {
            List<AccountUserInfoEntities> users = new List<AccountUserInfoEntities>();
            GetCommand("GetUsersMultiParam");
            AddParameterWithValue("@userName", SqlDbType.VarChar, username);
            AddParameterWithValue("@emailAddress", SqlDbType.VarChar, emailaddress);
            AddParameterWithValue("@firstName", SqlDbType.VarChar, firstname);
            AddParameterWithValue("@lastName", SqlDbType.VarChar, lastname);
            AddParameterWithValue("@city", SqlDbType.VarChar, city);
            SqlDataReader dr = Command.ExecuteReader();
            while (dr.Read())
            {
                AccountUserInfoEntities user = new AccountUserInfoEntities();
                user.UserIdNumber = (int)dr.GetValue(dr.GetOrdinal("userIdNumber"));
                user.UserName = dr.GetValue(dr.GetOrdinal("username")).ToString();
                user.EmailAddress = dr.GetValue(dr.GetOrdinal("emailAddress")).ToString();
                user.FirstName = dr.GetValue(dr.GetOrdinal("firstName")).ToString();
                user.LastName = dr.GetValue(dr.GetOrdinal("lastName")).ToString();
                user.City = dr.GetValue(dr.GetOrdinal("city")).ToString();
                user.Gender = (byte)dr.GetValue(dr.GetOrdinal("gender"));
                user.DateOfBirth = (DateTime)dr.GetValue(dr.GetOrdinal("dateOfBirth"));
                user.ProfileDescription = dr.GetValue(dr.GetOrdinal("profileDescription")).ToString();
                user.DateMade = (DateTime)dr.GetValue(dr.GetOrdinal("dateMade"));
                users.Add(user);
            }
            dr.Close();
            return users;
        }

        public AccountUserInfoEntities UpdateUserById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}

