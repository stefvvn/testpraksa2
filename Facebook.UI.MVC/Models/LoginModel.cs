namespace Facebook.UI.MVC.Models
{
    public class LoginModel
    {
        public Facebook.Entities.AccountUserInfoEntities User { get; set; }

        public int UserIdNumber { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string City { get; set; }
        public Byte Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ProfileDescription { get; set; }
        public string ImgPath { get; set; }


        public string email { get; set; }
        public string password { get; set; }
    }
}
