using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;

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
				return this._isLoading;
			}

			set {
				if (_isLoading == value) {
					return;
				}

				_isLoading = value;
				RaisePropertyChanged ("IsLoading");
			}
		}

		public async void LoadItemsAsync (Task<List<Event>> loadTask)
		{
			IsLoading = true;
			try {
				Items = await loadTask;
			} catch (Exception e) {
				if (e.StackTrace.Contains ("HttpWebRequest")) {
					Items = new List<Event> () { Event.newErrorEvent ("A network error has occurred. Please check your network connection.") };
				} else {
					Items = new List<Event> () { Event.newErrorEvent ("Exception while loading data. Please try again or contact Interact Club.\n\n" + e.StackTrace) };
				}
			}
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

