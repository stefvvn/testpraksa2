using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Entities
{
    public class PostLikeEntities
    {
        public int PostLikeId { get; set; } 
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int PostLikeStatus { get; set; }
        public string PostLikeStatusString
        {
            get
            {
                if (PostLikeStatus == 1)
                    return "Disliked";
                if (PostLikeStatus == 2)
                    return "Liked";
                return "N/A";
            }
        }
    }
}
