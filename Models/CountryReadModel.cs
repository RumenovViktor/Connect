namespace Models.Global
{
    public class CountryReadModel
    {
        public CountryReadModel() { }

        public CountryReadModel(int countryId, string countryName)
        {
            this.CountryId = countryId;
            this.CountryName = countryName;
        }

        public int CountryId { get; set; }

        public string CountryName { get; set; }
    }
}
