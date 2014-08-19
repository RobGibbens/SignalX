using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using System;

namespace SignalX
{


	public class ConflictViewModel :  INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public ConflictViewModel ()
		{
			App.SignalXClient.OnUserSaved += HandleOnUserSaved;
		}

		void RaisePropertyChanged ([CallerMemberName] string propertyName = "")
		{
			PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
		}

		string _firstName;

		public string FirstName {
			get {
				return _firstName;
			}
			set {
				if (_firstName != value) {
					_firstName = value;
					RaisePropertyChanged ();
				}
			}
		}

		string _lastName;

		public string LastName {
			get {
				return _lastName;
			}
			set {
				if (_lastName != value) {
					_lastName = value;
					RaisePropertyChanged ();
				}
			}
		}

		string _errorMessage;

		public string ErrorMessage {
			get {
				return _errorMessage;
			}
			set {
				if (_errorMessage != value) {
					_errorMessage = value;
					RaisePropertyChanged ();
				}
			}
		}

		bool _hasErrors;

		public bool HasErrors {
			get {
				return _hasErrors;
			}
			set {
				if (_hasErrors != value) {
					_hasErrors = value;
					RaisePropertyChanged ();
				}
			}
		}

		public ICommand ClearErrorMessage {
			get {
				return new Command (async () => {
					this.ErrorMessage = string.Empty;
					this.HasErrors = false;
				});
			}
		}

		public ICommand SaveUser {
			get {
				return new Command (async () => {

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