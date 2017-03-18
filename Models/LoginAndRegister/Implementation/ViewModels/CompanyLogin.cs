namespace Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    public class CompanyLogin : ICommand, ISerializable
    {
        public CompanyLogin() { }

        public CompanyLogin(long companyId, string companyName, string password) : this(companyName, password)
        {
            this.CompanyId = companyId;
        }

        public CompanyLogin(string companyName, string password)
        {
            this.CompanyName = companyName;
            this.Password = password;
        }

        public CompanyLogin(bool doesCompanyExists, long companyId) : this(doesCompanyExists)
        {
            this.CompanyId = companyId;
        }

        public CompanyLogin(bool doesCompanyExists)
        {
            this.DoesCompanyExists = doesCompanyExists;
            this.CompanyName = null;
            this.Password = null;
        }

        public CompanyLogin(SerializationInfo info, StreamingContext context)
        {
            this.CompanyId = (long)info.GetValue("CompanyId", typeof(long));
            this.CompanyName = (string)info.GetValue("CompanyName", typeof(string));
            this.Password = (string)info.GetValue("Password", typeof(string));
            this.DoesCompanyExists = (bool)info.GetValue("DoesCompanyExists", typeof(bool));
        }

        public long CompanyId { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Password { get; set; }

        public bool DoesCompanyExists { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CompanyId", this.CompanyId, typeof(long));
            info.AddValue("CompanyName", this.CompanyName, typeof(string));
            info.AddValue("Password", this.Password, typeof(string));
            info.AddValue("DoesCompanyExists", this.DoesCompanyExists, typeof(bool));
        }
    }
}
