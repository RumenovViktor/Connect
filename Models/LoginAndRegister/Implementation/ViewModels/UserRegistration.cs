namespace Models
{
    using System.Runtime.Serialization;
    using System.ComponentModel.DataAnnotations;

    using Utils;

    public class UserRegistration : BaseUser, ICommand, ISerializable
    {
        public UserRegistration() { }

        public UserRegistration(SerializationInfo info, StreamingContext context)
        {
            base.Email = (string)info.GetValue("Email", typeof(string));
            base.Password = (string)info.GetValue("Password", typeof(string));
            FirstName = (string)info.GetValue("FirstName", typeof(string));
            LastName = (string)info.GetValue("LastName", typeof(string));
            ConfirmPassword = (string)info.GetValue("ConfirmPassword", typeof(string));
            Gender = (Gender)info.GetValue("Gender", typeof(Gender));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Email", base.Email, typeof(string));
            info.AddValue("Password", base.Password, typeof(string));
            info.AddValue("FirstName", FirstName, typeof(string));
            info.AddValue("LastName", LastName, typeof(string));
            info.AddValue("ConfirmPassword", ConfirmPassword, typeof(string));
            info.AddValue("Gender", Gender, typeof(Gender));
        }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password missmatch.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public Gender Gender { get; set; }
    }
}
