using NETMeetApp.Models.Common;

namespace NETMeetApp.Models
{
    public abstract class User : BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string BioGraphy { get; set; }
        public Gender Gender { get; set; }
        public bool IsTeacher { get; set; }
        public bool IsAdmin { get; set; }
        public string UserType { get; set; } // Discriminator column

        public enum Gender { Male, Female }
    }
}
