using System.Collections.ObjectModel;
using PropertyChanged;

namespace SignalX
{
	[ImplementPropertyChanged]
	public class NewsViewModel : IViewModel
	{
		public NewsViewModel ()
		{
			this.NewsItems = new ObservableCollection<NewsItem> ();
			App.SignalXClient.OnNewsAdded += (sender, newsItem) => 
				this.NewsItems.Add (newsItem);
		}

		public ObservableCollection<NewsItem> NewsItems { get; set; }
	}
}