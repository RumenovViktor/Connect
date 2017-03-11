namespace Models.Profile
{
    public class UserSuitiblePosition
    {
        public UserSuitiblePosition(long companyId, long positionId, string companyName, string positionName, decimal matchPersentage)
        {
            this.CompanyId = companyId;
            this.PositionId = positionId;
            this.CompanyName = companyName;
            this.PositionName = positionName;
            this.MatchPersentage = matchPersentage;
        }

        public long CompanyId { get; set; }

        public long PositionId { get; set; }

        public string CompanyName { get; set; }

        public string PositionName { get; set; }

        public string PositionImage { get; set; } // Todo: Change to position image

        public decimal MatchPersentage { get; set; }
    }
}
