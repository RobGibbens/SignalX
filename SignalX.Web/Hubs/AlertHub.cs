using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalX.Web.Hubs
{
    [HubName("alerthub")]
    public class AlertHub : Hub
    {
        public void sendAlert(string message)
        {
            Clients.All.alertSent(message);
        }
    }
}