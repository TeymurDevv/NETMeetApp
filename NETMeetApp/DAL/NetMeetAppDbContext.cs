using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NETMeetApp.Models;

namespace NETMeetApp.DAL
{
    public class NetMeetAppDbContext : IdentityDbContext<AppUser>
    {
       
        public NetMeetAppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<HomeWork> Homeworks { get; set; }

    }
}
