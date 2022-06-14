using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Entities;

namespace Facebook.Interfaces
{
    public interface ISearch
    {
        List<PostEntities> SearchPosts(string query);
        List<AccountUserInfoEntities> SearchUsers(string query);
        List<CommentEntities> SearchComments(string query);

    }
}
