using System.ComponentModel;
using Xamarin.Forms;
using System;

namespace InteractApp
{
	public class EventInfoPageViewModel : INotifyPropertyChanged, IViewModel
	{
		private Event _e;

		public Event E {
			get {
				return _e;
			}
			set {
				if (_e != value) {
					_e = value;
					RaisePropertyChanged ("E");
				}
			}
		}

		public string ETags {
			get {
				return "Tags:  " + String.Join ("  |  ", E.Tags);
			}
		}

		public EventInfoPageViewModel (Event evt)
		{
			E = evt;
			IsLoading = true;
		}


		private bool _isLoading;

		public bool IsLoading {
			get {
				return _isLoading;
			}

			set {
				if (_isLoading != value) {
					_isLoading = value;
					RaisePropertyChanged ("IsLoading");
				}
			}
		}

		public void RSVP ()
		{
			try {
				Device.OpenUri (new Uri (E.FormUri));
			} catch (Exception ex) {
				if (ex is UriFormatException || ex is ArgumentNullException) {
					MessagingCenter.Send (this, "Invalid URI");
					return;
				}

				throw;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void RaisePropertyChanged (string propName)
		{
			if (PropertyChanged != null) {
				PropertyChanged (this, new PropertyChangedEventArgs (propName));
			}
		}
	}
}

