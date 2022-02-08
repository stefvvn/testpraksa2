using Facebook.Data.SQL;
using Facebook.Entities;
using Facebook.Interfaces;

namespace Facebook.Data.EntityFramework
{
    public class AccountUserInfoEF : SqlBaseData, IAccountUserInfo
    {
        public AccountUserInfoEntities DeleteUserByID(int Id)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            Db.User.Where(u => u.UserIdNumber == Id);
            return DeleteUserByID(Id);
        }

        public List<AccountUserInfoEntities> GetUserByCity(string City)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            return (List<AccountUserInfoEntities>)Db.User.Where(u => u.City == City);
        }

        public AccountUserInfoEntities GetUserByID(int Id)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            return (AccountUserInfoEntities)Db.User.Where(u => u.UserIdNumber == Id);
        }

        public List<AccountUserInfoEntities> GetUserById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<AccountUserInfoEntities> GetUserList()
        {
            throw new NotImplementedException();
        }

        public List<AccountUserInfoEntities> GetUsersMultiParam(string username, string emailaddress, string firstname, string lastname, string city)
        {
            throw new NotImplementedException();
        }

        public AccountUserInfoEntities InsertUser(AccountUserInfoEntities user)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            Db.User.Add(user);
            Db.SaveChanges();
            return user;
        }

        public AccountUserInfoEntities UpdateUserAccountInfo(AccountUserInfoEntities user)
        {
            throw new NotImplementedException();
        }
        public AccountUserInfoEntities UpdateUserById(int Id)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            return (AccountUserInfoEntities)Db.User.Where(u => u.UserIdNumber == Id);
        }
    }

}