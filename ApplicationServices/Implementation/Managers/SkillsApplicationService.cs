namespace ApplicationServices
{
    using System;
    using System.Collections.Generic;

    using Models;
    using Connect.Helpers;

    public class SkillsApplicationService : ISkillsApplicationService
    {
        public IList<SkillsDto> GetMatchedSkills(string name)
        {
            var matchedSkills = WebServiceProvider<IList<SkillsDto>>.Get(UrlHelper.GetSkillsUrl, new Dictionary<string, string>() { { "name", name } } );
            return matchedSkills;
        }

        public void AddSkill(SkillDtoWriteModel skill)
        {
            WebServiceProvider<SkillDtoWriteModel>.Post(skill, UrlHelper.CreateSkillUrl);
        }
    }
}
