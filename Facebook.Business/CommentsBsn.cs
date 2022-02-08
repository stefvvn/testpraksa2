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
        public CommentEntities UpdateComment(CommentEntities comment)
        {
            CommentData data = new CommentData();
            return data.UpdateComment(comment);
        }
        public CommentEntities DeleteCommentByID(int Id)
        {
            CommentData data = new CommentData();
            return data.DeleteCommentByID(Id);
        }
        public List<CommentEntities> GetCommentList()
        {
            CommentData data = new CommentData();
            return data.GetCommentList();
        }
        public List<CommentEntities> GetCommentsByPost(int postId)
        {
            CommentData data = new CommentData();
            return data.GetCommentsByPost(postId);
        }
    }
}