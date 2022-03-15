using Facebook.Data.EntityFramework;
using Facebook.Data.SQL;
using Facebook.Entities;
using Facebook.Interfaces;

namespace Facebook.Business
{
    public class AccountUserInfoBsn
    {
        public AccountUserInfoEntities InsertUser(AccountUserInfoEntities user)
        {
            IAccountUserInfo data = new AccountUserInfoData();

            return data.InsertUser(user);
        }

        public AccountUserInfoEntities GetUserByID(int Id)
        {
            AccountUserInfoData data = new AccountUserInfoData();
            return data.GetUserByID(Id);

            //IAccountUserInfo data = new AccountUserInfoEF();
            //return data.GetUserByID(Id);
        }

        public AccountUserInfoEntities UpdateUserAccountInfo(AccountUserInfoEntities user)
        {
            IAccountUserInfo data = new AccountUserInfoData();
            return data.UpdateUserAccountInfo(user);
        }

        public AccountUserInfoEntities DeleteUserByID(int Id)
        {
            IAccountUserInfo data = new AccountUserInfoData();
            return data.DeleteUserByID(Id);
        }

        public List<AccountUserInfoEntities> GetUserList()
        {
            IAccountUserInfo data = new AccountUserInfoEF();
            return data.GetUserList();
        }

        public List<AccountUserInfoEntities> GetUserByCity(string City)
        {
            IAccountUserInfo data = new AccountUserInfoData();
            return data.GetUserByCity(City);
        }

        public List<AccountUserInfoEntities> GetUserListById(int Id)
        {
            IAccountUserInfo data = new AccountUserInfoData();
            return data.GetUserListById(Id);
        }
        public List<AccountUserInfoEntities> GetUsersMultiParam(string username, string emailaddress, string firstname, string lastname, string city)
        {
            IAccountUserInfo data = new AccountUserInfoData();
            return data.GetUsersMultiParam(username, emailaddress, firstname, lastname, city);
        }
    }
}