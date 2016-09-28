namespace ApplicationServices
{
    using Connect.Helpers;
    using Models;

    public class RegistrationApplicationService : IRegistrationApplicationService
    {
        public UserRegistration Execute(UserRegistration command)
        {
            var registeredUser = WebServiceProvider<UserRegistration>.Post(command, UrlHelper.RegistrationApiUrl);
            return registeredUser;
        }
    }
}
