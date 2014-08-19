using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SignalX
{
	public class ChatViewModel : ViewModelBase
	{
		public ChatViewModel ()
		{
			ChatMessages = new ObservableCollection<ChatMessage> ();

			App.SignalXClient.OnChatReceived += (sender, e) => 
				this.ChatMessages.Add (new ChatMessage { Message = e });
		}

		public IList<ChatMessage> ChatMessages { get; set; }

		public ICommand SendMessage
		{
			get {
				return new Command(async () =>
					{
						await App.SignalXClient.Send(this.MessageToSend);
						this.MessageToSend = string.Empty;
					});
			}
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