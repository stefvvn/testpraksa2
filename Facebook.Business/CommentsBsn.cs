using Facebook.Data.EntityFramework;
using Facebook.Data.SQL;
using Facebook.Entities;
using Facebook.Interfaces;


namespace Facebook.Business
{

    public class CommentBsn
    {
        public CommentEntities InsertComment(CommentEntities comment)
        {
            IComments data = new CommentsEF();
            return data.InsertComment(comment);
        }
        public CommentEntities GetCommentByID(int Id)
        {
            IComments data = new CommentsEF();
            return data.GetCommentByID(Id);
        }
        public CommentEntities UpdateComment(CommentEntities comment)
        {
            IComments data = new CommentsEF();
            return data.UpdateComment(comment);
        }
        public CommentEntities DeleteCommentByID(int Id)
        {
            IComments data = new CommentsEF();
            return data.DeleteCommentByID(Id);
        }
        public List<CommentEntities> GetCommentList()
        {
            IComments data = new CommentsEF();
            return data.GetCommentList();
        }
        public List<CommentEntities> GetCommentsByPost(int postId)
        {
            IComments data = new CommentsEF();
            return data.GetCommentsByPost(postId);
        }
    }
}