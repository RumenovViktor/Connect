namespace ApplicationServices
{
    using System;
    using Models;
    using System.Collections.Generic;
    using Connect.Helpers;

    public class CompanyInfoProvider : ICompanyInfoProvider
    {
        public CompanyProfile GetCompanyProfile(long companyId)
        {
            var companyProfile = WebServiceProvider<CompanyProfile>.Get(UrlHelper.CompanyInfoUrl, new Dictionary<string, string>()
            {
                { "companyId", companyId.ToString() }
            });

            return companyProfile;
        }
    }
}
