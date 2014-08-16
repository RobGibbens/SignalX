using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SignalX
{	
	public partial class MainPage : TabbedPage
	{	
		public MainPage ()
		{
			InitializeComponent ();

			this.Children.Add (new NavigationPage(new ConflictPage ()) { Title = "Conflicts", Icon = "conflicts.png" } );
			this.Children.Add (new NavigationPage(new ChatPage ()) { Title = "Chats", Icon = "chatboxes.png" } );
			this.Children.Add (new NavigationPage(new NewsPage ()) { Title = "News", Icon = "news.png" } );
			this.Children.Add (new NavigationPage(new AlertPage ()) { Title = "Alerts", Icon = "alert.png" } );
			//this.Children.Add (new NotificationPage ());
		}
	}
}