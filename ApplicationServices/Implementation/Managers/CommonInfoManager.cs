namespace ApplicationServices
{
    using Models.Global;
    using Connect.Helpers;
    using Data.Unit_Of_Work;
    using System.Linq;
    using Models;
    using System.Collections.Generic;
    public class CommonInfoManager : ICommonInfoManager
    {
        private readonly IDALServiceData dalServiceData;

        public CommonInfoManager(IDALServiceData data)
        {
            dalServiceData = data;
        }

        public ActivityAreaReadModel GetActivityArea()
        {
            var countries = dalServiceData.Countries.All().ToList().Select(x => new CountryReadModel(x.CountryId, x.NiceName)).ToList();
            var sectors = dalServiceData.Sectors.All().ToList().Select(x => new SupportedSector(x.Id, x.Name)).ToList();

            return new ActivityAreaReadModel(countries, sectors);
        }
    }
}
