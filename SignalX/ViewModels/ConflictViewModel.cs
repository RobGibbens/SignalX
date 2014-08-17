using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SignalX
{	
	public class ConflictViewModel :  INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;


		void RaisePropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
	}
	
}