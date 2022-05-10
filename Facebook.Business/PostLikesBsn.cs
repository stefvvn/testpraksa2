using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Data.SQL;
using Facebook.Data.EntityFramework;
using Facebook.Entities;
using Facebook.Interfaces;

namespace Facebook.Business
{
    public class PostLikesBsn
    {
        public List<PostLikeEntities> GetPostLikes()
        {
            IPostLikes data = new PostLikesEF();
            return data.GetPostLikes();
        }
        public List<PostLikeEntities> GetPostLikesByPostId(int postId)
        {
            IPostLikes data = new PostLikesEF();
            return data.GetPostLikesByPostId(postId);
        }

        public PostLikeEntities InsertPostLike(PostLikeEntities postLike)
        {
            IPostLikes data = new PostLikesEF();
            return data.InsertPostLike(postLike);
        }

        public PostLikeEntities DeletePostLikeById(int postLikeId)
        {
            IPostLikes data = new PostLikesEF();
            return data.DeletePostLikeById(postLikeId);
        }
        //public PostLikeEntities ToggleLike(int postId, int userId)
        //{
        //    IPostLikes data = new PostLikesEF();
        //    return data.ToggleLike(postId, userId);
        //}
        public List<PostLikeEntities> GetPostLikesByUserId(int postLikeUserId)
        {
            IPostLikes data = new PostLikesEF();
            return data.GetPostLikesByUserId(postLikeUserId);
        }

    }
}
