using Microsoft.Phone.Controls;
using Xamarin.Forms;

namespace SignalX.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            Content = SignalX.App.GetMainPage().ConvertPageToUIElement(this);
        }
    }
}