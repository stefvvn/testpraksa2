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
    public class PostData : SqlBaseData
    {
        public PostEntities GetPostByID(int Id)
        {
            PostEntities post = new PostEntities();
            GetCommand("GetPostByID");
            {
                Command.Parameters.Add("@postId", SqlDbType.Int);
                Command.Parameters["@postId"].Value = Id;
                SqlDataReader dr = Command.ExecuteReader();
                if (dr.Read())
                {
                    post.PostId = Id;
                    post.UserId = (int)dr.GetValue(dr.GetOrdinal("userId"));
                    post.Content = dr.GetValue(dr.GetOrdinal("content")).ToString();
                    post.DateMade = (DateTime)dr.GetValue(dr.GetOrdinal("dateMade"));
                    post.Title = dr.GetValue(dr.GetOrdinal("Title")).ToString();
                }
                return post;
            }
        }
        public PostEntities InsertPost(PostEntities post)
        {
            GetCommand("InsertPost");
            {
                AddParameterWithValue("@userId", SqlDbType.Int, post.UserId);
                AddParameterWithValue("@content", SqlDbType.Text, post.Content);
                AddParameterWithValue("@Title", SqlDbType.Text, post.Title);
                Command.ExecuteNonQuery();
            }
            return post;
        }
        public PostEntities UpdatePost(PostEntities post)
        {
            GetCommand("UpdatePost");
            {
                AddParameterWithValue("@postId", SqlDbType.Int, post.PostId);
                AddParameterWithValue("@content", SqlDbType.Text, post.Content);
                AddParameterWithValue("@Title", SqlDbType.Text, post.Title);
                Command.ExecuteNonQuery();
            }
            return post;
        }
        public List<PostEntities> GetPostList()
        {
            List<PostEntities> posts = new List<PostEntities>();
            GetCommand("GetAllPosts");
            {
                SqlDataReader dr = Command.ExecuteReader();
                while (dr.Read())
                {
                    PostEntities post = new PostEntities();
                    post.PostId = dr.GetIntValue("postId");
                    post.UserId = (int)dr.GetValue(dr.GetOrdinal("userId"));
                    post.Content = dr.GetValue(dr.GetOrdinal("content")).ToString();
                    post.DateMade = (DateTime)dr.GetValue(dr.GetOrdinal("dateMade"));
                    post.Title = dr.GetValue(dr.GetOrdinal("Title")).ToString();
                    posts.Add(post);
                }
                dr.Close();
            }
            return posts;
        }
        public PostEntities DeletePostByID(int PostId)
        {
            PostEntities post = new PostEntities();
            GetCommand("DeletePostById");
            AddParameterWithValue("@postId", SqlDbType.Int, PostId);
            Command.ExecuteNonQuery();
            return post;
        }
        public List<PostEntities> GetPostsByUser(int UserId)
        {
            List<PostEntities> posts = new List<PostEntities>();
            GetCommand("GetPostsByUser");
            AddParameterWithValue("@userId", SqlDbType.Int, UserId);
            {
                SqlDataReader dr = Command.ExecuteReader();
                while (dr.Read())
                {
                    PostEntities post = new PostEntities();
                    post.PostId = (int)dr.GetValue(dr.GetOrdinal("postId"));
                    post.UserId = (int)dr.GetValue(dr.GetOrdinal("userId"));
                    post.Content = dr.GetValue(dr.GetOrdinal("content")).ToString();
                    post.DateMade = (DateTime)dr.GetValue(dr.GetOrdinal("dateMade"));
                    post.Title = dr.GetValue(dr.GetOrdinal("Title")).ToString();
                    posts.Add(post);
                }
                dr.Close();
            }
            return posts;
        }
        public List<PostEntities> GetJoinedPostList()
        {
            List<PostEntities> posts = new List<PostEntities>();
            List<AccountUserInfoEntities> users = new List<AccountUserInfoEntities>();
            GetCommand("GetJoinedPosts");
            {
                SqlDataReader dr = Command.ExecuteReader();
                while (dr.Read())
                {
                    PostEntities post = new PostEntities();
                    AccountUserInfoEntities user = new AccountUserInfoEntities();
                    post.PostId = dr.GetIntValue("postId");
                    post.UserId = (int)dr.GetValue(dr.GetOrdinal("userId"));
                    post.Content = dr.GetValue(dr.GetOrdinal("content")).ToString();
                    post.DateMade = (DateTime)dr.GetValue(dr.GetOrdinal("dateMade"));
                    post.Title = dr.GetValue(dr.GetOrdinal("Title")).ToString();

                    user.UserName = dr.GetValue(dr.GetOrdinal("userName")).ToString();
                    user.FirstName = dr.GetValue(dr.GetOrdinal("firstName")).ToString();
                    user.City = dr.GetValue(dr.GetOrdinal("city")).ToString();
                    user.LastName = dr.GetValue(dr.GetOrdinal("lastName")).ToString();
                    user.Gender = (byte)dr.GetValue(dr.GetOrdinal("gender"));
                    user.DateOfBirth = (DateTime)dr.GetValue(dr.GetOrdinal("dateOfBirth"));
                    user.ProfileDescription = dr.GetValue(dr.GetOrdinal("profileDescription")).ToString();
                    user.EmailAddress = dr.GetValue(dr.GetOrdinal("emailAddress")).ToString();
                    user.DateMade = (DateTime)dr.GetValue(dr.GetOrdinal("dateMade"));
                    users.Add(user);
                    posts.Add(post);
                }
                dr.Close();
            }
            return posts;
        }
    }
}
