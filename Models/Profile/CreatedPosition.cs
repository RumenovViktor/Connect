using System;
using System.Runtime.Serialization;

namespace Models
{
    public class CreatedPosition
    {
        public CreatedPosition() { }

        public CreatedPosition(long positionId, string positionName)
        {
            this.PositionId = positionId;
            this.PositionName = positionName;
        }

        public long PositionId { get; }

        public string PositionName { get; }
    }
}
