namespace Models
{
    public class UserRegistrationLogin
    {
        public UserRegistrationLogin()
        {
            this.UserLogin = new UserLogin();
            this.UserRegistration = new UserRegistration();        
        }

        public UserLogin UserLogin { get; set; }

        public UserRegistration UserRegistration { get; set; }
    }
}
