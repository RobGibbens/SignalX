using System;
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

			ClearError.Clicked += (sender, e) => {
				_viewModel.ErrorMessage = string.Empty;
				_viewModel.HasErrors = false;
			};

			App.SignalXClient.OnUserSaved += HandleOnUserSaved;
		}

		void HandleOnUserSaved (object sender, EventArgs e)
		{
			Device.BeginInvokeOnMainThread(() => {

				_viewModel.HasErrors = true;
				_viewModel.ErrorMessage = "Conflict: Another user has saved this record on the server";
				_viewModel.FirstName = string.Empty;
				_viewModel.LastName = string.Empty;

				//DisplayAlert("CONFLICT!", "Another user has saved this record on the server", "OK");
			});
		}
	}
}