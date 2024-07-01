using Microsoft.AspNetCore.SignalR;

namespace NETMeetApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string userrr, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", userrr, message);
        }
    }
}
