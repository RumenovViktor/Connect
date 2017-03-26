namespace Models.Dashboard
{
    public class UserDashboardProfile
    {
        public UserDashboardProfile(string fullName, string currentPosition, byte[] profileImage, string userName)
        {
            this.FullName = fullName;
            this.CurrentPosition = currentPosition;
            this.ProfileImage = profileImage;
            this.UserName = userName;
        }

        public byte[] ProfileImage { get; set; }

        public string FullName { get; set; }

        public string CurrentPosition { get; set; }

        public string UserName { get; set; }
    }
}
