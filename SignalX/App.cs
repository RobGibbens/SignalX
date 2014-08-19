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

		static string _userId;
		public static string UserId {
			get {
				if (_userId == null) {
					_userId = Guid.NewGuid ().ToString();
				}
				return _userId;
			}
		}

		public static Page GetMainPage ()
		{	
			var userId = App.UserId;
			Task.Run(async () => await App.SignalXClient.Connect ());

			return new MainPage ();
		}
	}
}