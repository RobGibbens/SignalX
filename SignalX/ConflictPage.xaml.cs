using Xamarin.Forms;

namespace SignalX
{
	public partial class ConflictPage : ContentPage
	{
		readonly ConflictViewModel _viewModel;

		public ConflictPage ()
		{
			InitializeComponent ();

			_viewModel = new ConflictViewModel ();

			this.BindingContext = _viewModel;

			ToolbarItems.Add (new ToolbarItem ("Info", "info.png", async () => 
				await DisplayAlert ("Info", "Message", "OK")
			));
		}
	}
}