using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Android.Util;

namespace InteractApp
{
	public class FilterPageBase : ViewPage<FilterPageViewModel>
	{

	}

	public partial class FilterPage : FilterPageBase
	{
		static readonly int[] AREA_CHOICES = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
		readonly Entry[] Entries;
		readonly DatePicker[] DatePickers;
		readonly Picker[] Pickers;


		public FilterPage ()
		{
			InitializeComponent ();

			FilterAreaPicker.Items.Clear ();
			foreach (int i in AREA_CHOICES) {
				FilterAreaPicker.Items.Add (i.ToString ());
			}
			// Have to set index AFTER picker has been populated
			FilterAreaPicker.SelectedIndex = ViewModel.AreaIndex;

			Entries = new [] {
				FilterNameEntry,
				FilterSchoolEntry,
			};

			DatePickers = new [] {
				FilterFromDatePicker,
				FilterToDatePicker,
			};

			Pickers = new [] {
				FilterAreaPicker,
			};

			FilterClearAllButton.Clicked += ClearAllClicked;
			FilterApplyButton.Clicked += ApplyClicked;
		}

		void ClearAllClicked (object sender, EventArgs e)
		{
			Switch[] switches = {
				FilterNameSwitch,
				FilterFromDateSwitch,
				FilterToDateSwitch,
				FilterSchoolSwitch,
				FilterAreaSwitch
			};

			foreach (Switch s in switches) {
				s.IsToggled = false;
			}
		}

		void ApplyClicked (Object sender, EventArgs e)
		{
			return;
		}
	}
}

