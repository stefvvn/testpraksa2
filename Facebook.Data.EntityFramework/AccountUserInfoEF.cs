using Facebook.Data.SQL;
using Facebook.Entities;
using Facebook.Interfaces;
using System.Linq;

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

        public List<AccountUserInfoEntities> GetUserListById(int Id)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            return (List<AccountUserInfoEntities>)Db.User.Where(u => u.UserIdNumber == Id);
        }

        public List<AccountUserInfoEntities> GetUserList()
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            return Db.User.ToList();
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
            ApplicationDbContext Db = new ApplicationDbContext();
            Db.User.Update(user);
            Db.SaveChanges();
            return user;
        }
        public AccountUserInfoEntities UpdateUserById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<PostEntities> GetPostsByUser(int Id)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            return (List<PostEntities>)Db.Post.Where(u => u.UserId == Id);
        }

        public List<PostEntities> GetJoinedPostList()
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            var q =
                from p in Db.Post
                join u in Db.User on p.UserId equals u.UserIdNumber
                select u;
            return (List<PostEntities>)q;
        }
    }
}