using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NETMeetApp.Models;

namespace NETMeetApp.DAL
{
    public class NetMeetAppTeacherDbContext : IdentityDbContext<TeacherAppUser>
    {
        public NetMeetAppTeacherDbContext(DbContextOptions<NetMeetAppTeacherDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TeacherAppUser>().ToTable("TeacherAspNetUsers");
            builder.Entity<IdentityRole>().ToTable("TeacherAspNetRoles");
            builder.Entity<IdentityUserRole<string>>().ToTable("TeacherAspNetUserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("TeacherAspNetUserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("TeacherAspNetUserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("TeacherAspNetRoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("TeacherAspNetUserTokens");
        }


    }
}
