using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InteractApp
{
	public partial class FilterPage : ContentPage
	{
		public static readonly int[] AREA_CHOICES = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

		public FilterPage ()
		{
			InitializeComponent ();

			FilterAreaPicker.Items.Clear ();
			foreach (int i in AREA_CHOICES) {
				FilterAreaPicker.Items.Add (i.ToString ());
			}

			FilterClearAllButton.Clicked += ClearAllClicked;
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
	}
}

