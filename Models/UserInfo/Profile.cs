namespace Models
{
    using System.Collections.Generic;

    public class Profile
    {
        public Profile()
        {
            this.UserExperience = new List<ExperienceViewModel>();                
        }
    
        public IList<ExperienceViewModel> UserExperience { get; set; }
    }
}
