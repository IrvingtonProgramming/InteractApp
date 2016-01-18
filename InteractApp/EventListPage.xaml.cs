using System;
using System.Diagnostics;

using Xamarin.Forms;

using InteractApp;
using System.Threading.Tasks;

namespace InteractApp
{
	public class EventListPageBase : ViewPage<EventListPageViewModel>
	{

	}

	public partial class EventListPage : EventListPageBase
	{
		public EventListPage ()
		{
			InitializeComponent ();

//			ToolbarItems.Add (new ToolbarItem {
//				Text = "My Info",
//				Order = ToolbarItemOrder.Primary,
//				Command = new Command (() => Navigation.PushAsync (new MyInfoPage ())),
//			});

			ToolbarItems.Add (new ToolbarItem {
				Text = "Filter",
				Icon = "ic_filter.png",
				Order = ToolbarItemOrder.Primary,
				Command = new Command (this.Filter),
			});

			//To hide iOS list seperator 
			EventList.SeparatorVisibility = SeparatorVisibility.None;

			ViewModel.LoadEvents ();

			EventList.ItemTapped += async (sender, e) => {
				Event evt = (Event)e.Item;
				var page = new EventInfoPage (evt);
				((ListView)sender).SelectedItem = null;
				await Navigation.PushAsync (page);
			};
		}

		private async void Filter ()
		{
			FilterOptions options = await OpenFilterPage (this.Navigation);
			ViewModel.LoadEvents (options);
			//await DisplayAlert ("Debug", options.Name, "Cancel");
		}

		public Task<FilterOptions> OpenFilterPage (INavigation navigation)
		{
			// wait in this proc, until user finishes input
			var tcs = new TaskCompletionSource<FilterOptions> ();
			var page = new FilterPage ();


			page.FindByName<Button> ("FilterApplyButton").Clicked += async (s, e) => {
				var result = page.ViewModel.selections;
				await navigation.PopAsync ();
				// pass result
				tcs.SetResult (result);
			};

			page.FindByName<Button> ("FilterClearAllButton").Clicked += async (s, e) => {
				page.ViewModel.ClearFilters ();
				var result = page.ViewModel.selections;
				await navigation.PopAsync ();
				tcs.SetResult (result);
			};

			navigation.PushAsync (page);

			return tcs.Task;
		}
	}
}
