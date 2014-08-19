using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using System.Threading.Tasks;

namespace SignalX
{
	public class ChatViewModel : ViewModelBase
	{
		public ChatViewModel ()
		{
			ChatMessages = new ObservableCollection<ChatMessage> ();

			App.SignalXClient.OnChatReceived += (sender, chatMessage) => 
				this.ChatMessages.Add (chatMessage);
		}

		public IList<ChatMessage> ChatMessages { get; set; }


		public ICommand SendMessage
		{
			get {
				return new Command(async () =>
					{
						await Send();
					});
			}
		}

		private async Task Send()
		{
			await App.SignalXClient.Send(this.MessageToSend, App.UserId);
			this.MessageToSend = string.Empty;
		}

		string messageToSend;
		public string MessageToSend {
			get {
				return messageToSend;
			}
			set {
				if (messageToSend != value) {
					messageToSend = value;
					RaisePropertyChanged ();
				}
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