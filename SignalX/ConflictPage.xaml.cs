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

			App.SignalXClient.OnUserSaved += HandleOnUserSaved;
		}

		void HandleOnUserSaved (object sender, EventArgs e)
		{
			Device.BeginInvokeOnMainThread(() => {
				this.ConflictLabel.Text = "Conflict: Another user have saved this record on the server";
				this.FirstNameEntry.Text = string.Empty;
				this.LastNameEntry.Text = string.Empty;
				//DisplayAlert("CONFLICT!", "Another user have saved this record on the server", "Cancel");
			});
		}
	}
}