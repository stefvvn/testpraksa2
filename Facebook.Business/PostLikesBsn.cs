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
        public PostLikeEntities ToggleInsertPostLike(PostLikeEntities postLike)
        {
            IPostLikes data = new PostLikesEF();
            return data.ToggleInsertPostLike(postLike);
        }
        public PostLikeEntities ToggleDeletePostLike(int userId, int postId)
        {
            IPostLikes data = new PostLikesEF();
            return data.ToggleDeletePostLikeById(userId, postId);
        }

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
        public List<PostLikeEntities> GetPostLikesByUserId(int postLikeUserId)
        {
            IPostLikes data = new PostLikesEF();
            return data.GetPostLikesByUserId(postLikeUserId);
        }

    }
}
