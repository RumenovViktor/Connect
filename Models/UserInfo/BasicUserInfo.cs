﻿using Utils;

namespace Models
{
    public class BasicUserInfo : ICommand
    {
        public BasicUserInfo(string profileImage, string email, string firstName, string lastName, Gender gender)
        {
            this.ProfileImage = profileImage;
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
        }

        // TODO: Property for picture

        public string ProfileImage { get; set; }

        public string Email { get; set; }

        //public string Country { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }
    }
}