namespace Models
{
    using System.Collections.Generic;

    using Global;

    public class UserRegistrationLogin
    {
        public UserRegistrationLogin(ActivityAreaReadModel activityArea)
        {
            this.UserLogin = new UserLogin();
            this.UserRegistration = new UserRegistration();
            this.ActivityArea = activityArea;
        }

        public UserLogin UserLogin { get; set; }

        public UserRegistration UserRegistration { get; set; }

        public ActivityAreaReadModel ActivityArea { get; set; }
    }
}
