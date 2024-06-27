namespace NETMeetApp.Models
{
    public class Teacher:AppUser
    {
        public string CVUrl { get; set; }
        public int GroupId { get; set; }  // Foreign key for Group
        public virtual Group Group { get; set; }  // Navigation property
        public List<Group> Groups { get; set; }

    }
}
