using System;
using System.Collections.Generic;
using System.Diagnostics;

using Xamarin.Forms;

namespace InteractApp
{
	public partial class EventListPage : ContentPage
	{
		public List<Event> SampleList =  new List<Event> () {
			Event.newEvent(0, "http://bloggingtips.moneyreigninc.netdna-cdn.com/wp-content/uploads/2014/12/Event-Blogging-Strategies.jpg", "Event0", new DateTime(), "Fremont, CA", "Test Event 0", new List<String> (){ "service" })
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

			Padding = new Thickness (0,Device.OnPlatform(20, 0, 0, 0),0,0);
		}
	}
}

