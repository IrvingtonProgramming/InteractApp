using System.Collections.Generic;

using Xamarin.Forms;

namespace InteractApp
{
	public class FilterPageBase : ViewPage<FilterPageViewModel>
	{

	}

	public partial class FilterPage : FilterPageBase
	{
		public FilterPage (List<Event> events)
		{
			//Generate tags BEFORE XAML is constructed
			ViewModel.GenerateTags (events);

			InitializeComponent ();

			// Have to set index AFTER picker has been populated
			FilterAreaPicker.SelectedIndex = ViewModel.AreaIndex;
			FilterTagPicker.SelectedIndex = ViewModel.TagIndex;
		}

		protected override void OnDisappearing ()
		{
			Application.Current.SavePropertiesAsync ();
		}
	}
}
