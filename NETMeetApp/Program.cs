using NETMeetApp;
using NETMeetApp.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var config = builder.Configuration;
builder.Services.Register(config);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseCors("CorsPolicy");
app.UseAuthorization();
app.UseAuthentication();
app.MapControllerRoute(
           name: "areas",
           pattern: "{area:exists}/{controller=DashBoard}/{action=Index}/{id?}"
         );
app.MapDefaultControllerRoute();

app.MapHub<ChatHub>("/chatHub");
app.MapHub<VideoHub>("/videoHub");



app.Run();
