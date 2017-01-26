namespace Models
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
    }
}
