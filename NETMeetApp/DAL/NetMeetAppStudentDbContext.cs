using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NETMeetApp.Models;

namespace NETMeetApp.DAL
{
    public class NetMeetAppStudentDbContext : IdentityDbContext<StudentAppUser>
    {
        public DbSet<Group> Groups { get; set; }
        public NetMeetAppStudentDbContext(DbContextOptions<NetMeetAppStudentDbContext> options) : base(options)
        {

        }
    }
}
