namespace ApplicationServices
{
    using System.Collections.Generic;

    using Models;

    public interface ISkillsApplicationService
    {
        IList<SkillsDto> GetMatchedSkills(string name);
    }
}
