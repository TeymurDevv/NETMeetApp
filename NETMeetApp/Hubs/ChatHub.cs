using Microsoft.AspNetCore.SignalR;

namespace NETMeetApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string userr, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", userr, message);
        }
    }
}
