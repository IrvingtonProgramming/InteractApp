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

			this.Title = "Events";
			Padding = new Thickness (0, 0, 0, 0);

			ToolbarItems.Add (new ToolbarItem {
				Text = "My Info",
				Order = ToolbarItemOrder.Primary,
				Command = new Command (this.ShowMyInfoPage),
			});

			ToolbarItems.Add (new ToolbarItem {
				Text = "My Events",
				Order = ToolbarItemOrder.Primary,
			});

			ViewModel.LoadItemsAsync (App.EventManager.GetEventsAsync ());

			EventList.ItemTapped += async (sender, e) => {
				Event evt = (Event)e.Item;
				Debug.WriteLine ("Tapped: " + (evt.Name));
				var page = new EventInfoPage (evt);
				((ListView)sender).SelectedItem = null;
				await Navigation.PushAsync (page);
			};
		}

		private void ShowMyInfoPage ()
		{
			Navigation.PushAsync (new MyInfoPage ());
		}
	}
}
