using System;

using Xamarin.Forms;

#define TEST_EVENT_INFO 1

namespace InteractApp
{
	public class App : Application
	{
		public App ()
		{
			
			// The root page of your application
			#if TEST_EVENT_INFO
			MainPage = new EventInfoPage();
			#else 
			MainPage = new EventListPage();
			#endif
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
	}
}

