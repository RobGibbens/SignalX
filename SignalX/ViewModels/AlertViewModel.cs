using Xamarin.Forms;

namespace SignalX
{
	public class AlertViewModel : ViewModelBase
	{
		public AlertViewModel ()
		{
			App.SignalXClient.OnAlertSent += (sender, e) => 
				//await DisplayAlert("Alert!", e, "OK");
				MessagingCenter.Send<ErrorAlert> (new ErrorAlert (), "Error");
		}
	}
}