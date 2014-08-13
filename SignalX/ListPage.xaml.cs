using Xamarin.Forms;
using System.Threading.Tasks;

namespace SignalX
{
	public partial class ListPage : ContentPage
	{
		private readonly NewsViewModel _viewModel;
		public ListPage ()
		{
			InitializeComponent ();

			_viewModel = new NewsViewModel ();

			this.BindingContext = _viewModel;

			ConnectClient ();
		}

		private async Task ConnectClient()
		{
			await App.SignalXClient.Connect ();

			App.SignalXClient.OnMessageReceived += (sender, e) => {
				_viewModel.NewsItems.Add (new NewsItem { Title = e });
			};
		}
	}
}