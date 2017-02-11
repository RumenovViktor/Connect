namespace ApplicationServices
{
    using System;
    using Connect.Helpers;
    using Models;

    public class RegistrationApplicationService : IRegistrationApplicationService
    {
        public UserRegistration Execute(UserRegistration command)
        {
            var registeredUser = WebServiceProvider<UserRegistration>.Post(command, UrlHelper.RegistrationApiUrl);
            return registeredUser;
        }

        public CompanyRegistration Execute(CompanyRegistration command)
        {
            var company = WebServiceProvider<CompanyRegistration>.Post(command, UrlHelper.CompanyRegistrationUrl);
            return company;
        }
    }
}
