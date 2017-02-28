namespace Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    public class AddPosition : ICommand, ISerializable
    {
        public AddPosition() { }

        public AddPosition(SerializationInfo info, StreamingContext context)
        {
            this.PositionName = (string)info.GetValue("PositionName", typeof(string));
            this.PositionDescription = (string)info.GetValue("PositionDescription", typeof(string));
            this.PositionId = (long)info.GetValue("PositionId", typeof(long));    
        }

        [Required]
        public string PositionName { get; set; }

        [Required]
        public string PositionDescription { get; set; }

        public long PositionId { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PositionName", this.PositionName, typeof(string));
            info.AddValue("PositionDescription", this.PositionDescription, typeof(string));
            info.AddValue("PositionId", this.PositionId, typeof(long));
        }
    }
}
