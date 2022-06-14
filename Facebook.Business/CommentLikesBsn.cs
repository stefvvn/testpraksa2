using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Data.EntityFramework;
using Facebook.Data.SQL;
using Facebook.Entities;
using Facebook.Interfaces;


namespace Facebook.Business
{
    public class CommentLikesBsn
    {

        public CommentLikeEntities ToggleCommentLikeDelete (int userId, int commentId)
        {
            ICommentLikes data = new CommentLikesEF();
            return data.ToggleCommentLikeDelete(userId, commentId);
        }
        public CommentLikeEntities InsertCommentLike(CommentLikeEntities commentLike)
        {
            ICommentLikes data = new CommentLikesEF();
            return data.InsertCommentLike(commentLike);
        }

        public CommentLikeEntities UpdateCommentLike(CommentLikeEntities commentLike)
        {
            ICommentLikes data = new CommentLikesEF();
            return data.UpdateCommentLike(commentLike);
        }

        public List<CommentLikeEntities> GetCommentLikesForComment(int commentId)
        {
            ICommentLikes data = new CommentLikesEF();
            return data.GetCommentLikesForComment(commentId);
        }
    }
}
