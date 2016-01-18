using System;
using System.ComponentModel;

using Newtonsoft.Json;

using Xamarin.Forms;
using System.Diagnostics;

namespace InteractApp
{
	public class FilterPageViewModel : INotifyPropertyChanged, IViewModel
	{
		public FilterOptions selections;

		public FilterPageViewModel ()
		{
			selections = FilterOptions.Load ();
		}

		public string Name {
			get {
				return selections.Name;
			}

			set {
				if (selections.Name != value) {
					selections.Name = value;
					selections.Save ();
					RaisePropertyChanged ("Name");
				}
			}
		}

		public DateTime FromDate {
			get {
				return selections.FromDate;
			}

			set {
				if (selections.FromDate != value) {
					selections.FromDate = value;
					selections.Save ();
					RaisePropertyChanged ("FromDate");
				}
			}
		}

		public DateTime ToDate {
			get {
				return selections.ToDate;
			}

			set {
				if (selections.ToDate != value) {
					selections.ToDate = value;
					selections.Save ();
					RaisePropertyChanged ("ToDate");
				}
			}
		}

		public string School {
			get {
				return selections.School;
			}

			set {
				if (selections.School != value) {
					selections.School = value;
					selections.Save ();
					RaisePropertyChanged ("School");
				}
			}
		}

		public int AreaIndex {
			get {
				return selections.AreaIndex;
			}

			set {
				if (selections.AreaIndex != value) {
					selections.AreaIndex = value;
					selections.Save ();
					RaisePropertyChanged ("Area");
				}
			}
		}

		public bool FilterName {
			get { return selections.FilterName; }

			set {
				if (selections.FilterName != value) {
					selections.FilterName = value;
					selections.Save ();
					RaisePropertyChanged ("FilterName");
				}
			}
		}

		public bool FilterFromDate {
			get { return selections.FilterFromDate; }

			set {
				if (selections.FilterFromDate != value) {
					selections.FilterFromDate = value;
					selections.Save ();
					RaisePropertyChanged ("FilterFromDate");
				}
			}
		}

		public bool FilterToDate {
			get { return selections.FilterToDate; }

			set {
				if (selections.FilterToDate != value) {
					selections.FilterToDate = value;
					selections.Save ();
					RaisePropertyChanged ("FilterToDate");
				}
			}
		}

		public bool FilterSchool {
			get { return selections.FilterSchool; }

			set {
				if (selections.FilterSchool != value) {
					selections.FilterSchool = value;
					selections.Save ();
					RaisePropertyChanged ("FilterSchool");
				}
			}
		}

		public bool FilterArea {
			get { return selections.FilterArea; }

			set {
				if (selections.FilterArea != value) {
					selections.FilterArea = value;
					selections.Save ();
					RaisePropertyChanged ("FilterArea");
				}
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
		public string School;
		public int AreaIndex;

		public bool FilterName;
		public bool FilterFromDate;
		public bool FilterToDate;
		public bool FilterSchool;
		public bool FilterArea;

		public FilterOptions ()
		{
			Name = School = "";
			FromDate = ToDate = DateTime.Now;
			AreaIndex = -1;

			FilterName = FilterFromDate = FilterToDate = FilterSchool = FilterArea = false;
		}

		public void Save ()
		{
			Application.Current.Properties ["FilterOptions"] = SerializeUtils.SerializeToJson (this);
			Application.Current.SavePropertiesAsync ();
		}

		public static FilterOptions Load ()
		{
			object o;
			Application.Current.Properties.TryGetValue ("FilterOptions", out o);
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
