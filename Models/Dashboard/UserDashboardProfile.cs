namespace Models.Dashboard
{
    public class UserDashboardProfile
    {
        public UserDashboardProfile(string fullName, string currentPosition)
        {
            this.FullName = fullName;
            this.CurrentPosition = currentPosition;
        }

        public string Image { get; set; } // Todo

        public string FullName { get; set; }

        public string CurrentPosition { get; set; }
    }
}
