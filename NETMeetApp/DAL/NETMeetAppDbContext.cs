using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NETMeetApp.Models;

namespace NETMeetApp.DAL
{
    public class NETMeetAppDbContext : IdentityDbContext<AppUser>
    {
        public NETMeetAppDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
