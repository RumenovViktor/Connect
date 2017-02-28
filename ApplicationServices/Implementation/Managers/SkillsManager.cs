using Connect.Helpers;
using Models;
using System.Collections.Generic;

namespace ApplicationServices
{
    public class SkillsManager : ISkillsManager
    {
        public IList<SkillsDto> GetMatchedSkills(string name)
        {
            var matchedSkills = WebServiceProvider<IList<SkillsDto>>.Get(UrlHelper.GetSkillsUrl, new Dictionary<string, string>() { { "name", name } });
            return matchedSkills;
        }
    }
}
