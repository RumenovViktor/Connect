namespace Models
{
    public class UserSuitiblePosition
    {
        public UserSuitiblePosition(long positionId, string positionName, decimal matchPersentage)
        {
            this.PositionId = positionId;
            this.PositionName = positionName;
            this.MatchPersentage = matchPersentage;
        }

        public long PositionId { get; set; }

        public string PositionName { get; set; }

        public string PositionImage { get; set; } // Todo: Change to position image

        public decimal MatchPersentage { get; set; }
    }
}
