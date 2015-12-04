using System;
using System.Configuration;

using Android.App;
using Android.Runtime;

using Parse;

namespace InteractApp.Droid
{
	[Application]
	public class InteractApplication : Application
	{
		public InteractApplication (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer)
		{
		}

		public override void OnCreate ()
		{
			base.OnCreate ();

			ParseObject.RegisterSubclass<Event> ();
			ParseClient.Initialize (Constants.ApplicationId, Constants.Key);
			ParsePush.ParsePushNotificationReceived += ParsePush.DefaultParsePushNotificationReceivedHandler;
		}
	}
}
