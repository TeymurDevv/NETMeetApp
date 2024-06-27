using Microsoft.AspNetCore.SignalR;

namespace NETMeetApp.Hubs
{
    public class VideoHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task JoinVideoSession(string user)
        {
            await Clients.All.SendAsync("UserJoined", user);
        }

        public async Task LeaveVideoSession(string user)
        {
            await Clients.All.SendAsync("UserLeft", user);
        }

        public async Task StartVideoSession(string user)
        {
            await Clients.All.SendAsync("VideoSessionStarted", user);
        }

        public async Task StopVideoSession(string user)
        {
            await Clients.All.SendAsync("VideoSessionStopped", user);
        }

        public async Task SendOffer(string user, object offer)
        {
            await Clients.Others.SendAsync("ReceiveOffer", user, offer);
        }

        public async Task SendAnswer(string user, object answer)
        {
            await Clients.Others.SendAsync("ReceiveAnswer", answer);
        }

        public async Task SendICECandidate(object candidate)
        {
            await Clients.Others.SendAsync("ReceiveICECandidate", candidate);
        }
    }
}
