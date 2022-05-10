using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Data.SQL;
using Facebook.Entities;
using Facebook.Interfaces;
using System.Linq;


namespace Facebook.Data.EntityFramework
{
    public class PostsEF : SqlBaseData, IPosts
    {
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

        public List<PostEntities> GetJoinedPostList()
        {
            throw new NotImplementedException();
        }

        public PostEntities GetPostByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
