using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facebook.Entities
{
    [Table("commentLikes")]
    public class CommentLikeEntities
    {
        [Key]
        public int CommentLikeId { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public byte CommentLikeStatus { get; set; }
        public string CommentLikeStatusString
        {
            get
            {
                if (CommentLikeStatus == 1)
                    return "Liked";
                return "Not Liked";
            }
        }

        [ForeignKey("CommentId")]
        public virtual CommentEntities? Comment { get; set; }
        [ForeignKey("UserId")]
        public virtual AccountUserInfoEntities? User { get; set; }
    }
}