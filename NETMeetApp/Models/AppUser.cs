using Microsoft.AspNetCore.Identity;

namespace NETMeetApp.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
