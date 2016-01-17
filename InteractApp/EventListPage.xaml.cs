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

			ViewModel.LoadAllEventsCommand.Execute (null);

			EventList.ItemTapped += async (sender, e) => {
				Event evt = (Event)e.Item;
				var page = new EventInfoPage (evt);
				((ListView)sender).SelectedItem = null;
				await Navigation.PushAsync (page);
			};
		}

		private async void Filter ()
		{
			string input = await OpenFilterPage (this.Navigation);
			await DisplayAlert ("Debug", input, "Cancel");
		}

		public Task<string> OpenFilterPage (INavigation navigation)
		{
			// wait in this proc, until user finishes input 
			var tcs = new TaskCompletionSource<string> ();
			var page = new FilterPage ();


			page.FindByName<Button> ("FilterApplyButton").Clicked += async (s, e) => {
				var result = page.FindByName<Entry> ("FilterNameEntry").Text;
				await navigation.PopAsync ();
				// pass result
				tcs.SetResult (result);
			};

			// show page
			navigation.PushAsync (page);

			// code is waiting here, until result is passed with tcs.SetResult() in btn-Clicked
			// then proc returns the result
			return tcs.Task;
		}
	}
}
