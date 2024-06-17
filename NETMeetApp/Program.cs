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

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapHub<MeetingHub>("/meet");
    endpoints.MapControllerRoute(
        name: "meet",
        pattern: "meet/{meetId}",
        defaults: new { controller = "Meet", action = "Index" });
});


app.Run();
