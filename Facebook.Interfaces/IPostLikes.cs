using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Entities;

namespace Facebook.Interfaces
{
    public interface IPostLikes
    {
        List<PostLikeEntities> GetPostLikes();
        List<PostLikeEntities> GetPostLikesByPostId(int postId);
        PostLikeEntities InsertPostLike(PostLikeEntities postLike);
        PostLikeEntities UpdatePostLike(PostLikeEntities postLike);
        PostLikeEntities DeletePostLikeById(int postLikeId);
        List<PostLikeEntities> GetPostLikesByUserId(int postLikeUserId);
        //PostLikeEntities ToggleLike(int postId, int userId);
    }
}
