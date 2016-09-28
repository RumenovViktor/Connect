namespace Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;
    using Utils;

    public class UserRegistration : ICommand, ISerializable
    {
        public UserRegistration() { }

        public UserRegistration(SerializationInfo info, StreamingContext context)
        {
            AggregateId = (long)info.GetValue("AggregateId", typeof(long));
            IssuedBy = (long)info.GetValue("IssuedBy", typeof(long));
            IssuedOn = (DateTime)info.GetValue("IssuedOn", typeof(DateTime));
            Email = (string)info.GetValue("Email", typeof(string));
            Password = (string)info.GetValue("Password", typeof(string));
            FirstName = (string)info.GetValue("FirstName", typeof(string));
            LastName = (string)info.GetValue("LastName", typeof(string));
            ConfirmPassword = (string)info.GetValue("ConfirmPassword", typeof(string));
            Gender = (Gender)info.GetValue("Gender", typeof(Gender));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("AggregateId", AggregateId, typeof(long));
            info.AddValue("IssuedBy", IssuedBy, typeof(long));
            info.AddValue("IssuedOn", IssuedOn, typeof(DateTime));
            info.AddValue("Email", Email, typeof(string));
            info.AddValue("Password", Password, typeof(string));
            info.AddValue("FirstName", FirstName, typeof(string));
            info.AddValue("LastName", LastName, typeof(string));
            info.AddValue("ConfirmPassword", ConfirmPassword, typeof(string));
            info.AddValue("Gender", Gender, typeof(Gender));
        }

        public long AggregateId { get; set; }

        public long IssuedBy { get; set; }

        public DateTime IssuedOn { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password missmatch.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Compare("ConfirmPassword", ErrorMessage = "Password missmatch.")]
        public string Password { get; set; }


        [Required]
        public Gender Gender { get; set; }
    }
}
