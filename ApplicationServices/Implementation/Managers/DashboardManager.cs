using Connect.Helpers;
using Data.Unit_Of_Work;
using Executors;
using Models;
using System.Collections.Generic;

namespace ApplicationServices
{
    public class DashboardManager : IDashboardManager
    {
        private readonly IDALServiceData dalServiceData;

        public DashboardManager(IDALServiceData data)
        {
            dalServiceData = data;
        }

        public IList<UserSuitiblePosition> GetSuitiblePositions(int? sectorId, int? countryId, string userId)
        {
            var user = dalServiceData.Users.FindEntity(x => x.Email == userId);
            var matchedPositions = new UserMatchingExecutor(dalServiceData).Match(user, sectorId, countryId);

            return matchedPositions;
        }
    }
}
