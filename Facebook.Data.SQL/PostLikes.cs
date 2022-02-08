using Facebook.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Data.SQL

{
    public class PostLikesData : SqlBaseData
    {
        public PostLikeEntities GetPostLikesByPost(int postId)
        {
            PostLikeEntities postLikes = new PostLikeEntities();
            GetCommand("GetPostLikesByPost");
            AddParameterWithValue("@postId", SqlDbType.Int, postId);
            SqlDataReader dr = Command.ExecuteReader();
            if (dr.Read())
            {
                postLikes.PostId = (int)dr.GetValue(dr.GetOrdinal("postId"));
                postLikes.UserId = (int)dr.GetValue(dr.GetOrdinal("userId"));
                postLikes.PostLikeStatus = (byte)dr.GetValue(dr.GetOrdinal("postLikeStatus"));
            }
            CloseConnection();
            return postLikes;
        }
    }
}