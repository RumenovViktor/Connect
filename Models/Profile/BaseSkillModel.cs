using System.Runtime.Serialization;

namespace Models
{
    public class BaseSkillModel : ICommand
    {
        public virtual string Name { get; set; }

        public virtual int UserId { get; set; }

        public BaseSkillModel() { }

        public BaseSkillModel(string name, int userId)
        {
            this.Name = name;
            this.UserId = userId;
        }
    }
}
