namespace Models
{
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.Runtime.Serialization;

    public class BaseUser: ICommand
    {
        public BaseUser()
        {
            IssuedOn = DateTime.UtcNow;
        }

        public long AggregateId { get; set; }

        public long IssuedBy { get; set; }

        public DateTime IssuedOn { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password missmatch.")]
        public string Password { get; set; }
    }
}
