using Models;
using System.Collections.Generic;

namespace ApplicationServices
{
    public interface IDashboardManager
    {
        IList<UserSuitiblePosition> GetSuitiblePositions(int? sectorId, int? countrId, string userId);
    }
}
