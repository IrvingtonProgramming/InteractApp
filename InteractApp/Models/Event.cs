using System;
using System.Linq;
using System.Collections.Generic;

using Parse;

namespace InteractApp
{
	[ParseClassName ("Event")]
	public class Event : ParseObject
	{
		public static readonly string DEFAULT_URI = "http://bloggingtips.moneyreigninc.netdna-cdn.com/wp-content/uploads/2014/12/Event-Blogging-Strategies.jpg";
		public static readonly string DEFAULT_NAME = "Test Event";
		public static readonly string DEFAULT_LOCATION = "Hooli Headquarters";
		public static readonly string DEFAULT_DESC = "Test Event. If you are seeing this and you're a user, we probably screwed up.";
		public static readonly List<string> DEFAULT_TAGS = new List<string> () { "Testing", "Event" };

		[ParseFieldName ("ImageUri")]
		public string ImageUri {
			get {
				if (String.IsNullOrEmpty (GetProperty<string> ())) {
					return "event_placeholder.jpg";
				}
				return GetProperty<string> ();
			}
			private set { SetProperty<string> (value); }
		}

		[ParseFieldName ("Name")]
		public string Name {
			get { return GetProperty<string> (); }
			private set { SetProperty<string> (value); }
		}

		[ParseFieldName ("Date")]
		public DateTime Date {
			get { return GetProperty<DateTime> (); }
			private set { SetProperty<DateTime> (value); }
		}

		[ParseFieldName ("Location")]
		public string Location {
			get { return GetProperty<string> (); }
			private set { SetProperty<string> (value); }
		}

		[ParseFieldName ("Desc")]
		public string Desc {
			get { return GetProperty<string> (); }
			private set { SetProperty<string> (value); }
		}

		[ParseFieldName ("Tags")]
		public IList<string> Tags {
			get { return GetProperty<IList<string>> ().ToList (); }
			private set { SetProperty<IList<string>> ((IList<string>)value); }
		}

		public string LocationDate { get { return string.Format ("{0} - {1}", this.Location, this.Date.ToShortDateString ()); } }

		public Event ()
		{
		}

		public Event (string EImageUri, string EName, DateTime EDate, string ELocation, string EDesc, List<string> ETags)
		{
			this.ImageUri = EImageUri;
			this.Name = EName;
			this.Date = EDate;
			this.Location = ELocation;
			this.Desc = EDesc;
			this.Tags = ETags;
		}

		public static Event newEvent (string EImageUri, string EName, DateTime EDate, string ELocation, string EDesc, List<string> ETags)
		{
			Event e = new Event (EImageUri, EName, EDate, ELocation, EDesc, ETags);
			// TODO: Add restrictions?
			return e;
		}

		public static Event newDefaultEvent (string ExceptionString)
		{
			if (ExceptionString != null) {
				return new Event (DEFAULT_URI, DEFAULT_NAME, DateTime.Now, DEFAULT_LOCATION, ExceptionString, DEFAULT_TAGS);
			}
			return new Event (DEFAULT_URI, DEFAULT_NAME, DateTime.Now, DEFAULT_LOCATION, DEFAULT_DESC, DEFAULT_TAGS);
		}
	}
}

