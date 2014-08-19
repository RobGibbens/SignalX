using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SignalX
{
	public class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public void RaisePropertyChanged ([CallerMemberName] string propertyName = "")
		{
			PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
		}
	}
}