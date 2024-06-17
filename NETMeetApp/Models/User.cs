namespace NETMeetApp.Models
{
    public abstract class User
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
        public enum Gender { Male, Female }
        public bool IsTeacher { get; set; }
        public bool IsAdmin { get; set; }

    }
}
