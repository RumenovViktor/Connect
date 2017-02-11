namespace Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    public class CompanyRegistration : ICommand, ISerializable
    {
        public CompanyRegistration() { }

        public CompanyRegistration(SerializationInfo info, StreamingContext context)
        {
            this.CompanyName = (string)info.GetValue("CompanyName", typeof(string));
            this.Email = (string)info.GetValue("Email", typeof(string));
            this.Password = (string)info.GetValue("Password", typeof(string));
            this.ConfirmPassword = (string)info.GetValue("ConfirmPassword", typeof(string));
            this.Country = (string)info.GetValue("Country", typeof(string));
            this.CompanyExists = (bool)info.GetValue("CompanyExists", typeof(bool));
        }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password missmatch.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Country { get; set; }

        public bool CompanyExists { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CompanyName", this.CompanyName, typeof(string));
            info.AddValue("Email", this.Email, typeof(string));
            info.AddValue("Password", this.Password, typeof(string));
            info.AddValue("ConfirmPassword", this.ConfirmPassword, typeof(string));
            info.AddValue("CompanyExists", this.CompanyExists, typeof(bool));
            info.AddValue("Country", this.Country, typeof(bool));
        }
    }
}
