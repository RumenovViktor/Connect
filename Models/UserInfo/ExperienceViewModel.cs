namespace Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    public class ExperienceViewModel : ICommand
    {
        public ExperienceViewModel()
        {
        }

        [Required]
        public string Position { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public string Description { get; set; }

        public int UserId { get; set; }
    }
}
