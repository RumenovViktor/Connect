using Connect.Helpers;
using Data.Unit_Of_Work;
using Executors;
using Models;
using System.Collections.Generic;
using System;
using Models.Dashboard;

namespace ApplicationServices
{
    public class DashboardManager : IDashboardManager
    {
        private readonly IDALServiceData dalServiceData;

        public DashboardManager(IDALServiceData data)
        {
            dalServiceData = data;
        }

        public IList<SuggestedUser> GetCandidateSuggestions(int? sectorId, int? countryId, int positionId)
        {
            var position = dalServiceData.Positions.FindEntity(x => x.Id == positionId);
            var matchedUsers = new RecruiterMatchingExecutor(dalServiceData).Match(position, sectorId, countryId);

            return matchedUsers;
        }

        public IList<UserSuitiblePosition> GetSuitiblePositions(int? sectorId, int? countryId, int userId)
        {
            var user = dalServiceData.Users.FindEntity(x => x.Id == userId);
            var matchedPositions = new UserMatchingExecutor(dalServiceData).Match(user, sectorId, countryId);

            return matchedPositions;
        }
    }
}
