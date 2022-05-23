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
    [Table("images")]
    public class ImageEntities
    {
        [Key]
        public int ImageId { get; set; }
        public int? UserId { get; set; }
        public int? PostId { get; set; }
        public int? CommentId { get; set; }
        public string? PathString { get; set; }  

        [ForeignKey("UserId")]
        public virtual AccountUserInfoEntities? User { get; set; }
        [ForeignKey("PostId")]
        public virtual PostEntities? Post { get; set; }
        [ForeignKey("CommentId")]
        public virtual CommentEntities? Comment { get; set; }

    }
}
