using NETMeetApp.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class Student : User
{
    public int Grade { get; set; }
   public Group Group { get; set; }
    [ForeignKey("GroupId")]
    public int GroupId { get; set; }

}