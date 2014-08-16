﻿using System;
using Xamarin.Forms;

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
			return new MainPage ();
			//return new NavigationPage(new MainPage ());
		}
	}
}