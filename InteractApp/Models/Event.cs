using System;
using System.Linq;
using System.Collections.Generic;

using Parse;

namespace InteractApp
{
	[ParseClassName ("Event")]
	public class Event : ParseObject
	{
		public static readonly string DEFAULT_NAME = "An Error Has Occurred";
		public static readonly string DEFAULT_LOCATION = "Hooli Headquarters";
		public static readonly string DEFAULT_DESC = "If you are seeing this and you're a user, we probably screwed up. Please try again or contact Interact Club.";
		public static readonly List<string> DEFAULT_TAGS = new List<string> () { "Error", "Event" };
		public static readonly string DEFAULT_FORM_URI = "";

		[ParseFieldName ("ImageUri")]
		public string ImageUri {
			get {
				if (String.IsNullOrEmpty (GetProperty<string> ())) {
					return "event_placeholder.png";
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

		[ParseFieldName ("FormUri")]
		public string FormUri {
			get { return GetProperty<string> (); }
			private set { SetProperty<string> (value); }
		}

		public string LocationDate { get { return string.Format ("{0} - {1}", this.Location, this.Date.ToShortDateString ()); } }

		public Event ()
		{
		}

		public Event (string EImageUri, string EName, DateTime EDate, string ELocation, string EDesc, List<string> ETags, string EFormUri)
		{
			this.ImageUri = EImageUri;
			this.Name = EName;
			this.Date = EDate;
			this.Location = ELocation;
			this.Desc = EDesc;
			this.Tags = ETags;
			this.FormUri = EFormUri;
		}

		public static Event newEvent (string EImageUri, string EName, DateTime EDate, string ELocation, string EDesc, List<string> ETags, string EFormUri)
		{
			Event e = new Event (EImageUri, EName, EDate, ELocation, EDesc, ETags, EFormUri);
			// TODO: Add restrictions?
			return e;
		}

		public static Event newErrorEvent (string ExceptionString)
		{
			if (ExceptionString != null) {
				return new Event (null, DEFAULT_NAME, DateTime.Now, DEFAULT_LOCATION, ExceptionString, DEFAULT_TAGS, DEFAULT_FORM_URI);
			}
			return new Event (null, DEFAULT_NAME, DateTime.Now, DEFAULT_LOCATION, DEFAULT_DESC, DEFAULT_TAGS, DEFAULT_FORM_URI);
		}
	}
}

