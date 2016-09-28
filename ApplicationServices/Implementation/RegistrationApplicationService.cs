﻿namespace ApplicationServices
{
    using Models;

    public class RegistrationApplicationService : IRegistrationApplicationService
    {
        public UserRegistration Execute(UserRegistration command)
        {
            var registeredUser = WebServiceProvider<UserRegistration>.Post(command);
            return registeredUser;
        }
    }
}
