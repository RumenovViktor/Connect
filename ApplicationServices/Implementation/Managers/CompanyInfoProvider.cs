namespace ApplicationServices
{
    using System;
    using System.Linq;

    using Models;
    using Data.Unit_Of_Work;
    using Models.Global;

    public class CompanyInfoProvider : ICompanyInfoProvider
    {
        private readonly IDALServiceData dalServiceData;

        public CompanyInfoProvider(IDALServiceData data)
        {
            dalServiceData = data;
        }

        public CompanyProfile GetCompanyProfile(long companyId)
        {
            var companyProfile = dalServiceData.Companies.FindEntity(x => x.Id == companyId);
            var mappedCompanyPositions = companyProfile.Positions.Select(x => new CreatedPosition(x.Id, x.PositionName)).ToList();
            var country = dalServiceData.Countries.FindEntity(x => x.CountryId == companyProfile.CountryId);

            if (companyProfile == null)
            {
                throw new ArgumentException();
            }

            return new CompanyProfile(companyProfile.Email, companyProfile.Name, new CountryReadModel(country.CountryId, country.NiceName), mappedCompanyPositions);
        }
    }
}
