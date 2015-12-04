using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

using Parse;

namespace InteractApp.Droid
{
	public class ParseStorage : IParseStorage
	{
		static ParseStorage eventServiceInstance = new ParseStorage ();

		public static ParseStorage Default { get { return eventServiceInstance; } }

		public List<Event> Items { get; private set; }

		// Constructor
		protected ParseStorage ()
		{
			Items = new List<Event> ();
		}

		public static async Task<List<Event>> GetAllEvents ()
		{
			var query = new ParseQuery<Event> ().OrderBy ("Date");
			var ie = ((IEnumerable<Event>)await query.FindAsync ()).ToList ();

			return ie;
		}

		async public Task<List<Event>> RefreshDataAsync ()
		{
			var query = new ParseQuery<Event> ().OrderBy ("Date");
			Items = ((IEnumerable<Event>)await query.FindAsync ()).ToList ();

			return Items;
		}

		public async Task SaveEventAsync (Event eventObj)
		{
			await eventObj.SaveAsync ();
		}

		public async Task<Event> GetEventAsync (string id)
		{
			var query = new ParseQuery<Event> ().WhereEqualTo ("objectId", id);
			var t = (Event)await query.FirstAsync ();
			return t;
		}

		public async Task DeleteEventAsync (Event eventObj)
		{
			try {
				await eventObj.DeleteAsync ();
			} catch (Exception e) {
				Console.Error.WriteLine (@"				ERROR {0}", e.Message);
			}
		}
	}
}
