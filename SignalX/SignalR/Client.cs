using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace SignalX
{
	public class Client
	{
		private readonly HubConnection _connection;
		private readonly IHubProxy _chatHub;
		private readonly IHubProxy _conflictHub;
		private readonly IHubProxy _newsHub;
		private readonly IHubProxy _alertHub;

		public event EventHandler<ChatMessage> OnChatReceived;
		public event EventHandler<string> OnAlertSent;
		public event EventHandler OnUserSaved;
		public event EventHandler<NewsItem> OnNewsAdded;

		public Client ()
		{
			_connection = new HubConnection ("http://signalx.azurewebsites.net");
//			_connection.ConnectionSlow += () => {
//				var connectionSlow = true;
////				MessagingCenter.Send<ConnectionStatus> (new ConnectionStatus () { 
////					Status = "Connection Slow"
////				} , "ConnectionChanged");
//			};
//			_connection.Received += (obj) => {
//				var rec = true;
////				MessagingCenter.Send<ConnectionStatus> (new ConnectionStatus () { 
////					Status = "Received"
////				} , "ConnectionChanged");
//			};
//			_connection.Reconnecting += () => {
//				var recon = true;
////				MessagingCenter.Send<ConnectionStatus> (new ConnectionStatus () { 
////					Status = "Reconnecting"
////				} , "ConnectionChanged");
//
//			};
//			_connection.Reconnected += () => {
//				var recon = true;
////				MessagingCenter.Send<ConnectionStatus> (new ConnectionStatus () { 
////					Status = "Reconnected" 
////				} , "ConnectionChanged");
//			};
			_connection.StateChanged += (obj) => {
				MessagingCenter.Send<ConnectionStatus> (new ConnectionStatus () { 
					Status = obj.NewState.ToString() 
				} , "ConnectionChanged");
			};
//			_connection.Closed += () => {
//				var closed = true;
////				MessagingCenter.Send<ConnectionStatus> (new ConnectionStatus () { 
////					Status = "Closed"
////				} , "ConnectionChanged");
//			};
			_connection.TransportConnectTimeout = new TimeSpan (0, 0, 10);

			_connection.Error += ex => {
				MessagingCenter.Send<ConnectionStatus> (new ConnectionStatus () { 
					Status = "Error" + ex.Message
				} , "ConnectionChanged");
			};

			_chatHub = _connection.CreateHubProxy ("chathub");
			_conflictHub = _connection.CreateHubProxy ("conflicthub");
			_newsHub = _connection.CreateHubProxy ("newshub");
			_alertHub = _connection.CreateHubProxy ("alerthub");

		}

		public async Task Connect ()
		{
			if (_connection.State != ConnectionState.Connected) {
				try {
					MessagingCenter.Send<ConnectionStatus> (new ConnectionStatus () { 
						Status = "Connecting"
					} , "ConnectionChanged");
					await _connection.Start ();

					_chatHub.On ("addMessage", (string message, string userId) => {
						if (OnChatReceived != null)
							OnChatReceived (this, new ChatMessage { Message = message, UserId = userId });
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

				} catch (Exception ex) {
					var message = ex.Message;
				}

				await Send("Connected", App.UserId);
			}
		}

		public Task Send (string message, string userId)
		{
			return _chatHub.Invoke ("sendMessage", message, userId);
		}
	}
}