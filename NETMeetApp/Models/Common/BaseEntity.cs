namespace NETMeetApp.Models.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime DeletedTime { get; set; }
    }
}
