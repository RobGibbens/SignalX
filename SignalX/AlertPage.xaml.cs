using Xamarin.Forms;

namespace SignalX
{
	public partial class AlertPage : ContentPage
	{
		AlertViewModel _viewModel;

		public AlertPage () : base()
		{
			InitializeComponent ();

			_viewModel = new AlertViewModel ();
			this.BindingContext = _viewModel;

			ToolbarItems.Add (new ToolbarItem ("Info", "info.png", async () => 
				await DisplayAlert ("Info", "Message", "OK")
			));

			MessagingCenter.Subscribe<ErrorAlert> (this, "", (errorAlert) => {
				DisplayAlert("Alert!", "Message", "OK");
			});
		}
	}
}