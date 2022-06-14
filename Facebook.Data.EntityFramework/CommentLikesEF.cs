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
    public class CommentLikesEF : SqlBaseData, ICommentLikes
    {
        public CommentLikeEntities InsertCommentLike(CommentLikeEntities commentLike)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            Db.CommentLike.Add(commentLike);
            Db.SaveChanges();
            return commentLike;
        }

        public CommentLikeEntities UpdateCommentLike(CommentLikeEntities commentLike)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            Db.CommentLike.Update(commentLike);
            Db.SaveChanges();
            return commentLike;
        }

        public List<CommentLikeEntities> GetCommentLikesForComment(int commentId)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            return Db.CommentLike.Where(x => x.CommentId == commentId).ToList();
        }

        public CommentLikeEntities ToggleCommentLikeDelete(int userId, int commentId)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            CommentLikeEntities commentlike = Db.CommentLike.Where(u => u.UserId == userId && u.CommentId == commentId).First();
            Db.CommentLike.Remove(commentlike);
            Db.SaveChanges();
            return commentlike;
        }

    }
}
