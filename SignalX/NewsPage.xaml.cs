using Xamarin.Forms;

namespace SignalX
{	
	public class NewsPageBase :  ViewPage<NewsViewModel>
	{
	}

	public partial class NewsPage : NewsPageBase
	{	
		public NewsPage ()
		{
			InitializeComponent ();

			ToolbarItems.Add (new ToolbarItem ("Info", "info.png", async () => 
				await DisplayAlert ("Info", "Message", "OK")
			));
		}
	}
}