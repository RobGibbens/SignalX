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
		}
	}
}