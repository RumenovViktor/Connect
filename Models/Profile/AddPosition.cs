namespace Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    public class AddPosition : ICommand
    {
        public AddPosition() { }

        [Required]
        public string PositionName { get; set; }

        [Required]
        public string PositionDescription { get; set; }

        public long PositionId { get; set; }

        public long UserId { get; set; }
    }
}
