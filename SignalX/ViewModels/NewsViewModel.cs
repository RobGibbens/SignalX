using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SignalX
{
	public class NewsViewModel
	{
		public NewsViewModel ()
		{
			this.NewsItems = new ObservableCollection<NewsItem> (){ };
		}

		public IList<NewsItem> NewsItems { get; set; }
	}
}