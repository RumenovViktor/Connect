namespace ApplicationServices
{
    using Models;

    public interface ILoginApplicationService 
        : IHandles<UserLogin>,
        IHandles<CompanyLogin>
    {
    }
}
