namespace Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    public class ExperienceViewModel : ICommand, ISerializable
    {
        public ExperienceViewModel()
        {

        }
        public ExperienceViewModel(SerializationInfo info, StreamingContext context)
        {
            this.Position = (string)info.GetValue("Position", typeof(string));
            this.Description = (string)info.GetValue("Description", typeof(string));
            this.StartDate = (DateTime)info.GetValue("StartDate", typeof(DateTime));
            this.EndDate = (DateTime?)info.GetValue("EndDate", typeof(DateTime?));
            this.Position = (string)info.GetValue("Position", typeof(string));
            this.UserEmail = (string)info.GetValue("UserEmail", typeof(string));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Position", this.Position, typeof(string));
            info.AddValue("Description", this.Description, typeof(string));
            info.AddValue("StartDate", this.StartDate, typeof(DateTime));
            info.AddValue("EndDate", this.EndDate, typeof(DateTime?));
            info.AddValue("UserEmail", this.UserEmail, typeof(string));

        }
        [Required]
        public string Position { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public string Description { get; set; }

        public string UserEmail { get; set; }
    }
}
