using System.Windows.Input;
using Xamarin.Forms;
using System;
using PropertyChanged;

namespace SignalX
{
	[ImplementPropertyChanged]
	public class ConflictViewModel : IViewModel
	{
		public ConflictViewModel ()
		{
			App.SignalXClient.OnUserSaved += HandleOnUserSaved;
		}

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string ErrorMessage { get; set; }
		public bool HasErrors { get; set; }

		public ICommand ClearErrorMessage {
			get {
				return new Command (() => {
					this.ErrorMessage = string.Empty;
					this.HasErrors = false;
				});
			}
		}

		public ICommand SaveUser {
			get {
				return new Command (() => {
					//TODO : Do something
				});
			}
		}

		void HandleOnUserSaved (object sender, EventArgs e)
		{
			this.HasErrors = true;
			this.ErrorMessage = "Conflict: Another user has saved this record on the server";
			this.FirstName = string.Empty;
			this.LastName = string.Empty;
		}
	}
	
}