namespace NETMeetApp.Models
{
    public class Teacher : User
    {
        public string Subject { get; set; }
        public string CVUrl { get; set; }
        public bool IsApproved { get; set; }
    }
}
