using Models.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Global
{
    public class ActivityAreaReadModel
    {
        public ActivityAreaReadModel(IList<CountryReadModel> countries, IList<SupportedSector> sectors)
        {
            this.Countries = countries;
            this.Sectors = sectors;
        }

        public IList<CountryReadModel> Countries { get; set; }

        public IList<SupportedSector> Sectors { get; set; }
    }
}
