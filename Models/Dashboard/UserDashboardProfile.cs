namespace Models.Dashboard
{
    public class UserDashboardProfile
    {
        public UserDashboardProfile(string fullName, string currentPosition, byte[] profileImage)
        {
            this.FullName = fullName;
            this.CurrentPosition = currentPosition;
            this.ProfileImage = profileImage;
        }

        public byte[] ProfileImage { get; set; }

        public string FullName { get; set; }

        public string CurrentPosition { get; set; }
    }
}
