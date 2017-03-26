namespace Models.Dashboard
{
    public class SuggestedUser
    {
        public SuggestedUser(string userName, string fullName, decimal matchedPercentage, byte[] userImage)
        {
            this.UserName = UserName;
            this.FullName = fullName;
            this.MatchPersentage = matchedPercentage;
            this.UserImage = userImage;
        }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public decimal MatchPersentage { get; set; }

        public byte[] UserImage { get; set; }
    }
}
