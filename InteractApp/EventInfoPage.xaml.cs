using System;
using System.Diagnostics;

using Xamarin.Forms;

namespace InteractApp
{
	public partial class EventInfoPage : ContentPage
	{
		private Event E;

		public EventInfoPage (Event e)
		{
			InitializeComponent ();
			E = e;
			EventInfo.BindingContext = e;
			this.Title = "Event Info";
			evtTagLabel.Text = "Tags:  " + String.Join ("  |  ", e.Tags);

			ToolbarItems.Add (new ToolbarItem {
				Text = "RSVP",
				Order = ToolbarItemOrder.Primary,
				Command = new Command (this.RSVP),
			});
		}

		private void RSVP ()
		{
			try {
				Device.OpenUri (new Uri (E.FormUri));
			} catch (UriFormatException) {
				DisplayAlert ("Oops", "Invalid URI, please contact Interact.", "YESSIR");
			}
		}
	}
}
