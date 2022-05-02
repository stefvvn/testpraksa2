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
    public class PostLikesEF : SqlBaseData, IPostLikes
    {
        public List<PostLikeEntities> GetPostLikes()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return db.PostLike.ToList();
        }
        public List<PostLikeEntities> GetPostLikesByPostId(int postId)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return (List<PostLikeEntities>)db.Post.Where(u => u.PostId == postId);
        }

        public PostLikeEntities InsertPostLike(PostLikeEntities postLike)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            Db.PostLike.Add(postLike);
            Db.SaveChanges();
            return postLike;
        }

        public PostLikeEntities UpdatePostLike(PostLikeEntities postLike)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            Db.PostLike.Update(postLike);
            Db.SaveChanges();
            return postLike;
        }

        public PostLikeEntities DeletePostLikeById(int postLikeId)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            Db.PostLike.Where(u => u.PostLikeId == postLikeId);
            return DeletePostLikeById(postLikeId);
        }
    }
}
