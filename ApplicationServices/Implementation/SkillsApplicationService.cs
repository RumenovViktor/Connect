namespace ApplicationServices
{
    using Models;
    using Connect.Helpers;
    using System;

    public class SkillsApplicationService : ISkillsApplicationService
    {
        public PositionRequiredSkill Execute(PositionRequiredSkill command)
        {
            return WebServiceProvider<PositionRequiredSkill>.Post(command, UrlHelper.AddPositionSkillUrl);
        }

        public SkillDtoWriteModel Execute(SkillDtoWriteModel command)
        {
            return WebServiceProvider<SkillDtoWriteModel>.Post(command, UrlHelper.CreateSkillUrl);
        }
    }
}
