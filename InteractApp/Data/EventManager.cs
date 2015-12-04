using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace InteractApp
{
	public class EventManager
	{
		readonly IParseStorage storage;

		public EventManager (IParseStorage storage)
		{
			this.storage = storage;
		}

		public Task<Event> GetEventAsync (string id)
		{
			return storage.GetEventAsync (id);
		}

		public Task<List<Event>> GetEventsAsync ()
		{
			return storage.RefreshDataAsync ();
		}

		public Task SaveEventAsync (Event item)
		{
			return storage.SaveEventAsync (item);
		}

		public Task DeleteEventAsync (Event item)
		{
			return storage.DeleteEventAsync (item);
		}
	}
}

