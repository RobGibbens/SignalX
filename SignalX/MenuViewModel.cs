using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace SignalX
{

	public class MenuViewModel
	{
		public MenuViewModel ()
		{
			MenuItems = new ObservableCollection<MenuItem>() {
				new MenuItem { Text = "Conflicts" },
				new MenuItem { Text = "New items in list" },
				new MenuItem { Text = "Alert message" },
				new MenuItem { Text = "Local notification" },
			};
		}

		public IList<MenuItem> MenuItems { get; set; }
	}
	
}