using Models.Global;
using Models.Profile;
using System.Collections;
using System.Collections.Generic;

namespace Models
{
    public class TheWall
    {
        public TheWall(ActivityAreaReadModel activityArea/*, IList<UserSuitiblePosition> positions*/)
        {
            this.ActivityArea = activityArea;
            //this.Positions = positions;
        }

        public ActivityAreaReadModel ActivityArea { get; set; }

        public int CountryId { get; set; }

        public int SectorId { get; set; }

        //IList<UserSuitiblePosition> Positions { get; set; }
    }
}
