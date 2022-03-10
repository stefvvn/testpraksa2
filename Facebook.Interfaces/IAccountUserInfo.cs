using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Entities;

namespace Facebook.Interfaces
{
    public interface IAccountUserInfo
    {
        AccountUserInfoEntities GetUserByID(int Id);
        AccountUserInfoEntities InsertUser(AccountUserInfoEntities user);
        AccountUserInfoEntities UpdateUserAccountInfo(AccountUserInfoEntities user);
        List<AccountUserInfoEntities> GetUserList();
        AccountUserInfoEntities DeleteUserByID(int Id);
        List<AccountUserInfoEntities> GetUserByCity(string City);
        List<AccountUserInfoEntities> GetUserListById(int Id);
        List<AccountUserInfoEntities> GetUsersMultiParam(string username, string emailaddress, string firstname, string lastname, string city);
        AccountUserInfoEntities UpdateUserById(int Id);
    }
}


