namespace ApplicationServices
{
    using Connect.Helpers;
    using Models;

    public class CompanyProfileApplicationService : ICompanyProfileApplicationService
    {
        public AddPosition Execute(AddPosition command)
        {
            return WebServiceProvider<AddPosition>.Post(command, UrlHelper.AddPositionUrl);
        }
    }
}
