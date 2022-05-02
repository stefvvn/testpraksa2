using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Data.SQL;
using Facebook.Entities;
using Facebook.Data.EntityFramework;
using Facebook.Interfaces;

namespace Facebook.Business
{
    public class PostBsn
    {
        public PostEntities InsertPost(PostEntities post)
        {
            PostData data = new PostData();
            return data.InsertPost(post);
        }
        public PostEntities GetPostByID(int Id)
        {
            PostData data = new PostData();
            return data.GetPostByID(Id);
        }
        public PostEntities UpdatePost(PostEntities post)
        {
            PostData data = new PostData();
            return data.UpdatePost(post);
        }
        public PostEntities DeletePostByID(int Id)
        {
            PostData data = new PostData();
            return data.DeletePostByID(Id);
        }
        public List<PostEntities> GetPostList()
        {
            IPosts data = new PostsEF();
            return data.GetPostList();
        }
        public List<PostEntities> GetPostsByUser(int userId)
        {
            PostData data = new PostData();
            return data.GetPostsByUser(userId);
        }

        public List<PostEntities> GetJoinedPostList()
        {
            PostData data = new PostData();
            return data.GetJoinedPostList();
        }
    }
}
