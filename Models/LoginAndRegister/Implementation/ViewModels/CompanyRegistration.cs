namespace Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    public class CompanyRegistration : ICommand, ISerializable
    {
        public CompanyRegistration() { }

        public CompanyRegistration(SerializationInfo info, StreamingContext context)
        {
            this.ComapanyName = (string)info.GetValue("ComapnyName", typeof(string));
            this.Email = (string)info.GetValue("Email", typeof(string));
            this.Password = (string)info.GetValue("Password", typeof(string));
            this.ConfirmPassword = (string)info.GetValue("ConfirmPassword", typeof(string));
            this.Country = (string)info.GetValue("Country", typeof(string));
        }

        [Required]
        public string ComapanyName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password missmatch.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Country { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FirstName", this.ComapanyName, typeof(string));
            info.AddValue("Email", this.Email, typeof(string));
            info.AddValue("Password", this.Password, typeof(string));
            info.AddValue("ConfirmPassword", this.ConfirmPassword, typeof(string));
            info.AddValue("ConfirmPassword", this.Country, typeof(string));
        }
    }
}
