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
			Event.newEvent(0, "http://bloggingtips.moneyreigninc.netdna-cdn.com/wp-content/uploads/2014/12/Event-Blogging-Strategies.jpg", "Event0", DateTime.Now, "Fremont, CA", EventDesc, new List<String> (){ "service" })
		};

		public EventListPage ()
		{
			InitializeComponent ();
			EventList.ItemsSource = SampleList;

			EventList.ItemTapped += async (sender, e) => {
				await DisplayAlert("Tapped", ((Event) e.Item).Name + " row was tapped", "OK");
				Debug.WriteLine("Tapped: " + ((Event) e.Item).Name);
				((ListView)sender).SelectedItem = null; // de-select the row
			};

			Padding = new Thickness (0,Device.OnPlatform(20, 0, 0),0,0);
		}
	}
}

