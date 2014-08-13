using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalX.Web.Hubs
{
	[HubName("conflicthub")]
	public class ConflictHub : Hub
	{
		public void saveUser()
		{
			Clients.All.userSaved();
		}
	}
}