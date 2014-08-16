using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SignalX
{
	public partial class AlertPage : ContentPage
	{
		public AlertPage ()
		{
			InitializeComponent ();

			ToolbarItems.Add (new ToolbarItem ("Info", "info.png", async () => {
				await DisplayAlert ("Info", "Message", "OK");
			}));
		}
	}
}