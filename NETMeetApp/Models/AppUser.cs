using Microsoft.AspNetCore.Identity;
using NETMeetApp.Enums;

namespace NETMeetApp.Models
{
    public class AppUser : IdentityUser
    {
        public int? Grade { get; set; }
        public string? imageUrl { get; set; }
        public string? Country { get; set; }
        public string? BioGraphy { get; set; }
        public int? Age { get; set; }
        public string FullName { get; set; }
        public int? GroupId { get; set; }
        public Group? Group { get; set; }
        public UserType UserType { get; set; }
    }
}
