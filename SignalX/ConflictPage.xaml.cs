using Xamarin.Forms;

namespace SignalX
{
	public class ConflictPageBase :  ViewPage<ConflictViewModel>
	{
	}

	public partial class ConflictPage : ConflictPageBase
	{
		public ConflictPage ()
		{
			InitializeComponent ();

			ToolbarItems.Add (new ToolbarItem ("Info", "info.png", async () => 
				await DisplayAlert ("Info", "Message", "OK")
			));
		}
	}
}