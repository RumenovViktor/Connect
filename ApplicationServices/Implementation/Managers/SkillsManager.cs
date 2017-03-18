using Connect.Helpers;
using Data.Unit_Of_Work;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationServices
{
    public class SkillsManager : ISkillsManager
    {
        private readonly IDALServiceData dalServiceData;

        public SkillsManager(IDALServiceData data)
        {
            dalServiceData = data;
        }

        public IList<SkillsDto> GetMatchedSkills(string name)
        {
            var matchedSkills = dalServiceData.Skills.All()
                    .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                    .ToList()
                    .Select(x => new SkillsDto(x.SkillId, x.Name));

            return matchedSkills.ToList();
        }
    }
}
