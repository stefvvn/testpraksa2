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
            IPosts data = new PostsEF();
            return data.InsertPost(post);
        }
        public PostEntities GetPostByID(int Id)
        {
            IPosts data = new PostsEF();
            return data.GetPostByID(Id);
        }
        public PostEntities UpdatePost(PostEntities post)
        {
            IPosts data = new PostsEF();
            return data.UpdatePost(post);
        }
        public PostEntities DeletePostByID(int Id)
        {
            IPosts data = new PostsEF();
            return data.DeletePostByID(Id);
        }
        public List<PostEntities> GetPostList()
        {
            IPosts data = new PostsEF();
            return data.GetPostList();
        }
        public List<PostEntities> GetPostsByUser(int userId)
        {
            IPosts data = new PostsEF();
            return data.GetPostsByUser(userId);
        }

        public List<PostEntities> GetJoinedPostList()
        {
            IPosts data = new PostsEF();
            return data.GetJoinedPostList();
        }
    }
}
