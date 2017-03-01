using System;
using System.Runtime.Serialization;

namespace Models
{
    public class CreatedPosition : ISerializable
    {
        public CreatedPosition() { }

        public CreatedPosition(long positionId, string positionName)
        {
            this.PositionId = positionId;
            this.PositionName = positionName;
        }

        public CreatedPosition(SerializationInfo info, StreamingContext context)
        {
            this.PositionId = (long)info.GetValue("PositionId", typeof(long));
            this.PositionName = (string)info.GetValue("PositionName", typeof(string));
        }

        public long PositionId { get; }

        public string PositionName { get; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PositionId", this.PositionId, typeof(long));
            info.AddValue("PositionName", this.PositionName, typeof(string));
        }
    }
}
