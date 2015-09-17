using System;
using System.Collections.Generic;

namespace InteractApp
{
	public class Event
	{
		public int Id { get; private set; }
		public String ImageUri { get; private set; }
		public String Name { get; private set; }
		public DateTime Date { get; private set; }
		public String Location { get; private set; }
		public String Desc { get; private set; }
		public List<String> Tags { get; private set; }

		public Event() {
			this.Id = -1;
			this.ImageUri = "http://bloggingtips.moneyreigninc.netdna-cdn.com/wp-content/uploads/2014/12/Event-Blogging-Strategies.jpg";
			this.Name = "Test Event";
			this.Date = new DateTime();
			this.Location = "Hooli Headquarters";
			this.Desc = "Test Event. If you are seeing this and you're a user, we probably screwed up.";
			this.Tags = new List<String>() {"Testing", "Event"};
		}

		public Event(int EId, String EImageUri, String EName, DateTime EDate, String ELocation, String EDesc, List<String> ETags) {
			this.Id = EId;
			this.ImageUri = EImageUri;
			this.Name = EName;
			this.Date = EDate;
			this.Location = ELocation;
			this.Desc = EDesc;
			this.Tags = ETags;
		}

		public static Event newEvent(int EId, String EImageUri, String EName, DateTime EDate, String ELocation, String EDesc, List<String> ETags) {
			Event e = new Event(EId, EImageUri, EName, EDate, ELocation, EDesc, ETags);
			// TODO: Add restrictions?
			return e;
		}
	}
}

