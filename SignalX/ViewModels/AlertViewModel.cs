using Xamarin.Forms;
using PropertyChanged;

namespace SignalX
{
	[ImplementPropertyChanged]
	public class AlertViewModel : IViewModel
	{
		public AlertViewModel ()
		{
			App.SignalXClient.OnAlertSent += (sender, e) => 
				MessagingCenter.Send<ErrorAlert> (new ErrorAlert (), "Error");
		}
	}
}