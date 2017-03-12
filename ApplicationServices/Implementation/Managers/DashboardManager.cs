using Connect.Helpers;
using Models;
using System.Collections.Generic;

namespace ApplicationServices
{
    public class DashboardManager : IDashboardManager
    {
        public IList<UserSuitiblePosition> GetSuitiblePositions(int? sectorId, int? countrId, string userId)
        {
            var suitiblePositions = WebServiceProvider<IList<UserSuitiblePosition>>.Get(UrlHelper.UserSuitiblePositions, new Dictionary<string, string>()
            {
                { "sectorId", sectorId.ToString() },
                { "countryId", countrId.ToString() },
                { "userId", userId }
            });


            return suitiblePositions;
        }
    }
}
