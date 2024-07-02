using NETMeetApp.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETMeetApp.Models
{
    public class HomeWork:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string GroupName { get; set; }
        public int Point {  get; set; }
        public string? FilePath { get; set; }
        [NotMapped]
        public string ShortDesc => Description.Length>50?Description.Substring(50):Description;
    }
}
