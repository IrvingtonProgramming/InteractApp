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
				this._isLoading = value;
				RaisePropertyChanged ("IsLoading");
			}
		}

		public async void LoadItemsAsync (Task<List<Event>> loadTask)
		{
			IsLoading = true;
			try {
				Items = await loadTask;
			} catch (Exception e) {
				Items = new List<Event> () { Event.newDefaultEvent ("Exception while loading data:\n" + e.StackTrace) };
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

