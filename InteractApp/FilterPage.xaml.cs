using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InteractApp
{
	public class FilterPageBase : ViewPage<FilterPageViewModel>
	{

	}

	public partial class FilterPage : FilterPageBase
	{
		static readonly int[] AREA_CHOICES = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

		public FilterPage ()
		{
			InitializeComponent ();

			FilterAreaPicker.Items.Clear ();
			foreach (int i in AREA_CHOICES) {
				FilterAreaPicker.Items.Add (i.ToString ());
			}
			// Have to set index AFTER picker has been populated
			FilterAreaPicker.SelectedIndex = ViewModel.AreaIndex;
		}

		protected override void OnDisappearing ()
		{
			Application.Current.SavePropertiesAsync ();
		}
	}
}
