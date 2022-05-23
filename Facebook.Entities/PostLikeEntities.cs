using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facebook.Entities
{
    [Table("postLikes")]
    public class PostLikeEntities
    {
        [Key]
        public int PostLikeId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public byte PostLikeStatus { get; set; }
        public string PostLikeStatusString
        {
            get
            {
                if (PostLikeStatus == 1)
                    return "Liked";
                return "Not Liked";
            }
        }

        [ForeignKey("PostId")]
        public virtual PostEntities? Post { get; set; }
        [ForeignKey("UserId")]
        public virtual AccountUserInfoEntities? User { get; set; }
    }
}