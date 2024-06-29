using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NETMeetApp.Models;

namespace NETMeetApp.DAL
{
    public class NetMeetAppDbContext : IdentityDbContext<AppUserUpdateVM>
    {
       
        public NetMeetAppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
