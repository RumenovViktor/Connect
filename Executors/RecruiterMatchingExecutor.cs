using System.Collections.Generic;
using Data.Unit_Of_Work;
using DTOs.Models;
using Models.Dashboard;
using System.Linq;
using Utils;

namespace Executors
{
    public class RecruiterMatchingExecutor : MatchingExecutor<Position, SuggestedUser>
    {
        public RecruiterMatchingExecutor(IDALServiceData dalServiceData) : base(dalServiceData) { }

        public override IList<SuggestedUser> Match(Position entity, int? sectorId, int? countryId)
        {
            var matchedUsers = new List<SuggestedUser>();
            var users = dalServiceData.Users.All().Where(x => x.Roles.FirstOrDefault(t => t.RoleId == 1) == null).ToList();

            foreach (var user in users)
            {
                var matchedSkillsCount = CalculateSkillRate(entity, user);

                var skillMatchInPercentage = entity.RequiredSkills.Count != 0 ? (matchedSkillsCount / entity.RequiredSkills.Count ) * TotalPercentage : TotalPercentage;
                var experienceMatchInPercentage = user.DaysOfExperience.HasValue ? ((decimal)DateProvider.ConvertToYears(user.DaysOfExperience) / entity.NeededYearsOfExperience) * TotalPercentage : 0;
                var fixedSkillsPercentage = skillMatchInPercentage > TotalPercentage ? TotalPercentage : skillMatchInPercentage;
                var fixedExperiencePercentage = experienceMatchInPercentage > TotalPercentage ? TotalPercentage : experienceMatchInPercentage;
                var matchedPercentege = (fixedSkillsPercentage + fixedExperiencePercentage) / Avarage;

                matchedUsers.Add(new SuggestedUser(user.UserName, string.Format("{0} {1}", user.FirstName, user.LastName), matchedPercentege.Value, user.Files.Select(x => x.FileInputStream).FirstOrDefault()));
            }

            return matchedUsers.OrderByDescending(x => x.MatchPersentage).ToList();
        }

        private int CalculateSkillRate(Position position, User user)
        {
            int skillsMatchCount = 0;

            if (position.RequiredSkills.Count == 0)
            {
                return (int)TotalPercentage;
            }

            foreach (var skill in position.RequiredSkills)
            {
                var userSkill = user.Skills.Where(x => x.Name == skill.Name).FirstOrDefault();

                if (userSkill != null)
                {
                    skillsMatchCount++;
                }
            }

            return skillsMatchCount;
        }
    }
}
