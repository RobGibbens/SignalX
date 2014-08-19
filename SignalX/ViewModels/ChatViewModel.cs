using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SignalX
{
	public class ChatViewModel : INotifyPropertyChanged
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

		public event PropertyChangedEventHandler PropertyChanged;

		void RaisePropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}