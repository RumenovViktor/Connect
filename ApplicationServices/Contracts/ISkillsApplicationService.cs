namespace ApplicationServices
{
    using System.Collections.Generic;

    using Models;

    public interface ISkillsApplicationService  : 
        IHandles<SkillDtoWriteModel>,
        IHandles<PositionRequiredSkill>
    {
    }
}
