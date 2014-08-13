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

			App.SignalXClient.OnUserSaved +=  (sender, e) => {
				DisplayAlert("CONFLICT!", "Another user have saved this record on the server", "Cancel");
			};
		}
	}
}