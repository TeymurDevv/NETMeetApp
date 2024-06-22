using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

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

        public async Task StartMicrophone(string meetingId, string user)
        {
            await Clients.Group(meetingId).SendAsync("MicrophoneStarted", user, Context.ConnectionId);
        }

        public async Task StopMicrophone(string meetingId, string user)
        {
            await Clients.Group(meetingId).SendAsync("MicrophoneStopped", user, Context.ConnectionId);
        }

        public async Task StartCamera(string meetingId, string user)
        {
            await Clients.Group(meetingId).SendAsync("CameraStarted", user, Context.ConnectionId);
        }

        public async Task StopCamera(string meetingId, string user)
        {
            await Clients.Group(meetingId).SendAsync("CameraStopped", user, Context.ConnectionId);
        }

        public async Task StartScreenShare(string meetingId, string user)
        {
            await Clients.Group(meetingId).SendAsync("ScreenShareStarted", user, Context.ConnectionId);
        }

        public async Task StopScreenShare(string meetingId, string user)
        {
            await Clients.Group(meetingId).SendAsync("ScreenShareStopped", user, Context.ConnectionId);
        }
    }
}
