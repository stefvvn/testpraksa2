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

    public class PostsEF : SqlBaseData, IPosts
    {

        public List<PostEntities> GetJoinedPostList(int loggedInUser)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var posts = db.Post
                    .Include(u => u.User)
                    .Include(a => a.PostLikes)
                    .Include(c => c.Comments)
                    .Include(i => i.Images)
                    .OrderByDescending(u => u.PostId)
                    .ToList();
            return posts;
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
    }
}
