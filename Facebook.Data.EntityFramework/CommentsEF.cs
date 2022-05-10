using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Data.SQL;
using Facebook.Entities;
using Facebook.Interfaces;
using System.Linq;

namespace Facebook.Data.EntityFramework
{
    public class CommentsEF : SqlBaseData, IComments
    {
        public CommentEntities DeleteCommentByID(int id)
        {
            throw new NotImplementedException();
        }

        public CommentEntities GetCommentByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<CommentEntities> GetCommentList()
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            return Db.Comment.ToList();
        }

        public List<CommentEntities> GetCommentsByPost(int postId)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            return Db.Comment.Where(x => x.PostId == postId).ToList();
        }

        public CommentEntities InsertComment(CommentEntities comment)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            Db.Comment.Add(comment);
            Db.SaveChanges();
            return comment;
        }

        public CommentEntities UpdateComment(CommentEntities comment)
        {
            ApplicationDbContext Db = new ApplicationDbContext();
            Db.Comment.Update(comment);
            Db.SaveChanges();
            return comment;
        }
    }
}
