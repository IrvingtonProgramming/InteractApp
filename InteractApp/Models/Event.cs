using System;
using System.Collections.Generic;

namespace InteractApp
{
	public class Event
	{
		public static readonly int DEFAULT_ID = -1;
		public static readonly String DEFAULT_URI = "http://bloggingtips.moneyreigninc.netdna-cdn.com/wp-content/uploads/2014/12/Event-Blogging-Strategies.jpg";
		public static readonly String DEFAULT_NAME = "Test Event";
		public static readonly String DEFAULT_LOCATION = "Hooli Headquarters";
		public static readonly String DEFAULT_DESC = "Test Event. If you are seeing this and you're a user, we probably screwed up.";
		public static readonly List<String> DEFAULT_TAGS = new List<String>() {"Testing", "Event"};


		public int Id { get; private set; }
		public String ImageUri { get; private set; }
		public String Name { get; private set; }
		public DateTime Date { get; private set; }
		public String Location { get; private set; }
		public String Desc { get; private set; }
		public List<String> Tags { get; private set; }

		public String LocationDate {get {return String.Format("{0} - {1}", Location, Date.ToShortDateString());}}

		public Event() {
			this.Id = DEFAULT_ID;
			this.ImageUri = DEFAULT_URI;
			this.Name = DEFAULT_NAME;
			this.Date = DateTime.Now;
			this.Location = DEFAULT_LOCATION;
			this.Desc = DEFAULT_DESC;
			this.Tags = DEFAULT_TAGS;
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

