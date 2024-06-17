using NETMeetApp.Models;

public class Student : User
{
    public int Grade { get; set; }

    public Student()
    {
        UserType = "Student";
    }
}