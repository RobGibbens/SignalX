using System;
using Xamarin.Forms;

namespace SignalX
{	
	public partial class ChatPage : ContentPage
	{	
		private readonly ChatViewModel _viewModel;
		public ChatPage ()
		{
			InitializeComponent ();

			ToolbarItems.Add (new ToolbarItem ("Info", "info.png", async () => 
				await DisplayAlert ("Info", "Message", "OK")
			));

			_viewModel = new ChatViewModel ();

			this.BindingContext = _viewModel;

			App.SignalXClient.OnChatReceived += (sender, e) => 
				_viewModel.ChatMessages.Add (new ChatMessage { Message = e });


			this.Send.Clicked += async (sender, e) => {
				var message = this.messageToSend.Text;
				await App.SignalXClient.Send(message);
				_viewModel.MessageToSend = string.Empty;
			};
		}
	}
}