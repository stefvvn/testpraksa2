using Facebook.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Interfaces
{
    public interface IComments
    {
        CommentEntities InsertComment(CommentEntities comment);
        CommentEntities GetCommentByID(int id);
        CommentEntities DeleteCommentByID(int id);
        CommentEntities UpdateComment(CommentEntities comment);
        List<CommentEntities> GetCommentList();
        List<CommentEntities> GetCommentsByPost(int postId);
    }
}
