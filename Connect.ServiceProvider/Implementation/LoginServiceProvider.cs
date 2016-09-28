namespace Connect.ServiceProvider
{
    using Models;

    public class LoginServiceProvider : RequestSender<UserLoginViewModel>, IServiceProvider<UserLoginViewModel>
    {
        public UserLoginViewModel Handle(UserLoginViewModel command)
        {
            return new UserLoginViewModel();
        }
    }
}
