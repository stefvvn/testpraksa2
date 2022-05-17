using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Facebook.Entities
{
    [Table("userAccountInfo")]
    public class AccountUserInfoEntities
    {
        public AccountUserInfoEntities()
        {
            Posts = new HashSet<PostEntities>();
            PostLikes = new HashSet<PostLikeEntities>();
            DateMade = DateTime.Now;
        }
        [Key]
        public int UserIdNumber { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string City { get; set; }
        public Byte Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ProfileDescription { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime DateMade { get; set; }
        public string GenderString
        {
            get
            {
                if (Gender == 0)
                    return "Zensko";

                return "Musko";
            }
        }

        public virtual ICollection<PostEntities> Posts { get; set; }
        public virtual ICollection<PostLikeEntities> PostLikes { get; set; }
    }
}