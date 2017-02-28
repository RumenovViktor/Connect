using Models;
using System.Collections.Generic;

namespace ApplicationServices
{
    public interface ISkillsManager
    {
        IList<SkillsDto> GetMatchedSkills(string name);
    }
}
