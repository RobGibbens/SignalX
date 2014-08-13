using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace SignalX
{
	public class Client
	{
		private readonly HubConnection _connection;
		private readonly IHubProxy _proxy;

		public event EventHandler<string> OnMessageReceived;
		public event EventHandler OnUserSaved;

		public Client()
		{
			_connection = new HubConnection("http://signalx.azurewebsites.net");

			_connection.Error += ex => {
				var sdsd = string.Format("SignalR error: {0}\r\n", ex.Message);
				//Console.WriteLine(sdsd);
			};
			_proxy = _connection.CreateHubProxy("chathub");
		}

		public async Task Connect()
		{
			await _connection.Start();

			_proxy.On("addMessage", (string message) =>
				{
					if (OnMessageReceived != null)
						OnMessageReceived(this, string.Format("{0}", message));
				});

			_proxy.On("userSaved", () =>
				{
					if (OnUserSaved != null)
						OnUserSaved(this);
				});

			await Send("Connected");
		}

		public Task Send(string message)
		{
			return _proxy.Invoke("sendMessage", message);
		}
	}
}