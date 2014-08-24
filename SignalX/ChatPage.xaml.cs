using Xamarin.Forms;

namespace SignalX
{	
	public class ChatPageBase : ViewPage<ChatViewModel> {}

	public partial class ChatPage : ChatPageBase
	{	
		public ChatPage ()
		{
			InitializeComponent ();

			ToolbarItems.Add (new ToolbarItem ("Info", "info.png", async () => 
				await DisplayAlert ("Info", this.ViewModel.InfoMessage, "OK")
			));
		}
	}
}