using Microsoft.Build.Framework;
using NETMeetApp.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETMeetApp.Models
{
    public class Group:BaseEntity
    {
        [Required]
        public string Name { get; set; }    
        public int Capacity { get; set; }
        public string Image { get; set; }

        public List<Student> Students { get; set; }
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }
        public int  TeacherId { get; set; }

    }
}
