namespace Models
{
    using Global;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    public class CompanyRegistration : ICommand, ISerializable
    {
        public CompanyRegistration() { }

        public CompanyRegistration(ActivityAreaReadModel activityArea)
        {
            this.Countries = activityArea.Countries;
            this.Sectors = activityArea.Sectors;
        }

        public CompanyRegistration(SerializationInfo info, StreamingContext context)
        {
            this.CompanyId = (long)info.GetValue("CompanyId", typeof(long));
            this.CompanyName = (string)info.GetValue("CompanyName", typeof(string));
            this.Email = (string)info.GetValue("Email", typeof(string));
            this.Password = (string)info.GetValue("Password", typeof(string));
            this.ConfirmPassword = (string)info.GetValue("ConfirmPassword", typeof(string));
            this.CountryId = (int?)info.GetValue("Country", typeof(int?));
            this.SectorId = (int?)info.GetValue("SectorId", typeof(int?));
            this.CompanyExists = (bool)info.GetValue("CompanyExists", typeof(bool));
        }

        public long CompanyId { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public IList<CountryReadModel> Countries { get; set; }

        [Required]
        public int? CountryId { get; set; }

        public IList<SupportedSector> Sectors { get; set; }

        [Required]
        public int? SectorId { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password mismatch.")]
        public string ConfirmPassword { get; set; }

        public bool CompanyExists { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CompanyId", this.CompanyId, typeof(long));
            info.AddValue("CompanyName", this.CompanyName, typeof(string));
            info.AddValue("Email", this.Email, typeof(string));
            info.AddValue("Password", this.Password, typeof(string));
            info.AddValue("ConfirmPassword", this.ConfirmPassword, typeof(string));
            info.AddValue("CompanyExists", this.CompanyExists, typeof(bool));
            info.AddValue("Country", this.CountryId, typeof(int?));
            info.AddValue("SectorId", this.SectorId, typeof(int?));
        }
    }
}
