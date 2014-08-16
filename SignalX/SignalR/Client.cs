using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace SignalX
{
	public class Client
	{
		private readonly HubConnection _connection;
		private readonly IHubProxy _chatHub;
		private readonly IHubProxy _conflictHub;
		private readonly IHubProxy _newsHub;

		public event EventHandler<string> OnMessageReceived;
		public event EventHandler<string> OnChatReceived;
		public event EventHandler OnUserSaved;
		public event EventHandler OnNewsAdded;

		public Client()
		{
			_connection = new HubConnection("http://signalx.azurewebsites.net");

			_connection.Error += ex => {
				var sdsd = string.Format("SignalR error: {0}\r\n", ex.Message);
				//Console.WriteLine(sdsd);
			};
			_chatHub = _connection.CreateHubProxy("chathub");
			_conflictHub = _connection.CreateHubProxy("conflicthub");
			_newsHub = _connection.CreateHubProxy("newshub");

		}

		public async Task Connect()
		{
			await _connection.Start();

			_chatHub.On("addMessage", (string message) =>
				{
					if (OnMessageReceived != null)
						OnMessageReceived(this, string.Format("{0}", message));

					if (OnChatReceived != null)
						OnChatReceived(this, string.Format("{0}", message));
				});

			_conflictHub.On("userSaved", () =>
				{
					if (OnUserSaved != null)
						OnUserSaved(this, new EventArgs());
				});

			_newsHub.On("newsAdded", (object item) =>
				{
					if (OnNewsAdded != null)
						OnNewsAdded(this, new EventArgs());
				});

			await Send("Connected");
		}
			
		public Task Send(string message)
		{
			return _chatHub.Invoke("sendMessage", message);
		}
	}
}