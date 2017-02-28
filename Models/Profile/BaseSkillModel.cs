using System.Runtime.Serialization;

namespace Models
{
    public class BaseSkillModel : ICommand
    {
        public virtual string Name { get; set; }

        public virtual string UserEmail { get; set; }

        public BaseSkillModel() { }

        public BaseSkillModel(string name, string userEmail)
        {
            this.Name = name;
            this.UserEmail = userEmail;
        }
    }
}
