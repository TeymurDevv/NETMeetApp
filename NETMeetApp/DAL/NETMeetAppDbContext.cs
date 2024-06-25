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


        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Group>().ToTable("Groups");

            base.OnModelCreating(modelBuilder);
        }
    }
}
