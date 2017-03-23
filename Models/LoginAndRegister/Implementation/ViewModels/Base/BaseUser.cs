namespace Models
{
    using System.ComponentModel.DataAnnotations;

    public class BaseUser: ICommand
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password missmatch.")]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
