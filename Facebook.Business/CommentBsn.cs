using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Data.SQL;
using Facebook.Entities;

namespace Facebook.Business
{

    public class CommentBsn
    {
        public CommentEntities InsertComment(CommentEntities comment)
        {
            CommentData data = new CommentData();
            return data.InsertComment(comment);
        }
        public CommentEntities GetCommentByID(int Id)
        {
            CommentData data = new CommentData();
            return data.GetCommentByID(Id);
        }
        public CommentEntities UpdateComment(int Id)
        {
            CommentData data = new CommentData();
            return data.UpdateComment(Id);
        }
    }
}