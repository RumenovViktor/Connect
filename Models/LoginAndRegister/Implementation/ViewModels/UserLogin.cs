using System;
using System.Runtime.Serialization;

namespace Models
{
    public class UserLogin : BaseUser, ICommand, ISerializable
    {
        public UserLogin() { }

        public UserLogin(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public UserLogin(SerializationInfo info, StreamingContext context)
        {
            this.UserId = (long)info.GetValue("UserId", typeof(long));
            base.Email = (string)info.GetValue("Email", typeof(string));
            base.Password = (string)info.GetValue("Password", typeof(string));
            this.DoesUserExists = (bool)info.GetValue("DoesUserExists", typeof(bool));
        }

        public bool DoesUserExists { get; set; }
        public long UserId { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("UserId", this.UserId, typeof(long));
            info.AddValue("Email", base.Email, typeof(string));
            info.AddValue("Password", base.Password, typeof(string));
            info.AddValue("DoesUserExists", this.DoesUserExists, typeof(bool));
        }
    }
}