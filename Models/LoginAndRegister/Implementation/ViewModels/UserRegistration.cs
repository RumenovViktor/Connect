namespace Models
{
    using System.ComponentModel.DataAnnotations;

    using Utils;
    using Global;
    using System.Collections.Generic;

    public class UserRegistration : BaseUser, ICommand
    {
        public UserRegistration() { }

        public UserRegistration(IList<CountryReadModel> countries)
        {
            this.Countries = countries;
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

        public UserType UserType { get; set; }
    }
}
