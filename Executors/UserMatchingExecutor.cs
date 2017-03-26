namespace Executors
{
    using System.Linq;
    using System.Collections.Generic;

    using DTOs.Models;
    using Data.Unit_Of_Work;
    using Models;
    using Utils;

    public class UserMatchingExecutor : MatchingExecutor<User, UserSuitiblePosition>
    {
        public UserMatchingExecutor(IDALServiceData dalServiceData) : base(dalServiceData) { }

        public override IList<UserSuitiblePosition> Match(User entity, int? sectorId, int? countryId)
        {
            var matchedPositions = new List<UserSuitiblePosition>();

            var allPositions = FilterPositions(sectorId, countryId);

            foreach (var position in allPositions)
            {
                var positionRequiredSkills = position.RequiredSkills.Count;
                var userSkills = CalculateSkillRate(position, entity);

                var skillMatchInPercentage = positionRequiredSkills != 0 ? (userSkills / positionRequiredSkills) * TotalPercentage : TotalPercentage;
                var experienceMatchInPercentage = entity.DaysOfExperience.HasValue ? ((decimal)DateProvider.ConvertToYears(entity.DaysOfExperience) / position.NeededYearsOfExperience) * TotalPercentage : 0;

                var fixedSkillsPercentage = skillMatchInPercentage > TotalPercentage ? TotalPercentage : skillMatchInPercentage;
                var fixedExperiencePercentage = experienceMatchInPercentage > TotalPercentage ? TotalPercentage : experienceMatchInPercentage;

                var matchedPercentege = (fixedSkillsPercentage + fixedExperiencePercentage) / Avarage;

                matchedPositions.Add(
                    new UserSuitiblePosition(position.Id, position.PositionName, matchedPercentege.Value));
            }

            return matchedPositions.OrderByDescending(x => x.MatchPersentage).Take(12).ToList();
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

        private IList<Position> FilterPositions(int? sectorId, int? countryId)
        {
            //if (sectorId.HasValue && countryId.HasValue)
            //{
            //    return dalServiceData.Positions.All()
            //        .Where(x => x.Company.Sectors.Select(t => t.Id).ToList().Contains(sectorId.Value) && x.Company.CountryId == countryId.Value)
            //        .ToList();
            //}

            //if (sectorId.HasValue)
            //{
            //    return dalServiceData.Positions.All().Where(x => x.Company.Sectors.Select(t => t.Id).ToList().Contains(sectorId.Value)).ToList();
            //}

            //if (countryId.HasValue)
            //{
            //    return dalServiceData.Positions.All().Where(x => x.Company.CountryId == countryId.Value).ToList();
            //}

            return dalServiceData.Positions.All().ToList();
        }
    }
}
