using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Data.SQL;
using Facebook.Entities;

namespace Facebook.Business
{
    public class PostLikesBsn
    {
        public PostLikeEntities GetPostLikesByPost(int postId)
        {
            PostLikesData data = new PostLikesData();
            return data.GetPostLikesByPost(postId);
        }
    }
}
