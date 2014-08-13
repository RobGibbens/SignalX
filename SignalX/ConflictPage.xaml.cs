using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace SignalX
{	
	public partial class ConflictPage : ContentPage
	{	
		public ConflictPage ()
		{
			InitializeComponent ();
			ConnectClient ();
		}

		private async Task ConnectClient()
		{
			await App.SignalXClient.Connect ();

			App.SignalXClient.OnUserSaved += async (sender, e) => {

				Device.BeginInvokeOnMainThread(() => {
					this.FirstNameEntry.Text = string.Empty;
					this.LastNameEntry.Text = string.Empty;
					DisplayAlert("CONFLICT!", "Another user have saved this record on the server", "Cancel");
				});
			};
		}
	}
}