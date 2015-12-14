using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace InteractApp
{
	public class EventListPageViewModel : INotifyPropertyChanged, IViewModel
	{
		public EventListPageViewModel ()
		{
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

		private bool _isRefreshing;

		public bool IsRefreshing {
			get {
				return _isRefreshing;
			}

			set {
				if (_isRefreshing != value) {
					_isRefreshing = value;
					RaisePropertyChanged ("IsRefreshing");
				}
			}
		}

		private Command loadEventsCommand;

		public Command LoadEventsCommand {
			get { 
				return loadEventsCommand ?? (loadEventsCommand = new Command (ExecuteLoadEventsCommand, () => {
					return !IsRefreshing;
				})); 
			}
		}

		private async void ExecuteLoadEventsCommand ()
		{
			if (IsRefreshing)
				return;

			IsRefreshing = true;
			LoadEventsCommand.ChangeCanExecute ();

			try {
				Items = await App.EventManager.GetEventsAsync ();
			} catch (Exception e) {
				if (e.StackTrace.Contains ("HttpWebRequest")) {
					Items = new List<Event> () { Event.newErrorEvent ("A network error has occurred. Please check your network connection.") };
				} else {
					Items = new List<Event> () { Event.newErrorEvent ("Exception while loading data. Please try again or contact Interact Club.\n\n" + e.StackTrace) };
				}
			}

			IsRefreshing = false;
			IsLoading = false;
			LoadEventsCommand.ChangeCanExecute ();
		}

		private List<Event> _items;

		public List<Event> Items {
			get {
				return _items;
			}

			private set {
				if (_items != value) {
					_items = value;
					RaisePropertyChanged ("Items");
				}
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

