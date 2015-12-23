using System;

using Xamarin.Forms;

using Parse;

namespace InteractApp
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new NavigationPage (new EventListPage ()) {
				BarBackgroundColor = ColorResources.NavBarColor,
			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

		static EventManager eventManager;

		public static EventManager EventManager {
			get { return eventManager; }
			set { eventManager = value; }
		}

		public static void SetEventManager (EventManager eventManager)
		{
			EventManager = eventManager;
		}
	}
}

