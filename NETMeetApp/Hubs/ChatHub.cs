using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using NETMeetApp.Models;
using System.Collections.Concurrent;

public class ChatHub : Hub
{
    private static readonly ConcurrentDictionary<string, string> UserConnections = new ConcurrentDictionary<string, string>();
    private readonly UserManager<AppUser> _userManager;

    public ChatHub(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public override async Task OnConnectedAsync()
    {
        if (Context.User.Identity.IsAuthenticated)
        {
            var user = await _userManager.FindByNameAsync(Context.User.Identity.Name);
            if (user != null)
            {
                user.Connectionid = Context.ConnectionId;
                await _userManager.UpdateAsync(user);
                await Clients.Others.SendAsync("OnConnect", user);
            }
        }

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        if (Context.User.Identity.IsAuthenticated)
        {
            var user = await _userManager.FindByNameAsync(Context.User.Identity.Name);
            if (user != null)
            {
                user.Connectionid = null;
                await _userManager.UpdateAsync(user);
                await Clients.Others.SendAsync("DisConnect", user.Id);
            }
        }

        await base.OnDisconnectedAsync(exception);
    }


    public async Task SendMessageGeneral(string message)
    {
        var user = await _userManager.GetUserAsync(Context.User);
        if (user != null)
        {
            await Clients.All.SendAsync("RecieveMessageGeneral", message, user);
        }
    }
}
