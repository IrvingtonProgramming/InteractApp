using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace InteractApp
{
	public interface IParseStorage
	{
		Task<List<Event>> RefreshDataAsync();

		Task<Event> GetEventAsync (string id);

		Task SaveEventAsync (Event item);

		Task DeleteEventAsync (Event id);
	}
}

