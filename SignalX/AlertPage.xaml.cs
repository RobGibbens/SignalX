using Xamarin.Forms;

namespace SignalX
{
	public class AlertPageBase :  ViewPage<AlertViewModel>
	{
	}

	public partial class AlertPage : AlertPageBase
	{
		public AlertPage ()
		{
			InitializeComponent ();

			ToolbarItems.Add (new ToolbarItem ("Info", "info.png", async () => 
				await DisplayAlert ("Info", "Message", "OK")
			));

			MessagingCenter.Subscribe<ErrorAlert> (this, "Error", (errorAlert) => 
				Device.BeginInvokeOnMainThread (() => 
					this.DisplayAlert ("Alert!", "Message", "OK")
				)
			);
		}
	}
}