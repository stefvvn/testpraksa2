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

    public class PostsEF : SqlBaseData, IPosts, ISearch
    {

        public List<PostEntities> SearchPosts(string query)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return db.Post.Where(p => p.Title.Contains(query) || p.Content.Contains(query)).ToList();
        }

        public List<PostEntities> GetPostsByUser(int Id)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            return (List<PostEntities>)Db.Post.Where(u => u.UserId == Id);
        }

        public PostEntities UpdatePost(PostEntities post)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            Db.Post.Update(post);
            Db.SaveChanges();
            return post;
        }




        public List<PostEntities> GetJoinedPostList(int loggedInUser)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            return db.Post
                    .Include(u => u.User)
                    .Include(b => b.PostLikes)
                    .Include(c => c.Comments)
                        .ThenInclude(p => p.CommentLikes)
                    .OrderByDescending(u => u.PostId)
                    .ToList();
        }

 
        public PostEntities InsertPost(PostEntities post)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            Db.Post.Add(post);
            Db.SaveChanges();
            return post;
        }

        public PostEntities DeletePostByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<PostEntities> GetPostList()
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            return Db.Post.ToList();
        }

        public PostEntities GetPostByID(int id)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            return (PostEntities)Db.Post.Where(i => i.PostId == id);
        }

        public PostEntities GetLastPost()
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            return Db.Post.OrderByDescending(p => p.PostId).FirstOrDefault();
        }

        public List<AccountUserInfoEntities> SearchUsers(string query)
        {
            throw new NotImplementedException();
        }

        public List<CommentEntities> SearchComments(string query)
        {
            throw new NotImplementedException();
        }
    }
}
