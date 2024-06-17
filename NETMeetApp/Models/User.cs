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

        public enum Gender { Male, Female }
    }
}
