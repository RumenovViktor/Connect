namespace Models.Profile
{
    using System.Collections.Generic;

    public class Profile
    {
        public Profile()
        {
            this.UserExperience = new List<ExperienceViewModel>();
            this.Skills = new List<string>();
        }
    
        public IList<ExperienceViewModel> UserExperience { get; set; }

        public IList<string> Skills { get; set; }

        public double? YearsOfExperience { get; set; }

        public byte[] ProfileImage { get; set; }

        public string UserName { get; set; }

        public bool CanEditProfile { get; set; }
    }
}
