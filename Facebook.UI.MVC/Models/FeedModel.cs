using System;
using Facebook.Entities;

namespace Facebook.UI.MVC.Models
{
    public class FeedModel
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime DateMade { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string PostLikeStatusString { get; set; }
    }
}