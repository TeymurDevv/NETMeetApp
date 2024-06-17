using Microsoft.EntityFrameworkCore;
using NETMeetApp.Models;

namespace NETMeetApp.DAL
{
    public class NETMeetAppDbContext : DbContext
    {
        public NETMeetAppDbContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            modelBuilder.Entity<Student>().ToTable("Students");

            base.OnModelCreating(modelBuilder);
        }
    }
}
