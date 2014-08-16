using Xamarin.Forms;

namespace SignalX
{	
	public partial class NotificationPage : ContentPage
	{	
		public NotificationPage ()
		{
			InitializeComponent ();

			ToolbarItems.Add (new ToolbarItem ("Info", "info.png", async () => {
				await DisplayAlert ("Info", "Message", "OK");
			}));
		}
	}
}