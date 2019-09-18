using Microsoft.AspNetCore.SignalR;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MessageApp.Infrastructure.Hubs
{
    public class MessageHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();

        public void SendMesage(string senderName, string recipientId, string messageText)
        {
            string name = Context.User.Identity.Name;

            foreach (var connectionId in _connections.GetConnections(recipientId))
            {
                Clients.Client(connectionId).SendAsync("NewMessage", senderName, messageText);
            }

        }

        public override Task OnConnectedAsync()
        {
            string userId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != null)
            {
                _connections.Add(userId, Context.ConnectionId);
            }

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            string userId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != null)
            {
                _connections.Remove(userId, Context.ConnectionId);
            }

            return base.OnDisconnectedAsync(exception);
        }

    }
}
