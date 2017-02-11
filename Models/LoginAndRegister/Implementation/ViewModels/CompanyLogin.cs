namespace Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    public class CompanyLogin : ICommand, ISerializable
    {
        public CompanyLogin() { }

        public CompanyLogin(SerializationInfo info, StreamingContext context)
        {
            this.Email = (string)info.GetValue("Email", typeof(string));
            this.Password = (string)info.GetValue("Password", typeof(string));
        }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Email", this.Email, typeof(string));
            info.AddValue("Password", this.Password, typeof(string));
        }
    }
}
