using Models;

namespace Connect.ServiceProvider.Implementation
{
    public class RegistrationServiceProvider : RequestSender<UserRegistrationViewModel>, IServiceProvider<UserRegistrationViewModel>
    {
        public UserRegistrationViewModel Handle(UserRegistrationViewModel command)
        {
            var registeredUser = Post(command);
            return null;
        }
    }
}
