using System;
using System.Collections.Generic;
using System.Diagnostics;

using Xamarin.Forms;

namespace InteractApp
{
	public partial class EventListPage : ContentPage
	{
		private static readonly string EventDesc = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
		public List<Event> SampleList =  new List<Event> () {
			Event.newEvent(0, "http://www.grey-hare.co.uk/wp-content/uploads/2012/09/Event-management.png", "Event0", DateTime.Now, "Fremont, CA", EventDesc, new List<String> (){ "service" }),
			new Event()
		};

		public EventListPage ()
		{
			InitializeComponent ();

			this.Title = "Events";

			ToolbarItems.Add(new ToolbarItem {
				Text = "My Info",
				Order = ToolbarItemOrder.Primary,
			});

			ToolbarItems.Add(new ToolbarItem {
				Text = "My Events",
				Order = ToolbarItemOrder.Primary,
			});

			EventList.ItemsSource = SampleList;

			EventList.ItemTapped += async (sender, e) => {
				await DisplayAlert("Tapped", ((Event) e.Item).Name + " row was tapped", "OK");
				Debug.WriteLine("Tapped: " + ((Event) e.Item).Name);
				((ListView)sender).SelectedItem = null; // de-select the row
			};

			Padding = new Thickness (0,0,0,0);
		}
	}
}

