﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace SignalX
{	
	public partial class NewsPage : ContentPage
	{	
		private readonly NewsViewModel _viewModel;
		public NewsPage ()
		{
			InitializeComponent ();

			_viewModel = new NewsViewModel ();

			this.BindingContext = _viewModel;

			ConnectClient ();
		}

		private async Task ConnectClient()
		{
			await App.SignalXClient.Connect ();

			;
			App.SignalXClient.OnNewsAdded += (sender, newsItem) => {
				_viewModel.NewsItems.Add (newsItem);
			};
		}
	}
}