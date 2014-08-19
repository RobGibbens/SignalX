using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalX.Web.Hubs
{

    [HubName("chathub")]
    public class ChatHub : Hub
    {
        public void sendMessage(string message, string userId)
        {
            Clients.All.addMessage(message, userId);
        }
    }
}