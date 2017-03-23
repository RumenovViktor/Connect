namespace Models
{
    using System.Runtime.Serialization;
    using System.ComponentModel.DataAnnotations;

    using Utils;
    using Global;
    using System.Collections.Generic;

    public class UserRegistration : BaseUser, ICommand, ISerializable
    {
        public UserRegistration() { }

        public UserRegistration(IList<CountryReadModel> countries)
        {
            this.Countries = countries;
        }

        public UserRegistration(SerializationInfo info, StreamingContext context)
        {
            base.Email = (string)info.GetValue("Email", typeof(string));
            base.Password = (string)info.GetValue("Password", typeof(string));
            FirstName = (string)info.GetValue("FirstName", typeof(string));
            LastName = (string)info.GetValue("LastName", typeof(string));
            CountryId = (int?)info.GetValue("CountryId", typeof(int?));
            ConfirmPassword = (string)info.GetValue("ConfirmPassword", typeof(string));
            Gender = (Gender)info.GetValue("Gender", typeof(Gender));
            UserId = (int)info.GetValue("UserId", typeof(int));
            UserExists = (bool)info.GetValue("UserExists", typeof(bool));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Email", base.Email, typeof(string));
            info.AddValue("Password", base.Password, typeof(string));
            info.AddValue("FirstName", FirstName, typeof(string));
            info.AddValue("LastName", LastName, typeof(string));
            info.AddValue("CountryId", CountryId, typeof(int?));
            info.AddValue("ConfirmPassword", ConfirmPassword, typeof(string));
            info.AddValue("Gender", Gender, typeof(Gender));
            info.AddValue("UserId", UserId, typeof(int));
            info.AddValue("UserExists", UserExists, typeof(bool));
        }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public IList<CountryReadModel> Countries { get; set; }

        [Required]
        public int? CountryId { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password missmatch.")]
        [MinLength(8)]
        public string ConfirmPassword { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public int UserId { get; set; }

        public bool UserExists { get; set; }
    }
}
