using Facebook.Data.SQL;
using Facebook.Entities;

namespace Facebook.Business
{
    public class AccountUserInfoBsn
    {
        public AccountUserInfoEntities InsertUser(AccountUserInfoEntities user)
        {
            AccountUserInfoData data = new AccountUserInfoData();
            return data.InsertUser(user);
        }
        public AccountUserInfoEntities GetUserByID(int Id)
        {
            AccountUserInfoData data = new AccountUserInfoData();
            return data.GetUserByID(Id);
        }
        public AccountUserInfoEntities UpdateUserAccountInfo(AccountUserInfoEntities user)
        {
            AccountUserInfoData data = new AccountUserInfoData();
            return data.UpdateUserAccountInfo(user);
        }
        public AccountUserInfoEntities DeleteUserByID(int Id)
        {
            AccountUserInfoData data = new AccountUserInfoData();
            return data.DeleteUserByID(Id);
        }
        public List<AccountUserInfoEntities> GetUserList()
        {
            AccountUserInfoData data = new AccountUserInfoData();
            return data.GetUserList();
        }
        public List<AccountUserInfoEntities> GetUserByCity(string City)
        {
            AccountUserInfoData data = new AccountUserInfoData();
            return data.GetUserByCity(City);
        }
        public List<AccountUserInfoEntities> GetUserById(int Id)
        {
            AccountUserInfoData data = new AccountUserInfoData();
            return data.GetUserById(Id);
        }
        public List<AccountUserInfoEntities> GetUsersMultiParam(string username, string emailaddress, string firstname, string lastname, string city)
        {
            AccountUserInfoData data = new AccountUserInfoData();
            return data.GetUsersMultiParam(username, emailaddress, firstname, lastname, city);
        }
    }
}