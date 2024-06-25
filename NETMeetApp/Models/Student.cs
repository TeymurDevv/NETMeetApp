using NETMeetApp.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class Student : User
{
    public int Grade { get; set; }
    [ForeignKey("GroupId")]
    public Group Group { get; set; }
    public int GroupId { get; set; }

}