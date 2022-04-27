using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Entities;

namespace Facebook.Interfaces
{
    public interface IPosts
    {
        List<PostEntities> GetPostList();
        PostEntities InsertPost(PostEntities post);
        PostEntities UpdatePost(PostEntities post);
        PostEntities DeletePostByID(int id);
        List<PostEntities> GetPostsByUser(int userId);
    }
}
