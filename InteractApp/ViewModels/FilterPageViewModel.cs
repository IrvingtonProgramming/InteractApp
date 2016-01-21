using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace InteractApp
{
	public class FilterPageViewModel : INotifyPropertyChanged, IViewModel
	{
		public FilterOptions Selections;
		private readonly Dictionary<int, string[]> AREA_TO_SCHOOL_MAPPING = new Dictionary<int, string[]> () { {
				1,
				new string[] {
					"ACLC",
					"Alameda High",
					"ASTI",
					"Encinal High",
					"Nea",
					"Oakland High",
					"Oakland Tech",
					"Skyline",
					"St. Joes",
					"Head Royce",
					"Oakland Charter"
				}
			}, {
				2,
				new string[] {
					"Arroyo",
					"Castro Valley",
					"Hayward",
					"Kipp",
					"LPS",
					"Moreau",
					"Mt. Eden",
					"Redwood",
					"San Leandro",
					"Canyon Middle School"
				}
			}, {
				3,
				new string[] {
					"Amador Valley",
					"Dublin High",
					"Foothill",
					"Granada",
					"Hart Middle School",
					"Livermore",
					"Livermore Valley Charter Prep",
					"Pleasanton Middle School",
					"Valley Christian"
				}
			},
			{ 4, new string[] { "American High", "Fremont Christian", "James Logan", "Newark Memorial" } }, {
				5,
				new string[] {
					"Alsion Ohlone Montessori",
					"Horner Jr. High",
					"Irvington High School",
					"John F. Kennedy",
					"Mission San Jose",
					"Robertson",
					"Washington"
				}
			},
			{ 6, new string[] { "Independence", "James Lick", "Milpitas", "Mt. Pleasant", "Piedmont Hills", "Summit Rainier" } }, {
				7,
				new string[] {
					"Archbishop Mitty",
					"Bellarmine",
					"Brenham",
					"Gunderson",
					"Harker",
					"Lincoln",
					"Notre Dame",
					"Pioneer"
				}
			}, {
				8,
				new string[] {
					"Andrew Hill",
					"Evergreen Valley",
					"Leland",
					"Oak Grove",
					"Overfelt High",
					"Santa Teresa",
					"Silver Creek",
					"Valley Christian",
					"Yerba Buena"
				}
			},
			{ 9, new string[] { "Ann Sobrato", "Anzar", "Central", "Christopher", "GECA", "Gilroy", "Live Oak", "Oakwood" } }, {
				10,
				new string[] {
					"Aptos",
					"Harbor",
					"Mission Hill",
					"San Lorenzo Valley",
					"Santa Cruz",
					"Scotts Valley",
					"Soquel",
					"Watsonville",
					"St. Francis",
					"Cieba"
				}
			}, {
				11,
				new string[] {
					"Adrian Wilcox",
					"Cambrian",
					"Leigh",
					"Saint Lawrence",
					"Santa Clara",
					"Saratoga",
					"Westmont",
					"Prospect",
					"Peterson MS",
					"Los Gatos"
				}
			},
			{ 12, new string[] { "Cupertino", "Fremont", "Homestead", "Lynbrook", "Monta Vista", "Cupertino Middle School" } }, {
				13,
				new string[] {
					"German International",
					"Gunn",
					"Los Altos",
					"Mountain View",
					"Palo Alto",
					"Pinewood",
					"Saint Francis"
				}
			},
		};


		public FilterPageViewModel ()
		{
			Selections = FilterOptions.Load ();
		}

		public int[] AreaChoices {
			get {
				return new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
			}
		}

		public List<string> SchoolChoices {
			get {
				if (AreaIndex < 0) {
					return new List<string> { "Please select an area." };
				} else {
					return AREA_TO_SCHOOL_MAPPING [Area].OrderBy (s => s).ToList ();
				}
			}
		}

		List<string> _tagChoices = new List<string> ();

		public List<string> TagChoices {
			get {
				return _tagChoices;
			}
		}

		public string Name {
			get {
				return Selections.Name;
			}

			set {
				if (Selections.Name != value) {
					Selections.Name = value;
					Selections.Save ();
					RaisePropertyChanged ("Name");
				}
			}
		}

		public DateTime FromDate {
			get {
				return Selections.FromDate;
			}

			set {
				if (Selections.FromDate != value) {
					Selections.FromDate = value;
					Selections.Save ();
					RaisePropertyChanged ("FromDate");
				}
			}
		}

		public DateTime ToDate {
			get {
				return Selections.ToDate;
			}

			set {
				if (Selections.ToDate != value) {
					Selections.ToDate = value;
					Selections.Save ();
					RaisePropertyChanged ("ToDate");
				}
			}
		}

		public int AreaIndex {
			get {
				return Selections.AreaIndex;
			}

			set {
				if (Selections.AreaIndex != value) {
					Selections.AreaIndex = value;
					Selections.Save ();
					RaisePropertyChanged ("AreaIndex");
				}
			}
		}

		public int Area {
			get {
				return Selections.Area;
			}

			set {
				if (Selections.Area != value) {
					Selections.Area = value;
					Selections.Save ();
					RaisePropertyChanged ("Area");
					RaisePropertyChanged ("SchoolChoices");
				}
			}
		}

		public int SchoolIndex {
			get {
				return Selections.SchoolIndex;
			}

			set {
				if (Selections.SchoolIndex != value) {
					Selections.SchoolIndex = value;
					Selections.Save ();
					RaisePropertyChanged ("SchoolIndex");
				}
			}
		}

		public string School {
			get {
				return Selections.School;
			}

			set {
				if (Selections.School != value) {
					Selections.School = value;
					Selections.Save ();
					RaisePropertyChanged ("School");
				}
			}
		}

		public int TagIndex {
			get {
				return Selections.TagIndex;
			}

			set {
				if (Selections.TagIndex != value) {
					Selections.TagIndex = value;
					Selections.Save ();
					RaisePropertyChanged ("TagIndex");
				}
			}
		}

		public string Tag {
			get {
				return Selections.Tag;
			}

			set {
				if (Selections.Tag != value) {
					Selections.Tag = value;
					Selections.Save ();
					RaisePropertyChanged ("Tag");
				}
			}
		}

		public bool FilterName {
			get { return Selections.FilterName; }

			set {
				if (Selections.FilterName != value) {
					Selections.FilterName = value;
					Selections.Save ();
					RaisePropertyChanged ("FilterName");
				}
			}
		}

		public bool FilterFromDate {
			get { return Selections.FilterFromDate; }

			set {
				if (Selections.FilterFromDate != value) {
					Selections.FilterFromDate = value;
					Selections.Save ();
					RaisePropertyChanged ("FilterFromDate");
				}
			}
		}

		public bool FilterToDate {
			get { return Selections.FilterToDate; }

			set {
				if (Selections.FilterToDate != value) {
					Selections.FilterToDate = value;
					Selections.Save ();
					RaisePropertyChanged ("FilterToDate");
				}
			}
		}

		public bool FilterArea {
			get { return Selections.FilterArea; }

			set {
				if (Selections.FilterArea != value) {
					Selections.FilterArea = value;
					Selections.Save ();
					RaisePropertyChanged ("FilterArea");
				}
			}
		}

		public bool FilterSchool {
			get { return Selections.FilterSchool; }

			set {
				if (Selections.FilterSchool != value) {
					Selections.FilterSchool = value;
					Selections.Save ();
					RaisePropertyChanged ("FilterSchool");
				}
			}
		}

		public bool FilterTag {
			get { return Selections.FilterTag; }

			set {
				if (Selections.FilterTag != value) {
					Selections.FilterTag = value;
					Selections.Save ();
					RaisePropertyChanged ("FilterTag");
				}
			}
		}

		public void ClearFilters ()
		{
			FilterName =
				FilterFromDate =
					FilterToDate =
						FilterArea =
							FilterSchool =
								FilterTag =
									false;
		}

		public void GenerateTags (List<Event> events)
		{
			if (events != null && events.Count > 0) {
				foreach (Event e in events) {
					foreach (string t in e.Tags) {
						if (!_tagChoices.Contains (t)) {
							_tagChoices.Add (t);
						}
					}
				}
				_tagChoices = _tagChoices.OrderBy (t => t).ToList ();
			} else {
				_tagChoices = new List<string> { "No events loaded yet." };
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

	public sealed class FilterOptions
	{
		public string Name;
		public DateTime FromDate;
		public DateTime ToDate;
		public int AreaIndex;
		public int Area;
		public int SchoolIndex;
		public string School;
		public int TagIndex;
		public string Tag;

		public bool FilterName;
		public bool FilterFromDate;
		public bool FilterToDate;
		public bool FilterArea;
		public bool FilterSchool;
		public bool FilterTag;

		public bool FilterAny {
			get {
				return FilterName | FilterFromDate | FilterToDate | FilterArea | FilterSchool | FilterTag;
			}
		}

		public FilterOptions ()
		{
			Name = School = Tag = "";
			FromDate = ToDate = DateTime.Now;
			AreaIndex = Area = SchoolIndex = TagIndex = -1;

			FilterName = FilterFromDate = FilterToDate = FilterArea = FilterSchool = FilterTag = false;
		}

		public void Save (string key = "FilterOptions")
		{
			Application.Current.Properties [key] = SerializeUtils.SerializeToJson (this);
		}

		public static FilterOptions Load (string key = "FilterOptions")
		{
			object o;
			Application.Current.Properties.TryGetValue (key, out o);
			return o != null ? SerializeUtils.DeserializeFromJson (o.ToString ()) : new FilterOptions ();
		}
	}

	public static class SerializeUtils
	{
		public static string SerializeToJson (object obj)
		{
			try {
				return JsonConvert.SerializeObject (obj);
			} catch (Exception ex) {
				Debug.WriteLine ("Error in serializing filter selections: " + ex.StackTrace);
				return "";
			}
		}

		public static FilterOptions DeserializeFromJson (string jsonObj)
		{
			try {
				return JsonConvert.DeserializeObject<FilterOptions> (jsonObj);
			} catch (Exception ex) {
				Debug.WriteLine ("Error in deserializing filter selections: " + ex.StackTrace);
				return new FilterOptions ();
			}
		}
	}
}
