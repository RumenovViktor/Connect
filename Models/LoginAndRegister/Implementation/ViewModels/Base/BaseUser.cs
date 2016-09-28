namespace Models
{
    using System.ComponentModel.DataAnnotations;

    public class BaseUser: ICommand
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password missmatch.")]
        public string Password { get; set; }
    }
}
