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

			//Event e = Event.newEvent(0,null, "Event Name 2", new DateTime(), "Fremont CA", "Test Event 0", new List<String> (){ "service", "clubs" });
			Event e = Event.newEvent(0, null, "Maze Days for 2015-2016", DateTime.Now, null, null, new List<String> (){ "back to school", "registration" });
			/**
			evtName.Text = "Event Name 1";

			backBtn.Image = (FileImageSource) ImageSource.FromFile("back.png");

			evtPic.Source= (FileImageSource) ImageSource.FromFile("lilies.jpg");

			evtDate.Text = DateTime.Now.ToString ("G");
			evtLoc.Text = "Irvington High School";
			evtDescLabel.Text = "Event Description";

			evtDesc.Text = "Now Is the time for all good men to come to the aid of their people.This is an event description. " +
				"Blah blah blah.Now Is the time for all good men to come to the aid of their people.This is an event description. Blah blah blah." +
				"Blah blah blah.Now Is the time for all good men to come to the aid of their people.This is an event description. Blah blah blah." +
				"Blah blah blah.Now Is the time for all good men to come to the aid of their people.This is an event description. Blah blah blah." +
				"Blah blah blah.Now Is the time for all good men to come to the aid of their people.This is an event description. Blah blah blah." +
				"Blah blah blah.Now Is the time for all good men to come to the aid of their people.This is an event description. Blah blah blah." +
				"Blah blah blah.Now Is the time for all good men to come to the aid of their people.This is an event description. Blah blah blah." +
				"Blah blah blah.Now Is the time for all good men to come to the aid of their people.This is an event description. Blah blah blah." +
				"Blah blah blah.Now Is the time for all good men to come to the aid of their people.This is an event description. Blah blah blah.";
			evtTagLabel.Text = "Tags";
			**/
			LoadEvent (e);
		}
		public void OnClicked()
		{

		}

		public void LoadEvent(Event evt) 
		{
			// Defaults are loaded if null string
			string eventName = "Event Name 12";
			string eventtDate = DateTime.Now.ToString ("g");
			string eventLocation = "Location: Irvington High School";
			string eventDescription = "Dear Parents and Families,\n \nWelcome to Irvington!\n Please read the instructions below carefully. There are several links to information that students and parents must read, and forms that must be filled out and signed BEFORE arriving at the school for the physical walk-through registration. All forms on this web site are downloadable (Microsoft Word or PDF format). This online registration packet will enable you and your student to be prepared and save a lot of time and trouble at MAZE day (orientation and registration day) on Irvington's campus at the end of the summer. The first form, the Walk-Through Registration Signature Page, must be printed, signed, and returned on MAZE Day in order for your child to receive his/her class schedule. In order to complete the signature page, you and your student must first read each of the other documents below.";
			/*
				"" +
				"Now Is the time for all good men to come to the aid of their people.This is an event description. " +
				"Blah blah blah.Now Is the time for all good men to come to the aid of their people.This is an event description. Blah blah blah." +
				"Blah blah blah.Now Is the time for all good men to come to the aid of their people.This is an event description. Blah blah blah." +
				"Blah blah blah.Now Is the time for all good men to come to the aid of their people.This is an event description. Blah blah blah." +
				"Blah blah blah.Now Is the time for all good men to come to the aid of their people.This is an event description. Blah blah blah." +
				"Blah blah blah.Now Is the time for all good men to come to the aid of their people.This is an event description. Blah blah blah." +
				"Blah blah blah.Now Is the time for all good men to come to the aid of their people.This is an event description. Blah blah blah." +
				"Blah blah blah.Now Is the time for all good men to come to the aid of their people.This is an event description. Blah blah blah." +
				"Blah blah blah.Now Is the time for all good men to come to the aid of their people.This is an event description. Blah blah blah.";
				*/
//			backBtn.Image = (FileImageSource) ImageSource.FromFile("back.png");
			if (evt.Name != null) {
				evtName.Text = evt.Name;
			} else {
				evtName.Text = eventName;
			}
			if (evt.ImageUri != null) {
				evtPic.Source= (FileImageSource)ImageSource.FromFile (evt.ImageUri);
			} else {
				evtPic.Source= (FileImageSource) ImageSource.FromFile("irvington1.jpg");
			}
			if (evt.Date != null) {
				evtDate.Text = "Date: " + evt.Date;
			} else {
				evtDate.Text = "Date: " + eventtDate;
			}
			if (evt.Location != null) {
				evtLoc.Text  = "Location: " + evt.Location;
			} else {
				evtLoc.Text = eventLocation; 
			}
			evtDescLabel.Text = "Event Description";
			if (evt.Desc != null) {
				evtDesc.Text = evt.Desc;
			} else {
				evtDesc.Text = eventDescription;
			}
			if (evt.Tags != null) {
				string tagString = "Tags:  ";
				for (int ii=0; ii < evt.Tags.Count; ii++) {
					tagString = tagString + evt.Tags [ii] + "    ";
				}
				evtTagLabel.Text = tagString;
			} else {
				evtTagLabel.Text = "Tags: ";
			}

		}

	}
}

