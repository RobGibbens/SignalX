using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using System.Threading.Tasks;
using PropertyChanged;

namespace SignalX
{
	[ImplementPropertyChanged]
	public class ChatViewModel : IViewModel
	{
		public ChatViewModel ()
		{
			ChatMessages = new ObservableCollection<ChatMessage> ();

			App.SignalXClient.OnChatReceived += (sender, chatMessage) => 
				this.ChatMessages.Add (chatMessage);

			MessagingCenter.Subscribe<ConnectionStatus> (this, "ConnectionChanged", (status) => {
				this.Status = "Status: " + status.Status;
			});
		}

		public ObservableCollection<ChatMessage> ChatMessages { get; set; }
		public string Status { get; set; }
		public string MessageToSend { get; set; }

		public ICommand SendMessage
		{
			get {
				return new Command(async () =>
					{
						await App.SignalXClient.Send(this.MessageToSend, App.UserId);
						this.MessageToSend = string.Empty;
					});
			}
		}

		public string InfoMessage
		{
			get {
				return "Use the Chat window to send chat messages to http://signalx.azurewebsites.net/Home/Index";
			}
		}
	}
}