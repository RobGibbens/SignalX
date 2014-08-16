using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace SignalX
{	
	public partial class ChatPage : ContentPage
	{	
		private readonly ChatViewModel _viewModel;
		public ChatPage ()
		{
			InitializeComponent ();

			_viewModel = new ChatViewModel ();

			this.BindingContext = _viewModel;

			ConnectClient ();
		}

		private async Task ConnectClient()
		{
			await App.SignalXClient.Connect ();

			App.SignalXClient.OnChatReceived += (sender, e) => {
				_viewModel.ChatMessages.Add (new ChatMessage { Message = e });
			};

			this.Send.Clicked += async (sender, e) => {
				var message = this.messageToSend.Text;
				await App.SignalXClient.Send(message);
				_viewModel.MessageToSend = string.Empty;
			};
		}
	}
}

