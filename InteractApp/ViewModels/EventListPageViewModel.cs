using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using Xamarin.Forms;
using System.Threading.Tasks;

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

		private Command loadAllEventsCommand;

		public Command LoadAllEventsCommand {
			get { 
				return loadAllEventsCommand ?? (loadAllEventsCommand = new Command (ExecuteLoadEventsCommand, () => {
					return !IsRefreshing;
				})); 
			}
		}

		private async void ExecuteLoadEventsCommand ()
		{
			if (IsRefreshing)
				return;

			IsRefreshing = true;
			LoadAllEventsCommand.ChangeCanExecute ();

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
			LoadAllEventsCommand.ChangeCanExecute ();
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

		public void Filter (FilterOptions options)
		{
			IsLoading = true;

			if (options.FilterName) {
				Items = Items.Where (e => e.Name.Contains (options.Name)).ToList ();
			}
				
			IsLoading = false;
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

