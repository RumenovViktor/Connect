using System;
using Models;
using Connect.Helpers;
using System.Collections.Generic;

namespace ApplicationServices
{
    public class LoginApplicationService : ILoginApplicationService
    {
        public CompanyLogin Execute(CompanyLogin command)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("companyName", command.CompanyName);
            queryParams.Add("password", command.Password);

            var existingCompany = WebServiceProvider<CompanyLogin>.Get(UrlHelper.CompanyLoginUrl, queryParams);
            return existingCompany;
        }

        public UserLogin Execute(UserLogin command)
        {
            throw new NotImplementedException();
        }
    }
}
