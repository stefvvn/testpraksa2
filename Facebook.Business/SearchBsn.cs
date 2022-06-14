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
    public class SearchBsn
    {
        public List<PostEntities> SearchPosts(string query)
        {
            ISearch data = new PostsEF();
            return data.SearchPosts(query);
        }

        public List<AccountUserInfoEntities> SearchUsers(string query)
        {
            ISearch data = new AccountUserInfoEF();
            return data.SearchUsers(query);
        }

        //public List<CommentEntities> SearchComments(string query)
        //{
        //    ISearch data = new CommentsEF();
        //    return data.SearchComments(query);
        //}
    }
}
