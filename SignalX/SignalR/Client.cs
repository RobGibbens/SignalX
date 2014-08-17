using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json.Linq;

namespace SignalX
{
	public class Client
	{
		private readonly HubConnection _connection;
		private readonly IHubProxy _chatHub;
		private readonly IHubProxy _conflictHub;
		private readonly IHubProxy _newsHub;
		private readonly IHubProxy _alertHub;

		public event EventHandler<string> OnMessageReceived;
		public event EventHandler<string> OnChatReceived;
		public event EventHandler<string> OnAlertSent;
		public event EventHandler OnUserSaved;
		public event EventHandler<NewsItem> OnNewsAdded;

		public Client()
		{
			_connection = new HubConnection("http://signalx.azurewebsites.net");

			_connection.Error += ex => {
				var error = string.Format("SignalR error: {0}\r\n", ex.Message);
			};
			_chatHub = _connection.CreateHubProxy("chathub");
			_conflictHub = _connection.CreateHubProxy("conflicthub");
			_newsHub = _connection.CreateHubProxy("newshub");
			_alertHub = _connection.CreateHubProxy("alerthub");

		}

		public async Task Connect()
		{
			if (_connection.State != ConnectionState.Connected) {
				await _connection.Start ();

				_chatHub.On ("addMessage", (string message) => {
					if (OnChatReceived != null)
						OnChatReceived (this, string.Format ("{0}", message));
				});

				_conflictHub.On ("userSaved", () => {
					if (OnUserSaved != null)
						OnUserSaved (this, new EventArgs ());
				});

				_newsHub.On ("newsAdded", (JContainer item) => {
					var newsItem = item.ToObject<NewsItem> ();
					if (OnNewsAdded != null)
						OnNewsAdded (this, newsItem);
				});

				_alertHub.On ("alertSent", (string message) => {

					if (OnAlertSent != null)
						OnAlertSent (this, message);
				});

				await Send ("Connected");
			}
		}
			
		public Task Send(string message)
		{
			return _chatHub.Invoke("sendMessage", message);
		}
	}
}