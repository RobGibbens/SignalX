using Xamarin.Forms;

namespace SignalX
{
	public partial class AlertPage : ContentPage
	{
		public AlertPage ()
		{
			InitializeComponent ();

			ToolbarItems.Add (new ToolbarItem ("Info", "info.png", async () => 
				await DisplayAlert ("Info", "Message", "OK")
			));

			App.SignalXClient.OnAlertSent += async (sender, e) => 
				await DisplayAlert("Alert!", e, "OK");
		}
	}
}