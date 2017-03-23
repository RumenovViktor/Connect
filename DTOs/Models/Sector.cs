namespace DTOs.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Sector
    {
        public Sector()
        {
            this.Positions = new HashSet<Position>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
}
