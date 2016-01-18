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
		public static readonly string DEFAULT_DESC = "If you are seeing this and you're a user, we probably screwed up. Please try again or contact Interact Club.";
		public static readonly int[] DEFAULT_AREAS = { -1 };
		public static readonly string DEFAULT_SCHOOL = "Hooli Headquarters";
		public static readonly List<string> DEFAULT_TAGS = new List<string> () { "Error", "Event" };
		public static readonly string DEFAULT_FORM_URI = "";

		[ParseFieldName ("ImageUri")]
		public string ImageUri {
			get {
				string v = GetProperty<string> ();
				if (String.IsNullOrEmpty (v) || v == "invalid") {
					return "event_placeholder.png";
				}
				return v;
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

		[ParseFieldName ("Desc")]
		public string Desc {
			get { return GetProperty<string> (); }
			private set { SetProperty<string> (value); }
		}

		[ParseFieldName ("Areas")]
		public IList<int> Areas {
			get { return GetProperty<IList<int>> ().ToList (); }
			private set { SetProperty<IList<int>> ((IList<int>)value); }
		}

		[ParseFieldName ("School")]
		public string School {
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

		public string DateAreasSchool { get { return string.Format ("{0} | Areas {1} | {2}", this.Date.ToShortDateString (), String.Join (",", this.Areas), this.School); } }

		public string AreasSchool { get { return string.Format ("Areas {0} | {1}", String.Join (",", this.Areas), this.School); } }

		public Event ()
		{
		}

		public Event (string EImageUri, string EName, DateTime EDate, string EDesc, int[] EAreas, string ESchool, List<string> ETags, string EFormUri)
		{
			this.ImageUri = EImageUri;
			this.Name = EName;
			this.Date = EDate;
			this.Desc = EDesc;
			this.Areas = EAreas;
			this.School = ESchool;
			this.Tags = ETags;
			this.FormUri = EFormUri;
		}

		public static Event newEvent (string EImageUri, string EName, DateTime EDate, string EDesc, int[] EAreas, string ESchool, List<string> ETags, string EFormUri)
		{
			Event e = new Event (EImageUri, EName, EDate, EDesc, EAreas, ESchool, ETags, EFormUri);
			// TODO: Add restrictions?
			return e;
		}

		public static Event newErrorEvent (string ExceptionString)
		{
			if (ExceptionString != null) {
				return new Event (null, DEFAULT_NAME, DateTime.Now, ExceptionString, DEFAULT_AREAS, DEFAULT_SCHOOL, DEFAULT_TAGS, DEFAULT_FORM_URI);
			}
			return new Event (null, DEFAULT_NAME, DateTime.Now, DEFAULT_DESC, DEFAULT_AREAS, DEFAULT_SCHOOL, DEFAULT_TAGS, DEFAULT_FORM_URI);
		}
	}
}

