using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using System;

namespace SignalX
{
	public class AlertViewModel :  ViewModelBase
	{
		public AlertViewModel () : base()
		{
			App.SignalXClient.OnAlertSent += (sender, e) => 
				//await DisplayAlert("Alert!", e, "OK");
				MessagingCenter.Send<ErrorAlert> (new ErrorAlert(), "message");
		}
	}
}