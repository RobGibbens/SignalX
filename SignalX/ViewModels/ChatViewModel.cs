using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SignalX
{
	public class ChatViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public ChatViewModel ()
		{
			ChatMessages = new ObservableCollection<ChatMessage> ();
		}

		public IList<ChatMessage> ChatMessages { get; set; }

		string messageToSend;
		public string MessageToSend {
			get {
				return messageToSend;
			}
			set {
				if (messageToSend != value) {
					messageToSend = value;
					PropertyChanged(this, new PropertyChangedEventArgs("MessageToSend"));
				}
			}
		}
	}
}