using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using Xamarin.Forms;

namespace InteractApp
{
	public class FilterPageViewModel : INotifyPropertyChanged, IViewModel
	{
		public FilterOptions Selections;


		public FilterPageViewModel ()
		{
			Selections = FilterOptions.Load ();
		}

		public int[] AreaChoices {
			get {
				return new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
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
			foreach (Event e in events) {
				foreach (string t in e.Tags) {
					if (!_tagChoices.Contains (t)) {
						_tagChoices.Add (t);
					}
				}
			}
			_tagChoices = _tagChoices.OrderBy (t => t).ToList ();
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
			AreaIndex = Area = TagIndex = -1;

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
