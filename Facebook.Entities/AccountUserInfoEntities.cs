namespace Facebook.Entities
{
    public class AccountUserInfoEntities
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