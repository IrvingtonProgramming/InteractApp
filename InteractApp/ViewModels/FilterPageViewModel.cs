using System;
using System.ComponentModel;

using Xamarin.Forms;

namespace InteractApp
{
	public class FilterPageViewModel : INotifyPropertyChanged, IViewModel
	{
		public FilterOptions selections;

		public FilterPageViewModel ()
		{
		}

		public string Name {
			get {
				object v;
				Application.Current.Properties.TryGetValue (Key.NAME, out v);
				return (string)v;
			}

			set {
				object v;
				Application.Current.Properties.TryGetValue (Key.NAME, out v);
				if ((string)v != value) {
					Application.Current.Properties [Key.NAME] = value;
					RaisePropertyChanged ("Name");
				}
			}
		}

		public DateTime FromDate {
			get {
				object v;
				Application.Current.Properties.TryGetValue (Key.FROM_DATE, out v);
				return (DateTime)((v) ?? DateTime.Now);
			}

			set {
				object v;
				Application.Current.Properties.TryGetValue (Key.FROM_DATE, out v);
				if (((DateTime)((v) ?? DateTime.Now)) != value) {
					Application.Current.Properties [Key.FROM_DATE] = value;
					RaisePropertyChanged ("FromDate");
				}
			}
		}

		public DateTime ToDate {
			get {
				object v;
				Application.Current.Properties.TryGetValue (Key.TO_DATE, out v);
				return (DateTime)((v) ?? DateTime.Now);
			}

			set {
				object v;
				Application.Current.Properties.TryGetValue (Key.TO_DATE, out v);
				if (((DateTime)((v) ?? DateTime.Now)) != value) {
					Application.Current.Properties [Key.TO_DATE] = value;
					RaisePropertyChanged ("ToDate");
				}
			}
		}

		public string School {
			get {
				object v;
				Application.Current.Properties.TryGetValue (Key.SCHOOL, out v);
				return (string)v;
			}

			set {
				object v;
				Application.Current.Properties.TryGetValue (Key.SCHOOL, out v);
				if ((string)v != value) {
					Application.Current.Properties [Key.SCHOOL] = value;
					RaisePropertyChanged ("School");
				}
			}
		}

		public int Area {
			get {
				object v;
				Application.Current.Properties.TryGetValue (Key.AREA, out v);
				return (int)(v ?? -1);
			}

			set {
				object v;
				Application.Current.Properties.TryGetValue (Key.AREA, out v);
				if (((int)(v ?? -1)) != value) {
					Application.Current.Properties [Key.AREA] = value;
					RaisePropertyChanged ("Area");
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

	public sealed class Key
	{
		public static readonly string NAME = "Name";
		public static readonly string FROM_DATE = "FromDate";
		public static readonly string TO_DATE = "ToDate";
		public static readonly string SCHOOL = "School";
		public static readonly string AREA = "Area";
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

		public void save ()
		{
			Application.Current.Properties ["FilterOptions"] = this;
		}

		public static FilterOptions load ()
		{
			object o;
			Application.Current.Properties.TryGetValue ("FilterOptions", out o);
			return (FilterOptions)(o ?? new FilterOptions ());
		}
	}
}
