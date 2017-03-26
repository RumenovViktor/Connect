using Models;
using Models.Dashboard;
using System.Collections.Generic;

namespace ApplicationServices
{
    public interface IDashboardManager
    {
        IList<UserSuitiblePosition> GetSuitiblePositions(int? sectorId, int? countryId, int userId);
        IList<SuggestedUser> GetCandidateSuggestions(int? sectorId, int? countryId, int positionId);
    }
}
