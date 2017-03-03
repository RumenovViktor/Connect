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
        public ActivityAreaReadModel(IList<CountryReadModel> countries)
        {
            this.Countries = countries;
        }

        public IList<CountryReadModel> Countries { get; set; }
    }
}
