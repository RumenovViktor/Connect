using Models.Global;
using System.Collections.Generic;

namespace Models
{
    public class CompanyProfile
    {
        public CompanyProfile()
        {
            this.Employees = new List<string>();
        }

        public CompanyProfile(string email, string companyName, CountryReadModel country, IList<CreatedPosition> createdPositions)
        {
            this.Email = email;
            this.CompanyName = companyName;
            this.Country = country;
            this.CreatedPositions = createdPositions;
            this.Employees = new List<string>();
        }

        public string Email { get; set; }

        public string CompanyName { get; set; }

        public CountryReadModel Country { get; set; }

        public IList<CreatedPosition> CreatedPositions { get; set; }

        public IList<string> Employees { get; set; }
    }
}
