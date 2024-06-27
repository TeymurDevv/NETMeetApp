using NETMeetApp.Models.Common;

namespace NETMeetApp.Models
{
    public class Group:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public  int capacity { get; set; }
        public virtual List<Student> Students { get; set; }
        public int TeacherId { get; set; }  // Foreign key for Teacher
        public virtual Teacher Teacher { get; set; }  // Navigation property
    }
}
