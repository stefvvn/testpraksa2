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
            return (List<PostLikeEntities>)db.PostLike.Where(u => u.PostId == postId);
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
        public List<PostLikeEntities> GetPostLikesByUserId(int postLikeUserId)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            return Db.PostLike.Where(u => u.UserId == postLikeUserId).ToList();
        }

        public PostLikeEntities ToggleInsertPostLike(PostLikeEntities postLike)
        {
            throw new NotImplementedException();
        }

        public PostLikeEntities ToggleDeletePostLikeById(int userId, int postId)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            PostLikeEntities postlike = Db.PostLike.Where(u => u.UserId == userId && u.PostId == postId).First();
            Db.PostLike.Remove(postlike);
            Db.SaveChanges();
            return postlike;
        }
    }
}
