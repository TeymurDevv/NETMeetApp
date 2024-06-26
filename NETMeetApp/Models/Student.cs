namespace NETMeetApp.Models
{
    public class Student:AppUser
    {
        public int Grade { get; set; }
        public bool isPassed => Grade >= 60 ? true : false;
        public int GroupId  { get; set; }
        public Group Group { get; set; }
    }
}
