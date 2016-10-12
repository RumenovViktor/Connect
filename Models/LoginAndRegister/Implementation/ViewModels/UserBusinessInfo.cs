using Utils;

namespace Models
{
    public class UserBusinessInfo : UserRegistration
    {
        public UserBusinessInfo() : base() { }

        public UserBusinessInfo(string email, string password, string firstName, string lastName, string confirmPassword, Gender gender, bool isAfterRegistration = false)
        {
            base.Email = email;
            base.Password = password;
            FirstName = firstName;
            LastName = lastName;
            ConfirmPassword = confirmPassword;
            Gender = gender;
            IsAfterRegistration = isAfterRegistration;
        }

        public bool IsAfterRegistration { get; set; }
    }
}
