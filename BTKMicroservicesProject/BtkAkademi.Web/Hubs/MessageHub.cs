using Microsoft.AspNetCore.SignalR;

namespace BtkAkademi.Web.Hubs
{
    public class MessageHub : Hub
    {
        public async Task SendMessageToAdmin(string message, string connectionId)
        {
            string user = "User" + connectionId;
            //await Clients.AllExcept(new List<String> { connectionId }).SendAsync("lastOrder", order);
            await Clients.All.SendAsync("messageToAdmin", message, user);
        }

        public async Task SendMessageToUser(string message, string connectionId)
        {
            string user = "Admin" + connectionId;
            //await Clients.AllExcept(new List<String> { connectionId }).SendAsync("lastOrder", order);
            await Clients.All.SendAsync("messageToUser", message, user);
        }
    }
}
