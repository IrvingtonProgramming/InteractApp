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

		private async Task<List<Event>> GetAllEvents ()
		{
			try {
				return await App.EventManager.GetEventsAsync ();
			} catch (Exception e) {
				if (e.StackTrace.Contains ("HttpWebRequest")) {
					return new List<Event> () { Event.newErrorEvent ("A network error has occurred. Please check your network connection.") };
				} else {
					return new List<Event> () { Event.newErrorEvent ("Exception while loading data. Please try again or contact Interact Club.\n\n" + e.StackTrace) };
				}
			}
		}

		private Command refreshListCommand;

		public Command RefreshListCommand {
			get { 
				return refreshListCommand ?? (refreshListCommand = new Command (ExecuteRefreshListCommand, () => {
					return !IsRefreshing;
				})); 
			}
		}

		private async void ExecuteRefreshListCommand ()
		{
			if (IsRefreshing)
				return;

			IsRefreshing = true;
			RefreshListCommand.ChangeCanExecute ();

			await LoadEvents (appliedFilterOptions);

			IsRefreshing = false;
			RefreshListCommand.ChangeCanExecute ();
		}

		private static FilterOptions appliedFilterOptions;

		public async Task LoadEvents (FilterOptions options = null)
		{
			IsLoading = true;

			IEnumerable<Event> filteredEvents = await GetAllEvents ();
			appliedFilterOptions = options;

			if (options != null && options.FilterAny) {
				if (options.FilterName) {
					filteredEvents = filteredEvents.Where (e => e.Name.Contains (options.Name));
				}

				if (options.FilterFromDate) {
					filteredEvents = filteredEvents.Where (e => DateTime.Compare (options.FromDate, e.Date.Date) <= 0);
				}

				if (options.FilterToDate) {
					filteredEvents = filteredEvents.Where (e => DateTime.Compare (e.Date.Date, options.ToDate) <= 0);
				}

				if (options.FilterArea) {
					filteredEvents = filteredEvents.Where (e => e.Areas.Contains (options.AreaIndex + 1));
				}

				if (options.FilterSchool) {
					filteredEvents = filteredEvents.Where (e => e.School.Contains (options.School));
				}
			}

			Items = filteredEvents.ToList ();

			IsLoading = false;
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

