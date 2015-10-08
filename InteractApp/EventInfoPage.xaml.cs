using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InteractApp
{
	public partial class EventInfoPage : ContentPage
	{
		public EventInfoPage (Event e)
		{
			InitializeComponent ();
			this.Title = "Event Info";
			LoadEvent (e);
		}

		public void LoadEvent(Event evt) 
		{

			evtName.Text = "Default Name";
			if (evt.Name != null) {
				evtName.Text = evt.Name;
			}

			if (evt.ImageUri != null) {
				evtPic.Source = evt.ImageUri;
			} else {
				evtPic.Source= (FileImageSource) ImageSource.FromFile("irvington1.jpg");
			}

			evtDate.Text = "Default Date";
			if (evt.Date != null) {
				evtDate.Text = "Date: " + evt.Date;
			}

			evtLoc.Text = "Location: Irvington High School";
			if (evt.Location != null) {
				evtLoc.Text  = "Location: " + evt.Location;
			}

			evtDescLabel.Text = "Event Description";
			if (evt.Desc != null) {
				evtDesc.Text = evt.Desc;
			}

			if (evt.Tags != null) {
				string tagString = "Tags:  ";
				for (int ii=0; ii < evt.Tags.Count; ii++) {
					tagString = tagString + evt.Tags [ii] + "    ";
				}
				evtTagLabel.Text = tagString;
			}

		}
	}
}

