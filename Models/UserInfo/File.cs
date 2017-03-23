using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Models
{
    public class File : ICommand, ISerializable
    {
        public string Name { get; set; }

        [Required]
        public byte[] FileInputStream { get; set; }

        public int UserId { get; set; }

        public File(SerializationInfo info, StreamingContext context)
        {
            this.Name = (string)info.GetValue("Name", typeof(string));
            this.UserId = (int)info.GetValue("UserId", typeof(int));
            this.FileInputStream = (byte[])info.GetValue("FileInputStream", typeof(byte[]));
        }

        public File(string name, byte[] fileInputStream, int userId)
        {
            this.Name = name;
            this.FileInputStream = fileInputStream;
            this.UserId = userId;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", this.Name, typeof(string));
            info.AddValue("UserId", this.UserId, typeof(int));
            info.AddValue("FileInputStream", this.FileInputStream, typeof(byte[]));
        }
    }
}
