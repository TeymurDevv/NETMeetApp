using NETMeetApp.Models.Common;

namespace NETMeetApp.Models
{
    public class Group:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity     { get; set; }
    }
}
