using Facebook.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Interfaces
{
    public interface ICommentLikes
    {
        CommentLikeEntities InsertCommentLike(CommentLikeEntities commentLike);
        CommentLikeEntities UpdateCommentLike(CommentLikeEntities commentLike);
        List<CommentLikeEntities> GetCommentLikesForComment(int commentId);
        CommentLikeEntities ToggleCommentLikeDelete(int userId, int commentId);
    }
}
