using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Facebook.Entities
{   
    public class PostEntities
    {
        [Key]
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime DateMade { get; set; }
        public string Title { get; set; }  
        public AccountUserInfoEntities User { get; set; }
    }

    public class User
    {
        public int UserIdNumber { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string City { get; set; }
        public Byte Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ProfileDescription { get; set; }
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
    }

}
