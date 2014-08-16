using Xamarin.Forms;

namespace SignalX
{
	public partial class MenuPage : ContentPage
	{
		public MenuPage ()
		{
			InitializeComponent ();
			var viewModel = new MenuViewModel ();
			this.BindingContext = viewModel;
			this.menu.ItemTapped += OnItemTapped;
		}

		async void OnItemTapped (object sender, ItemTappedEventArgs e)
		{
			var tappedItem = (MenuItem)e.Item;

			switch (tappedItem.Text) {
			case "Conflicts":
				await this.Navigation.PushAsync (new ConflictPage ());
				break;
			case "Chat":
				await this.Navigation.PushAsync (new ChatPage ());
				break;
			case "News items":
				await this.Navigation.PushAsync (new NewsPage ());
				break;
			case "Alert message":
				await this.Navigation.PushAsync (new AlertPage ());
				break;
			case "Local notification":
				await this.Navigation.PushAsync (new NotificationPage ());
				break;
			}
		
			//await this.Navigation.PushAsync(new ContactDetails(tappedPerson));
		}
	}
}