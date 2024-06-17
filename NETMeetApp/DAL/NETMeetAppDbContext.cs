using Microsoft.EntityFrameworkCore;

namespace NETMeetApp.DAL
{
    public class NETMeetAppDbContext : DbContext
    {
        public NETMeetAppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
