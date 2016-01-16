using System;
using System.Diagnostics;

using Xamarin.Forms;

using InteractApp;

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

//			ToolbarItems.Add (new ToolbarItem {
//				Text = "My Events",
//				Order = ToolbarItemOrder.Primary,
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
			var action = await DisplayActionSheet ("Filter:", "OK", "Clear all", "Name", "Date", "Tag");
			Debug.WriteLine ("Action: " + action);
			switch (action) {

			case "Clear all":
				ViewModel.LoadAllEventsCommand.Execute (null);
				break;
			
			case "Name":
				break;

			case "Date":
				break;

			case "Tag":
				break;

			}
		}
	}
}
