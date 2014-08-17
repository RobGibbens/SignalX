using Xamarin.Forms;

namespace SignalX
{	
	public partial class NewsPage : ContentPage
	{	
		private readonly NewsViewModel _viewModel;
		public NewsPage ()
		{
			InitializeComponent ();

			ToolbarItems.Add (new ToolbarItem ("Info", "info.png", async () => 
				await DisplayAlert ("Info", "Message", "OK")
			));

			_viewModel = new NewsViewModel ();

			this.BindingContext = _viewModel;

			App.SignalXClient.OnNewsAdded += (sender, newsItem) => 
				_viewModel.NewsItems.Add (newsItem);
			
		}
	}
}