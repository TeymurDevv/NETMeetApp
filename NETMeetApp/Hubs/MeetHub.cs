using Microsoft.AspNetCore.SignalR;

namespace NETMeetApp.Hubs
{
    public class MeetingHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task JoinMeeting(string meetingId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, meetingId);
        }

        public async Task LeaveMeeting(string meetingId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, meetingId);
        }

        public async Task SendMessageToMeeting(string meetingId, string user, string message)
        {
            await Clients.Group(meetingId).SendAsync("ReceiveMessage", user, message);
        }
    }
}
