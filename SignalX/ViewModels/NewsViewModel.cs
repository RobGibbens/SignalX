using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SignalX
{
	public class NewsViewModel : ViewModelBase
	{
		public NewsViewModel ()
		{
			this.NewsItems = new ObservableCollection<NewsItem> ();
			App.SignalXClient.OnNewsAdded += (sender, newsItem) => 
				this.NewsItems.Add (newsItem);
		}

		public IList<NewsItem> NewsItems { get; set; }
	}
}