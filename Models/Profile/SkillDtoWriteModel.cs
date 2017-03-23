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

        public override int UserId { get; set; }

        public SkillDtoWriteModel() { }

        public SkillDtoWriteModel(string name, int userId) : base (name, userId) { }

        public SkillDtoWriteModel(SerializationInfo info, StreamingContext context)
        {
            this.Id = (long)info.GetValue("Id", typeof(long));
            this.Name = (string)info.GetValue("Name", typeof(string));
            this.UserId = (int)info.GetValue("UserId", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", this.Id, typeof(long));
            info.AddValue("Name", this.Name, typeof(string));
            info.AddValue("UserId", this.UserId, typeof(int));

        }
    }
}
