namespace DTOs.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser<int, UserLogin, UserRole, UserClaim>
    {
        private ICollection<Skill> skills;
        private ICollection<File> files;
        private ICollection<Experience> experience;

        public User()
        {
            this.skills = new HashSet<Skill>();
            this.files = new HashSet<File>();
            this.experience = new HashSet<Experience>();
        }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public int? CountryId { get; set; }

        public Country Country { get; set; }

        public DateTime DateOfCreation { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Experience> Experience
        {
            get
            {
                return this.experience;
            }
            set
            {
                this.experience = value;
            }
        }

        public virtual ICollection<Skill> Skills
        {
            get
            {
                return this.skills;
            }
            set
            {
                this.skills = value;
            }
        }

        public virtual ICollection<File> Files
        {
            get
            {
                return this.files;
            }
            set
            {
                this.files = value;
            }
        }
    }
}
