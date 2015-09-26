using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InteractApp
{
	public partial class EventInfoPage : ContentPage
	{
		public EventInfoPage ()
		{
			InitializeComponent ();

			string eventDescription = "Dear Parents and Families,\n \nWelcome to Irvington!\n Please read the instructions below carefully. There are several links to information that students and parents must read, and forms that must be filled out and signed BEFORE arriving at the school for the physical walk-through registration. All forms on this web site are downloadable (Microsoft Word or PDF format). This online registration packet will enable you and your student to be prepared and save a lot of time and trouble at MAZE day (orientation and registration day) on Irvington's campus at the end of the summer. The first form, the Walk-Through Registration Signature Page, must be printed, signed, and returned on MAZE Day in order for your child to receive his/her class schedule. In order to complete the signature page, you and your student must first read each of the other documents below.";
			Event e = Event.newEvent(0, null, "Maze Days for 2015-2016", DateTime.Now, null, eventDescription, new List<String> (){ "back to school", "registration" });

			LoadEvent (e);
		}
			
		public void LoadEvent(Event evt) 
		{

			evtName.Text = "Default Name";
			if (evt.Name != null) {
				evtName.Text = evt.Name;
			}

			if (evt.ImageUri != null) {
				evtPic.Source = (FileImageSource)ImageSource.FromUri(new Uri(evt.ImageUri));
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