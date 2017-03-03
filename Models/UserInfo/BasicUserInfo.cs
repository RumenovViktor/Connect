using Models.Global;
using System;
using Utils;

namespace Models
{
    public class BasicUserInfo : ICommand
    {
        public BasicUserInfo(int id, byte[] profileImage, string email, string firstName, 
                            string lastName, Gender gender, DateTime DateOfCreation, CountryReadModel country)
        {
            this.Id = id;
            this.ProfileImage = profileImage;
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.Country = country;
        }

        public int Id { get; set; }
        
        public byte[] ProfileImage { get; set; }

        public string Email { get; set; }

        public CountryReadModel Country { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfCreation { get; set; }
    }
}
