using Facebook.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Data.SQL

{
    public class CommentData : SqlBaseData
    {
        public CommentEntities GetCommentByID(int Id)
        {
            CommentEntities comment = new CommentEntities();

            GetCommand("GetCommentById");
            AddParameterWithValue("@commentId", SqlDbType.Int, Id);

            SqlDataReader dr = Command.ExecuteReader();
            if (dr.Read())
            {
                comment.CommentId = Id;
                comment.PostId = (int)dr.GetValue(dr.GetOrdinal("postId"));
                comment.UserId = (int)dr.GetValue(dr.GetOrdinal("userId"));
                comment.Content = dr.GetValue(dr.GetOrdinal("content")).ToString();
                comment.DateMade = (DateTime)dr.GetValue(dr.GetOrdinal("dateMade"));
            }
            CloseConnection();
            return comment;
        }
        public CommentEntities InsertComment(CommentEntities comment)
        {
            GetCommand("InsertComment");
            {
                AddParameterWithValue("@postId", SqlDbType.Int, comment.PostId);
                AddParameterWithValue("@userID", SqlDbType.Int, comment.UserId);
                AddParameterWithValue("@content", SqlDbType.Text, comment.Content);
                Command.ExecuteNonQuery();
            }
            return comment;
        }
        public CommentEntities UpdateComment(CommentEntities comment)
        {
            GetCommand("UpdateComment");
            {
                AddParameterWithValue("@commentId", SqlDbType.Int, comment.CommentId);
                AddParameterWithValue("@content", SqlDbType.Text, comment.Content);
                Command.ExecuteNonQuery();
            }
            return comment;
        }
        public List<CommentEntities> GetCommentList()
        {
            List<CommentEntities> comments = new List<CommentEntities>();
            GetCommand("GetAllComments");
            {
                SqlDataReader dr = Command.ExecuteReader();
                while (dr.Read())
                {
                    CommentEntities comment = new CommentEntities();
                    comment.CommentId = (int)dr.GetValue(dr.GetOrdinal("commentId"));
                    comment.PostId = (int)dr.GetValue(dr.GetOrdinal("postId"));
                    comment.UserId = (int)dr.GetValue(dr.GetOrdinal("userId"));
                    comment.Content = dr.GetValue(dr.GetOrdinal("content")).ToString();
                    comment.DateMade = (DateTime)dr.GetValue(dr.GetOrdinal("dateMade"));
                    comments.Add(comment);
                }
                dr.Close();
            }
            return comments;
        }
        public CommentEntities DeleteCommentByID(int CommentId)
        {
            CommentEntities comment = new CommentEntities();
            GetCommand("DeleteCommentById");
            AddParameterWithValue("@commentId", SqlDbType.Int, CommentId);
            return comment;
        }
        public List<CommentEntities> GetCommentsByPost(int PostId)
        {
            List<CommentEntities> comments = new List<CommentEntities>();
            GetCommand("GetCommentsByPost");
            AddParameterWithValue("@postId", SqlDbType.Int, PostId);
            {
                SqlDataReader dr = Command.ExecuteReader();
                while (dr.Read())
                {
                    CommentEntities comment = new CommentEntities();
                    comment.CommentId = (int)dr.GetValue(dr.GetOrdinal("commentId"));
                    comment.PostId = (int)dr.GetValue(dr.GetOrdinal("postId"));
                    comment.UserId = (int)dr.GetValue(dr.GetOrdinal("userId"));
                    comment.Content = dr.GetValue(dr.GetOrdinal("content")).ToString();
                    comment.DateMade = (DateTime)dr.GetValue(dr.GetOrdinal("dateMade"));
                    comments.Add(comment);
                }
                dr.Close();
            }
            return comments;
        }
    }
}
