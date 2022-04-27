namespace Facebook.UI.MVC.Models
{
    public class LoginModel
    {
        public Facebook.Entities.AccountUserInfoEntities User { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
