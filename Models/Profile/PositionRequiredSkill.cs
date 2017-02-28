using System.Runtime.Serialization;

namespace Models
{
    public class PositionRequiredSkill : ICommand, ISerializable
    {
        public PositionRequiredSkill() { }

        public PositionRequiredSkill(string[] skillsNames, long positionId)
        {
            this.SkillsNames = skillsNames;
            this.PositionId = positionId;
        }

        public long PositionId { get; set; }

        public string[] SkillsNames { get; set; }

        public PositionRequiredSkill(SerializationInfo info, StreamingContext context)
        {
            this.SkillsNames = (string[])info.GetValue("SkillsNames", typeof(string[]));
            this.PositionId = (long)info.GetValue("PositionId", typeof(long));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("SkillsNames", this.SkillsNames, typeof(string[]));
            info.AddValue("PositionId", this.PositionId, typeof(long));
        }
    }
}
