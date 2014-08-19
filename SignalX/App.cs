using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace SignalX
{
	public static class App
	{
		static Client _signalXClient;
		public static Client SignalXClient {
			get {
				if (_signalXClient == null) {
					_signalXClient = new Client ();
				}
				return _signalXClient;
			}
		}

		public static Page GetMainPage ()
		{	
			Task.Run(async () => await App.SignalXClient.Connect ());

			return new MainPage ();
		}
	}
}