using System;
using System.Diagnostics;

using Xamarin.Forms;

namespace InteractApp
{
	public partial class EventInfoPage : ContentPage
	{
		public EventInfoPage (Event e)
		{
			InitializeComponent ();
			EventInfo.BindingContext = e;
			this.Title = "Event Info";
			evtTagLabel.Text = "Tags:  " + String.Join ("  |  ", e.Tags);

			ToolbarItems.Add (new ToolbarItem {
				Text = "RSVP",
				Order = ToolbarItemOrder.Primary,
			});
		}
	}
}
