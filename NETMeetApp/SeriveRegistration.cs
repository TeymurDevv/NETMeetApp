﻿using Microsoft.EntityFrameworkCore;
using NETMeetApp.DAL;

namespace NETMeetApp
{
    public static class SeriveRegistration
    {
        public static void Register(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();
            services.AddDbContext<NETMeetAppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AppConnectionString"))
            );
            services.AddSignalR();
        }
    }
}
