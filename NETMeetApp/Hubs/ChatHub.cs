using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using NETMeetApp.Models;

namespace NETMeetApp.Hubs
{
    public class ChatHub : Hub
    {
        private readonly UserManager<AppUser> _userManager;

        public ChatHub(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public override Task OnConnectedAsync()
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                var user = _userManager.FindByNameAsync(Context.User.Identity.Name).Result;
                user.Connectionid = Context.ConnectionId;
                var result = _userManager.UpdateAsync(user).Result;
                Clients.All.SendAsync("OnConnect", user);
            }

            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
