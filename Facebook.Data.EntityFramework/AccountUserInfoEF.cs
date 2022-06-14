using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Facebook.Data.SQL;
using Facebook.Entities;
using Facebook.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Facebook.Data.EntityFramework
{
    public class AccountUserInfoEF : SqlBaseData, IAccountUserInfo, ISearch
    {

        public List<AccountUserInfoEntities> SearchUsers(string query)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return db.User.Where(u => u.FirstName.Contains(query) || u.LastName.Contains(query)).ToList();
        }

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

        public List<PostEntities> GetPostList()
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            return Db.Post.ToList();
        }

        public AccountUserInfoEntities GetUserByEmail(string email)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            return Db.User.First(u => u.EmailAddress == email);
        }

        public AccountUserInfoEntities GetLastUser()
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            return Db.User.OrderByDescending(u => u.UserIdNumber).FirstOrDefault();
        }

        public List<PostEntities> SearchPosts(string query)
        {
            throw new NotImplementedException();
        }

        public List<CommentEntities> SearchComments(string query)
        {
            throw new NotImplementedException();
        }
    }
}