namespace Models
{
    public class UserLogin : BaseUser, ICommand
    {
        public UserLogin() { }

        public UserLogin(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public bool DoesUserExists { get; set; }
        public int UserId { get; set; }
        public UserType UserType { get; set; }
    }
}