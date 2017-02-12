using Models;

namespace ApplicationServices
{
    public interface ICompanyInfoProvider
    {
        CompanyProfile GetCompanyProfile(string companyName);
    }
}
