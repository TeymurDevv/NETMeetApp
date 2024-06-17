using Microsoft.EntityFrameworkCore;
using NETMeetApp.Models;
using NETMeetApp.Models.Common;

namespace NETMeetApp.DAL
{
    public class NETMeetAppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public NETMeetAppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
