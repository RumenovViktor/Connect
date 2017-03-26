namespace Models
{
    using System.ComponentModel.DataAnnotations;

    public class AddPosition : ICommand
    {
        public AddPosition() { }

        [Required]
        public string PositionName { get; set; }
        
        public string Introduction { get; set; }

        [Required]
        public string PositionDescription { get; set; }

        public string WhatWeProvide { get; set; }

        public int NeededYearsOfExperience { get; set; }

        public long PositionId { get; set; }

        public long UserId { get; set; }
    }
}
