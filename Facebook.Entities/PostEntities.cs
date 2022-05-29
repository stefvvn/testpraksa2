using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facebook.Entities
{
    [Table("posts")]
    public class PostEntities
    {
        public PostEntities()
        {
            DateMade = DateTime.Now;
        }
        [Key]
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime DateMade { get; set; }
        public string Title { get; set; }
        public string? ImgPath { get; set; }


        [NotMapped]
        public int LikeCount { get { return PostLikes.Count(); } }


        [ForeignKey("UserId")]
        public virtual AccountUserInfoEntities User { get; set; }
        public virtual List<PostLikeEntities>? PostLikes { get; set; }
        public virtual List<CommentEntities>? Comments { get; set; }
    }
}
