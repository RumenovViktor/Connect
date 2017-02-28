namespace Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    public class SkillDtoWriteModel : BaseSkillModel, ICommand, ISerializable
    {

        public long Id { get; set; }

        [Required]
        public override string Name { get; set; }

        public override string UserEmail { get; set; }

        public SkillDtoWriteModel() { }

        public SkillDtoWriteModel(string name, string userEmail) : base (name, userEmail) { }

        public SkillDtoWriteModel(SerializationInfo info, StreamingContext context)
        {
            this.Id = (long)info.GetValue("Id", typeof(long));
            this.Name = (string)info.GetValue("Name", typeof(string));
            this.UserEmail = (string)info.GetValue("UserEmail", typeof(string));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", this.Id, typeof(long));
            info.AddValue("Name", this.Name, typeof(string));
            info.AddValue("UserEmail", this.UserEmail, typeof(string));

        }
    }
}
